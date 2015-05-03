"use strict";

var WLFlow;
WLFlow = WLFlow || {};
WLFlow.UI = WLFlow.UI || {};

/**
*need fix!!!
 * @class {WLFlow.UI.Notifier} Notifier about events
 */
WLFlow.UI.Notifier = function () {
	// singleton
	if (WLFlow.UI.Notifier.__instance) return WLFlow.UI.Notifier.__instance;
	WLFlow.UI.Notifier.__instance = this;

	var $container = $('<div class="wlflow-ui-notifier"></div>').appendTo('BODY').hide();

	var items = [];

	/**
	 * @param {WLFlow.UI.Notifier.Item} value
	 */
	function addMessage(value) {
		if (!(value instanceof WLFlow.UI.Notifier.Item)) {
			throw new Error('WLFlow.UI.Notifier.addMessage: a message must be instance of class WLFlow.UI.Notifier.Item');
		}

		var $item = $('<div>').addClass('alert alert-info fade in alert-' + value.getMessageTypeStyle()).appendTo($container);
		$item.append($('<span class="content" />').text(value.getDescription()));

		var $actionsContainer = $('<span>').addClass('alert-actions-container').appendTo($item);
		var actions = value.getActions();
		if (!$.isEmptyObject(actions)) {
			$.each(actions, function (action, description) {
				$('<button aria-hidden="true" class="btn btn-xs" type="button"></button>')
					.addClass('btn-' + value.getMessageTypeStyle())
					.appendTo($actionsContainer).addClass(action)
					.text(description)
					.on('click', function (e) {
						e.preventDefault();
						value.doAction(action);
					});
			});
		}
		actions = null;

		items.push({
			ui: $item,
			data: value
		});

		$item.alert();
		$item = null;

		$(value).on(WLFlow.UI.Notifier.Item.Event.DESTROY, function () {
			removeMessage(value);
			value = null;
		});

		updateVisibleStatus();
	}


	/**
	 * @param {WLFlow.UI.Notifier.Item} value
	 */
	function addMessageWithCloseAction(value) {
		var actions = value.getActions();
		actions['close'] = '✖';
		$(value).on(WLFlow.UI.Notifier.Item.Event.ACTION, function (e, actionName) {
			switch (actionName) {
				case 'close':
					value.destroy();

					break;
			}
		});

		addMessage(value);
	}

	function removeAll() {
		items = $.grep(items, function (item) {

			item.ui.alert('close');

			// @todo workaround. Should be fixed.
			setTimeout(function () {
				item.ui.remove();
				item = null;
				updateVisibleStatus();
			}, 1500);

			return false;
		});
	}

	/**
	 * @param {WLFlow.UI.Notifier.Item} value
	 */
	function removeMessage(value) {
		items = $.grep(items, function (item) {
			if (item.data == value) {
				item.ui.alert('close');

				// @todo workaround. Should be fixed.
				setTimeout(function () {
					item.ui.remove();
					item = null;
					updateVisibleStatus();
				}, 1000);

				return false;
			} else {
				return true;
			}
		});
	}

	function updateVisibleStatus() {
		$container[items.length ? 'slideDown' : 'slideUp']('fast');
	}

	// public methods
	this.addMessage = addMessage;
	this.addMessageWithCloseAction = addMessageWithCloseAction;
	this.removeAll = removeAll;
};

/**
 * @class {WLFlow.UI.Notifier.Item}
 * @param {string} text
 * @param {object} [actions]
 * @param {WLFlow.UI.Notifier.Item.Type} [messageType]
 */
WLFlow.UI.Notifier.Item = function (text, actions, messageType) {
	var self = this;

	actions = actions || {};

	function getDescription() {
		return text;
	}

	function getActions() {
		return actions;
	}

	/**
	 * @returns {WLFlow.UI.Notifier.Item.Type}
	 */
	function getMessageType() {
		return messageType || WLFlow.UI.Notifier.Item.Type.ERROR;
	}

	/**
	 * @returns {WLFlow.UI.Notifier.Item.Type}
	 */
	function getMessageTypeStyle() {
		return WLFlow.UI.Notifier.Item.TypeStyle[messageType || WLFlow.UI.Notifier.Item.Type.ERROR];
	}

	function addAction(name, title, callback) {
		actions[name] = title;

		$(self).on(WLFlow.UI.Notifier.Item.Event.ACTION, function (e, actionName) {
			if (name == actionName) {
				callback();
			}
		});
	}

	function doAction(name) {
		if (getActions().hasOwnProperty(name)) {
			$(self).trigger(WLFlow.UI.Notifier.Item.Event.ACTION, name);
		}
	}

	function destroy() {
		$(self)
			.trigger(WLFlow.UI.Notifier.Item.Event.DESTROY, self)
			.off();
		self = null;
	}

	// public methods
	this.getDescription = getDescription;
	this.getActions = getActions;
	this.getMessageType = getMessageType;
	this.getMessageTypeStyle = getMessageTypeStyle;
	this.doAction = doAction;
	this.addAction = addAction;
	this.destroy = destroy;
};

WLFlow.UI.Notifier.Item.Type = {
	WARNING: 'warning',
	ERROR: 'error',
	MESSAGE: 'message'
};

WLFlow.UI.Notifier.Item.TypeStyle = {
	warning: 'warning',
	error: 'danger',
	message: 'info'
};

WLFlow.UI.Notifier.Item.Event = {
	ACTION: 'fireAction',
	DESTROY: 'fireDestroy'
};

WLFlow.UI.Warning = {
	/**
	 *
	 * @type {WLFlow.UI.Notifier.Item|null}
	 */
	_currentMessage: null,

	show: function (message) {
		this.hide();
		this.currentMessage = new WLFlow.UI.Notifier.Item(message, null, WLFlow.UI.Notifier.Item.Type.WARNING);
		new WLFlow.UI.Notifier().addMessageWithCloseAction(this.currentMessage);
	},

	hide: function () {
		if (this.currentMessage == null) {
			return null;
		}
		this.currentMessage.destroy();
		this.currentMessage = null;
	}
};
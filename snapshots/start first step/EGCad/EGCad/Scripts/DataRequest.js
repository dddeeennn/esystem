"use strict";

egcad.Data = egcad.Data || {};

/**
 * @class {egcad.Data.Request}
 * @param {object} options
 */
egcad.Data.Request = function (options) {
	var self = this;

	/**
	 * @type {XMLHttpRequest|null}
	 */
	var xhr = null;

	/**
	 * @type {string}
	 * @see {egcad.Data.Request.Status}
	 */
	var status = null;

	/**
	 * @type {egcad.Data.Request.Error|null}
	 */
	var lastError = null;

	function init() {
		setStatus(egcad.Data.Request.Status.INIT);
	}

	function destroy() {
		setStatus(egcad.Data.Request.Status.DESTROYED);
		if (xhr) {
			xhr.abort();
			xhr = null;
		}
		$(self).off();
		self = null;
	}

	function getStatus() {
		return status;
	}

	function setStatus(value) {
		if (status === value) return;

		status = value;
		$(self).trigger(egcad.Data.Request.Event.CHANGE, self);
	}


	function isDestroyed() {
		return getStatus() == egcad.Data.Request.Status.DESTROYED;
	}

	function exec() {
		if (getStatus() == egcad.Data.Request.Status.LOAD) return;

		lastError = null;

		setStatus(egcad.Data.Request.Status.LOAD);
		xhr = $.ajax($.extend(
			{},
			options,
			{
				success: onSuccess,
				error: onError
			}
		));
	}

	function processResult(value) {
		if ($.isFunction(options.success)) {
			options.success(value);
		}
	}

	function onSuccess(response) {
		if (isDestroyed()) return;

		setStatus(egcad.Data.Request.Status.READY);
		processResult(response);
	}


	function onError() {
		if (isDestroyed()) return;

		error(
			new egcad.Data.Request.Error(
				egcad.Data.Request.Exception.getInfo(WLFlow.Data.Request.Exception.TRANSPORT_PROBLEM),
				true
			)
		);
	}

	/**
	 * @param {egcad.Data.Request.Error} value
	 */
	function error(value) {
		lastError = value;
		setStatus(egcad.Data.Request.Status.ERROR);
		if ($.isFunction(options.error)) {
			options.error(value);
		}
	}

	/**
	 * @returns {egcad.Data.Request.Error|null}
	 */
	function getLastError() {
		return lastError;
	}

	init();

	// public methods
	this.exec = exec;
	this.destroy = destroy;
	this.getStatus = getStatus;
	this.getLastError = getLastError;
};

/**
 * @class {egcad.Data.Request.Error}
 * @param {string} message
 * @param {boolean} [initCanRetry]
 */
egcad.Data.Request.Error = function (message, initCanRetry) {
	var initCanRetry = initCanRetry || false;

	/**
	 * @returns {string|null}
	 */
	function getDescription() {
		return message || 'egcad.Data.Request.Error: description is not defined';
	}

	/**
	 * Returns true if request can retry again
	 * @returns {boolean}
	 */
	function canRetry() {
		return initCanRetry;
	}

	// public methods
	this.getDescription = getDescription;
	this.canRetry = canRetry;
};

egcad.Data.Request.Event = {
	CHANGE: 'change'
};

egcad.Data.Request.Status = {
	INIT: 'init',
	LOAD: 'load',
	READY: 'ready',
	ERROR: 'error',
	DESTROYED: 'destroyed'
};

egcad.Data.Request.Exception = {
	TRANSPORT_PROBLEM: 1,
	INCORRECT_RESULT: 2,
	SERVER_ERROR: 3,
	getInfo: function (exceptionType) {
		var message;
		switch (exceptionType) {
			case egcad.Data.Request.Exception.TRANSPORT_PROBLEM:
				message = 'Transport error. Failed to retrieve data from the server';
				break;

			case egcad.Data.Request.Exception.INCORRECT_RESULT:
				message = 'Invalid response has been received from the server.';
				break;

			case egcad.Data.Request.Exception.SERVER_ERROR:
				message = 'An error occurred on server side.';
				break;

			default:
				message = 'Unknown exception';
				break;
		}

		return message;
	}
};
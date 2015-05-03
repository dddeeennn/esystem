var egcad = egcad || {};

var Utils = Utils || {};
Utils.cookies = {
	defaultPath: '/',
	get: function (name) {
		var matches = document.cookie.match(new RegExp(
		    "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
	    ));
		return matches ? decodeURIComponent(matches[1]) : undefined;
	},

	set: function (name, value, props) {
		props = props || {}
		var exp = props.expires;
		if (typeof exp == "number" && exp) {
			var d = new Date();
			d.setTime(d.getTime() + exp * 1000);
			exp = props.expires = d;
		}
		if (exp && exp.toUTCString) {
			props.expires = exp.toUTCString();
		}

		props.path = props.path || this.defaultPath;

		value = encodeURIComponent(value);
		var updatedCookie = name + "=" + value;
		for (var propName in props) {
			updatedCookie += "; " + propName;
			var propValue = props[propName];
			if (propValue !== true) {
				updatedCookie += "=" + propValue;
			}
		}
		document.cookie = updatedCookie;
	},

	remove: function (name) {
		this.set(name, null, { expires: -1 });
	},

	setDefaultPath: function (value) {
		this.defaultPath = value;
	}
};


var DynamicSideBar = function ($container) {
	$container.hover(
		function () {
			$container.addClass('hover');
		}, function () {
			$container.removeClass('hover');
		}
	);

	var $ui = {
		switcher: $container.find('.btn-sticker-mode > A'),
		body: $('BODY')
	};

	$ui.switcher.on('click', function (e) {
		e.preventDefault();
		setCompactMode(!getCompactMode());
		$(window).trigger('resize', e);
		$ui.body.trigger('scroll', e);
	});

	function setCompactMode(value, skipStore) {

		value = !!value;
		$ui.body.toggleClass('view-compact', value);

		var $icon = $ui.switcher.find('.glyphicon');
		$icon.removeClass('glyphicon-arrow-left glyphicon-check');
		$icon.addClass(value ? 'glyphicon-check' : ' glyphicon-arrow-left');

		$ui.switcher.attr(
			'title',
			value ? 'click for fix' : 'click for unpin'
		);

		if (!skipStore) {
			// one year storing
			Utils.cookies.set('egcadLeftSideBarPin', !value, { expires: 365 * 24 * 60 * 60 });
		}
	}

	function getCompactMode() {
		return $ui.body.hasClass('view-compact');
	}

	var storedPinState = Utils.cookies.get('egcadLeftSideBarPin');
	setCompactMode(
		storedPinState === undefined
		? $(window).width() < 1024
		: storedPinState !== 'true',
		true
	);
};

/*customize file input*/

$(function () {
	$.fn.bootstrapFileInput = function () {

		this.each(function (i, elem) {

			var $elem = $(elem);

			// Maybe some fields don't need to be standardized.
			if (typeof $elem.attr('data-bfi-disabled') != 'undefined') {
				return;
			}

			// Set the word to be displayed on the button
			var buttonWord = 'Browse';

			if (typeof $elem.attr('title') != 'undefined') {
				buttonWord = $elem.attr('title');
			}

			var className = '';

			if (!!$elem.attr('class')) {
				className = ' ' + $elem.attr('class');
			}

			// Now we're going to wrap that input field with a Bootstrap button.
			// The input will actually still be there, it will just be float above and transparent (done with the CSS).
			$elem.wrap('<a class="file-input-wrapper btn btn-default ' + className + '"></a>').parent().prepend(buttonWord);
		})

			// After we have found all of the file inputs let's apply a listener for tracking the mouse movement.
		// This is important because the in order to give the illusion that this is a button in FF we actually need to move the button from the file input under the cursor. Ugh.
			.promise().done(function () {

				// As the cursor moves over our new Bootstrap button we need to adjust the position of the invisible file input Browse button to be under the cursor.
				// This gives us the pointer cursor that FF denies us
				$('.file-input-wrapper').mousemove(function (cursor) {

					var input, wrapper,
						wrapperX, wrapperY,
						inputWidth, inputHeight,
						cursorX, cursorY;

					// This wrapper element (the button surround this file input)
					wrapper = $(this);
					// The invisible file input element
					input = wrapper.find("input");
					// The left-most position of the wrapper
					wrapperX = wrapper.offset().left;
					// The top-most position of the wrapper
					wrapperY = wrapper.offset().top;
					// The with of the browsers input field
					inputWidth = input.width();
					// The height of the browsers input field
					inputHeight = input.height();
					//The position of the cursor in the wrapper
					cursorX = cursor.pageX;
					cursorY = cursor.pageY;

					//The positions we are to move the invisible file input
					// The 20 at the end is an arbitrary number of pixels that we can shift the input such that cursor is not pointing at the end of the Browse button but somewhere nearer the middle
					moveInputX = cursorX - wrapperX - inputWidth + 20;
					// Slides the invisible input Browse button to be positioned middle under the cursor
					moveInputY = cursorY - wrapperY - (inputHeight / 2);

					// Apply the positioning styles to actually move the invisible file input
					input.css({
						left: moveInputX,
						top: moveInputY
					});
				});

				$('body').on('change', '.file-input-wrapper input[type=file]', function () {

					var fileName;
					fileName = $(this).val();

					// Remove any previous file names
					$(this).parent().next('.file-input-name').remove();
					if (!!$(this).prop('files') && $(this).prop('files').length > 1) {
						fileName = $(this)[0].files.length + ' files';
						//$(this).parent().after('<span class="file-input-name">'+$(this)[0].files.length+' files</span>');
					}
					else {
						// var fakepath = 'C:\\fakepath\\';
						// fileName = $(this).val().replace('C:\\fakepath\\','');
						fileName = fileName.substring(fileName.lastIndexOf('\\') + 1, fileName.length);
					}

					$(this).parent().after('<span class="file-input-name">' + fileName + '</span>');
				});

			});

	}
});

Modal = function () {
	var hideCallback = null;

	var $modal = $('<div class="modal fade" id="modal-window" tabindex="-1" role="dialog" aria-hidden="true">\
	  <div class="modal-dialog">\
		<div class="modal-content">\
		  <div class="modal-header">\
			<div class="modal-title">Modal title</div>\
		  </div>\
		  <div class="modal-body"></div>\
		  <div class="modal-footer"></div>\
		</div>\
	  </div>\
	</div>').appendTo('BODY').modal('hide');

	$modal.on('hidden.bs.modal', function () {
		$(this).data('bs.modal', null);
		$modal.remove();
		$modal = null;
	});

	function show() {
		$modal.modal('show');
	}

	function hide() {
		if ($.isFunction(hideCallback)) {
			hideCallback();
		}
		$modal.modal('hide');
	}

	function setHideCallback(value) {
		hideCallback = value;
	}

	function setTitle(value) {
		$modal.find('.modal-title').text(value || '');
	}

	function setButtons(values) {
		var $buttons = $modal.find('.modal-footer').empty();
		$.each(values || [], function (index, item) {
			var $button = $('<button type="button" class="btn"/>').appendTo($buttons);
			$button.text(item.label || 'Button #' + index).addClass(item.cssClass || '');

			if ($.isFunction(item.callback)) {
				$button.on('click', item.callback);
			}

			if ($button.hasClass('action-close')) {
				$button.attr('data-dismiss', 'modal');
			}
		});
	}

	function destroy() {
		hide();
		$(document).trigger('hidden.bs.modal');

	}

	/**
	 * @return {jQuery}
	 */
	function getWindowElement() {
		return $modal;
	}

	/**
	 * @return {jQuery}
	 */
	function getContentElement() {
		return $modal.find('.modal-body');
	}

	// public methods
	this.show = show;
	this.hide = hide;
	this.setTitle = setTitle;
	this.setHideCallback = setHideCallback;
	this.setButtons = setButtons;
	this.destroy = destroy;
	this.getWindowElement = getWindowElement;
	this.getContentElement = getContentElement;
};
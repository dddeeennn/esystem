"use strict";

egcad.Data = egcad.Data || {};

/**
 * @class {egcad.DataProvider} The layer provides data from server
 */
egcad.Data.Provider = function () {
	var self = this;
	var CACHE_MAX_SIZE = 200;

	/**
	  * @type {object} {name => egcad.Data.Request} Active requests to the server by name
	  */
	var requests = {};

	/**
	 * Cache of data of lists requested via API
	 * @type {Array}
	 */
	var listCache = [];

	/**
	 * @param {string} name
	 * @param {object} options
	 */
	function request(name, options) {
		if (!name) {
			throw new Error('egcad.Data.Provider: name of request is not defined.');
			return;
		}

		destroyRequest(name);

		var cacheId = calcCacheId(options);
		if (cacheId) {
			var cache = getCache(cacheId);
			if (cache) {
				setTimeout(function () {
					processHandler(options, cache);
				}, 10);
				return;
			}
		}

		var request = requests[name] = new egcad.Data.Request(
			cacheId
			? $.extend(
				{},
				options,
				{
					success: function (response) {
						storeCache(cacheId, response);
						processHandler(options, response);
					}
				}
			)
			: options);

		$(request).bind(egcad.Data.Request.Event.CHANGE, requestChangeHandler);
		request.exec();
	}

	function processHandler(options, response) {
		var successHandler = options.success;
		if ($.isFunction(successHandler)) successHandler(response);
	}

	function requestChangeHandler(event, request) {
		$(self).trigger(egcad.Data.Provider.Event.CHANGE, self);
	}


	/**
	 * Returns an identifier for storage in the cache
	 * Return null if the request can not be cached
	 * @param options
	 * @returns {string|null}
	 */
	function calcCacheId(options) {
		if (options.type.toLowerCase() == 'post' || options.skipCache) {
			return null;
		}
		return (options.url + '#' + JSON.stringify(options.data)).toUpperCase();
	}

	function destroyRequest(name) {
		if (requests[name]) {
			requests[name].destroy();
			delete requests[name];
		}
	}

	function getCache(requestKey) {
		for (var i = listCache.length - 1; i >= 0; i--) {
			var item = listCache[i];
			if (item.key == requestKey) return item.data;
		}
		return null;
	}

	function storeCache(requestKey, data) {
		listCache.push({ key: requestKey, data: data });
		if (listCache.length > CACHE_MAX_SIZE) listCache.shift();
	}

	/**
	 * @returns {Object<requestName, Data.Request.Error>}
	 */
	function getErrors() {
		var errors = {};
		$.each(requests, function (key, request) {
			var error = request.getLastError();
			if (error) {
				errors[key] = error;
			}
		});

		return errors;
	}

	function resend(requestName) {
		/**
		 * @type {egcad.Data.Request}
		 */
		var request = requests[requestName];
		if (request && request.getStatus() == WLFlow.Data.Request.Status.ERROR) {
			request.exec();
		}
	}

	// public methods
	this.request = request;
	this.getErrors = getErrors;
	this.resend = resend;
	this.destroyRequest = destroyRequest;
};

egcad.Data.Provider.Event = {
	CHANGE: 'fireChange'
};

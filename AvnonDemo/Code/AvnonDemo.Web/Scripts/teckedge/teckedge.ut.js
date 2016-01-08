var teckedge = teckedge || {};

teckedge.ut = (function () {
    'use strict';
    //GENERAL ========================================================================
    //this returns a new object, which is a copy of the original object
    function clone(obj) {
        if (obj === null || obj === undefined || typeof (obj) !== 'object') {
            return obj;
        }

        var temp = obj.constructor(); // changed

        for (var key in obj) {
            temp[key] = clone(obj[key]);
        }

        return temp;
    }

    //HTTP ========================================================================
   
    function requestToQueryString(url, data) {
        if (data) {
            var alreadyContainsQsMark = contains(url, "?");
            url += alreadyContainsQsMark ? '&' : '?'; //TODO.. assumes qsMark is not at the end
            var firstItem = true;
            for (var prop in data) {
                url += firstItem ? '' : '&';
                if (data.hasOwnProperty(prop)) {
                    url += prop + '=' + data[prop];
                }
                firstItem = false;
            }
        }

        return url;
    }

    function contains(items, i) {
        var indx = items.indexOf(i);
        return indx > -1;
    }

    function mapTo(source, result) {
        for (var resultProp in result) {
            for (var sourceProperty in source) {
                if (resultProp == sourceProperty) {
                    result[resultProp] = source[sourceProperty];
                }
            }
        }
    }

    function isArray(obj) {
        return obj instanceof Array;
    }

    //this checks whether an item is an object or not.
    //NULL returns false
    function isObject(obj) {
        return obj !== null && typeof obj === 'object';
    }


    return {
       
        requestToQueryString: requestToQueryString,
        mapTo: mapTo,
        isArray: isArray,
        isObject: isObject,
        clone:clone
    }
})();

(function () {
    'use strict';

    var serviceId = 'messageService';
    App.factory(serviceId, ['requestHandler', 'utilities', messageService]);
    function messageService(request, ut) {
        var baseUrl = 'api/message';

        var service = {
            getAll: getAll,
            getById: getById,
            save: save,
            update: update,
            remove: remove
        }

        return service;

        function getAll(callback) {
            request.get(baseUrl, {}).then(function (response) {
                if (response.success) {
                    if (callback)
                        callback(response.data);
                }
            });
        }

        function getById(id, callback) {
            var url = baseUrl + '/' + id;
            request.get(url, {}).then(function (response) {
                if (response.success) {
                    if (callback)
                        callback(response.data);
                }
            });
        }

        function save(item, callback) {
            var url = baseUrl;
            request.post(url, item).then(function (response) {
                if (response.success) {
                    if (callback)
                        callback(response.data);
                }
            });
        }

        function update(item, callback) {
            var url = baseUrl + '/' + item.id;
            request.put(url, item).then(function (response) {
                if (response.success) {
                    if (callback)
                        callback(response.data);
                }
            });
        }

        function remove(id, callback) {
            var url = baseUrl + '/' + id;
            request.remove(url, {}).then(function (response) {
                if (response.success) {
                    if (callback)
                        callback(response.data);
                }
            });
        }
    };
})();

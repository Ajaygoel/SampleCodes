"use strict";
//var TApp = angular.module('teckedge.angular',[]);

//-------------------------- C O N F I G ------------------------------

App.value('utilities', teckedge.ut);


//----------------------- D I R E C T I V E S -----------------------------------------
(function () {
    'use strict';

    App.directive('ssPager', ['utilities', ssPager]);

    function ssPager(ut) {

        var directive = {
            replace: true,
            restrict: 'E',
            template: "" +
                "<div class='clearfix'>" +
                "    <div class='pull-left'>" +
                "       Page &nbsp;<a href='' class='btn btn-sm btn-default' data-ng-disabled='request.pn === 1' data-ng-click='request.pn = request.pn - 1;'>" +
                "            <i class='fa fa-angle-left'></i>" +
                "        </a>&nbsp;" +
                "        <input type='number' data-ng-model='request.pn' class='input-inline input-sm' data-ng-disabled='container.pages===1' min='1' max={{container.pages}} />" +
                "        &nbsp;<a href='' class='btn btn-sm btn-default' data-ng-disabled='container.p === container.pages' data-ng-click='request.pn = request.pn + 1;'>" +
                "            <i class='fa fa-angle-right'></i>" +
                "        </a>&nbsp; of {{container.pages}}" +
                "    </div>" +
                "    <div class='pull-right'> Total: {{container.count}} {{itemsLabel}} </div>" +
                "</div>",
            controller: ctrl,
            scope: {
                container: '=', //this is the itemsData container object that the grid data is contained in
                request: '=', //this is the dataRequest object that will be updated when the pageNumber is changed
                itemsLabel: '@?' //this is the type of items in the grid eg: cows, orders, contacts etc. 
            }
        };

        return directive;

        function ctrl($scope) {
        }
    };
})();

(function () {
    'use strict';

    App.directive('ssActions', ['$timeout', 'utilities', dlActions]);

    function dlActions($timeout, ut) {
        var directive = {
            replace: true,
            restrict: 'E',
            templateUrl: 'Scripts/teckedge/templates/ssActions.html',
            controller: ctrl,
            scope: {
                view: '=?', //this is the current state of the view 'details', 'edit', 'delete'
                editable: '=?',
                deletable: '=?',
                save: '=?', //this is the save method that will be called when saveitem is clicked. the item and a callback will be passed to be returned so it knows when the saving is complete
                remove: '=?', //this is the remove method that will be called when removeitem is clicked. the item and a callback will be passed to be returned so it knows when the deletion is complete
                cancel: '=?', //this is the cancel method that will be called when in edit/create view, the person decides to cancel. We need to discard of the newItem if it a create scenario
                item: '=?' //this is the item that the actions are on. the actions control the item._view property of the item
            }
        };

        return directive;

        function ctrl($scope) {
            $scope.view = $scope.view || 'details';
            $scope.editable = $scope.editable == undefined ? true : $scope.editable;
            $scope.deletable = $scope.deletable == undefined ? true : $scope.deletable;
            if ($scope.remove == undefined)
                $scope.deletable = false;

            $scope.saving = false;
            $scope.deleting = false;

            $scope.saveItem = saveItem;
            $scope.removeItem = removeItem;
            $scope.cancelItem = cancelItem;
            $scope.editItem = editItem;

            function saveItem() {
                if ($scope.save) {
                    $scope.saving = true;
                    $scope.save($scope.item, function () {
                        $scope.saving = false;
                        $scope.view = 'details';
                        $scope.item._view = 'details';
                    });
                }

                //register an error after 10 seconds if still saving!
                $timeout(function () {
                    if ($scope.saving) {
                    }
                }, 10000);
            }

            function removeItem() {
                if ($scope.remove) {
                    $scope.deleting = true;
                    $scope.remove($scope.item, function () {
                        $scope.deleting = false;
                        $scope.view = 'details';
                        $scope.item._view = 'details';
                    });
                }

                //register an error after 10 seconds if still deleting!
                $timeout(function () {
                    if ($scope.deleting) {
                    }
                }, 10000);
            }

            function cancelItem() {
                //restore original item
                if ($scope.originalItem) {
                    $scope.item = ut.clone($scope.originalItem);
                    $scope.originalItem = undefined;
                }

                //BUG, TODO, Cancelling creating new item not working properly
                $scope.view = 'details';
                $scope.item._view = 'details';

                if ($scope.cancel) $scope.cancel($scope.item); //don't bother with a callback... don't care

                //this will remove the NewItem in the instance where the CANCEL method is called during a create
                if ($scope.item && ($scope.item.id === undefined && $scope.item.Id === undefined)) {
                    $scope.item = undefined;
                }
            }

            function editItem() {
                $scope.view = "edit";
                $scope.originalItem = ut.clone($scope.item);
            }
        }
    };
})();


//----------------------- S E R V I C E S -----------------------------------------

(function () {
    'use strict';

    var serviceId = 'requestHandler';
    App.factory(serviceId, ['$q', '$http', 'utilities', requestHandler]);

    function requestHandler($q, $http, ut) {

        var service = {
            get: getRequest,
            put: putRequest,
            post: postRequest,
            patch: patchRequest,
            remove: deleteRequest
        }

        return service;

        function getRequest(url, data) {
            if (data) {
                var isObj = ut.isObject(data);
                var isArray = ut.isArray(data);

                if (isObj) {
                    url = ut.requestToQueryString(url, data);
                } else if (isArray) {
                    //TODO... what to do for an array?
                } else {
                    //assumes its id
                    url = ut.requestToQueryString(url, { id: data });
                }
            }

            return makeRequest(url, 'GET', {});
        }

        function putRequest(url, data) {
            var d = data || {};
            return makeRequest(url, 'PUT', d);
        }

        function postRequest(url, data) {
            var d = data || {};
            return makeRequest(url, 'POST', d);
        }

        function patchRequest(url, data) {
            var d = data || {};
            return makeRequest(url, 'PATCH', d);
        }

        function deleteRequest(url, data) {
            var d = data || {};
            return makeRequest(url, 'DELETE', d);
        }

        function makeRequest(url, method, dataToSend) {
            var defer = $q.defer();

            $http({ method: method, url: url, data: dataToSend }).
                success(function (data, status, headers, config) {
                    defer.resolve(data);
                }).
                error(function (data, status, headers, config) {
                    //defer.fail(data);    
                });
            return defer.promise;
        };
    }
})();




(function () {
    'use strict';

    var serviceId = 'context';

    App.factory(serviceId, ['$injector', context]);

    function context($injector) {

        function getRepo(entityName) {
            var fullRepoName = entityName + 'Service';
            var repo = $injector.get(fullRepoName);
            return repo;
        }

        return getRepo;
    }
})();

//----------------------- M O D E L S -----------------------------------------
(function () {
    'use strict';

    var serviceId = 'models';

    App.factory(serviceId, ['$injector', models]);
    function models($injector) {
        function getModel(entityName) {
            var fullModelName = entityName + 'Model';
            var repo = $injector.get(fullModelName);
            return repo;
        }

        return getModel;
    }
})();



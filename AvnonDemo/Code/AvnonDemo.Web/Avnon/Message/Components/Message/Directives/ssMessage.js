(function () {
    'use strict';
    App.directive('ssMessage', ['$location', 'models', 'context', 'utilities', ssMessage]);

    function ssMessage($location, models, context, ut) {
        var directive = {
            replace: true,
            restrict: 'EA',
            templateUrl: 'Avnon/Message/Components/Message/Directives/ssMessage.html',
            controller: ctrl,
            scope: {
            }
        };

        return directive;
        function ctrl($scope) {

            var entityName = 'message';
            var service = context(entityName);
            activate();
            $scope.messageList = [];
            function activate() {
                $scope.message = {
                    user: {
                        id: 1
                    },
                    images: []
                };
                getUserMessages();
            }

            function getUserMessages() {
                $scope.loading = true;
                service.getAll(function (data) {
                    $scope.loading = false;
                    $scope.messageList = data;
                    angular.forEach($scope.messageList, function (message, indx) {
                        message._view = "detail";
                    });
                });
            }

            $scope.save = save;
            function save(bol) {
                $scope.onClickValidation = !bol;
                if (!bol) { return; }
                service.save($scope.message, function (data) {
                    activate();
                });
            }

            $('#fileupload1').fileupload({
                url: "/imageUpload/fileuploader",
                dataType: 'text',
                done: function (e, data) {
                    //First three are response code
                    var code = data.result.indexOf("Success");
                    var imagePath;
                    // if not returned the path, sent it back from here with exception
                    if (code == -1) {
                        alert("Getting error While Upload Image");
                        return;
                    }
                    imagePath = data.result.split(",")[1].replace("</html>", "");
                    $scope.$apply(function () {
                        $scope.message.images.push({ "url": imagePath });
                    });
                },
            }).bind('fileuploadfail', function (e, data) {
                alert("Getting error While Upload Image");
            });
            $scope.deleteMessage = deleteMessage;
            function deleteMessage(message) {
                service.remove(message.id, function (data) {
                    activate();
                });
            }
            $scope.editMessage = editMessage;
            function editMessage(message) {
                $scope.oldMessage = {};
                $scope.oldMessage = angular.copy(message);
                message._view = "edit";
            }
            $scope.cancelUpdateMessage = cancelUpdateMessage;
            function cancelUpdateMessage(message) {
                message._view = "detail";
                message.text = angular.copy($scope.oldMessage.text);
            }
            $scope.okUpdateMessage = okUpdateMessage;
            function okUpdateMessage(message) {
                service.update(message, function (data) {
                    activate();
                });
            }
        }
    };
})();

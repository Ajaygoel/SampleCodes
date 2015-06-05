'use strict';

var cargoclixAppControllers = angular.module('cargoclixAppControllers', []);

// Path: /Bookings
cargoclixAppControllers.controller('BookingsCtrl', [
    '$scope', '$location', '$http', function ($scope, $location, $http) {
        $scope.$root.title = 'Cargoclix';
        $scope.Bookings = [];
        $scope.GetBookings = function (mobileNumber) {
            $http.post('/api/Bookings/GetBookings', {
                mobileNumber: mobileNumber
            }).
                success(function (data, status, headers, config) {
                    if (data != null) {
                        $scope.Bookings = data;
                    } else {
                        toastr.error("No Bookings found");
                    }
                }).
                error(function (data, status, headers, config) {
                    toastr.error("No Bookings found,Error Occured");
                });
        };
    }
]);


cargoclixAppControllers.controller('BookingDetailsCtrl', [
    '$scope', '$location', '$http', '$routeParams', function ($scope, $location, $http, $routeParams) {
        $scope.$root.title = 'Cargoclix';
        $scope.$root.BookingDetail = [];
        var id = $routeParams.bookingId;
        $scope.GetBookingDetails = function () {
            $http.get('/api/Bookings/GetBookingDetails/' + id ).
                success(function (data, status, headers, config) {
                    if (data != null) {
                        $scope.$root.BookingDetail = data;
                    } else {
                        toastr.error("No Booking details found");
                    }
                }).
                error(function (data, status, headers, config) {
                    toastr.error("No Booking details found,Error Occured");
                });
        };

    }
]);


cargoclixAppControllers.controller('BookingDetailsReportDelayCtrl', [
    '$scope', '$location', '$http', '$routeParams', function($scope, $location, $http, $routeParams) {
        var id = $scope.$root.BookingDetail.Id;
        $scope.NewEta = "";
        $scope.ReasonForDelay = "";
        $scope.FreeText = "";
        $scope.ReportDelay = function() {
            $http.post('/api/Bookings/PostDelay', {
                    SlotId: id,
                    NewEta: $scope.NewEta,
                    ReasonForDelay: $scope.ReasonForDelay,
                    FreeText: $scope.FreeText
                }).
                success(function(data, status, headers, config) {
                    if (data != null) {
                        $location.path('/bookings');
                        toastr.success("Delay Reported");

                    } else {
                        toastr.error("No able to report Delay");
                    }
                }).
                error(function(data, status, headers, config) {
                    toastr.error("Error Occured");
                });
        };
    }
]);


cargoclixAppControllers.controller('BookingDetailsOnWayCtrl', [
    '$scope', '$location', '$http', '$routeParams', function ($scope, $location, $http, $routeParams) {
        var id = $scope.$root.BookingDetail.Id;
        //Post onway here
    }
]);


cargoclixAppControllers.controller('BookingDetailsSendMessageCtrl', [
    '$scope', '$location', '$http', '$routeParams', function ($scope, $location, $http, $routeParams) {
        var id = $scope.$root.BookingDetail.Id;
        $scope.Description = "";
        $scope.SendMessage = function () {
            $http.post('/api/Bookings/SendMessage', {
                SlotId: id,
                Description: $scope.Description
            }).
        success(function (data, status, headers, config) {
            if (data != null) {
                $location.path('/bookings');
                toastr.success("Message Sent");
            } else {
                toastr.error("No able to Sent Messsage");
            }
        }).
        error(function (data, status, headers, config) {
            toastr.error("Error Occured");
        });
        };
    }
]);


// Path: /login
cargoclixAppControllers.controller('LoginCtrl', [
    '$scope', '$location', "$http", function ($scope, $location, $http) {
        $scope.$root.title = 'Cargoclix.com | Sign In';
        $scope.$root.UserInfo = [];
        $scope.login = function (mobileNumber) {
            $http.post('/api/account/login', {
                mobileNumber: mobileNumber
            }).
              success(function (data, status, headers, config) {
                  if (data != null) {
                      if (data.IsAuthorized) {
                          $scope.$root.UserInfo = data;
                          $location.path('/bookings');
                          toastr.success("Login Successful");
                      } else {
                          toastr.error("not a valid user login");
                      }
                  } else {
                      toastr.error("not a valid user login");
                  }
              }).
              error(function (data, status, headers, config) {
                  toastr.error("not a valid user login,Error Occured");
              });
            return false;
        };
    }
]);


// Path: /error/404
cargoclixAppControllers.controller('Error404Ctrl', ['$scope', '$location', function ($scope, $location) {
    $scope.$root.title = 'Error 404: Page Not Found';

}]);
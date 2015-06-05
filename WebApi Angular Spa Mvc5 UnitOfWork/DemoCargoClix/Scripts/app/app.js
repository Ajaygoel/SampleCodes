var cargoclixApp = angular.module('cargoclixApp', [
  'ngRoute',
  'cargoclixAppControllers'
]);

cargoclixApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/', {
          templateUrl: '/views/Login.cshtml',
          controller: 'LoginCtrl'
      }).
        when('/bookings', {
            templateUrl: '/views/Bookings.cshtml',
            controller: 'BookingsCtrl'
        }).

        when('/bookingDetails/:bookingId', {
            templateUrl: '/views/BookingDetails.cshtml',
            controller: 'BookingDetailsCtrl'
        }).
        when('/booking/status/onWay', {
            templateUrl: '/views/OnWay.cshtml',
            controller: 'BookingDetailsOnWayCtrl'
        }).
        when('/booking/status/reportDelay', {
            templateUrl: '/views/ReportDelay.cshtml',
            controller: 'BookingDetailsReportDelayCtrl'
        }).
        when('/booking/status/sendMessage', {
            templateUrl: '/views/EnterMessage.cshtml',
            controller: 'BookingDetailsSendMessageCtrl'
        }).
        otherwise({
            templateUrl: '/views/404.cshtml',
        });
  }]);
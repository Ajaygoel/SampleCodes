'use strict';
App.config(["$routeProvider", appConfig]);
function appConfig($routeProvider) {

    //PRODUCTS
    $routeProvider.when('/', { templateUrl: 'Avnon/Message/Pages/Message/message.html', controller: 'MessageCtrl' });
    $routeProvider.otherwise({ redirectTo: '/' });
};
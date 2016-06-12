(function () {
    'use strict';
    var myApp = angular.module('SocialEventsApp', ['ngRoute', 'socialEventsService']);

    myApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'partials/events.html',
                controller: 'socialEventsController'
            })
            .when('/events/add', {
                templateUrl: 'partials/add.html',
                controller: 'socialEventsAddController'
            })
            .when('/events/edit/:id', {
                templateUrl: 'partials/edit.html',
                controller: 'socialEventsEditController'
            })
            .when('/events/delete/:id', {
                templateUrl: 'partials/delete.html',
                controller: 'socialEventsDeleteController'
            })
            .otherwise({ redirectTo: "/" });

        //check browser support
        if (window.history && window.history.pushState) {
            //$locationProvider.html5Mode(true); will cause an error $location in HTML5 mode requires a  tag to be present! Unless you set baseUrl tag after head tag like so: <head> <base href="/">

            // to know more about setting base URL visit: https://docs.angularjs.org/error/$location/nobase

            // if you don't wish to set base URL then use this
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        }
    }])
})();
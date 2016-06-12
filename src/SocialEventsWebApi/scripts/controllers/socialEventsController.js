(function () {
    'use strict';

    var mainModule = angular
        .module('SocialEventsApp');
        
    mainModule
        .controller('socialEventsController', socialEventsController)
        .controller('socialEventsAddController', socialEventsAddController)
        .controller('socialEventsEditController', socialEventsEditController)
        .controller('socialEventsDeleteController', socialEventsDeleteController);

        

    socialEventsController.$inject = ['$scope', 'socialEvents', '$sce'];

    mainModule.filter('trusted', ['$sce', function ($sce) {
        return function (url) {
            return $sce.trustAsResourceUrl(url);
        };
    }]);
    //ctor
    function socialEventsController($scope, socialEvents) {

        $scope.socialEvents = socialEvents.query();
    }

    //functions
    function _displayServerSideValidationErrors($scope, error) {
        $scope.validationErrors = [];

        var errorObject = error.data;

        if (errorObject) {
            for (var key in errorObject) {
                var errorMessage = errorObject[key][0];
                $scope.validationErrors.push(errorMessage);
            }
        }

    }

    function setDatesAsUTC($scope) {
        var localTimeCreationDate = new Date($scope.socialEvent.CreationDate);
        var localTimeEventDate = new Date($scope.socialEvent.EventDate);
        var utcCreationDate = localTimeCreationDate.getTime() + (localTimeCreationDate.getTimezoneOffset() * 60000);
        var utcEventDate = localTimeEventDate.getTime() + (localTimeEventDate.getTimezoneOffset() * 60000);

        $scope.socialEvent.CreationDate = new Date(utcCreationDate);
        $scope.socialEvent.EventDate = new Date(utcEventDate);
    }
    //controllers
    socialEventsAddController.$inject = ['$scope', 'socialEvents', '$location'];

    function socialEventsAddController($scope, socialEvents, $location) {

        //assing a new instance of the custom made AngularJs service [factory('serviceId' is the name to use]
        $scope.socialEvent = new socialEvents();

        $scope.addEvent = function () {
            $scope.socialEvent.$save(function () {
                $scope.socialEvent.CreationDate = new Date($scope.socialEvent.CreationDate);
                $scope.socialEvent.EventDate = new Date($scope.socialEvent.EventDate);
                $location.path('/');
            }, function (error) {
                console.log('Got an error back from the server');
                _displayServerSideValidationErrors($scope, error);
            });
        }
    }

    socialEventsEditController.$inject = ['$scope', 'socialEvents', '$location', '$routeParams'];

    function socialEventsEditController($scope, socialEvents, $location, $routeParams) {
        $scope.socialEvent = socialEvents.get({ id: $routeParams.id }, function ()  
        {
            setDatesAsUTC($scope)
        });
        

        $scope.editEvent = function () {
            $scope.socialEvent.$update(function () {
                $scope.socialEvent.CreationDate = new Date($scope.socialEvent.CreationDate);
                $scope.socialEvent.EventDate = new Date($scope.socialEvent.EventDate);
                $location.path('/');
            });
        }

        $scope.cancelEdit = function () {
            $location.path('/');
        }
    }

    socialEventsDeleteController.$inject = ['$scope', 'socialEvents', '$location', '$routeParams'];

    function socialEventsDeleteController($scope, socialEvents, $location, $routeParams) {
        $scope.socialEvent = socialEvents.get({ id: $routeParams.id });

            $scope.deleteEvent = function () {
                $scope.socialEvent.$remove(function () {
                    $location.path('/');
                });
            }
        }
})();

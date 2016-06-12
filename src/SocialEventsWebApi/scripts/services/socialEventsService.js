(function () {
    'use strict';

    var socialEventsService =  angular
        .module('socialEventsService', ['ngResource']);

    socialEventsService.factory('socialEvents', ['$resource', function ($resource) {
        return $resource('/api/socialEvents/:id', { id: '@Id' }, {
            'update': { method: 'PUT' }
        });

    }]);

})();
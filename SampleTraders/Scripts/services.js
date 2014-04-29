var sampleTradersServices = angular.module('sampleTradersServices', ['ngResource']);

sampleTradersServices.factory('Product', ['$resource',
    function ($resource) {
        return $resource('products/:id', null, {
            query: { method: 'GET', isArray: false },
            update: { method: 'PUT' }
        });
}]);
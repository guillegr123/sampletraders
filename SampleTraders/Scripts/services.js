var sampleTradersServices = angular.module('sampleTradersServices', ['ngResource']);

sampleTradersServices.factory('Product', ['$resource',
    function ($resource) {
        return $resource('products/:guid', null, {
            query: { method: 'GET', isArray: false },
            update: { method: 'PUT' }
        });
}]);
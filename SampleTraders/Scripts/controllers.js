var sampleTradersApp = angular.module('SampleTradersApp', []);

sampleTradersApp.controller('ProductListCtrl', function ($scope, $http) {
    $http.get('/products').success(function (data) {
        $scope.products = data.products;
    });
    $scope.editProduct = function (product) {
        $scope.vendors = ['Vendor1', 'Vendor2'];

        if (product === 'new') {
            $scope.newProduct = true;
            $scope.product = { name: '', vendor: '', qty: 0 };
        }
        else {
            $scope.newProduct = false;
            $scope.product = product;
        }
    };
});
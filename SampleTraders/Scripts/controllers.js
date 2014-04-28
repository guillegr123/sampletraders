var sampleTradersControllers = angular.module('sampleTradersControllers', []);

sampleTradersControllers.controller('ProductListCtrl', ['$scope', 'Product', function ($scope, Product) {
    $scope.products = Product.query();
    $scope.save = function (product) {
        if (product.id == null) {
            Product.save(product);
            $scope.products.push(product);
        } else {
            Product.update({id:product.id}, product);
        }
    };
    $scope.delete = function (product) {
        $scope.products.forEach(function (e, index) {
            if (e.id == product.id) {
                product.$delete({ id: product.id }, function () {
                    $scope.products.splice(index, 1);
                });
            }
        });
    };
    $scope.editProduct = function (product) {
        $scope.vendors = ['Vendor1', 'Vendor2'];

        if (product === 'new') {
            $scope.newProduct = true;
            $scope.product = { id:null, name: '', vendor: '', qty: 0 };
        }
        else {
            $scope.newProduct = false;
            $scope.product = product;
        }
    };
}]);
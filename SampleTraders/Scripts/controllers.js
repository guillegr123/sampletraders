var sampleTradersControllers = angular.module('sampleTradersControllers', []);

sampleTradersControllers.controller('ProductListCtrl', ['$scope', 'Product', function ($scope, Product) {
    Product.query(function (res) {
        $scope.products = res.products;
        }, function (error) {
            // Error handler code
        });
    $scope.save = function (product) {
        if (product.id == null) {
            Product.save(product, function (res) {
                $scope.products.push(res.product);
            }, function (error) {
            });
        } else {
            Product.update({ id: product.id }, product, function (res) {
                console.log(res);
            }, function (error) {
            });
        }
    };
    $scope.delete = function (product) {
        if (!window.confirm('Are you sure to delete the product "' + product.name + '"?')) return;
        $scope.products.forEach(function (e, index) {
            if (e.id == product.id) {
                Product.delete({ id: product.id }, function () {
                    $scope.products.splice(index, 1);
                });
            }
        });
    };
    $scope.edit = function (product) {
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
    $scope.upQty = function (product) {
        if (product.qty > 100000) return;
        product.qty = product.qty + 1
    };
    $scope.downQty = function (product) {
        if (product.qty <= 0) return;
        product.qty = product.qty - 1
    };
}]);
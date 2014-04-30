﻿var sampleTradersControllers = angular.module('sampleTradersControllers', []);

sampleTradersControllers.controller('ProductListCtrl', ['$scope', 'Product', function ($scope, Product) {
    Product.query(function (res) {
        $scope.products = res.products;
        }, function (error) {
            // Error handler code
        });
    $scope.save = function (product) {
        console.log(product);
        if (product.guid == null) {
            Product.save(product, function (res) {
                $scope.products.push(res.product);
            }, function (error) {
            });
        } else {
            Product.update({ guid: product.guid }, product, function (res) {
                console.log(res);
                $scope.originalProduct.guid = res.guid;
                $scope.originalProduct.name = res.name;
                $scope.originalProduct.vendor = res.vendor;
                $scope.originalProduct.qty = res.qty;
            }, function (error) {
            });
        }
    };
    $scope.delete = function (product) {
        if (!window.confirm('Are you sure to delete the product "' + product.name + '"?')) return;
        $scope.products.forEach(function (e, index) {
            if (e.guid == product.guid) {
                Product.delete({ guid: product.guid }, function () {
                    $scope.products.splice(index, 1);
                });
            }
        });
    };
    $scope.edit = function (product) {
        $scope.product_form.$setPristine();
        $scope.vendors = ['Vendor1', 'Vendor2'];
        if (product === 'new') {
            $scope.newProduct = true;
            $scope.product = { guid: null, name: '', vendor: '', qty: 0 };
            $scope.originalProduct = $scope.product;
        }
        else {
            $scope.newProduct = false;
            $scope.product = { guid: product.guid, name: product.name, vendor: product.vendor, qty: product.qty };
            $scope.originalProduct = product;
        }
    };
    $scope.isUnchanged = function (product) {
        return angular.equals(product, $scope.originalProduct);
    };
    $scope.upQty = function (product) {
        if (product.qty > 100000) return;
        product.qty = product.qty + 1
        $scope.product_form.product_qty.$setViewValue($scope.product_form.product_qty.$viewValue);  //Setting field as dirty
    };
    $scope.downQty = function (product) {
        if (product.qty <= 0) return;
        product.qty = product.qty - 1
        $scope.product_form.product_qty.$setViewValue($scope.product_form.product_qty.$viewValue);  //Setting field as dirty
    };
}]);
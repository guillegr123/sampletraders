var sampleTradersApp = angular.module('sampleTradersApp', [
    'sampleTradersControllers',
    'sampleTradersServices'
]);

// Number-only directive: http://stackoverflow.com/a/19063323/806975
sampleTradersApp.directive('validNumber', function() {
    return {
        require: '?ngModel',
        link: function(scope, element, attrs, ngModelCtrl) {
            if(!ngModelCtrl) {
                return; 
            }

            ngModelCtrl.$parsers.push(function (val) {
                var clean;
                if (val) {
                    clean = val.replace(/[^0-9]+/g, '');
                } else {
                    clean = '0';
                }
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });

            element.bind('keypress', function(event) {
                if(event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});

var myApp = angular.module('myApp', []);

myApp.controller('MyCtrl', ['$scope', MyCtrl]);

function MyCtrl($scope) {
    $scope.visible = true;

    $scope.toggle = function () {
        $scope.visible = !$scope.visible;
    };
    
    $scope.name = "Sashihara Rino";
}

var myApp = angular.module('myApp', []);

myApp.controller('MyCtrl', ['$scope', MyCtrl]);

function MyCtrl($scope) {
    $scope.visible = true;

    $scope.toggle = function () {
        $scope.visible = !$scope.visible;
    };

    $scope.value = 0;

    $scope.getIncrementedValue = function() {
        $scope.value++;
    };

    $scope.name = "Sashihara Rino";

    $scope.akbmember = "";

    $scope.$watch("akbmember", function (newValue, oldValue) {
        if ($scope.name.length > 0) {
            $scope.greeting = "Greetings " + newValue;
        }
    });
    
}

myApp.controller('PostingController', function ($scope, $http) {
    $scope.posting = "";

    $http.post("/home/GetId", data).error(function(responseData) {
        console.log("Error !" + responseData);
    });
});

myApp.controller('ColorController', function ($scope,$http) {
    $http({
        url: '/home/DataColor',
        method: 'GET'
    }).success(function (data, status, headers, config) {
        $scope.color = data;
    });
});

myApp.controller('PersonController', function ($scope, $http) {
    $http({
        url: '/home/PersonJson',
        method: 'GET'
    }).success(function (data, status, headers, config) {
        $scope.person = data;
    });
});

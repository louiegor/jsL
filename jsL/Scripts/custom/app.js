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


//angular.module('myApp', [])
//.controller('myCtrl', function ($scope, $http) {
//    $scope.hello = { name: "Boaz" };
//    $scope.newName = "";
//    $scope.sendPost = function () {
//        var data = $.param({
//            json: JSON.stringify({
//                name: $scope.newName
//            })
//        });
//        $http.post("/echo/json/", data).success(function (data, status) {
//            $scope.hello = data;
//        })
//    }
//})

myApp.controller('PostingController', function($scope, $http) {
    $scope.hello = { name: "Boaz" };
    $scope.newName = "";
    $scope.sendPost = function() {
        var data = $.param({
            json: JSON.stringify({
                name: $scope.newName
            }),
            //headers: { 'Content-Type': 'application/json' }
        });
            
        $http.post("/home/GetId", {
            newName : $scope.newName
        }).success(function (data, status) {
            $scope.hello.name = data.NewName;
        });
    };
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

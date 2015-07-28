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

myApp.controller('PersonPostController', function ($scope, $http) {
    $scope.person = { name: "" , organization: ""};
    $scope.newName = "";
    $scope.newOrg = "";
    $scope.sendPost = function () {
        $http.post("/home/PostPerson",  $scope.person
            
        ).success(function (data, status) {
            $scope.person.name = data.Name;
            $scope.person.organization = data.Organization;
        });
    };
});

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


myApp.controller('UploadController', function ($scope, fileReader) {
    console.log(fileReader),
    $scope.getFile = function () {
        $scope.progress = 0;
        fileReader.readAsDataUrl($scope.file, $scope)
                      .then(function (result) {
                          $scope.imageSrc = result;
                      });
    };

    $scope.$on("fileProgress", function (e, progress) {
        $scope.progress = progress.loaded / progress.total;
    });

    $scope.uploadFile = function () {
        var file = $scope.myFile;
        console.log('file is ');
        console.dir(file);
        var uploadUrl = "/home/PostFile";
        fileUpload.uploadFileToUrl(file, uploadUrl);
    };

});

myApp.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function(file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
            .success(function() {
            })
            .error(function() {
            });
    };
}]);

myApp.directive("ngFileSelect", function() {

    return {
        link: function($scope, el) {

            el.bind("change", function(e) {

                $scope.file = (e.srcElement || e.target).files[0];
                $scope.getFile();
            });

        }
    };
});

myApp.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);
var myApp = angular.module('myApp', ['ngTable']);

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

//cmApp
//  .controller('AddCtrl', ['$scope', 'sharedService', '$http', function($scope, sharedService, $http) {

//myApp.controller('CharaController', ['$scope','sharedService','$http', function($scope, sharedService, $http) {

myApp.controller('TableCtrl', function ($scope, ngTableParams) {
    $scope.data = [
     { name: "Moroni", age: 50 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 }
    ];

    $scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10           // count per page
    }, {
        total: data.length, // length of data
        getData: function ($defer, params) {
            $defer.resolve(data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
        }
    });
});

myApp.controller('OrganizationCtrl', function($scope, $http) {
    $scope.orgName = "";
    $scope.listAllOrg = [];
    $scope.list_category="";
    var path = "/home/GetAllOrg";
    $http.get(path).then(function (response) {
        $scope.listAllOrg = response;
    }, function(response) {
    });

    $scope.orgId = "";
    $scope.charaName = "";
    $scope.addChara = function () {
        $http.post("/home/AddCharacter", { orgId: $scope.orgId, charaName: $scope.charaName }).then(function (response) {

        }, function (response) { });
    };

    $scope.addOrg = function() {
        $http.post("/home/AddOrganization", {orgName : $scope.orgName }).then(function(response) {

        }, function (response){});
    };
});


myApp.controller('CharaController', function($scope, $http) {
    $scope.listChara = [];
    $scope.orgName = "StrawHatPirate";
   
    var path = "/character/GetByOrg";
    $http.post(path, { name: $scope.orgName }).success(function (data, status) {
        $scope.listChara = data;
    });
    
});

myApp.controller('PersonPostController', function ($scope, $http) {
    $scope.person;
    $scope.newName = "";
    $scope.newOrg = "";
    $scope.sendPost = function () {
        $http.post("/home/PostPerson",  $scope.person
            
        ).success(function (data, status) {
           
        });
    };
    

});

myApp.controller('PostingController', function($scope, $http) {
    $scope.hello = { name: "Boaz" };
    $scope.newName = "";
    $scope.sendPost = function() {
        //var data = $.param({
        //    json: JSON.stringify({
        //        name: $scope.newName
        //    }),
        //    //headers: { 'Content-Type': 'application/json' }
        //});
            
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

myApp.controller('CharacterController', function ($scope, $http) {
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
var urlKatanaControllers = angular.module('urlKatanaControllers', []);

urlKatanaControllers.controller('NewUrlInputCtrl', ['$scope', '$http', '$location',
    function ($scope, $http, $location) {
        $scope.save = function () {
            var data = $scope.url;
            $http.post(
                '/api/url',
                JSON.stringify(data),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).success(function (data) {
                $location.path('/short/' + data.ShortUrl);
            });
        };
    }
]);

urlKatanaControllers.controller('ShortUrlCtrl', ['$scope', '$http', "$routeParams",
    function ($scope, $http, $routeParams) {
        var shortUrl = $routeParams.shortUrl;
        $http.get('/api/url/' + shortUrl)
            .success(function (data) {
                $scope.url = data;
            });        
        }
]);

urlKatanaControllers.controller('ShortUrlCtrl', ['$scope', '$http', "$routeParams", "$location",
    function ($scope, $http, $routeParams, $location) {
        var baseLen = $location.absUrl().length - $location.url().length;
        $scope.BaseUrl = $location.absUrl().substring(0, baseLen);
        var shortUrl = $routeParams.shortUrl;
        $http.get('/api/url/' + shortUrl)
            .success(function (data) {
                $scope.url = data;
            });
    }
]);

urlKatanaControllers.controller('RedirectCtrl', ['$scope', '$http', "$location",
    function ($scope, $http, $location) {
        var value = $location.path().substring(1);
        $http.get('/api/url/' + value)
            .success(function (data) {
                window.location = data.LongUrl;
            }).error(function (data){
                $location.path('/');
            });
    }
]);
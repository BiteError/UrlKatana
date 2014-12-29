var urlKatanaApp = angular.module('UrlKatanaApp', ['ngRoute', 'urlKatanaControllers']);

urlKatanaApp.config(['$routeProvider',
  function ($routeProvider) {

      $routeProvider.
          when('/new', {
              templateUrl: '/WebApp/NewUrlInput.html',
              controller: 'NewUrlInputCtrl'
          }).
          when('/short/:shortUrl', {
              templateUrl: '/WebApp/ShortUrl.html',
              controller: 'ShortUrlCtrl'
          }).
          when('/', {
              redirectTo: '/new'
          }).
          otherwise({
              templateUrl: '/WebApp/Redirect.html',
              controller: 'RedirectCtrl'
          });
  }]);
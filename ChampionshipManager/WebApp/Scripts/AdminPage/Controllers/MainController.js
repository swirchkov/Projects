var adminApp = angular.module('adminApp');

adminApp.controller('main', function ($scope, $route) {
    setTimeout(function () {
        if ($route.current.$$route.originalPath == '/users') {
            $scope.mode = "Users";
        }
        else {
            $scope.mode = 'Tournaments';
        }
    }, 1);
});
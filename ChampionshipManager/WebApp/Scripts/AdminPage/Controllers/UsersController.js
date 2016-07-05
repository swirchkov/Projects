var adminApp = angular.module('adminApp');

adminApp.controller('UsersController', function ($scope, selectService) {

    $.get("/Admin/GetFirstUsers", "", function success(response) {
        $scope.Users = response;

        setTimeout(function () {
            $scope.$apply();
        }, 1);
    });

    $scope.searchByPattern = function () {

        window.event.preventDefault();

        $.get('/Admin/FilterByPattern?query=' + $scope.Query, "", function (response) {
            $scope.Users = response;

            setTimeout(function () {
                $scope.$apply();
            }, 1);
        });
    }

    $scope.editUser = function (user) {
        selectService.setUser(user);
    }
});
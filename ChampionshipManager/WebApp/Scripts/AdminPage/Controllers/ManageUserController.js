var adminApp = angular.module('adminApp');

adminApp.controller('ManageUserController', function ($scope, selectService) {

    $scope.User = selectService.getUser();
    $scope.User.FullName = $scope.User.Name + " " + $scope.User.Patronymic + " " + $scope.User.Surname;

    $scope.deleteAvatar = function () {

        window.event.preventDefault();

        if ($scope.User.IsDefaultPhoto) {
            return;
        }

        $.post('/Admin/DeletePhoto', { userId: $scope.User.Id }, function (data) {
            $scope.User.Photo = data;
        });
    }

    $scope.editUser = function () {
        var form = document.getElementById('userEditForm');

        if (!form.checkValidity()) {
            return;
        }

        window.event.preventDefault();

        var splitName = $scope.User.FullName.split(' ');

        $.post('/Admin/EditProfile', {
            Id: $scope.User.Id, Name: splitName[0], Patronymic: splitName[1], Surname: splitName[2], Email: $scope.User.Email,
            PhoneNumber: $scope.User.PhoneNumber
        }, function success(data) {
            if (data.Message != undefined) {
                $scope.hasMessage = true;
                $scope.IsSuccessMessage = false;
                $scope.Message = data.Message;
            }

            $scope.hasMessage = true;
            $scope.IsSuccessMessage = true;
            $scope.Message = data;

            setTimeout(function () {
                $scope.$apply();
            }, 1);
        })
    }
});
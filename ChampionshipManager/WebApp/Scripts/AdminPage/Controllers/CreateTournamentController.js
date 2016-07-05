var adminApp = angular.module('adminApp');

adminApp.controller('CreateTournamentController', function ($scope, $http, TournamentFormSender) {
    $scope.createTournament = function () {
        var form = document.getElementById("createForm");

        if (!form.checkValidity()) {
            return true;
        }

        TournamentFormSender.uploadForm();
    }
});
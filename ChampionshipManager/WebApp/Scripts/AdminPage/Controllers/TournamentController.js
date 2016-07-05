var adminApp = angular.module('adminApp');

adminApp.controller("TournamentController", function ($scope, TournamentFilterService, selectService) {

    $.getJSON("/Admin/FirstTournaments").then(function success(data) {
        $scope.Tournaments = data;
        $scope.$apply();
    },
    function fail(response) {
        console.error(response);
    });

    $scope.searchTournaments = function () {
        window.event.preventDefault();

        TournamentFilterService.filterTournaments($scope.SearchPattern).then(
            function success(response) {
                $scope.Tournaments = response.data;
            }, 
            function fail(response) {
                console.error('failed request');
                console.error(response);
            });

        return false;
    }

    $scope.selectTournament = function (tour) {
        selectService.selectTournament(tour);
        console.log('selecting tournament');
        console.log(tour);
    }

});
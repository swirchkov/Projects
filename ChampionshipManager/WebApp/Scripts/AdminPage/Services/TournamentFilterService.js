var adminApp = angular.module('adminApp');

adminApp.service('TournamentFilterService', function ($http) {
    this.filterTournaments = function (pattern) {
        return $http.get('/Admin/SearchTournamentJson?query=' + pattern);
    }
});
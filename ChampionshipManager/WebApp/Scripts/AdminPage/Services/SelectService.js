var adminApp = angular.module('adminApp');

adminApp.service('selectService', function () {
    var values = {};

    this.selectTournament = function (tour) {
        values.Tournament = tour;
    }

    this.getTournament = function () {
        return values.Tournament;
    }

    this.setUser = function (user) {
        values.User = user;
    }

    this.getUser = function () {
        return values.User;
    }

});
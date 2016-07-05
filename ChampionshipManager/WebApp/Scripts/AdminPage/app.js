var adminApp = angular.module('adminApp', ['ngRoute']).config(
    function ($routeProvider) {

        $routeProvider.when("/tournaments", {
            templateUrl: "/Scripts/AdminPage/Views/Tournament.html",
            controller: "TournamentController"
        });

        $routeProvider.when('/createTournament', {
            templateUrl: "/Scripts/AdminPage/Views/CreateTournament.html",
            controller: "CreateTournamentController"
        });

        $routeProvider.when('/manageTournament', {
            templateUrl: "/Scripts/AdminPage/Views/ManageTournament.html",
            controller: "ManageTournamentController"
        });

        $routeProvider.when('/gamesManagement', {
            templateUrl: "/Scripts/AdminPage/Views/Games.html",
            controller: "GamesController"
        });

        $routeProvider.when('/users', {
            templateUrl: "/Scripts/AdminPage/Views/Users.html",
            controller: "UsersController"
        });

        $routeProvider.when('/userManagement', {
            templateUrl: "/Scripts/AdminPage/Views/ManageUser.html",
            controller: "ManageUserController"
        });

        $routeProvider.otherwise({ redirectTo: "/tournaments" });
    });


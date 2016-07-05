var adminApp = angular.module('adminApp');

adminApp.controller('ManageTournamentController', function ($scope, $http, selectService) {
    $scope.Tournament = selectService.getTournament();

    $.get('/Admin/GetTournamentUsers?id=' + $scope.Tournament.Id).then(
        function success(response) {
            console.log(response);
            $scope.Participates = response.Participates;
            $scope.Requests = response.Requests;
            $scope.$apply();
        },
        function fail(response) {
            console.log('failed request');
            console.log(response);
        });

    $scope.declineParticipateRequest = function (user) {

        window.event.preventDefault();

        $.post('/Admin/DeclineRequest', { userId: user.Id, tournamentId: $scope.Tournament.Id },
            function success() {
                var requests = [];

                for (var i = 0; i < $scope.Requests.length; i++) {
                    if ($scope.Requests[i].Id != user.Id) {
                        requests.push($scope.Requests[i]);
                    }
                }

                $scope.Requests = requests;

                setTimeout(function () {
                    $scope.$apply();
                }, 1);
            });
    };

    $scope.acceptParticipateRequest = function (user) {

        window.event.preventDefault();

        $http.post('/Admin/AcceptRequest', { userId: user.Id, tournamentId: $scope.Tournament.Id })
            .success(function() {
                var requests = [];

                for (var i = 0; i < $scope.Requests.length; i++) {
                    if ($scope.Requests[i].Id != user.Id) {
                        requests.push($scope.Requests[i]);
                    }
                }

                $scope.Requests = requests;

                $scope.Participates.push(user);

                setTimeout(function () {
                    $scope.$apply();
                }, 1);

            });

        return false;
    };

    $scope.removeFromTournament = function (user) {

        window.event.preventDefault();

        $.post('/Admin/RemoveFromTournament', { userId: user.Id, tournamentId: $scope.Tournament.Id },
            function success() {
                var participates = [];

                for (var i = 0; i < $scope.Participates.length; i++) {
                    if ($scope.Participates[i].Id != user.Id) {
                        participates.push($scope.Participates[i]);
                    }
                }

                $scope.Participates = participates;
                $scope.$apply();
            });

        return false;
    };

    $scope.startTournament = function () {

        window.event.preventDefault();

        $.post('/Admin/StartTournament', { Id: $scope.Tournament.Id }, function success(response) {
            console.log(response);
            $scope.Tournament.IsStarted = true;
        })
    }
});
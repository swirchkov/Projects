var adminApp = angular.module('adminApp');

adminApp.controller('GamesController', function ($scope, selectService) {
    $scope.Tournament = selectService.getTournament();

    $scope.User1 = {};
    $scope.User2 = {};
    $scope.hasError = false;
    $scope.editGame = null;
    $scope.Date = null;
    $scope.Time = null;

    $.get("/Admin/GetTournamentGames?id=" + $scope.Tournament.Id).then(
        function sucess(response) {
            console.log(response);
            $scope.Games = response;

            setTimeout(function () {
                $scope.$apply();
            }, 1);
        },
        function fail(error) {
            console.error(error);
        });

    $.get('/Admin/GetTournamentParticipates?id=' + $scope.Tournament.Id).then(
        function success(response) {
            $scope.Users = response;

            $scope.Users1 = [];
            $scope.Users2 = [];

            for (var i = 0; i < response.length; i++) {
                $scope.Users1.push(response[i]);
                $scope.Users2.push(response[i]);
            }
        },
        function fail(response) {
            console.error(response);
        });

    $scope.filterCollection = function (Users, user) {
        var users = [];

        for (var i = 0; i < Users.length; i++) {
            if (Users[i].Name != user.Name) {
                users.push(Users[i]);
            }
        }

        console.log(users);
        return users;
    }

    $scope.createGame = function () {

        window.event.preventDefault();

        if (!document.getElementById('gameCreateForm').checkValidity()) {
            $("#submitForm").click();
            return;
        }

        var user1 = null;
        var user2 = null;

        for (var i = 0; i < $scope.Users.length; i++) {
            if ($scope.Users[i].Name == $scope.User1.Name) {
                user1 = $scope.Users[i];
            }
            else if ($scope.Users[i].Name == $scope.User2.Name) {
                user2 = $scope.Users[i];
            }
        }

        if (user1 == null || user2 == null) {
            $scope.ErrorMessage = 'Enter correct user name(s)';
            $scope.hasError = true;
            return;
        }

        var date = new Date($scope.Date);
        var time = new Date($scope.Time);
       
        if ($scope.editedGame == null) {
            $.post('/Admin/CreateGame', {
                User1Id: user1.Id, User2Id: user2.Id, FirstScore: $scope.FirstScore, SecondScore: $scope.SecondScore,
                Year: date.getFullYear(), Month: date.getMonth(), Day: date.getDate(),
                Hour: time.getHours(), Minute: time.getMinutes(), TournamentId: $scope.Tournament.Id
            }, function success(response) {
                if (response.Message != undefined) {
                    $scope.ErrorMessage = response.Message;
                    $scope.hasError = true;
                }
                else {
                    $scope.hasError = false;
                }

                $scope.Games.push(response);

                setTimeout(function () {
                    $scope.$apply();
                }, 1);

                if (!$scope.hasError) {
                    $scope.clearFields();
                }
            });
        }
        else {
            $.post("/Admin/EditGame", {
                gameId: $scope.editedGame.Id, User1Id: user1.Id, User2Id: user2.Id, FirstScore: $scope.FirstScore,
                SecondScore: $scope.SecondScore, Year: date.getFullYear(), Month: date.getMonth(), Day: date.getDate(),
                Hour: time.getHours(), Minute: time.getMinutes(), TournamentId: $scope.Tournament.Id
            }, function success(response) {

                if (response.Message != undefined) {
                    $scope.ErrorMessage = response.Message;
                    $scope.hasError = true;
                }
                else {
                    $scope.hasError = false;
                }

                date.setHours(time.getHours());
                date.setMinutes(time.getMinutes());

                var game = {
                    Id: $scope.editedGame.Id, User1: user1, User2: user2,
                    ResultView: " " + $scope.FirstScore + " : " + $scope.SecondScore + " ",
                    StartDate: {
                        Year: date.getFullYear(), Month: date.getMonth(), Day: date.getDate(),
                        Hours: time.getHours(), Minutes: time.getMinutes()
                    }, TournamentId: $scope.Tournament.Id, Start: date.toLocaleString()
                };

                var games = [];

                for (var i = 0; i < $scope.Games.length; i++) {
                    if ($scope.Games[i].Id != game.Id) {
                        games.push($scope.Games[i]);
                    }
                    else {
                        games.push(game);
                    }
                }

                $scope.Games = games;

                setTimeout(function () {
                    $scope.$apply();
                }, 1);

                if (!$scope.hasError) {
                    $scope.clearFields();
                }
            });
        }
    }

    $scope.clearFields = function () {

        $scope.User1 = {};
        $scope.User2 = {};

        $scope.Date = null;
        $scope.Time = null;

        $scope.FirstScore = null;
        $scope.SecondScore = null;

        $scope.editedGame = null;
        $scope.hasError = false;
    }

    $scope.editGame = function (game) {
        $scope.User1 = game.User1;
        $scope.User2 = game.User2;

        var arr = game.ResultView.split(':');

        $scope.FirstScore = +arr[0].trim();
        $scope.SecondScore = +arr[1].trim();

        var rawDate = game.StartDate;
        var date = new Date(rawDate.Year, rawDate.Month, rawDate.Day, rawDate.Hours, rawDate.Minutes);

        $scope.Date = date;
        $scope.Time = date;

        $scope.editedGame = game;
    }

    $scope.editGameFinish = function () {
        window.event.preventDefault();

        if (!document.getElementById('gameCreateForm').checkValidity()) {
            $("#submitForm").click();
        }

        var user1 = null;
        var user2 = null;

        for (var i = 0; i < $scope.Users.length; i++) {
            if ($scope.Users[i].Name == $scope.User1.Name) {
                user1 = $scope.Users[i];
            }
            else if ($scope.Users[i].Name == $scope.User2.Name) {
                user2 = $scope.Users[i];
            }
        }
    }

    $scope.deleteGame = function (game) {
        $.post('/Admin/DeleteGame', { gameId: game.Id }, function success(response) {

            if (response.Message != undefined) {
                $scope.ErrorMessage = response.Message;
                $scope.hasError = true;
            }
            else {
                $scope.hasError = false;
            }

            var games = [];

            for (var i = 0; i < $scope.Games.length; i++) {
                if ($scope.Games[i].Id != game.Id) {
                    games.push($scope.Games[i]);
                }
            }

            $scope.Games = games;

            setTimeout(function () {
                $scope.$apply();
            }, 1);
        })
    }
});
var adminApp = angular.module("adminApp");

adminApp.service('TournamentFormSender', function ($http) {
    this.uploadForm = function () {
        var fd = new FormData();

        fd.append('Logo', document.getElementsByName("Logo").item(0).files[0]);
        fd.append('Name', document.getElementsByName('Name').item(0).value);
        fd.append('SportKind', document.getElementsByName('SportKind').item(0).value);
        fd.append('ParticipateNumber', document.getElementsByName('ParticipateNumber').item(0).value);

        console.log(fd);

        $http.post('/Admin/CreateTournament', fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (response) {

            if (response.data == "Success") {
                return;
            }

            // show message
            $("#CreateTournamentValidation").text(response.data.Message);
            $("#CreateTournamentValidation").css({ display: "block" });

        }, function errorCaalback(data) {
            console.log("error with request");
            // show message
            $("#CreateTournamentValidation").text(data.Message);
            $("#CreateTournamentValidation").css({ display: "initial" });
        });

    }
});
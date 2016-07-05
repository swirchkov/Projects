$(document).ready(function () {

    var successCallback = function (data) {
        $('#tournamentContent-' + tourId).html(data);
    };

    var tourId = 0;

    window.loadParticipates = function (tournamentId) {

        window.event.preventDefault();

        tourId = tournamentId;
        $.get('/Tournament/TournamentParticipates?tournamentId=' + tournamentId, null, successCallback);

    };

    window.loadStatistic = function (tournamentId) {

        window.event.preventDefault();

        tourId = tournamentId;
        $.get("/Tournament/TournamentStatistic?tournamentId=" + tournamentId, null, successCallback);

    };

    window.loadGames = function (tournamentId) {

        window.event.preventDefault();

        tourId = tournamentId;
        $.get("/Tournament/TournamentGames?tournamentId=" + tournamentId, null, successCallback);

    };

    window.loadTournaments = function (status) {
        $.get('/Tournament/TournamentsByStatus?status=' + status, null, function (data) {
            $("#pageContent").html(data);
        })
    }

})
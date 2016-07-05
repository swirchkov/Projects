$(document).ready(function () {

    $("#searchTournamentBtn").click(function () {
        var text = $("#searchBox").val();

        if (text == null) {
            return;
        }

        if (text.match('[^ ]').length == 0) {
            return;
        }

        location.replace("/Tournament/Search?query=" + text);
    });

});
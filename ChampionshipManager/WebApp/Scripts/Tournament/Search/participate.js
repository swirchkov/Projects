$(document).ready(function () {
    window.participate = function (id) {
        $.post("/Tournament/ParticipateTournament", { tournamentId: id }, function (data) {
            console.log(data);

            if (data.Message == undefined) {
                $("#participateLink" + id).text("Вы успешно подали заявку");
                $("#participateLink" + id).addClass("text-warning");
            }
            else {
                $("#participateLink" + id).text(data.Message);
                $("#participateLink" + id).addClass("participate-link-danger");
            }
        });
    }
});
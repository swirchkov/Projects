$(document).ready(function () {

    $("#ErrorContainer").hide();

    window.submitLoginForm = function () {

        if (!document.getElementById('LoginForm').checkValidity()) {
            return true;
        }

        window.event.preventDefault();
        
        $.post("/Account/ProfileLogin", { Login: $("#Login").val(), Password: $("#Password").val() }, function (data) {

            if (data.Message != undefined) {

                $("#ErrorContainer").first().children().first().html(data.Message).addClass("text-danger");
                $("#ErrorContainer").show();

                return;
            }

            $("#mainContainer").html(data);
            $("#ErrorProfileContainer").hide();

        });

        return false;
    }

    window.sendRegisterForm = function () {

        if (!document.getElementById("EditForm")) {
            return;
        }

        window.event.preventDefault();

        var fd = new FormData();

        fd.append('Email', $("#Email").val());
        fd.append('FullName', $("#FullName").val());
        fd.append('PhoneNumber', $("#PhoneNumber").val());
        fd.append('Photo', document.getElementById("Photo").files[0]);
        fd.append('Password', $("#Password").val());
        fd.append('ConfirmPassword', $("#ConfirmPassword").val());
        fd.append('Comment', $("#Comment").val());

        $.ajax({
            url: "/Account/ProfileEdit",
            data: fd,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function success(data) {
                var errSurround = $("#ErrorProfileContainer").first().children().first().html(data.Message);

                if (data.Success != undefined) {
                    errSurround.addClass('text-success');
                }
                else {
                    errSurround.addClass('text-danger');
                }

                $("#ErrorProfileContainer").show();
            }
        });
    }

});
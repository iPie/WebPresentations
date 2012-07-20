    // validate signup form on keyup and submit
    $("#signupForm").validate({
        rules: {
            old_password: {
                required: true,
                minlength: 8
            },
            new_password: {
                required: true,
                minlength: 8
            },
            confirm_password: {
                required: true,
                minlength: 8,
                equalTo: "#new_password"
            }
        },
        messages: {
            old_password: "Password format is incorrect",
            new_password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 8 characters long"
            },
            confirm_password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 8 characters long",
                equalTo: "Please enter the same password as above"
            }
        },
        
        // specifying a submitHandler prevents the default submit, good for the demo
        submitHandler: function () {
            ChangePassword();
        }
    });
    function Reset() {
        $.post("/AdministrativeTool/PasswordReset", { "userName": "@User.Identity.Name" },
            function (data) {
                var resultJson = data.message;
                $('#statusMessage').modal('show');
                if (resultJson == "Success") {
                    $("#statusMessageHeader").html('<h3 style="color:green">Success</h3>');
                    $("#statusMessageText").html('<h5>Password reset competed successfully</h5>');
                } else {
                    $("#statusMessageHeader").html('<h3 style="color:red">Error!</h3>');
                    $("#statusMessageText").html('<h5>Password reset failed. Something went wrong..</h5>');
                }
            });
        }
    
        function ChangePassword() {
            $.post("/Account/ChangePassword", {
                currentPassword: $("#old_password").val(),
                newPassword: $("#new_password").val(),
                confirmPassword: $("#confirm_password").val()
                },
                function(data) {
                    var resultJson = data;
                    $('#statusMessage').modal('show');
                    if (resultJson == "Success") {
                        $("#statusMessageHeader").html('<h3 style="color:green">Success</h3>');
                        $("#statusMessageText").html('<h5>Your password has been successfully changed</h5>');
                    } else {
                        $("#statusMessageHeader").html('<h3 style="color:red">Error!</h3>');
                        $("#statusMessageText").html('<h5>Specified password is incorrect and/or passwords do not match.</h5>');
                    }
                });
        }

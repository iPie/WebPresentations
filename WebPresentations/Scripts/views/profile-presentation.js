    var id;
    
    function handleUpdate(_id) {
        $('#row-' + _id).fadeOut('slow');
    }
    function Delete(_id) {
        $('#YesNoModal').modal('show');
        id = _id;
    };
        
    function DeletePost() {
        $.post("/Editor/Delete", { "id": id },
            function (data) {
                var resultJson = data.message;
                $('#YesNoModal').modal('hide');
                if (resultJson == "Success") {                    
                    handleUpdate(id);
                } else {
                    $('#statusMessage').modal('show');
                    $("#statusMessageHeader").html('<h3 style="color:red">Error!</h3>');
                    $("#statusMessageText").html('<h5>Could not delete presentation. Something went wrong..</h5>');
                }
            });
    };
    function LikeIt(pId, count) {
        $.post("/Profile/AddLike", { id: pId },
            function (data) {
                var resultJson = data;
                if (resultJson == "Success") {
                    $('#qbutton-' + pId).fadeOut('slow');
                    $('#qtext-' + pId).fadeOut('slow');
                    $('#qbutton-' + pId).addClass('btn btn-success btn-small disabled');
                    $('#qtext-' + pId).html(count + 1 + " Liked");
                    $('#qbutton-' + pId).fadeIn('slow');
                    $('#qtext-' + pId).fadeIn('slow');
                }
            });
    };
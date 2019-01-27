$(document).ready(function () {
    getData();

    $(".post-form > button").click(function(){
        var message = $(".post-form > textarea").val();
        var postObject = {
            Text: message,
            Visible: true
        };
        $.ajax({
            type: "POST",
            url: "/api/post",
            contentType: "application/json",
            data: JSON.stringify(postObject),
            success: function (result) {
                getData();
            }

        });

    });

});

function getData() {
    $.ajax({
        type: "GET",
        url: "api/post/getposts",
        success: function (data) {
            tableBody = $("#posts");
            $(tableBody).empty();
            $.each(data, function (key, item) {
                tableBody.append('<div class="col-md-3"><div class="card"><h4 class="text-center"></h4 ><p class="text-center">' + item.text + '</p></div></div>');
            });
            
        }

    });

}
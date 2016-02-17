(function () {
    $("span[data-value='1']").click(function () {
        var id = $(this).attr("data-id");
        makeRating(id, 1);
    })

    $("span[data-value='2']").click(function () {
        var id = $(this).attr("data-id");
        makeRating(id, 2);
    })

    $("span[data-value='3']").click(function () {
        var id = $(this).attr("data-id");
        makeRating(id, 3);
    })

    $("span[data-value='4']").click(function () {
        var id = $(this).attr("data-id");
        makeRating(id, 4);
    })

    $("span[data-value='5']").click(function () {
        var id = $(this).attr("data-id");
        makeRating(id, 5);
    })

    function makeRating(itemId, ratingValue) {
        $.post("/Ratings/Rate", { itemId: itemId, ratingValue: ratingValue },
            function (data) {
                var newRating = data.Rating;

                var a = $("span[data-value='ratingValue'][data-id='" + itemId + "']").html(newRating);
            });
    }
}());

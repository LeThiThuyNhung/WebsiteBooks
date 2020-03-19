$(document).ready(function () {
    $('.btn-default').click(function () {
        var id = $(this).data("id");
        $.ajax({
            type: "POST",
            url: '/Cart/Buy',
            data: { Id: id },
            success: function (data) {
                alert("Add to cart successfully")
            }
        });
    });
});
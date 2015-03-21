$(document).ready(function() {
    $(".postupvote").click(function () {
        var mId = $(this).attr("data-postid");
        $.post("/Home/VoteUp", { messageId: mId, },
           function (data) {
               $("#postvotescount_"+mId).html(data);
           });
    });
    $(".postdownvote").click(function () {
        var mId = $(this).attr("data-postid");
        $.post("/Home/VoteDown", { messageId: mId, },
           function (data) {
               $("#postvotescount_"+mId).html(data);
           });
    });
});
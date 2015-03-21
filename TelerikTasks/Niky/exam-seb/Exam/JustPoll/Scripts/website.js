$(document).ready(function () {
    setInterval(function () {
        var id = $(".voteAgaingWarning").attr("id");
        $("#"+id).load("/Vote/GetTimeLeftToVote/" + id);
    }, 700);
});
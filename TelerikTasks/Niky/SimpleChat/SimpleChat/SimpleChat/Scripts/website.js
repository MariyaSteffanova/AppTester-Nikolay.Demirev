$(document).ready(function (e) {
    $(".roomFromList").click(function () {
        var id = $(this).attr("id");
        var url = "http://" + location.host + "/ChatRooms/AddChatWindow?chatRoomId=" + id;
        $(window).attr("location", url);
    });
});
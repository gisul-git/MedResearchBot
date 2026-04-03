$(document).ready(function () {
    var furl = $(".lblguid").html();
    BindForumsDetailsNew(furl);
    $(document.body).on("click", "#btnCmt", function (e) {
        e.preventDefault();

        var message = $("#txtComment").val();
        var guid = $(".lblguid").html();

        message = encodeURIComponent(message);
        $(".spncmt").html("");
        var count = 1;

        if (message === "") {
            count = 0;
            $(".spncmt").html("Enter Your Comments");
        }

        if (count === 1) {
            $.ajax({
                type: 'POST',
                url: "/forum-details.aspx/Commentsdetails",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: JSON.stringify({ message: message, guid: guid }),
                success: function (data2) {
                    if (data2.d === "Success") {
                        Snackbar.show({ pos: 'top-right', text: 'Thank you for commenting.', actionTextColor: '#fff', backgroundColor: '#008A3D' });
                        $("#txtComment").val("");
                        BindForumsDetailsNew(furl);
                    } else {
                        Snackbar.show({ pos: 'top-right', text: 'Oops...! Please try again later.', actionTextColor: '#fff', backgroundColor: '#EA1C1C' });
                    }
                }
            });
        }
    });

    $(document.body).on("click", "#btnClear", function (e) {
        e.preventDefault();
        $("#txtComment").val("");
    });

    $(document.body).on("click", ".like", function (e) {

        e.preventDefault();
        $this = $(this);
        var MessageGuid = $(".lblguid").html();
        var IsExist = $this.find("i").hasClass("text-warning");
        var url = "";
        if (IsExist) {
            url = "/forum-details.aspx/RemoveLike";
        }
        else {
            url = "/forum-details.aspx/AddLike";
        }
        $.ajax({
            type: "POST",
            url: url,
            async: false,
            data: "{mesGuid :' " + MessageGuid + "'}",
            contentType: 'application/json; charset=utf-8',
            success: function (res) {

                if (res.d.toString() == "Success") {
                    if (IsExist) {
                        $this.find("cls").removeClass("text-warning");
                        $(".cls").removeClass("text-warning");
                        Snackbar.show({ text: 'Like Removed Successfully.', pos: 'top-right', textColor: '#fff', actionTextColor: '##fff', backgroundColor: '#008A3D' });
                       
                    } else {
                        $this.find("cls").addClass("text-warning");
                        $(".cls").addClass("text-warning");
                        Snackbar.show({ text: 'Like Added Successfully.', pos: 'top-right', textColor: '#fff', actionTextColor: '#fff', backgroundColor: '#008A3D' });
                    }
                }
                else {
                    Snackbar.show({ text: 'There is some problem right now ,please try again after some time.', pos: 'top-right', textColor: '#000000', actionTextColor: '#008A3D', backgroundColor: '#FEEB9D' });
                }
            }
        });
    });
});
function BindForumsDetailsNew(furl) {
    $.ajax({
        type: 'POST',
        url: "/forum-details.aspx/BindForumsDetailsNew",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: JSON.stringify({ furl: furl }),
        success: function (response) {
            if (response.d !== "Error") {
                var data = jQuery.parseJSON(response.d);

                let commentsHtml = '';
                data.Cmnt.forEach(function (comment) {
                    var decodedMessage = decodeURIComponent(comment.Message);
                    var addedOnDate = new Date(comment.AddedOn);
                    var options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', hour12: true };
                    var formattedDate = addedOnDate.toLocaleDateString('en-US', options).replace(',', '');
                    commentsHtml += `
                        <div class="forum-comment strComments">
                            <div class="forum-post-top">
                                <a class="author-avatar" href="javascript:void(0)">
                                    <img src="/images/user.png" height="48" width="48" alt="author avatar">
                                </a>
                                <div class="forum-post-author">
                                    <a class="author-name" href="#">${comment.AddedBy}</a>
                                    <div class="forum-author-meta">
                                        <div class="author-badge">
                                            <i class="fa-solid fa-calendar-days"></i>
                                           <a href="javascript:void(0);">${formattedDate}</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="comment-content">
                               <p>${decodedMessage}</p> 
                            </div>
                        </div>
                    `;
                });

                // Bind the generated HTML to the .strComments container
                $(".strComments").html(commentsHtml);
                
                $(".cls").addClass(data.LikeCls);
                $(".strDescription").html(data.Desc);
                $(".strTitle").html(data.Title);
                $(".strLastseen").html(data.LastUpdate);
                $(".strTopics").html(data.Topics);
                $(".CommentCount").html(data.CommentCount);
                //$(".profileImg").attr("src", data.ProfileImage)

                if (data.ProfileImage === "") {
                    $(".profileImg").attr("src", "/images/user.png");

                }
                else {
                    $(".profileImg").attr("src", "/" + data.ProfileImage);

                }
                $(".username").html(data.FullName);
            }

        },
        error: function (xhr, status, error) {
        }
    });
}


$(document).ready(function () {
    BindForumsPost();
    $(document.body).on('change', ".pageLenght", function () {
        $(".mppagination").empty();
        //$('.loaderclass').removeClass("d-none");
        //$('.mytablewrap').addClass("d-none");
        BindForumsPost();
    });
    $(document.body).on("keyup", ".txtsearch", function (e) {
        $(".mppagination").empty();
        //$('.loaderclass').removeClass("d-none");
        //$('.mytablewrap').addClass("d-none");
        BindForumsPost();
    })

    //Rejected
    $(document.body).on("click", ".btnreject", function (e) {
        e.preventDefault();
        var id = $(this).attr("data-id");

        $.ajax({
            type: 'POST',
            url: "manage-forum-post.aspx/RejectForums",
            data: "{id: '" + id + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                if (data2.d.toString() == "Success") {
                    Snackbar.show({ pos: 'top-right', text: 'Forum Rejected!', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    setTimeout(function () { window.location.href = "manage-forum-post.aspx"; }, 1000);

                }
                else {
                    Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                }
            },
            error: function (err) {
                Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
            }
        });
    });


    //accepted
    $(document.body).on("click", ".btnAccept", function (e) {

        e.preventDefault();
        var id = $(this).attr("data-id");
        var user = $(this).attr("data-user");

        $.ajax({
            type: 'POST',
            url: "manage-forum-post.aspx/AcceptForums",
            data: "{id: '" + id + "',Uid: '" + user + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                if (data2.d.toString() == "Success") {
                    Snackbar.show({ pos: 'top-right', text: 'Forum Accepted!', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    setTimeout(function () { window.location.href = "manage-forum-post.aspx"; }, 1000);

                }
                else {
                    Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                }
            },
            error: function (err) {
                Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
            }
        });
    });

    //deleted
    $(document.body).on("click", ".deleteItem", function () {
        var elem = $(this);
        var id = $(this).attr('data-id');
        swal.fire({
            html:
                '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/gsqxdxog.json" trigger="loop" colors="primary:#f7b84b,secondary:#f06548" style="width:100px;height:100px"></lord-icon><div class="mt-4 pt-2 fs-15 mx-5"><h4>Are You Sure You Want To Delete ?</h4><p class="text-muted mx-4 mb-0">You won`t be able to revert this !</p></div></div>',
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mb-1",
            confirmButtonText: "Yes, Delete It!",
            cancelButtonClass: "btn btn-danger w-xs mb-1",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                $.ajax({
                    type: 'POST',
                    url: "manage-forum-post.aspx/DeleteForums",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: "{id: '" + id + "'}",
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            Swal.fire({
                                html:
                                    '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/kfzfxczd.json" trigger="loop" colors="primary:#0ab39c,secondary:#405189" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4 style="color:red">Deleted!</h4><p class="text-muted mx-4 mb-0">Deleted Successfully</p></div></div>',
                                showCancelButton: !0,
                                showConfirmButton: !1,
                                cancelButtonClass: "btn btn-primary w-xs mb-1 back",
                                cancelButtonText: "Back",
                                buttonsStyling: !1,
                                showCloseButton: !0,
                            });
                            $(".back").on("click", () => window.location.href = "manage-forum-post.aspx");
                            elem.parent().parent().remove();
                        }
                        else if (data2.d.toString() == "Permission") {
                            Swal.fire({
                                html:
                                    '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/tdrtiskw.json" trigger="loop" colors="primary:#f06548,secondary:#f7b84b" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4>Oops...! Something went Wrong !</h4><p class="text-muted mx-4 mb-0">Permission denied. Please contact to your administrator</p></div></div>',
                                showCancelButton: !0,
                                showConfirmButton: !1,
                                cancelButtonClass: "btn btn-primary w-xs mb-1",
                                cancelButtonText: "Dismiss",
                                buttonsStyling: !1,
                                showCloseButton: !0,
                            });
                        }
                        else {
                            Swal.fire({
                                html:
                                    '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/tdrtiskw.json" trigger="loop" colors="primary:#f06548,secondary:#f7b84b" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4>Oops...! There is some problem now !</h4><p class="text-muted mx-4 mb-0">Please try again later</p></div></div>',
                                showCancelButton: !0,
                                showConfirmButton: !1,
                                cancelButtonClass: "btn btn-primary w-xs mb-1",
                                cancelButtonText: "Dismiss",
                                buttonsStyling: !1,
                                showCloseButton: !0,
                            });
                        }
                    }
                });
            }
        })
    });

    //Current Page
    $(document.body).on('click', ".pVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindForumsPost();
    });

    //Previous Page
    $(document.body).on('click', ".prVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindForumsPost();
    });

    //Next Page
    $(document.body).on('click', ".nxVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindForumsPost();

    });

    $(document).on('click', '.btndesc', function () {

        var Msg = $(this).attr('data-msg'); // Msg from data-msg

        $(".modalbody").html(Msg);


    })
});

//Bind Customers
function BindForumsPost() {
    var PLenght = $(".pageLenght option:selected").val();
    var PageNo = "1";
    var Key = $(".txtsearch").val();
    if ($(".mppagination li a").hasClass("active")) {
        PageNo = $(".mppagination li .active").attr('id').split('_')[1];
    }
    $('.custlbl').addClass("d-none");
    $.ajax({
        type: 'POST',
        url: "manage-forum-post.aspx/GetForums",
        data: "{PageNo:'" + PageNo + "',PageLenght:'" + PLenght + "',Key:'" + Key + "'}",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        async: true,
        success: function (data2) {

            if (data2.d == "Error") {
                $(".StrForumPost").html("<tr><td colspan='6' class='text-center'>no data available in the table</td></tr>");

            }
            if (data2.d == "Empty") {
                $(".StrForumPost").html("<tr><td colspan='6' class='text-center'>no data available in the table</td></tr>");

            }
            else {
                data = $.parseJSON(data2.d);
                $(".StrForumPost").html(data.table);
                $('.custcount').html(data.count);
                $('.custlbl').removeClass("d-none");
                BindLPage(PageNo, PLenght, data.count);
            }
        }
    });

}
//New Pagination
function BindLPage(cPage, pageS, pCount) {
    var noOfPagesCreated = ~~(parseFloat(pCount) / parseInt(pageS));
    var isExtra = (parseFloat(pCount) % parseInt(pageS)) === 0 ? 0 : 1;

    noOfPagesCreated = noOfPagesCreated + isExtra;

    $(".mppagination").empty();

    var pagesss = "";

    var np = parseInt(cPage) % 5 === 0 ? (parseInt(cPage) / parseInt(5) - 1) : parseInt(cPage) / parseInt(5);
    var nearestNextP = (~~np + 1) * 5;
    var pLength = noOfPagesCreated < parseInt(nearestNextP) ? noOfPagesCreated : parseInt(nearestNextP);
    var startPage = (parseInt(nearestNextP) - 4);

    if (parseInt(cPage) > 5) {
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_1'>1</a></li>";
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_1'>...</a></li>";
    }

    for (var i = startPage; i <= pLength; i++) {
        var act = i === parseInt(cPage) ? "active" : "";
        pagesss += "<li class='page-item'><a class='page-link pVClick " + act + "' href='javascript:void(0);' id='pno_" + (i) + "'>" + (i) + "</a></li>";
    }
    if (noOfPagesCreated > pLength) {
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_" + (pLength + 1) + "'>...</a></li>";
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_" + (noOfPagesCreated) + "'>" + (noOfPagesCreated) + "</a></li>";
    }



    var prvPg = startPage === 1 ? 1 : startPage - 1;
    var nxtPg = noOfPagesCreated > pLength ? (pLength + 1) : pLength;


    if (noOfPagesCreated <= 5) {
        prvPg = parseInt(cPage) === 1 ? 1 : parseInt(cPage) - 1;
        nxtPg = parseInt(cPage) === pLength ? pLength : parseInt(cPage) + 1;
    }

    var pgnPrev = "";
    if (parseInt(cPage) > 1) {
        pgnPrev = "<li class='page-item'><a id='pnon_" + prvPg + "' class='page-link prVClick' href='javascript:void(0);' aria-label='Previous'><i class='mdi mdi-chevron-left'></i> Previous</a></li>";
    }
    else {
        pgnPrev = "<li class='page-item'><a id='pnon_" + prvPg + "' class='page-link disabled' href='javascript:void(0);' aria-label='Previous'><i class='mdi mdi-chevron-left'></i> Previous</a></li>";
    }

    var pgnNext = "";

    if (nxtPg != parseInt(cPage)) {
        pgnNext = "<li class='page-item'><a class='page-link nxVClick' href='javascript:void(0);' id='pnon_" + nxtPg + "' aria-label='Next'>Next <i class='mdi mdi-chevron-right'></i></a></li>";
    }
    else {
        pgnNext = "<li class='page-item'><a class='page-link disabled' href='javascript:void(0);' id='pnon_" + nxtPg + "' aria-label='Next'>Next <i class='mdi mdi-chevron-right'></i></a></li>";
    }
    $(".mppagination").append(pgnPrev + pagesss + pgnNext);
}



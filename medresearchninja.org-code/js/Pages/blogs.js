
$(document).ready(function () {
    BindAllBlogs();

    $(document.body).on('click', ".pPVClick", function () {
        var ele = $(this);
        $(".pPagination a").removeClass("current");
        ele.addClass("current");
        BindAllBlogs();

    });
    $(document.body).on('click', ".prPVClick", function () {


        var ele = $(this);
        var activeIndex = $(".pPagination li.active a").attr("id").split('_')[1];
        var currentIndex = ele.attr("id").split('_')[1];
        if (activeIndex == currentIndex) {
            $(".pPagination li a.dNonePrev").css("display", "none");
            return;
        }
        $(".pPagination a").removeClass("current");
        ele.addClass("current");
        BindAllBlogs();

    });
    $(document.body).on('click', ".nxPVClick", function () {
        $(".pPagination li.dNonePrev").css("display", "flex");
        var ele = $(this);

        var currentIndex = ele.attr("id").split('_')[1];
        var activeIndex = $(".pPagination li.active a").attr("id").split('_')[1];

        if (currentIndex == activeIndex) {
            $(".pPagination li a.dNoneNext").css("display", "none");
            return;
        }

        $(".pPagination a").removeClass("current");
        ele.addClass("current");
        BindAllBlogs();

    });

});
function BindAllBlogs() {


    var pno = "1";
    if ($(".pPagination a").hasClass("current")) {
        pno = $(".pPagination .current").attr('id').split('_')[1];
    }

    var dts = { pno: pno };
    $.ajax({
        type: 'POST',
        url: 'blogs.aspx/allBlogs',
        data: JSON.stringify(dts),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        async: false,
        success: function (res) {
            var products = res.d;
            console.log("products from the webmethod is", products);
            var listings = "";
            var pLength = "";
            for (var i = 0; i < products.length; i++) {
                var blogurl = "/blog/" + products[i].BlogUrl;
                var img = "/" + products[i].ThumbImage;
                pLength = products[0].TotalCount;
                listings += "<div class='col-sm-6 col-xl-3'>";
                listings += "<div class='listing-style1 bdrs16'>";
                listings += "<div class='list-thumb'>";
                listings += "<a href='" + blogurl + "'><img class='w-100' src='" + img + "' alt='blog image'></a>";
                listings += "</div>";
                listings += " <div class='list-content'>";
                listings += "<p class='list-text body-color fz14 mb20 mb10-sm fw-bold'>" + products[i].PostedBy + " <span> | </span> " + products[i].PostedOn + "</p>";
                listings += "<hr><h5 class='list-title'><a href='" + blogurl + "'>" + (products[i].BlogTitle || "Untitled Blog") + "</a></h5>";
                listings += "</div>";
                listings += "</div>";
                listings += "</div>";

            }

            $("#BlogListBindingSec").empty();
            if (products.length > 0) {
                $("#BlogListBindingSec").append(listings);
                BindPPage(8, parseInt(pno), pLength);
                var maxHeight = Math.max.apply(null, $(".post-item .post__title a").map(function () {
                    return $(this).height();
                }).get());
                $(".post-item .post__title a").css("min-height", maxHeight);

                var maxHeight1 = Math.max.apply(null, $(".mainBlogPage .post-item .post__body .post__desc").map(function () {
                    return $(this).height();
                }).get());
                $(".mainBlogPage .post-item .post__body .post__desc").css("min-height", maxHeight1);
            }
        },
        error: function (err) {

            $("#BlogListBindingSec").empty();

        }
    });


};

//function BindPPage(pageS, cPage, pCount) {
//    var noOfPagesCreated = ~~(parseFloat(pCount) / parseInt(pageS));
//    var isExtra = (parseFloat(pCount) % parseInt(pageS)) === 0 ? 0 : 1;

//    noOfPagesCreated = noOfPagesCreated + isExtra;

//    $(".pPagination").empty();

//    var pagesss = "";

//    var np = parseInt(cPage) % 6 === 0 ? (parseInt(cPage) / parseInt(8) - 1) : parseInt(cPage) / parseInt(6);
//    var nearestNextP = (~~np + 1) * 6;
//    var pLength = noOfPagesCreated < parseInt(nearestNextP) ? noOfPagesCreated : parseInt(nearestNextP);
//    var startPage = (parseInt(nearestNextP) - 5);


//    for (var i = startPage; i <= pLength; i++) {
//        var act = i === parseInt(cPage) ? "current" : "";
//        var activ = i === parseInt(cPage) ? "active" : "";
//        var LastIndex = i === pLength ? "LastIndex" : "";
//        pagesss += "<li class='page-item " + activ + "'><a class='page-link pPVClick " + act + " " + LastIndex + "' href='javascript:void(0);' id='pno_" + (i) + "'>" + (i) + "</a></li>";
//    }
//    if (noOfPagesCreated > pLength) {
//        pagesss += "<li class='page-item'><a class=' pPVClick' href='javascript:void(0);' id='pno_" + (pLength + 1) + "'>...</a></li>";
//        pagesss += "<li class='page-item'><a class='pPVClick LastIndex' href='javascript:void(0);' id='pno_" + (noOfPagesCreated) + "'>" + (noOfPagesCreated) + "</a></li>";
//    }

//    var prvPg = startPage === 1 ? 1 : startPage - 1;
//    var nxtPg = noOfPagesCreated > pLength ? (pLength + 1) : pLength;

//    if (noOfPagesCreated <= 5) {
//        prvPg = parseInt(cPage) === 1 ? 1 : parseInt(cPage) - 1;
//        nxtPg = parseInt(cPage) === pLength ? pLength : parseInt(cPage) + 1;
//    }

//    var dNonePrev = parseInt(cPage) === 1 ? "dNonePrev" : "";
//    var dNoneNext = parseInt(cPage) === nxtPg ? "dNoneNext" : "";

//    var pgnPrev = "<li class='left page-item " + dNonePrev + "'><a id='pnon_" + prvPg + "' class='page-link prPVClick' href='javascript:void(0);' aria-label='Previous'><i class='fa fa-angle-left'></i></a></li>";

//    var pgnNext = "<li class='left page-item " + dNoneNext + "'><a class='page-link nxPVClick ' href='javascript:void(0);' id='pnon_" + nxtPg + "' aria-label='Next'><i class='fa fa-angle-right'></i></a></li>";


//    $(".pPagination").append(pgnPrev + pagesss + pgnNext);

//    var topOffset = $("#BlogListBindingSec").offset().top;
//    $(document).scrollTop(topOffset - 150)
//}

function BindPPage(pageSize, currentPage, totalCount) {

    const totalPages = Math.ceil(totalCount / pageSize);
    const delta = 2; // pages before & after current

    $(".pPagination").empty();
    let html = "";

    // PREV
    html += `
    <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
        <a class="page-link prPVClick" id="pno_${currentPage - 1}" href="javascript:void(0);">
            <i class="fa fa-angle-left"></i>
        </a>
    </li>`;

    let range = [];

    // Always include first page
    range.push(1);

    // Pages around current
    for (let i = currentPage - delta; i <= currentPage + delta; i++) {
        if (i > 1 && i < totalPages) {
            range.push(i);
        }
    }

    // Always include last page
    if (totalPages > 1) {
        range.push(totalPages);
    }

    // Remove duplicates & sort
    range = [...new Set(range)].sort((a, b) => a - b);

    // Build pagination with dots
    let last = null;
    range.forEach(page => {

        if (last && page - last > 1) {
            html += `
            <li class="page-item disabled">
                <span class="page-link">...</span>
            </li>`;
        }

        html += `
        <li class="page-item ${page === currentPage ? 'active' : ''}">
            <a class="page-link pPVClick ${page === currentPage ? 'current' : ''}"
               id="pno_${page}" href="javascript:void(0);">${page}</a>
        </li>`;

        last = page;
    });

    // NEXT
    html += `
    <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
        <a class="page-link nxPVClick" id="pno_${currentPage + 1}" href="javascript:void(0);">
            <i class="fa fa-angle-right"></i>
        </a>
    </li>`;

    $(".pPagination").append(html);

    // Scroll to top of list
    const topOffset = $("#BlogListBindingSec").offset().top;
    $(document).scrollTop(topOffset - 150);
}




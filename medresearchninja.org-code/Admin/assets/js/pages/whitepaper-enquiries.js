//Delete Function
$(document).ready(function () {
    $(document.body).on('click', '.deleteItem', function () {
        var elem = $(this);
        var id = elem.attr('data-id');
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, delete it!",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                $.ajax({
                    type: 'POST',
                    url: "whitepaper-enquiries.aspx/Delete",
                    data: "{id: '" + id + "'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    async: false,
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            Swal.fire({ title: "Deleted!", text: "Artical has been deleted.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                            elem.parent().parent().remove();
                        }
                        else if (data2.d.toString() == "Permission") {

                            Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                        }
                        else {
                            Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                        }
                    }
                });

            }
        })
    });

    $(document.body).on("click", ".btnViewInfo", function () {
        $("#Contactinfosingle").empty();
        var elem = $(this);
        var id = elem.attr('data-id');
        $.ajax({
            type: 'POST',
            url: "whitepaper-enquiries.aspx/GetDetails",
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (res) {
                var pack = JSON.parse(res.d);
                var tableinfo = "";
                if (pack) {
                    tableinfo += "<table class='table'><tbody>";
                    tableinfo += "<tr><td><b>AuthorName</b></td><td>:</td><td>" + pack.AuthorFullName + "</td></tr>";
                    tableinfo += "<tr><td><b>Author Position/Title</b></td><td>:</td><td>" + pack.AuthorPosition + "</td></tr>";
                    tableinfo += "<tr><td><b>Affiliation</b></td><td>:</td><td>" + pack.AuthorAffiliation + "</td></tr>";
                    tableinfo += "<tr><td><b>Author Email Id</b></td><td>:</td><td><a href='mailto:" + pack.AuthorEmailId + "' rel='noreferrer' target='_blank'>" + pack.AuthorEmailId + "</a></td></tr>";
                    tableinfo += "<tr><td><b>Contact No</b></td><td>:</td><td>" + pack.AuthorPhoneNo + "</td></tr>";
                    tableinfo += "<tr><td><b>Co-Author Name</b></td><td>:</td><td>" + pack.CoAuthorFullName + "</td></tr>";
                    tableinfo += "<tr><td><b>Co-Author Position/Title</b></td><td>:</td><td>" + pack.CoAuthorPosition + "</td></tr>";
                    tableinfo += "<tr><td><b>Co-Author Affiliation</b></td><td>:</td><td>" + pack.CoAuthorAffiliation + "</td></tr>";
                    tableinfo += "<tr><td><b>Co-Author Email Id</b></td><td>:</td><td><a href='mailto:" + pack.CoAuthorEmailId + "' rel='noreferrer' target='_blank'>" + pack.CoAuthorEmailId + "</a></td></tr>";
                    tableinfo += "<tr><td><b>Article Title</b></td><td>:</td><td>" + pack.ArticleTitle + "</td></tr>";
                    tableinfo += "<tr><td><b>Article Abstract </b></td><td>:</td><td>" + pack.ArticleAbstract + "</td></tr>";
                    tableinfo += "<tr><td><b>Article Type </b></td><td>:</td><td>" + pack.ArticleType + "</td></tr>";
                    tableinfo += "<tr><td><b>No of Tables/Figures </b></td><td>:</td><td>" + pack.ArticleTables + "</td></tr>";
                    tableinfo += "<tr><td><b>Article Word Count </b></td><td>:</td><td>" + pack.ArticleWordCount + "</td></tr>";
                    tableinfo += "<tr><td><b>Has this article been submitted to any other journal? </b></td><td>:</td><td>" + pack.ArticleAnyOtherJournal + "</td></tr>";
                    tableinfo += "<tr><td><b>Is this article based on previously published work?</b></td><td>:</td><td>" + pack.ArticlePublishedWork + "</td></tr>";
                    tableinfo += "<tr><td><b>Is this article based on previously published work? Details </b></td><td>:</td><td>" + pack.ArticlePrevPublishedWork + "</td></tr>";
                    tableinfo += "<tr><td><b>Is this article based on previously published work? </b></td><td>:</td><td>" + pack.ArticlePrevPublishedddl + "</td></tr>";
                    tableinfo += "<tr><td><b>Do you have any conflicts of interest to declare? </b></td><td>:</td><td>" + pack.DescInterestToDeclare + "</td></tr>";
                    tableinfo += "<tr><td><b>Details </b></td><td>:</td><td>" + pack.DescOrganization + "</td></tr>";
                    tableinfo += "<tr><td><b>Was this research funded by any organization? </b></td><td>:</td><td>" + pack.EthicalCompliance + "</td></tr>";
                    tableinfo += "<tr><td><b>Details </b></td><td>:</td><td>" + pack.DescEthicalCompliance + "</td></tr>";
                    tableinfo += "<tr><td><b>Acknowledgments </b></td><td>:</td><td>" + pack.Acknowledgments + "</td></tr>";
                    tableinfo += "<tr><td><b>Have all necessary ethical approvals been obtained for this research? </b></td><td>:</td><td>" + pack.EthicalCompliance + "</td></tr>";
                    tableinfo += "<tr><td><b>Details </b></td><td>:</td><td>" + pack.DescEthicalCompliance + "</td></tr>";
                    tableinfo += "<tr><td><b>Name </b></td><td>:</td><td>" + pack.ContactInfoName + "</td></tr>";
                    tableinfo += "<tr><td><b>Phone Number </b></td><td>:</td><td>" + pack.ContactInfoPhoneNo + "</td></tr>";
                    tableinfo += "<tr><td><b>Author Email Id</b></td><td>:</td><td><a href='mailto:" + pack.ContactInfoEmailId + "' rel='noreferrer' target='_blank'>" + pack.ContactInfoEmailId + "</a></td></tr>";
                    tableinfo += "<tr><td><b>Date </b></td><td>:</td><td>" + pack.Date + "</td></tr>";
                    tableinfo += "<tr><td><b>Signature </b></td><td>:</td><td>" + pack.Signature + "</td></tr>";
                    tableinfo += "</tbody></table>";
                    $("#Contactinfosingle").append(tableinfo);
                } else {
                    $("#Contactinfosingle").html("No Deatils Found.");
                }
            }
        });
    });


    //co-authors

    $(document.body).on("click", ".btnCoAuthInfo", function () {
        $("#Contactinfosingle1").empty();
        var elem = $(this);
        var id = elem.attr('data-id');
        $.ajax({
            type: 'POST',
            url: "whitepaper-enquiries.aspx/GetCoAuthDetails",
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (res) {
                var pack = JSON.parse(res.d);
                var tableinfo = "";
                if (pack && pack.length > 0) {
                    tableinfo += "<table class='table'><tbody>";
                    tableinfo += "<tr><th>#</th>";
                    tableinfo += "<th>Name</th>";
                    tableinfo += "<th>Co-Author Position/Title</th>";
                    tableinfo += "<th>Co-Author Affiliation</th>";
                    tableinfo += "<th>Co-Author Email Id</th></tr>";

                    for (var i = 0; i < pack.length; i++) {
                        tableinfo += "<tr>";
                        tableinfo += "<td>" + (i + 1) + "</td>";
                        tableinfo += "<td>" + pack[i].CoAuthorFullName + "</td>";
                        tableinfo += "<td>" + pack[i].CoAuthorPosition + "</td>";
                        tableinfo += "<td>" + pack[i].CoAuthorAffiliation + "</td>";
                        tableinfo += "<td>" + pack[i].CoAuthorEmailId + "</td>";
                        tableinfo += "</tr>";
                    }
                    tableinfo += "</tbody></table>";
                    $("#Contactinfosingle1").append(tableinfo);
                } else {
                    $("#Contactinfosingle1").html("No Details Found.");
                }
            
            }

        });
    });
});

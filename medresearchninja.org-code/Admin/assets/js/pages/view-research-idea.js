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
                    url: "view-research-idea.aspx/Delete",
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
            url: "view-research-idea.aspx/GetDetails",
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (res) {
                var pack = JSON.parse(res.d);
                var tableinfo = "";
                if (pack) {
                    tableinfo += "<table class='table'><tbody>";
                    tableinfo += "<tr><td><b>Research Topic Title</b></td><td>:</td><td>" + pack.ResearchTopic + "</td></tr>";
                    tableinfo += "<tr><td><b>Abstract of Research Topic/Title</b></td><td>:</td><td>" + pack.Abstract + "</td></tr>";
                    tableinfo += "<tr><td><b>Research Methods</b></td><td>:</td><td>" + pack.Methods + "</td></tr>";
                    tableinfo += "<tr><td><b>Expected Outcomes</b></td><td>:</td><td>" + pack.ExpectedOutcomes + "</td></tr>";
                    tableinfo += "<tr><td><b>Name</b></td><td>:</td><td>" + pack.SubmittedByName + "</td></tr>";
                    tableinfo += "<tr><td><b>Cantact</b></td><td>:</td><td>" + pack.SubmittedByContact + "</td></tr>";
                    tableinfo += "<tr><td><b>Affiliation </b></td><td>:</td><td>" + pack.SubmittedByAffiliation + "</td></tr>";
                    tableinfo += "<tr><td><b>References</b></td><td>:</td><td>" + pack.Reference + "</td></tr>";
                    tableinfo += "<tr><td><b>Additional Comments or Information</b></td><td>:</td><td>" + pack.Comments + "</td></tr>";
                    tableinfo += "<tr><td><b>Status </b></td><td>:</td><td>" + pack.Status + "</td></tr>";
                    tableinfo += "</tbody></table>";
                    $("#Contactinfosingle").append(tableinfo);
                } else {
                    $("#Contactinfosingle").html("No Deatils Found.");
                }
            }
        });
    });
});
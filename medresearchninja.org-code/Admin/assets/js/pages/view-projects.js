
//Delete Function
$(document).ready(function () {
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
                    url: "view-projects.aspx/Delete",
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
                            $(".back").on("click", () => window.location.href = "#");
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

    $(document.body).on("click", ".btnViewInfo", function () {
        $("#Contactinfosingle").empty();
        var elem = $(this);
        var id = elem.attr('data-id');
        $.ajax({
            type: 'POST',
            url: "view-projects.aspx/GetDetails",
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (res) {
                var pack = JSON.parse(res.d);
                var tableinfo = "";
                if (pack) {
                    tableinfo += "<table class='table'><tbody>";
                    tableinfo += "<tr><td><b>Project Id</b></td><td>:</td><td>" + pack.ProjectId + "</td></tr>";
                    tableinfo += "<tr><td><b>Project Name</b></td><td>:</td><td>" + pack.ProjectName + "</td></tr>";
                    tableinfo += "<tr><td><b>PriceINR</b></td><td>:</td><td>" + pack.PriceINR + "</td></tr>";
                    tableinfo += "<tr><td><b>Price Other</b></td><td>:</td><td>" + pack.PriceOther + "</td></tr>";
                    tableinfo += "<tr><td><b>Project Link</b></td><td>:</td><td><a href='" + pack.ProjectLink + "'>" + pack.ProjectLink + "</td></tr>";
                    tableinfo += "<tr><td><b>Subject</b></td><td>:</td><td>" + pack.Subject + "</td></tr>";
                    tableinfo += "<tr><td><b>Short Description </b></td><td>:</td><td>" + pack.ShortDesc + "</td></tr>";
                    tableinfo += "<tr><td><b>Maximum Collab </b></td><td>:</td><td>" + pack.MaxCollab + "</td></tr>";
                    tableinfo += "<tr><td><b>Published On</b></td><td>:</td><td>" + pack.PostedOn + "</td></tr>";
                    tableinfo += "<tr><td><b>Status </b></td><td>:</td><td>" + pack.Status + "</td></tr>";
                    tableinfo += "</tbody></table>";
                    $("#Contactinfosingle").append(tableinfo);
                } else {
                    $("#Contactinfosingle").html("No Deatils Found.");
                }
            }
        });
    });

    //Block-UnBlock Item

    $(document.body).on("click", ".blockItem", function () {
        var id = $(this).attr('data-id');
        var ftr = $(this).prop("checked") ? "Yes" : "No";
        $.ajax({
            type: 'POST',
            url: "view-projects.aspx/Publish",
            data: "{id:'" + id + "',ftr: '" + ftr + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                if (data2.d.toString() == "Success") {
                    if (ftr === "Yes") {
                        $("#sts_" + id).removeAttr("class");
                        $("#sts_" + id).attr("class", "badge badge-outline-danger shadow fs-13");
                        $("#sts_" + id).text("Blocked");
                        Snackbar.show({ pos: 'top-right', text: 'Project Published successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    }
                    else {
                        $("#sts_" + id).text("Draft");
                        $("#sts_" + id).removeAttr("class");
                        $("#sts_" + id).attr("class", "badge badge-outline-warning fs-13 shadow");
                        Snackbar.show({ pos: 'top-right', text: 'Project Draft successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    }
                }
                else if (data2.d.toString() == "Permission") {
                    Snackbar.show({ pos: 'top-right', text: 'Permission denied. Please contact to your administrator.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });

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
 

});


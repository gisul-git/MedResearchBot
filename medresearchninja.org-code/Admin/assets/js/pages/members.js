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
                    url: "members.aspx/Delete",
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
    //Password Criteria
    $(document.body).on("click", ".password-addon", function (e) {
        var i = $(this).siblings("input").attr("type");
        if (i == "password") {
            $(this).siblings("input").attr("type", "text");
        }
        else {
            $(this).siblings("input").attr("type", "password");
        }
    })
    $(document.body).on("change", ".txtpwd , .txtcnfpwd", function (e) {
        $(".txtpwd").val() != $(".txtcnfpwd").val() ? $(".lblstatus").html("Passwords Doesn't Match") : $(".lblstatus").html("");
    })
    $(document.body).on("focus", ".txtpwd , .txtcnfpwd", function (e) {
        $(".password-contain").css("display", "block");
    });
    $(document.body).on("blur", ".txtpwd , .txtcnfpwd", function (e) {
        $(".password-contain").css("display", "none");
    });
    $(document.body).on("keyup", ".txtpwd , .txtcnfpwd", function (e) {
        pwd = $(".txtpwd").val();
        pwd.match(/[a-z]/g) ? ($("#pass-lower").removeClass("invalid"), $("#pass-lower").addClass("valid")) : ($("#pass-lower").removeClass("valid"), $("#pass-lower").addClass("invalid"));
        pwd.match(/[A-Z]/g) ? ($("#pass-upper").removeClass("invalid"), $("#pass-upper").addClass("valid")) : ($("#pass-upper").removeClass("valid"), $("#pass-upper").addClass("invalid"));
        pwd.match(/[0-9]/g) ? ($("#pass-number").removeClass("invalid"), $("#pass-number").addClass("valid")) : ($("#pass-number").removeClass("valid"), $("#pass-number").addClass("invalid"));
        pwd.match(/[~!@#$%^&*(),.?:{}|<>]/g) ? ($("#pass-special").removeClass("invalid"), $("#pass-special").addClass("valid")) : ($("#pass-special").removeClass("valid"), $("#pass-special").addClass("invalid"));
        pwd.length >= 8 ? ($("#pass-length").removeClass("invalid"), $("#pass-length").addClass("valid")) : ($("#pass-length").removeClass("valid"), $("#pass-length").addClass("invalid"));
    })

    $(document.body).on("click", ".pwdItem", function (e) {
        var guid = $(this).attr('data-guid');
        var email = $(this).attr('data-email');
        $(".btnpwdsubmit").attr('data-guid', guid);
        $(".writermail").html(email);
        // GetPassword();
    });

    //Save New Pwd 
    $(document.body).on("click", ".btnpwdsubmit", function (e) {
        e.preventDefault();
        var count = 1;
        var pwd = $(".txtpwd").val();
        var cnfpwd = $(".txtcnfpwd").val();
        var guid = $(".btnpwdsubmit").attr("data-guid");
        var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[~!@#$%^&*(),.?:{}|<>]).{8,}$/;
        if (pwd != cnfpwd) {
            count = 0;
            $(".lblstatus").html("Passwords Doesn't Match");
        }
        if (!(regex.test(pwd))) {
            count = 0;
            $(".password-contain").css("display", "block");
        }
        if (count == 1) {
            $.ajax({
                type: 'POST',
                url: "members.aspx/UpdatePassword",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: "{Guid:'" + guid + "',password: '" + pwd + "'}",
                success: function (data2) {
                    if (data2.d.toString() == "Success") {
                        Snackbar.show({ pos: 'top-right', text: 'Password Updated successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                        //GetPassword();
                        $(".txtpwd").val("");
                        $(".txtcnfpwd").val("");
                        document.cookie = "med_uid=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
                    }
                    else {
                        Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time. FormData undefined', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                    }
                }
            })

        }
    })

    //Block/Unblock Partner
    $(document.body).on("click", ".blockItem", function () {
        var id = $(this).attr('data-id');
        var guid = $(this).attr('data-guid');
        var ftr = $(this).prop("checked") ? "Yes" : "No";
        $.ajax({
            type: 'POST',
            url: "members.aspx/BlockPartner",
            data: "{id: '" + id + "',guid:'" + guid + "',ftr: '" + ftr + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                if (data2.d.toString() == "Success") {
                    if (ftr === "Yes") {
                        $("#sts_" + id).removeAttr("class");
                        $("#sts_" + id).attr("class", "badge badge-outline-danger shadow fs-13");
                        $("#sts_" + id).text("Blocked");
                        Snackbar.show({ pos: 'top-right', text: 'Member Blocked successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    }
                    else {
                        $("#sts_" + id).text("Unverified");
                        $("#sts_" + id).removeAttr("class");
                        $("#sts_" + id).attr("class", "badge badge-outline-warning fs-13 shadow");
                        Snackbar.show({ pos: 'top-right', text: 'Member Unblocked successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });

                        $("#ver_" + id).removeClass("d-none");
                    }
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

    //Verify Partner
    $(document.body).on("click", ".verifyItem", function () {
        Snackbar.show({ pos: 'top-right', text: 'Please Wait ...', actionTextColor: '#fff', backgroundColor: '#008a3d' });

        var id = $(this).attr('data-id');
        var guid = $(this).attr('data-guid');
        $.ajax({
            type: 'POST',
            url: "members.aspx/VerifyPartner",
            data: "{id: '" + id + "',guid:'" + guid + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                if (data2.d.toString() == "Success") {
                    $("#sts_" + id).removeAttr("class");
                    $("#sts_" + id).attr("class", "badge badge-outline-success shadow fs-13");
                    $("#sts_" + id).text("Active");


                    $("#stsp_" + id).removeAttr("class");
                    $("#stsp_" + id).attr("class", "badge badge-outline-success shadow fs-13");
                    $("#stsp_" + id).text("Paid");
                    Snackbar.show({ pos: 'top-right', text: 'Member verified successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });

                    $("#ver_" + id).addClass("d-none");
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

    //Mail User
    $(document.body).on("click", ".mailItem", function () {

        var guid = $(this).attr('data-guid');
        var ele = $(this);
        var msgcnt = ele.find(".msgcnt").html();
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, update it!",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                Swal.fire({ title: "Processing...", text: "Please wait while we send the mail.", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });
                $.ajax({
                    type: 'POST',
                    url: "members.aspx/ApprovedMsg",
                    data: "{guid:'" + guid + "'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    async: true,
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            ele.find(".msgcnt").html(parseInt(msgcnt) + 1);
                            /*Snackbar.show({ pos: 'top-right', text: 'Mail Sent Successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });*/
                            Swal.fire({ title: "Sent!", text: "Mail Sent Successfully.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })

                        }
                        else {
                            Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                        }
                    },
                    error: function (err) {
                        Snackbar.show({ pos: 'top-right', text: 'Oops!!! There is some error right now, please try again after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                    }
                });
            }
        });

    });


    $(document.body).on("click", ".btnViewInfo", function () {
        $("#Contactinfosingle").empty();
        var elem = $(this);
        var id = elem.attr('data-id');
        $.ajax({
            type: 'POST',
            url: "members.aspx/GetDetails",
            data: JSON.stringify({ id: id }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (res) {
                var pack = JSON.parse(res.d);
                var tableinfo = "";
                if (pack) {
                    tableinfo += "<table class='table'><tbody>";
                    tableinfo += "<tr><td><b>User ID</b></td><td>:</td><td>" + pack.UserID + "</td></tr>";
                    tableinfo += "<tr><td><b>Full Name</b></td><td>:</td><td>" + pack.FullName + "</td></tr>";
                    tableinfo += "<tr><td><b>Email Id</b></td><td>:</td><td>" + pack.EmailId + "</td></tr>";
                    tableinfo += "<tr><td><b>Country</b></td><td>:</td><td>" + pack.Country + "</td></tr>";
                    tableinfo += "<tr><td><b>Contact</b></td><td>:</td><td>" + pack.Contact + "</td></tr>";
                    tableinfo += "<tr><td><b>Medical School Name</b></td><td>:</td><td>" + pack.MedicalSchoolName + "</td></tr>";
                    //tableinfo += "<tr><td><b>GovtID</b></td><td>:</td><td>" + pack.GovtID + "</td></tr>";
                    tableinfo += "<tr><td><b>Status </b></td><td>:</td><td>" + pack.Status + "</td></tr>";
                    tableinfo += "<tr><td><b>Profile Image </b></td><td>:</td><td>" + pack.ProfileImage + "</td></tr>";

                    if (pack.GovtID && pack.GovtID.endsWith('.pdf')) {
                        tableinfo += "<tr><td><b>Govt ID</b></td><td>:</td><td><a href='/" + pack.GovtID + "' target='_blank'><img src='assets/images/pdf.png' alt='PDF' style='width:50px; height:50px; vertical-align:middle;' /></a></td></tr>";
                    } else {
                        tableinfo += "<tr><td><b>Govt ID</b></td><td>:</td><td>" + pack.GovtID + "</td></tr>";
                    }


                    $("#Contactinfosingle").append(tableinfo);
                } else {
                    $("#Contactinfosingle").html("No Deatils Found.");
                }
            }
        });
    });

});


//function DeliveryOrder($this) {
//    var elem = $this;
//    var OrderGuid = elem.attr('data-id');
//    var currentStatus = $('#o_r_' + OrderGuid).text();

//    if (currentStatus != "") {
//        if (currentStatus == "Delivered") {
//            Snackbar.show({ pos: 'top-right', text: 'Order already delivered!', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
//            return false;
//        }
//        if (currentStatus == "Initiated") {
//            Snackbar.show({ pos: 'top-right', text: 'dispatched Order to proceed!', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
//            return false;
//        } if (currentStatus == "Cancelled") {

//            Snackbar.show({ pos: 'top-right', text: 'Order is already cancelled!', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
//            return false;
//        }
//    }

//    var oStatus = "Delivered";

//    Swal.fire({
//        title: "Are you sure?",
//        text: "You won't be able to revert this!",
//        icon: "warning",
//        showCancelButton: !0,
//        confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
//        cancelButtonClass: "btn btn-danger w-xs mt-2",
//        confirmButtonText: "Yes, update it!",
//        buttonsStyling: !1,
//        showCloseButton: !0,
//    }).then(function (result) {
//        if (result.value) {
//            Swal.fire({ title: "Processing...", text: "Please wait while we update the order.", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });

//            $.ajax({
//                type: 'POST',
//                url: "order-report.aspx/UpdateOrderStatusDelivered",
//                data: "{OrderGuid: '" + OrderGuid + "', oStatus: '" + oStatus + "'}",
//                contentType: 'application/json; charset=utf-8',
//                dataType: "json",
//                async: true,
//                success: function (data2) {
//                    if (data2.d.toString() == "Success") {
//                        var orderStatusBadge = "<a href='javascript:void(0);' data-id='" + OrderGuid + "' data-sts='" + oStatus + "' class='badge badge-outline-success'>" + oStatus + "</a>";

//                        Swal.fire({ title: "Delivered!", text: "Order has been delivered.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })

//                        $("#o_r_" + OrderGuid).html(orderStatusBadge);
//                    }
//                    else if (data2.d.toString() == "Permission") {
//                        Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
//                    } else if (data2.d.toString() == "Pending") {

//                        Swal.fire({ title: "Oops...", text: "Oops! To Remove Sponser the Payout should be in Pending Stage.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
//                    }
//                    else {
//                        Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
//                    }
//                }
//            });
//        }
//    });

//}
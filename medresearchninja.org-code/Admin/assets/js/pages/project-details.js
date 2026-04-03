$(document).ready(function () {
    $(".bs-tooltip").tooltip();
    BindProjectDetails();

    $(document.body).on("click", "#MembersTab a", function () {
        if ($("#MembersFlag").val() == "") {
            BindOrderMembers();
            $("#MembersFlag").val("1");
        }
    });

    $(document.body).on("click", "#PaymentsTab a", function () {
        if ($("#PaymentsFlag").val() == "") {
            BindProjectDues();
            $("#PaymentsFlag").val("1");
        }
    });

    $(document.body).on('click', '.btnDue', function () {
        var $this = $(this);
        var m_guid = $this.attr("data-guid");

        $("#txtAmount").val("");
        $("#txtComment").val("");
        $("#txtAmount").parent().parent().find(".fs-label-wrap").removeClass("input-error");
        $("#txtAmount").parent().parent().find(".error").html("");

        $("#btnSendDue").attr("data-guid", m_guid);
        $("#viewDueModal").modal('show');
    });

    $(document.body).on('click', '#btnSendDue', function () {
        var $this = $(this);
        var $thisParent = $this.parent();
        var currentData = $thisParent.html();
        $this.parent().html("<a href='javascript:void(0);' class='d-block p-1 px-2 text-success'><i class='mdi mdi-loading mdi-spin fs-30 align-middle me-2'></i> Sending...</a>");

        var m_guid = $this.attr("data-guid");
        var p_guid = getUrlParameter("id");
        var amount = $("#txtAmount").val();
        var cmts = $("#txtComment").val();
        var flag = 0;
        if (amount == "") {
            flag = 1;
            $("#txtAmount").parent().parent().find(".fs-label-wrap").addClass("input-error");
            $("#txtAmount").parent().parent().find(".error").html("Field can't be empty");
        }
        else {
            $("#txtAmount").parent().parent().find(".fs-label-wrap").removeClass("input-error");
            $("#txtAmount").parent().parent().find(".error").html("");
        }

        if (flag == 0) {
            Swal.fire({ title: "Processing", text: "Saving payment details and sending notification to the member. Please wait...", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });

            var _data = { p_guid: p_guid, m_guid: m_guid, amount: amount, cmts: cmts };
            $.ajax({
                type: 'POST',
                url: "project-details.aspx/SendNotification",
                data: JSON.stringify(_data),
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                async: true,
                success: function (data2) {
                    if (data2.d == "Success") {
                        Swal.fire({ title: "success", text: "Due added and email sent to member successfully.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                        $thisParent.html(currentData);
                    }
                    else if (data2.d.toString() == "Permission") {
                        Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                    }
                    else {
                        Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                    }
                    $("#viewDueModal").modal('hide');
                }
            });
        }
        else {
            $thisParent.html(currentData);
        }
    });

    $(document.body).on("click", ".btnDeleteProjectDue", function () {
        var $this = $(this);
        var $mainItem = $this.parent().parent();
        var id_ = $this.attr("data-id");
        var p_guid = getUrlParameter("id");
        var _data = { p_guid: p_guid, id: id_ }
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
                    url: "project-details.aspx/DeleteProjectDue",
                    data: JSON.stringify(_data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        var status = data.d;
                        if (status == "Success") {
                            Snackbar.show({ pos: 'top-right', text: 'Deleted successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                            $mainItem.remove();
                        }
                        else if (status == "Permission") {
                            Snackbar.show({ pos: 'top-right', text: 'Permisssion denied. Contact to your admin', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                        }
                        else {
                            Snackbar.show({ pos: 'top-right', text: 'Oops! There is some problem now. Please try after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                        }
                    }
                });
            }
        });
    });

    $(document.body).on('click', '.paymentDueMailReminder', function () {
        var elem = $(this);
        var pay_guid = elem.attr('data-guid');
        Swal.fire({
            title: "Confirmation Required",
            text: "You want to send payment remender",
            icon: "question",
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, Send!",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                Swal.fire({ title: "Processing Request", text: "Please wait while we prepare and send the email...", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });

                $.ajax({
                    type: 'POST',
                    url: "project-details.aspx/PaymentReminderEmail",
                    data: "{pay_guid: '" + pay_guid + "'}",
                    contentType: 'application/json; charset=utf-8',
                    //dataType: "json",
                    async: true,
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            Swal.fire({ title: "success", text: "Reminder Sent successfully ", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
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
    $(document.body).on('click', '.btnDelete', function () {
        var elem = $(this);
        var ord_guid = elem.attr('data-guid');
        Swal.fire({
            title: "Confirmation Required",
            text: "Are you sure you want to remove this member.",
            icon: "question",
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, Remove!",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                Swal.fire({ title: "Processing Request", text: "Please wait while we prepare.", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });

                $.ajax({
                    type: 'POST',
                    url: "project-details.aspx/RemoveMember",
                    data: "{ord_guid: '" + ord_guid + "'}",
                    contentType: 'application/json; charset=utf-8',
                    //dataType: "json",
                    async: true,
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            elem.parent().parent().remove();
                            Swal.fire({ title: "success", text: "Member removed successfully", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
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
    $(document.body).on('click', '.btncontinue', function () {
        $(".strerror").addClass("d-none");

        var mem_guid = $(".ddlMembers option:selected").val();
        var tranId = $(".txttrans").val();
        var ProjectGuid = getUrlParameter("id");
        var count = 0;
        if (mem_guid == "0") {
            $(".strerror").html("please select one member to continue");
            $(".strerror").removeClass("d-none");
            count++;
        }
        if (tranId == "") {
            $(".strerror").html("please enter transaction id to continue");
            $(".strerror").removeClass("d-none");
            count++;
        }
        if (count == 0) {
            Swal.fire({
                title: "Confirmation Required",
                text: "Are you sure you want to add this member.",
                icon: "question",
                showCancelButton: !0,
                confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
                cancelButtonClass: "btn btn-danger w-xs mt-2",
                confirmButtonText: "Yes, Add!",
                buttonsStyling: !1,
                showCloseButton: !0,
            }).then(function (result) {
                if (result.value) {
                    Swal.fire({ title: "Processing Request", text: "Please wait while we prepare.", icon: "info", showCancelButton: false, allowOutsideClick: false, didOpen: () => { Swal.showLoading(); }, willClose: () => { Swal.hideLoading(); } });

                    $.ajax({
                        type: 'POST',
                        url: "project-details.aspx/AddMembers",
                        data: "{mem_guid: '" + mem_guid + "',tranId:'" + tranId + "',ProjectGuid:'" + ProjectGuid +"'}",
                        contentType: 'application/json; charset=utf-8',
                        //dataType: "json",
                        async: true,
                        success: function (data2) {
                            if (data2.d.toString() == "Success") {
                                //elem.parent().parent().remove();
                                $("#AddMemberModal").modal('hide');
                                BindOrderMembers();
                                Swal.fire({ title: "success", text: "Member added successfully", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
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
        }
    });
});
function BindProjectDetails() {

    var projectGuid = getUrlParameter("id");
    if (projectGuid != null && projectGuid != "") {
        $.ajax({
            type: 'POST',
            url: "project-details.aspx/BindProjectDetails",
            data: "{p_guid:'" + projectGuid + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data) {
                var project_ = data.d;
                if (project_ != null) {
                    $("#editLink").attr("href", "write-projects.aspx?id=" + project_.Id);
                    $("#lblProjectLink").attr("href", project_.ProjectLink);
                    $("#addwhatsapps").attr("href", project_.ProjectLink);

                    $("#lblProjectId").html(project_.ProjectId);
                    $("#lblProjectId1").html(project_.ProjectId);
                    $("#txtTotalAmount").html(project_.PriceINR);

                    $("#lblProjectName").html(project_.ProjectName);
                    $("#lblProjectName1").html(project_.ProjectName);

                    $("#lblSubject").html(project_.Subject);
                    $("#lblSubject1").html(project_.Subject);

                    $("#lblStatus").html(project_.Status);
                    $("#lblStatus1").html(project_.Status);
                    $("#mCount").html(project_.mCount);

                    $("#lblStartDate").html(getDateTimeForm(project_.StartDate));
                    $("#lblCreatedOn").html(getDateTimeForm(project_.AddedOn));

                    $("#lblPostedOn").html(getDateTimeForm(project_.PostedOn));
                    $("#lblPostedOn1").html(getDateTimeForm(project_.PostedOn));

                    $("#lblPrice").html("<span class='fw-bold'>₹ " + project_.PriceINR + "</span>");
                    $("#lblOtherPrice").html(project_.PriceOther);

                    var _css = "";
                    var ttlMCount = parseInt(project_.mCount) || 0;
                    var ttlMaxCollab = parseInt(project_.MaxCollab) || 0;

                    if (ttlMCount === ttlMaxCollab) {
                        _css = "success";
                    } else {
                        _css = "danger";
                    }
                    $("#lblMaximumCollab").html("<span class='badge badge-outline-" + _css + "'>" + ttlMCount + "/" + ttlMaxCollab + "</span>");
                    $(".divDesc").html(project_.ShortDesc);
                    $(".bs-tooltip").tooltip();
                }
            }
        });
    }
    $(".bs-tooltip").tooltip();
}
function BindOrderMembers() {
    $("#tblMembersBody").empty();
    var projectGuid = getUrlParameter("id");
    if (projectGuid != null && projectGuid != "") {
        $.ajax({
            type: 'POST',
            url: "project-details.aspx/BindProjectMembers",
            data: "{p_guid:'" + projectGuid + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data) {
                var pMembers = data.d;

                var rwo = "";
                if (pMembers != null) {

                    for (var i = 0; i < pMembers.length; i++) {

                        rwo += "<tr>";
                        rwo += "<td>" + (i + 1) + "</td>";
                        rwo += "<td><a href='javascript:void(0);' class='badge badge-outline-primary'>" + pMembers[i].UserID + "</a></td>";
                        rwo += "<td><span data-guid='" + pMembers[i].UserGuid + "'>" + pMembers[i].FullName + "</span></td>";
                        rwo += "<td>" + pMembers[i].EmailId + "</td>";
                        rwo += "<td>" + pMembers[i].Contact + "</td>";
                        rwo += "<td><a href='javascript:void(0);' class='btn btn-soft-danger btn-sm btn-label waves-effect right waves-light rounded-pill btnDue' data-guid='" + pMembers[i].UserGuid + "'><i class='mdi mdi-currency-inr label-icon align-middle rounded-pill fs-16 ms-2'></i>Add Dues</a><a href='javascript:void(0);' class='btn btn-soft-danger btn-sm btn-icon rounded-pill ms-2 btnDelete' data-guid='" + pMembers[i].OrderGuid + "'><i class='mdi mdi-delete-forever align-middle fs-16'></i></a></td>";
                        rwo += "</tr>";
                    }

                    $("#tblMembersBody").html(rwo);
                }
            }
        })
    }
}
function BindProjectDues() {
    $("#tBodyAllPaymentsDues").empty();
    var p_guid = getUrlParameter("id");
    if (p_guid != null && p_guid != "") {
        $.ajax({
            type: 'POST',
            url: "project-details.aspx/BindProjectDues",
            data: "{p_guid:'" + p_guid + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data) {
                var oItems = data.d;
                var rwo = "";
                if (oItems != null) {
                    for (var i = 0; i < oItems.length; i++) {
                        var email = oItems[i].EmailId === "" ? "<a href='javascript:void(0);' class='bs-tooltip text-muted fs-18 mr-5px' data-bs-toggle='tooltip' data-placement='top' title='this order does not have email id to send reminder'><i class='mdi mdi-email-off'></i></a>" : "<a href='javascript:void();' class='bs-tooltip text-danger fs-18 mr-5px paymentDueMailReminder' data-id='" + oItems[i].id + "' data-guid='" + oItems[i].PaymentGuid + "' data-bs-toggle='tooltip' data-placement='top' title='Send Payment Due Reminder'><i class='mdi mdi-email'></i></a>";

                        rwo += "<tr class='" + (oItems[i].PaymentStatus == "Paid" ? "table-success" : "") + "'>";
                        rwo += "<td>" + (i + 1) + "</td>";
                        rwo += "<td><a href='javascript:void(0);' class='badge badge-outline-primary'>" + oItems[i].UserID + "</a></td>";
                        rwo += "<td>" + oItems[i].FullName + "</td>";
                        rwo += "<td>₹" + oItems[i].Amount + "</td>";
                        if (oItems[i].PaymentStatus == "Paid") {
                            rwo += "<td><span class='badge badge-outline-success'>" + oItems[i].PaymentStatus + "</span></td>";
                            email = "<a href='javascript:void(0);' class='bs-tooltip text-muted fs-18 mr-5px text-muted' data-bs-toggle='tooltip' data-placement='top' title='Payment Paid'><i class='mdi mdi-email-check'></i></a>";
                        }
                        else {
                            rwo += "<td><span class='badge badge-outline-danger'>" + oItems[i].PaymentStatus + "</span></td>";
                        }
                        rwo += "<td>" + oItems[i].PaymentMode + "</td>";
                        rwo += "<td>" + oItems[i].tr_id + "</td>";
                        rwo += "<td>" + getDateTimeForm(oItems[i].AddedOn) + "</td>";
                        rwo += "<td>" + oItems[i].Comments + "</td>";
                        rwo += "<td>"
                        rwo += "<a href='javascript:void();' class='bs-tooltip text-danger fs-16 mr-5px btnDeleteProjectDue' data-guid='" + oItems[i].PaymentGuid + "' data-id='" + oItems[i].id + "' data-bs-toggle='tooltip' data-placement='top' title='Delete Payment Due'><i class='mdi mdi-trash-can-outline'></i></a>";
                        rwo += email;
                        rwo += "</td>";
                        rwo += "</tr>";
                    }
                    $("#tBodyAllPaymentsDues").html(rwo);
                    $(".bs-tooltip").tooltip();
                    if (oItems.length > 0) {
                        $("#divNoPayment").hide();
                        $("#divYesPayment").show();
                    }
                    else {
                        $("#divNoPayment").show();
                        $("#divYesPayment").hide();
                    }
                }
                else {
                    $("#divNoPayment").show();
                    $("#divYesPayment").hide();
                }
            }
        })
    }
}

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
    return false;
};
function getDateForm(date1) {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    var re = /-?\d+/;
    var pOn = re.exec(date1);
    var date = new Date(parseInt(pOn[0]));
    var formattedDate = `${date.getDate()}-${months[date.getMonth()]}-${date.getFullYear()}`;
    return formattedDate;
}
function getDateTimeForm(date1) {
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
    var re = /-?\d+/;
    var pOn = re.exec(date1);
    var date = new Date(parseInt(pOn[0]));
    var time = date.toLocaleTimeString().replace(/(.*)\D\d+/, '$1');
    var formattedDate = `${date.getDate()}-${months[date.getMonth()]}-${date.getFullYear()} ${time}`;
    return formattedDate;
}

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
                    url: "orders.aspx/Delete",
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
                            $(".back").on("click", () => window.location.href = "javascript:void(0)");
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

    $(document.body).on('click', '.UpdatePayment', function () {
        var elem = $(this);
        var OrderGuid = elem.attr('data-id');
        var currentStatus = $('#o_r_' + OrderGuid).text();
        $("#btnPayStatus").attr("data-id", OrderGuid);
        $("#txtPayId").val("");
        $('#PaymentModel').modal('show');
    });

    $(document.body).on("click", "#btnPayStatus", function () {
        PaymentStatusUpdate($(this));
    });
});
$(document.body).on("click", ".btnreminder", function () {

    var user = $(this).attr('data-user');
    var pro = $(this).attr('data-pro');
    var ord = $(this).attr('data-guid');
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
                url: "orders.aspx/ReminderMail",
                data: "{user:'" + user + "',Pid:'" + pro + "',Oid:'" + ord + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                async: true,
                success: function (data2) {
                    if (data2.d.toString() == "Success") {
                        ele.find(".msgcnt").html(parseInt(msgcnt) + 1);
                        Swal.fire({ title: "Sent!", text: "Mail Sent Successfully.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                    }
                    else if (data2.d.toString() == "Expired") {


                        Swal.fire({ title: "Error!", text: "The Project does not exist any more.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                    }
                    else {
                        Swal.fire({ title: "Error!", text: "Oops!!! There is some error right now, please try again after some time.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                    }
                },
                error: function (err) {
                    Swal.fire({ title: "Error!", text: "Oops!!! There is some error right now, please try again after some time.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                }
            });
        }
    });

});

function PaymentStatusUpdate($this) {
    var OrderGuid = $this.attr("data-id");
    var payId = $("#txtPayId").val();
    var isValid = true;

    $("#txtPayId").parent().find(".error").html("");
    var payId = $("#txtPayId").val();
    if (payId === "") {
        isValid = false;
        $("#txtPayId").parent().find(".error").html("Field can't be empty");
    }

    if (isValid) {
        var _data = { OrderGuid: OrderGuid, payId: payId };
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, Update it!",
            buttonsStyling: false,
            showCloseButton: true,
        }).then(function (result) {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    url: "orders.aspx/UpdatePaymentStatus",
                    data: JSON.stringify(_data),
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        if (response.d === "Success") {
                            Swal.fire({
                                title: "Updated!",
                                text: "Payment Status has been Updated.",
                                icon: "success",
                                confirmButtonClass: "btn btn-primary w-xs mt-2",
                                buttonsStyling: false
                            });
                            $("#txtPayId").val("");
                            $('#PaymentModel').modal('hide');
                            $('#sts_' + OrderGuid).attr('class', 'badge bg-success text-light').html('Paid');
                            $('#mute_' + OrderGuid).remove('class', 'UpdatePayment');
                            $('#icon_' + OrderGuid).attr('class', 'mdi mdi-currency-inr text-muted');
                            $('#payid_' + OrderGuid).html(payId);
                        }
                        else if (response.d.toString() == "Permission") {
                            Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                        }
                        else {
                            Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                        }
                    }
                });
            } else {
            }
        });
    }
}
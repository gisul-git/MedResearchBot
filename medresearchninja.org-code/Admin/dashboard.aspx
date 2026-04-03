<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        span.clsord {
            text-align: center !important;
        }

        .filterRev.selected {
            background: #3577f1 !important;
            color: #fff !important;
        }

        .MfilterRev.selected {
            background: #3577f1 !important;
            color: #fff !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">

            <!-- start page title -->
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Dashboard</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item active"><a href="javascript: void(0);">Dashboard</a></li>
                            </ol>
                        </div>

                    </div>
                </div>
            </div>
            <!-- end page title -->

            <div class="row">
                <div class="col">
                    <div class="h-100">
                        <div class="row mb-3 pb-1">
                            <div class="col-12">
                                <div class="d-flex align-items-lg-center flex-lg-row flex-column">
                                    <div class="flex-grow-1">
                                        <h4 class="fs-16 mb-1">Hello, <%=Strusername %>!</h4>
                                        <p class="text-muted mb-0">Here's what's happening with your store today.</p>
                                    </div>
                                    <div class="mt-3 mt-lg-0">
                                        <div class="row g-3 mb-0 align-items-center">
                                            <div class="col-sm-auto">
                                                <div class="input-group">
                                                    <div class="input-group-text text-white" style="background: #ff7f3e">
                                                        <i class="mdi mdi-clock"></i>
                                                    </div>
                                                    <input type="text" id="liveClock" class="form-control border-0 dash-filter-picker shadow" readonly>
                                                </div>
                                            </div>
                                            <div class="col-auto">
                                                <a href="add-whatsapp-link.aspx" class="btn btn-soft bg-sucess border-danger"><i class="mdi  mdi-whatsapp  align-middle me-1"></i>Add Whatsapp Link</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xl-3 col-md-6">
                    <!-- card -->
                    <div class="card card-animate bg-info">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="flex-grow-1 overflow-hidden">
                                    <p class="text-uppercase fw-bold text-white-50 text-truncate mb-0">Total Revenue</p>
                                </div>
                            </div>
                            <div class="d-flex align-items-end justify-content-between mt-4">
                                <div>
                                    <h4 class="fs-22 fw-bold ff-secondary text-white mb-4">₹<span class="counter-value" data-target="<%=strTotalSales %>"><%=strTotalSales %></span></h4>
                                    <a href="/Admin/orders.aspx" class="text-decoration-underline text-white-50">view total revenue</a>
                                </div>
                                <div class="avatar-sm flex-shrink-0">
                                    <span class="avatar-title bg-soft-light rounded fs-3">
                                        <i class="bx bx-rupee text-white"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <!-- end col -->

                <div class="col-xl-3 col-md-6">
                    <!-- card -->
                    <div class="card card-animate bg-success">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="flex-grow-1 overflow-hidden">
                                    <p class="text-uppercase fw-bold text-white-50 text-truncate mb-0">Orders</p>
                                </div>
                            </div>
                            <div class="d-flex align-items-end justify-content-between mt-4">
                                <div>
                                    <h4 class="fs-22 fw-bold ff-secondary text-white mb-4"><span class="counter-value" data-target="<%=StrOrderCnt %>"><%=StrOrderCnt %></span></h4>
                                    <a href="/Admin/orders.aspx" class="text-decoration-underline text-white-50">view all orders</a>
                                </div>
                                <div class="avatar-sm flex-shrink-0">
                                    <span class="avatar-title bg-soft-light rounded fs-3">
                                        <i class="bx bx-shopping-bag text-white"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <!-- end col -->

                <div class="col-xl-3 col-md-6">
                    <!-- card -->
                    <div class="card card-animate bg-primary">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="flex-grow-1 overflow-hidden">
                                    <p class="text-uppercase fw-bold text-white-50 text-truncate mb-0">Members</p>
                                </div>
                            </div>
                            <div class="d-flex align-items-end justify-content-between mt-4">
                                <div>
                                    <h4 class="fs-22 fw-bold ff-secondary text-white mb-4"><span class="counter-value" data-target="<%=strNoOfMembers %>"><%=strNoOfMembers %></span></h4>
                                    <a href="/Admin/members.aspx" class="text-decoration-underline text-white-50">view all members</a>
                                </div>
                                <div class="avatar-sm flex-shrink-0">
                                    <span class="avatar-title bg-soft-light rounded fs-3">
                                        <i class="bx bx-user-circle text-white"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <!-- end col -->

                <div class="col-xl-3 col-md-6">
                    <!-- card -->
                    <div class="card card-animate bg-secondary">
                        <div class="card-body">
                            <div class="d-flex align-items-center">
                                <div class="flex-grow-1 overflow-hidden">
                                    <p class="text-uppercase fw-bold text-white-50 text-truncate mb-0">Contact requests</p>
                                </div>
                            </div>
                            <div class="d-flex align-items-end justify-content-between mt-4">
                                <div>
                                    <h4 class="fs-22 fw-bold ff-secondary text-white mb-4"><span class="counter-value" data-target="<%=strNoOfContact %>"><%=strNoOfContact %></span></h4>
                                    <a href="/Admin/view-contact-enquiry.aspx" class="text-decoration-underline text-white-50">view contact requests</a>
                                </div>
                                <div class="avatar-sm flex-shrink-0">
                                    <span class="avatar-title bg-soft-light rounded fs-3">
                                        <i class="mdi mdi-comment-question-outline text-white"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <!-- end col -->
            </div>
            <!-- end row-->
            <div class="row">
                <div class="col-xl-8">
                    <div class="card">
                        <div class="card-header border-0 align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Projects Sale Revenue</h4>

                            <div>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev" data-val="All">
                                    ALL
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev" data-val="1W">
                                    1W
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev" data-val="1M">
                                    1M
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev" data-val="6M">
                                    6M
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev selected" data-val="1Y">
                                    1Y 
                                </button>
                            </div>
                        </div>
                        <!-- end card header -->

                        <div class="card-header p-0 border-0 bg-soft-light">
                            <div class="row g-0 text-center">
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1"><span class="counter-value totalSales" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Total Sales</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1">₹<span class="counter-value confirmedSale" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Confirmed Order</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1">₹<span class="counter-value initiatedSale" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Initiated Order</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0 border-end-0">
                                        <h5 class="mb-1 text-success"><span class="counter-value convRatio" data-target="0">0</span>%</h5>
                                        <p class="text-muted mb-0">Conversation Ratio</p>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                        </div>
                        <!-- end card header -->

                        <div class="card-body p-0 pb-2">
                            <div class="w-100">
                                <div id="customer_impression_charts" data-colors='["--vz-warning", "--vz-primary", "--vz-danger"]' class="apex-charts" dir="ltr"></div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <div class="col-xl-4">
                    <div class="card card-height-100">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Order Status</h4>
                            <div>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterSts" data-val="All">
                                    ALL
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterSts" data-val="1W">
                                    1W
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterSts" data-val="1M">
                                    1M
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterSts" data-val="6M">
                                    6M
    
                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterSts selected" data-val="1Y">
                                    1Y 
                                </button>
                            </div>
                        </div>
                        <!-- end card header -->

                        <div class="card-body">
                            <div id="store-visits-source" class="apex-charts" dir="ltr"></div>
                        </div>
                    </div>
                    <!-- .card-->
                </div>
            </div>
            <div class="row">
                <div class="col-xl-4">
                    <!-- card -->
                    <div class="card card-height-100">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Members Around the World</h4>
                            <div class="flex-shrink-0">
                                <a href="/Admin/members.aspx" type="button" class="btn btn-soft-primary btn-sm">View Members
                                </a>
                            </div>
                        </div>
                        <!-- end card header -->

                        <!-- card body -->
                        <div class="card-body">

                            <%--<div id="sales-by-locations" data-colors='["--vz-light", "--vz-success", "--vz-primary"]' style="height: 269px" dir="ltr"></div>--%>
                            <div class="px-2 py-2 mt-1">
                                <%=strMembersCountry %>
                                <%=strMembersOtherCountry %>
                                <%--<p class="mb-1">Canada <span class="float-end">75%</span></p>
                                <div class="progress mt-2" style="height: 6px;">
                                    <div class="progress-bar progress-bar-striped bg-primary" role="progressbar" style="width: 75%" aria-valuenow="75" aria-valuemin="0" aria-valuemax="75"></div>
                                </div>

                                <p class="mt-3 mb-1">
                                    Greenland <span class="float-end">47%</span>
                                </p>
                                <div class="progress mt-2" style="height: 6px;">
                                    <div class="progress-bar progress-bar-striped bg-primary" role="progressbar" style="width: 47%" aria-valuenow="47" aria-valuemin="0" aria-valuemax="47"></div>
                                </div>

                                <p class="mt-3 mb-1">Russia <span class="float-end">82%</span></p>
                                <div class="progress mt-2" style="height: 6px;">
                                    <div class="progress-bar progress-bar-striped bg-primary" role="progressbar" style="width: 82%" aria-valuenow="82" aria-valuemin="0" aria-valuemax="82"></div>
                                </div>--%>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
                <div class="col-xl-8">
                    <div class="card">
                        <div class="card-header border-0 align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Members Revenue</h4>

                            <div>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none MfilterRev" data-val="All">
                                    ALL

                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none MfilterRev" data-val="1W">
                                    1W

                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none MfilterRev" data-val="1M">
                                    1M

                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none MfilterRev" data-val="6M">
                                    6M

                                </button>
                                <button type="button" class="btn btn-soft-primary btn-sm shadow-none MfilterRev selected" data-val="1Y">
                                    1Y 
                                </button>
                            </div>
                        </div>
                        <!-- end card header -->

                        <div class="card-header p-0 border-0 bg-soft-light">
                            <div class="row g-0 text-center">
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1"><span class="counter-value MtotalSales" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Total Sales</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1">₹<span class="counter-value MconfirmedSale" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Confirmed Order</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0">
                                        <h5 class="mb-1">₹<span class="counter-value MinitiatedSale" data-target="0">0</span></h5>
                                        <p class="text-muted mb-0">Initiated Order</p>
                                    </div>
                                </div>
                                <!--end col-->
                                <div class="col-6 col-sm-3">
                                    <div class="p-3 border border-dashed border-start-0 border-end-0">
                                        <h5 class="mb-1 text-success"><span class="counter-value MconvRatio" data-target="0">0</span>%</h5>
                                        <p class="text-muted mb-0">Conversation Ratio</p>
                                    </div>
                                </div>
                                <!--end col-->
                            </div>
                        </div>
                        <!-- end card header -->

                        <div class="card-body p-0 pb-2">
                            <div class="w-100">
                                <div id="Mcustomer_impression_charts" data-colors='["--vz-warning", "--vz-primary", "--vz-danger"]' class="apex-charts" dir="ltr"></div>
                            </div>
                        </div>
                        <!-- end card body -->
                    </div>
                    <!-- end card -->
                </div>
            </div>
            <div class="row">
                <div class="col-xl-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Recent Orders</h4>
                            <div class="flex-shrink-0">
                                <a href="orders.aspx" class="btn btn-soft-info btn-sm shadow-none">
                                    <i class="ri-file-list-3-line align-middle text-ligt"></i>View Reports</a>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive table-card">
                                <table class="table table-bordered table-centered align-middle table-nowrap mb-0">
                                    <thead class="text-muted table-light">
                                        <tr>
                                            <th>#</th>
                                            <th>Order Id</th>
                                            <th>User Details</th>
                                            <th>Project Name</th>
                                            <th>Total Price</th>
                                            <th>Payment Status</th>
                                            <th>Order Date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%=strOrders %>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/libs/apexcharts/apexcharts.min.js"></script>
    <script src="assets/js/pages/dashboard-ecommerce.init.js"></script>
    <script src="assets/js/pages/dashboard-ecommerce.js"></script>
    <script>
        $(document.body).on('click', '.btnmsg', function () {
            $("#Contactinfosingle").empty();
            var elem = $(this);
            var id = elem.attr('data-id');
            var name = elem.attr('data-name');
            $('.modal-header .modal-title').html('Message Information - ' + name);
            $.ajax({
                type: 'POST',
                url: "Dashboard.aspx/GetContactMessage",
                data: "{id: '" + id + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                async: false,
                success: function (res) {
                    var Message = res.d;
                    if (Message) {
                        var tableinfo = "<table class='table'><tbody>";
                        tableinfo += "<tr><td>" + Message + "</td></tr>";
                        tableinfo += "</tbody></table>";
                        $("#Contactinfosingle").append(tableinfo);
                    } else {
                        $("#Contactinfosingle").html("No message available.");
                    }
                }
            });
        });
    </script>
    <script>
        function updateClock() {
            let now = new Date();
            let formattedDate = now.toLocaleDateString('en-GB', {
                day: '2-digit',
                month: 'short',
                year: 'numeric'
            });
            let formattedTime = now.toLocaleTimeString('en-US', {
                hour: '2-digit',
                minute: '2-digit',
                second: '2-digit',
                hour12: true
            });
            document.getElementById("liveClock").value = `${formattedDate} ${formattedTime}`;
        }
        setInterval(updateClock, 1000);
        updateClock();
    </script>
</asp:Content>


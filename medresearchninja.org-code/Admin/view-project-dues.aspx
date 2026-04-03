<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-project-dues.aspx.cs" Inherits="Admin_view_project_dues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .input-error {
            border: 1px solid red !important;
        }

        .error {
            color: red;
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
                        <h4 class="mb-sm-0">View All Projects due</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/">Dashboard</a></li>
                                <li class="breadcrumb-item active">Projects due</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end page title -->

        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Filters</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 noSpace" placeholder="Search by Project Id/Project Name/Member Id/Name/Email/Phone No." ID="txtSearch" />
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlDay" runat="server" CssClass="form-control fSelect ddlDay">
                                        <asp:ListItem Value="">Select Day's</asp:ListItem>
                                        <asp:ListItem Value="Today">Today</asp:ListItem>
                                        <asp:ListItem Value="YDay">Yesterday</asp:ListItem>
                                        <asp:ListItem Value="L7Days">Last 7 Days</asp:ListItem>
                                        <asp:ListItem Value="L30Days">Last 30 Days</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox runat="server" placeholder="From Date" class="form-control mb-2 mr-sm-2 datepicker txtFrom" ID="txtFrom" />
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox runat="server" placeholder="To Date" class="form-control mb-2 mr-sm-2 datepicker txtTo" ID="txtTo" />
                                </div>
                                <div class="col-lg-2 d-none">
                                    <asp:DropDownList runat="server" class="form-control mb-2 fSelect ddlOStatus" ID="ddlOStatus">
                                        <asp:ListItem Value="">- Order Status -</asp:ListItem>
                                        <asp:ListItem Value="In-Process">In Process</asp:ListItem>
                                        <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <asp:DropDownList runat="server" class="form-control mb-2 fSelect ddlPStatus" ID="ddlPStatus">
                                        <asp:ListItem Value="">Payment Status</asp:ListItem>
                                        <asp:ListItem Value="Initiated">Initiated</asp:ListItem>
                                        <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2 ">
                                    <a id="btnSearch" class="btn btn-primary btnSearch" href="javascript:void(0);">Search</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-2">
                                    <select id="ddlPageSize" style="width: 80px !important;">
                                        <option value="30">30</option>
                                        <option value="50">50</option>
                                        <option value="100">100</option>
                                        <option value="200">200</option>
                                    </select>
                                </div>
                                <div class="col-lg-12 mt-3 mb-2">
                                    <div class="table-responsive table-card p-2">
                                        <table class="table table-nowrap align-middle table-striped table-bordered" style="width: 100%;">
                                            <thead class="bg-danger text-white">
                                                <tr>
                                                    <th class="nosort">#</th>
                                                    <th class="nosort">Project Id</th>
                                                    <th class="nosort">Project Name</th>
                                                    <th class="nosort">Member Id</th>
                                                    <th class="nosort">Name</th>
                                                    <th class="nosort">Amount</th>
                                                    <th class="nosort">Status</th>
                                                    <th class="nosort">Mode</th>
                                                    <th class="nosort">Trans. Id</th>
                                                    <th class="nosort">Added On</th>
                                                    <th class="nosort">Comments</th>
                                                    <th class="nosort">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tblBodyLoadingFrame">
                                            </tbody>
                                            <tbody id="tblBody">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 mt-3">
                                    <span id="showDetails"></span>
                                </div>
                                <div class="col-lg-12">
                                    <ul class="pagination pagination-separated justify-content-center mb-0 vPagination">
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/view-project-dues.js"></script>
</asp:Content>


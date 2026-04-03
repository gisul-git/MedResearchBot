<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="members.aspx.cs" Inherits="Admin_members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .minfowidth {
            width: 300px !important;
        }

        .mwidth {
            width: 200px !important;
            word-break: break-word;
        }

        .fs-8 {
            font-size: 8px;
        }

        .topbar-badge {
            right: -16px;
            top: 1px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">View Members</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Members</a></li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header align-items-center d-flex">
                    <h4 class="card-title mb-0 flex-grow-1">View Members</h4>
                    <div class="">
                        <a href="javascript:void(0);" class="btn btn-secondary btn-sm btnupload" id="btnupload">Upload Member Excel</a>
                        <a href="assets/SAMPLE123.xlsx" class="btn btn-success btn-sm  btn-label waves-effect waves-light"><i class="mdi mdi-tray-arrow-down label-icon align-middle fs-16 me-2"></i>Download Sample</a>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row ">
                        <div class="col-lg-12">
                            <h3>Filter By Search :</h3>
                        </div>
                        <div class="col-lg-4">
                            <label>Search Key</label>
                            <asp:TextBox runat="server" ID="txtKey" CssClass="form-control" placeholder="search by name,mobile,email ..."></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label>Select Date Range</label>
                            <asp:TextBox runat="server" ID="txtdates" CssClass="form-control daterangepicker" placeholder="dd/mmm/yyyy to dd/mmm/yyyy  "></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <label>Select Member Status</label>
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-select">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="Active">Active</asp:ListItem>
                                <asp:ListItem Value="Unverified">Unverified</asp:ListItem>
                                <asp:ListItem Value="Blocked">Blocked</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-2">
                            <label>Select Payment Status</label>
                            <asp:DropDownList runat="server" ID="ddlPayStatus" CssClass="form-select">
                                <asp:ListItem Value="">All</asp:ListItem>
                                <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                <asp:ListItem Value="Not Paid">Initiated</asp:ListItem>
                                <asp:ListItem Value="Failed">Failed</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-1">
                            <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-danger m-t-25" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    <div class="border border-1 mt-4 mb-4"></div>
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="alternative-pagination" class="table  align-middle table-striped table-bordered myTable" style="width: 100%">
                                <thead class="">
                                    <tr>
                                        <th>#</th>
                                        <th class="minfowidth">User Details</th>
                                        <th class="mwidth">Medical School Name	</th>
                                        <th>Country</th>
                                        <th class="text-center">Block/Unblock</th>
                                        <th class="text-center">Status</th>
                                        <th class="text-center">Payment Status</th>
                                        <th>AddedOn</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=strMembers%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="UserLogin" tabindex="-1" aria-labelledby="UserLoginLabel" aria-modal="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="UserLoginLabel">Update Password - <span class="writermail"></span></h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <label>New Password</label>
                        <div class="col-lg-12 mb-3">
                            <input class="form-control mb-2 mr-sm-2 txtpwd" type="password" id="txtNewPwd" placeholder="Enter Password" autocomplete="new-password" />
                            <button class="btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted password-addon" type="button" id="password-addon"><i class="ri-eye-fill align-middle"></i></button>
                        </div>
                        <label>Confirm Password</label>
                        <div class="col-lg-12 mb-3">
                            <input class="form-control mb-2 mr-sm-2 txtcnfpwd" type="password" id="txtConfirmPwd" placeholder="Enter Confirm Password" autocomplete="new-password" />
                            <button class="btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted password-addon" type="button" id="password-addon"><i class="ri-eye-fill align-middle"></i></button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <label class="lblstatus text-danger"></label>
                            <div id="password-contain" class="p-3 bg-light mb-2 password-contain rounded">
                                <h5 class="fs-13">Password must contain:</h5>
                                <p id="pass-length" class="invalid fs-12 mb-2">Minimum <b>8 characters</b></p>
                                <p id="pass-lower" class="invalid fs-12 mb-2">At least <b>lowercase</b> letter (a-z)</p>
                                <p id="pass-upper" class="invalid fs-12 mb-2">At least <b>uppercase</b> letter (A-Z)</p>
                                <p id="pass-number" class="invalid fs-12 mb-2">At least <b>number</b> (0-9)</p>
                                <p id="pass-special" class="invalid fs-12 mb-0">At least <b>Special character</b> (~!@#$%^&*(),.?":{}|<>)</p>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-secondary btnpwdsubmit">Update</button>
                </div>
            </div>
        </div>
    </div>
    <div id="WhitePaperModal" class="modal fade fadeInRight" tabindex="-1" aria-labelledby="WhitePaperModalLabel" style="display: none;" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="WhitePaperModalLabel">Register Member Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive" id="Contactinfosingle"></div>
                        </div>
                        <!--end col-->
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <div id="ProductModal" class="modal fade" tabindex="-1" aria-labelledby="ProductModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ProductModalLabel">Upload Member Excel</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:FileUpload runat="server" ID="FileUpload1" CssClass="form-control mb-2" />
                    <small class="mt-2 text-danger"><sup>*</sup>please upload <b>.xls</b> or <b>.xlsx</b> files only.</small>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-secondary ms-2" Text="Upload" OnClick="BtnUpload_Click" />

                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/members.js"></script>
    <script>
        $(document).ready(function () {
            $(document.body).on("click", ".btnupload", function () {
                $("#ProductModal").modal("show");
            });

            var f1 = flatpickr(document.getElementsByClassName('daterangepicker'), {
                //enableTime: true,
                dateFormat: "d-M-Y",
                mode: "range",

            });
        });
    </script>
</asp:Content>


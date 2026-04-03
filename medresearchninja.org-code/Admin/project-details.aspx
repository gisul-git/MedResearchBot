<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="project-details.aspx.cs" Inherits="Admin_project_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #tBodyPayments td:first-child {
            padding: 0.5rem 0.6rem !important;
        }

        .error {
            color: red;
        }

        .mr-5px {
            margin-right: 5px;
        }

        sup {
            color: red;
        }

        .ribbon-box .ribbon {
            position: unset !important;
        }

        .ml-5px {
            margin-right: 5px;
        }

        .mr-5px {
            margin-right: 10px;
        }

        tbody td:first-child {
            padding-left: 0.6rem !important;
        }

        .text-right {
            text-align: right !important;
        }

        .imgdelete {
            position: absolute;
            width: 30px;
            height: 30px;
            top: 15px;
            left: 338px;
            z-index: 9;
        }

        .fs-dropdown {
            width: auto !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"></h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                                <li class="breadcrumb-item active">View Project Details</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="card mt-n4 mx-n4">
                        <div class="bg-soft-danger">
                            <div class="card-body pb-0 px-4">
                                <div class="row mb-3">
                                    <div class="col-md">
                                        <div class="row align-items-center g-3">
                                            <div class="col-md">
                                                <div>
                                                    <h4 class="fw-bold">Project Details : <span id="lblProjectId"></span></h4>
                                                    <div class="hstack gap-3 flex-wrap mb-2 fw-bold">
                                                        <div>Project Name : <a id="lblProjectName"></a></div>
                                                        <div class="d-none vr"></div>
                                                        <div class="d-none">Subject : <a id="lblSubject"></a></div>
                                                    </div>
                                                    <div class="hstack gap-3 flex-wrap">
                                                        <div class="d-none">created on  : <span class="fw-medium" id="lblCreatedOn"></span></div>
                                                        <div class="d-none vr"></div>
                                                        <div>Posted On : <span class="fw-medium" id="lblPostedOn"></span></div>
                                                        <div class="vr"></div>
                                                        <div class="badge rounded-pill bg-info fs-12" id="lblStatus"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-auto">
                                        <div class="hstack gap-1 flex-wrap">
                                            <a href="javascript:void(0);" id="addwhatsapps" target="_blank" class="avatar-xs d-block bs-tooltip" data-bs-toggle="tooltip" title='WhatsApp Group Invitation'>
                                                <span class="avatar-title rounded-circle fs-18 bg-success shadow"><i class="ri-whatsapp-line fs-18"></i></span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <ul class="nav nav-tabs-custom border-bottom-0" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-bs-toggle="tab" href="#ProjectDetails" role="tab">Project Details
                                        </a>
                                    </li>
                                    <li class="nav-item" id="MembersTab">
                                        <a class="nav-link" data-bs-toggle="tab" href="#members" role="tab">Members
                                        </a>
                                    </li>
                                    <li class="nav-item" id="PaymentsTab">
                                        <a class="nav-link" data-bs-toggle="tab" href="#payments" role="tab">Payments
                                        </a>
                                    </li>
                                </ul>
                            </div>
                            <!-- end card body -->
                        </div>
                    </div>
                    <!-- end card -->
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="tab-content">
                        <div class="tab-pane active" id="ProjectDetails" role="tabpanel">
                            <div class="tab-content">
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="card">
                                            <div class="card-header">
                                                <h6 class="fw-semibold text-uppercase mb-0">Description</h6>
                                            </div>
                                            <div class="card-body p-4">
                                                <div class="row">
                                                    <div class="col-lg-12 divDesc">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="card">
                                            <div class="card-header">
                                                <h6 class="fw-semibold text-uppercase mb-0">Summary</h6>
                                            </div>
                                            <div class="card-body p-4">
                                                <div class="row">
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Project Id : <span id="lblProjectId1" class="badge badge-outline-primary fs-12"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Project Name : <span id="lblProjectName1"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Subject : <span id="lblSubject1"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Price INR : <span id="lblPrice"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Price USD	 : <span id="lblOtherPrice"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Whatsapp Group Link : <a id="lblProjectLink" href="javascript:void(0);" target="_blank" class="badge badge-soft-info">Click Link</a></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Maximum Collab : <span id="lblMaximumCollab"></span></label>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Start Date : <span id="lblStartDate"></span></label>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Posted On : <span id="lblPostedOn1"></span></label>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12">
                                                        <div class="mb-1">
                                                            <label class="form-label">Status : <span id="lblStatus1"></span></label>
                                                            <div></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--end tab-pane-->
                        <div class="tab-pane" id="members" role="tabpanel">

                            <div class="card">
                                <div class="card-header d-flex justify-content-between">
                                    <h6 class="fw-semibold text-uppercase mb-0">Project Members</h6>
                                    <div class="d-flex align-items-center">
                                        <a href="javascript:void(0);" class="btn btn-danger btn-sm" id="btnAddMember"><i class="ri-add-line align-bottom me-1"></i>Add Member</a>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive table-card p-2">
                                                <table id="alternative-pagination" class="table table-nowrap align-middle table-striped table-bordered" style="width: 100%;">
                                                    <thead>
                                                        <tr class="table-light">
                                                            <th>SR No.</th>
                                                            <th>Member Id</th>
                                                            <th>Name </th>
                                                            <th>Email </th>
                                                            <th>Contact</th>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tblMembersBody">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <!--end tab-pane-->
                        <div class="tab-pane" id="payments" role="tabpanel">
                            <div class="card">
                                <div class="card-header">
                                    <h6 class="fw-semibold text-uppercase mb-0">Received Payments</h6>
                                </div>
                                <div class="card-body">

                                    <div class="row" id="divNoPayment">
                                        <div class="col-md-12">
                                            <div class="text-center">
                                                <lord-icon src="https://cdn.lordicon.com/yeallgsa.json" trigger="loop" colors="primary:#4b38b3,secondary:#0ab39c" style="width: 80px; height: 80px"></lord-icon>
                                                <h5 class="fs-16 mt-2">No payment dues have been made for this project.<br />
                                                </h5>

                                            </div>

                                        </div>
                                    </div>

                                    <div class="row" id="divYesPayment" style="display: none;">
                                        <div class="col-md-12  mt-3 mb-2">
                                            <div class="table-responsive table-card p-2">
                                                <table class="table table-nowrap align-middle table-striped table-bordered" style="width: 100%;">
                                                    <thead>
                                                        <tr class="table-light">
                                                            <th>SR No.</th>
                                                            <th>Member Id </th>
                                                            <th>Member Name </th>
                                                            <th>Amount </th>
                                                            <th>Paid Amount </th>
                                                            <th>Status </th>
                                                            <th>Payment By</th>
                                                            <th>Trans. Id </th>
                                                            <th>Added On </th>
                                                            <th>Comments </th>
                                                            <th>Action </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody id="tBodyAllPaymentsDues">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <!--end tab-pane-->
                    </div>
                </div>
                <!-- end col -->
            </div>
            <!-- end row -->
        </div>
        <!-- container-fluid -->
    </div>

    <div class="modal fade " id="viewDueModal" tabindex="-1" role="dialog" aria-labelledby="viewDueLabel" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header p-3 ps-4 bg-soft-danger">
                    <h5 class="modal-title" id="viewDueLabel">Send Due Notification to Member</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-x">
                            <line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>
                    </button>
                </div>
                <div class="modal-body mb-2">
                    <div class="row">
                        <div class="col-md-6 mt-2">
                            <div class="mb-2">
                                <label class="form-label">Amount INR<sup>*</sup></label>
                                <input id="txtAmount" maxlength="50" placeholder="850" class="form-control numWPts txtAmount" />
                                <span class="error"></span>
                            </div>
                        </div>
                        <div class="col-md-6 mt-2">
                            <div class="mb-2">
                                <label class="form-label">Amount USD<sup>*</sup></label>
                                <input id="txtUSDAmount" maxlength="50" placeholder="10.00" class="form-control numWPts txtUSDAmount" />
                                <span class="error"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 mt-2">
                            <div class="mb-2">
                                <label class="form-label">Comments</label>
                                <textarea id="txtComment" maxlength="200" class="form-control txtComment" rows="4"></textarea>
                                <span class="error"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 mt-2">
                            <div class="mb-2">
                                <a href="javascript:void(0);" class="btn btn-primary btnSendDue" id="btnSendDue">Send Mail</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="AddMemberModal" tabindex="-1" role="dialog" aria-labelledby="viewDueLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header p-3 ps-4 bg-soft-danger">
                    <h5 class="modal-title" id="AddMembeLabel">Add New Members</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-x">
                            <line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>
                    </button>
                </div>
                <div class="modal-body mb-2">
                    <div class="row">
                        <div class="col-lg-6">
                            <label>Select Member</label>
                            <asp:DropDownList runat="server" ID="ddlMembers" CssClass="form-select ddlMembers fSelect">
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-3">
                            <label>Transaction Id</label>
                            <input id="txttrans" class="txttrans form-control" maxlength="30" placeholder="Enter transaction id..." />
                        </div>
                        <div class="col-lg-3">
                            <a href="javascrit:void(0);" class="btn btn-danger m-t-25 btncontinue">Continue..</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" value="<%=Request.QueryString["id"] %>" id="txtOID" />
    <input type="hidden" value="" id="txtOrdId" />
    <input type="hidden" value="" id="MembersFlag" />
    <input type="hidden" value="" id="PaymentsFlag" />

    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/libs/cleave.js/cleave.min.js"></script>
    <script src="assets/js/pages/project-details1.js"></script>
    <script>
        $(document.body).on("click", "#btnAddMember", function () {
            $("#AddMemberModal").modal("show");
        });
    </script>
</asp:Content>


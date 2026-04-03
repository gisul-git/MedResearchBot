<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="whitepaper-enquiries.aspx.cs" Inherits="Admin_whitepaper_enquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Whitepapers</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Enquiries</a></li>
                                <li class="breadcrumb-item active">View Whitepaper</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">View Whitepaper</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <table id="alternative-pagination" class="table nowrap align-middle table-striped table-bordered myTable" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Author FullName</th>
                                            <th>Author EmailID</th>
                                            <th>Author Phone No</th>
                                            <th>Co-Author Details</th>
                                            <th>Attachment Manuscript</th>
                                            <th>Attach Supplementory Manuscript</th>
                                            <th>Date</th>
                                            <th>Signature</th>
                                            <th>More Information</th>
                                            <th class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%=StrWhitepapers %>
                                    </tbody>

                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="WhitePaperModal" class="modal fade fadeInRight" tabindex="-1" aria-labelledby="WhitePaperModalLabel" style="display: none;" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="WhitePaperModalLabel">Whitepaper Article Details</h5>
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
    <div id="WhitePaperModal1" class="modal fade fadeInRight" tabindex="-1" aria-labelledby="WhitePaperModalLabel" style="display: none;" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="WhitePaperModalLabel1">Co-Authors Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive" id="Contactinfosingle1"></div>
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
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/whitepaper-enquiries.js"></script>
</asp:Content>

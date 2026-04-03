<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-modules.aspx.cs" Inherits="Admin_view_modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .maxWidth {
            max-width: 200px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">View All Projects</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Projects</a></li>
                                <li class="breadcrumb-item active">View Projects</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">View Projects</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="alternative-pagination" class="table align-middle table-striped table-bordered myTable" style="width: 100%">
                                <thead class="">
                                    <tr>
                                        <th>#</th>
                                        <th class='maxWidth'>ModuleName</th>
                                        <th>ModuleType</th>
                                        <th>videolink</th>
                                        <th>TextContent</th>
                                        <th>FullDesc</th>
                                        <th>Updated On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=strModules%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="viewModuleTextContent" class="modal fade fadeInRight" tabindex="-1" aria-labelledby="ViewModelLabel" style="display: none;" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="view-module">Module Text content</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive" id="textContent"></div>
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
    <div id="viewModuleFullDesc" class="modal fade fadeInRight" tabindex="-1" aria-labelledby="ViewModelLabel" style="display: none;" aria-modal="true" role="dialog">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="view-module-full-desc">Module Full description</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="table-responsive" id="FullDesc"></div>
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
    <script src="assets/js/pages/viewModules.js"></script>
</asp:Content>


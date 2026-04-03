<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-project-tags.aspx.cs" Inherits="Admin_manage_project_tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage Tags</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Projects</a></li>
                                <li class="breadcrumb-item active">Manage Tags</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add New":"Update"%> Tag</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-4 mb-3">
                                    <label class="form-label" for="project-title-input">Tag Name<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 alphaonly txtName" ID="txtName" placeholder="Enter Tag Name" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-3">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save"  CssClass="btn btn-secondary waves-effect waves-light m-t-25" Style="margin-top: 28px" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title">View Tags</h4>
                        </div>
                        <div class="card-body table-responsive">
                            <table id="alternative-pagination" class="table table-nowrap align-middle table-striped table-bordered myTable" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Tag Name</th>
                                        <th>Last Updated On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=strTag %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <script src="assets/js/jquery-3.6.0.min.js"></script>
   <script src="assets/js/pages/manage-project-tags.js"></script>
    <script>
       
    </script>
</asp:Content>


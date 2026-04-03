<%@ Page Title="Med Research Ninja | Resource Category" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-resource-category.aspx.cs" Inherits="Admin_manage_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage Category</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                 <li class="breadcrumb-item"><a href="javascript: void(0);">Resources</a></li>
                                <li class="breadcrumb-item active"> Manage Category</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblStatus" runat="server" Visible="false" Width="100%"></asp:Label>
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Resource Category</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-4">
                                <div class="col-lg-3">
                                    <label>Category Title<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtName" ID="txtTitle" placeholder="Category Title" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xxl-3 col-md-6">
                                    <div>
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary waves-effect waves-light m-t-25" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" />
                                        <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info waves-effect waves-light m-t-25" Visible="false" Text="Add New Category" OnClick="btnNew_Click" />
                                        <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Manage Resource Category </h4>
                        </div>
                        <div class="card-body">
                            <div class="card-body">
                                <table id="alternative-pagination" class="table nowrap dt-responsive align-middle table-striped table-bordered myTable" style="width: 100%;">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Category Title</th>
                                            <th>AddedOn</th>
                                            <th class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                            <%=strResourcesCategory %>
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
    <script src="assets/js/pages/manage-resource-category.js"></script>
    <script>
        $(document).ready(function () {
            $(".txtName").change(function () {
                $(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\&/g, 'and').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
            });
        });
    </script>
</asp:Content>


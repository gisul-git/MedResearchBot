<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-testimonials.aspx.cs" Inherits="Admin_add_testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Testimonials</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Testimonials</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Testimonials</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Testimonials</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6 mb-2">
                                    <label class="">Institute Name <sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtInstitute" placeholder="Enter Institute Name" />
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtInstitute" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 mb-2">
                                    <label class="">Posted By<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtPostedBy" placeholder="Enter Posted By" />
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPostedBy" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-lg-12 mb-2 ">
                                    <label class="">Full Desc <sup>*</sup></label>
                                    <asp:TextBox ID="txtFullDesc" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" runat="server" placeholder="Full Desc"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" Style="margin-top: 10px;" />
                                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Testimonials" OnClick="btnNew_Click" Style="margin-top: 10px;" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="assets/js/jquery-3.6.0.min.js"></script>
        <script>
            $(document).ready(function () {
                $(".txtName").change(function () {
                    $(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
                });
            });
        </script>
</asp:Content>


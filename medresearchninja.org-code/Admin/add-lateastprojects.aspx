<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-lateastprojects.aspx.cs" Inherits="Admin_add_Lateastprojects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Latest Project</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Latest Projects</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Project</li>
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
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Latest Projects </h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 mb-2">
                                    <label class="form-label" for="project-title-input">Category<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-select mb-2">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Please select one "></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3 mb-2">
                                    <label class="">Project Title<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="250" class="form-control mb-2 mr-sm-2 txtName" ID="txtProjectTitle" placeholder="Enter Project Title" />
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtProjectTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3">
                                    <label>Project URL<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtName" ID="txtProjectURL" placeholder="Project URL" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtProjectURL" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-3 mb-2">
                                    <label>Thumb Image</label>
                                    <asp:FileUpload runat="server" ID="Thumbimage" CssClass="form-control" placeholder="Thumb Image"></asp:FileUpload>
                                    <small style="color: red;">Image format .png, .jpeg, .jpg, .webp with 330 w X 225 h</small><br />
                                    <%=strThumbImage %>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" Style="margin-top: 10px;" />
                                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New" OnClick="btnNew_Click" Style="margin-top: 10px;" />
                                    <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPDFLink" runat="server" Visible="false"></asp:Label>
                                </div>
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


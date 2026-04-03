<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-other-members.aspx.cs" Inherits="Admin_add_other_members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Add Other Member</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Other Member</a></li>
                                <li class="breadcrumb-item active">Add Video</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add New":"Update"%> Other Member</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6 mb-2">
                                    <label class="">Name <sup class="text-danger">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtname" CssClass=" form-control" MaxLength="100" placeholder="Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 mb-2">
                                    <label class="">Linkedin Url<sup class="text-danger">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtlink" CssClass=" form-control" MaxLength="100" placeholder="Linkedin Url"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtlink" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 mb-3">
                                    <label class="">Select Type <sup class="text-danger">*</sup></label>
                                    <div class="custom-textbox">

                                        <asp:DropDownList ID="ddltype" runat="server" CssClass="dropdown-inside-textbox form-select">
                                            <asp:ListItem Value="">Please Select</asp:ListItem>
                                            <asp:ListItem>Core Committee</asp:ListItem>
                                            <asp:ListItem>Working Committee</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-6 mb-2">
                                    <label class="">Thumb Image <sup class="text-danger">*</sup></label>
                                    <asp:FileUpload runat="server" ID="Thumbimage" CssClass="form-control" />
                                    <small class="text-danger fw-bold">Image format .png, .jpeg, .jpg, .webp with 556px w X 581px h is required.</small><br />
                                    <%=strThumbImage %>
                                </div>
                                <div class="col-lg-4 mb-3">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-success waves-effect waves-light" Style="margin-top: 28px" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnNew" runat="server" Text="Add New Member" CssClass="btn btn-success waves-effect waves-light" Style="margin-top: 28px" OnClick="btnNew_Click" Visible="false" />
                                    <asp:Label runat="server" ID="lblThumb" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="Med Research Ninja | Projects" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="write-projects.aspx.cs" Inherits="Admin_write_projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .fs-option:hover {
            background-color: #426CB4 !important;
            color: white !important;
        }

        .fs-wrap.multiple .fs-option {
            background: White;
            color: #000;
        }

        .fs-option.selected {
            background-color: #426CB4 !important;
            color: white !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Projects</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Projects</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Project</li>
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
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Project</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-4">
                                <div class="col-lg-4">
                                    <label>Project Name<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtProjectName" placeholder="Project Name" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtProjectName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label>Max Collaborator Count<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtMaxColCount" placeholder="Max Collaborator Count" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtMaxColCount" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label>Price (INR)<sup></sup></label>
                                    <div class="input-group">
                                        <span class="input-group-text">₹</span>
                                        <asp:TextBox runat="server" class="form-control numWPts" ID="txtPriceINR" placeholder="Price INR" MaxLength="10" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <label>Price (USD)</label>
                                    <div class="input-group">
                                        <span class="input-group-text">$</span>
                                        <asp:TextBox runat="server" class="form-control numWPts" ID="txtPriceOther" placeholder="10.00" MaxLength="10" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <label>Whatsapp Group Link<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtProjectLink" placeholder="Whatsapp Group Link (Externel Link)" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txtProjectLink" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 ">
                                    <label>Select Product Tags <sup>*</sup></label>
                                    <asp:ListBox runat="server" ID="ddlTags" SelectionMode="Multiple" CssClass="form-control fSelect"></asp:ListBox>
                                </div>
                                <div class="col-lg-4">
                                    <label>Subject<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtSubject" placeholder="Subject" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="txtSubject" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Posted On <sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 datetimepicker" ID="txtPostedOn" placeholder="Select Posted On Date" />
                                    <asp:RequiredFieldValidator ID="rfv10" runat="server" ControlToValidate="txtPostedOn" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Start Date<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 datepicker" ID="txtStart" placeholder="Enter Start Date" />
                                    <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtStart" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label>Short Desc<sup>*</sup></label>
                                    <asp:TextBox ID="txtShortDesc" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" Rows="3" runat="server" placeholder="Short Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv9" runat="server" ControlToValidate="txtShortDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xxl-3 col-md-6">
                <div>
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary waves-effect waves-light m-t-25" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" />
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info waves-effect waves-light m-t-25" Visible="false" Text="Add New" OnClick="btnNew_Click" />

                </div>
            </div>
        </div>
    </div>

</asp:Content>




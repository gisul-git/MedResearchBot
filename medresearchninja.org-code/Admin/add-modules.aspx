<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-modules.aspx.cs" Inherits="Admin_add_modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .module-type-fields {
            display: none;
        }
        
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
                        <h4 class="mb-sm-0">Modules</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Modules</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Module</li>
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
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Module</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-4">
                                <div class="col-lg-6">
                                    <label>Module Name<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtModuleName" placeholder="Module Name" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtModuleName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Module name is required"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="col-lg-6">
                                    <label>Module Type<sup>*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlModuleType" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlModuleType_SelectedIndexChanged">
                                        <asp:ListItem Text="Text Content" Value="Text Content" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="YouTube Video" Value="YouTube Video"></asp:ListItem>
                                        <asp:ListItem Text="Our Video" Value="Our Video"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvModuleType" runat="server" ControlToValidate="ddlModuleType" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Module type is required"></asp:RequiredFieldValidator>
                                </div>

                                <!-- Text Content Field (Visible by default) -->
                                <div class="col-lg-12 module-type-fields" id="textContentField">
                                    <label>Text Content<sup>*</sup></label>
                                    <asp:TextBox ID="txtTextContent" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" Rows="3" runat="server" placeholder="Enter text content"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTextContent" runat="server" ControlToValidate="txtTextContent" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Text content is required"></asp:RequiredFieldValidator>
                                </div>

                                <!-- Video Link Field (Hidden by default) -->
                                <div class="col-lg-12 module-type-fields" id="videoLinkField">
                                    <label>Video Link<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtVideoLink" placeholder="Enter video URL" MaxLength="500" />
                                    <asp:RequiredFieldValidator ID="rfvVideoLink" runat="server" ControlToValidate="txtVideoLink" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Video link is required"></asp:RequiredFieldValidator>
                                </div>

                                <!-- Full Description Field (Always visible) -->
                                <div class="col-lg-12">
                                    <label>Full Description<sup>*</sup></label>
                                    <asp:TextBox ID="txtFullDesc" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" Rows="5" runat="server" placeholder="Enter full description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFullDesc" runat="server" ControlToValidate="txtFullDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Full description is required"></asp:RequiredFieldValidator>
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
    <!--
   <script src="assets/js/pages/Modules.js"></script>

        -->
    <script>
    function toggleModuleFields() {
    var moduleType = document.getElementById('<%= ddlModuleType.ClientID %>').value;
    var textContentField = document.getElementById('textContentField');
    var videoLinkField = document.getElementById('videoLinkField');
    var textContentValidator = document.getElementById('<%= rfvTextContent.ClientID %>');
    var videoLinkValidator = document.getElementById('<%= rfvVideoLink.ClientID %>');

    // Hide all fields first
    if (textContentField) textContentField.style.display = 'none';
    if (videoLinkField) videoLinkField.style.display = 'none';

    // Disable validators first
    if (textContentValidator) textContentValidator.enabled = false;
    if (videoLinkValidator) videoLinkValidator.enabled = false;

    // Show relevant field based on module type
    if (moduleType === 'Text Content') {
            if (textContentField) textContentField.style.display = 'block';
    if (textContentValidator) textContentValidator.enabled = true;
        } else if (moduleType === 'YouTube Video' || moduleType === 'Our Video') {
            if (videoLinkField) videoLinkField.style.display = 'block';
    if (videoLinkValidator) videoLinkValidator.enabled = true;
        }
    }

    // Initialize on page load
    document.addEventListener('DOMContentLoaded', function () {
        toggleModuleFields();

    // Add event listener for module type change
    var moduleTypeDropdown = document.getElementById('<%= ddlModuleType.ClientID %>');
    if (moduleTypeDropdown) {
        moduleTypeDropdown.addEventListener('change', toggleModuleFields);
        }
    });

    // Also call when ASP.NET postback completes (for UpdatePanel support)
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function () {
        toggleModuleFields();

    // Re-attach event listener after postback
    var moduleTypeDropdown = document.getElementById('<%= ddlModuleType.ClientID %>');
    if (moduleTypeDropdown) {
        moduleTypeDropdown.addEventListener('change', toggleModuleFields);
        }
    });
</script>


</asp:Content>

<%@ Page Title="Med Research Ninja | Add New Job" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-new-job.aspx.cs" Inherits="Admin_add_new_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Job</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Career</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Job</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="container-fluid">

            <div class="row">
                <div class="col-lg-8">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add New" %> Job</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-2">
                                <div class="col-lg-4">
                                    <label>Select Job Type <sup class="text-danger">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlJobType" CssClass="form-select" AutoPostBack="true">
                                        <asp:ListItem Value="">Select Jobs/Internship</asp:ListItem>
                                        <asp:ListItem Text="Jobs" Value="Jobs"></asp:ListItem>
                                        <asp:ListItem Text="Internship" Value="Internship"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="req1" ErrorMessage="Please select one media type" ControlToValidate="ddlJobType" ValidationGroup="Save" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Job Title <sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 txtName" ID="txtName" placeholder="Enter Job Title" />
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Job URL <sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 txtUrl" ID="txtUrl" placeholder="Auto-Generated" />
                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtUrl" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Job Location<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtLocation" placeholder="Job Location" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLocation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Experience (In Years)<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtExp" placeholder="Experience (In Years)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExp" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label class="">Salary (In LPA) <sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 " ID="txtSalary" placeholder="Enter Salary (In LPA)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-12">
                                    <label class="">Job Responsibilities <sup>*</sup></label>
                                    <asp:TextBox runat="server" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" ID="txtResponsibilities" Placeholder="Enter Responsibilities   ....." />
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Job Requirements <sup>*</sup></label>
                                    <asp:TextBox runat="server" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" ID="txtRequirements" Placeholder="Enter Requirements ....." />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header">
                            <h5 class=" card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Seo Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-2">
                                <div class="col-lg-12">
                                    <label class="">Title</label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtPageTitle" placeholder="Page Title" />
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Meta Keys</label>
                                    <asp:TextBox ID="txtMetaKey" class="form-control mb-2 mr-sm-2" runat="server" placeholder="Meta Keys"></asp:TextBox>
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Meta Description</label>
                                    <asp:TextBox ID="txtMetaDesc" TextMode="MultiLine" class="form-control mb-2 mr-sm-2" Rows="3" runat="server" placeholder="Meta Description"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Other Details</h5>
                        </div>
                        <duv class="card-body">
                            <div class="row gy-2">
                                <div class="col-lg-12">
                                    <label class="">Posted On <sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 datepicker" ID="txtPostedOn" placeholder="Select Posted On Date" />
                                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtPostedOn" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Employment Type<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtEmpType" placeholder="Enter Employment Type" />
                                    <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtEmpType" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-lg-12">
                                    <label class="">Education<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtEducation" placeholder="Enter Education" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEducation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Industry Type<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtIndustryType" placeholder="Enter Industry Type" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIndustryType" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Role Category </label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtRoleCat" placeholder="Enter Role Category" />
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Functional Area</label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtFunctionalArea" placeholder="Enter Functional Area" />
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Key Skills <sup>*</sup></label>
                                    <asp:TextBox ID="txtKeySkills" class="form-control mb-2 mr-sm-2" Rows="3" runat="server" placeholder="Enter Key Skills"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtKeySkills" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label class="">Role <sup>*</sup></label>
                                    <asp:TextBox ID="txtRole" class="form-control mb-2 mr-sm-2" Rows="3" runat="server" placeholder="Enter Job Role" />
                                    <asp:RequiredFieldValidator ID="rfv56" runat="server" ControlToValidate="txtRole" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </duv>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="mb-3">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" Style="margin-top: 10px;" />
                        <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Job" OnClick="btnNew_Click" Style="margin-top: 10px;" />

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



            //validation 
            // No special characters, only alphanumeric (spaces allowed)
            $('.nospecial').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode;
                var $input = $(this);
                if (charCode != 32 && !String.fromCharCode(charCode).match(/^[a-zA-Z0-9]*$/g)) {
                    // Prevent special character input
                    return false;
                } else {
                    // Replace any non-alphanumeric characters
                    var val = $input.val();
                    val = val.replace(/[^a-zA-Z0-9 ]/g, "");  // Remove special characters
                    $input.val(val);
                }
            });
            // Only numeric characters
            $('.onlyNum').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode;
                var $input = $(this);
                if (String.fromCharCode(charCode).match(/[^0-9]/g)) {
                    // Prevent non-numeric input
                    return false;
                } else {
                    // Remove non-numeric characters already present
                    var val = $input.val();
                    val = val.replace(/[^0-9]/g, "");
                    $input.val(val);
                }
            });
            // Numbers with periods (decimal values)
            $('.numWPts').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode;
                var $input = $(this);
                if (String.fromCharCode(charCode).match(/[^0-9\.]/g)) {
                    // Prevent non-numeric and non-period input
                    return false;
                } else {
                    // Allow numeric and decimal point, but replace invalid characters
                    var val = $input.val();
                    val = val.replace(/[^0-9\.]/g, "");  // Remove any non-numeric, non-period characters
                    $input.val(val);
                }
            });
            // Only alphabetic characters and spaces
            $('.onlyAlpha').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode;
                var $input = $(this);
                if (!String.fromCharCode(charCode).match(/^[a-zA-Z\s]*$/g)) {
                    // Prevent non-alphabetic input
                    return false;
                } else {
                    // Replace any non-alphabetic characters
                    var val = $input.val();
                    val = val.replace(/[^a-zA-Z\s]/g, "");  // Remove any non-alphabetic characters
                    $input.val(val);
                }
            });


        });
    </script>
</asp:Content>




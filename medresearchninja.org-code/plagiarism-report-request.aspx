<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="plagiarism-report-request.aspx.cs" Inherits="plagiarism_report_request" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="js/intelinput/css/intlTelInput.min.css" rel="stylesheet" />
    <style>
        section.header-top-home11.bg-dark.pt10.pb10 {
            display: none !important;
        }

        a.header-logo.logo1 {
            position: relative;
            top: unset !important;
        }

        .header-logo img {
            width: 190px;
        }

        .badge-circle {
            background-color: #fff;
            color: #000;
            font-size: 12px;
            font-weight: bold;
            width: 20px;
            height: 20px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            position: absolute;
            top: 10px;
            right: 20px;
        }

        .new-block {
            display: block !important;
        }

        .new-join {
            display: none;
        }

        .new-profile {
            display: flex !important;
        }

        .mobile_menu_bar .right-side {
            display: flex;
        }

        .new-profile .btn {
            display: flex;
            align-items: center;
            gap: 1rem;
        }

            .new-profile .btn img {
                height: 36px;
                width: 36px;
            }

        .user-name span {
            line-height: 10px;
        }

        .new-head {
            height: 100px;
        }

        .dashboard__sidebar {
            margin-top: 0px;
            position: sticky;
            top: 0px;
        }

        .details h5 {
            font-family: "DM Sans", sans-serif;
        }

        .dashboard__main {
            margin-top: 0px;
            padding-left: 0px;
        }

        .bootstrap-select:not([class*=col-]):not([class*=form-control]):not(.input-group-btn) .btn, .bootstrap-select:not([class*=col-]):not([class*=form-control]):not(.input-group-btn) .btn-light {
            background-color: #fff;
            border-radius: 8px;
        }

        #lblStatus {
            font-size: 100px;
        }

        .form-control[type=file] {
            border-radius: 8px;
            border: 2px solid transparent;
            box-shadow: none;
            height: 53px;
            outline: 1px solid #E9E9E9;
            /* padding-left: 14px; */
            padding: 12px 20px;
        }

        .dashboard_sidebar_list .sidebar_list_item active {
            background: #222222;
        }

        @media (min-width:320px) and (max-width:767px) {
            .new-join {
                display: none;
            }

            .new-profile {
                display: flex !important;
            }
        }

        .pending-style.style6 {
            background-color: #F1FAFF;
            color: #00A3FF;
            /* width: 126px !important; */
            display: block;
        }

        .plagiarism-service {
            background: #f8f9fa;
            padding: 25px;
        }

        .feature-item {
            padding: 15px;
            background: white;
            border-radius: 6px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.05);
        }

            .feature-item p {
                margin-bottom: 0;
                line-height: 1.6;
            }

        .profile-section {
            background-color: #ffffff; /* white background */
            width: 100%; /* full width of sidebar */
            padding: 15px 20px;
            display: flex;
            align-items: center;
            border-radius: 10px; /* optional: remove if sidebar has rounded edges */
            box-shadow: 0 1px 4px rgba(0,0,0,0.1);
            margin-bottom: 15px; /* spacing between profile and menu items */
        }

        /* Make link inside clickable */
        .profile-btn {
            display: flex;
            align-items: center;
            width: 100%;
            text-decoration: none;
            color: #333;
        }

        /* Profile image */
        .profile-image {
            width: 50px;
            height: 50px;
            border-radius: 50%;
            overflow: hidden;
            margin-right: 12px;
            flex-shrink: 0;
        }

            .profile-image img {
                width: 100%;
                height: 100%;
                object-fit: cover;
            }

        /* User name and status */
        .user-name h6 {
            margin: 0;
            font-size: 16px;
            font-weight: 600;
        }

        .status {
            color: #ff7f3e;
            font-size: 14px;
        }

        /* Hover effect for profile */
        .profile-section:hover {
            background-color: #f8f8f8;
            cursor: pointer;
        }

        /* Optional: Responsive adjustments */
        @media (max-width: 768px) {
            .profile-section {
                padding: 12px 15px;
            }
               .plagiarism-service{
       padding:0px !important;
   }
            .profile-image {
                width: 40px;
                height: 40px;
                margin-right: 10px;
            }

            .user-name h6 {
                font-size: 14px;
            }

            .status {
                font-size: 12px;
            }
        }
        .pl-0{
            padding-left: 15px !important;
        }
    </style>
    <link href="js/snackbar/snackbar.min.css" rel="stylesheet" />
    <link href="js/sweetalert2/sweetalert2.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard_content_wrapper">
        <div class="dashboard dashboard_wrapper ">
            <div class="dashboard__sidebar d-none d-lg-block">
                <div class="dashboard_sidebar_list">
                    <div class="profile-section">
                        <a class="profile-btn" href="javascript:void(0);" data-bs-toggle="dropdown">
                            <div class="profile-image">
                                <%=StrUserImage %>
                            </div>
                            <div class="user-name">
                                <h6 class="mb-0 text-dark"><%=StrUserName %></h6>
                                <span class="status text-dark">Active</span>
                            </div>
                        </a>
                    </div>
                    <%--<p class="fz15 fw400 ff-heading pl30">Member Dashboard</p>--%>
                    <div class="sidebar_list_item">
                        <a href="general-information.aspx" class="items-center "><i class="flaticon-document mr10"></i>General Information</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="member-profile.aspx" class="items-center"><i class="flaticon-home mr10"></i>My Profile</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-projects.aspx" class="items-center"><i class="flaticon-like mr10"></i>My Projects</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="recent-projects.aspx" class="items-center "><i class="flaticon-document mr10"></i>Recent Projects</a>
                    </div>
                    <div class="sidebar_list_item position-relative">
                        <a href="my-payment.aspx" class="items-center "><i class="flaticon-receipt mr10"></i>Projects Due</a><%= strDues %>
                    </div>
             <div class="sidebar_list_item">
     <a href="plagiarism-report-request.aspx" class="items-center d-flex justify-content-between -is-active"><span><i class="fa-regular fa-copy mr10"></i> Plagiarism report request</span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="request-closed-access-article.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed-Access Article </span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="ninja-research-bot.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot</span>  <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
                    <div class="sidebar_list_item ">
                        <a href="my-discussion.aspx" class="items-center"><i class="flaticon-chat mr10"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center "><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a>
                    </div>

                    <hr class="bg-white">

                    <div class="sidebar_list_item">
                        <a href="change-password.aspx" class="items-center"><i class="flaticon-presentation mr10"></i>Change Password</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <asp:LinkButton class="items-center" ID="lnkLogout" runat="server" OnClick="btnLogout_Click"><i class="flaticon-logout mr10"></i>Logout</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="dashboard__main pl0-md">
                <div class="dashboard__content hover-bgc-color">

                    <div class="row">
                        <div class="col-xl-12">
                            <div class="dashboard_navigationbar d-block d-lg-none">
                                <div class="dropdown">
                                    <a onclick="myFunction()" class="dropbtn"><i class="fa fa-bars pr10"></i>Dashboard Navigation</a>
                                    <ul id="myDropdown" class="dropdown-content">
                                        <%-- <li>
                                            <p class="fz15 fw400 ff-heading mt30 pl30">Start</p>

                                        </li>--%>
                                        <li><a href="/general-information.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-document mr10"></i>General Information</a></li>
                                        <li><a href="/member-profile.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-home mr10"></i>My Profile</a></li>
                                        <li><a href="/my-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>My Projects</a></li>
                                        <li><a href="/recent-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>Recent Projects</a></li>
                                        <li><a href="/my-payment.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>Projects Due</a><%= strDues %></li>
                                            <li class="active"><a href="/plagiarism-report-request.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-copy mr10"></i>Plagiarism Report Request</span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>
                                            <li><a href="/request-closed-access-article.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed Access Article </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/> </a></li>
                                            <li><a href="/ninja-research-bot.aspx" contenteditable="false" class="d-flex justify-content-between align-items-center" style="cursor: pointer;"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>                                        <li><a href="/my-discussion.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>My Discussion</a></li>
                                        <li><a href="/my-blueprintrx.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a></li>
                                        <li><a href="/my-portfolio.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a></li>
                                        <li><a href="/change-password.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-presentation  mr10"></i>Change Password</a></li>

                                        <li>
                                            <asp:LinkButton ID="btnLogout" runat="server" class="items-center" OnClick="btnLogout_Click">
                                            <i class="flaticon-logout mr10"></i>Logout 
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h5 class="list-title fw-bold">Plagiarism Request </h5>
                                </div>

                                <div class="col-lg-12">
                                    <div class="plagiarism-service mt-4">
                                        <p class="mb-4">Maintain the highest standards of academic integrity with our upcoming plagiarism report service.</p>

                                        <div class="features-list">
                                            <div class="feature-item mb-3">
                                                <p>
                                                    <strong>● 1 Free Report / Month </strong>

                                                </p>
                                                <ul class="pl-0">
                                                    <li>Every MedResearch Ninja member can request 
                                                   one plagiarism check each month.</li>
                                                </ul>
                                            </div>

                                            <div class="feature-item mb-3">
                                                <p>
                                                    <strong>● Powered by iThenticate </strong>
                                                </p>
                                                <ul class="pl-0" >
                                                    <li>The same industry-leading tool trusted by top journals and publishers worldwide.</li>
                                                </ul>
                                               
                                            </div>

                                            <div class="feature-item mb-3">
                                                <p><strong>● Publication-Ready Confidence </strong> </p>
                                                    
                                                    <ul class="pl-0">
                                                        <li>Identify overlap, similarity indexes, and refine your work before journal submission or conference presentation.</li>
                                                    </ul>
                                            </div>
                                        </div>

                                        <p class="mt-4">
                                            By using the very software relied upon during peer review, you can ensure your work is as credible, original, and submission-ready as possible.
                                            <br />
                                            <strong>Launching soon</strong> — because your research deserves the same checks journals use.
                                        </p>
                                    </div>
                                </div>

                                <div class="col-lg-12 d-none">
                                    <asp:Label ID="lblStatus" runat="server" Visible="false" Width="100%"></asp:Label>
                                    <div class="form-style1">
                                        <div class="row">

                                            <div class="col-sm-6">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10">Name<sup class="text-danger">*</sup></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtName" placeholder="Enter Name" MaxLength="100" />
                                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="mb20 txtPhone">
                                                    <label class="heading-color ff-heading fw500 mb10" for="txtPhone">Phone No</label>
                                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" CssClass="form-control onlyNum" Style="padding-left: 85px;" placeholder="Phone No" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhone" ErrorMessage="Please Enter valid Phone number" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10" for="txtEmail">Email</label>
                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email ID" TextMode="Email" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter valid emailIdAdress" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10">First Author Name<sup class="text-danger">*</sup></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="TexFirstAuthorName" placeholder="Enter First Author Name " MaxLength="100" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TexFirstAuthorName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10">Title<sup class="text-danger">*</sup></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtTitle" placeholder="Enter current payment title" MaxLength="100" />
                                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>



                                            <div class="col-sm-6 d-none" id="pdfUploadSection">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10">Upload Pdf<sup class="text-danger">*</sup></label>
                                                    <asp:FileUpload ID="upldPdf" runat="server" ToolTip="Maxmimum 2 MB file size" CssClass="form-control"></asp:FileUpload>
                                                    <small class="text-danger">.pdf, .doc, .docx, .png, .jpg .jpeg formats are required</small><br />
                                                    <div id="divpdf" runat="server" visible="false">
                                                        <a href="/<%=strPdf %>" target="_blank">
                                                            <img src="images/pdf.png" alt="" width="65" height="60"></a><br />
                                                        Check PDF
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="col-sm-6 d-none" id="linkSection">
                                                <div class="mb20">
                                                    <label class="heading-color ff-heading fw500 mb10">Add Link<sup class="text-danger">*</sup> </label>
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtLink" placeholder="Enter resource link" MaxLength="200" />
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <div class="text-start">
                                                    <asp:LinkButton ID="btnPortfolio" runat="server" CssClass="ud-btn btn-thm " OnClick="btnPortfolio_Click" Text="Add Plagiarism request" ValidationGroup="Save">Add Plagiarism request <i class="fal fa-arrow-right-long"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="btnNew" CssClass="ud-btn btn-thm" Visible="false" Text="Add New Portfolio" OnClick="btnNew_Click">Add New Portfolio <i class="fal fa-arrow-right-long"></i></asp:LinkButton>
                                                    <asp:Label ID="lblpdf" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <asp:HiddenField ID="txtCCodeMob1" runat="server" />
    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/snackbar/snackbar.min.js"></script>
    <script src="js/sweetalert2/sweetalert2.all.min.js"></script>

    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/intelinput/js/intlTelInput.min.js"></script>
    <script>
        $(document).ready(function () {
            $(document).ready(function () {
                $('.onlyNum').keypress(function (e) {
                    var charCode = (e.which) ? e.which : event.keyCode
                    if (String.fromCharCode(charCode).match(/[^0-9]/g))
                        return false;
                    if ($(this).val().length > 12)
                        return false;

                });
            })
            var input = document.querySelector("#<%=txtPhone.ClientID %>");
            window.intlTelInput(input, { separateDialCode: true }).setNumber(($("#<%=txtCCodeMob1.ClientID %>").val() == "" ? "+91" : $("#<%=txtCCodeMob1.ClientID %>").val()) + $("#<%=txtPhone.ClientID%>").val());

            $('#<%=txtPhone.ClientID %>').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode
                if (String.fromCharCode(charCode).match(/[^0-9]/g))
                    return false;
            });
            $('#<%=txtPhone.ClientID %>').change(function () {
                $("#<%=txtCCodeMob1.ClientID %>").val($(".txtPhone .iti__selected-dial-code").html());
            });

        });
    </script>
</asp:Content>





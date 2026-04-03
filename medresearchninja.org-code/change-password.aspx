<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        section.header-top-home11.bg-dark.pt10.pb10 {
            display: none !important;
        }

        .badge-circle {
            background-color: #000 !important;
            color: #fff !important;
            font-size: 12px !important;
            font-weight: bold !important;
            width: 20px !important;
            height: 20px !important;
            border-radius: 50%;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
            position: absolute !important;
            top: 8px !important;
            right: 20px !important;
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

        a.header-logo.logo1 {
            position: relative;
            top: unset !important;
        }

        .new-block {
            display: block !important;
        }

        .header-logo img {
            width: 190px;
        }

        .new-head {
            height: 100px;
        }

        .dashboard__sidebar {
            margin-top: 0px;
            position: relative;
        }

        .dashboard__main {
            margin-top: 0px;
            padding-left: 0px;
        }

        .table-style3 .t-body th {
            padding: 20px;
        }

        .table-style3 .t-body td {
            padding: 20px;
        }

        .table-style3 .t-body td {
            padding: 20px;
        }

        .table-style3 .t-head th {
            width: 25%;
        }

            .table-style3 .t-head th:first-child {
                width: 32%;
            }



        .table-style3 .t-head th {
            font-weight: 600;
            padding: 20px;
        }

        .details h5 {
            font-weight: 600;
            font-size: 16px;
        }

        @media (min-width:320px) and (max-width:767px) {
            .new-join {
                display: none;
            }

            .new-profile {
                display: flex !important;
            }
        }

        .pwd_eye {
            position: absolute;
            top: 8px;
            right: 8px;
        }

        .btn-custom {
            background: #ff7f3e;
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
    </style>
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
                        <a href="general-information.aspx" class="items-center "><i class="flaticon-document mr15"></i>General Information</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="member-profile.aspx" class="items-center"><i class="flaticon-home mr15"></i>My Profile</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-projects.aspx" class="items-center"><i class="flaticon-like mr15"></i>My Projects</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="recent-projects.aspx" class="items-center "><i class="flaticon-document mr15"></i>Recent Projects</a>
                    </div>
                    <div class="sidebar_list_item position-relative">
                        <a href="my-payment.aspx" class="items-center "><i class="flaticon-receipt mr15"></i>Projects Due</a><%= strDues %>
                    </div>
                  <div class="sidebar_list_item">
     <a href="plagiarism-report-request.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-regular fa-copy mr10"></i> Plagiarism report request</span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="request-closed-access-article.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed-Access Article </span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="ninja-research-bot.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot</span>  <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
                    <div class="sidebar_list_item ">
                        <a href="my-discussion.aspx" class="items-center"><i class="flaticon-chat mr15"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center"><i class="flaticon-review-1 mr15"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center"><i class="flaticon-receipt mr15"></i>Build My Research Portfolio</a>
                    </div>

                    <hr class="bg-white">

                    <div class="sidebar_list_item">
                        <a href="change-password.aspx" class="items-center -is-active"><i class="flaticon-presentation mr15"></i>Change Password</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <asp:LinkButton class="items-center" ID="lnkLogout" runat="server" OnClick="btnLogout_Click"><i class="flaticon-logout mr15"></i>Logout</asp:LinkButton>
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
                                      <%--  <li>
                                            <p class="fz15 fw400 ff-heading mt30 pl30">Start</p>
                                        </li>--%>
                                        <li><a href="/general-information.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-document mr10"></i>General Information</a></li>
                                        <li><a href="/member-profile.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-home mr10"></i>My Profile</a></li>
                                        <li><a href="/my-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>My Projects</a></li>
                                        <li><a href="/recent-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>Recent Projects</a></li>
                                       
                                        <li><a href="/my-payment.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>Projects Due</a><%= strDues %></li>
                                                                                    <li><a href="/plagiarism-report-request.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-copy mr10"></i>Plagiarism Report Request</span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>
                                            <li><a href="/request-closed-access-article.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed Access Article </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/> </a></li>
                                            <li><a href="/ninja-research-bot.aspx" contenteditable="false" class="d-flex justify-content-between align-items-center" style="cursor: pointer;"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>
                                        <li><a href="/my-discussion.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>My Discussion</a></li>
                                        <li><a href="/my-blueprintrx.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a></li>
                                        <li><a href="/my-portfolio.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a></li>
                                        <li class="active"><a href="/change-password.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-presentation  mr10"></i>Change Password</a></li>

                                        <li>
                                            <asp:LinkButton ID="btnLogout" runat="server" class="items-center" OnClick="btnLogout_Click">
                                    <i class="flaticon-logout mr15"></i>Logout 
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h5 class="list-title fw-bold">Change Password</h5>
                                </div>

                                <div class="col-lg-12 gy-3">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:Label ID="lblStatus" runat="server" Visible="false" Width="100%"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-lg-5">
                                            <label class="form-label">Current Password<sup class="text-danger">*</sup></label>
                                            <div class="form-group position-relative">
                                                <asp:TextBox runat="server" ID="txtCurrent" CssClass="form-control password" autocomplete="new-password" placeholder="Current Password" TextMode="Password"></asp:TextBox>
                                                <a href="javascript:void(0);" class="pwd_eye showpwd d-none">
                                                    <img src="images/eye.svg" /></a>
                                                <a href="javascript:void(0);" class="pwd_eye hidepwd">
                                                    <img src="images/eye-slash.svg" /></a>
                                            </div>
                                            <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtCurrent" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-lg-5">
                                            <label class="form-label">New Password<sup class="text-danger">*</sup></label>
                                            <div class="form-group position-relative">
                                                <asp:TextBox runat="server" ID="txtNew" CssClass="form-control password" autocomplete="new-password" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                                <a href="javascript:void(0);" class="pwd_eye showpwd d-none">
                                                    <img src="images/eye.svg" /></a>
                                                <a href="javascript:void(0);" class="pwd_eye hidepwd">
                                                    <img src="images/eye-slash.svg" /></a>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNew" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="row mb-3">
                                        <div class="col-lg-5">
                                            <label class="form-label">Confirm Password<sup class="text-danger">*</sup></label>
                                            <div class="form-group position-relative">
                                                <asp:TextBox runat="server" ID="txtConfirm" CssClass="form-control password" autocomplete="new-password" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                                <a href="javascript:void(0);" class="pwd_eye showpwd d-none">
                                                    <img src="images/eye.svg" />
                                                </a>
                                                <a href="javascript:void(0);" class="pwd_eye hidepwd">
                                                    <img src="images/eye-slash.svg" />
                                                </a>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirm" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cmp1" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtNew" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Password doesn't match"> </asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="row">


                                        <div class="col-xxl-3 col-md-6">
                                            <div>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" CssClass="btn btn-custom text-light waves-effect waves-light m-t-25" />

                                            </div>
                                        </div>
                                        <!--end col-->
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
    <script src="js/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            // Handle show/hide password toggle
            $(".pwd_eye").on("click", function () {
                // Find the related input element
                var ele = $(this);
                var input = $(this).siblings("input.password");

                // Check if the input type is password
                if (input.attr("type") === "password") {
                    input.attr("type", "text"); // Change type to text
                    ele.siblings(".showpwd").removeClass("d-none"); // Show the eye icon
                    ele.addClass("d-none"); // Hide the eye-slash icon
                } else {
                    input.attr("type", "password"); // Change type to password
                    ele.addClass("d-none"); // Hide the eye icon
                    ele.siblings(".hidepwd").removeClass("d-none"); // Show the eye-slash icon
                }
            });
        });
    </script>
</asp:Content>


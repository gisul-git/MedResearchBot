<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="upcoming-modules.aspx.cs" Inherits="upcoming_modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        section.header-top-home11.bg-dark.pt10.pb10 {
            display: none !important;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard_content_wrapper">
        <div class="dashboard dashboard_wrapper ">
            <div class="dashboard__sidebar d-none d-lg-block">
                <div class="dashboard_sidebar_list">
                    <p class="fz15 fw400 ff-heading pl30">Member Dashboard</p>
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
                        <a href="my-payment.aspx" class="items-center "><i class="flaticon-receipt mr15"></i>Projects Due</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-discussion.aspx" class="items-center"><i class="flaticon-chat mr15"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center -is-active"><i class="flaticon-review-1 mr15"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center"><i class="flaticon-receipt mr15"></i>Build My Research Portfolio</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="change-password.aspx" class="items-center"><i class="flaticon-presentation mr15"></i>Change Password</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <asp:LinkButton class="items-center" ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"><i class="flaticon-logout mr15"></i>Logout</asp:LinkButton>
                    </div>

                </div>
            </div>
            <div class="dashboard__main pl0-md">
                <div class="dashboard__content hover-bgc-color">

                    <div class="row">
                        <div class="col-xl-12">
                            <div class="dashboard_navigationbar d-block d-lg-none">
                                <div class="dropdown">
                                    <a onclick="" class="dropbtn"><i class="fa fa-bars pr10"></i>Dashboard Navigation</a>
                                    <ul id="myDropdown" class="dropdown-content">
                                        <li>
                                            <p class="fz15 fw400 ff-heading mt30 pl30">Start</p>
                                        </li>
                                        <li><a href="/general-information.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-document mr10"></i>General Information</a></li>
                                        <li><a href="/member-profile.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-home mr10"></i>My Profile</a></li>
                                        <li><a href="/my-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>My Projects</a></li>
                                        <li><a href="/recent-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>Recent Projects</a></li>
                                        <li><a href="/my-payment.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>Projects Due</a></li>
                                        <li><a href="/my-discussion.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>My Discussion</a></li>
                                        <li class="active"><a href="/my-blueprintrx.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a></li>
                                        <li><a href="/my-portfolio.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a></li>
                                        <li><a href="/change-password.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-presentation  mr10"></i>Change Password</a></li>

                                        <li>
                                            <asp:LinkButton ID="btnLogout" runat="server" class="items-center" OnClick="btnLogout_Click">
<i class="flaticon-logout mr15"></i>Logout 
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h5 class="list-title fw-bold">Upcoming modules</h5>
                                </div>

                                <div class="col-lg-12">
                                    <h2>Coming Soon!</h2>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

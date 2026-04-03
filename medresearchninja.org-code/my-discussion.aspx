<%@ Page Title="" Language="C#" MasterPageFile="./User.master" AutoEventWireup="true" CodeFile="my-discussion.aspx.cs" Inherits="my_discussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        section.header-top-home11.bg-dark.pt10.pb10 {
            display: none !important;
        }

        .mobile_menu_bar .right-side {
            display: flex;
        }

        .header-logo img {
            width: 203px;
        }

        .new-block {
            display: block !important;
        }

        .new-head {
            height: unset !important;
        }

        a.header-logo.logo1 {
            top: -15px !important;
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

        .table-style3 .t-head th {
            width: auto;
        }

        .table-style3 .t-head th {
            font-weight: 600;
            padding: 20px;
        }

        .all-answers {
            margin-top: 20px;
        }

            .all-answers .title {
                font-size: 20px;
                font-weight: 500;
                margin-bottom: 0px;
            }

            .all-answers .forum-comment {
                background: #f1f1f1;
                padding: 20px;
                margin-bottom: 20px;
            }

        .forum-post-top {
            display: flex;
        }

            .forum-post-top .author-avatar img {
                border-radius: 50%;
                margin-right: 15px;
            }

            .forum-post-top .forum-post-author .author-name {
                font-size: 20px;
                font-weight: 500;
                color: #1d2746;
                padding: 2px 0px;
            }

            .forum-post-top .forum-post-author .forum-author-meta {
                display: flex;
                margin-top: 10px;
            }

        .comment-content p {
            overflow: hidden;
            display: -webkit-box;
            font-size: 14px;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
        }

        .all-answers .forum-comment {
            background: #fff;
            padding: 20px;
            box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
            margin-bottom: 20px;
        }

        .forum-post-author {
            width: 100%;
        }

        .title:hover p {
            color: #ffc107;
        }

        .all-answers .forum-comment .comment-content {
            margin-left: 0px;
            margin-top: 10px;
        }

        .all-answers .pagination-wrapper {
            background: transparent;
            box-shadow: none;
            margin-top: 15px;
        }

        .forum-post-author .title {
            border-bottom: 1px solid #000;
            width: 100%;
            padding: 10px 0px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .details h5 {
            font-weight: 600;
            font-size: 16px;
        }

        .opacity-50 {
            opacity: 50%;
            pointer-events: none;
            user-select: auto;
        }

        @media (min-width: 768px) and (max-width: 991px) {
            .new-profile .btn {
                margin-top: 20px !important;
            }
        }

        @media (min-width: 320px) and (max-width: 767px) {
            .new-profile .btn {
                margin-top: 20px !important;
            }
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
     <a href="plagiarism-report-request.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-regular fa-copy mr10"></i> Plagiarism report request</span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="request-closed-access-article.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed-Access Article </span> <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
 <div class="sidebar_list_item">
     <a href="ninja-research-bot.aspx" class="items-center d-flex justify-content-between"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot</span>  <img src="images/upcoming/sign.png" class="" width="25"/></a>
 </div>
                    <div class="sidebar_list_item ">
                        <a href="my-discussion.aspx" class="items-center -is-active"><i class="flaticon-chat mr10"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a>
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
                                            <li><a href="/ninja-research-bot.aspx" contenteditable="false" class="d-flex justify-content-between align-items-center" style="cursor: pointer;"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>                                        <li class="active"><a href="/my-discussion.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>My Discussion</a></li>
                                        <li><a href="/my-blueprintrx.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a></li>
                                        <li><a href="/my-portfolio.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a></li>
                                        <li><a href="/change-password.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-presentation  mr10"></i>Change Password</a></li>

                                        <li>
                                            <asp:LinkButton ID="btnLogout" runat="server" class="items-center" OnClick="btnLogout_Click">
                                            <i class="flaticon-logout mr10"></i>Logout</asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h5 class="list-title fw-bold">My Posts</h5>
                                </div>
                                <div class="col-lg-12">
                                    <div class="  position-relative">
                                        <div class="packages_table table-responsive">
                                            <table class="table-style3 table at-savesearch">
                                                <thead class="t-head">
                                                    <tr>
                                                        <th scope="col">Question</th>

                                                        <th scope="col">AddedOn</th>
                                                        <th scope="col">Status</th>
                                                        <th scope="col">Link</th>
                                                    </tr>
                                                </thead>
                                                <tbody class="t-body">
                                                    <%=strPosts %>
                                                </tbody>
                                            </table>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h5 class="list-title fw-bold">My Comments</h5>
                                </div>
                                <div class="col-lg-12">
                                    <div class="  position-relative">
                                        <div class="packages_table table-responsive">
                                            <table class="table-style3 table at-savesearch">
                                                <thead class="t-head">
                                                    <tr>
                                                        <th scope="col">Comment</th>

                                                        <th scope="col">AddedOn</th>
                                                        <th scope="col">Status</th>
                                                        <th scope="col">Link</th>
                                                    </tr>
                                                </thead>
                                                <tbody class="t-body">
                                                    <%=strComments %>
                                                </tbody>
                                            </table>

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
</asp:Content>


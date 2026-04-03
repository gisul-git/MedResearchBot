<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="recent-projects.aspx.cs" Inherits="recent_projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        section.header-top-home11.bg-dark.pt10.pb10 {
            display: none !important;
        }

        .header-logo img {
            width: 203px;
        }

        .new-head {
            height: unset !important;
        }

        a.header-logo.logo1 {
            top: -15px !important;
        }

        .modal-body {
            position: relative;
            flex: 1 1 auto;
            padding: 1rem;
            height: 500px;
            overflow: scroll;
        }

        .details h5 {
            font-weight: 600;
            font-size: 16px;
        }

        .new-block {
            display: block !important;
        }

        .dashboard__sidebar {
            margin-top: 0px;
            position: relative;
        }

        .details h5 {
            font-family: "DM Sans", sans-serif;
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
            width: 40%;
        }

        .table-style3 .t-head th {
            font-weight: 600;
            padding: 20px;
        }

        .details h5 {
            margin-bottom: 0px;
        }

        .new-flex-project {
            display: flex;
            justify-content: space-between;
            align-items: start;
        }

        @media (min-width:320px) and (max-width:767px) {
            .new-flex-project {
                display: flex;
                flex-direction: column;
                justify-content: start !important;
                align-items: start !important;
                gap: 1rem;
            }

            .p30 {
                padding: 30px 10px !important;
            }

            .bdr1 {
                border: 1px solid #e9e9e9 !important;
                padding: 20px 10px;
            }

            .toggle-button {
                cursor: pointer;
                background-color: #000;
                color: white;
                border: none;
                padding: 0px 10px !important;
                border-radius: 5px;
                font-size: 12px !important;
            }

            .review.mb5 {
                width: 100% !important;
            }

            .pending-style.style1 {
                margin-bottom: 0px !important;
            }

            .new-profile .btn {
                margin-top: 20px !important;
            }

            .skill-tags {
                flex-direction: column;
                gap: 1rem;
            }
        }

        @media (min-width:992px) and (max-width:1199px) {
            .ps-widget h5 {
                font-size: 22px;
                width: 85%;
            }
        }

        @media (min-width:767px) and (max-width:991px) {
            .skill-tags a {
                width: 25%;
            }

            .new-flex-project {
                gap: 1rem;
                flex-direction: column;
            }

            .new-profile .btn {
                margin-top: 20px !important;
            }
        }

        @media (min-width:1200px) and (max-width:1300px) {
            .review.mb5 {
                width: 30%;
                text-align: center;
            }
        }

        @media (min-width:1300px) and (max-width:1400px) {
        }

        .review.mb5 {
            text-align: center;
            width: 30%;
        }

        .new-flex-tags {
            display: flex;
            justify-content: start;
            gap: 1rem;
            flex-wrap: wrap;
        }

        @media (min-width: 320px) and (max-width: 767px) {
            .ps-widget h5 {
                font-size: 15px;
                white-space: unset !important;
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
    <style>
        .new-dec {
            max-height: 150px;
            overflow: hidden;
            transition: max-height 0.3s ease;
            margin-bottom: 10px;
        }

            .new-dec.expanded {
                max-height: 100%; /* Adjust this as needed for the content's full height */
            }

        .toggle-button {
            cursor: pointer;
            background-color: #000;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 5px;
            font-size: 14px;
            display: block;
            width: max-content;
            margin: 10px 0px;
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
                        <a href="member-profile.aspx" class="items-center "><i class="flaticon-document mr10"></i>General Information</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="member-profile.aspx" class="items-center"><i class="flaticon-home mr10"></i>My Profile</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-projects.aspx" class="items-center"><i class="flaticon-like mr10"></i>My Projects</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="recent-projects.aspx" class="items-center -is-active"><i class="flaticon-document mr10"></i>Recent Projects</a>
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
                        <a href="my-discussion.aspx" class="items-center"><i class="flaticon-chat mr10"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a>
                    </div>

                    <hr class="bg-white">

                    <div class="sidebar_list_item">
                        <a href="/change-password.aspx" class="items-center"><i class="flaticon-presentation mr10"></i>Change Password</a>
                    </div>
                    <div class="sidebar_list_item">
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
                                        <li class="active"><a href="/recent-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>Recent Projects</a></li>
                                        <li><a href="/my-payment.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>Projects Due</a><%= strDues %></li>
                                            <li><a href="/plagiarism-report-request.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-copy mr10"></i>Plagiarism Report Request</span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>
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
                                    <h5 class="list-title fw-bold">Recent Projects</h5>
                                </div>
                                <%=strProjects %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="OverviewModal" tabindex="-1" aria-labelledby="OverviewModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="OverviewModalLabel">Project Overview</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body modalbody">
                    ...
                </div>

            </div>
        </div>
    </div>
    <script src="/js/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on('click', '.btnPurchase', function () {
                var projectGuid = $(this).data('id'); //  ProjectGuid from data-id

                $.ajax({
                    type: "POST",
                    url: "recent-projects.aspx/BuyProject",
                    data: JSON.stringify({ projectGuid: projectGuid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d.split('|')[0] == "Success") {
                            window.location.href = "pay-for-project.aspx?order=" + response.d.split('|')[1];
                        }
                        else if (response.d === "Paid") {
                            window.location.href = "My-projects.aspx";
                        } else {
                        }
                    },
                    error: function (xhr, status, error) {
                        alert("Error: " + error);
                    }

                });
            });


            $(document).on('click', '.btnoverview', function () {

                var id = $(this).attr('data-id'); // id from data-id
                var Msg = $(this).attr('data-msg'); // Msg from data-msg

                $(".modalbody").html(Msg);


            })
        });
    </script>

</asp:Content>


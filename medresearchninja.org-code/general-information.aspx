<%@ Page Title="" Language="C#" MasterPageFile="./User.master" AutoEventWireup="true" CodeFile="general-information.aspx.cs" Inherits="general_information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        header.nav-homepage-style {
            margin-right: 0px;
            padding: 0px 0px;
        }

        .new-head {
            height: 100px;
        }

        .dashboard__sidebar {
            margin-top: 0px;
            position: relative;
        }

        .new-block {
            display: block !important;
        }

        .dashboard__main {
            margin-top: 0px;
            padding-left: 0px;
        }

        input[type="file"] {
            background: #f1f1f1;
            padding: 2px 10px;
        }

        @media (min-width:320px) and (max-width:767px) {
            .new-join {
                display: none;
            }

            .new-profile {
                display: flex !important;
            }
        }

        @media (min-width:768px) and (max-width:911px) {
            .new-join {
                display: none;
            }

            .new-profile {
                display: flex !important;
            }
        }

        @media (min-width:767px) and (max-width:991px) {
            label.heading-color.ff-heading.fw500.mb10 {
                font-size: 12px;
            }
        }

        @media (min-width:992px) and (max-width:1199pxs) {
            label.heading-color.ff-heading.fw500.mb10 {
                font-size: 12px;
            }
        }

        @media (min-width:320px) and (max-width:767px) {
            .new-join {
                display: none;
            }

            .new-profile {
                display: flex !important;
            }

            label.heading-color.ff-heading.fw500.mb10 {
                font-size: 12px;
            }
        }

        .table-container {
            margin: 20px 0;
            border: 1px solid #ddd;
            border-collapse: collapse;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            color: #000;
            text-align: left;
        }

        th {
            background-color: #f4f4f4;
        }

        ul {
            margin: 10px 0;
            padding-left: 20px;
        }

        p {
            color: #000;
        }

        li {
            color: #000;
        }

        /* Sidebar container */
        .dashboard_sidebar_list .new-block {
            width: 100%;
        }

        /* Profile section styling */
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
                    <%--<h2 class=" ">ResearchHub </h2>--%>
                    <%--<div class="col-auto col-lg-auto new-block">--%>
                    <%-- <div class="text-center text-lg-end header_right_widgets">
                            <ul class="dashboard_dd_menu_list d-flex align-items-center justify-content-center justify-content-sm-end mb-0 p-0">

                                <li class="user_setting">
                                    <div class="dropdown">
                                     

                                    </div>
                                </li>
                            </ul>
                        </div>--%>
                    <%-- <div class=" profile-section">
                            <a class="btn" href="javascript:void(0);" data-bs-toggle="dropdown">
                                <%=StrUserImage %>
                                <div class="user-name">
                                    <h6 class="mb0"><%=StrUserName %></h6>
                                    <span class="" style="color: #ff7f3e">Active</span>
                                </div>
                            </a>
                        </div>--%>
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

                    <div class="sidebar_list_item">
                        <a href="member-profile.aspx" class="items-center -is-active"><i class="flaticon-document mr10"></i>General Information</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="member-profile.aspx" class="items-center -"><i class="flaticon-home mr10"></i>My Profile</a>
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
                        <a href="my-discussion.aspx" class="items-center"><i class="flaticon-chat mr10"></i>My Discussion</a>
                    </div>
                    <div class="sidebar_list_item ">
                        <a href="my-blueprintrx.aspx" class="items-center"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a>
                    </div>
                    <div class="sidebar_list_item">
                        <a href="my-portfolio.aspx" class="items-center"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a>
                    </div>

                    <hr class="bg-white" />
                    <div class="sidebar_list_item">
                        <a href="change-password.aspx" class="items-center"><i class="flaticon-presentation mr10"></i>Change Password</a>
                    </div>
                    <div class="sidebar_list_item">
                        <asp:LinkButton ID="btnLogout" runat="server" class="items-center" OnClick="btnLogout_Click">
                    <i class="flaticon-logout mr10"></i>Logout 
                        </asp:LinkButton>
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
                                        <%--<li>
                                            <p class="fz15 fw400 ff-heading mt30 pl30">Start</p>
                                        </li>--%>
                                        <li class="active"><a href="/general-information.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-document mr10"></i>General Information</a></li>
                                        <li><a href="/member-profile.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-home mr10"></i>My Profile</a></li>
                                        <li><a href="/my-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>My Projects</a></li>
                                        <li><a href="/recent-projects.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>Recent Projects</a></li>
                                        <li><a href="/my-payment.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>Projects Due</a><%= strDues %></li>
                                            <li><a href="/plagiarism-report-request.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-copy mr10"></i>Plagiarism Report Request</span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>
                                            <li><a href="/request-closed-access-article.aspx" class="d-flex justify-content-between align-items-center" contenteditable="false" style="cursor: pointer;"><span><i class="fa-regular fa-folder-open mr10"></i>Request Closed Access Article </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/> </a></li>
                                            <li><a href="/ninja-research-bot.aspx" contenteditable="false" class="d-flex justify-content-between align-items-center" style="cursor: pointer;"><span><i class="fa-solid fa-robot mr10"></i>Ninja Research Bot </span> <img src="images/upcoming/sign.png" class="" width="25" height="25"/></a></li>                                        <li><a href="/my-discussion.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-chat mr10"></i>My Discussion</a></li>
                                        <li><a href="/my-blueprintrx.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-review-1 mr10"></i>My BlueprintRX</a></li>
                                        <li><a href="/my-portfolio.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-receipt mr10"></i>Build My Research Portfolio</a></li>
                                        <li><a href="/change-password.aspx" contenteditable="false" style="cursor: pointer;"><i class="flaticon-presentation  mr10"></i>Change Password</a></li>


                                        <li>
                                            <asp:LinkButton ID="LinkButton1" runat="server" class="items-center" OnClick="btnLogout_Click">
<i class="flaticon-logout mr10"></i>Logout 
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="ps-widget position-relative">
                                <div class="bdrb1 pb15 mb25">
                                    <h3 class=" fw-bold">General Information</h3>
                                </div>
                                <div class="">
                                    <div class="bdrb1 pb15 mb25">
                                        <h5 class="">Enrollment Steps
                                        </h5>
                                    </div>

                                    <h4>1. Submit the Enrollment Fee</h4>
                                    <p>Begin by submitting the base enrollment fee. This is a mandatory step to officially confirm your participation in the project.</p>

                                    <h4>2. Dashboard Access</h4>
                                    <p>Once your payment is verified, you'll gain access to your personal dashboard on our website. The dashboard will serve as your central hub for project resources, updates, and access to the community.</p>

                                    <h4>3. Join the WhatsApp Group</h4>
                                    <p>Through your dashboard, you'll find a link to join the project's dedicated WhatsApp group. This group is where all project members connect, share updates, and receive support. It’s a great way to stay informed and engaged with the team.</p>

                                    <h4>4. Welcome Message & Resources</h4>
                                    <p>Upon joining the WhatsApp group, expect a welcome message from the project coordinator. The message may include key project guidelines, introductory resources, or other initial tasks to help you get started smoothly.</p>

                                    <h4>5. Next Steps and Project Updates</h4>
                                    <p>Moving forward, you'll receive regular updates and announcements both via WhatsApp and on your dashboard. Any additional resources, project milestones, and deadlines will be shared here.</p>
                                </div>
                                <hr />
                                <div class="">
                                    <div class="bdrb1 pb15 mb25">
                                        <h3 class="mb-3">Team Member Guidelines 
                                        </h3>
                                    </div>
                                    <p>Welcome to the team! This guide outlines the essential expectations and guidelines to ensure our research project runs smoothly, effectively, and in a positive, collaborative environment. Please read through each section carefully to understand your responsibilities.</p>

                                    <h4>1. Reaching Out to Mentors</h4>
                                    <ul>
                                        <li>Team members are encouraged to reach out to mentors for guidance on research tools, data analysis techniques, and advanced methodologies.</li>
                                        <li>For premium research-related tools (e.g., SPSS, STATA, NVivo), members may contact mentors or project leads to discuss potential access or licensing support.</li>
                                    </ul>

                                    <h4>2. Meeting Attendance</h4>
                                    <ul>
                                        <li><strong>Regular Attendance:</strong> Members are expected to attend all scheduled meetings to ensure seamless project progress and team coordination.</li>
                                        <li><strong>Absences:</strong> Missing more than two meetings without prior notice may result in removal from the team. Exceptions may be granted for significant reasons but must be communicated as early as possible.</li>
                                        <li><strong>Meeting Preparedness:</strong> Each member should come prepared, having reviewed assigned tasks or literature, and be ready to contribute to discussions and decisions.</li>
                                    </ul>

                                    <h4>3. Project Timeline</h4>
                                    <ul>
                                        <li><strong>Timeline Adherence:</strong> Each phase of the project has a set timeline. Adhering to these deadlines ensures we maintain progress and avoid delays in submission.</li>
                                        <li><strong>Checkpoints and Progress Reviews:</strong> There will be regular progress reviews to ensure everyone is on track. Be prepared to discuss your contributions and any challenges you’re facing.</li>
                                        <li><strong>Buffer Periods:</strong> The timeline includes buffer periods before key deadlines. Utilize this time to review, refine, or finalize sections to meet project standards.</li>
                                        <li><strong>Transparent Calendar:</strong> A shared calendar or project management tool will be used, making each phase, checkpoint, and deadline visible to all team members for alignment and accountability.</li>
                                    </ul>

                                    <h4>4. Journal Selection</h4>
                                    <ul>
                                        <li><strong>Early Journal Identification:</strong> We’ll decide on a target journal early in the project to align our work with the journal’s requirements, including structure, word count, and style.</li>
                                        <li><strong>Backup Journals:</strong> In case of rejection, we’ll have backup journals identified to keep publication timelines on track.</li>
                                        <li><strong>Adhering to Journal Guidelines:</strong> Familiarize yourself with the target journal’s specific guidelines to ensure all submissions (like figures, tables, and citations) meet standards.</li>
                                    </ul>

                                    <h4>5. Authorship Scoring Table</h4>
                                    <p>Authorship will be determined based on contributions using the following scoring criteria. Higher scores will correlate with more prominent authorship positions.</p>

                                    <div class="table-container">
                                        <div class="table-responsive">

                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>Criteria</th>
                                                        <th>Points</th>
                                                        <th>Description</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>Idea/Concept Development</td>
                                                        <td>15</td>
                                                        <td>Contributions to formulating the project’s research question, hypothesis, or primary concept</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Literature Review</td>
                                                        <td>10</td>
                                                        <td>Compiling and synthesizing relevant studies that inform the research</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Methodology Design</td>
                                                        <td>15</td>
                                                        <td>Developing or adapting study methodologies, protocols, and data collection strategies</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Data Collection</td>
                                                        <td>20</td>
                                                        <td>Responsible for collecting data, whether through experiments, surveys, or other means</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Data Analysis</td>
                                                        <td>20</td>
                                                        <td>Conducting statistical analysis, model building, or interpretation of results</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Manuscript Drafting</td>
                                                        <td>10</td>
                                                        <td>Writing and structuring the manuscript, including sections like introduction, methods, and discussion</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Editing and Revisions</td>
                                                        <td>5</td>
                                                        <td>Major revisions, formatting, and ensuring adherence to journal requirements</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Funding and Resources Acquisition</td>
                                                        <td>5</td>
                                                        <td>Securing funding or resources necessary for the project</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Project Coordination</td>
                                                        <td>5</td>
                                                        <td>Managing project timelines, meetings, and coordinating team member contributions</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Final Approval</td>
                                                        <td>5</td>
                                                        <td>Reviewing and providing the final approval on the manuscript and author list</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <ul>
                                        <li><strong>Authorship Order Determination:</strong> Scores will be tallied, and authorship order will follow from highest to lowest contributor. Final order will consider both points and critical contributions that align with the authorship guidelines of the chosen journal.</li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>


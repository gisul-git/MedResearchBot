<%@ Page Title="Application" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="apply-job.aspx.cs" Inherits="apply_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .breadcumb-style1 .breadcumb-list a {
            color: #000;
        }

            .breadcumb-style1 .breadcumb-list a:last-child {
                color: #000;
            }

        .breadcumb-section {
            background: #f1f1f1;
        }

        .inv {
            filter: invert(1);
        }

        .job-list-style1 h5 {
            font-size: 22px;
            margin-bottom: 10px;
        }

        ..accordion-style1 .accordion-button {
            margin-bottom: 0px;
        }

        .accordion-style1 .accordion-button {
            padding: 15px 20px !important;
        }

        .accordion-style1 .accordion-button {
            box-shadow: none !important;
            border-radius: 0px !important;
            border-bottom: 2px solid #ff7f3e;
        }

        .accordion-style1 .accordion-body {
            padding: 15px 30px 15px 30px;
        }

        .accordion-style1 .accordion-body {
            background: #f1f1f1;
        }

        .list-style1 li {
            margin-bottom: 10px;
        }


        .new-contact {
            border: 1px solid #ebf0f6;
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
            padding: 30px 20px;
            border-radius: 5px;
        }


        .other-details {
            margin-top: 20px;
        }

        .details.details-new {
            border-bottom: 1px solid #e5e2e2;
            padding: 10px;
            display: flex;
        }

            .details.details-new label {
                width: 30%;
                font-weight: 600;
                color: #000;
            }

            .details.details-new span {
                width: 70%;
                color: #000;
            }

        .details.details-new {
            border-bottom: 1px solid #e5e2e2;
            padding: 10px;
            display: flex;
        }

        .form-select {
            line-height: 46px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="breadcumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcumb-style1">
                        <div class="breadcumb-list">
                            <a href="/Default.aspx">Home</a>
                            <a href="/job-listing.aspx">Career</a>

                            <a href="#">Career  Details</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-7">
                    <div class="career-detail-left">
                        <div class="job-desc">
                            <div class="wow fadeInLeft animated" data-wow-delay="100ms" data-wow-duration="1000ms" style="visibility: visible; animation-duration: 1000ms; animation-delay: 100ms; animation-name: fadeInLeft;">
                                <h2>Job Description</h2>
                                <div class="other-details">
                                    <div class="details details-new">
                                        <label>Key Skills</label><span><%=strKeySkills %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Role</label><span><%=strRole %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Industry Type</label><span><%=strIndustryType %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Functional Area</label><span><%=strFunctionalArea %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Employment Type</label><span><%=strEmploymentType %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Role Category</label><span><%=strRoleCategory %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Education</label><span><%=strKeySkills %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Experience</label><span><%=strExperienceYears %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Salary</label><span><%=strSalaryLPA %></span>

                                    </div>
                                    <div class="details details-new">
                                        <label>Job Location</label><span><%=strJobLocation %></span>

                                    </div>
                                </div>
                            </div>
                            <div class="job-res-sec wow fadeInLeft" data-wow-delay="100ms" data-wow-duration="1200ms" style="visibility: hidden; animation-duration: 1200ms; animation-delay: 100ms; animation-name: none;">
                                <div class="list-style1 mt30 p-2">
                                    <h3 class="mb20">Responsibility</h3>

                                    <%=strJobResponsibilities %>
                                </div>
                            </div>
                            <div class="job-req-sec wow fadeInLeft" data-wow-delay="100ms" data-wow-duration="1400ms" style="visibility: hidden; animation-duration: 1400ms; animation-delay: 100ms; animation-name: none;">
                                <div class="list-style1 mt20 p-2">
                                    <h3 class="mb20">Qualifications</h3>


                                    <%=strRequirements %>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="col-lg-4 offset-lg-1">
                    <div class="new-contact text-black">
                        <h3 class="mb10 text-center  mb20">Apply For This Job
                        </h3>
                        <asp:Label ID="lblStatus" runat="server" Text="" visible="false"></asp:Label>
                        <div class="mb25">
                            <asp:TextBox ID="txtFullName" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Full Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFullName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtEmailId" runat="server" MaxLength="100" class="form-control" placeholder="Email Id"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtEmailId" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmailId" ErrorMessage="Please Enter valid EmailId" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtContactNumber" runat="server" MaxLength="15" class="form-control" placeholder="Contact Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtContactNumber" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Please Enter valid contact number" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtExperience" runat="server" MaxLength="100" class="form-control" placeholder="Experience"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtExperience" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtLocation" runat="server" MaxLength="100" class="form-control" placeholder="Location"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtLocation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtExpectedSalary" runat="server" class="form-control" MaxLength="10" placeholder="Expected Salary"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txtExpectedSalary" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:TextBox ID="txtCurrentSalary" runat="server" class="form-control" MaxLength="10" placeholder="Current Salary"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvf7" runat="server" ControlToValidate="txtCurrentSalary" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:DropDownList ID="ddlJobType" runat="server" class="form-select" aria-label="Default select example">
                                <asp:ListItem Value="">Job Type</asp:ListItem>
                                <asp:ListItem Value="Full Time">Full Time</asp:ListItem>
                                <asp:ListItem Value="Internship">Internship</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="ddlJobType" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Please select Notice Period"></asp:RequiredFieldValidator>

                        </div>
                        <div class="mb25">
                            <asp:DropDownList ID="ddlNoticePeriod" runat="server" class="form-select" aria-label="Default select example">
                                <asp:ListItem Value="">Notice Peroid</asp:ListItem>
                                <asp:ListItem Value="30 Days">30 Days</asp:ListItem>
                                <asp:ListItem Value="2 Months">2 Months</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv9" runat="server" ControlToValidate="ddlNoticePeriod" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Please select Notice Period"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb15">
                            <label for="formFile" class="form-label">Upload Your Resume</label>
                            <asp:FileUpload ID="UploadResume" runat="server" ToolTip="Maxmimum 1 MB file size"></asp:FileUpload><br />
                            <small class="text-danger">.pdf, .doc, .docx, formats are required</small><br />
                        </div>
                        <div class="d-grid mb20">
                           <a><asp:LinkButton  class="ud-btn btn-thm default-box-shadow2" ID="btnsubmit" runat="server" Text="Apply Now" OnClick="btnsubmit_Click" ValidationGroup="Save">Apply Now<i class="fal fa-arrow-right-long"></i></asp:LinkButton></a>
                            <asp:Label ID="lblResume" runat="server" Visible="false"></asp:Label>
                            <asp:HiddenField ID="txtJobId" runat="server" />
                            <asp:HiddenField ID="txtJobTitle" runat="server" />
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>


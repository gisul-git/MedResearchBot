<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="js/intelinput/css/intlTelInput.min.css" rel="stylesheet" />
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }


        .breadcumb-section {
            padding: 0px 0px;
        }

        .logos.me-4 {
            position: absolute;
        }


        .new-li {
            display: flex;
            gap: 1rem;
            padding-left: 0px;
            justify-content: start;
        }

        .new0bg {
            background-color: #ff7f3e;
        }

        .new-color {
            color: #ff7f3e;
        }

        .new-contact {
            padding: 40px;
        }

        .ud-btn i {
            margin-left: 10px;
            font-size: 16px;
            transform: unset !important;
        }


        .our-register {
            background: #f1f1f1;
            background-size: cover;
            background-position: center;
        }

        .side-img {
            height: 680px;
            width: 100%;
            overflow: hidden;
        }

            .side-img img {
                height: 100%;
                width: 100%;
                object-fit: cover
            }

        .breadcumb-style1 .breadcumb-list a {
            color: #000;
        }

            .breadcumb-style1 .breadcumb-list a:last-child {
                color: #000;
            }

        .breadcumb-section {
            background: #f1f1f1;
        }

        .High-light {
            margin-top: 20px;
            margin-bottom: 20px;
            border: 1px solid #ebf0f6;
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
            border-radius: 5px;
            border: 2px dashed #ff7f3e;
            background: #fff;
            padding: 10px 20px;
        }

            .High-light p {
                margin-bottom: 0px;
                color: #000;
                font-weight: 600;
                font-size: 18px;
            }

        .member-form {
            border: 1px solid #ebf0f6;
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
            border-radius: 5px;
            border: 2px dashed #ff7f3e;
            background: #fff;
            position: sticky;
            top: 0px;
        }

        .iconbox-style1 {
            padding: 20px 30px;
        }

        .list-style1 li {
            line-height: 20px !important;
        }

        .ui-content {
            margin-bottom: 0px;
        }

        .list-style1 h2 {
            font-size: 20px;
            margin-bottom: 20px;
        }

        .new-hei {
            height: 500px;
            overflow: scroll;
        }

        @media (min-width: 992px) and (max-width: 1300px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }
        }

        @media (min-width: 1300px) and (max-width: 1400px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }
        }

        @media (min-width: 768px) and (max-width: 991px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }
        }
        
        @media (min-width: 768px) and (max-width: 991px) {
           
              .list-style1 li{
      display:block !important;
  }
        }
          @media (min-width: 320px) and (max-width: 767px) {
   .list-style1 li{
       display:block !important;
   }
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
                            <a href="Default.aspx">Home</a>
                            <a href="#">Become a Member </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding">
        <div class="container">

            <div class="row align-items-center wow fadeInUp mt20" style="visibility: visible; animation-name: fadeInUp;">
                <div class="col-md-8 col-xl-6">
                    <div class="main-title">

                        <h2 class="title">Welcome to the <span class="new-color">MedResearch Ninja</span> </h2>
                        <p class="paragraph">
                            We’re excited to have you here! MedResearch Ninja is a welcoming community where students, early-career researchers, and healthcare professionals come together to learn, collaborate, and grow in the field of medical research.                       
                        </p>
                        <p class="paragraph">
                            Our goal is to support you through every step of the research process, from developing ideas to publishing your work. With 100+ publications across a range of topics, our community is full of opportunities to get involved, whether you're interested in original research, case studies, or reviews. 
                        </p>
                        <p class="paragraph">
                            As a member, you’ll be part of a network that values teamwork and hands-on experience. We connect you with mentors and resources, giving you the chance to build skills, contribute to projects, and see your work in reputable journals—all while being actively involved in the research process. 
                        </p>
                        <p class="paragraph">Join us to explore, learn, and make your mark in medical research!</p>
                    </div>
                </div>
                <div class="col-md-4 col-xl-3 offset-xl-2">
                    <div class="text-center mt30-sm">
                        <img class="w-100 bdrs4" src="new-img/loyalty.png" alt="">
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding bg-light">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 order-lg-0 order-1">



                    <div class="row align-items-center wow fadeInUp" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">
                        <div class="col-lg-12">
                            <div class="main-title2">
                                <h2 class="title">Membership Benefits of MedResearch Ninja    </h2>
                                <p class="paragraph">Becoming a member of MedResearch Ninja opens up a world of opportunities to advance your knowledge, skills, and career in the medical research field. As a member, you'll gain access to a wide range of exclusive benefits designed to support your growth and success.</p>
                            </div>
                        </div>

                    </div>
                    <div class="row wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a1.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Access to Research Projects </h5>
                                    <p class="text">Participate in cutting-edge research projects that align with your interests. Collaborate with fellow members, industry experts, and academic professionals to contribute to meaningful research that impacts the healthcare landscape.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a2.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Contribution to BlueprintRx</h5>
                                    <p>Get the opportunity to publish your research, opinions, and studies in our quarterly white paper journal, BlueprintRx. This platform allows you to share your work with a broader audience, gaining recognition and contributing to the discourse in medical research.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a3.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Networking Opportunities</h5>
                                    <p>Connect with a diverse community of students, clinicians, researchers, and industry professionals. Our forums, events, and collaborative projects provide a unique platform to build relationships, exchange ideas, and explore potential collaborations.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a4.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Educational Resources</h5>
                                    <p>Gain access to a wealth of educational resources, including webinars, workshops, and expert-led sessions. These resources are designed to keep you updated on the latest research trends, methodologies, and best practices in the field</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a5.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Career Development</h5>
                                    <p>Benefit from career development opportunities such as job postings, internship openings, and mentorship programs. We support your professional growth by providing guidance, resources, and opportunities to advance your career in research.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a6.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Exclusive Events and Conferences</h5>
                                    <p>Attend members-only events and conferences that focus on the latest developments in medical research. These events provide a platform to learn, share, and discuss emerging trends and innovations with leaders in the field.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a7.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">

                                    <h5 class="title">Presentation Opportunities at International Conferences</h5>
                                    <p>As a member, you have the chance to present your posters and abstracts at prestigious international conferences. This opportunity allows you to showcase your research on a global stage, gain recognition, and connect with leading experts in the field.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 col-lg-12 col-xl-12">
                            <div class="iconbox-style1 bdr1 d-flex align-items-start mb30">
                                <div class="icon flex-shrink-0">
                                    <img src="new-img/aicons/a8.png" height="42" w="42" />
                                </div>
                                <div class="details ml40">
                                    <h5 class="title">Recognition and Awards</h5>
                                    <p>Be recognized for your contributions to research through our member awards and recognition programs. Highlight your achievements and enhance your professional profile within the research community.</p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-lg-4 offset-lg-1  order-lg-1 order-0">
                    <div class="member-form">
                        <div class="new-contact text-black">
                            <h3 class="mb10  mb20">Sign Up to Become a Member
                            </h3>
                            <p class="text mt20">Already a Member? <a href="login.aspx" class="text-thm">Log In!</a></p>
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:Label ID="lblStatus" runat="server" Visible="false" Width="100%"></asp:Label>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtFullName" runat="server" MaxLength="100" placeholder="Full Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFullName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtemail" runat="server" MaxLength="100" placeholder="Email"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtemail" ErrorMessage="Please Enter valid EmailAddress" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtPassword" TextMode="Password" runat="server" MaxLength="100" placeholder="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtCountry" runat="server" MaxLength="100" placeholder="Country"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25 txtContactnumber">
                                        <asp:TextBox class="form-control onlyNum" ID="txtContactnumber" runat="server" Style="padding-left: 95px;" MaxLength="10" placeholder="Contact Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContactnumber" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtContactnumber" ErrorMessage="Please Enter valid contact number" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:DropDownList ID="ddlWhoAreYou" runat="server" CssClass="form-control" onchange="toggleSections()">
                                            <asp:ListItem Text="Who are you ?" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Medical Student" Value="Medical Student"></asp:ListItem>
                                            <asp:ListItem Text="Graduate" Value="Graduate"></asp:ListItem>
                                            <asp:ListItem Text="Resident" Value="Resident"></asp:ListItem>
                                            <asp:ListItem Text="Other" Value="Others"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="ddlWhoAreYou" InitialValue="" ErrorMessage="Please select a resource type" ForeColor="Red" Display="Dynamic" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div id="otherTextBoxContainer" class="col-lg-12 d-none">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtspecify" runat="server" MaxLength="100" placeholder="Other ? Please Specify"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="rfv12" runat="server" ControlToValidate="txtspecify" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="mb25">
                                        <asp:TextBox class="form-control" ID="txtCourse" runat="server" MaxLength="100" placeholder="Medical School Name/ Undergraduate Course"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCourse" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="">
                                        <label for="formFile" class="form-label">Upload College ID or Govt ID proof</label>
                                        <asp:FileUpload ID="UploadGovtID" runat="server" ToolTip="Maxmimum 2 MB file size" CssClass="form-control"></asp:FileUpload>
                                        <small class="text-danger">.pdf, .doc, .docx, .png, .jpg .jpeg formats are required</small><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="UploadGovtID" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Please upload the image"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorFile" runat="server" ControlToValidate="UploadGovtID" ErrorMessage="Invalid file type. Only .pdf, .doc, .docx, .png, .jpg, .jpeg files are allowed." ForeColor="Red" ValidationGroup="Save" Display="Dynamic" ValidationExpression="^.*\.(pdf|doc|docx|png|jpg|jpeg)$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="High-light">
                                        <p class="text-center">Membership Fee of  Rs. 850 or $10</p>
                                    </div>
                                </div>
                                <div class="checkbox-style1 d-block d-sm-flex align-items-center justify-content-between mb20">
                                    <label class="custom_checkbox fz14 ff-heading" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                        Accept Terms & Condition
                                        <asp:CheckBox ID="CheckBox" runat="server" />

                                        <span class="checkmark"></span>
                                    </label>
                                </div>

                                <div class="d-grid mb20">
                                    <asp:LinkButton ID="btnRegister" runat="server" CssClass="ud-btn btn-thm default-box-shadow2" OnClick="btnRegister_Click" ValidationGroup="Save">  Register <i class="fal fa-arrow-right-long"></i></asp:LinkButton>
                                    
                                    <small><asp:Label ID="lblstatus2" runat="server" Visible="false" Width="100%"></asp:Label></small>
                                    <asp:Label ID="lblGovtId" runat="server" Visible="false"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>


    <section class="section-padding">
        <div class="container">
            <div class="row align-items-center wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
                <div class="col-lg-9 mx-auto">
                    <div class="main-title text-center mb30">
                        <h2 class="title">Frequently Asked Questions
                        </h2>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-10">
                    <div class="navpill-style2">
                        <ul class="nav nav-pills mb60 justify-content-center" id="pills-tab" role="tablist">
                            <li class="nav-item" role="presentation">
                                <button class="nav-link active fw500 dark-color" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="false">Membership Related</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link fw500 dark-color" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Contribution Fees Related</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link fw500 dark-color" id="pills-contact-tab" data-bs-toggle="pill" data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact" aria-selected="false">Research Opportunities Related</button>
                            </li>

                        </ul>
                        <div class="tab-content ha" id="pills-tabContent">
                            <div class="tab-pane fade fz15 text show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                <div class="ui-content">
                                    <div class="accordion-style1 text-center faq-page mb-4 mb-lg-5">
                                        <div class="accordion" id="accordionExample">
                                            <div class="accordion-item ">
                                                <h2 class="accordion-header" id="headingOne">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">How do I become a member of MedResearch Ninja?</button>
                                                </h2>
                                                <div id="collapseOne" class="accordion-collapse collapse " aria-labelledby="headingOne" data-parent="#accordionExample">
                                                    <div class="accordion-body">To join, simply enroll by paying a membership fee of Rs. 850 or $10. This grants you access to our exclusive WhatsApp group and other community resources.</div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwo">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Is there a time limit on my membership?</button>
                                                </h2>
                                                <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        No, your membership is for life, meaning you only pay the membership fee once and enjoy lifetime access to all member benefits.                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingThree">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">Can I cancel my membership?</button>
                                                </h2>
                                                <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                                                    <div class="accordion-body">While you can choose to stop participating at any time, your membership is for life, and the fee is non-refundable. However, you’ll always be welcome to return and re-engage with the community whenever you wish.</div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingFour">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                                        What benefits do I get as a lifetime member?

                                                    </button>
                                                </h2>
                                                <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        As a lifetime member, you gain permanent access to our exclusive WhatsApp group, where you’ll receive continuous updates on new research projects, calls for authors, and collaboration opportunities. You’ll also benefit from ongoing mentorship and access to valuable research resources throughout your membership.                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingFive">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                                                        Can I join from anywhere in the world?

                                                    </button>
                                                </h2>
                                                <div id="collapseFive" class="accordion-collapse collapse" aria-labelledby="headingFive" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, MedResearch Ninja welcomes members globally. Our online platform allows you to participate in research projects and engage with the community, no matter where you are located.                                       
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingsix">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                                                        What happens after I become a member?
 
                                                    </button>
                                                </h2>
                                                <div id="collapseSix" class="accordion-collapse collapse" aria-labelledby="headingSix" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        After joining, you'll be added to our exclusive WhatsApp group where we regularly post updates about new research projects, calls for authors, and other opportunities.
 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingseven">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSeven" aria-expanded="false" aria-controls="collapseSeven">
                                                        How do I choose a project to work on?
 
                                                    </button>
                                                </h2>
                                                <div id="collapseSeven" class="accordion-collapse collapse" aria-labelledby="headingSeven" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        When we launch a new project, we post the details in the WhatsApp group. If you're interested in a particular project, you can message the admin directly to express your interest and enroll in the project. 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingEight">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEight" aria-expanded="false" aria-controls="collapseEight">
                                                        Is there a fee to participate in research projects?
 
                                                    </button>
                                                </h2>
                                                <div id="collapseEight" class="accordion-collapse collapse" aria-labelledby="headingEight" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, once you select a project, there is a contribution fee associated with it. This fee supports the resources and guidance provided during the research process. 
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade fz15 text" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                                <div class="ui-content">
                                    <div class="accordion-style1 text-center faq-page mb-4 mb-lg-5">
                                        <div class="accordion" id="accordionExample">

                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingNine">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseNine" aria-expanded="false" aria-controls="collapseNine">
                                                        What does the contribution fee cover?
 
                                                    </button>
                                                </h2>
                                                <div id="collapseNine" class="accordion-collapse collapse" aria-labelledby="headingNine" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        The contribution fee helps cover the costs associated with the project, including access to research tools, mentorship, and administrative support throughout the research process. 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTen" aria-expanded="false" aria-controls="collapseTen">
                                                        Is there a separate publication fee after paying the contribution fee?
 
                                                    </button>
                                                </h2>
                                                <div id="collapseTen" class="accordion-collapse collapse" aria-labelledby="headingTen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        <strong>No, there is no separate publication fee.</strong> Once you have paid the contribution fee, it covers all costs associated with the project, including resources, mentorship, and administrative support needed for the research and submission for publication. You won’t need to pay any additional fees for publication. 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingElven">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEleven" aria-expanded="false" aria-controls="collapseEleven">
                                                        When do I need to pay the contribution fee? 
                                                    </button>
                                                </h2>
                                                <div id="collapseEleven" class="accordion-collapse collapse" aria-labelledby="headingElven" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        You need to pay the contribution fee after you have expressed interest in a project and before the project officially begins. This ensures that all necessary resources and support are in place from the start.                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwelve">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwelve" aria-expanded="false" aria-controls="collapseTwelve">
                                                        Are there any additional costs after paying the contribution fee?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwelve" class="accordion-collapse collapse" aria-labelledby="headingTwelve" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        The contribution fee generally covers all necessary costs for the project. If additional resources are required, these will be communicated upfront, and members will be informed in advance.
   
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingThirteen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThirteen" aria-expanded="false" aria-controls="collapseThirteen">
                                                        Does the contribution fee guarantee publication?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseThirteen" class="accordion-collapse collapse" aria-labelledby="headingThirteen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        While we strive to ensure that all projects lead to publication, the quality of the research is the primary factor in determining whether a project will be published. Our team provides support to help you achieve publication, but it is ultimately dependent on the research outcomes and adherence to the required standards.       
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade fz15 text" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
                                <div class="ui-content">
                                    <div class="accordion-style1 text-center faq-page mb-4 mb-lg-5">
                                        <div class="accordion" id="accordionExample">

                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingFourteen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFourteen" aria-expanded="false" aria-controls="collapseFourteen">
                                                        What kind of support do I receive during the project?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseFourteen" class="accordion-collapse collapse" aria-labelledby="headingFourteen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        We provide comprehensive support, including guidance from experienced mentors, access to necessary research resources, and collaboration with fellow researchers.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingSixteen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSixteen" aria-expanded="false" aria-controls="collapseSixteen">
                                                        How long does it take for a project to be completed?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseSixteen" class="accordion-collapse collapse" aria-labelledby="headingSixteen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        The timeline for each project varies depending on its complexity and scope. However, we ensure that all projects are conducted efficiently, aiming for timely completion and publication.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingSeventeen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSeventeen" aria-expanded="false" aria-controls="collapseSeventeen">
                                                        Will my research be published?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseSeventeen" class="accordion-collapse collapse" aria-labelledby="headingSeventeen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, one of our key goals is to ensure that the research conducted by our members is of high quality and is published in reputable journals, adding significant value to your academic and professional portfolio.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingEighteen">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEighteen" aria-expanded="false" aria-controls="collapseEighteen">
                                                        Can I work on multiple projects?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseEighteen" class="accordion-collapse collapse" aria-labelledby="headingEighteen" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Absolutely! Many of our members work on multiple projects, which allows them to broaden their research experience and enhance their academic credentials.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwenty">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwenty" aria-expanded="false" aria-controls="collapseTwenty">
                                                        How do I find out about new research opportunities?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwenty" class="accordion-collapse collapse" aria-labelledby="headingTwenty" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        To stay informed about new research opportunities, visit our website and log in to your account. There, you’ll find regular updates on upcoming projects and calls for authors. Additionally, you’ll receive notifications via WhatsApp, so keep an eye on the group for real-time updates!                              
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyOne">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyOne" aria-expanded="false" aria-controls="collapseTwentyOne">
                                                        What types of research projects are available?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyOne" class="accordion-collapse collapse" aria-labelledby="headingTwentyOne" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        We offer a wide range of research projects across various medical specialties, including basic science, clinical research, case reports, systematic reviews, and more. This diversity allows members to choose projects that align with their interests and career goals.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyTwo">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyTwo" aria-expanded="false" aria-controls="collapseTwentyTwo">
                                                        How do I join a research project?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyTwo" class="accordion-collapse collapse" aria-labelledby="headingTwentyTwo" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        When a new project is announced, simply express your interest by messaging the admin in the WhatsApp group. After your enrollment is confirmed and the contribution fee is paid, you can begin working on the project.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyThree">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyThree" aria-expanded="false" aria-controls="collapseTwentyThree">
                                                        Can I participate in more than one project at a time?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyThree" class="accordion-collapse collapse" aria-labelledby="headingTwentyThree" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, you are welcome to participate in multiple projects simultaneously, depending on your availability and interest. Each project will have its own contribution fee, and you’ll need to manage your time to ensure you can contribute effectively to each project.                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyFour">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyFour" aria-expanded="false" aria-controls="collapseTwentyFour">
                                                        Do I need prior research experience to join a project?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyFour" class="accordion-collapse collapse" aria-labelledby="headingTwentyFour" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        No prior research experience is required to join a project. We welcome members at all levels of experience and provide mentorship and guidance to help you develop your research skills.       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyFive">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyFive" aria-expanded="false" aria-controls="collapseTwentyFive">
                                                        How long does a typical research project take to complete?       
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyFive" class="accordion-collapse collapse" aria-labelledby="headingTwentyFive" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        The duration of a research project varies depending on its scope and complexity. Some projects may take a few months, while others could take longer. We strive to keep timelines clear and manageable, with regular progress updates provided.
   
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentySix">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentySix" aria-expanded="false" aria-controls="collapseTwentySix">
                                                        What kind of support will I receive during a research project?
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentySix" class="accordion-collapse collapse" aria-labelledby="headingTwentySix" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        You’ll receive comprehensive support throughout the project, including guidance from experienced mentors, access to research resources, and collaboration with fellow members. Our goal is to ensure that you have everything you need to succeed.
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentySeven">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentySeven" aria-expanded="false" aria-controls="collapseTwentySeven">
                                                        Will I receive credit or authorship for my work on a project?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentySeven" class="accordion-collapse collapse" aria-labelledby="headingTwentySeven" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, members who contribute to a research project will receive appropriate credit and authorship when the work is published. Authorship is determined based on the level of contribution and follows ethical guidelines for academic publishing.
   
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyEight">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyEight" aria-expanded="false" aria-controls="collapseTwentyEight">
                                                        How often are new research opportunities available?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyEight" class="accordion-collapse collapse" aria-labelledby="headingTwentyEight" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        New research opportunities are available regularly throughout the year. The frequency of new projects depends on ongoing collaborations, member proposals, and emerging areas of interest in the medical field.
         
   
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingTwentyNine">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwentyNine" aria-expanded="false" aria-controls="collapseTwentyNine">
                                                        Can I propose my own research project?       
                                                    </button>
                                                </h2>
                                                <div id="collapseTwentyNine" class="accordion-collapse collapse" aria-labelledby="headingTwentyNine" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, members are encouraged to propose their own research ideas. If you have a project idea, you can discuss it with the admin team, and we will help you develop it into a formal project that other members can join.                                       
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingThirty">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThirty" aria-expanded="false" aria-controls="collapseThirty">
                                                        Can I bring my own cases to the research projects?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseThirty" class="accordion-collapse collapse" aria-labelledby="headingThirty" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        Yes, you can bring your own cases to the research projects! If you have an interesting or unique case that you believe would be valuable for research, you are encouraged to share it with the admin team. We can help you develop the case into a research project and involve other members in the study. This is a great way to contribute to the community and enhance your own research portfolio.
   
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="accordion-item">
                                                <h2 class="accordion-header" id="headingThirtyOne">
                                                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThirtyOne" aria-expanded="false" aria-controls="collapseThirtyOne">
                                                        What if I have more questions or need help?
   
                                                    </button>
                                                </h2>
                                                <div id="collapseThirtyOne" class="accordion-collapse collapse" aria-labelledby="headingThirtyOne" data-parent="#accordionExample">
                                                    <div class="accordion-body">
                                                        If you have any further questions or need assistance, feel free to reach out to our admin team via the WhatsApp group or contact us directly through our website. We’re here to help you every step of the way!       
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
    </section>

    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Terms & Condition</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body new-hei">
                    <p class="text-dark">
                        Welcome to our research community and discussion group. By joining, you agree to abide by the following terms and conditions. Please read them carefully before proceeding. For any queries, feel free to contact us.
                    </p>
                    <div class="list-style1">
                        <div class="section">
                            <h2>1. Purpose of the Discussion Forum</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>Share knowledge and insights related to research.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Discuss challenges, solutions, and best practices in academic publishing.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Provide constructive feedback and support to fellow researchers.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Stay updated with announcements, submission calls, and important deadlines.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>2. Confidentiality and Information Sharing</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>All discussions and shared materials within the group are strictly confidential.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Forwarding or sharing group content, messages, or documents with anyone outside the group is strictly prohibited. Violating this may result in immediate removal from the group and legal action if necessary.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Plagiarism of any shared content will not be tolerated under any circumstances.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>3. Contribution and Financial Commitments</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>Contribution fees must be paid at the start of each project. This covers essential costs such as plagiarism checks, editing, and journal submission.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Advance bookings or payments for future projects are not accepted. Authorship spots can only be secured once the official calls for submissions are announced.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>4. Publication Deadlines</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>While we strive to meet all deadlines, delays may occur due to reasons beyond our control, including journal review timelines. Members will be informed of any changes promptly.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>5. Group Etiquette</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>Maintain professionalism and mutual respect in all interactions within the group.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Avoid posting irrelevant, offensive, or promotional content. Any inappropriate behavior may result in removal from the group.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>6. Features and Responsibilities of the Discussion Forum</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i><strong>Expert Guidance:</strong> Members can seek guidance from experts on research methodology, writing, and publication processes.</li>
                                <li><i class="fa-solid fa-check dark-color"></i><strong>Collaboration Opportunities:</strong> Engage in collaborative projects with other members based on shared interests.</li>
                                <li><i class="fa-solid fa-check dark-color"></i><strong>Regular Updates:</strong> Receive updates on new opportunities, journal calls, and community initiatives.</li>
                                <li><i class="fa-solid fa-check dark-color"></i><strong>Problem Resolution:</strong> Discuss and resolve research and academic challenges collectively with input from peers and experts.</li>
                                <li><i class="fa-solid fa-check dark-color"></i><strong>Resource Sharing:</strong> Access and share tools, templates, and other resources relevant to academic publishing.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>7. Intellectual Property</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>All original ideas, research, and intellectual property shared within the group remain the property of the respective contributors.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>Members must seek explicit permission before using any shared content for personal or professional purposes.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>8. Disclaimer</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>The research community and its administrators do not guarantee the acceptance of manuscripts by journals, as publication decisions are made solely by the respective journals.</li>
                                <li><i class="fa-solid fa-check dark-color"></i>While every effort is made to provide accurate and valuable advice, the community is not responsible for any errors or omissions.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>9. Termination of Membership</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>Membership may be terminated at any time for violation of these terms and conditions, including but not limited to breaches of confidentiality, plagiarism, or inappropriate behavior.</li>
                            </ul>
                        </div>

                        <div class="section">
                            <h2>10. General Conduct</h2>
                            <ul>
                                <li><i class="fa-solid fa-check dark-color"></i>Research is a challenging and dynamic process. Members are encouraged to remain patient, committed, and collaborative throughout their journey with the community.</li>
                            </ul>
                        </div>

                    </div>

                </div>

            </div>
        </div>
    </div>
    <asp:HiddenField ID="txtCCodeMob1" runat="server" />
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
            var input = document.querySelector("#<%=txtContactnumber.ClientID %>");
            window.intlTelInput(input, { separateDialCode: true }).setNumber(($("#<%=txtCCodeMob1.ClientID %>").val() == "" ? "+91" : $("#<%=txtCCodeMob1.ClientID %>").val()) + $("#<%=txtContactnumber.ClientID%>").val());

            $('#<%=txtContactnumber.ClientID %>').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode
                if (String.fromCharCode(charCode).match(/[^0-9]/g))
                    return false;

            });
            $('#<%=txtContactnumber.ClientID %>').change(function () {
                $("#<%=txtCCodeMob1.ClientID %>").val($(".txtContactnumber .iti__selected-dial-code").html());
            });

        });
    </script>
    <script type="text/javascript">
        function toggleSections() {
            var dropdown = document.getElementById("<%=ddlWhoAreYou.ClientID %>");
            var otherTextBoxContainer = document.getElementById("otherTextBoxContainer");

            if (dropdown.value === "Others") {
                otherTextBoxContainer.classList.remove("d-none");
                // validator.enabled = true;
            } else {
                otherTextBoxContainer.classList.add("d-none");
                // validator.enabled = false;
            }
        }
    </script>
</asp:Content>


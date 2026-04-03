<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="career.aspx.cs" Inherits="career" %>

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

        .iconbox-style1 {
            padding: 20px !important;
        }

        .find-work {
            text-align: left;
            padding: 35px 50px 35px 50px;
            transition: 0.5s all ease-in-out;
            position: relative;
            border-radius: 10px;
            position: relative;
            background: #fff;
        }

            .find-work p {
                min-height: 140px;
            }

        .iconbox-style1 h4 {
            font-weight: 600;
        }

        .color-th {
            color: #ff7f3e;
        }

        .service-card-6 .inner .icon img {
            filter: invert(0) !important;
        }

        .service-card-6 .inner .content .title a {
            color: #ff7f3e;
        }

        @media (min-width: 992px) and (max-width: 1199px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }

            .find-work p {
                min-height: 205px !important;
            }
        }

        @media (min-width: 1200px) and (max-width: 1300px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }

           
        }

        @media (min-width: 1300px) and (max-width: 1400px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }

           
        }

        @media (min-width: 992px) and (max-width: 1200px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }

           
        }

        @media (min-width: 768px) and (max-width: 991px) {
            .iconbox-style1 p {
                min-height: unset !important;
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
                            <a href="/Default.aspx">Home</a>
                            <a href="#">Career</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding">
        <div class="container">

            <div class="row align-items-center wow fadeInUp mt20" style="visibility: visible; animation-name: fadeInUp;">
                <div class="col-md-6 col-lg-8 col-xl-6">
                    <div class="main-title">
                        <h2 class="title">Careers at MedResearch Ninja

                        </h2>
                        <p class="paragraph">
                            Step beyond membership and become an integral part of MedResearch Ninja, where we’re dedicated to pioneering advancements in medical research and healthcare innovation. Explore the opportunities below to join our passionate and innovative team and help shape the future of healthcare.

                        </p>
                    </div>
                </div>
                <div class="col-md-6 col-lg-3 offset-lg-1  col-xl-3 offset-xl-2">
                    <div class="text-center mt30-sm">
                        <img class="w-100 bdrs4" src="new-img/aicons/job1.png" alt="">
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="our-features section-padding bg-dark">
        <div class="container wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
            <div class="row justify-content-center">
                <div class="col-lg-10">
                    <div class="main-title text-center">
                        <h2 class="text-white">Become a Key Player

                        </h2>
                        <p class="text-white">Explore our available roles and see how you can contribute beyond membership. Join MedResearch Ninja as a vital part of our team, driving forward groundbreaking research and innovation in healthcare. Make a meaningful impact and help shape the future of medical science with us.</p>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center gy-4">
                <div class="col-sm-6 col-md-12 col-lg-10 align-items-stretch">
                    <div class="iconbox-style1 h-100 at-home4 p-0 text-start d-flex align-items-center gap-5">
                        <div class="w-auto">
                            <div class="icon before-none text-center "><span class="flaticon-cv"></span></div>
                        </div>
                        <div class="details text-start">
                            <h4 class="title mt10 mb-3">Join Our Core Team</h4>
                            <p class="text mb-0">
                                Be a driving force in our community’s mission.
If you're interested in joining our core team, please email us with your CV and a statement of intent outlining why you’re passionate about being part of our core team. We look forward to hearing how your unique experiences and insights can help drive our community forward!
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-12 col-lg-10 align-items-stretch">
                    <div class="iconbox-style1 h-100 at-home4 p-0 text-start d-flex align-items-center gap-5">
                        <div class="w-auto">
                            <div class="icon before-none text-center "><span class="flaticon-cv"></span></div>
                        </div>
                        <div class="details text-start">
                            <h4 class="title mt10 mb-3">Join Our Working Committee 
                            </h4>
                            <p class="text w-95">
                                Collaborate on impactful projects and bring ideas to life.
Applications for our Working Committee open once a year. Watch this space for updates on when the application window opens, so you don’t miss your chance to be part of this dedicated team!
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-12 col-lg-10 align-items-stretch">
                    <div class="iconbox-style1 h-100 at-home4 p-0 text-start d-flex align-items-center gap-5">
                        <div class="w-auto">
                            <div class="icon before-none text-center "><span class="flaticon-cv"></span></div>
                        </div>
                        <div class="details text-start">
                            <h4 class="title mt10 mb-3">Work as a Student Intern
                            </h4>
                            <p class="text">
                                Start your journey in medical research with hands-on experience.
Our internships offer an incredible opportunity for students to gain practical experience and contribute to real-world projects. Check back for open internship positions and application details.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-12 col-lg-10 align-items-stretch">
                    <div class="iconbox-style1 h-100 at-home4 p-0 text-start d-flex align-items-center gap-5">
                        <div class="w-auto">
                            <div class="icon before-none text-center "><span class="flaticon-cv"></span></div>
                        </div>
                        <div class="details text-start">
                            <h4 class="title mt10 mb-3">Apply for a Research Assistant 
                            </h4>
                            <p class="text">
                                Apply for a Research Assistant
Support our busy medical professionals with your expertise.
We welcome helping hands to support our medical professionals. If you have prior research experience in pharmacy or hold a degree in an allied healthcare subject, you’re encouraged to apply.<br class="d-lg-none d-block mt-2" />
                                Email us at <a class="new-color" href="mailto:connect@medresearchninja.org">connect@medresearchninja.org</a> with your CV to express your interest.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding main-job ">
        <div class="container">
            <div class="row align-items-center justify-content-center wow fadeInUp" data-wow-delay="00ms" style="visibility: visible; animation-delay: 0ms; animation-name: fadeInUp;">
                <div class="col-md-12 col-lg-6">
                    <div class="find-work bg-white pb40 pt40 px20 bdrs24 text-start ">
                        <h2 class="title  mb20">Research Assistant Opportunity</h2>
                        <p>Work alongside experienced mentors, contribute to impactful medical research, and develop your skills in a collaborative environment. This is a paid position, with compensation based on experience. As we are a nonprofit organization, please note that the salary may be modest. Join us to help drive healthcare innovation and make a real difference! If you’re looking to grow, learn, and contribute to something meaningful, we’d love for you to join us!</p>
                        <h4>Qualifications</h4>
                        <ul>
                            <li>-MBBS or related degree (clinical research experience preferred)</li>
                            <li>-Strong data collection, analysis, and protocol skills</li>
                            <li>-Detail-oriented with organizational abilities</li>
                            <li>-Team player with strong communication skills</li>
                        </ul>
                        <a class="ud-btn btn-dark bdrs60" href="career/jobs">Apply Now <i class="fal fa-arrow-right-long"></i></a>
                    </div>
                </div>
                <div class="col-md-12 col-lg-4 offset-lg-1">
                    <img src="images/job.jpg" class="img-fluid" />
                </div>
            </div>
            <div class="row align-items-center justify-content-center wow fadeInUp" data-wow-delay="00ms" style="visibility: visible; animation-delay: 0ms; animation-name: fadeInUp;">
                <div class="col-md-12 col-lg-4 order-lg-0 order-1 ">
                    <img src="images/job1.jpg" class="img-fluid" />
                </div>
                <div class="col-md-12 col-lg-6 offset-lg-1 order-lg-1 order-0">

                    <div class="find-work bg-white pb40 pt40 px20 bdrs24 text-start ">
                        <h2 class="title  mb20">Student Internships 
                        </h2>
                        <p class="text">
                            We believe medical professionals can be all-rounders! Join us to expand your expertise beyond clinical skills—gain hands-on experience in research, administration, and project management within a collaborative nonprofit setting. Though unpaid, this position offers MBBS students and graduates the chance to develop versatile skills while making a real impact on healthcare

                        </p>
                        <a class="ud-btn btn-dark bdrs60" href="career/internship">Find Internships<i class="fal fa-arrow-right-long"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--<section class="section-padding bg-dark">
        <div class="container">
            <div class="row align-items-center justify-content-center wow fadeInUp" data-wow-delay="00ms" style="visibility: visible; animation-delay: 0ms; animation-name: fadeInUp;">
                <div class="col-lg-8 ">
                    <div class="main-title text-center">
                        <h2 class="title text-white">Application Process</h2>
                        <p class="text-white">
                            <span class=" color-th">Interested in joining our team?</span> Learn more about our straightforward application process.
                            <br />
                            We value transparency and efficiency, and our process is designed to identify the best candidates who share our vision and commitment.

                        </p>
                    </div>
                </div>

            </div>
            <div class="row wow fadeInUp" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">



                <!-- Start Service Grid  -->
                <div class="col-lg-4 col-xl-3 col-xxl-3 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/aicons/1111.png" alt="icons Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="#">Submitting Resume

                                </a></h6>
                                <p class="description">
                                    Establish clear research goals and hypotheses to guide the study. This involves pinpointing specific questions or problems that need addressing.


                                </p>
                            </div>
                            <span class="number-text">1</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                <div class="col-lg-4 col-xl-3 col-xxl-3 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/aicons/2222.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="#">Interview Stage
                                </a></h6>
                                <p class="description">
                                    Examine existing research and data to understand the current knowledge landscape. This helps identify gaps and refine the study focus.


                                </p>
                            </div>
                            <span class="number-text">2</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                <div class="col-lg-4 col-xl-3 col-xxl-3 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/aicons/job.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="/#">You Get Ready </a></h6>
                                <p class="description">
                                    Create a detailed research plan outlining methods, participant criteria, and data collection techniques. This ensures consistency and reliability in the research process.


                                </p>
                            </div>
                            <span class="number-text">3</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                <div class="col-lg-4 col-xl-3 col-xxl-3 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="/new-img/aicons/4444.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="/#">Selection </a></h6>
                                <p class="description">
                                    Interpret the data collected to draw conclusions and determine if the research objectives were met. This phase involves statistical analysis and critical evaluation of findings.



                                </p>
                            </div>
                            <span class="number-text">4</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

            </div>





        </div>
    </section>--%>
    <section class="section-padding bgc-thm">
        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-md-8 col-lg-8 col-12 wow fadeInRight" style="visibility: visible; animation-name: fadeInRight;">
                    <div class="cta-style3 text-center">
                        <h2 class="cta-title text-white">Join Our Team of Innovators  Start Your Journey with Us Today!</h2>
                        <p class="cta-text text-white">Highlights the innovative aspect of the work  and invites candidates to begin their application.</p>
                        <a href="contact-us.aspx" class="ud-btn btn-transparent2 bdrs60">Contact Us<i class="fal fa-arrow-right-long"></i></a>
                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Open Graph Meta Tags -->
    <meta property="og:title" content="MedResearch Ninja | Connecting Researchers Globally for Medical Breakthroughs" />
    <meta property="og:description" content="Join MedResearch Ninja – a global community for medical students, clinicians, and researchers. Collaborate on research projects, access resources, connect with experts, and publish impactful medical studies." />
    <meta property="og:type" content="website" />
    <meta property="og:url" content="https://medresearchninja.org/" />
    <meta property="og:image" content="https://medresearchninja.org/images/og.png" />
    <meta property="og:image:width" content="1200" />
    <meta property="og:image:height" content="630" />
    <meta property="og:site_name" content="MedResearch Ninja" />
    <meta property="og:locale" content="en_US" />

    <!-- Twitter Card -->
    <meta name="twitter:card" content="summary_large_image" />
    <meta name="twitter:title" content="MedResearch Ninja | Global Medical Research Collaboration Platform" />
    <meta name="twitter:description" content="Collaborate with medical researchers worldwide. Access projects, mentorship, resources, and publication support through MedResearch Ninja." />
    <meta name="twitter:image" content="https://medresearchninja.org/images/og.png" />
    <style>
        .social-style1 {
            display: flex;
            margin-top: 14px;
            align-items: center;
        }

        .home20-hero-content .title {
            font-size: 55px;
            line-height: 62px;
        }

        .iconbox-style1 p {
            min-height: 206px;
        }

        .listing-style1 .list-title {
            margin-bottom: 15px;
            min-height: 46px;
        }

        .row.mb60.mb0-xl {
            position: relative;
        }

        .notice-wrap:hover {
            box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
        }

            .notice-wrap:hover h4 {
                color: #f1f1f1;
                font-weight: bold;
            }

        .home16-hero-fltimg {
            max-height: 600px;
            max-width: 800px;
            position: absolute;
            right: -44px;
            top: -145px;
            z-index: -1;
        }


        .home2-hero-content .iconbox-small2 {
            border-radius: 16px;
            padding: 20px 30px 20px 20px;
            right: -4px;
            z-index: 1;
            top: 7px;
        }


        .notice-body ul {
            padding: 20px 0px;
        }

            .notice-body ul li {
                border-bottom: 1px solid #f1f1f1;
                color: #000;
                padding: 10px 0px;
                cursor: pointer;
            }

                .notice-body ul li i {
                    border-bottom: 1px solid #f1f1f1;
                    margin-right: 10px;
                    color: #f77b3c;
                }

        .notice-body {
            padding: 0px 20px 20px 20px;
            background: #000;
        }

        .notice-wrap {
            padding: 0px 0px;
            border-radius: 16px;
        }

        .new-head1 {
            text-align: center;
            background: #000;
            padding: 10px 20px;
            border-top-right-radius: 12px;
            border-top-left-radius: 12px;
        }

            .new-head1 h4 {
                margin-bottom: 0px;
                color: #fff;
                font-size: 28px;
            }

        .notice-body {
            border-bottom-left-radius: 12px;
            border-bottom-right-radius: 12px;
        }

        .new-sec {
            background: #fff;
            padding: 20px;
        }

        .notice-body ul {
            padding: 20px 0px;
        }

            .notice-body ul li {
                border-bottom: 1px solid #f1f1f1;
                color: #000;
                padding: 10px 0px;
                cursor: pointer;
            }

                .notice-body ul li i {
                    border-bottom: 1px solid #f1f1f1;
                    margin-right: 10px;
                }

        .notice-body {
            padding: 0px 20px 20px 20px;
            background: #000;
        }

        .autoscroller {
            height: 400px;
            overflow: hidden;
        }

        .navtab-style1 .nav-link.active, .navtab-style2 .nav-link.active {
            border: 2px solid transparent;
            border-bottom: 2px solid var(--headings-color);
            color: #222222;
            text-align: left;
            font-weight: 700;
            padding-left: 0px;
        }

        .notice-body ul li {
            border-bottom: 1px solid #f1f1f1;
            color: #000;
            font-size: 16px;
            padding: 10px 0px;
            cursor: pointer;
        }

            .notice-body ul li:hover {
                font-weight: 600;
            }

        .strategies-content-card {
            background-color: #ffffff;
            padding: 25px;
            border-radius: 5px;
            -webkit-transition: 0.4s;
            transition: 0.4s;
            margin-right: 30px;
            margin-bottom: 25px;
        }

            .strategies-content-card .content {
                position: relative;
                padding-left: 105px;
            }

                .strategies-content-card .content .icon {
                    position: absolute;
                    left: 0;
                    top: -25px;
                    display: inline-block;
                    width: 80px;
                    height: 110px;
                    line-height: 110px;
                    background: radial-gradient(circle, rgba(255,74,29,1) 0%, rgba(255,127,62,1) 100%);
                    box-shadow: -2px 6px 20px rgba(255, 109, 52, 0.08);
                    color: #ffffff;
                    text-align: center;
                    font-size: 45px;
                    -webkit-transition: 0.4s;
                    transition: 0.4s;
                }

                .strategies-content-card .content h4 {
                    font-size: 20px;
                    text-align: start;
                    margin-bottom: 15px;
                    font-weight: 600;
                }

                .strategies-content-card .content p {
                    margin-bottom: 0;
                    color: #000;
                    text-align: start;
                }

                .strategies-content-card .content .icon img {
                    height: 44px;
                    width: 40px;
                }

        .funfact_one h4 {
            color: #fff;
            font-weight: 600;
        }

        .funfact_one p {
            color: #fff;
            min-height: 60px;
        }

        .high-lighy {
            margin-top: 20px;
            border-left: 3px solid #fff;
            font-size: 17px;
            padding: 10px 20px;
            font-weight: 700;
            background: #0000001f;
        }

            .high-lighy h6 {
                color: #fff;
                font-weight: 700;
                font-size: 22px;
                margin-bottom: 0px;
            }

        .funfact_one {
            text-align: left;
            padding: 25px 25px 25px 25px;
            transition: 0.5s all ease-in-out;
            position: relative;
            border-radius: 10px;
            position: relative;
            z-index: 1;
            height: 100%;
            display: flex;
            align-items: center;
            border: 2px dashed #fff;
            box-shadow: 0 13px 48px 0 rgba(215, 216, 222, 0.44);
        }

            .funfact_one h4 {
                font-size: 20px;
                min-height: 18px;
            }

        .iconbox-style9 {
            padding: 40px;
        }

            .iconbox-style9 p {
                overflow: hidden;
                text-overflow: ellipsis;
                -webkit-line-clamp: 2;
                display: -webkit-box;
                -webkit-box-orient: vertical;
            }



        @media (min-width: 320px) and (max-width: 767px) {
            .why-chose-list {
                margin-bottom: 0px !important;
            }

            .listbox-style1 {
                max-width: unset !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="hero-home13 at-home20 overflow-hidden bg-dark">

        <div class="container">

            <div class="row align-items-center justify-content-center">
                <div class="col-xl-6 col-lg-7">
                    <div class="home20-hero-content text-start">
                        <h1 class="animate-up-1 mb25  text-white title">Connecting  
                             <span class="new-color">Researchers Globally </span>


                            for Collaborative Breakthroughs in Medicine </h1>
                        <p class="text mb30 text-white animate-up-2">
                            Join a network of over hundreds of students and clinicians who have advanced their research journey with our support. Whether you're a PLAB or USMLE aspirant, or a medical student with a passion for research, connect with leading experts and like-minded peers. Share insights, discuss breakthroughs, and collaborate on innovative solutions to drive the future of healthcare. Together, we're shaping the next generation of medical research.                     
                        </p>
                        <div></div>
                        <a href="signup.aspx" class="ud-btn1 btn-thm  mb25 me-4 joinUs">Join Us Now</a>

                    </div>
                </div>
                <div class="col-xl-6 col-lg-5">
                    <div class="position-relative">
                        <img src="new-img/asds.png" class="img-fluid" />
                        <div class="home20-hero-imgs-left d-none d-lg-block">
                            <img src="new-img/doctor/1.png" alt="" class="img-1  animate-up-3">
                            <img src="new-img/doctor/3.png" alt="" class="img-3  animate-up-3">
                            <img src="new-img/doctor/4.png" alt="" class="img-4  animate-up-3">
                        </div>
                        <div class="home20-hero-imgs-right d-none d-lg-block">
                            <img src="new-img/doctor/5.png" alt="" class="img-1  animate-up-3">
                            <img src="new-img/doctor/7.png" alt="" class="img-3 animate-up-3">
                            <img src="new-img/doctor/8.png" alt="" class="img-4  animate-up-3">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Need something -->
    <section class=" mx-auto position-relative pt60-lg pb60-lg bg-white">
        <div class="container">
            <div class="row align-items-center wow fadeInDown" data-wow-delay="400ms" style="visibility: visible; animation-delay: 400ms; animation-name: fadeInDown;">
                <div class="col-lg-7 col-xl-6 pr30  wow fadeInRight mb60-xs mb100-md" style="visibility: visible; animation-name: fadeInRight;">
                    <div class="mb20">
                        <div class="main-title mb20">
                            <h2 class="title">Empowering Collective Growth   <span class="new-color">in Medical Research</span><br class="d-none d-xl-block">
                            </h2>
                        </div>
                    </div>

                    <div class="why-chose-list">
                        <p class="text-dark mb30">
                            MedResearch Ninja empowers students, residents, and researchers by offering a collaborative space to connect, share, and grow. Our platform enriches the journey in medical research—whether advancing careers, building professional connections, or exploring innovative ideas in healthcare. Known for our beginner-friendly support, we guide those new to research, helping them build a strong foundation. We foster an environment where collaboration and shared knowledge fuel progress in medical science.

                        </p>
                        <div class="list-one d-flex align-items-start mb30">
                            <img src="new-img/aicons/1.png" height="38" width="38" class="list-icon flex-shrink-0" />
                            <div class="list-content flex-grow-1 ml20">
                                <h4 class="mb-1">Engage Across Diverse Specialties

                                </h4>
                                <p class="text ">
                                    Our platform supports research and publications across a wide range of medical fields, encouraging knowledge exchange and specialized collaboration
                                </p>
                            </div>
                        </div>

                        <div class="list-one d-flex align-items-start mb30">
                            <img src="new-img/aicons/3.png" height="38" width="38" class="list-icon flex-shrink-0" />
                            <div class="list-content flex-grow-1 ml20">
                                <h4 class="mb-1">Share Your Research and Insights


                                </h4>
                                <p class="text mb-0 ">
                                    Have valuable findings or ideas? Submit your research, connect with fellow professionals, and engage in discussions that inspire future advancements.







                                </p>
                            </div>
                        </div>
                        <div class="list-one d-flex align-items-start mb30">
                            <img src="new-img/aicons/4.png" height="38" width="38" class="list-icon flex-shrink-0" />
                            <div class="list-content flex-grow-1 ml20">
                                <h4 class="mb-1">Commitment to Research Excellence
  
                                </h4>
                                <p class="text mb-0 ">
                                    We emphasize high-quality, impactful research that drives progress and fosters meaningful innovations in global healthcare. Together, we’re shaping a brighter future in medical science.

                                </p>
                            </div>
                        </div>
                        <div class="list-one d-flex align-items-start mb30">
                            <img src="images/support.png" height="38" width="38" class="list-icon flex-shrink-0" />
                            <div class="list-content flex-grow-1 ml20">
                                <h4 class="mb-1">Supporting New Researchers
  
                                </h4>
                                <p class="text mb-0 ">
                                    Starting out in medical research? MedResearch Ninja is known for its supportive environment, guiding beginners as they navigate and build their research skills. We provide resources and mentorship to help you establish a strong foundation and connect with experts across diverse specialties.

                                </p>
                            </div>
                        </div>
                        <a href="signup.aspx" class="ud-btn btn-dark mt15 joinUs">Join Us Now</a>

                    </div>
                </div>
                <div class="col-lg-5 col-xl-4 wow fadeInLeft" style="visibility: visible; animation-name: fadeInLeft;">
                    <div class="listbox-style1 px30 py-5 bdrs16 bgc-dark position-relative">
                        <div class="list-style1">
                            <ul class="mb-0">
                                <li class="text-white fw500"><i class="fa-solid fa-check dark-color "></i>Explore Research Opportunities</li>
                                <li class="text-white fw500"><i class="fa-solid fa-check dark-color "></i>Build Your Research Network
                                </li>
                                <li class="text-white fw500"><i class="fa-solid fa-check dark-color "></i>Conference & Webinar Alerts</li>
                                <li class="text-white fw500 mb-0"><i class="fa-solid fa-check dark-color "></i>Access Exclusive Resources




                                </li>
                            </ul>
                        </div>
                    </div>
                    <img class="home10-cta-img bdrs24" src="images/about.png" alt="">
                </div>
            </div>
        </div>
    </section>


    <section class="  position-relative section-padding bg-dark new-top">
        <%--        <img class="cta-about2-img at-home10 bdrs24 d-none d-xl-block" src="new-img/res.png" alt="">--%>
        <div class="container">
            <div class="row">
                <div class="col-xl-5  wow fadeInUp" data-wow-delay="200ms" style="visibility: visible; animation-delay: 200ms; animation-name: fadeInUp;">
                    <div class="main-title">
                        <h2 class="title text-white  text-capitalize">A Glimpse Into Our Community</h2>
                        <p class=" text-white  text">
                            Discover a rich array of resources, including research tools, best practices, and publications, all designed to support and enhance your journey in medical research.

                        </p>
                    </div>
                </div>
            </div>
            <div class="row  wow fadeInDown" data-wow-delay="400ms" style="visibility: visible; animation-delay: 400ms; animation-name: fadeInDown;">
                <div class="col-xl-12 ">
                    <div class="row justify-content-end">
                        <div class="col-sm-6 col-lg-3">
                            <div class="iconbox-style9 default-box-shadow1 bgc-white   p20-sm bdrs12 position-relative mb30">
                                <img src="new-img/art.png" />
                                <h4 class="iconbox-title mt20">Latest Project</h4>
                                <p class="text mb-2">
                                    Check out the latest research from our top collaborators

                                </p>
                                <a href="latest-work.aspx" class="ud-btn2 text-dark mt-2">View All <i class="fal fa-arrow-right-long"></i></a>

                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="iconbox-style9 default-box-shadow1 bgc-white  p20-sm bdrs12 position-relative mb30">
                                <img src="new-img/icon/2.png" />
                                <h4 class="iconbox-title mt20">Whitepaper</h4>
                                <p class="text mb-2">
                                    Enhance your Knowledge with articles from top researchers, medical experts, and collaborators.

                                </p>
                                <a href="white-paper.aspx" class="ud-btn2 text-dark mt-2">View All <i class="fal fa-arrow-right-long"></i></a>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="iconbox-style9 default-box-shadow1 bgc-white  p20-sm bdrs12 position-relative mb30">
                                <img src="new-img/icon/3.png" />
                                <h4 class="iconbox-title mt20">Discussion  Forum</h4>
                                <p class="text mb-2">
                                    Thoughts and ideas are welcome in our community, check what like-minded people have to say in our discussion forums like Quora. 
                                </p>
                                <a href="discussion-forum.aspx" class="ud-btn2 text-dark mt-2">View All <i class="fal fa-arrow-right-long"></i></a>
                            </div>
                        </div>
                        <div class="col-sm-6 col-lg-3">
                            <div class="iconbox-style9 default-box-shadow1 bgc-white p20-sm bdrs12 position-relative mb30">
                                <img src="images/document.png" />
                                <h4 class="iconbox-title mt20">Resources</h4>
                                <p class="text mb-2">
                                    Read, Grow, and learn with our profound and published articles. 

                                </p>
                                <a href="resources.aspx" class="ud-btn2 text-dark mt-2">View All <i class="fal fa-arrow-right-long"></i></a>
                            </div>
                        </div>

                    </div>
                    <div class="row ">
                        <div class="col-lg-4">
                            <a href="signup.aspx" class="ud-btn1 btn-thm mt15 joinUs">Join Us Now</a>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="coming-soon-section  position-relative overflow-hidden">
        <!-- Decorative animated circles/particles -->
        <div class="particles">
            <span></span><span></span><span></span><span></span><span></span>
            <span></span><span></span><span></span><span></span><span></span>
        </div>

        <div class="container position-relative">
            <div class="row justify-content-center">
                <div class="col-lg-8 mb30 text-lg-center text-start">
                    <h2 class="title text-white">Our Upcoming Features</h2>

                </div>
            </div>

            <div class="row g-4 text-center">

                <!-- Card 1 -->
                <div class="col-lg-4">
                    <div class="comming-soon-card">
                        <div class="icon mb-3">
                            <img src="images/upcoming/3.png" class="img-fluid" />
                        </div>
                        <div class="content">
                            <h4 class="mb-2">Plagiarism Report</h4>
                            <p class="text-muted">Maintain the highest standards of academic integrity with our upcoming plagiarism report service.</p>
                        </div>
                    </div>
                </div>

                <!-- Card 2 -->
                <div class="col-lg-4">
                    <div class="comming-soon-card">
                        <div class="icon mb-3">
                            <img src="images/upcoming/2.png" class="img-fluid" />
                        </div>
                        <div class="content">
                            <h4 class="mb-2">Request Article</h4>
                            <p class="text-muted">Don’t let paywalls hold back your research. With our upcoming Request an Article feature.</p>
                        </div>
                    </div>
                </div>

                <!-- Card 3 -->
                <div class="col-lg-4">
                    <div class="comming-soon-card">
                        <div class="icon mb-3">
                            <img src="images/upcoming/1.png" class="img-fluid" />
                        </div>
                        <div class="content">
                            <h4 class="mb-2">Ninja Research Bot</h4>
                            <p class="text-muted">The Ninja Research Bot is your fast, reliable, and intelligent assistant designed to simplify every step.</p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <section class="section-padding  overflow-hidden">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-lg-8 mb30 text-lg-center text-start">
                    <h2 class="title">How We Work</h2>
                    <p class="text-dark">
                        At MedResearch Ninja, we’re evolving into a comprehensive platform that fosters broad research engagement and collaboration. As we take on a more expansive role, we’re excited to introduce new opportunities to support our members’ growth and success in research.
                    </p>
                </div>
            </div>

            <div class="row justify-content-center process-flow">

                <div class="col-lg-2 col-md-6 col-sm-6">
                    <div class="process-flow-box">
                        <div class="number">1</div>
                        <div class="separator d-none"></div>
                        <div class="new_service_content">
                            <img src="new-img/aicons/111.png" alt="Alternate Text">
                            <h3 class="sub-head">Membership Enrollment</h3>
                            <p>
                                Start your research journey with MedResearch Ninja by joining our community. For a nominal membership fee of Rs. 850/- or $10, members gain access to a supportive network, exclusive resources, and valuable research opportunities.                   
                            </p>

                        </div>
                    </div>
                </div>

                <div class="col-lg-2 col-md-6 col-sm-6">
                    <div class="process-flow-box">
                        <div class="number">2</div>
                        <div class="separator"></div>
                        <div class="new_service_content">
                            <img src="new-img/aicons/222.png" alt="Alternate Text">
                            <h3 class="sub-head">Exclusive Group Access</h3>
                            <p>
                                As a member, you will gain entry to our dedicated WhatsApp group, where we share regular updates on author openings, project opportunities, and collaborative initiatives.   Each member will also have an account to log in, view ongoing projects, and explore new launches.        
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-lg-2 col-md-6 col-sm-6">
                    <div class="process-flow-box">
                        <div class="number">3</div>
                        <div class="separator"></div>
                        <div class="new_service_content">
                            <img src="new-img/aicons/333.png" alt="Alternate Text">
                            <h3 class="sub-head">Project Selection</h3>
                            <p>
                                Once enrolled, members can browse available projects and choose those that align with their research interests. Selected projects offer meaningful opportunities to engage and contribute to impactful research.    
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-lg-2 col-md-6 col-sm-6">
                    <div class="process-flow-box">
                        <div class="number">4</div>
                        <div class="separator"></div>
                        <div class="new_service_content">
                            <img src="new-img/aicons/444.png" alt="Alternate Text">
                            <h3 class="sub-head">Project Contribution</h3>
                            <p>
                                Upon selecting a project, members contribute a project-specific fee, which supports access to resources, mentorship, and structured guidance throughout the research process, ensuring success and growth.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6 col-sm-6">
                    <div class="process-flow-box">
                        <div class="number">5</div>
                        <div class="separator"></div>
                        <div class="new_service_content">
                            <img src="new-img/aicons/555.png" alt="Alternate Text">
                            <h3 class="sub-head">Research and Publication</h3>
                            <p>
                                Members work closely with peers and mentors to achieve high-quality research outcomes. Once a project is completed, it progresses to publication in reputable journals, adding a significant accomplishment to the member’s research portfolio and advancing the field of medical science.                           
                            </p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="cta-banner3 section-padding position-relative overflow-hidden bg-dark">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-xl-6 col-lg-12 wow fadeInRight" style="visibility: visible; animation-name: fadeInRight;">
                    <div class="mb30">
                        <div class="main-title">
                            <h2 class="title text-white">Comprehensive Research Support</h2>
                        </div>
                        <p class="text-white">At MedResearch Ninja, we offer end-to-end support to ensure our members succeed at every stage of their research journey. Here’s what our support includes:</p>
                    </div>
                    <div class="list-style1">
                        <ul>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Project Guidance and Planning:</strong>
                                    Receive personalized guidance on project selection, scope definition, and research planning to set a strong foundation for success.
                                </p>
                            </li>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Resource Access:</strong>
                                    Access a curated library of research tools, databases, and specialized literature, helping you gain the knowledge needed for in-depth studies.
                                </p>
                            </li>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Mentorship and Expertise:</strong>
                                    Work alongside experienced mentors who provide feedback, troubleshooting, and advice, helping you refine your methods and reach research goals.
                                </p>
                            </li>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Skill Development:</strong>
                                    Participate in workshops, webinars, and tutorials covering essential skills like data analysis, manuscript writing, and study design.
                                </p>
                            </li>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Ongoing Collaboration and Feedback:</strong>
                                    Collaborate within teams or peer groups, receiving continuous feedback to ensure your research remains on track and aligns with best practices.
                                </p>
                            </li>
                            <li class="text-white">
                                <p class="text-white">
                                    <i class="fa-solid fa-check dark-color mt-1"></i><strong>Publication Support :</strong>
                                    From manuscript preparation to submission, our team guides you through the entire publication process, helping you achieve a strong, publishable outcome.
                                </p>
                            </li>
                        </ul>
                        <p class="text-white">With this end-to-end support, MedResearch Ninja is committed to helping you succeed and make meaningful contributions to the medical research field.</p>
                    </div>
                    <a href="signup.aspx" class="ud-btn btn-thm mt15 joinUs">Join Us Now</a>
                </div>
                <div class="col-xl-6 col-lg-6">
                    <img class=" img-fluid new-hide wow fadeInLeft" src="images/3655633-ai.png" alt="" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInLeft;">
                </div>
            </div>
        </div>
    </div>

    <section class="our-features section-padding">
        <div class="container wow fadeInUp" style="visibility: visible; animation-name: fadeInUp;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="main-title text-center">
                        <h2>Unlock New Avenues for Contribution</h2>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-sm-6 col-lg-4">
                    <div class="iconbox-style1 at-home14-v2 after_style p-0 text-center">
                        <div class="icon before-none"><span class="flaticon-cv"></span></div>
                        <div class="details">
                            <h4 class="title fw-bold mt10 mb-3">New Research Questions and Case Submissions
                            </h4>
                            <p class="text">
                                Members are encouraged to bring forward new research questions and share interesting clinical cases or observations. These contributions spark collaborative discussions and can lead to the development of impactful research projects within the community.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="iconbox-style1 at-home14-v2 after_style p-0 text-center">
                        <div class="icon before-none"><span class="flaticon-web-design"></span></div>
                        <div class="details">
                            <h4 class="title fw-bold mt10 mb-3">BlueprintRx Journal Contributions
                            </h4>
                            <p class="text">
                                We are proud to introduce BlueprintRx, our quarterly white paper journal, where members can submit research insights, studies, and industry reports. From health economics to clinical research, pharmaceutical sciences, epidemiology, public health, and biomedical engineering, BlueprintRx is your platform to present completed projects, explore innovative ideas, and contribute to the evolving landscape of medical and scientific research.
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-4">
                    <div class="iconbox-style1 at-home14-v2  p-0 text-center">
                        <div class="icon before-none"><span class="flaticon-rocket"></span></div>
                        <div class="details">
                            <h4 class="title fw-bold mt10 mb-3">From Idea to Action</h4>
                            <p class="text">
                                From Idea to Action
Have a research idea but unsure of the next steps? Our platform connects you with mentors, resources, and collaborative brainstorming sessions to help shape your idea into a concrete project. MedResearch Ninja is here to guide you from concept to completion.
                            </p>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </section>

    <section class="hover-bgc-color section-padding overflow-hidden">
        <div class="container">
            <div class="row ">
                <div class="main-title">
                    <h2 class="title text-capitalize">Our  Activities</h2>
                </div>
                <div class="col-lg-8">
                    <div class="notice-wrap">
                        <div class="new-head1">
                            <h4>Notice Board</h4>
                        </div>
                        <div class="notice-body  ">
                            <div class="new-sec autoscroller">
                                <ul>

                                    <%=StrNotice %>
                                    <%-- <li><i class="fa fa-angle-double-right dark-color"></i>Upcoming Conferences and Webinars</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Research Grant Opportunities</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>New Research Publications</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Collaborative Research Opportunities</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Workshop and Training Sessions</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Community Achievements</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Call for Abstracts and Papers</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Clinical Trials and Studies Recruiting Participants</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Ethics and Compliance Updates</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Job and Internship Opportunities</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Recent Research Grants Awarded</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Member Spotlights and Interviews</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Important Deadlines and Reminders</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>New Research Tools and Resources</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Institutional Updates and Announcements</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Ethical Dilemmas and Discussions</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Clinical Case Studies and Reports</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Health Policy and Regulatory Changes</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Volunteering and Community Involvement</li>
                                    <li><i class="fa fa-angle-double-right dark-color"></i>Networking and Professional Development Events</li>--%>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="column ">
                        <div class=" ms-lg-auto">
                            <div class="price-widget">
                                <div class="navtab-style1">
                                    <nav>
                                        <div class="nav nav-tabs active mb20" id="nav-tab2p" role="tablist">
                                            <button class="nav-link active fw500" id="nav-item1p-tab" data-bs-toggle="tab" data-bs-target="#nav-item1p" type="button" role="tab" aria-controls="nav-item1p" aria-selected="true">Latest Discussion</button>
                                        </div>
                                    </nav>
                                    <div class="cant" id="nav-tabContent">
                                        <div class="tab-pane show  active new-one " id="nav-item1p" role="tabpanel" aria-labelledby="nav-item1p-tab">
                                            <a href="discussion-forum.aspx">

                                                <%=str3Forums %></a>
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

    <section class=" bgc-thm4  section-padding overflow-hidden  new-bg d-none">
        <div class="container">
            <div class="row align-items-center justify-content-center">
                <div class="col-md-12 col-lg-10 col-12 wow fadeInRight" style="visibility: visible; animation-name: fadeInRight;">
                    <div class="cta-style3 text-center">
                        <h4 class="cta-title text-white mb-4 ">Support MedResearch Ninja
                        </h4>
                        <div class="mt10 mb30 ">
                            <h1 class="text-white">Donate Now to support MedResearch Ninja
                                <br>
                                and the Sanmon Foundation.</h1>
                        </div>
                        <p class="cta-text text-white mb50">
                            Your donation can make a significant impact. By donating, you directly support our innovative research initiatives while contributing to the broader mission of the Sanmon Foundation, a non-profit organization dedicated to fostering positive change across various fields.

                        </p>
                        <a href="#" class="ud-btn btn-lg btn-dark default-box-shadow1  mr20">Donate Now <i class="fal fa-arrow-right-long"></i></a>

                        <h2 class="text-white mb40 mt50">Why Donate</h2>
                        <div class="row justify-content-center">
                            <div class="col-sm-6 col-md-6 col-lg-4">
                                <div class="funfact_one">
                                    <div class="details">
                                        <h4>Award winner</h4>
                                        <p class="text mb-0">
                                            Your donation funds pioneering studies that have the potential to transform healthcare.
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-4">
                                <div class="funfact_one">
                                    <div class="details">
                                        <h4>Empower Researchers</h4>
                                        <p class="text mb-0">
                                            Support talented scientists with the resources they need to make significant discoveries.

                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-4">
                                <div class="funfact_one">
                                    <div class="details">
                                        <h4>Contribute to Broader Causesr</h4>
                                        <p class="text mb-0">
                                            The Sanmon Foundation supports various initiatives beyond medical research, fostering positive change in multiple fields.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <%--  <div class="col-md-6 col-lg-4 wow fadeIn" style="visibility: visible; animation-name: fadeIn;">
                    <img class="home11-ctaimg-v3 at-home15 d-none d-md-block" src="images/about/about-16.png" alt="">
                    <img class="home15-ctaimg-v2 at-home17 d-none d-md-block" src="images/about/element-14.png" alt="">
                </div>--%>
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




    <script src="js/jquery-3.6.4.min.js"></script>

    <script>

        $(document).ready(function () {
            if (document.cookie.indexOf('med_uid') !== -1) {
                $('.joinUs').addClass('d-none');
            }
        });
        var div = $('.autoscroller');

        $('.autoscroller').bind('scroll mousedown wheel DOMMouseScroll mousewheel keyup', function (evt) {
            if (evt.type === 'mousewheel') {

            }
            if (evt.originalEvent.detail < 0 || (evt.originalEvent.wheelDelta && evt.originalEvent.wheelDelta > 0)) {
                clearInterval(autoscroller);
            }
            if (evt.originalEvent.detail > 0 || (evt.originalEvent.wheelDelta && evt.originalEvent.wheelDelta < 0)) {
                clearInterval(autoscroller);
            }
        });

        var autoscroller = setInterval(function () {
            var pos = div.scrollTop();
            if ((div.scrollTop() + div.innerHeight()) >= div[0].scrollHeight) {
                clearInterval(autoscroller);
            }
            div.scrollTop(pos + 1);
        }, 50);



    </script>
</asp:Content>


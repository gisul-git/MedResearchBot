<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="about-us.aspx.cs" Inherits="about_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }

        .header-top-home11 {
            background: #000 !important;
        }

        .breadcumb-section {
            padding: 0px 0px;
        }

        .freelancer-style1 {
            margin-bottom: 30px;
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

        .details i {
            font-size: 18px;
        }
        .thumb.new-thumb-img {
    height: 150px !important;
}
        .details {
            padding: 00px 10px;
        }


        .new-color {
            color: #ff7f3e;
        }

        .freelancer-style1.hover-box-shadow img {
            border-radius: 12px;
            height: 100%;
            width: 100%;
            object-fit:cover !important;
        }

        .thumb.mb30 {
            height: 300px;
            width: 100%;
        }

        .service-card-6 {
            height: 100%;
        }

            .service-card-6 .inner {
                border-radius: 5px;
                padding: 45px 35px;
                position: relative;
                z-index: 1;
                border: 1px solid #fff;
                height: 100%;
            }

                .service-card-6 .inner .icon {
                    position: relative;
                    display: inline-block;
                    margin-bottom: 15px;
                }

                    .service-card-6 .inner .icon img {
                        max-height: 60px;
                        filter: invert(1);
                    }

                .service-card-6 .inner .content {
                    padding-top: 10px;
                }

                    .service-card-6 .inner .content .title {
                        font-weight: 700;
                        font-size: 20px;
                        color: #fff;
                        line-height: 32px;
                        margin-bottom: 8px;
                        text-align: left;
                        transition: 0.4s;
                    }


                        .service-card-6 .inner .content .title a {
                            color: #fff;
                        }


                    .service-card-6 .inner .content .description {
                        margin-bottom: 0;
                        font-weight: 400;
                        text-align: left;
                        color: #fff;
                    }

                .service-card-6 .inner .number-text {
                    font-size: 100px;
                    font-weight: 800;
                    opacity: 0.05;
                    display: inline-block;
                    line-height: 70px;
                    position: absolute;
                    right: 15px;
                    top: 15px;
                    z-index: -1;
                }

        .funfact_one {
            padding: 25px 25px 25px 25px;
            transition: 0.5s all ease-in-out;
            position: relative;
            border-radius: 10px;
            position: relative;
            z-index: 1;
            display: flex;
            align-items: center;
            margin-bottom: 30px;
            border: 2px dashed #fff;
            box-shadow: 0 13px 48px 0 rgba(0, 0, 0, 0.24);
        }

            .funfact_one h4 {
                font-size: 22px;
                font-weight: 600;
            }

            .funfact_one p {
                min-height: 120px;
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

        @media (min-width:768px) and (max-width:991px) {

            .funfact_one p {
                min-height: 144px;
            }

            .funfact_one {
                padding: 25px 15px;
            }

            .new-min-hei {
                min-height: unset !important;
            }

            .thumb.mb30 {
                height: 300px !important;
                width: 100%;
            }
        }
        .new-font{
            font-size:14px;
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
                            <a href="#">About Us</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="hero-home19 section-padding">
        <div class="container">
            <div class="row align-items-center justify-content-between">
                <div class="col-xl-6 col-lg-6">

                    <div class=" wow fadeInRight" style="visibility: visible; animation-name: fadeInRight;">
                        <div class="main-title mb30 mb20-sm">

                            <h2 class="title ">Our Journey to
                            <span class="new-color">Medical Research</span></h2>

                            <p class="text animate-up-2">
Welcome to our dynamic research community, where passion meets purpose. We are dedicated to building a supportive and collaborative environment that empowers individuals to connect, share knowledge, and work together to advance health and well-being. Our commitment is to foster innovation in healthcare through meaningful research, cross-disciplinary collaboration, and a shared goal of improving patient outcomes.
                            </p>
                            <p class="text">
Our community is a diverse network of aspiring researchers, seasoned scientists, healthcare professionals, and students—all united by the drive to make a real impact in medicine. Together, we strive to bridge gaps in medical knowledge, bring new ideas to life, and support one another in the journey of discovery.</p>
                            <a href="signup.aspx" class="ud-btn btn-dark bdrs12 mt15 joinUs">Join Us Now</a>
                        </div>
                    </div>

                </div>
                <div class="col-xl-6 col-lg-5">
                    <img class="img-fluid bdrs20 wow fadeInLeft" src="images/about-img.png" alt="" style="visibility: visible; animation-name: fadeInLeft;">
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding pb-0 pt-0">
        <div class="container">
            <div class="row align-items-center wow fadeInUp" data-wow-delay="00ms" style="visibility: visible; animation-delay: 0ms; animation-name: fadeInUp;">
                <div class="col-md-12 col-12 col-lg-6">
                    <div class="find-work bg-light pb50 pt60  py30-sm px20 bdrs24 text-center mb30">
                        <img class="mb30" src="new-img/mission.png" alt="">
                        <h2 class="title mb30 mb-20-sm">Mission</h2>
                        <p class="text mb30">
                            At MedResearch Ninja, our mission is to empower and support medical students and aspiring clinicians in their research journeys. We strive to foster a collaborative environment where students can gain hands-on experience, develop critical research skills, and contribute to meaningful advancements in medical science. By providing access to resources, mentorship, and a global network, we aim to inspire the next generation of researchers to innovate and lead in the healthcare field.

                        </p>
                    </div>
                </div>
                <div class="col-md-12 col-12 col-lg-6">
                    <div class="find-work new0bg pb50 pt60 py30-sm px20 bdrs24 text-center mb30">
                        <img class="mb30" src="new-img/opportunity.png" style="filter: invert(1)" alt="">
                        <h2 class="title text-white mb30 mb-20-sm">Vision</h2>
                        <p class="text text-white mb30">
                            Our vision is to become a leading global student research community that drives excellence in medical research. We aspire to create a platform where every passionate medical student, regardless of their background, can engage in high-impact research, share knowledge, and contribute to improving healthcare outcomes worldwide. Through our commitment to innovation, collaboration, and education, we aim to shape the future of medicine by nurturing the researchers and leaders of tomorrow.

                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding bg-dark">
        <div class="container">
            <div class="row align-items-center wow fadeInUp" data-wow-delay="00ms" style="visibility: visible; animation-delay: 0ms; animation-name: fadeInUp;">
                <div class="col-lg-12 ">
                    <div class="main-title text-center">
                        <h2 class="title text-white">Our Community Values</h2>
                    </div>
                </div>

            </div>
            <div class="row gy-4 justify-content-center wow fadeInUp" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">



                <!-- Start Service Grid  -->
                                <div class="col-lg-6 col-xl-3 col-xxl-4 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/001-bulb.png" alt="icons Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="Javascript:void(0)">Integrity in Research
                                </a></h6>
                                <p class="description">
We are committed to maintaining ethical standards and honesty in all research activities, ensuring trustworthiness and reliability in our work.
                                </p>
                            </div>
                            <span class="number-text">1</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                                <div class="col-lg-6 col-xl-3 col-xxl-4 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/002-hat.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="Javascript:void(0)">Collaboration & Support
                                </a></h6>
                                <p class="description">

Our community thrives on teamwork. We foster a supportive environment where members can freely exchange ideas, ask questions, and learn from each other.

                                </p>
                            </div>
                            <span class="number-text">2</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                                <div class="col-lg-6 col-xl-3 col-xxl-4 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="new-img/003-id-card.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="Javascript:void(0)">Inclusivity & Accessibility
                                </a></h6>
                                <p class="description">
We believe in making research accessible to everyone, from beginners to experts. Our platform welcomes diverse perspectives, promoting equal opportunities for learning and growth.

                                </p>
                            </div>
                            <span class="number-text">3</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

                <!-- Start Service Grid  -->
                                <div class="col-lg-6 col-xl-3 col-xxl-4 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="images/e1.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="#">Continuous Learning</a></h6>
                                <p class="description">
We value curiosity and encourage members to stay updated with the latest advancements in science and research methodologies.




                                </p>
                            </div>
                            <span class="number-text">4</span>
                        </div>
                    </div>
                </div>
                                <div class="col-lg-6 col-xl-3 col-xxl-4 col-md-6 col-sm-6 col-12 mt--30">
                    <div class="service-card service-card-6">
                        <div class="inner">
                            <div class="icon">
                                <img src="images/e2.png" alt="Shape Images">
                            </div>
                            <div class="content">
                                <h6 class="title"><a href="Javascript:void(0)">Impactful Contributions</a></h6>
                                <p class="description">
Our goal is to drive research that makes a difference. We prioritize projects that address real-world challenges and have the potential to benefit communities globally.



                                </p>
                            </div>
                            <span class="number-text">5</span>
                        </div>
                    </div>
                </div>
                <!-- End Service Grid  -->

            </div>





        </div>
    </section>
    <section class="section-padding  overflow-hidden">
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-lg-8 mb30 text-lg-center text-start">
                    <h2 class="title">How We Work</h2>
                    <p class="text-dark">
                        At MedResearch Ninja, we are transitioning from a specialized project enrollment organization to a comprehensive platform that encourages broader research involvement and collaboration. As we expand our role, we are thrilled to unveil new opportunities for our members.
                    </p>
                </div>
            </div>
             
                        <div class="row  gy-4 justify-content-center process-flow">

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
    </section>
    <section class="section-padding bg-dark">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-12">
                    <div class="mb30">
                        <div class="main-title text-start mb30">
                            <h2 class="title text-white">Our  <span class="new-color">Story</span><br class="d-none d-xl-block">
                            </h2>
                        </div>
                    </div>
                    <p class="text-start text-white">MedResearch Ninja started in 2022 with Dr. Sweta’s goal to make research accessible and approachable for students like herself. As a medical student, she saw how challenging research could be and wanted to create a space where others could learn, connect, and grow in a supportive environment.</p>
                    <p class="text-start text-white">Over the years, our community has grown, with many students transitioning into residents who continue to stay connected, mentor others, and share their experiences. Watching our members progress in their careers has strengthened MedResearch Ninja, building a network of individuals who support each other’s journeys at every stage.</p>
                    <p class="text-start text-white">Today, MedResearch Ninja is a welcoming, evolving community that grows stronger every day as more members join, contribute, and carry forward the spirit of helping one another succeed in the world of research.</p>
                </div>
            </div>
            <div class="mt50">
                <div class="row 5 justify-content-center wow fadeInUp" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">
                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="funfact_one mb20-sm text-center">
                            <div class="details">
                                <ul class="ps-0 mb-0 d-flex justify-content-center">
                                    <li>
                                        <div class="timer text-white">350</div>
                                    </li>
                                    <li><span class="text-white">+</span></li>
                                </ul>
                                <h4 class="text-white mb20">Active Members</h4>
                                <p class="text-white">Our projects span across a wide range of specialties, including cardiology, oncology, neurology, and rare diseases, ensuring comprehensive coverage of medical research fields.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="funfact_one mb20-sm text-center">
                            <div class="details">
                                <ul class="ps-0 mb-0 d-flex justify-content-center">
                                    <li>
                                        <div class="timer text-white">200</div>
                                    </li>
                                    <li><span class="text-white">+</span></li>
                                </ul>
                                <h4 class=" text-white mb20">Engaged Researchers</h4>
                                <p class="text-white">Our projects span across a wide range of specialties, including cardiology, oncology, neurology, and rare diseases, ensuring comprehensive coverage of medical research fields.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-lg-4 col-md-12">
                        <div class="funfact_one mb20-sm text-center">
                            <div class="details">
                                <ul class="ps-0 mb-0 d-flex justify-content-center">
                                    <li>
                                        <div class="timer text-white">100</div>
                                    </li>
                                    <li><span class="text-white">+</span></li>
                                </ul>
                                <h4 class="text-white mb20">Projects Completed</h4>
                                <p class="text-white new-min-hei">Our projects span across a wide range of specialties, including cardiology, oncology, neurology, and rare diseases, ensuring comprehensive coverage of medical research fields.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="funfact_one mb20-sm text-center">
                            <div class="details">

                                <h4 class="text-white mb20">High Publication Success</h4>

                                <p class="text text-white mb-0">Over 80% of our projects have been published or presented in renowned journals and conferences, reflecting the high quality and impact of our research.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="funfact_one mb20-sm text-center">
                            <div class="details">

                                <h4 class="text-white mb20">Diverse Research Portfolio</h4>

                                <p class="text text-white mb-0">Our projects span across a wide range of specialties, including cardiology, oncology, neurology, and rare diseases, ensuring comprehensive coverage of medical research fields.</p>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>





    <section class="section-padding new0bg">
        <div class="container">
            <div class="row align-items-center wow fadeInUp">
                <div class="col-lg-12">
                    <div class="main-title tex-center">
                        <h2 class="title text-center text-white">Meet Our Core Team</h2>
                        <p class="paragraph text-center text-white">Precision in Every Discovery: Your Medical Research Ninjas</p>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/1.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title fw-bold mb-1">Dr. Sweta Sahu</h4>
                                <a href="https://www.linkedin.com/in/sweta-sahu-88a24089?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="images/user/1.png" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr. Udit Choubey 
                                </h4>
                                <a href="https://www.linkedin.com/in/dr-udit-choubey-mbbs-hons-35a039226?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/4.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">⁠Dr. Mihir M Parmar 
                                </h4>
                                <a href="https://www.linkedin.com/in/mihirpmr?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/6.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr. Roopeessh Vempati  
                                </h4>
                                <a href="https://www.linkedin.com/in/roopeessh-vempati-82557b95?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="images/user/user.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr. Anam Sayed 
                                </h4>
                                <a href="https://www.linkedin.com/in/anam-sayed-mushir-ali-2524461b5?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/5.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr.  Devarsh Shah 
                                </h4>
                                <a href="https://www.linkedin.com/in/devarsh-shah-a7011a1a6?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/3.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr. Harshal Chorya
                                </h4>
                                <a href="https://www.linkedin.com/in/harshal-c-ba93021b6?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="item">
                        <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                            <div class="thumb mb30">
                                <img class=" mx-auto" src="new-img/ourteam/7.jpg" alt="">
                            </div>
                            <div class="details d-flex justify-content-between align-items-center ">
                                <h4 class="title  fw-bold mb-1">Dr. Nishi Modi</h4>
                                <a href="https://www.linkedin.com/in/nishi-modi-ba6a1725a?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                            </div>
                        </div>
                    </div>
                </div>



            </div>
        </div>
    </section>
     <section class="section-padding new0bg pt-0">
     <div class="container">
         <div class="row align-items-center wow fadeInUp">
             <div class="col-lg-12">
                 <div class="main-title tex-center">
                     <h2 class="title text-center text-white">Meet Our Working Committee</h2>
                     <p class="paragraph text-center text-white">Precision in Every Discovery: Your Medical Research Ninjas</p>
                 </div>

             </div>
         </div>
         <div class="row">
             <%=strmembers %>
            <%-- <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/1.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title fw-bold mb-1 new-font">Dr. Sweta Sahu</h4>
                             <a href="https://www.linkedin.com/in/sweta-sahu-88a24089?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="images/user/1.png" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr. Udit Choubey 
                             </h4>
                             <a href="https://www.linkedin.com/in/dr-udit-choubey-mbbs-hons-35a039226?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/4.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">⁠Dr. Mihir M Parmar 
                             </h4>
                             <a href="https://www.linkedin.com/in/mihirpmr?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/6.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr. Roopeessh Vempati  
                             </h4>
                             <a href="https://www.linkedin.com/in/roopeessh-vempati-82557b95?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>

             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="images/user/user.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr. Anam Sayed 
                             </h4>
                             <a href="https://www.linkedin.com/in/anam-sayed-mushir-ali-2524461b5?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/5.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr.  Devarsh Shah 
                             </h4>
                             <a href="https://www.linkedin.com/in/devarsh-shah-a7011a1a6?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/3.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr. Harshal Chorya
                             </h4>
                             <a href="https://www.linkedin.com/in/harshal-c-ba93021b6?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>
             <div class="col-lg-2 col-md-6 col-12">
                 <div class="item">
                     <div class="freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow">
                         <div class="thumb new-thumb-img mb30">
                             <img class=" mx-auto" src="new-img/ourteam/7.jpg" alt="">
                         </div>
                         <div class="details d-flex justify-content-between align-items-center ">
                             <h4 class="title  fw-bold mb-1 new-font">Dr. Nishi Modi</h4>
                             <a href="https://www.linkedin.com/in/nishi-modi-ba6a1725a?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=ios_app"><i class="fa-brands fa-linkedin"></i></a>


                         </div>
                     </div>
                 </div>
             </div>--%>



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
    </script>

</asp:Content>


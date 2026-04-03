<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="whitepaper-details.aspx.cs" Inherits="whitepaper_details" %>

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

        .home3-hero {
            background-image: url(new-img/black.png);
            align-items: center;
            display: flex;
            height: 300px;
        }
         .listing-style1 .list-content {
     padding: 25px 15px !important;
 }
        .white-head {
            border-bottom: 1px solid #ff7f3e;
        }
        .new-margin{
            margin-top:50px;
        }
        .ud-btn1 i {
    margin-left: 10px;
    font-size: 16px;
    transform: rotate(0);
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
                            <a href="white-paper.aspx">Whitepaper</a>
                                                        <a href="#">Whitepaper Details</a>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="home3-hero">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-xl-7">
                    <div class="home3-hero-content pe-xl-5 position-relative zi1">
                        <h2 class="title text-thm2 animate-up-1"><span class="text-white">Blueprint</span><span>Rx</span></h2>

                    </div>
                </div>

            </div>

        </div>
    </section>
    <section class="section-padding mb10">
        <div class="container">
            <div class="row justify-content-center">
               
                <div class="col-lg-12">
                    <h2 class="mt30 mb10">Welcome to BlueprintRx – The MedResearch Ninja White Paper Journal</h2>
                    <p>BlueprintRx serves as a dynamic platform for students, pharmaceutical companies, clinicians, and other stakeholders in the medical and research fields to share and explore cutting-edge ideas and research findings. A white paper journal is a specialized publication that presents authoritative reports or proposals on various topics, providing detailed analysis, insights, and recommendations to guide decision-making and foster innovation.</p>
                    <p>Our journal will be published quarterly, offering timely and relevant content on a regular basis. BlueprintRx focuses on a broad range of research interests, including:</p>

                    <div class="ui-content">
                        <div class="list-style1">
                            <ul>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Health Economics: Evaluating the economic impact of healthcare policies and practices.</li>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Clinical Research: Advances in patient care, treatment methodologies, and clinical trials.</li>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Pharmaceutical Sciences: Innovations in drug development and therapeutics.</li>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Epidemiology: Studies on disease patterns, causes, and effects in populations.</li>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Public Health: Strategies for improving community health and wellness.</li>
                                <li><i class="fa-solid fa-check text-thm3 bgc-thm3-light"></i>Biomedical Engineering: Technological advancements in medical devices and diagnostics.</li>
                            </ul>
                        </div>
                    </div>
                    <p>We invite contributors from diverse backgrounds to submit their articles, whether they are research studies, opinion pieces, or industry reports. By showcasing these contributions, BlueprintRx aspires to create a valuable resource that informs, inspires, and drives progress in the medical and research communities.</p>

                    <strong>Join us in shaping the future of healthcare and research through BlueprintRx!</strong>
                    <div class="mt20">
                        <a href="submit-an-article.aspx" class="ud-btn btn-thm">SUBMIT AN ARTICLE NOW <i class="fal fa-arrow-right-long"></i></a>
                    </div>
                </div>
            </div>
            <div class="row new-margin">
                <%=StrWhitepapers %>

            </div>
        </div>
    </section>
</asp:Content>


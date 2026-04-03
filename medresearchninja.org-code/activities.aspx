<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="activities.aspx.cs" Inherits="activities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .freelancer-style1.hover-box-shadow img {
            border-radius: 12px;
            height: 100%;
            width: 100%;
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

        .notice-body ul {
            padding: 20px 20px;
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
            background: #ff7f3e;
        }

        .notice-wrap {
            box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px;
            padding: 0px 0px;
            border-radius: 16px;
        }

        .new-head {
            text-align: center;
            background: #ff7f3e;
            padding: 10px 20px;
        }

            .new-head h4 {
                margin-bottom: 0px;
                color: #fff
            }

        .new-sec {
            background: #f1f1f1;
            padding: 20px;
        }

        p {
            color: #444444;
            background-color: #eeeeee;
            font-size: 16px;
            font-variant: normal;
            text-transform: none;
            letter-spacing: 0px;
            word-spacing: 5px;
            text-align: justify;
        }

      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="breadcumb-section wow fadeInUp position-relative" style="background: url(new-img/5939101-ai.png)">
        <div class="cta-commmon-v1 cta-banner  mx-auto maxw1700 pt120 pb120  position-relative overflow-hidden d-flex align-items-center mx20-lg">

            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-6">
                        <div class="position-relative text-center wow fadeInUp" data-wow-delay="300ms">
                            <h2 class="">Activities</h2>
                            <div class="breadcumb-style1">
                                <div class="breadcumb-list">
                                    <a href="Default.aspx">Home</a>
                                    <a href="#">Activities </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <div class="notice-wrap">
                        <div class="new-head">
                            <h4>Notice Borad</h4>
                        </div>
                        <div class="notice-body ">
                            <div class="new-sec">
                                <p>
                                    Indexing for the year 2019 of all the journals in Index Copernicus will be updated in May June 2020, This is the official process followed by Index Copernicus every year. Till then ICV value and indexing of the year 2018 will be valid. Kindly click here

                                </p>
                                <div class="notice highlight">
                                    <h3>Enjoy the free services
                                    </h3>

                                    <p>
                                        We provides a perfect platform to publish your requirements on versatile need. All the publishing services except journals and books are absolutely free. For more details please contact us at editor@medresearch.in.

                                    </p>

                                </div>

                                <div class="notice">
                                    <h3>Publish your blog
                                    </h3>
                                    <p>
                                        Along with the publication of journals and books, we also promote the publication of writers and authors who have a real zeal of writing blog posts. Along with the suggested topics, one can go for the publication of their blogs on other versatile topics. Email us the details at editor@medresearch.in

                                    </p>
                                </div>

                                <div class="notice">
                                    <h3>Publish your profile
                                    </h3>
                                    <p>
                                        You may require such a platform to publish your profile where you can reach to the professionals of health care. We are a publisher website which encounters with the visit of many authors, researchers of medical health science, academicians to reach them for many purposes. With the publication of your profile, you can reach them for campaigning or other purposes. Email us the details at editor@medresearch.in

.
                                    </p>
                                </div>
                                                                <div class="notice">
                                    <h3>Conference/ Webinar Alert

                                    </h3>
                                    <p>
We provides a platform for the researchers, readers, academicians, and others; a perfect platform to collaborate their thoughts. It witnesses the visit of many researchers daily onboard. This could help to publicize your conferences/webinars among them to get maximum no. of participants. With us, you can publicize your conferences/ webinars absolutely free of charge. Mail us the details at editor@medresearch.in


.
                                    </p>
                                </div>
                                                                                                <div class="notice">
                                    <h3>Journals, Book and Blogs


                                    </h3>
                                    <p>
We invites the writers who have real zeal in writing. We are providing all the possible platforms for the publication of Book, Journal, and Blogs. Please contact us for the details at editor@medresearch.in



.
                                    </p>
                                </div>



                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="column ">
                        <div class="blog-sidebar ms-lg-auto">
                            
                            <div class="price-widget pt25 bdrs8">

                                <img src="/new-img/donate.jpg" class="img-fluid mb-3">
                                <i class="text fz16 mt-5 fw-bold ">Support Pioneering Medical Research: Donate Now to Make a Difference!</i>
                                <div class="d-grid mt-4">
                                    <a href="signup.aspx" class="ud-btn btn-thm">Join Us Now<i class="fal fa-arrow-right-long"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blog-details.aspx.cs" Inherits="blog_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }

        .breadcumb-section {
            padding: 0px 0px;
        }

        .listing-style1 .list-content {
            padding: 20px 15px;
        }

        .logos.me-4 {
            position: absolute;
        }


        .list-sidebar-style1.d-none.d-lg-block {
            position: sticky;
            top: 0px;
        }

        .new-li {
            display: flex;
            gap: 1rem;
            padding-left: 0px;
            justify-content: start;
        }

            .new-li li {
                color: #fff;
            }

                .new-li li a {
                    color: #fff;
                }

        .budget {
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
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

        .date {
            background: #f1f1f1;
            border-radius: 4px;
            width: max-content;
            color: #222222;
            padding: 5px 10px;
            cursor: pointer;
            margin-bottom: 10px;
        }

        .ud-btn1 i {
            margin-left: 10px;
            font-size: 16px;
            transform: rotate(0) !important;
        }

        .dropdown-lists .open-btn {
            display: none;
        }

        .blog-details-card {
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            padding: 20px;
            border-radius: 8px;
        }

        .blog-section .blog-heading h1 {
            margin-bottom: 22px;
        }

        .blog-body img {
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--  Start contact-info  -->
    <section class="breadcumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcumb-style1">
                        <div class="breadcumb-list">
                            <a href="/">Home</a>
                            <a href="/blogs">Blogs</a>
                            <a href="javascript:void(0);"><%=StrBlogTitle %></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding blog-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12">
                    <div class="blog-heading mb-4">
                        <div class="blog-details-card">
                            <h1><%=StrBlogTitle %></h1>

                            <div class="d-flex justify-content-between blog-sub-head">
                                <div class="blog-tags">
                                    <span class="sep-line">| </span>

                                    <span><%=StrPostedOn %></span>
                                    <span class="sep-line">| </span>

                                    <span>By
                                            <a href="javascript:void(0);" contenteditable="false" style="cursor: pointer;"><%=StrPostedBy %></a>
                                    </span>
                                </div>
                                <div class="share-icons">
                                    <a href="javascript:void(0);" contenteditable="false" style="cursor: pointer;">Share :  </a>
                                    <a href="https://twitter.com/intent/tweet?url=<%=strBlogUrl %>" contenteditable="false" style="cursor: pointer;" class="social-links"><i class="fab fa-x-twitter"></i></a>|
                                <a href="https://www.facebook.com/sharer.php?u=<%=strBlogUrl %>" contenteditable="false" style="cursor: pointer;" class="social-links"><i class="fab fa-facebook-f"></i></a>|
                                <a href="https://www.linkedin.com/shareArticle?url=<%=strBlogUrl %>" contenteditable="false" style="cursor: pointer;" class="social-links"><i class="fab fa-linkedin-in"></i></a>
                                </div>
                            </div>


                            <div class="blog-body">
                                <div class="mb-4">
                                    <div class="blog-img">
                                        <img src="/<%=StrImgUrl %>" alt="Blog Image" />
                                    </div>
                                </div>
                                <div>
                                    <div class="blog-detail-para">
                                        <%=StrDesc %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>



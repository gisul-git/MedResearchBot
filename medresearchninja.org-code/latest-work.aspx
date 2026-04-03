<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="latest-work.aspx.cs" Inherits="latest_work" %>

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
    </style>
    <link rel="stylesheet" href="https://cdn.materialdesignicons.com/5.4.55/css/materialdesignicons.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="breadcumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcumb-style1">
                        <div class="breadcumb-list">
                            <a href="Default.aspx">Home</a>
                            <a href="#">Community</a>

                            <a href="#">Latest Projects</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <!-- Listings All Lists -->
    <section class="section-padding">
        <div class="container">
            <div class="row wow fadeInUp">

                <div class="col-lg-12">
                    <div class="row justify-content-center align-items-center mb20">

                        <div class="col-md-6">
                            <div class="page_control_shorting d-md-none d-block align-items-center justify-content-center justify-content-md-center">
                                <div class="dropdown-lists d-block d-lg-none me-2 mb10-sm">
                                    <ul class="p-0 mb-0 text-center text-md-start">
                                        <li>
                                            <!-- Advance Features modal trigger -->
                                            <button type="button" class="open-btn filter-btn-left">
                                                <img class="me-2" src="images/icon/all-filter-icon.svg" alt="">
                                                All Filter</button>
                                        </li>
                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <%=strProjects %>
                    </div>
                    <div class="row mt-2">
                        <div class="col-lg-12 text-center">
                            <h4 style="font-style:italic">We’re proud to showcase our growing collection of published projects. While we can’t feature them all, we’ve selected a few recent highlights to reflect their impact and keep you updated.</h4>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Download Latest Projects</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="fourm">
                        <div class="row">
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb20">
                                    <div class="form-style1">
                                        <input type="text" class="form-control" placeholder="Full Name">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb20">
                                    <div class="form-style1">
                                        <input type="email" class="form-control" placeholder="Email">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb20">
                                    <div class="form-style1">
                                        <input type="text" class="form-control" placeholder="Contact Number">
                                    </div>
                                </div>
                            </div>

                            <div class="mt10">
                                <button class="ud-btn bgc-thm text-white bdr1 default-box-shadow2 w-100" type="button">Download <i class="fal fa-arrow-right-long"></i></button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="blogs.aspx.cs" Inherits="blogs" %>

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


        .page-item.active .page-link {
            background-color: #ff7f3e;
            border: 1px solid #ff7f3e;
        }

        .fa-angle-left, .fa-angle-right {
            color: #ff7f3e;
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
                            <a href="/">Home</a>
                            <a href="/blogs">Blogs</a>
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
                    <div class="row" id="BlogListBindingSec">
                        <%--    <div class='col-sm-6 col-xl-3'>
                            <div class='listing-style1 bdrs16'>
                                <div class='list-thumb'>
                                    <img class='w-100' src='/UploadImages/4d84e0b6-2d38-4c70-b496-849d9ae58ea6-sample.png' alt=''>
                                </div>
                                <div class='list-content'>
                                    <p class='list-text body-color fz14 mb20 mb10-sm fw-bold'>Admin | 12-02-1212</p>
                                    <h5 class='list-title'>Test</h5>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-6 col-xl-3">
                            <div class="listing-style1 bdrs16">
                                <div class="list-thumb">
                                    <img class="w-100" src="/UploadImages/4d84e0b6-2d38-4c70-b496-849d9ae58ea6-sample.png" alt="">
                                </div>
                                <div class="list-content">
                                    <p class="list-text body-color fz14 mb20 mb10-sm fw-bold">Admin | 12-02-1212</p>
                                    <h5 class="list-title">Test</h5>
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-6 col-xl-3">
                            <div class="listing-style1 bdrs16">
                                <div class="list-thumb">
                                    <img class="w-100" src="/UploadImages/4d84e0b6-2d38-4c70-b496-849d9ae58ea6-sample.png" alt="">
                                </div>
                                <div class="list-content">
                                    <p class="list-text body-color fz14 mb20 mb10-sm fw-bold">Admin | 12-02-1212</p>
                                    <h5 class="list-title">Test</h5>
                                </div>

                            </div>
                        </div>--%>
                    </div>
                    <div class="row mt-3">
                        <div class="col-lg-12">
                            <div class="d-flex justify-content-center">
                                <nav aria-label="Page navigation example">
                                    <ul class="pagination pPagination">
                                        <li class="page-item left"><a class="page-link" href="javascript:void(0);"><i class="fa fa-angle-left"></i></a></li>
                                        <li class="page-item left"><a class="page-link" href="javascript:void(0);"><i class="fa fa-angle-right"></i></a></li>
                                    </ul>
                                </nav>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <script src="/js/jquery-3.6.0.min.js"></script>
    <script src="/js/Pages/blogs.js"></script>
</asp:Content>




<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay-project-due.aspx.cs" Inherits="pay_project_due" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- css file -->
    <link rel="shortcut icon" href="/new-img/fab.png" type="image/x-icon" />

    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/jquery-ui.min.css" />
    <link rel="stylesheet" href="/css/ace-responsive-menu.css" />
    <link rel="stylesheet" href="/css/menu.css" />
    <link rel="stylesheet" href="/css/fontawesome.css" />
    <link rel="stylesheet" href="/css/flaticon.css" />
    <link rel="stylesheet" href="/css/bootstrap-select.min.css" />
    <link rel="stylesheet" href="/css/animate.css" />
    <link rel="stylesheet" href="/css/slider.css" />
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/css/ud-custom-spacing.css" />
    <link href="/js/snackbar/snackbar.min.css" rel="stylesheet" />
    <!-- Responsive stylesheet -->
    <link rel="stylesheet" href="css/responsive.css" />
    <!-- Title -->
    <title>Pay Now | MedResearch Ninja </title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.6.0/css/all.min.css" integrity="sha512-Kc323vGBEqzTmouAECnVceyQqyqdsSiqLQISBL29aUW4U/M7pSPA/gEUZQqv1cwx4OnYxTxve5UMg5GT6L4JJg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- Favicon -->

    <style>
        .header-logo img {
            width: 150px;
        }

        .pay-card {
            padding: 20px;
            border: 2px dotted #000;
            box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
        }

        .section-title {
            margin-bottom: 30px;
        }

        .pay-details.d-flex.align-items-center {
            margin-bottom: 10px;
            border-bottom: 1px solid #000;
        }

        .pay-left h4 {
            font-weight: 700;
        }

        @media (min-width:320px) and (max-width:767px) {
            .mobile_logo img {
                width: 120px;
            }

            .mobile-menu {
                background: #000;
            }

            .menubar img {
                filter: invert(1);
            }

            .pay-left h4 {
                font-size: 14px !important;
            }

            .pay-right h4 {
                font-size: 14px !important;
            }
        }

        @media (min-width:768px) and (max-width:991px) {
            .mobile_logo img {
                width: 120px;
            }

            .mobile-menu {
                background: #000;
            }

            .menubar img {
                filter: invert(1);
            }
        }

        .btn-danger {
            color: #fff;
            background-color: #ff7f3e;
            border-color: #ff7f3e;
        }

        .p-details p {
            color: #fff !important;
        }
    </style>
</head>
<body>
    <div class="page-wrapper">
        <div class="new-head">
            <header class="header-nav nav-homepage-style main-menu border-0">
                <nav class="posr">
                    <div class="container posr">
                        <div class="row align-items-center justify-content-between">
                            <div class="col-auto">
                                <div class="logos d-flex justify-content-start align-items-center ">
                                    <a class="header-logo logo1" href="/">
                                        <img src="/new-img/logo4.png" alt="Header Logo" /></a>
                                    <a class="header-logo logo2" href="/">
                                        <img src="/new-img/logo4.png" alt="Header Logo" /></a>
                                </div>
                            </div>
                            <div class="col-lg-8 px-0 ">
                                <div class="d-flex align-items-center justify-content-end">
                                    <ul id="respMenu" class="ace-responsive-menu" data-menu-style="horizontal">
                                        <li class="visible_list"><a class="list-item" href="/"><span class="title">Home</span></a></li>
                                        <li class="visible_list"><a class="list-item" href="/about-us.aspx"><span class="title">About Us</span></a></li>
                                        <li class="visible_list"><a class="list-item" href="javascript:void(0);"><span class="title">Community</span></a>
                                            <ul>
                                                <li><a href="/latest-work.aspx">Latest Projects</a></li>
                                                <li><a href="/discussion-forum.aspx">Discussion Forum</a></li>
                                                <li><a href="/white-paper.aspx">Whitepaper Journel </a></li>
                                                <li><a href="/resources.aspx">Resources </a></li>
                                                <li><a href="/case-submission.aspx">Submit a Topic </a></li>
                                            </ul>
                                        </li>
                                        <li class="visible_list"><a class="list-item" href="/testimonials.aspx">Testimonials</a></li>
                                        <li class="visible_list"><a class="list-item" href="/career.aspx">Career </a></li>
                                        <li class="visible_list"><a class="list-item" href="/contact-us.aspx">Contact Us</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </nav>
            </header>
        </div>

        <div id="page" class="mobilie_header_nav stylehome1">
            <div class="mobile-menu">
                <div class="header bdrb1">
                    <div class="menu_and_widgets">
                        <div class="mobile_menu_bar d-flex justify-content-between align-items-center">
                            <a class="mobile_logo" href="/">
                                <img src="/new-img/logo4.png" alt="" /></a>
                            <div class="right-side text-end">
                                <a class="menubar ml30" href="#menu">
                                    <img src="/images/mobile-dark-nav-icon.svg" alt="icon" /></a>
                            </div>
                        </div>
                    </div>
                    <div class="posr">
                        <div class="mobile_menu_close_btn"><span class="far fa-times"></span></div>
                    </div>
                </div>
            </div>
            <!-- /.mobile-menu -->
            <nav id="menu">
                <ul>
                    <li><a href="/">Home</a>

                    </li>
                    <li><span>Community</span>
                        <ul>
                            <li><a href="/latest-work.aspx">Latest Projects</a></li>
                            <li><a href="/discussion-forum.aspx">Discussion Forum</a></li>
                            <li><a href="/white-paper.aspx">Whitepaper</a></li>
                            <li><a href="/resources.aspx">Resources</a></li>
                            <li><a href="/case-submission.aspx">Submit a Topic </a></li>
                        </ul>
                    </li>
                    <li><a href="/about-us.aspx">About Us</a>
                    </li>
                    <li><a href="/testimonials.aspx">Testimonials </a>
                    </li>
                    <li><a href="/career.aspx">Career</a>
                    </li>
                    <li><a href="/contact-us.aspx">Contact Us</a>

                    </li>

                </ul>
            </nav>
        </div>

        <div>
            <div class="section-padding">
                <div class="container p-t80">

                    <!-- Checkout Start -->
                    <div class="checkout-wrapper">
                        <div class="row justify-content-center">
                            <div class="col-lg-12">
                                <div class="pay-card p-4 border rounded shadow-sm" style="background-color: #fff; color: #000;">

                                    <div class="section-title text-center mb-4">
                                        <h1 class="title">Payment</h1>
                                    </div>

                                    <div class="row justify-content-center">
                                        <div class="col-md-8 text-center p-4 border rounded" style="background-color: #111;">

                                            <!-- 1. Logo -->
                                            <img src="/new-img/logo4.png" alt="Company Logo" class="mb-3" style="max-width: 180px;" />

                                            <!-- 2. Title -->
                                            <h4 class="mb-4 text-white">Complete Your Payment</h4>

                                            <!-- 3. Payment Details -->
                                            <!-- Modify the payment section -->
                                            <div class="text-start mb-3 mb-4 text-white p-details">
                                                <p><strong>Project Code:</strong> <%=ProjectCode %></p>
                                                <p><strong>Project Name:</strong> <%=Projectname %></p>
                                                <p><strong>User Name:</strong> <%=buyerName %></p>
                                                <p><strong>Email ID:</strong> <%=buyerEmail %></p>
                                                <p><strong>Contact:</strong> <%=BuyerMobile %></p>
                                                <% if (!IsPayPalPayment)
                                                    { %>
                                                <p><strong>Total Amount:</strong> <%=strTotal %></p>
                                                <% }
                                                    else
                                                    { %>
                                                <p>
                                                    <strong>Total Amount:</strong> <%=strTotal %>
                                                    <small class="text-muted">(Approx. $<%=Math.Round(Convert.ToDecimal(strTotal.Replace("₹", "").Replace(",", "")) * 0.012M, 2) %>)
            </small>
                                                </p>
                                                <% } %>
                                            </div>

                                            <% if (!IsPayPalPayment)
                                                { %>
                                            <!-- PayU Form -->
                                            <form action='<%=ConfigurationManager.AppSettings["ENVURL"] %>_payment' method='post'>
                                                <input type="hidden" name="key" value="<%=strKey %>" />
                                                <input type="hidden" name="txnid" value="<%=strTRid %>" />
                                                <input type="hidden" name="productinfo" value="<%=strPInfo %>" />
                                                <input type="hidden" name="amount" value="<%=strAmount %>" />
                                                <input type="hidden" name="email" value="<%=strEmail %>" />
                                                <input type="hidden" name="firstname" value="<%=strFName %>" />
                                                <input type="hidden" name="surl" value="<%=strSUrl %>" />
                                                <input type="hidden" name="furl" value="<%=strFUrl %>" />
                                                <input type="hidden" name="phone" value="<%=strPhone %>" />
                                                <input type="hidden" name="hash" value="<%=strHash %>" />

                                                <!-- Payment Button -->
                                                <input type="submit" value="Proceed to Pay" class="btnpay btn btn-danger text-white px-4 py-2 mt-3" />
                                            </form>
                                            <% }
                                                else
                                                { %>
                                            <!-- PayPal Redirect Message -->
                                            <div class="text-center">
                                                <div class="spinner-border text-primary mb-3" role="status">
                                                    <span class="sr-only">Loading...</span>
                                                </div>
                                                <p class="text-white">Redirecting to PayPal...</p>
                                            </div>
                                            <% } %>

                                            <!-- 6. Instruction -->
                                            <p class="mt-3 text-light" style="font-size: 13px;">
                                                Please do not refresh or press back during payment processing.
                                            </p>

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- jQuery for Styling (if needed) -->
                    <script src="/js/jquery-3.6.4.min.js"></script>
                    <script>
                        $(document).ready(function () {
                            $(".btnpay").addClass("text-uppercase");
                        });
                    </script>


                    <!-- jQuery for Styling (if needed) -->
                    <script src="/js/jquery-3.6.4.min.js"></script>
                    <script>
                        $(document).ready(function () {
                            $(".btnpay").addClass("text-uppercase");
                        });
                    </script>


                    <!-- jQuery for Styling (if needed) -->
                    <script src="/js/jquery-3.6.4.min.js"></script>
                    <script>
                        $(document).ready(function () {
                            $(".btnpay").addClass("text-uppercase");
                        });
                    </script>

                </div>
            </div>
        </div>
    </div>

    <!-- Our Footer -->
    <section class="footer-style1 at-home6 bg-dark section-padding pb-0">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-5">
                    <div class="link-style1 mb-4 mb-sm-5">
                        <h5 class="text-white mb15">Contact Info</h5>
                        <a class="app-list d-flex align-items-center mb20" href="mailto:connect@medresearchninja.com">
                            <i class="fa-solid fa-envelope mr15"></i>
                            <h6 class="app-title fz15 fw400 mb-0">connect@medresearchninja.com</h6>
                        </a>
                        <a class="app-list d-flex align-items-center mb20" href="tel:+919364040500">
                            <i class="fa-solid fa-phone mr15"></i>
                            <h6 class="app-title fz15 fw400 mb-0">+91 9364040500</h6>
                        </a>
                        <a class="app-list d-flex align-items-center mb20 " href="https://wa.me/+919364040500">
                            <i class="fa-brands fa-whatsapp mr15"></i>
                            <h6 class="app-title fz15 fw400 mb-0">Connect on whatsapp</h6>
                        </a>
                    </div>
                </div>

                <div class="col-md-3 col-lg-2">
                    <div class="link-style1 mb-4 mb-sm-5">
                        <h5 class="text-white mb15">Quick Links</h5>
                        <ul class="ps-0">
                            <li><a href="/about-us.aspx">About Us</a></li>
                            <li><a href="/career.aspx">Career</a></li>
                            <li><a href="/testimonials.aspx">Testimonials   </a></li>
                        </ul>
                    </div>
                </div>

                <div class="col-md-3 col-lg-2">
                    <div class="link-style1 mb-4 mb-sm-5">
                        <h5 class="text-white mb15">Community</h5>
                        <ul class="ps-0">
                            <li><a href="/white-paper.aspx">Whitepaper</a></li>
                            <li><a href="/discussion-forum.aspx">Discussion Forum</a></li>
                            <li><a href="/resources.aspx">Resources</a></li>

                            <li><a href="/latest-work.aspx">Latest Projects</a></li>
                            <li><a href="/case-submission.aspx">Submit a Topic</a></li>
                        </ul>
                    </div>
                </div>

                <div class="col-md-12 col-lg-4">
                    <div class="footer-widget">
                        <div class="footer-widget ">
                            <div class="mailchimp-widget">
                                <h5 class="title text-white mb20">Subscribe Now</h5>
                                <span class="spnmail text-danger"></span>
                                <div class="mailchimp-style1 at-home11">
                                    <input runat="server" textmode="email" type="email" class="form-control txtmail" id="txtmail" placeholder="Your email address" />
                                    <button type="submit" class="btnmail">Send</button>
                                </div>
                            </div>
                        </div>
                        <div class="social-widget mt20 ">
                            <div class="social-style1">
                                <a class=" text-white me-2 fw500 fz17" href="javascript:void(0);">Follow us</a>
                                <a href="javascript:void(0);"><i class="fab fa-facebook-f list-inline-item"></i></a>
                                <a href="javascript:void(0);"><i class="fab fa-twitter list-inline-item"></i></a>
                                <a href="javascript:void(0);"><i class="fab fa-instagram list-inline-item"></i></a>
                                <a href="javascript:void(0);"><i class="fab fa-linkedin-in list-inline-item"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container white-bdrt1 py-4">
            <div class="row">
                <div class="col-md-6">
                    <div class="text-center text-lg-start">
                        <p class="copyright-text mb-0 text-white-light ff-heading">© 2024 MedResearch Ninja. All rights reserved.</p>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="text-center text-lg-end">
                        <p class="copyright-text mb-0 text-white-light ff-heading">Website Designed By <a href="https://www.nextwebi.com/" class="new-color">Nextwebi</a></p>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <a class="scrollToHome at-home2" href="javascript:void(0);"><i class="fas fa-angle-up"></i></a>
    <script src="/js/jquery-3.6.4.min.js"></script>
    <script src="/js/snackbar/snackbar.min.js"></script>
    <script src="/js/popper.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/bootstrap-select.min.js"></script>
    <script src="/js/jquery.mmenu.all.js"></script>
    <script src="/js/ace-responsive-menu.js"></script>
    <script src="/js/jquery-scrolltofixed-min.js"></script>
    <script src="/js/wow.min.js"></script>
    <script src="/js/owl.js"></script>
    <script src="/js/isotop.js"></script>
    <script src="/js/script.js"></script>
    <script src="/js/jquery-migrate-3.0.0.min.js"></script>
</body>
</html>

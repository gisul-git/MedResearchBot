<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="white-paper.aspx.cs" Inherits="white_paper" %>

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
         .listing-style1{
        box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
    border-radius: 5px;
    border: 2px dashed #ff7f3e;
    background: #fff;}

        .new-li {
            display: flex;
            gap: 1rem;
            padding-left: 0px;
            justify-content: start;
        }

        .listing-style1 .list-title {
            margin-bottom: 15px;
            font-size: 20px;
        }

        .listing-style1 img {
            -webkit-transition: all 0.4s ease;
            padding: 20px 20px 20px 20px;
            -moz-transition: all 0.4s ease;
            -ms-transition: all 0.4s ease;
            -o-transition: all 0.4s ease;
            transition: all 0.4s ease;
            border-radius: 24px;
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

        .bootstrap-select:not([class*=col-]):not([class*=form-control]):not(.input-group-btn) .btn, .bootstrap-select:not([class*=col-]):not([class*=form-control]):not(.input-group-btn) .btn-light {
            background-color: #fff;
        }

        .new-input-head1 {
            padding: 10px 20px;
            background: #ff7f3e;
            margin: 0px 0px;
            border-left: 3px solid #ff7f3e;
            border-right: 3px solid #ff7f3e;
            text-align: center;
        }

            .new-input-head1 h5 {
                margin-bottom: 0px;
                color: #fff;
            }

        .new-input-head {
            padding: 10px 20px;
            background: #f1f1f1;
            margin: 20px 0px;
            border-left: 3px solid #ff7f3e;
        }

            .new-input-head h5 {
                margin-bottom: 0px;
            }

        .form-check-inline {
            display: flex;
            align-items: center;
            gap: .5rem;
        }

        .textAreaContainer {
            display: none; /* Initially hide the text area container */
        }
        .listing-style1 .list-content{
            padding:25px 25px;
        }
        
       .new-fade .modal:before{
           backdrop-filter:blur(10px);
       }
   </style>
  <style>
       .new-fade .modal:before{
           backdrop-filter:blur(10px);
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
                            <a href="#">Community</a>
                            <a href="#">Whitepaper</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="bg-light">
        <div class="container">

            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="listing-style1 default-box-shadow1 bdrs8">

                        <div class="row align-items-center">

                            <div class="col-lg-6">
                                <div class="">
                                    <img class="w-100 " src="new-img/blue.png"  alt="">
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="list-content">
                                    <p class="list-text body-color fz14 mb-1"></p>
                                    <h3 class="mb10 fw-bold"><a href="whitepaper-details.aspx">Welcome to BlueprintRx – The MedResearch Ninja White Paper Journal</a></h3>
                                    <p>BlueprintRx serves as a dynamic platform for students, pharmaceutical companies, clinicians, and other stakeholders in the medical and research fields to share and explore cutting-edge ideas and research findings.</p>
                                   <hr class="my-2">
                                    <div class="list-meta d-flex justify-content-between align-items-center mt15">
                                        <a href="whitepaper-details.aspx" class="ud-btn2 text-dark mt-2">Read More <i class="fal fa-arrow-right-long"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>


            </div>

        </div>
    </section>
       <div class="new-fade">
    <div class="modal fade" id="exampleModal1"  data-bs-backdrop="static" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body text-center p-5">
                    <h2>Login to Continue</h2>
                    <a href="login.aspx" class="ud-btn btn-thm mt-4 default-box-shadow2">
                        Login <i class="fal fa-arrow-right-long"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
     <script src="/js/jquery-3.6.4.min.js"></script>
  <%--  <script>
        
        $(window).on('load', function () {
            var isLoggedIn = document.cookie.indexOf('med_uid=') !== -1;

            if (!isLoggedIn) {
                $('#exampleModal1').modal('show');
            }
        });
    </script>
  --%>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .bg-dark {
            background: #000 !important;
        }

        .testimonial .details {
            height: 205px;
            overflow: auto;
        }

        .testimonial-style1 .t_content {
            line-height: 25px;
            font-size: 18px;
        }



        .testimonial::after {
            content: "";
            border: 8px solid black;
            border-radius: 50px;
            width: 85%;
            height: 120%;
            position: absolute;
            z-index: -1;
            left: 1.5em;
            top: -2em;
        }
   

        .testimonial::before {
            content: "";
            position: absolute;
            bottom: -6.1em;
            left: 5em;
            z-index: 1;
            width: 0;
            height: 0;
            border-style: solid;
            border-width: 70px 100px 0 0;
            border-color: black transparent transparent transparent;
        }

        .quote {
            position: absolute;
            font-size: 3em;
            width: 40px;
            height: 40px;
            background: black;
            color: #fff;
            text-align: center;
            line-height: 1.25;
        }

            .quote.open {
                top: 0;
                left: 0;
            }

            .quote.close {
                bottom: 0;
                right: 0;
            }

        .testimonial p {
            width: 100%;
            display: inline-block;
        }



        .source {
            width: 100%;
            height: 100%;
            position: relative;
        }

            .source span {
                display: inline-block;
                font-weight: bold;
                font-size: 18px;
                color: #000;
                position: relative;
                margin-left: 1rem;
                text-align: right;
            }

                .source span::before {
                    content: "\2014";
                    display: inline;
                    margin-right: 5px;
                }

        .image {
            transform: rotate(-5deg);
            position: absolute;
            top: 0.5em;
            right: 1.5em;
        }

            .image img {
                border: 10px solid #fff;
                margin: 0;
                padding: 0;
            }

        .clip {
            border: 2px solid #222;
            border-right: none;
            height: 75px;
            width: 20px;
            position: absolute;
            right: 30%;
            top: -15%;
            border-radius: 25px;
        }

            .clip::before {
                content: "";
                position: absolute;
                top: -1px;
                right: 0;
                height: 10px;
                width: 16px;
                border: 2px solid #222;
                border-bottom: none;
                border-top-left-radius: 25px;
                border-top-right-radius: 25px;
                z-index: 99;
            }

            .clip::after {
                content: "";
                position: absolute;
                bottom: -1px;
                right: 0;
                height: 40px;
                width: 16px;
                border: 2px solid #222;
                border-top: none;
                border-bottom-left-radius: 25px;
                border-bot
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
        .testimonial{
            padding:unset !important;margin-bottom:unset !important;
        }
        .testimonial-bg {
            border: 10px solid #66e1e3;
            padding: 44px 40px;
            text-align: center;
            position: relative;
        }

            .testimonial-bg:before {
                content: "\f10d";
                font-family: "fontawesome";
                width: 75px;
                height: 75px;
                line-height: 75px;
                background: #fff;
                text-align: center;
                font-size: 50px;
                color: #3c414c;
                position: absolute;
                top: -40px;
                left: 2%;
            }

        .testimonial {
            padding: 0 15px;
        }

            .testimonial .description {
                font-size: 20px;
                font-weight: 400;
                font-style: italic;
                color: #848484;
                line-height: 30px;
                padding-bottom: 25px;
                margin-bottom: 15px;
                position: relative;
            }

                .testimonial .description:before {
                    content: "";
                    width: 75%;
                    border-top: 1px solid #ddd;
                    margin: 0 auto;
                    position: absolute;
                    bottom: 0;
                    left: 0;
                    right: 0;
                }

                .testimonial .description:after {
                    content: "";
                    width: 20px;
                    height: 20px;
                    background: #fff;
                    position: absolute;
                    bottom: -10px;
                    left: 50%;
                    border-bottom: 1px solid #ddd;
                    border-right: 1px solid #ddd;
                    transform: translateX(-50%) rotate(45deg);
                }

            .testimonial .pic {
                width: 100px;
                height: 100px;
                border-radius: 50%;
                margin: 25px auto;
                overflow: hidden;
            }

                .testimonial .pic img {
                    width: 100%;
                    height: auto;
                }

            .testimonial .title {
                display: inline-block;
                font-size: 23px;
                font-weight: 700;
                color: #848484;
                text-transform: capitalize;
                margin: 0;
            }

            .testimonial .post {
                display: inline-block;
                font-size: 20px;
                color: #848484;
            }

        .owl-theme .owl-controls {
            background: #fff;
            margin-top: 10px;
            position: absolute;
            bottom: -34%;
            right: 0;
        }

            .owl-theme .owl-controls .owl-buttons div {
                width: 30px;
                height: 30px;
                line-height: 30px;
                border-radius: 50%;
                background: #34363b;
                opacity: 1;
                padding: 0;
            }

        .owl-prev:before,
        .owl-next:before {
            content: "\f104";
   font-family: "fontawesome";
            font-size: 23px;
            font-weight: 700;
            color: #fff;
        }

        .owl-next:before {
            content: "\f105";
        }

        @media only screen and (max-width:767px) {
            .testimonial-bg {
                padding: 50px 40px;
            }

            .owl-theme .owl-controls {
                bottom: -22%;
            }
        }

        @media only screen and (max-width:480px) {
            .testimonial-bg:before {
                width: 55px;
                height: 55px;
                line-height: 55px;
                font-size: 40px;
            }

            .testimonial-bg {
                padding: 30px 10px;
            }

            .owl-theme .owl-controls {
                bottom: -15%;
            }
        }

        @media only screen and (max-width:360px) {
            .testimonial .title,
            .testimonial .post {
                font-size: 16px;
            }

            .owl-theme .owl-controls {
                bottom: -12%;
            }
        }
        .testimonial .details{
            margin-bottom:30px !important;
        }
        .owl-carousel .owl-dots.disabled, .owl-carousel .owl-nav.disabled {
    display: block !important;
}
        .owl-dots{
            display:none !important;

        }
   .owl-nav  span{
            font-size:50px;
            background:red;
            height:40px;
            width:40px;
            display:flex;
            margin-top:20px;
            align-items:start;justify-content:center;
            border-radius:100%;
            color:#fff;
        }
    .owl-nav {
        width:100%;

    }
 .owl-nav   .owl-prev{
     font-size:20px;
  
     color:#fff;
     background:#000;
 }
  .owl-nav   .owl-next{
     font-size:20px;
   
     color:#fff;
     background:#000;
 }
    @media (min-width: 320px) and (max-width: 767px) {


  .owl-nav  span{
        font-size: 44px;
    background: red;
    height: 40px !important;
    width: 40px !important;
    display: flex;
     margin-top: unset !important;
    line-height: 31px;
    align-items: unset !important;
    justify-content: center;
    border-radius: 100%;
    color: #fff;
       }
  }

  @media (min-width: 767px) and (max-width :991px) {



       .owl-nav  span{
             font-size: 44px;
    background: red;
    height: 40px !important;
    width: 40px !important;
    display: flex;
     margin-top: unset !important;
    line-height: 31px;
    align-items: unset !important;
    justify-content: center;
    border-radius: 100%;
    color: #fff;
       }
  }
  @media (min-width: 992px) and (max-width: 1300px) {
    .testimonial p {
        width: 100%;
        display: inline-block;
        color: #000 !important;;
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
                            <a href="Default.aspx">Home</a>
                            <a href="#">Testimonials</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="section-padding">
        <div class="container">

            <div class="row justify-content-center">
                <div class="col-md-8 ">
                    <div class="testimonial-bg">
                        <div id="testimonial-slider1" class="owl-carousel">

                            <%=strTestimonials %>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>



    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.0.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/owl-carousel/1.3.3/owl.carousel.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#testimonial-slider1").owlCarousel({
                items: 1,
                itemsDesktop: [1000, 1],
                itemsDesktopSmall: [979, 1],
                itemsTablet: [768, 1],
                pagination: true,
                navigation: true,
                navigationText: ["", ""],
                autoPlay: true
            });
        });</script>
</asp:Content>


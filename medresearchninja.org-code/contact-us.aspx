<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="contact-us.aspx.cs" Inherits="contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="js/intelinput/css/intlTelInput.min.css" rel="stylesheet" />
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }

        .capcha-refreshbox {
            height: 25px;
            width: 25px !important;
            height: 21px !important;
        }

        .iconbox-style1 .icon:before {
            background-color: #FBF7ED;
            border-radius: 50%;
            bottom: -3px;
            content: "";
            height: 40px;
            position: absolute;
            right: -7px;
        }

        .breadcumb-section {
            padding: 0px 0px;
        }

        .logos.me-4 {
            position: absolute;
        }


        .iconbox-style1 .icon {
            color: #ff7f3e;
            display: inline-block;
            font-size: 24px;
            position: relative
        }

        .new-li {
            display: flex;
            gap: 1rem;
            padding-left: 0px;
            justify-content: start;
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

        @media (min-width: 320px) and (max-width: 767px) {
            .iconbox-style1 {
                flex-direction: row;
            }

                .iconbox-style1 .details {
                    padding-top: 00px;
                    margin-left: 0px !important;
                }

                .iconbox-style1 .icon:before {
                    position: relative !important;
                    bottom: unset !important;
                    right: unset !important;
                }

                .iconbox-style1 p {
                    min-height: unset !important;
                }

                .iconbox-style1 .icon {
                    margin-left: 10px;
                }

                .iconbox-style1.contact-style .details {
                    padding-left: 15px;
                }
        }

        @media (min-width: 1300px) and (max-width: 1400px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }
        }

        @media (min-width: 1200px) and (max-width: 1300px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }
        }

        @media (min-width:768px) and (max-width:991px) {
            .iconbox-style1 {
                flex-direction: row;
            }

                .iconbox-style1 p {
                    min-height: unset !important;
                }

                .iconbox-style1 .details {
                    padding-top: 00px;
                    margin-left: 0px !important;
                }

                .iconbox-style1 .icon:before {
                    position: relative !important;
                    bottom: unset !important;
                    right: unset !important;
                }

                .iconbox-style1 .icon {
                    margin-left: 10px;
                }

                .iconbox-style1.contact-style .details {
                    padding-left: 15px;
                }
        }

        @media (min-width: 992px) and (max-width: 1199px) {
            .iconbox-style1 p {
                min-height: unset !important;
            }

            .capcha-refreshbox {
                height: 25px;
                width: 25px !important;
                height: 21px !important;
            }

            .img-captcha {
                position: relative !important;
                right: 0 !important;
                top: 6px !important;
            }

            .capcha-field {
                display: flex;
                align-items: center;
            }

                .capcha-field input {
                    width: 40%;
                    margin-left: 20px;
                }

                .capcha-field .form-control {
                    margin-bottom: 0px;
                }

            @media only screen and (min-width:320px) and (max-width:767px) {
                .capcha-field input {
                    margin-left: 5px;
                    width: 53%;
                }
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
                            <a href="/">Home</a>
                            <a href="javascript:void(0);">Contact Us</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Our Contact Info -->
    <section class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="position-relative mt40 mt10-sm">
                        <div class="main-title">
                            <h2 class="form-title mb25 fw-bold mb20-sm">Keep In Touch With Us.</h2>
                            <p class="text">
                                If you have any questions, need further information, or wish to get involved with our initiatives,   please don’t hesitate to reach out. We value your input and are here to assist you.

                            </p>
                        </div>

                        <div class="iconbox-style1 contact-style d-flex align-items-start mb30">
                            <div class="icon flex-shrink-0"><span class="fa-brands fa-whatsapp"></span></div>
                            <div class="details">
                                <h5 class="title">Whatsapp</h5>
                                <p class="mb-0 text"><a href="https://wa.me/+919945275295">+91 9945275295</a></p>
                            </div>
                        </div>
                        <div class="iconbox-style1 contact-style d-flex align-items-start mb30">
                            <div class="icon flex-shrink-0"><span class="flaticon-mail"></span></div>
                            <div class="details">
                                <h5 class="title">Email</h5>
                                <p class="mb-0 text"><a href="mailto:connect@medresearchninja.org">connect@medresearchninja.org </a></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="contact-page-form default-box-shadow1 bdrs8 bdr1 mb30-md mb0-sm bgc-white">
                        <div action="#" class="form-style1">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="lblStatus" runat="server" Width="100%" Visible="false"></asp:Label>

                                </div>
                                <div class="col-md-6">
                                    <div class="mb20">
                                        <label class="heading-color ff-heading fw500 mb10" for="txtName">Name</label>
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="100" CssClass="form-control" placeholder="Full Name" />
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb20">
                                        <label class="heading-color ff-heading fw500 mb10" for="txtEmail">Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email ID" TextMode="Email" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter valid emailIdAdress" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="mb20 txtPhone">
                                        <label class="heading-color ff-heading fw500 mb10" for="txtPhone">Phone No</label>
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" CssClass="form-control onlyNum" Style="padding-left: 85px;" placeholder="Phone No" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhone" ErrorMessage="Please Enter valid Phone number" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="mb20">
                                        <label class="heading-color ff-heading fw500 mb10" for="txtMessage">Messages</label>
                                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Your Messages Here..." Style="height: 150px !important" />
                                    </div>
                                </div>

                                <div class="d-flex">

                                    <div class="col-md-4 mb-5 mt-3  col-lg-4 col-6">
                                        <asp:Image ID="Image1" class="img-captcha" CssClass="border-width: 0px;" src="/capchanum.aspx?637725949916051783" runat="server" />
                                        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" ImageUrl="images/refresh.jpg" CssClass="capcha-refreshbox" formnovalidate="" runat="server" />
                                    </div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCaptcha" placeholder="Please enter result here" CssClass="form-control capcha-box onlyNum" runat="server" MaxLength="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="clearfix" Display="Dynamic" ForeColor="Red" ControlToValidate="txtCaptcha" SetFocusOnError="true" ValidationGroup="cd" ErrorMessage="Enter Captcha here"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div>
                                        <asp:Button ID="btnSend" runat="server" CssClass="ud-btn btn-thm" Text="Send Messages" OnClick="btnSend_Click" ValidationGroup="Save" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:HiddenField ID="txtCCodeMob1" runat="server" />
    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/intelinput/js/intlTelInput.min.js"></script>
    <script>
        $(document).ready(function () {
            $(document).ready(function () {
                $('.onlyNum').keypress(function (e) {
                    var charCode = (e.which) ? e.which : event.keyCode
                    if (String.fromCharCode(charCode).match(/[^0-9]/g))
                        return false;
                    if ($(this).val().length > 12)
                        return false;

                });
            })
            var input = document.querySelector("#<%=txtPhone.ClientID %>");
            window.intlTelInput(input, { separateDialCode: true }).setNumber(($("#<%=txtCCodeMob1.ClientID %>").val() == "" ? "+91" : $("#<%=txtCCodeMob1.ClientID %>").val()) + $("#<%=txtPhone.ClientID%>").val());

            $('#<%=txtPhone.ClientID %>').keypress(function (e) {
                var charCode = (e.which) ? e.which : event.keyCode
                if (String.fromCharCode(charCode).match(/[^0-9]/g))
                    return false;
            });
            $('#<%=txtPhone.ClientID %>').change(function () {
                $("#<%=txtCCodeMob1.ClientID %>").val($(".txtPhone .iti__selected-dial-code").html());
            });

        });
    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

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

        .new-contact {
            padding: 40px;
        }

        .ud-btn i {
            margin-left: 10px;
            font-size: 16px;
            transform: unset !important;
        }


        .our-register {
            background: #f1f1f1;
            background-size: cover;
            background-position: center;
        }

        .side-img {
            height: 680px;
            width: 100%;
            overflow: hidden;
        }

            .side-img img {
                height: 100%;
                width: 100%;
                object-fit: cover
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

        .High-light {
            margin-top: 20px;
            margin-bottom: 20px;
            border: 1px solid #ebf0f6;
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
            border-radius: 5px;
            border: 2px dashed #ff7f3e;
            background: #fff;
            padding: 10px 20px;
        }

            .High-light p {
                margin-bottom: 0px;
                color: #000;
                font-weight: 600;
                font-size: 18px;
            }

        .member-form {
            border: 1px solid #ebf0f6;
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
            border-radius: 5px;
            border: 2px dashed #ff7f3e;
            background: #fff;
            position: sticky;
            top: 0px;
        }


        .iconbox-style1 {
            padding: 20px 30px;
        }

        .list-style1 li {
            line-height: 20px !important;
        }

        .ui-content {
            margin-bottom: 0px;
        }

        .field-icon {
            float: right;
            margin-left: -25px;
            margin-top: -25px;
            position: relative;
            z-index: 2;
        }

        .pwd_eye {
            position: absolute;
            top: 8px;
            right: 8px;
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
                            <a href="#">Member Login </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding bg-light">
        <div class="container">
            <div class="row align-items-center  justify-content-center wow fadeInUp mt20" style="visibility: visible; animation-name: fadeInUp;">
                <div class="col-lg-10">
                    <div class="member-form">
                        <div class="row align-items-center">

                            <div class="col-md-6 col-xl-6 ">
                                <img src="new-img/user.jpg" class="img-fluid" />
                            </div>
                            <div class="col-md-6 col-xl-6">
                                <div class="member-form1  ">
                                    <div class="new-contact text-black">
                                        <h3 class="mb10   mb20">Login
                                        </h3>
                                        <p class="text">Don't have an account? <a href="signup.aspx" class="text-thm">Become a Member!</a></p>
                                        <asp:Label ID="lblStatus" runat="server" Style="width: 100%;" Visible="false"></asp:Label>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="mb25">
                                                    <asp:TextBox class="form-control" ID="txtEmail" runat="server" MaxLength="100" placeholder="Email"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Please Enter valid EmailAddress" ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="mb25">
                                                    <div class="form-group position-relative">
                                                        <asp:TextBox class="form-control password" TextMode="Password" ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox>

                                                        <a href="javascript:void(0);" class="pwd_eye showpwd d-none">
                                                            <img src="images/eye.svg" />
                                                        </a>
                                                        <a href="javascript:void(0);" class="pwd_eye hidepwd">
                                                            <img src="images/eye-slash.svg" />
                                                        </a>
                                                    </div>
                                                    <%--<input type="password" class="form-control" ID="txtPassword" runat="server" placeholder="Password">--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="checkbox-style1 d-block d-sm-flex align-items-center justify-content-between mb20">
                                                <label class="custom_checkbox fz14 ff-heading" for="<%=chkLogKeep.ClientID %>">
                                                    Remember me
                                                    <asp:CheckBox ID="chkLogKeep" runat="server" />
                                                    <span class="checkmark"></span>
                                                </label>
                                                <a class="fz14 ff-heading" href="forget-password.aspx">Forgot your password ?</a>
                                            </div>
                                            <div class="d-grid mb20">
                                                <asp:Button class="ud-btn btn-thm default-box-shadow2" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="Save" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
    </section>
    <script src="js/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            // Handle show/hide password toggle
            $(".pwd_eye").on("click", function () {
                // Find the related input element
                var ele = $(this);
                var input = $(this).siblings("input.password");

                // Check if the input type is password
                if (input.attr("type") === "password") {
                    input.attr("type", "text"); // Change type to text
                    ele.siblings(".showpwd").removeClass("d-none"); // Show the eye icon
                    ele.addClass("d-none"); // Hide the eye-slash icon
                } else {
                    input.attr("type", "password"); // Change type to password
                    ele.addClass("d-none"); // Hide the eye icon
                    ele.siblings(".hidepwd").removeClass("d-none"); // Show the eye-slash icon
                }
            });
        });

    </script>
</asp:Content>


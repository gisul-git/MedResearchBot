<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="forget-password.aspx.cs" Inherits="forget_password" %>

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
                            <a href="#">Forgot Password </a>
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
                                        <h3 class="mb10   mb20">Forgot Your Passsord ?
                                        </h3>
                                        <p class="text-danger">
                                            Enter your email and instructions will be sent to you!
                                        </p>
                                        <asp:Label ID="lblStatus" runat="server" Style="width: 100%;" Visible="false"></asp:Label>
                                        <div class="row">

                                            <div class="col-lg-12">
                                                <div class="mb25">
                                                    <%-- <input type="email" class="form-control" placeholder="Email">--%>
                                                    <asp:TextBox class="form-control" ID="txtemail" runat="server" placeholder="Email"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ValidationGroup="Save" SetFocusOnError="true" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="d-grid mb20">
                                                <%-- <a href="member-profile.aspx" class="ud-btn btn-thm default-box-shadow2" type="button">Reset Password <i class="fal fa-arrow-right-long"></i></a>--%>
                                                <asp:LinkButton ID="ResetPasswordButton" runat="server" CssClass="ud-btn btn-thm default-box-shadow2" OnClick="ResetPasswordButton_Click" ValidationGroup="Save">
                                              Reset Password <i class="fal fa-arrow-right-long"></i>
                                                </asp:LinkButton>
                                            </div>

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
</asp:Content>


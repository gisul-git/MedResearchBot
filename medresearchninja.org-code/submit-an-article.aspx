<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="submit-an-article.aspx.cs" Inherits="submit_an_article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }

        .new-input-head h5 {
            margin-bottom: 0px;
            font-size: 20px;
        }

        .form-control[type=file]:not(:disabled):not([readonly]) {
            cursor: pointer;
            padding: 10px 20px;
        }

        .breadcumb-section {
            padding: 0px 0px;
        }

        .form-style1 .form-control {
            height: 50px !important;
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

        .listing-style1 .list-title {
            margin-bottom: 15px;
            min-height: 80px;
            font-size: 20px;
        }

        .listing-style1 img {
            -webkit-transition: all 0.4s ease;
            padding: 20px 20px 0px 20px;
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

        .ps-widget {
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
        }

        .textAreaContainer {
            display: none; /* Initially hide the text area container */
        }

        .form-check {
            padding-left: 0px !important;
        }
    </style>
    <link href="js/sweetalert2/sweetalert2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@mdi/font/css/materialdesignicons.min.css">
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
                            <a href="white-paper.aspx">Whitepaper</a>
                            <a href="white-paper.aspx">BlueprintRx</a>
                            <a href="white-paper.aspx">Submit an Article</a>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding bg-light">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 px-0">
                    <div class="new-input-head1">
                        <h5 class="list-title">Submission Form for Blueprint-Rx </h5>
                    </div>

                </div>
                <div class="col-lg-8">
                    <div class="row">


                        <div class="ps-widget position-relative">


                            <div class="col-lg-12">
                                <div class="form-style1">

                                    <div class="row">
                                        <div class="new-input-head">
                                            <h5 class="list-title">Author Details</h5>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtAuthFullName" runat="server" class="form-control onlyAlpha txtAuthFullName" MaxLength="100" placeholder="Full Name"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtAuthTitle" runat="server" MaxLength="100" class="form-control txtAuthTitle" placeholder="Title/Postion"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtAuthAffiliation" runat="server" MaxLength="100" class="form-control txtAuthAffiliation" placeholder="Affiliation"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtAuthEmail" runat="server" MaxLength="100" class="form-control txtAuthEmail" TextMode="Email" placeholder="Email Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtAuthPhone" runat="server" MaxLength="100" class="form-control txtAuthPhone" placeholder="Phone Number"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="coAuthor">
                                            <div class="new-input-head d-flex justify-content-between align-items-center">
                                                <h5 class="list-title">Co-Authors</h5>
                                                <a href="javascript:void(0)" class="AddAuthor">
                                                    <img src="Img/plus.png" alt="Add Author" style="width: 30px; height: 30px;" />
                                                </a>
                                            </div>

                                            <div id="coAuthordata">
                                                <div class="row mb-3 co-author">
                                                    <div class="col-sm-4">
                                                        <div class="mb20">
                                                            <asp:TextBox ID="txtCoAuthFullName" runat="server" class="form-control onlyAlpha CoAuthorFullName" MaxLength="100" placeholder="Full Name"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="mb20">
                                                            <asp:TextBox ID="txtCoAuthTitle" runat="server" MaxLength="100" class="form-control CoAuthorPosition" placeholder="Title/Position"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="mb20">
                                                            <asp:TextBox ID="txtCoAuthAffiliation" runat="server" MaxLength="100" class="form-control CoAuthorAffiliation" placeholder="Affiliation"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="mb20">
                                                            <asp:TextBox ID="txtCoAuthEmail" runat="server" MaxLength="100" class="form-control CoAuthorEmailId " TextMode="Email" placeholder="Email Address"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 ">
                                                        <div class="mb20">
                                                            <a href="javascript:void(0)" class="Remove d-none">
                                                                <img src="Img/minus.png" alt="Remove" style="width: 30px; height: 30px;" />
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <hr class="border border-1" />


                                                </div>
                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Manuscript Information</h5>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtArticleTitle" runat="server" MaxLength="100" class="form-control txtArticleTitle" placeholder="Title of the Article"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="mb10">
                                                <label class="heading-color ff-heading fw500 mb10">Abstract<sup class="text-danger">*</sup></label>
                                                <asp:TextBox ID="txtAbstract" runat="server" CssClass="txtAbstract" MaxLength="200" cols="30" Rows="6" TextMode="MultiLine" placeholder="(150-200 words summary of the article)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtKeywords" runat="server" MaxLength="100" class="form-control txtKeywords" placeholder="Keywords (Up to 5 keywords that describe the article)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Type of Article</label>
                                                    <div class="bootselect-multiselect">
                                                        <asp:DropDownList runat="server" ID="ddlArticleType" class="selectpicker ddlArticleType">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Value="Research Article">Research Article</asp:ListItem>
                                                            <asp:ListItem Value="Review">Review</asp:ListItem>
                                                            <asp:ListItem Value="Case Study">Case Study</asp:ListItem>
                                                            <asp:ListItem Value="Commentary">Commentary</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="new-input-head">
                                            <h5 class="list-title">Article Details</h5>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtWordCount" runat="server" class="form-control txtWordCount" placeholder="Word Count"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtFigures" runat="server" class="form-control txtFigures" placeholder="Number of Figures/Tables"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Has this article been submitted to any other journal?</label>
                                                    <div class="form-check form-check-inline">
                                                        <asp:RadioButtonList ID="RadioButtonList1" Class="RadioButtonList1" runat="server" GroupName="inlineRadioOptions">
                                                            <asp:ListItem Value="Yes">&nbsp Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">&nbsp No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">
                                                        Is this article based on previously published work?
                                                    </label>
                                                    <asp:RadioButtonList ID="rabioBtnPublishedWorkCheck" runat="server" CssClass="form-check form-check-inline rabioBtnPublishedWorkCheck">
                                                        <asp:ListItem Value="Yes">&nbsp Yes</asp:ListItem>
                                                        <asp:ListItem Value="No">&nbsp No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 divDescPublishedWork d-none">
                                            <div class="mb10">
                                                <asp:TextBox ID="txtPublishWork" runat="server" CssClass="txtPublishWork" MaxLength="200" cols="30" Rows="6" TextMode="MultiLine" placeholder="please provide details"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Supplementary Materials </h5>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Is this article based on previously published work?</label>
                                                    <div class="bootselect-multiselect">
                                                        <asp:DropDownList runat="server" ID="ddlPrevPublishedWork" CssClass="selectpicker ddlPrevPublishedWork">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Value="Datasets">Datasets</asp:ListItem>
                                                            <asp:ListItem Value="Additional figures">Additional figures</asp:ListItem>
                                                            <asp:ListItem Value="Appendices">Appendices</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="new-input-head">
                                            <h5 class="list-title">Conflicts of Interest and Funding </h5>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Do you have any conflicts of interest to declare?</label>
                                                    <div class="bootselect-multiselect">
                                                        <asp:RadioButtonList ID="rabioBtnInterestAndFunding" runat="server" ValidationGroup="Save" Class="form-check form-check-inline rabioBtnInterestAndFunding">
                                                            <asp:ListItem Value="Yes">&nbsp Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">&nbsp No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 divInterestAndFunding d-none">
                                            <div class="mb10">
                                                <asp:TextBox ID="DescInterestAndFunding" runat="server" MaxLength="200" cols="30" Rows="6" TextMode="MultiLine" placeholder="please provide details"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12 ">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Was this research funded by any organization?</label>
                                                    <div class="bootselect-multiselect">
                                                        <asp:RadioButtonList ID="rabioBtnOrganization" runat="server" CssClass="form-check form-check-inline rabioBtnOrganization">
                                                            <asp:ListItem Value="Yes">&nbsp Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">&nbsp No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 divOrganization d-none">
                                            <div class="mb10 ">
                                                <asp:TextBox ID="DescOrganization" runat="server" class="DescOrganization" MaxLength="250" cols="30" Rows="6" TextMode="MultiLine" placeholder="If yes, please list the funding sources"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Acknowledgments  </h5>
                                        </div>


                                        <div class="col-md-12">
                                            <div class="mb10">
                                                <asp:TextBox ID="DescAcknowledgment" runat="server" class="DescAcknowledgment" MaxLength="250" cols="30" Rows="6" TextMode="MultiLine" placeholder="If yes ,Please provide any acknowledgments for individuals or organizations who contributed to the research but are not listed as authors:"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Ethical Compliance </h5>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <div class="form-style1">
                                                    <label class="heading-color ff-heading fw500 mb10">Have all necessary ethical approvals been obtained for this research?</label>
                                                    <div class="bootselect-multiselect">
                                                        <asp:RadioButtonList ID="rabioBtnReserach" runat="server" CssClass="form-check form-check-inline rabioBtnReserach">
                                                            <asp:ListItem Value="Yes">&nbsp Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">&nbsp No</asp:ListItem>
                                                            <asp:ListItem Value="Not Applicable">&nbsp Not Applicable</asp:ListItem>

                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 divEthicalCompliance d-none">
                                            <div class="mb10">
                                                <asp:TextBox ID="DescEthicalCompliance" runat="server" class="DescEthicalCompliance" MaxLength="250" cols="30" Rows="6" TextMode="MultiLine" placeholder="If yes, please provide the ethical approval reference number:"></asp:TextBox>

                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Ethical Compliance </h5>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <label class="heading-color ff-heading fw500 mb10">Attach Manuscript</label>
                                                <asp:FileUpload ID="AttachManuscript" runat="server" class="form-control AttachManuscript" ToolTip="Maxmimum 1 MB file size"></asp:FileUpload><br />
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <label class="heading-color ff-heading fw500 mb10">Attach Supplementory Manuscript</label>
                                                <asp:FileUpload ID="AttachSupplementoryManuscript" runat="server" class="form-control AttachSupplementoryManuscript" ToolTip="Maxmimum 1 MB file size"></asp:FileUpload><br />
                                            </div>
                                        </div>


                                        <div class="checkbox-style1 d-block d-sm-flex align-items-center justify-content-between mb20">
                                            <label class="custom_checkbox fz14 ff-heading">
                                                By submitting this form, I confirm that this manuscript is an original work and has not been published or submitted elsewhere. I agree to adhere to the journal's submission guidelines and ethical standards.
                                         <input type="checkbox" checked="checked">
                                                <span class="checkmark"></span>
                                            </label>
                                        </div>

                                        <div class="d-flex justify-content-between">
                                            <div class="col-sm-4">
                                                <div class="mb20">
                                                    <asp:TextBox ID="txtSignature" runat="server" class="form-control txtSignature" MaxLength="100" placeholder="Signature (typed name)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="mb20">
                                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 datepicker txtDate" TextMode="Date" ID="txtDate" placeholder="dd-mm-yyyy" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="new-input-head">
                                            <h5 class="list-title">Contact Information for Correspondence</h5>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtConName" runat="server" class="form-control onlyAlpha txtConName" MaxLength="100" placeholder="Name"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtConEmail" runat="server" class="form-control onlyAlpha txtConEmail" MaxLength="100" placeholder="Email Address"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-12">
                                            <div class="mb20">
                                                <asp:TextBox ID="txtConPhone" runat="server" class="form-control onlyAlpha txtConPhone" MaxLength="100" placeholder="Phone Number"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="text-start">
                                                <div class="error-message alert alert-danger d-block d-none fw-bold"></div>
                                                <a>
                                                    <asp:LinkButton class="ud-btn btn-thm btnsubmit" ID="btnsubmit" runat="server" Text="Submit">Submit<i class="fal fa-arrow-right-long"></i></asp:LinkButton></a>
                                                <asp:Label ID="lblattach" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="lblSupAttach" runat="server" Text="" Visible="false"></asp:Label>

                                                <asp:Label ID="lblStatus" CssClass="lblStatus" runat="server" Text="" Visible="false"></asp:Label>

                                                <asp:HiddenField ID="txtAuthorGuid" runat="server"></asp:HiddenField>
                                                <asp:HiddenField ID="txtStatus" runat="server"></asp:HiddenField>
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
        <div class="new-fade">
            <div class="modal fade" id="exampleModal1" data-bs-backdrop="static" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-body text-center p-5">
                            <h2>Login to Continue</h2>
                            <a href="/login.aspx" class="ud-btn btn-thm mt-4 default-box-shadow2">Login <i class="fal fa-arrow-right-long"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="js/jquery-3.6.0.min.js"></script>
    <script>
        $(window).on('load', function () {
            var isLoggedIn = document.cookie.indexOf('med_uid=') !== -1;
            if (!isLoggedIn) {
                $('#exampleModal1').modal('show');
            }
        });
    </script>
    <script src="js/sweetalert2/sweetalert2.min.js"></script>
    <script src="js/pages/submit-an-article.js"></script>
</asp:Content>


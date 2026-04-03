<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="resources.aspx.cs" Inherits="resources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        header.nav-homepage-style {
            background: #000;
            position: relative;
        }

        .blog-style1 .title {
            -webkit-transition: all 0.4s ease;
            -moz-transition: all 0.4s ease;
            -ms-transition: all 0.4s ease;
            font-size: 18px;
            font-weight: 600;
            -o-transition: all 0.4s ease;
            transition: all 0.4s ease;
        }

        .ud-btn1 i {
            margin-left: 10px;
            font-size: 16px;
            transform: rotate(0) !important;
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

            .new-li li {
                color: #fff;
            }

                .new-li li a {
                    color: #fff;
                }

        .blog-style1 .blog-img {
            overflow: hidden;
            border-top-left-radius: 12px;
            border-top-right-radius: 12px;
        }

        .dropdown-lists .open-btn {
            background-color: #ff7f3e;
            border: 1px solid #ff7f3e;
            border-radius: 4px;
            cursor: pointer;
            color: #000;
            font-family: var(--title-font-family);
            font-weight: 400;
            font-weight: 500;
            letter-spacing: 0em;
            padding: 10px 40px;
        }

        .bootstrap-select > .dropdown-toggle.bs-placeholder, .bootstrap-select > .dropdown-toggle.bs-placeholder:active, .bootstrap-select > .dropdown-toggle.bs-placeholder:focus, .bootstrap-select > .dropdown-toggle.bs-placeholder:hover {
            color: #fff;
        }


        .blog-style1.at-home7 {
            border-radius: 12px;
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


        .blog-content h4 {
            min-height: 44px;
        }

        .modal-header {
            display: flex;
            flex-shrink: 0;
            align-items: center;
            background: #ff7f3e;
            justify-content: center;
            padding: 1rem 1rem;
            /* border-bottom: 1px solid #dee2e6; */
            border-top-left-radius: calc(.3rem - 1px);
            border-top-right-radius: calc(.3rem - 1px);
        }

            .modal-header .btn-close {
                padding: .5rem .5rem;
                margin: -.5rem -.5rem -.5rem auto;
                position: absolute;
                color: #fff;
                right: 27px;
                top: 20px;
            }

        .modal-title {
            font-size: 22px;
        }

        .modal-title {
            font-size: 22px;
            color: #fff;
        }

        .modal-body {
            position: relative;
            flex: 1 1 auto;
            padding: 30px;
        }

        .modal-dialog {
            max-width: 700px;
        }

        .btn-close {
            box-sizing: content-box;
            width: 1em;
            height: 1em;
            padding: .25em .25em;
            color: #fff !important;
            background: unset;
            border: 0;
            border-radius: .25rem;
            opacity: 1;
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
                            <a href="#">Resources</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding ">
        <div class="container">

            <div class="row wow fadeInUp justify-content-between align-items-center d-none" style="visibility: visible; animation-name: fadeInUp;">
                <div class="col-lg-8">
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="text-end mb-5 ">
                        <div class="bootselect-multiselect">
                            <div class="dropdown bootstrap-select show-tick dropup">

                                <button type="button" tabindex="-1" class="btn dropdown-toggle bs-placeholder btn-light" data-bs-toggle="dropdown" role="combobox" aria-owns="bs-select-2" aria-haspopup="listbox" aria-expanded="false" title="Nothing selected">
                                    <div class="filter-option">
                                        <div class="filter-option-inner">
                                            <div class="filter-option-inner-inner">Select Category</div>
                                        </div>
                                    </div>
                                </button>
                                <div class="dropdown-menu" style="max-height: 264.4px; overflow: hidden; min-height: 124px;">
                                    <div class="inner show" role="listbox" id="bs-select-2" tabindex="-1" aria-multiselectable="true" style="max-height: 248.4px; overflow-y: auto; min-height: 108px;">
                                        <ul class="dropdown-menu inner show" role="presentation" style="margin-top: 0px; margin-bottom: 0px;">
                                            <li><a role="option" class="dropdown-item" id="bs-select-2-0" tabindex="0" aria-selected="false" aria-setsize="6" aria-posinset="1"><span class=" bs-ok-default check-mark"></span><span class="text">Journel</span></a></li>
                                            <li><a role="option" class="dropdown-item" id="bs-select-2-1" tabindex="0" aria-selected="false" aria-setsize="6" aria-posinset="2"><span class=" bs-ok-default check-mark"></span><span class="text">Database</span></a></li>
                                            <li><a role="option" class="dropdown-item" id="bs-select-2-2" tabindex="0" aria-selected="false" aria-setsize="6" aria-posinset="3"><span class=" bs-ok-default check-mark"></span><span class="text">Tools</span></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row wow fadeInUp" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">

                <%=StrResources %>
            </div>
        </div>
    </section>

    <div class="modal fade sucess" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Download Resources</h5>

                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"><i class="fa-solid fa-x text-white"></i></button>
                </div>
                <div class="modal-body">

                    <div class="fourm">
                        <div class="row justify-content-center align-items-center">
                            <div class="col-lg-5">
                                <img src="new-img/pop.png" class="img-fluid">
                            </div>
                            <div class="col-lg-7">

                                <div class="row">
                                    <div class="col-lg-12 col-xl-12">
                                        <div class="ui-content mb20">
                                            <div class="form-style1">
                                                <asp:TextBox ID="textFname" runat="server" class="form-control textFname" MaxLength="100" placeholder="Full Name"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-xl-12">
                                        <div class="ui-content mb20">
                                            <div class="form-style1">
                                                <asp:TextBox ID="txtemailAdress" class="form-control txtemailAdress" runat="server" MaxLength="100" placeholder="Email"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-xl-12">
                                        <div class="ui-content mb20">
                                            <div class="form-style1">

                                                <asp:TextBox ID="txtContact" class="form-control txtContact" runat="server" MaxLength="15" placeholder="Contact Number"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="error-message alert alert-danger d-block d-none fw-bold"></div>
                                    <div class="mt10">
                                     <asp:LinkButton runat="server" ID="BtnSubmit" CssClass="ud-btn bgc-thm text-white bdr1 default-box-shadow2 submitdata BtnSubmit" ValidationGroup="Save">Download<i class="fal fa-arrow-right-long"></i></asp:LinkButton>
                                    </div>
                                        
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.6.4.min.js"></script>
    <script>
        $(document).on('click', '.hidenId', function () {
            var dataId = $(this).attr('data-id');
            $('.BtnSubmit').attr('data-id', dataId); 
        });
        //$(document).on('click', '.btn-close', function () {
        //    $(".textFname").val("");
        //    $(".txtemailAdress").val("");
        //    $(".txtContact").val("");
        //});

        $(document.body).on("click", ".submitdata", function (e) {
            e.preventDefault();
            
            if ($(".textFname").val() || $(".txtemailAdress").val() || $(".txtContact").val() !== "") {
                var id = $('.BtnSubmit').attr('data-id');
                var name = $(".textFname").val().trim();
                var email = $(".txtemailAdress").val().trim();
                var contact = $(".txtContact").val().trim();
                $.ajax({
                    type: 'POST',
                    url: "resources.aspx/SaveDownloadEnquiry",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: JSON.stringify({
                        name: name, email: email, contact: contact, Id: id
                    }),
                    success: function (data2) {
                        var result = data2.d;
                        if (result.split('|')[0] == "Success ") { 
                            Snackbar.show({ pos: 'top-right', text: 'Thank you for Submitting.', actionTextColor: '#fff', backgroundColor: '#ff7f3e' });
                            $('.error-message').addClass("d-none");
                            $(".textFname").val("");
                            $(".txtemailAdress").val("");
                            $(".txtContact").val("");
                            $('.btn-close').trigger('click');
                            var pdf = result.split('|')[1].trim(); // Trim to remove extra spaces

                            // Automatically start downloading the PDF
                            if (pdf) { // Check if pdf link is not empty
                                var a = document.createElement('a');
                                a.href = pdf;
                                a.download = ''; // Optional: specify a filename
                                document.body.appendChild(a);
                                a.click(); // Trigger the download
                                document.body.removeChild(a); // Clean up the DOM
                            }
                            //dwnlod pdf
                        } else {
                            Snackbar.show({
                                pos: 'top-right', text: 'Oops...! There is some problem right now. Please try again later.', actionTextColor: '#fff', backgroundColor: '#ff7f3e'
                            });
                        }
                    }
                });
            }
            else {
                $('.error-message').removeClass("d-none");
                $('.error-message').text('Please fill all the fields.');
            }
        });


    </script>
</asp:Content>


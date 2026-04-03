<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="ask-a-question.aspx.cs" Inherits="ask_a_question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-style1 .form-control {
            border-radius: 0px !important;
        }

        .fourm {
            padding: 20px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            position:relative;
        }
        .small-12.medium-2.large-2.columns{
            position:relative;
        }
        textarea {
            border-radius: 0px !important;
        }

        .profile-pic {
            width: 200px;
            max-height: 200px;
            display: inline-block;
        }

        .file-upload {
            display: none;
        }

        .circle {
            border-radius: 100% !important;
            overflow: hidden;
            width: 128px;
            height: 128px;
            border: 2px solid rgba(255, 255, 255, 0.2);
          
        }

        img {
            max-width: 100%;
            height: auto;
        }

        .p-image {
            position: absolute;
            top: 75px;
            left: 100px;
            color: #666666;
            transition: all .3s cubic-bezier(.175, .885, .32, 1.275);
        }

            .p-image:hover {
                transition: all .3s cubic-bezier(.175, .885, .32, 1.275);
            }

        .upload-button {
            font-size: 1.2em;
        }

            .upload-button:hover {
                transition: all .3s cubic-bezier(.175, .885, .32, 1.275);
                color: #999;
            }
            .breadcumb-style1 .breadcumb-list a{
                color:#000;
            }
            .breadcumb-style1 .breadcumb-list a:last-child {
    color: #000;
}
              .breadcumb-section{
                  background:#f1f1f1;
              }
              .fourm{
                  background:#fff;
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
                            <a href="discussion-forum.aspx">
Forums</a>
                            <a href="#">Ask a question</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding bg-light">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-6">
                    <div class="fourm">
                        <div class="row">
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb40">
                                    <div class="form-style1">
                                        <label class="form-label fw700 fz18 dark-color">Title</label>
                                        <input type="text" class="form-control" placeholder="Your Name">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb40">
                                    <div class="form-style1">
                                        <label class="form-label fw700 fz18 dark-color">Location</label>
                                        <input type="text" class="form-control" placeholder="Your Name">
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 col-xl-12">
                                <div class="ui-content mb40">
                                    <div class="form-style1">
                                        <label class="form-label fw700 fz18 dark-color">Textarea</label>
                                        <textarea name="text" id="textarea1" cols="30" rows="7"></textarea>
                                    </div>
                                </div>
                            </div>
                            
                        <div class="mt20">
                            <button class="ud-btn btn-thm default-box-shadow2" type="button">Submit <i class="fal fa-arrow-right-long"></i></button>
                        </div>
                        </div>
                    </div>
                </div>
          


            </div>
        </div>
    </section>
</asp:Content>


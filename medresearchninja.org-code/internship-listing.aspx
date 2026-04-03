<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="internship-listing.aspx.cs" Inherits="internship_listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .breadcumb-style1 .breadcumb-list a {
            color: #000;
        }

            .breadcumb-style1 .breadcumb-list a:last-child {
                color: #000;
            }

        .breadcumb-section {
            background: #f1f1f1;
        }

        .inv {
            filter: invert(1);
        }

        .job-list-style1 h5 {
            font-size: 22px;
            margin-bottom: 10px;
        }

        ..accordion-style1 .accordion-button {
            margin-bottom: 0px;
        }

        .accordion-style1 .accordion-button {
            padding: 15px 20px !important;
        }

        .accordion-style1 .accordion-button {
            box-shadow: none !important;
            border-radius: 0px !important;
            border-bottom: 2px solid #ff7f3e;
        }

        .accordion-style1 .accordion-body {
            padding: 15px 30px 15px 30px;
        }

        .accordion-style1 .accordion-body {
            background: #f1f1f1;
        }

        .list-style1 li {
            margin-bottom: 10px;
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
                            <a href="/#">Home</a>
                            <a href="/#">Career</a>
                             <a href="#"><%=RouteData.Values["career/jurl"] !=null?"Jobs":"Internship" %> Listing</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding">
        <div class="container">
            <div class="main-title">
                                <h2 class="title  text-center  text-capitalize"> <a href="#"><%=RouteData.Values["career/jurl"] !=null?"Current Internships":"Current Jobs" %> Openings</a></h2>

            </div>
            <div class="row justify-content-center">
                <%=strIntership %>
            </div>
        </div>
    </section>

</asp:Content>


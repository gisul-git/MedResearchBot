<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="project-paypal-success.aspx.cs" Inherits="project_paypal_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .flickity-viewport {
            height: 400px !important;
        }

        @media (min-width: 1025px) {
            #nt_footer {
                position: static;
            }
        }
    </style>
    <link rel="canonical" href="<%=Request.Url.AbsoluteUri.ToLower() %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="py_6">
        <div class="container">
            <div class="row my-5 justify-content-center">
                <div class="col-md-8">
                    <div class="card border-0">
                        <div class="card-body text-center">
                            <%=strStatus %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body text-center">
            <a href="/" class="ud-btn btn-thm">Back to Home</a>
        </div>
    </section>
</asp:Content>


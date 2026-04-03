<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="paypal-success.aspx.cs" Inherits="paypal_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .flickity-viewport {
            height: 400px !important;
        }

        tbody, td, tfoot, th, thead, tr {
            border-width: 1px;
        }

        select {
            border-radius: unset !important;
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
            <div class="row my-2 justify-content-center">
                <div class="col-md-6">
                    <div class="card border-0">
                        <div class="card-body text-center">
                            <%=strStatus %>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="card-body text-center">
            <a href="/" class="ud-btn btn-thm">Back To Home</a>
        </div>
    </section>
</asp:Content>



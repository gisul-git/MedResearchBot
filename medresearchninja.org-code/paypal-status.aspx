<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="paypal-status.aspx.cs" Inherits="paypal_status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="canonical" href="<%=Request.Url.AbsoluteUri.ToLower() %>" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-full p-t40 p-b100 our-projects-galery cartpagesec">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="spinner-border text-primary mb-3" role="status">
                        <span class="sr-only">Processing...</span>
                    </div>
                    <h3>Processing your PayPal payment...</h3>
                    <p class="text-muted">Please wait while we confirm your transaction.</p>
                    <% if (!string.IsNullOrEmpty(payStatus)) { %>
                        <div class="alert alert-danger mt-3">
                            <%=payStatus %>
                        </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
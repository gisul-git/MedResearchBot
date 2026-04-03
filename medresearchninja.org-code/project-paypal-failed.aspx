<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="project-paypal-failed.aspx.cs" Inherits="project_paypal_failed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .payment-failed-container {
            min-height: 400px;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .failed-icon {
            font-size: 80px;
            color: #dc3545;
            margin-bottom: 20px;
        }

        .btn-retry {
            margin-top: 20px;
            padding: 12px 40px;
            font-size: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-full p-t80 p-b100 our-projects-galery cartpagesec">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="payment-failed-container">
                        <div class="text-center">
                            <div class="failed-icon">
                                <i class="fas fa-times-circle"></i>
                            </div>
                            <h2>Payment Cancelled</h2>
                            <p class="lead"><%=payStatus %></p>

                            <% if (!string.IsNullOrEmpty(orderGuid))
                                { %>
                            <a href="pay-for-project.aspx?order=<%=orderGuid %>" class="btn btn-primary btn-retry">
                                <i class="fas fa-redo"></i>Try Again
                                </a>
                            <% } %>

                            <a href="/" class="btn btn-secondary btn-retry">
                                <i class="fas fa-home"></i>Go to Homepage
                            </a>

                            <div class="mt-4">
                                <p class="text-muted">
                                    Need help? <a href="/contact-us.aspx">Contact Support</a>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


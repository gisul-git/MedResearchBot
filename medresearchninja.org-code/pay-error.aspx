<%@ Page Title="Payment Error | MedResearchNinja" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pay-error.aspx.cs" Inherits="Pay_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="canonical" href="<%=Request.Url.AbsoluteUri.ToLower() %>" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="py_6">
        <div class="container">
            <div class="row my-5 justify-content-center">
                <div class="col-md-8">
                    <div class="card border-0">
                        <div class="card-body text-center">
                            <img style='height: 200px;' src='/assets/images/x.gif' /><h3 class='main-heading text-danger'>Oops!<br>
                            Your Payment has failed.</h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


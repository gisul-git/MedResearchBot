<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="project-payment-status.aspx.cs" Inherits="project_payment_status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <link rel="canonical" href="<%=Request.Url.AbsoluteUri.ToLower() %>" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-full p-t40 p-b100 our-projects-galery cartpagesec">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h1><%=payStatus %></h1>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


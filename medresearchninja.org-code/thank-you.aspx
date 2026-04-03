<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="thank-you.aspx.cs" Inherits="thank_you" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="our-error">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-xl-6 wow fadeInRight" data-wow-delay="300ms">
            <div class="animate_content text-center text-xl-start">
              <div class="animate_thumb">
                <img class="w-100" src="/images/thank.jpg" alt="error-page-img">
              </div>
            </div>
          </div>
          <div class="col-xl-5 offset-xl-1 wow fadeInLeft" data-wow-delay="300ms">
            <div class="error_page_content text-center text-xl-start">
              <div class="h2 error_title">Thank You!</div>
              <p class="text fz15 mb20"> Thank you. our team will get back to you soon.

</p>
              <a href="Default.aspx" class="ud-btn btn-thm">Go back to home</a>
            </div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>


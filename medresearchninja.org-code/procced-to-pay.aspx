<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeFile="procced-to-pay.aspx.cs" Inherits="procced_to_pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="our-error">
      <div class="container">
        <div class="row align-items-center">
          <div class="col-xl-6 wow fadeInRight" data-wow-delay="300ms">
            <div class="animate_content text-center text-xl-start">
              <div class="animate_thumb">
                <img class="w-100" src="/images/pay.jpg" alt="error-page-img">
                  <%--<img class="w-100" src="/images/payfaill.jpg" alt="error-page-img">--%>
              </div>
            </div>
          </div>
          <div class="col-xl-5 offset-xl-1 wow fadeInLeft" data-wow-delay="300ms">
            <div class="error_page_content text-center text-xl-start">
              <div class="h1 error_title">Opps! Your Payment is Pending</div>
                <br />
                <%--<p class="text fz15 mb20">To Login you may need to pay membership fee of ₹850</p>--%>
                <asp:LinkButton class="ud-btn btn-thm1 add-joining1" ID="btnLogin" runat="server" OnClick="btnProceed_Click">Proceed To Pay<i class="fal fa-arrow-right-long"></i></asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>


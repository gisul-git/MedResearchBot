<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="refund-policy.aspx.cs" Inherits="refund_policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style>
        .breadcumb-section {
    background: #f1f1f1;
}.breadcumb-style1 .breadcumb-list a {
    color: #000;
    opacity:.5;
}
 .breadcumb-style1 .breadcumb-list a:last-child{
     color:#000 !important;
 } .section-padding{
     padding:40px 0px;
 } li{
     color:#000;
 }
       .new-il-new {
       position:relative;
   }
    .new-il-new li {
     position:relative;
 }
   .new-il-new li:before {
    position: absolute;
    top: 0px;
    margin: 0px 0 0 -28px;
    vertical-align: middle;
    color: #F26622;
    content: "✓";
}
   .new-color{
       color:#F26622;
   }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <section class="breadcumb-section">
      <div class="container">
          <div class="row">
              <div class="col-lg-12">
                  <div class="breadcumb-style1">
                      <div class="breadcumb-list">
                          <a href="Default.aspx">Home</a>
                          <a href="#">Refund Policy</a>
                      </div>
                  </div>
              </div>
          </div>
      </div>
  </section>
    <section class="section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                     <h1>Refund Policy</h1>
    <p>We value transparency regarding membership and project enrollment fees.</p>
    
    <h2>Refunds</h2>
    <ul class="new-il-new">
        <li>Refunds are available only if requested within 3 days of joining.</li>
        <li>Refunds are not applicable once access to events or resources has begun.</li>
    </ul>
    
    <h2>How to Request a Refund</h2>
    <ul class="new-il-new">
        <li>Email <a  class="new-color" href="mailto:connect@medresearchninja.org">connect@medresearchninja.org</a> with your payment details.</li>
        <li>Refunds will be processed within 30 business days if eligible.</li>
    </ul>
    
    <p>For questions, reach out to <a class="new-color" href="mailto:connect@medresearchninja.org">connect@medresearchninja.org</a>.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="terms-and-conditions.aspx.cs" Inherits="terms_and_conditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style>
        .breadcumb-section {
    background: #f1f1f1;
}.breadcumb-style1 .breadcumb-list a {
    color: #000;
    opacity:.5;
}.new-color{
    color:#F26622;
}
 .breadcumb-style1 .breadcumb-list a:last-child{
     color:#000 !important;
 } .section-padding{
     padding:40px 0px;
 }
   li{
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
                          <a href="#">Terms and Conditions</a>
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
                       <h1>Terms and Conditions</h1>
    <p>By joining MedResearch Ninja, you agree to the following:</p>
    
    <h2>Membership</h2>
    <ul class="new-il-new">
        <li><strong>Eligibility:</strong> Open to researchers and professionals. Users under 18 require guardian consent.</li>
        <li><strong>Fees:</strong> Membership fees cover access to resources and events.</li>
    </ul>
    
    <h2>Community Rules</h2>
    <ul class="new-il-new">
        <li>Respect all members and their intellectual property.</li>
        <li>Avoid harassment, spamming, or misuse of the platform.</li>
    </ul>
    
    <h2>Disclaimers</h2>
    <ul class="new-il-new">
        <li>We do not guarantee the accuracy of user-shared research or uninterrupted access.</li>
        <li>MedResearch Ninja is not liable for any losses resulting from platform usage.</li>
    </ul>
    
    <p>By using our site, you agree to these terms.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="privacy-policy.aspx.cs" Inherits="privacy_policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
             <style>
        .breadcumb-section {
    background: #f1f1f1;
}.breadcumb-style1 .breadcumb-list a {
    color: #000;
    opacity:.5;
}
 .breadcumb-style1 .breadcumb-list a:last-child{
     color:#000 !important;
 }
 .section-padding{
     padding:40px 0px;
 } li{
     color:#000;
 }
       .new-il-new {
       position:relative;
   }
    .new-il-new li {
     position:relative;
 }.new-color{
    color:#F26622;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="breadcumb-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="breadcumb-style1">
                        <div class="breadcumb-list">
                            <a href="Default.aspx">Home</a>
                            <a href="#">Privacy policy</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="section-padding">
        <div class="container">
            <div class="row">
                <div class="co-lg-12">
                    <h1>Privacy Policy</h1>
                    <p>At MedResearch Ninja, your privacy matters to us. This policy explains how we collect, use, and protect your information when you join our research community.</p>

                    <h2>What Information We Collect</h2>
    <ul class="new-il-new">
                        <li><strong>Personal Details:</strong> Name, email, professional credentials, and payment information for membership.</li>
                        <li><strong>Community Data:</strong> Contributions to research discussions, feedback, or submissions.</li>
                        <li><strong>Site Usage:</strong> Non-identifiable data like IP addresses and session activity for improving the platform.</li>
                    </ul>

                    <h2>How We Use Your Information</h2>
                    <p>We use your data to:</p>     
    <ul class="new-il-new">
                        <li>Facilitate your participation in the community.</li>
                        <li>Provide access to resources, events, and updates.</li>
                        <li>Maintain secure records and comply with regulations.</li>
                    </ul>

                    <h2>Your Rights</h2>
    <ul class="new-il-new">
                        <li>Access or update your data anytime by contacting us.</li>
                        <li>Opt out of communications or delete your account.</li>
                    </ul>

                    <p>We never sell your data. For questions, email <a  class="new-color" href="mailto:connect@medresearchninja.org">connect@medresearchninja.org</a>.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


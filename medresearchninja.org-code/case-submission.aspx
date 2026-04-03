<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="case-submission.aspx.cs" Inherits="case_submission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .breadcumb-style1 .breadcumb-list a {
            color: #000;
        }

        .new-input-head1 {
            padding: 10px 20px;
            background: #ff7f3e;
            margin: 0px 0px;
            border-left: 3px solid #ff7f3e;
            border-right: 3px solid #ff7f3e;
            text-align: center;
        }

            .new-input-head1 h5 {
                margin-bottom: 0px;
                color: #fff;
            }

        .ps-widget {
            box-shadow: 0 0 10px 7px rgb(0 0 0 / 3%);
        }

        .new-input-head {
            padding: 10px 20px;
            background: #f1f1f1;
            margin: 20px 0px;
            border-left: 3px solid #ff7f3e;
        }

            .new-input-head h5 {
                margin-bottom: 0px;
            }

        .form-check-inline {
            display: flex;
            align-items: center;
            gap: .5rem;
        }

        .textAreaContainer {
            display: none; 
        }

        .breadcumb-style1 .breadcumb-list a:last-child {
            color: #000;
        }

        .breadcumb-section {
            background: #f1f1f1;
        }
        
     .new-fade .modal:before{
         backdrop-filter:blur(10px);
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
                            <a href="#">Community</a>

                            <a href="#">Submit a Research Idea or Case Report
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="section-padding bg-light">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="ui-content">
                        <h2 class="title text-center">Submit a Research Idea/Case Report</h2>
                        <div class="navpill-style1 mb70">
                            <ul class="nav justify-content-center nav-pills mb30" id="pills-tab" role="tablist">
                                <li class="nav-item" role="presentation">
                                    <button class="nav-link active fw500 dark-color" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Case Report</button>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <button class="nav-link fw500 dark-color" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Research Idea</button>
                                </li>

                            </ul>
                            <div class="tab-content" id="pills-tabContent">
                                <div class="tab-pane fade fz15 text show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">

                                    <div class="row justify-content-center">
                                        <div class="col-lg-12  px-0">
                                            <div class="new-input-head1">
                                                <h5 class="list-title">Submit a Case Report
                                                </h5>
                                            </div>

                                        </div>
                                        <div class="col-lg-12">
                                            <div class="row">
                                                <div class="ps-widget bgc-white bdrs4 p30 p15-sm mb30 overflow-hidden position-relative">
                                                    <div class="col-lg-12">
                                                        <div class="form-style1">

                                                            <div class="row">

                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Title of the Case</label>
                                                                        <asp:TextBox ID="txtTitleOfCase" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder=""></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtTitleOfCase" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Case Summary</label>
                                                                        <asp:TextBox ID="txtCaseSummary" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Provide a brief overview of the case"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtCaseSummary" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">
                                                                            Why is this Case Rare or Reportable?
                                                                        </label>
                                                                        <asp:TextBox ID="txtRareOrReportable" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Explain why this case is considered rare or of interest for reporting. Discuss any unique aspects or unusual presentation."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtRareOrReportable" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Upload Evidence</label>

                                                                        <asp:FileUpload ID="UploadEvidence" runat="server" class="form-control" ToolTip="Maxmimum 1 MB file size"></asp:FileUpload><br />

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Submitted By</label>
                                                                        <asp:TextBox ID="txtName" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Name"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">&nbsp</label>
                                                                        <asp:TextBox ID="txtPhone" runat="server" class="form-control" MaxLength="100" placeholder="Contact Information"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">&nbsp</label>
                                                                        <asp:TextBox ID="txtAffiliation" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Affiliation"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv56" runat="server" ControlToValidate="txtAffiliation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save2" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="d-grid mb20">
                                                                        <asp:Button CssClass="ud-btn btn-thm default-box-shadow2" ID="btncasesubmit"  runat="server" OnClick="btnCasesubmit_Click" ValidationGroup="Save2" Text="Submit Now"></asp:Button>
                                                                        <asp:Label ID="lblEvidence" runat="server" Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade fz15 text" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">
                                    <div class="row justify-content-center">
                                        <div class="col-lg-12 px-0">
                                            <div class="new-input-head1">
                                                <h5 class="list-title">Submit a Research Idea
                                                </h5>
                                            </div>

                                        </div>
                                        <div class="col-lg-12">
                                            <div class="row">


                                                <div class="ps-widget bgc-white bdrs4 p30 p15-sm mb30 overflow-hidden position-relative">


                                                    <div class="col-lg-12">
                                                        <div class="form-style1">

                                                            <div class="row">

                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Research Topic Title</label>
                                                                        <asp:TextBox ID="txtResearchTitle" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Provide a concise and descriptive title for your research topic."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txtResearchTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Abstract of Research Topic</label>
                                                                        <asp:TextBox ID="txtAbstract" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="A brief summary of the research topic (150-250 words)."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="txtAbstract" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">
                                                                            Research Objectives:
                                                                        </label>
                                                                        <asp:TextBox ID="txtResearchObjectives" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Clearly state the main objectives of the research."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv8" runat="server" ControlToValidate="txtResearchObjectives" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">
                                                                            Background/Justification:

                                                                        </label>
                                                                        <asp:TextBox ID="txtBackground" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Explain the background and importance of the research topic"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv9" runat="server" ControlToValidate="txtBackground" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">
                                                                            Research Methods:</label>
                                                                        <asp:TextBox ID="txtResearchMethods" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Outline the proposed research methods or approach."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv10" runat="server" ControlToValidate="txtResearchMethods" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">
                                                                            Expected Outcomes</label>
                                                                        <asp:TextBox ID="txtExpectedOutcomes" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Describe the anticipated outcomes or findings of the research."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtExpectedOutcomes" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">References</label>
                                                                        <asp:TextBox ID="txtReferences" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="List any references or prior studies related to the topic."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv12" runat="server" ControlToValidate="txtReferences" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-12">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Additional Comments or Information</label>
                                                                        <asp:TextBox ID="txtComments" runat="server" MaxLength="250" TextMode="MultiLine" cols="30" Rows="6" placeholder="Any additional details or comments about the research topic."></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfv13" runat="server" ControlToValidate="txtComments" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">Submitted By</label>
                                                                        <asp:TextBox ID="txtResName" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Name"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">&nbsp</label>
                                                                        <asp:TextBox ID="txtResPhone" runat="server" class="form-control" MaxLength="100" placeholder="Contact Information"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtResPhone" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-4">
                                                                    <div class="mb20">
                                                                        <label class="heading-color ff-heading fw500 mb10" for="">&nbsp</label>
                                                                        <asp:TextBox ID="txtResAffiliation" runat="server" class="form-control onlyAlpha" MaxLength="100" placeholder="Affiliation"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtResAffiliation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Idea" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="checkbox-style1 d-block d-sm-flex align-items-center justify-content-between mb20">
                                                                    <label class="custom_checkbox fz14 ff-heading">
                                                                        Accept Terms &amp; Condition
                                                                        <input type="checkbox" checked="checked">
                                                                        <span class="checkmark"></span>
                                                                    </label>
                                                                </div>
                                                                <div class="col-sm-4">

                                                                    <div class="d-grid mb20">
                                                             <asp:Button CssClass="ud-btn btn-thm default-box-shadow2" ID="btnIdeaSubmit"   runat="server" OnClick="btnIdeasubmit_Click" ValidationGroup="Idea" Text="Submit Now"></asp:Button>

                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
           <div class="new-fade">
    <div class="modal fade" id="exampleModal1" data-bs-backdrop="static" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body text-center p-5">
                    <h2>Login to Continue</h2>
                    <a href="login.aspx" class="ud-btn btn-thm mt-4 default-box-shadow2">
                        Login <i class="fal fa-arrow-right-long"></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</div>
     <script src="/js/jquery-3.6.4.min.js"></script>
    <script>
        
        $(window).on('load', function () {
            var isLoggedIn = document.cookie.indexOf('med_uid=') !== -1;

            if (!isLoggedIn) {
                $('#exampleModal1').modal('show');
            }
        });
    </script>
</asp:Content>


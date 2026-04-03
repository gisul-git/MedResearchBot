<%@ Page Title="Med Research Ninja | White Paper" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-whitepapers.aspx.cs" Inherits="Admin_manage_whitepapers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">White Paper</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add" %> White Paper</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblStatus" runat="server" Visible="false" Width="100%"></asp:Label>
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> White Paper</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-4">
                                <div class="col-lg-4">
                                    <label>WhitePaper Title<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtName" ID="txtTitle" placeholder="WhitePaper Title" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4">
                                    <label>Thumb Image<sup>*</sup></label>
                                    <asp:FileUpload runat="server" class="form-control mb-2 mr-sm-2" ID="thumbImage" />
                                    <small class="text-danger">Image format .png, .jpeg, .jpg, .webp, .gif with 292px X 215px</small><br />
                                     <%=strThumbImage %>
                                </div>

                                <div class="col-lg-4">
                                    <label>Upload PDF<sup>*</sup></label>
                                    <asp:FileUpload ID="UploadPDF" runat="server" CssClass="form-control"></asp:FileUpload>
                                    <small class="text-danger">.pdf, .doc, formats are required.</small><br />
                                    <div id="divpdf" runat="server" visible="false">
                                       <a href="/<%=strPDF %>" target="_blank">
                                        <img src="assets/images/pdf.png" alt="" width="65" height="60"></a><br />
                                        Check PDF
                                    </div>
                                </div>




                                <div class="col-xxl-3 col-md-6">
                                    <div>
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary waves-effect waves-light m-t-25" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" />
                                        <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info waves-effect waves-light m-t-25" Visible="false" Text="Add New WhitePaper" OnClick="btnNew_Click" />
                                        <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblpdf" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title mb-0 flex-grow-1">Manage White Paper </h4>
                        </div>
                        <div class="card-body">
                            <div class="card-body">
                                <table id="alternative-pagination" class="table nowrap dt-responsive align-middle table-striped table-bordered myTable" style="width: 100%;">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Thumb Image</th>
                                            <th>WhitePaper PDF</th>
                                            <th>Title </th>
                                            <th>AddedOn</th>
                                            <th class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
<%=strAllWhitepaper %>
                                    </tbody>

                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/manage-whitepaper.js"></script>
    <script>
        $(document).ready(function () {
            $(".txtName").change(function () {
                $(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\&/g, 'and').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
            });
        });
    </script>
</asp:Content>



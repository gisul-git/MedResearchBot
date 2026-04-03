<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-blogs.aspx.cs" Inherits="Admin_add_blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Blogs</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Blogs</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Blogs</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Blog Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row mb-2">
                                <div class="col-lg-6">
                                    <label>Blog Title<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtName nospecial" ID="txtName" placeholder="Blog Title" maxlength="100" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6">
                                    <label>Blog URL<sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtUrl" ID="txtUrl" placeholder="Blog Url" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrl" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 mt-2">
                                    <label>Posted By<sup>*</sup></label>
                                    <asp:TextBox runat="server"  MaxLength="100" class="form-control mb-2 mr-sm-2 onlyAlpha" ID="txtPostedBy" placeholder="Posted By" />
                                    <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="txtPostedBy" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 mt-2">
                                    <label>Posted On<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 datepicker" ID="txtPostedOn" placeholder="Posted On" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPostedOn" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12 mt-2">
                                    <label>Short Description</label>
                                    <asp:TextBox runat="server" MaxLength="250" Rows="3" TextMode="MultiLine" class="form-control mb-2 mr-sm-2" ID="txtShortDesc" placeholder="Short Description" />
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-lg-12 mt-2">
                                    <label>Full Description<sup>*</sup></label>
                                    <asp:TextBox runat="server" TextMode="MultiLine" maxlength="250" class="form-control mb-2 mr-sm-2 summernote" ID="txtDesc" Placeholder="Full Description ....." />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header">
                            <h5 class=" card-title">Add Seo Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <label class="text-muted">Page Title</label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtPageTitle" placeholder="Page Title" />
                                </div>
                                <div class="col-lg-12">
                                    <label class="text-muted">Meta Keys</label>
                                    <asp:TextBox ID="txtMetaKey" class="form-control mb-2 mr-sm-2" runat="server" placeholder="Meta Keys" maxlength="100"></asp:TextBox>
                                </div>
                                <div class="col-lg-12">
                                    <label class="text-muted">Meta Description</label>
                                    <asp:TextBox ID="txtMetaDesc" maxlength="250" TextMode="MultiLine" class="form-control mb-2 mr-sm-2" Rows="3" runat="server" placeholder="Meta Description"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Add Image Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12 mb-3">
                                    <label class="text-muted">Thumb Image<sup class="text-danger">*</sup></label>
                                    <asp:FileUpload ID="Thumbimage" runat="server" ToolTip="Maxmimum 1 MB file size" CssClass="form-control"></asp:FileUpload>
                                    <small class="text-danger">.png, .jpeg, .jpg, .gif, .webp formats are required, Image Size Should be 800 × 480 px</small><br />
                                </div>
                                <div class="col-lg-12 mb-3">
                                    <label class="text-muted">Blog Image<sup class="text-danger">*</sup></label>
                                    <asp:FileUpload ID="BlogImage" runat="server" ToolTip="Maxmimum 1 MB file size" CssClass="form-control"></asp:FileUpload>
                                    <small class="text-danger">.png, .jpeg, .jpg, .gif, .webp formats are required, Image Size Should be 1200 × 780 px</small><br />
                                </div>
                                <div runat="server" id="divimg" class="col-lg-12 d-flex justify-content-around" visible="false">
                                    <div class="col-lg-3 text-center">
                                        <%=strBlogImage %>
                                        <h6 class="text-muted mt-1">Blog Image</h6>
                                    </div>
                                    <div class="col-lg-3 text-center">
                                        <%=strThumbImage %>
                                        <h6 class="text-muted mt-1">Thumb Image </h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 mb-3">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" />
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Blog" OnClick="btnNew_Click" />
                    <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblBlog" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".txtName").change(function () {
                $(".txtUrl").val(
                    $(".txtName").val().toLowerCase()
                        .replace(/[\/\\'"&%@~`!#$?()*=\[\]:;|+,]/g, '-')
                        .replace(/\s+/g, '-') 
                        .replace(/\./g, '') 
                );
                //$(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\&/g, 'and').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
            });
        });
    </script>
</asp:Content>



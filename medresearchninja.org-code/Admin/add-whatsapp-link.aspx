<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-whatsapp-link.aspx.cs" Inherits="Admin_add_whatsapp_link" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Whatsapp Link</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Whatsapp Link</a></li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">Whatsapp Link</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <label>Whatsapp Link <sup>*</sup></label>
                            <asp:TextBox runat="server" ID="txtLink" CssClass="form-control" placeholder="enter whatsapp link ..."></asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <asp:Button runat="server" CssClass="btn btn-danger m-t-25" Text="Save" ID="BtnSave" OnClick="BtnSave_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-member.aspx.cs" Inherits="Admin_add_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=(Request.QueryString["id"] != null?"Update":"Add New") %> Members</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);"><%=(Request.QueryString["id"] != null?"Update":"Add New") %> Members</a></li>
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
                            <h5 class="card-title"><%=(Request.QueryString["id"] != null?"Update":"Add New") %> Members</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-2 mb-2">
                                <div class="col-md-4">
                                    <label>Full Name <sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtName" MaxLength="100" placeholder="Full Name" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>Contact No <sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtContactNo" MaxLength="100" placeholder="Mobile Number" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please Enter Valid Mobile No." ForeColor="Red" ValidationGroup="Save" SetFocusOnError="True" Display="Dynamic" ValidationExpression="[1-9][0-9]{9}"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>Email <sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtEmail" placeholder="Email Address" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="Save" ErrorMessage="Enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </div>
                                <div class="col-md-4" id="pwd" runat="server">
                                    <label>Password <sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2 txtPwd" ID="txtPwd" placeholder="Password" TextMode="Password" autocomplete="new-password" MaxLength="20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPwd" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="cnfpwd" runat="server">
                                    <label>Confirm Password <sup>*</sup></label>
                                    <asp:TextBox runat="server" class="form-control mb-2 mr-sm-2" ID="txtConfirm" placeholder="Confirm Password"  TextMode="Password" autocomplete="new-password" MaxLength="20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirm" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmp1" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPwd" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Password doesn't match"> </asp:CompareValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>Medical School</label>
                                    <asp:TextBox runat="server" ID="txtMedical" placeholder="Medical School" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Select Member Type(Who are you?)</label>
                                    <asp:DropDownList runat="server" ID="ddlWho" CssClass="form-select">
                                        <asp:ListItem Value="">Select Member Type</asp:ListItem>
                                        <asp:ListItem Value="Medical Student">Medical Student</asp:ListItem>
                                        <asp:ListItem Value="Graduate">Graduate</asp:ListItem>
                                        <asp:ListItem Value="Resident">Resident</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Select Status</label>
                                    <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-select">
                                        <asp:ListItem Value="Active">Active</asp:ListItem>
                                        <asp:ListItem Value="Unverified">Unverified</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Select Pay Status</label>
                                    <asp:DropDownList runat="server" ID="ddlPayStatus" CssClass="form-select">
                                          <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                          <asp:ListItem Value="Initiated">Initiated</asp:ListItem>
                                          <asp:ListItem Value="Failed">Failed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row gy-3">
                                <div class="col-md-6">
                                    <label>Profile Image </label>
                                    <asp:FileUpload runat="server" class="form-control mb-2 mr-sm-2" ID="fuProfile" />
                                    <small>Image format .png, .jpeg, .jpg, .webp, .gif is required</small>
                                    <br />
                                    <%=strThumbImage %>
                                </div>
                                <div class="col-md-6">
                                    <label>Govt Id </label>
                                    <asp:FileUpload runat="server" class="form-control mb-2 mr-sm-2" ID="fuGovt" />
                                    <small>Image format .png, .jpeg, .jpg, .webp, .gif is required</small>
                                    <br />
                                    <%=strGovtImage %>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Address Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row gy-3">
                                <div class="col-lg-12">
                                    <label>Address</label>
                                    <asp:TextBox runat="server" ID="txtAddress" placeholder="Full Address" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <label>Enter City</label>
                                    <asp:TextBox runat="server" ID="txtCity" placeholder="City" CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-lg-6">

                                    <label>Enter State</label>
                                    <asp:TextBox runat="server" ID="txtState" placeholder="State" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">

                                    <label>Enter Country</label>
                                    <asp:TextBox runat="server" ID="txtCountry" placeholder="Country" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <label>Enter Pincode</label>
                                    <asp:TextBox runat="server" ID="txtPincode" placeholder="Country" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12 mb-3">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" Style="margin-top: 10px;" />
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New" OnClick="btnNew_Click" Style="margin-top: 10px;" />
                    <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblGovt" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


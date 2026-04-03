<%@ Page Title="MedResearchNinja" Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MedResearchNinja Test With Github</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="MedResearchNinja" name="author" />
    <!-- App favicon -->
    <link rel="shortcut icon" href="assets/images/logo(4).png" />

    <!-- Bootstrap Css -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Icons Css -->
    <link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />
    <!-- App Css-->
    <link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />
    <!-- custom Css-->
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="auth-page-wrapper pt-5">
            <div class="auth-page-content">
                <div class="container">
                    <!-- end row -->
                    <div class="row justify-content-center">
                        <div class="col-md-12 col-lg-10 col-xl-10">
                            <div class="card mt-4">
                                <div class="card-body p-4">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <img src="assets/images/login-bg.jpg" class="w-100" />
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="text-center mt-2">
                                                <a href="javascript:void();" class="d-inline-block auth-logo">
                                                    <img src="/Img/websiteLogos/logo.png" class="filter_0" alt="" height="70" />
                                                </a>
                                            </div>
                                            <div class="text-center mt-2">
                                                <h5 class="text-primary">Welcome Back !</h5>
                                                <p class="text-muted">Sign in to continue to MedResearchNinja</p>
                                                <asp:Label ID="lblStatus" runat="server" Style="width: 100%;" Visible="false"></asp:Label>
                                            </div>
                                            <div class="p-2 mt-4 mb-4">
                                                <div class="mb-3">
                                                    <label for="username" class="form-label">User Id<span class="text-danger">*</span></label>
                                                    <asp:TextBox runat="server" class="form-control" ID="txtUserName" MaxLength="100" placeholder="Enter username" />
                                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Login" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="mb-3">
                                                    <div class="float-end">
                                                        <u class="text-muted"><a href="forgot-password.aspx">Forgot password?</a></u>
                                                    </div>
                                                    <label class="form-label" for="password-input">Password<span class="text-danger">*</span></label>
                                                    <div class="position-relative auth-pass-inputgroup mb-3">
                                                        <asp:TextBox runat="server" MaxLength="100" TextMode="Password" class="form-control pe-5 password-input" placeholder="Enter password" ID="txtPassword" />
                                                        <button class="btn btn-link position-absolute end-0 top-0 text-decoration-none text-muted shadow-none password-addon" type="button" id="password-addon"><i class="mdi mdi-eye align-middle fs-16 vispass"></i></button>
                                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Login" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-check">
                                                    <input class="form-check-input" type="checkbox" runat="server" value="" id="chkLogKeep" />
                                                    <label class="form-check-label" for="<%=chkLogKeep.ClientID %>">Remember me</label>
                                                </div>
                                                <div class="mt-4">
                                                    <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" class="btn btn-primary btn-primary-login w-100" ValidationGroup="Login" Text="Sign In" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mt-4 text-center">
                                <p class="mb-0">
                                    &copy; 
                                    <script>document.write(new Date().getFullYear())</script>
                                    Med Research Ninja
                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <footer class="footer">
                <div class="container">     
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="text-center">
                               <a href="https://www.nextwebi.com/"> <p class="mb-0 text-muted">
                                    Designed & Developed by Nextwebi
                           
                                </p></a> 
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
        <!-- JAVASCRIPT -->
        <script src="assets/libs/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="assets/js/plugins.js"></script>
        <script src="assets/libs/prismjs/prism.js"></script>
        <script src="assets/js/pages/notifications.init.js"></script>
        <script src="assets/js/pages/password-addon.init.js"></script>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-job-applications.aspx.cs" Inherits="Admin_manage_job_applications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Job Applications</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Enquiries</a></li>
                                <li class="breadcrumb-item active">View Job Applications</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">View Job Applications</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <table id="alternative-pagination" class="table nowrap align-middle table-striped table-bordered myTable" style="width: 100%">
                                    <thead>
                                       <tr>
    <th>#</th>
    <th>Full Name</th>
    <th>Resume</th>
    <th>Email Id</th>
    <th>Contact No</th>
    <th>Experience</th>
    <th>Location</th>
    <th>Current salary</th>
    <th>Expected salary</th>
    <th>Job Type</th>
    <th>Notice Period</th>
    <th class="text-center">Action</th>
</tr>
                                    </thead>
                                    <tbody>
                                        <%=StrJobApplications %>
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
    <script src="assets/js/pages/manage-job-applications.js"></script>
</asp:Content>


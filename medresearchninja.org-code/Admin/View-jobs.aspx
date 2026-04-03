<%@ Page Title="Med Research Ninja | View Job" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="View-jobs.aspx.cs" Inherits="Admin_View_jobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">View All Jobs</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="/javascript: void(0);">Career</a></li>
                                <li class="breadcrumb-item active">View Jobs</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">View Jobs</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="alternative-pagination" class="table table-nowrap align-middle table-striped table-bordered myTable" style="width: 100%">
                                <thead class="">
                                    <tr>
                                        <th>#</th>
                                        <th>Job Type</th>
                                        <th>Job Title</th>
                                        <th>Job Location</th>
                                        <th>Added On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                       <%=strJobs%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/view-jobs.js"></script>
</asp:Content>



<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/MasterPage.master" CodeFile="manage-forum-post.aspx.cs" Inherits="Admin_manage_forum_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .Tdetails td:first-child {
            padding: .3rem .25rem !important;
        }

        .pageLenght {
            width: 80px;
            padding: 5px;
            margin: 5px;
            height: 30px;
        }

        .password-addon {
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }

        .txtsearch {
            width: 360px;
            height: 30px;
            border-radius: 5px;
            border: 1px solid #e1e1e1;
            margin-bottom: 20px;
            padding: 10px 20px;
        }

        .fixed-width {
            width: 500px;
        }

        .fixed-width3 {
            width: 200px;
            text-align: start;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Discussion Forum</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Discussion Forum</a></li>
                                <li class="breadcrumb-item active">Manage Forum Post</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header d-flex justify-content-between">
                            <h5 class="card-title">View Forum Post</h5>
                        </div>
                        <div class="card-body">

                            <div class="row mt-2">
                                <div class="col-lg-6 col-md-6 d-flex">
                                    <label style="margin-top: 10px;">Show </label>
                                    <select name="pageLenght" class="form-select form-select-sm pageLenght">
                                        <option value="10">1</option>
                                        <option value="20">2</option>
                                        <option value="50">5</option>
                                        <option value="100">10</option>
                                    </select>
                                    <label style="margin-top: 10px;">entries</label>
                                </div>
                                <div class="col-lg-6 text-end">
                                    <input class="txtsearch" placeholder="search by Title or Topics" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 table-responsive">
                                    <table id="alternative-pagination" class="table align-middle table-striped table-bordered" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Title</th>
                                                <th>Topic/Subject</th>
                                                <th class="text-center">Added By</th>
                                                <th class="text-center">Added On</th>
                                                <th class="col-1">Status</th>
                                                <th class="text-center">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody class="StrForumPost">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <nav aria-label="Page navigation" class="mt-2">
                            <ul class="mppagination pagination justify-content-center">
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="DescModal" tabindex="-1" aria-labelledby="DescModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="DescModalLabel">Project Overview</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body modalbody">
                    ...
                </div>

            </div>
        </div>
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/manage-forum-post.js"></script>

</asp:Content>



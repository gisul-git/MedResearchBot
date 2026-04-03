<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="project-due-success.aspx.cs" Inherits="project_due_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .flickity-viewport {
            height: 400px !important;
        }

        tbody, td, tfoot, th, thead, tr {
            border-width: 1px;
        }

        select {
            border-radius: unset !important;
        }


        @media (min-width: 1025px) {
            #nt_footer {
                position: static;
            }
        }

        .my-5 {
            margin-top: 3rem !important;
            margin-bottom: 0rem !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="py_6">
        <div class="container">
            <div class="row my-5 justify-content-center">
                <div class="col-md-8">
                    <div class="card border-0">
                        <div class="card-body text-center">
                            <%=strStatus %>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="card-body text-center">
            <a href="/" class="ud-btn btn-thm">back to home</a>
        </div>
    </section>
</asp:Content>


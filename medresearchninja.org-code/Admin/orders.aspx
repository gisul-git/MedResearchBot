<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/MasterPage.master" CodeFile="orders.aspx.cs" Inherits="Admin_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .fs-8 {
            font-size: 8px;
        }

        .topbar-badge {
            right: -10px;
            top: 1px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Orders</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Reports</a></li>
                                <li class="breadcrumb-item active">View Orders</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-title">View Orders</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <table id="alternative-pagination" class="table align-middle table-striped table-bordered myTable" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Order Id</th>
                                            <th>User Details</th>
                                            <th>Project Name</th>
                                            <th>Total Price</th>
                                            <th>Payment Status</th>
                                            <th>Order Date</th>
                                            <th>Payment Id</th>
                                            <th class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%=StrOrders %>
                                    </tbody>

                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
      <div class="modal fade" id="PaymentModel" data-orderguid="" tabindex="-1" aria-labelledby="exampleModalgridLabel2" aria-hidden="true" style="display: none;">
      <div class="modal-dialog">
          <div class="modal-content">
              <div class="modal-header">
                  <h5 class="modal-title">Update Payment Status</h5>
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="modal-body">

                  <div class="row g-3">
                      <!--end col-->
                      <div class="col-xxl-12">
                          <div>
                              <label for="txtPayId" class="form-label">Payment Id<sup>*</sup></label>
                              <input type="text" class="form-control" maxlength="100" id="txtPayId">
                              <span class="text-danger error"></span>
                          </div>
                      </div>
                      <div class="col-lg-12">
                          <div class="hstack gap-2 justify-content-end">
                              <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                              <button type="button" id="btnPayStatus" class="btn btn-primary">Submit</button>
                          </div>
                      </div>
                  </div>
                  <!--end col-->
              </div>
              <!--end row-->

          </div>
      </div>
  </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/pages/orders.js"></script>
</asp:Content>


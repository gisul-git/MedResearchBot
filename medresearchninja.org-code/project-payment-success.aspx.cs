using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class project_payment_success : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["O"] != null)
        {
            strStatus = "<img style='height:300px;' class='mb-3' src='/assets/images/rb_20631.png' />" +
                 "<h3 class='main-heading text-success text-dark'>" +
    "<strong>Welcome to the Project ! </strong></h3><h5 class='mt-2'>You have successfully enrolled in our project. Please check your email for further instructions, including a link to join the project's exclusive WhatsApp group." +

    "Stay connected, collaborate with the team, and get access to important updates, resources, and opportunities!</h3>";
            var orderid = Request.QueryString["O"];

            //UserCheckout.SendToUser(conMN, orderid);

            var order = PReports.GetSingleOrderDetailsWOid(conMN, orderid);
            var exe1 = PayUAPI.VerifyPayment(order.OrderGuid);
            if (exe1 != null)
            {
                if (exe1.Status == "1")
                {

                    if (order != null)
                    {

                        POrders orders = new POrders();
                        string Oid = orderid;  //UserCheckout.GetOrderId(conMN, orderid);
                        string rId = PUserCheckout.GetRMax(conMN);
                        orders.OrderGuid = order.OrderGuid;
                        orders.PaymentStatus = "Paid";
                        orders.OrderStatus = "Completed";
                        orders.UserName = order.UserName;
                         orders.PaymentMode = "PayU";
                        orders.EmailId = order.EmailId;
                        orders.Contact = order.Contact;
                        orders.PaymentId = exe1.Transaction_Details[order.OrderGuid].Mihpayid;
                        orders.hostedCheckoutId = "";
                        orders.RMax = rId;
                        orders.ReceiptNo = "MEDIR" + rId;
                        int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                        if (x > 0)
                        {
                            var user = Convert.ToString(Reports.GetUserByOrder(conMN, orders.OrderGuid));
                            if (user != "")
                            {
                                var timeline = new OrderTimeline()
                                {
                                    OrderGuid = orderid,
                                    OrderStatus = "Confirmed",
                                    AddedBy = user,
                                };
                                var exe = OrderTimeline.AddTimeline(conMN, timeline);
                                MemberDetails.UpdatePaymentStatus(conMN, user);
                                var userDetail = MemberDetails.GetMemberDetailsByGuid(conMN, user);
                            }
                            else
                            {
                                strStatus = @"There is some problem now. Please try again later";
                            }

                        }
                        Emails.NewProjectMail(order.UserName, order.ProjectName, order.EmailId, order.ProjectLink);
                        Emails.NewProjectMailAdmin(order.UserName, order.EmailId, order.ProjectName);
                    }
                }
                else
                {
                    strStatus = "<img style='height:200px;' src='/images/x.gif' /><h3 class='main-heading text-danger'>Not Found!<br>Your order can not be found. please contact adminstration for furthur details.</h3>";
                }

            }

        }
        else
        {
            Response.Redirect("/");
        }

    }

}
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

public partial class project_paypal_status : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string payStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProcessPayPalPayment();
        }
    }

    private void ProcessPayPalPayment()
    {
        try
        {
            string paymentId = Request.QueryString["paymentId"];
            string token = Request.QueryString["token"];
            string PayerID = Request.QueryString["PayerID"];
            string orderGuid = Request.QueryString["o"];

            if (string.IsNullOrEmpty(paymentId) || string.IsNullOrEmpty(PayerID) || string.IsNullOrEmpty(orderGuid))
            {
                payStatus = "Invalid payment parameters.";
                Response.Redirect("pay-error.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }

            // Initialize PayPal API
            string clientId = ConfigurationManager.AppSettings["PaypalClientId"];
            string clientSecret = ConfigurationManager.AppSettings["PaypalSecretId"];
            string mode = ConfigurationManager.AppSettings["PaypalMode"];

            var config = new Dictionary<string, string>();
            config.Add("mode", mode);
            config.Add("clientId", clientId);
            config.Add("clientSecret", clientSecret);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken) { Config = config };

            // Execute the payment
            var payment = new Payment() { id = paymentId };
            var paymentExecution = new PaymentExecution() { payer_id = PayerID };
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            string status = executedPayment.state;

            POrders orders = new POrders();

            if (status == "approved")
            {
                string Oid = PUserCheckout.GetOrderId(conMN, orderGuid);
                string rId = PUserCheckout.GetRMax(conMN);
                List<POrders> order = PReports.GetSingleOrderDetails(conMN, orderGuid);
                orders.OrderGuid = orderGuid;
                orders.PaymentStatus = "Paid";
                orders.OrderStatus = "Completed";
                orders.PaymentId = paymentId;
                orders.hostedCheckoutId = "";
                orders.PaymentMode = "PayPal";
                orders.RMax = rId;
                orders.UserName = order[0].UserName;
                orders.EmailId = order[0].EmailId;
                orders.Contact = order[0].Contact;
                orders.ReceiptNo = "MEDPROJECT" + rId;
                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                if (x > 0)
                {
                    if (order != null && order.Count > 0)
                    {
                        Emails.NewProjectMail(order[0].UserName, order[0].ProjectName, order[0].EmailId, order[0].ProjectLink);
                        Emails.NewProjectMailAdmin(order[0].UserName, order[0].EmailId, order[0].ProjectName);
                        var timeline = new OrderTimeline()
                        {
                            OrderGuid = orderGuid,
                            OrderStatus = "Completed",
                            AddedBy = order[0].UserName,
                        };
                        OrderTimeline.AddTimeline(conMN, timeline);
                        Response.Redirect("project-paypal-success.aspx?O=" + orderGuid, false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        payStatus = "Project not found for this order.";
                        Response.Redirect("pay-error.aspx", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    payStatus = "Failed to update order status.";
                    Response.Redirect("pay-error.aspx", false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                orders.OrderGuid = orderGuid;
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.RMax = "";
                orders.ReceiptNo = "";
                orders.PaymentMode = "";

                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                Response.Redirect("project-paypal-failed.aspx?o=" + orderGuid, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "project_paypal_status_ProcessPayment", ex.Message);
            payStatus = "An error occurred while processing your payment.";
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
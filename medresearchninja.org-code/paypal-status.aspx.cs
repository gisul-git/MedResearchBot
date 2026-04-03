using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

public partial class paypal_status : System.Web.UI.Page
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

            Orders orders = new Orders();

            if (status == "approved")
            {
                string Oid = UserCheckout.GetOrderId(conMN, orderGuid);
                string rId = UserCheckout.GetRMax(conMN);

                orders.OrderGuid = orderGuid;
                orders.PaymentStatus = "Paid";
                orders.OrderStatus = "Completed";
                orders.PaymentId = paymentId;
                orders.hostedCheckoutId = "";
                orders.RMax = rId;
                orders.ReceiptNo = "MEDIR" + rId;

                int x = UserCheckout.UpdateUserOrder(conMN, orders);

                if (x > 0)
                {
                    var user = Convert.ToString(Reports.GetUserByOrder(conMN, orderGuid));

                    if (!string.IsNullOrEmpty(user))
                    {
                        var timeline = new OrderTimeline()
                        {
                            OrderGuid = orderGuid,
                            OrderStatus = "Confirmed",
                            AddedBy = user,
                        };
                        OrderTimeline.AddTimeline(conMN, timeline);
                        MemberDetails.UpdatePaymentStatus(conMN, user);
                        var userDetail = MemberDetails.GetMemberDetailsByGuid(conMN, user);
                        var pwd = CommonModel.Decrypt(userDetail.Password);
                        var mail = Emails.NewMembershipMail(userDetail.FullName, userDetail.EmailId, pwd, userDetail.WLink);
                        var admmail = Emails.NewMembershipMailAdmin(userDetail.FullName, userDetail.EmailId);

                        Response.Redirect("paypal-success.aspx?O=" + orderGuid + @"", false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        payStatus = "User not found for this order.";
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

                int x = UserCheckout.UpdateUserOrder(conMN, orders);
                Response.Redirect("pay-error.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (ThreadAbortException)
        {
            // Expected exception - ignore
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "paypal_status_ProcessPayment", ex.Message);
            payStatus = "An error occurred while processing your payment.";
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
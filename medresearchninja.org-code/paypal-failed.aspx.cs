using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class paypal_failed : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string payStatus = "Payment was cancelled or failed.";
    public string orderGuid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProcessFailedPayment();
        }
    }

    private void ProcessFailedPayment()
    {
        try
        {
            orderGuid = Request.QueryString["o"];

            if (!string.IsNullOrEmpty(orderGuid))
            {
                Orders orders = new Orders();
                orders.OrderGuid = orderGuid;
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.RMax = "";
                orders.ReceiptNo = "";

                int x = UserCheckout.UpdateUserOrder(conMN, orders);

                if (x > 0)
                {
                    payStatus = "Your payment was cancelled. You can try again by clicking the button below.";
                }
                else
                {
                    payStatus = "Failed to update order status. Please contact support.";
                }
            }
            else
            {
                payStatus = "Invalid order reference. Please contact support.";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "paypal_failed_ProcessFailedPayment", ex.Message);
            payStatus = "An error occurred. Please contact support.";
        }
    }
}
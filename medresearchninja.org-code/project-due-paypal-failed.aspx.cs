using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class project_due_paypal_failed : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string payStatus = "Payment was cancelled or failed.";
    public string paymentGuid = "";

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
            paymentGuid = Request.QueryString["p"];

            if (!string.IsNullOrEmpty(paymentGuid))
            {
                ProjectDues dues = new ProjectDues();
                dues.PaymentGuid = paymentGuid;
                dues.PaymentStatus = "Failed";
                dues.PaymentId = "";
                dues.tr_id = "";
                dues.PaymentMode = "PayPal";
                dues.PaymentDate = Convert.ToString(TimeStamps.UTCTime());
                dues.RMax = "";
                dues.ReceiptNo = "";

                int x = Projects.UpdateProjectDuesPayment(conMN, dues);

                if (x > 0)
                {
                    payStatus = "Your payment was cancelled. You can try again by clicking the button below.";
                }
                else
                {
                    payStatus = "Failed to update payment status. Please contact support.";
                }
            }
            else
            {
                payStatus = "Invalid payment reference. Please contact support.";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "project_due_paypal_failed_ProcessFailedPayment", ex.Message);
            payStatus = "An error occurred. Please contact support.";
        }
    }
}
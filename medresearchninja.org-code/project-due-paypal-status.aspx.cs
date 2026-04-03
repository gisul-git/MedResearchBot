using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

public partial class project_due_paypal_status : System.Web.UI.Page
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
            string paymentGuid = Request.QueryString["p"];

            if (string.IsNullOrEmpty(paymentId) || string.IsNullOrEmpty(PayerID) || string.IsNullOrEmpty(paymentGuid))
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

            // Get payment details
            var p_Details = Projects.GetPaymentDetailsBy_PaymentGuid(conMN, paymentGuid);

            if (p_Details.Rows.Count > 0)
            {
                ProjectDues dues = new ProjectDues();
                string rId = Projects.GetRMax(conMN);

                if (status == "approved")
                {
                    // Get USD amount from PayPal transaction
                    decimal usdAmount = Convert.ToDecimal(executedPayment.transactions[0].amount.total);

                    // Update payment details
                    dues.PaymentGuid = paymentGuid;
                    dues.PaymentId = paymentId;
                    dues.tr_id = paymentId;
                    dues.PaymentMode = "PayPal";
                    dues.PaymentStatus = "Paid";
                    dues.PaymentDate = Convert.ToString(TimeStamps.UTCTime());
                    dues.RMax = rId;
                    dues.ReceiptNo = "MEDUE" + rId;

                    int x = Projects.UpdateProjectDuesPayment(conMN, dues);

                    if (x > 0)
                    {
                        // Send emails
                        decimal amount = Convert.ToDecimal(p_Details.Rows[0]["Amount"]);
                        string fullName = Convert.ToString(p_Details.Rows[0]["FullName"]);
                        string projectName = Convert.ToString(p_Details.Rows[0]["ProjectName"]);
                        string projectId = Convert.ToString(p_Details.Rows[0]["ProjectId"]);
                        string email = Convert.ToString(p_Details.Rows[0]["EmailId"]);

                        string mailSubject = "Payment Successful – Project ID: #" + projectId;

                        #region Member Mail Body
                        string MailBody = @"Dear " + fullName + @", 

                                            <p>We are pleased to inform you that your payment for the project has been successfully received.</p>

                                            <p><strong>Project Details:</strong></p>

                                            <p>
                                            <strong>Project Name:</strong> " + projectName + @"<br>
                                            <strong>Project ID:</strong> #" + projectId + @"<br>
                                            <strong>Amount Paid :</strong> ₹" + amount.ToString("##,##,##,###") + @" (~$" + usdAmount.ToString("0.00") + @")</p>

                                            <p>If you have any questions or need further assistance, feel free to reach out to our support team.</p>

                                            <p>Thank you for your continued association with <strong>Med Research Ninja</strong>.</p>

                                            <p>Best regards,<br>
                                            Team Med Research Ninja<br>
                                            Email: connect@medresearchninja.com</p>";
                        #endregion

                        #region Admin Mail Body

                        string MailBodyAdmin = @"Dear Admin,

                                                <p>A payment has been successfully received for the following project:</p>

                                                <p>
                                                <strong>Project Name:</strong> " + projectName + @"<br>
                                                <strong>Project ID:</strong> #" + projectId + @"<br>
                                                <strong>Amount Paid :</strong> ₹" + amount.ToString("##,##,##,###") + @" (~$" + usdAmount.ToString("0.00") + @") </p>
                                               

                                                <p> Regards,</br>
                                                Med Research Ninja System </p> ";
                        #endregion

                        int memberMail = Emails.SendMailtoMember("Payment Success", email, "", "", mailSubject, MailBody);
                        int adminMail = Emails.SendMailtoAdmin("Payment Success", mailSubject, MailBodyAdmin);

                        Response.Redirect("project-due-paypal-success.aspx?p=" + projectId, false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        payStatus = "Failed to update payment status.";
                        Response.Redirect("project-due-paypal-failed.aspx?p=" + paymentGuid, false);
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    dues.PaymentGuid = paymentGuid;
                    dues.PaymentId = "";
                    dues.tr_id = "";
                    dues.PaymentMode = "PayPal";
                    dues.PaymentStatus = "Failed";
                    dues.PaymentDate = Convert.ToString(TimeStamps.UTCTime());
                    dues.RMax = "";
                    dues.ReceiptNo = "";

                    int x = Projects.UpdateProjectDuesPayment(conMN, dues);
                    Response.Redirect("project-due-paypal-failed.aspx?p=" + paymentGuid, false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                payStatus = "Payment details not found.";
                Response.Redirect("pay-error.aspx", false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "project_due_paypal_status_ProcessPayment", ex.Message);
            payStatus = "An error occurred while processing your payment.";
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class project_due_status : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["p"]))
        {
            var p_guid = Request.QueryString["p"];
            var p_details = Projects.GetPaymentDetailsBy_PaymentGuid(conMN, p_guid);
            var exe1 = PayUAPI.VerifyPayment(p_guid);

            if (exe1 != null && exe1.Transaction_Details != null && exe1.Transaction_Details.ContainsKey(p_guid))
            {
                if (exe1.Status == "1")
                {
                    ProjectDues dues = new ProjectDues();
                    string rId = Projects.GetRMax(conMN);
                    dues.PaymentGuid = p_guid;
                    dues.PaymentId = exe1.Transaction_Details[p_guid].Mihpayid;
                    dues.tr_id = exe1.Transaction_Details[p_guid].Mihpayid;
                    dues.PaymentMode = "Online";
                    dues.PaymentStatus = "Paid";
                    dues.PaymentDate = Convert.ToString(TimeStamps.UTCTime());
                    dues.RMax = rId;
                    dues.ReceiptNo = "MEDUE" + rId;
                    int x = Projects.UpdateProjectDuesPayment(conMN, dues);
                    if (x > 0 && p_details.Rows.Count > 0)
                    {
                        decimal amount = 0;
                        string fullName = Convert.ToString(p_details.Rows[0]["FullName"]);
                        string projectName = Convert.ToString(p_details.Rows[0]["ProjectName"]);
                        string projectId = Convert.ToString(p_details.Rows[0]["ProjectId"]);
                        decimal.TryParse(Convert.ToString(p_details.Rows[0]["Amount"]), out amount);

                        string mailSubject = "Payment Successful – Project ID: #" + projectId;

                        #region Member Mail Body
                        string MailBody = @"Dear " + fullName + @", 

                                            <p>We are pleased to inform you that your payment for the project has been successfully received.</p>

                                            <p><strong>Project Details:</strong></p>

                                            <p>
                                            <strong>Project Name:</strong> " + projectName + @"<br>
                                            <strong>Project ID:</strong> #" + projectId + @"<br>
                                            <strong>Paid Amount:</strong> ₹" + amount.ToString("##,##,##,###") + @"</p>

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
                                                <strong>Amount Paid:</strong> ₹" + amount.ToString("##,##,##,###") + @"</p>

                                                <p>Regards,<br>
                                                Med Research Ninja System</p>";
                        #endregion

                        int memberMail = Emails.SendMailtoMember("Payment Success", Convert.ToString(p_details.Rows[0]["EmailId"]), "", "", mailSubject, MailBody);
                        int adminMail = Emails.SendMailtoAdmin("Payment Success", mailSubject, MailBodyAdmin);

                        if (memberMail == 1 && adminMail == 1)
                        {
                            Response.Redirect("project-due-success.aspx?p=" + Convert.ToString(p_details.Rows[0]["ProjectId"]), false);
                        }
                        else
                        {
                            Response.Redirect("project-due-success.aspx?p=" + Convert.ToString(p_details.Rows[0]["ProjectId"]), false);
                        }
                    }
                }
                else
                {
                    ProjectDues dues = new ProjectDues();
                    dues.PaymentGuid = p_guid;
                    dues.PaymentId = "";
                    dues.tr_id = "";
                    dues.PaymentMode = "Online";
                    dues.PaymentStatus = "Failed";
                    dues.PaymentDate = Convert.ToString(TimeStamps.UTCTime());
                    dues.RMax = "";
                    dues.ReceiptNo = "";
                    int x = Projects.UpdateProjectDuesPayment(conMN, dues);
                    if (x > 0 && p_details.Rows.Count > 0)
                    {
                        Response.Redirect("project-due-error.aspx?p=" + Convert.ToString(p_details.Rows[0]["ProjectId"]), false);
                    }
                }
            }
            else
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "__PaymentDue", "Null response or missing transaction details from PayU.");
            }
        }

    }
}
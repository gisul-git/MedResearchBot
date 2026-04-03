using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Admin_view_project_dues : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static SearchReports BindReports(string pNo, string pSize, string sDay, string fromDate, string toDate, string oStatus, string pStatus, string oParam)
    {
        SearchReports reports = new SearchReports();
        try
        {
            string strSales = "";
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            if (!CreateUser.CheckAccess(conMN, "view-project-dues.aspx", "View", HttpContext.Current.Request.Cookies["med_aid"].Value))
            {
                return reports;
            }

            int pNo2 = 0, pSize2 = 0;
            int.TryParse(pNo, out pNo2);
            int.TryParse(pSize, out pSize2);
            DateTime cDate = TimeStamps.UTCTime();
            string sFrom = "";
            string sTo = "";

            if (sDay != "")
            {
                switch (sDay)
                {
                    case "Today":
                        sFrom = cDate.ToString("dd-MMM-yyyy");
                        sTo = cDate.ToString("dd-MMM-yyyy");
                        break;
                    case "YDay":
                        sFrom = cDate.AddDays(-1).ToString("dd-MMM-yyyy");
                        sTo = cDate.AddDays(-1).ToString("dd-MMM-yyyy");
                        break;
                    case "L7Days":
                        sFrom = cDate.AddDays(-7).ToString("dd-MMM-yyyy");
                        sTo = cDate.ToString("dd-MMM-yyyy");
                        break;
                    case "L30Days":
                        sFrom = cDate.AddDays(-30).ToString("dd-MMM-yyyy");
                        sTo = cDate.ToString("dd-MMM-yyyy");
                        break;
                }
            }
            else
            {
                sFrom = fromDate == "" ? "" : Convert.ToDateTime(fromDate).ToString("dd-MMM-yyyy");
                sTo = toDate == "" ? "" : Convert.ToDateTime(toDate).ToString("dd-MMM-yyyy");
            }

            var order = Reports.GetAllProjectDues(conMN, pNo2, pSize2, sFrom, sTo, oStatus, pStatus, oParam);
            if (order.Rows.Count > 0)
            {
                for (int i = 0; i < order.Rows.Count; i++)
                {
                    string PaymentStatus = Convert.ToString(order.Rows[i]["PaymentStatus"]);
                    string payStatus = "";
                    var email = Convert.ToString(order.Rows[i]["EmailId"]) == "" ? "<a href='javascript:void(0);' class='bs-tooltip text-muted fs-18 mr-5px' data-bs-toggle='tooltip' data-placement='top' title='this order does not have email id to send reminder'><i class='mdi mdi-email-off'></i></a>" : "<a href='javascript:void();' class='bs-tooltip text-danger fs-18 mr-5px paymentDueMailReminder' data-id='" + Convert.ToString(order.Rows[i]["id"]) + "' data-guid='" + Convert.ToString(order.Rows[i]["PaymentGuid"]) + "' data-bs-toggle='tooltip' data-placement='top' title='Send Payment Due Reminder'><i class='mdi mdi-email'></i></a>";


                    switch (PaymentStatus.ToLowerInvariant())
                    {
                        case "initiated":
                            payStatus = "<span class='badge badge-soft-warning badge-border'>Initiated</span>";
                            break;

                        case "paid":
                            payStatus = "<span class='badge badge-soft-success badge-border'>Paid</span>";
                            email = "<a href='javascript:void(0);' class='bs-tooltip text-muted fs-18 mr-5px text-muted' data-bs-toggle='tooltip' data-placement='top' title='Payment Paid'><i class='mdi mdi-email-check'></i></a>";
                            break;
                    }



                    decimal totalAmount = 0;
                    decimal.TryParse(Convert.ToString(order.Rows[i]["Amount"]), out totalAmount);

                    int PageIndex = ((pNo2 - 1) * pSize2);

                    strSales += @"<tr>
                                    <td><span>" + (PageIndex + (i + 1)) + @"</span></td>
                                    <td><a class='badge badge-outline-primary' href='javascript:void(0);'>" + Convert.ToString(order.Rows[i]["ProjectId"]) + @"</a></td>
                                    <td>" + Convert.ToString(order.Rows[i]["projectname"]) + @"</td>
                                    <td><a class='badge badge-outline-info' href='javascript:void(0);'>" + Convert.ToString(order.Rows[i]["userid"]) + @"</a></td>
                                    <td>" + Convert.ToString(order.Rows[i]["fullname"]) + @"</td>
                                    <td><strong>₹" + (totalAmount > 0 ? totalAmount.ToString("##,##,##,###") : "0") + @"</strong>  (~$" + Convert.ToDecimal(order.Rows[i]["AmountUSD"]).ToString("##,##,###") + @")</td> 
                                    <td>" + payStatus + @"</td> 
                                    <td>" + Convert.ToString(order.Rows[i]["PaymentMode"]) + @"</td>
                                    <td>" + (string.IsNullOrEmpty(Convert.ToString(order.Rows[i]["tr_id"])) ? "-" : Convert.ToString(order.Rows[i]["tr_id"])) + @"</td>
                                    <td>" + Convert.ToDateTime(Convert.ToString(order.Rows[i]["AddedOn"])).ToString("dd-MMM-yyyy hh:mm tt") + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["Comments"]) + @"</td>
                                    <td class='text-center'>" + email + @"</td>
                                  </tr>";
                }

                int totalN = 0;
                int.TryParse(Convert.ToString(order.Rows[0]["TotalOrder"]), out totalN);

                reports.Status = "Success";
                reports.TotalCount = totalN;
                reports.LineItems = strSales;
            }
            else
            {
                reports.Status = "error";
                reports.StatusMessage = "No Data";
            }
        }
        catch (Exception ex)
        {
            reports.Status = "error";
            reports.StatusMessage = ex.Message;
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindReport", ex.Message);
        }
        return reports;
    }

    [WebMethod(EnableSession = true)]
    public static string PaymentReminderEmail(string pay_guid)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            decimal dueAmount = 0;

            var pay_details = Projects.GetPaymentDetailsBy_PaymentGuid(conMN, pay_guid);
            if (pay_details.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(pay_details.Rows[0]["amount"]), out dueAmount);

                int mailStatus = 0;

                var p_details = Projects.GetProjectDetails(conMN, Convert.ToString(pay_details.Rows[0]["ProjectGuid"]));
                if (p_details != null)
                {
                    var project_id = Convert.ToString(p_details.ProjectId);
                    var project_name = Convert.ToString(p_details.ProjectName);

                    string m_name = "", m_email = "";
                    var m_details = MemberDetails.GetMemberDetailsByGuid(conMN, Convert.ToString(pay_details.Rows[0]["UserGuid"]));
                    if (m_details != null)
                    {
                        m_name = Convert.ToString(m_details.FullName);
                        m_email = Convert.ToString(m_details.EmailId);
                    }

                    var pay_link = ConfigurationManager.AppSettings["domain"] + "my-payment.aspx";

                    string payNow_Button = "<table style='border-collapse:collapse;width:99%;' border='0'><tbody><td style='padding: 15px;' align='center'><a style='padding:10px 15px;background-color:#4caf50 !important;color:#fff;border-radius:5px;white-space:nowrap;text-decoration:none;' href='" + pay_link + "'>Pay Now</a></td></tr></tbody></table>";

                    var mailSubject = "Reminder: Payment Due – Project ID: #" + project_id;

                    #region Mail Body
                    string MailBody = @"Dear " + m_name + @", 

                    <p>We hope you are doing well.</p>

                    <p>This is a gentle reminder that the payment for the project mentioned below is still pending. We kindly request you to log in to your Med Research Ninja account and complete the payment at your earliest convenience.</p>

                    <p><strong>Project ID:</strong> #" + project_id + @"</p>

                    <p><span style='text-decoration:underline;font-size:14pt;'><strong>Payment Summary:</strong></span></p>

                    <p><strong>Project ID:</strong> #" + project_id + @"<br>
                        <strong>Project Name:</strong> " + project_name + @"<br>
                        <strong>Outstanding Amount:</strong> ₹" + dueAmount.ToString("##,##,##,###") + @"</p>

                    <p>Please click the button below to log in and access the <strong>Payments</strong> section to settle the pending amount.</p>

                    " + payNow_Button + @"

                    <p><strong>Login Link:</strong> <a href='" + pay_link + @"' target='_blank'>" + pay_link + @"</a></p>

                    <p><em>If payment has already been completed, kindly disregard this reminder.</em></p>

                    <p>We appreciate your cooperation. Should you require any support, please don’t hesitate to contact our team.</p>

                    <p>Thank you for your continued engagement with <strong>Med Research Ninja</strong>.</p>

                    <p>Best regards,<br>
                    Team Med Research Ninja<br>
                    Email: connect@medresearchninja.com</p>";
                    #endregion

                    mailStatus = Emails.SendMailtoMember("⏰ Payment Due Reminder", m_email, "", "", mailSubject, MailBody);
                }

                x = mailStatus > 0 ? "Success" : "W";
            }
            else
            {
                x = "W";
            }
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "PaymentReminderEmail", ex.Message);
        }
        return x;
    }
}
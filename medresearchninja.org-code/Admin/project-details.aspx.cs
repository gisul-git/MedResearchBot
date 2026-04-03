using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_project_details : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindMembers();
    }
    public void BindMembers()
    {
        try
        {
            var members = MemberDetails.GetAllMembersList(conMN);
            ddlMembers.Items.Clear();
            if (members.Count > 0)
            {
                ddlMembers.DataSource = members;
                ddlMembers.DataValueField = "UserGuid";
                ddlMembers.DataTextField = "FullName";
                ddlMembers.DataBind();

            }
            ddlMembers.Items.Insert(0, new ListItem("Select Member", "0"));

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindMembers", ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public static Projects BindProjectDetails(string p_guid)
    {
        Projects project = new Projects();
        try
        {
            if (Convert.ToString(p_guid) == "")
            {
                return project;
            }
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var pDetails = Projects.GetProjectDetails(conMN, p_guid);
            return pDetails;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindProjectDetails", ex.Message);
        }
        return project;
    }

    [WebMethod(EnableSession = true)]
    public static List<MemberDetails> BindProjectMembers(string p_guid)
    {
        List<MemberDetails> oI = new List<MemberDetails>();
        try
        {
            if (Convert.ToString(p_guid) == "")
            {
                return oI;
            }

            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var oItems = MemberDetails.GetProjectMembers(conMN, p_guid);
            if (oItems.Rows.Count > 0)
            {
                for (int i = 0; i < oItems.Rows.Count; i++)
                {
                    MemberDetails item = new MemberDetails()
                    {
                        UserGuid = Convert.ToString(oItems.Rows[i]["UserGuid"]),
                        UserID = Convert.ToString(oItems.Rows[i]["UserID"]),
                        FullName = Convert.ToString(oItems.Rows[i]["FullName"]),
                        EmailId = Convert.ToString(oItems.Rows[i]["EmailId"]),
                        Contact = Convert.ToString(oItems.Rows[i]["Contact"]),
                        OrderGuid = Convert.ToString(oItems.Rows[i]["OrderGuid"])
                    };

                    oI.Add(item);
                }
            }
        }
        catch (Exception es)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindProjectMembers", es.Message);
        }
        return oI;
    }

    [WebMethod(EnableSession = true)]
    public static string SendNotification(string p_guid, string m_guid, string amount, string amountUSd, string cmts)
    {
        string x = "";
        try
        {
            if (String.IsNullOrEmpty(p_guid) || String.IsNullOrEmpty(amount))
            {
                return "Validation";
            }
            decimal dueAmount = 0;
            decimal.TryParse(Convert.ToString(amount), out dueAmount);
            decimal dueAmountUSD = 0;
            decimal.TryParse(Convert.ToString(amountUSd), out dueAmountUSD);

            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            ProjectDues dues = new ProjectDues();

            dues.ProjectGuid = p_guid;
            dues.ProjectGuid = p_guid;
            dues.UserGuid = m_guid;
            dues.PaymentGuid = Guid.NewGuid().ToString();
            dues.Amount = dueAmount.ToString();
            dues.AmountUSD = dueAmountUSD.ToString();
            dues.Comments = cmts;
            dues.PaymentMode = "";
            dues.PaymentId = "";
            dues.PaymentStatus = "Pending";
            dues.tr_id = "";
            dues.AddedOn = TimeStamps.UTCTime();
            dues.AddedIP = CommonModel.IPAddress();
            dues.AddedBy = HttpContext.Current.Request.Cookies["med_aid"].Value;
            dues.Status = "Active";

            int exec = Projects.InsertProjectDues(conMN, dues);
            if (exec > 0)
            {
                // Send payment due reminder to the Member
                int mailStatus = 0;

                var p_details = Projects.GetProjectDetails(conMN, p_guid);
                if (p_details != null)
                {
                    var project_id = Convert.ToString(p_details.ProjectId);
                    var project_name = Convert.ToString(p_details.ProjectName);

                    string m_name = "", m_email = "";
                    var m_details = MemberDetails.GetMemberDetailsByGuid(conMN, m_guid);
                    if (m_details != null)
                    {
                        m_name = Convert.ToString(m_details.FullName);
                        m_email = Convert.ToString(m_details.EmailId);
                    }

                    var mailSubject = "Payment Due Notification – Project ID: #" + project_id;
                    var pay_link = ConfigurationManager.AppSettings["domain"] + "my-payment.aspx";

                    string payNow_Button = "<table style='border-collapse:collapse;width:99%;' border='0'><tbody><td style='padding: 15px;' align='center'><a style='padding:10px 15px;background-color:#4caf50 !important;color:#fff;border-radius:5px;white-space:nowrap;text-decoration:none;' href='" + pay_link + "'>Pay Now</a></td></tr></tbody></table>";

                    #region Mail Body

                    string MailBody = @"Dear " + m_name + @", 

                                        <p>We hope this message finds you well.</p>

                                        <p>This is to inform you that a payment is currently due for the project mentioned below. We kindly request that you log in to your Med Research Ninja account to review and complete the payment.</p>

                                        <p><strong>Project ID:</strong> #" + project_id + @"</p>

                                        <p><span style='text-decoration:underline;font-size:14pt;'><strong>Payment Summary:</strong></span></p>

                                        <p><strong>Project Name:</strong> " + project_name + @"<br>
                                        <strong>Project ID:</strong> #" + project_id + @"<br>
                                        <strong>Due Amount:</strong> ₹" + dueAmount.ToString("##,##,##,###") + @" (~$" + dueAmountUSD + @")</p>

                                        <p>Please use the button below to log in and access the <strong>Payments</strong> section, where you can view and process your pending dues.</p>

                                        " + payNow_Button + @"

                                        <p><strong>Login Link:</strong> <a href='" + pay_link + @"' target='_blank'>" + pay_link + @"</a></p>

                                        <p><em>If the payment has already been completed, please ignore this notification.</em></p>

                                        <p>We appreciate your prompt attention. For any assistance, feel free to contact our support team.</p>

                                        <p>Thank you for your continued association with <strong>Med Research Ninja</strong>.</p>

                                        <p>Best regards,<br>
                                        Team Med Research Ninja<br>
                                        Email: connect@medresearchninja.com</p>";

                    #endregion



                    mailStatus = Emails.SendMailtoMember("📢 Project Payment Due Alert", m_email, "", "", mailSubject, MailBody);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendNotification", ex.Message);
        }
        return x;
    }

    [WebMethod(EnableSession = true)]
    public static string RemoveMember(string ord_guid)
    {
        string tms = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            if (!CreateUser.CheckAccess(conMN, "project-details.aspx", "Delete", HttpContext.Current.Request.Cookies["med_aid"].Value))
            {
                tms = "Permission";
                return tms;
            }
            int exec = PReports.DeletePOrder(conMN, ord_guid);
            if (exec > 0)
            {
                tms = "Success";
            }
        }
        catch (Exception ex)
        {
            tms = "Error";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RemoveMember", ex.Message);
        }
        return tms;
    }

    [WebMethod(EnableSession = true)]
    public static List<ProjectDues> BindProjectDues(string p_guid)
    {
        List<ProjectDues> paymentsDues = new List<ProjectDues>();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            if (Convert.ToString(p_guid) == "")
            {
                return paymentsDues;
            }

            var Dues = Projects.GetProjectDues(conMN, p_guid);
            if (Dues.Rows.Count > 0)
            {
                for (int j = 0; j < Dues.Rows.Count; j++)
                {
                    ProjectDues item = new ProjectDues();
                    item.id = Convert.ToString(Dues.Rows[j]["id"]);
                    item.PaymentGuid = Convert.ToString(Dues.Rows[j]["PaymentGuid"]);
                    item.ProjectGuid = Convert.ToString(Dues.Rows[j]["ProjectGuid"]);
                    item.UserGuid = Convert.ToString(Dues.Rows[j]["UserGuid"]);
                    item.UserID = Convert.ToString(Dues.Rows[j]["UserID"]);
                    item.FullName = Convert.ToString(Dues.Rows[j]["FullName"]);
                    item.EmailId = Convert.ToString(Dues.Rows[j]["EmailId"]);
                    item.Amount = Convert.ToString(Dues.Rows[j]["Amount"]);
                    item.AmountUSD = Convert.ToString(Dues.Rows[j]["AmountUSD"]);
                    item.Comments = Convert.ToString(Dues.Rows[j]["Comments"]);
                    item.PaymentMode = Convert.ToString(Dues.Rows[j]["PaymentMode"]);
                    item.PaymentId = Convert.ToString(Dues.Rows[j]["PaymentId"]);
                    item.PaymentStatus = Convert.ToString(Dues.Rows[j]["PaymentStatus"]);
                    item.tr_id = Convert.ToString(Dues.Rows[j]["tr_id"]);
                    item.AddedOn = Convert.ToDateTime(Convert.ToString(Dues.Rows[j]["AddedOn"]));
                    paymentsDues.Add(item);
                }
            }
        }
        catch (Exception es)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindProjectDues", es.Message);
        }
        return paymentsDues;
    }

    [WebMethod(EnableSession = true)]
    public static string DeleteProjectDue(string p_guid, string id)
    {
        string tms = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            if (!CreateUser.CheckAccess(conMN, "project-details.aspx", "Delete", HttpContext.Current.Request.Cookies["med_aid"].Value))
            {
                tms = "Permission";
                return tms;
            }

            ProjectDues payment = new ProjectDues();
            payment.id = id;
            payment.Status = "Deleted";
            payment.AddedIP = CommonModel.IPAddress();
            payment.AddedOn = TimeStamps.UTCTime();
            payment.AddedBy = HttpContext.Current.Request.Cookies["med_aid"].Value;
            int exec = Projects.DeleteProjectDues(conMN, payment);
            if (exec > 0)
            {
                tms = "Success";
            }
        }
        catch (Exception ex)
        {
            tms = "Error";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProjectDue", ex.Message);
        }
        return tms;
    }

    [WebMethod(EnableSession = true)]
    public static string PaymentReminderEmail(string pay_guid)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            decimal dueAmount = 0;
            decimal dueAmountUSD = 0;

            var pay_details = Projects.GetPaymentDetailsBy_PaymentGuid(conMN, pay_guid);
            if (pay_details.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(pay_details.Rows[0]["amount"]), out dueAmount);
                decimal.TryParse(Convert.ToString(pay_details.Rows[0]["AmountUSD"]), out dueAmountUSD);

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
                        <strong>Outstanding Amount:</strong> ₹" + dueAmount.ToString("##,##,##,###") + @" (~$" + dueAmountUSD + @")</p>

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

    [WebMethod(EnableSession = true)]
    public static string AddMembers(string mem_guid, string tranId, string ProjectGuid)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var MD = MemberDetails.GetMemberDetailsByGuid(conMN, mem_guid);
            var Proj = Projects.GetProjectDetailsByPGuid(conMN, ProjectGuid);
            decimal price = Convert.ToDecimal(Proj.PriceINR);
            decimal priceUSD = Convert.ToDecimal(Proj.PriceOther);
            string oid = PUserCheckout.GetOMax(conMN);
            string OGuid = Guid.NewGuid().ToString();
            string payType = "PayU";
            string ipAddress = CommonModel.IPAddress();
            DateTime orderedOn = TimeStamps.UTCTime();
            // Billingelivery 
            PUserBillingAddress bill = new PUserBillingAddress()
            {
                AddedDateTime = orderedOn,
                FirstName = MD.FullName,
                Mobile = MD.Contact,
                OrderGuid = OGuid,
                UserGuid = MD.UserGuid,
                EmailId = MD.EmailId,
                AddedIp = ipAddress,
                Landmark = "",
                CustomerGSTN = "",
                Salutation = "",
                CompanyName = "",
                Address1 = "",
                Address2 = "",
                Block = "",
                City = "",
                State = "",
                Country = "",
                LastName = "",
                AltMobile = "",
                Zip = "",
            };
            PUserCheckout.InsertBillingAddress(conMN, bill);
            PUserDeliveryAddress delA = new PUserDeliveryAddress()
            {
                AddedDateTime = orderedOn,
                FirstName = MD.FullName,
                Email = MD.EmailId,
                Mobile = MD.Contact,
                OrderGuid = OGuid,
                UserGuid = MD.UserGuid,
                AddedIp = ipAddress,
                Apartment = "",
                Block = "",
                Landmark = "",
                Salutation = "",
                Address1 = "",
                Address2 = "",
                Country = MD.Country,
                City = "",
                State = "",
                LastName = "",
                AltMobile = "",
                Zip = "",
            };
            PUserCheckout.InsertDeliveryAddress(conMN, delA);

            price = Convert.ToDecimal(Proj.PriceINR);
            priceUSD = Convert.ToDecimal(Proj.PriceOther);

            string rId = PUserCheckout.GetRMax(conMN);
            // Insert the order
            POrders od = new POrders()
            {
                LastUpdatedOn = orderedOn,
                LastUpdatedIp = ipAddress,
                OrderedIp = ipAddress,
                OrderGuid = OGuid,
                ProjectGuid = ProjectGuid,
                OrderId = "MEDPROJORD" + oid,
                OrderMax = oid,
                OrderOn = orderedOn,
                OrderStatus = "Completed",
                PaymentMode = payType,
                PaymentStatus = "Paid",
                TotalPrice = (price).ToString(".##"),
                PriceUSD = (priceUSD).ToString(".##"),
                UserGuid = MD.UserGuid,
                UserName = MD.FullName,
                EmailId = MD.EmailId,
                Contact = MD.Contact,
                PaymentId = tranId,
                ReceiptNo = "MEDIR" + rId,
                RMax = rId,
                PromoCode = "",
                PromoType = "",
                PromoValue = "",
                CODAmount = "",
                Discount = "",
                ShippingPrice = "",
                SubTotal = "",
                SubTotalWithoutTax = "",
                Tax = "",
                AdvAmount = "",
                BalAmount = "",
                UserType = "",
                ProjectName = Proj.ProjectName
            };

            int ord = PUserCheckout.CreateUserOrder(conMN, od);
            if (ord > 0)
            {
                Emails.NewProjectMail(od.UserName, od.ProjectName, od.EmailId, Proj.ProjectLink);
                Emails.NewProjectMailAdmin(od.UserName, od.EmailId, od.ProjectName);
                return "Success";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddMembers", ex.Message);
            return "Error";
        }
        return "Error";
    }
}
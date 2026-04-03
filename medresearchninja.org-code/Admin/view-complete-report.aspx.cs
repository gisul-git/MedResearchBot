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

public partial class Admin_view_complete_report : System.Web.UI.Page
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

            if (!CreateUser.CheckAccess(conMN, "view-complete-report.aspx", "View", HttpContext.Current.Request.Cookies["med_aid"].Value))
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

            var order = Reports.GetAllOrdersReportWithFilters(conMN, pNo2, pSize2, sFrom, sTo, oStatus, pStatus, oParam);
            if (order.Rows.Count > 0)
            {
                for (int i = 0; i < order.Rows.Count; i++)
                {
                    string PaymentStatus = Convert.ToString(order.Rows[i]["PaymentStatus"]);
                    string orderGuid = Convert.ToString(order.Rows[i]["OrderGuid"]);
                    string payStatus = "", payStatus1 = "";
                    var paidAmount = "0";
                    var PaymentMode = "-";
                    switch (PaymentStatus.ToLowerInvariant())
                    {
                        case "initiated":
                            payStatus = "<span class='badge badge-soft-warning badge-border'>Initiated</span>";
                            payStatus1 = "<a href='javascript:void(0);' id='mute_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='bs-tooltip fs-18 link-success UpdatePayment' data-id='" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Update Payment'><i id='icon_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='mdi mdi-currency-inr text-black'></i></a>";
                            break;

                        case "paid":
                            if (!string.IsNullOrEmpty(Convert.ToString(order.Rows[i]["PaymentMode"])))
                            {
                                if (Convert.ToString(order.Rows[i]["PaymentMode"]).ToLower() == "payu")
                                {
                                    paidAmount = "<strong>₹" + Convert.ToString(order.Rows[i]["TotalPrice"]) + @"</strong>";
                                    PaymentMode = "PayU";
                                }
                                else if (Convert.ToString(order.Rows[i]["PaymentMode"]).ToLower() == "paypal")
                                {
                                    paidAmount = "<strong>$" + Convert.ToString(order.Rows[i]["PriceUSD"]) + @"</strong>";
                                    PaymentMode = "PayPal";
                                }
                                else if (Convert.ToString(order.Rows[i]["PaymentMode"]).ToLower() == "Payment Gateway")
                                {
                                    paidAmount = "<strong>$" + Convert.ToString(order.Rows[i]["PriceUSD"]) + @"</strong>";
                                    PaymentMode = "-";
                                }
                                else
                                {
                                    PaymentMode = "-";
                                    paidAmount = "0";
                                }
                            }
                            payStatus = "<span class='badge badge-soft-success badge-border'>Paid</span>";
                            payStatus1 = "<a href='javascript:void(0);' id='mute_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='bs-tooltip fs-18 link-success' data-id='" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Paid'><i id='icon_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='mdi mdi-currency-inr text-muted'></i></a>";
                            break;
                    }

                    string OrderStatus = Convert.ToString(order.Rows[i]["OrderStatus"]);
                    string ordStatus = "";

                    switch (OrderStatus.ToLowerInvariant())
                    {
                        case "draft":
                            ordStatus = "<span class='badge badge-outline-warning'>Draft</span>";
                            break;
                        case "completed":
                            ordStatus = "<span class='badge badge-outline-success'>Completed</span>";
                            break;
                        case "in-process":
                            ordStatus = "<span class='badge badge-outline-secondary'>In Process</span>";
                            break;
                        case "rejected":
                            ordStatus = "<span class='badge badge-outline-danger'>Rejected</span>";
                            break;
                        case "cancelled":
                            ordStatus = "<span class='badge badge-outline-dark'>Cancelled</span>";
                            break;
                    }


                    decimal totalAmount = 0;
                    decimal.TryParse(Convert.ToString(order.Rows[i]["TotalPrice"]), out totalAmount);

                    int PageIndex = ((pNo2 - 1) * pSize2);

                    strSales += @"<tr>
                                    <td><span>" + (PageIndex + (i + 1)) + @"</span></td>
                                    <td><a class='badge badge-outline-primary' href='javascript:void(0);'>" + Convert.ToString(order.Rows[i]["OrderId"]) + @"</a></td>
                                    <td>" + Convert.ToString(order.Rows[i]["UserName"]) + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["EmailId"]) + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["Contact"]) + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["ProjectName"]) + @"</td> 
                                    <td>" + ordStatus + @"</td> 
                                    <td><strong>₹" + totalAmount + @" (~ $" + Convert.ToString(order.Rows[i]["PriceUSD"]) + @")</strong></td> 
                                    <td>" + PaymentMode + @"</td> 
                                    <td>" + paidAmount + @"</td> 
                                    <td>" + payStatus + @"</td> 
                                    <td>" + (string.IsNullOrEmpty(Convert.ToString(order.Rows[i]["PaymentId"])) ? "-" : Convert.ToString(order.Rows[i]["PaymentId"])) + @"</td>
                                    <td>" + Convert.ToDateTime(Convert.ToString(order.Rows[i]["OrderOn"])).ToString("dd-MMM-yyyy hh:mm tt") + @"</td>
                                    <td class='text-center'><a href='javascript:void(0);' class='bs-tooltip btnreminder link-success' data-guid='" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' data-user='" + Convert.ToString(order.Rows[i]["UserGuid"]) + @"' data-pro='" + Convert.ToString(order.Rows[i]["ProjectGuid"]) + @"' data-toggle='tooltip' data-placement='top' title='Send Reminder Mail' data-original-title='Send Reminder Mail'><i class='mdi mdi-email-alert-outline fs-18'></i><span class='position-absolute topbar-badge fs-8 translate-middle badge rounded-pill bg-info msgcnt'>" + Convert.ToString(order.Rows[i]["msgcnt"]) + @"</span></a> " + payStatus1 + @" <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + Convert.ToString(order.Rows[i]["Id"]) + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'><i class='mdi mdi-trash-can-outline fs-18'></i></a></td>
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
    public static string ReminderMail(string user, string Pid, string Oid)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

        try
        {
            var userdetails = MemberDetails.GetMemberDetailsByGuid(conMN, user);
            var Pro = Projects.GetProjectDetailsByPGuid(conMN, Pid);
            if (userdetails != null && Pro != null)
            {
                var exe = Emails.ReminderMail(userdetails.FullName, userdetails.EmailId, Pro.ProjectName, Pro.StartDate);
                if (exe > 0)
                {
                    PUserCheckout.UpdateMsgCount(conMN, Oid);
                    return "Success";
                }
            }
            else
            {
                return "Expired";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ReminderMail", ex.Message);

        }
        return "Error";
    }
    [WebMethod(EnableSession = true)]
    public static string UpdatePaymentStatus(string OrderGuid, string payId)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var oDetails = Reports.GetOrderDetails(conMN, OrderGuid);
            if (oDetails.Rows.Count > 0)
            {
                var UpdatedOn = TimeStamps.UTCTime();
                var UpdatedIP = CommonModel.IPAddress();

                int exec = Reports.UpdatePaymentStatus(conMN, OrderGuid, payId, UpdatedOn, UpdatedIP);
                if (exec > 0)
                {
                    x = "Success";
                }
                else
                {
                    x = "W";
                }
            }
            else
            {
                x = "W";
            }
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePaymentStatus", ex.Message);
        }
        return x;
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            POrders MR = new POrders();
            MR.Id = Convert.ToInt32(id);
            int exec = PUserCheckout.DeleteOrders(conMN, MR);
            if (exec > 0)
            {
                x = "Success";
            }
            else
            {
                x = "W";
            }

        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Delete", ex.Message);
        }
        return x;
    }
}
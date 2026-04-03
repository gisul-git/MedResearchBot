using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_orders : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrOrders = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllOrder();
    }
    private void GetAllOrder()
    {
        try
        {
            var orders = PUserCheckout.GetAllOrders(conMN);
            if (orders != null && orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    string sts = "";
                    switch (orders[i].PaymentStatus.ToLower().Trim())
                    {
                        case "failed":
                            sts = "<a href='javascript:void(0);' id='sts_"+ orders[i].OrderGuid + "' class='badge bg-danger text-light'>Failed</a>";
                            break;
                        case "paid":
                            sts = "<a href='javascript:void(0);' id='sts_"+ orders[i].OrderGuid + "' class='badge bg-success text-light'>Paid</a>";
                            break;
                        case "initiated":
                            sts = "<a href='javascript:void(0);' id='sts_"+ orders[i].OrderGuid + "' class='badge bg-primary text-light'>Pending</a>";
                            break;
                    }
                    string PayStatus = "";
                    var PaymentStatus = Convert.ToString(orders[i].PaymentStatus);
                     if (PaymentStatus == "Paid")
                    {
                        PayStatus = "<a href='javascript:void(0);' id='mute_" + orders[i].OrderGuid + @"' class='bs-tooltip fs-18 link-success' data-id='" + orders[i].OrderGuid + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Paid'><i id='icon_" + orders[i].OrderGuid+@"' class='mdi mdi-currency-inr text-muted'></i></a>";
                    }
                    else if (PaymentStatus == "Initiated")
                    {
                        PayStatus = "<a href='javascript:void(0);' id='mute_" + orders[i].OrderGuid + @"' class='bs-tooltip fs-18 link-success UpdatePayment' data-id='" + orders[i].OrderGuid + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Update Payment'><i id='icon_" + orders[i].OrderGuid+@"' class='mdi mdi-currency-inr text-black'></i></a>";
                    }

                    StrOrders += @"<tr class=''>" +
                                     "<td>" + (i + 1) + @"</td>" +
                                     "<td><span class='text-primary fw-bold'>" + orders[i].OrderId + @"</span></td>" +
                                     "<td><span class='text-primary fw-bold'>" + orders[i].UserName + @"</span><br><span class='text-info fw-bold'><a href='mailto:" + orders[i].EmailId + @"' class='link'>" + orders[i].EmailId + @"</a></span><br><span class='text-info fw-bold'>" + orders[i].Contact + @"</span></td>" +
                                     "<td>" + orders[i].ProjectName + @"</td>" +
                                     "<td>₹ " + orders[i].TotalPrice + @"</td>" +
                                     "<td>" + sts + @"</td>" +
                                     "<td>" + orders[i].OrderOn.ToString("dd MMM yyyy") + @"</td>" +
                                     "<td><span id='payid_" + orders[i].OrderGuid + @"'></span>" + orders[i].PaymentId + @"</td>" +
                                     "<td class='text-center'><a href='javascript:void(0);' class='bs-tooltip btnreminder link-success' data-guid='" + orders[i].OrderGuid + @"' data-user='" + orders[i].UserGuid + @"' data-pro='" + orders[i].ProjectGuid + @"' data-toggle='tooltip' data-placement='top' title='Send Reminder Mail' data-original-title='Send Reminder Mail'><i class='mdi mdi-email-alert-outline fs-18'></i><span class='position-absolute topbar-badge fs-8 translate-middle badge rounded-pill bg-info msgcnt'>" + orders[i].msgcnt + @"</span></a> " + PayStatus + @" <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + orders[i].Id + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'><i class='mdi mdi-trash-can-outline fs-18'></i></a></td>" +
                                 "</tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllJobApplications", ex.Message);

        }
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
            if (oDetails.Rows.Count>0)
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

}
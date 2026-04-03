using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_members_orders : System.Web.UI.Page
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

            var order = Reports.GetAllMemberOrdersWithFilters(conMN, pNo2, pSize2, sFrom, sTo, oStatus, pStatus, oParam);
            if (order.Rows.Count > 0)
            {
                for (int i = 0; i < order.Rows.Count; i++)
                {
                    string PaymentStatus = Convert.ToString(order.Rows[i]["OrderPaymentStatus"]);
                    string orderGuid = Convert.ToString(order.Rows[i]["OrderGuid"]);
                    string payStatus = "", payStatus1 = "";
                    var totalAmount = "0 (~$0)";

                    switch (PaymentStatus.ToLowerInvariant())
                    {
                        case "not paid":
                            payStatus = "<span class='badge badge-soft-warning badge-border'>Initiated</span>";
                            payStatus1 = "<a href='javascript:void(0);' id='mute_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='bs-tooltip fs-18 link-success UpdatePayment' data-id='" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Update Payment'><i id='icon_" + Convert.ToString(order.Rows[i]["OrderGuid"]) + @"' class='mdi mdi-currency-inr text-black'></i></a>";
                            totalAmount = "0 (~$0)";
                            break;

                        case "paid":
                            totalAmount = Convert.ToString(order.Rows[i]["TotalPrice"]) + " (~$10)";
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



                    int PageIndex = ((pNo2 - 1) * pSize2);

                    strSales += @"<tr>
                                    <td><span>" + (PageIndex + (i + 1)) + @"</span></td>
                                    <td><a class='badge badge-outline-primary' href='javascript:void(0);'>" + Convert.ToString(order.Rows[i]["OrderId"]) + @"</a></td>
                                    <td>" + Convert.ToString(order.Rows[i]["FullName"]) + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["MemberEmail"]) + @"</td>
                                    <td>" + Convert.ToString(order.Rows[i]["MemberContact"]) + @"</td>
                                    <td>" + ordStatus + @"</td> 
                                    <td>" + payStatus + @"</td> 
                                    <td>₹" + totalAmount + @"</td> 
                                    <td>" + (string.IsNullOrEmpty(Convert.ToString(order.Rows[i]["PaymentId"])) ? "-" : Convert.ToString(order.Rows[i]["PaymentId"])) + @"</td>
                                    <td>" + Convert.ToDateTime(Convert.ToString(order.Rows[i]["OrderOn"])).ToString("dd-MMM-yyyy hh:mm tt") + @"</td>
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

}
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

public partial class Admin_dashboard : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string Strusername, strMembersCountry, strOrders, strMembersOtherCountry = "", strNoOfMembers = "", strTotalSales = "", strNoOfProjects, strNoOfContact, StrOrderCnt = "", StrContact = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["med_aid"] == null)
        {
            Response.Redirect("Default.aspx", false);
        }

        BindUserName();
        GetAllMembers();
        NoOfMembers();
        GetOrderReports();
        NoOfProjects();
        StrOrderCnt = DashBoard.GetOrderCount(conMN).ToString();
        strTotalSales = DashBoard.GetTotalSales(conMN).ToString();
        strNoOfContact = DashBoard.NoOfContacts(conMN).ToString();
    }

    private void NoOfMembers()
    {
        decimal cntB = MemberDetails.NoOfMember(conMN);
        strNoOfMembers = cntB.ToString();
    }

    private void NoOfProjects()
    {
        decimal cntP = LatestProject.NoOfLatestProjects(conMN);
        strNoOfProjects = cntP.ToString();
    }
     

    [WebMethod(EnableSession = true)]
    public static MonthlyChart DashBoardChart()
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            slp = PReports.GetMonthlynYearlyValueDefault(conMN);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DashBoardChart", ex.Message);
        }
        return slp;
    }
    [WebMethod(EnableSession = true)]
    public static MonthlyChart FilterDashBoardChart(string fValue)
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            if (fValue == "1Y")
            {
                slp = PReports.GetMonthlynYearlyValue(conMN, "");
            }
            else if (fValue == "6M")
            {
                slp = PReports.GetMonthlynYearlyValue(conMN, "6M");
            }
            else if (fValue == "All")
            {
                slp = PReports.GetYearlyValue(conMN);
            }
            else if (fValue == "1M")
            {
                slp = PReports.GetMonthlyValue(conMN, "1M");
            }
            else if (fValue == "1W")
            {
                slp = PReports.GetMonthlyValue(conMN, "1W");
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DashBoardChart", ex.Message);
        }
        return slp;
    }

    [WebMethod(EnableSession = true)]
    public static MonthlyChart FilterDashBoardChartStatus(string fValue)
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            slp = PReports.GetMonthlynYearlyValueStatus(conMN, fValue);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DashBoardChart", ex.Message);
        }
        return slp;
    }

    [WebMethod(EnableSession = true)]
    public static MonthlyChart MDashBoardChart()
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            slp = Reports.GetMonthlynYearlyValueDefault(conMN);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MDashBoardChart", ex.Message);
        }
        return slp;
    }
    [WebMethod(EnableSession = true)]
    public static MonthlyChart MFilterDashBoardChart(string fValue)
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            if (fValue == "1Y")
            {
                slp = Reports.GetMonthlynYearlyValue(conMN, "");
            }
            else if (fValue == "6M")
            {
                slp = Reports.GetMonthlynYearlyValue(conMN, "6M");
            }
            else if (fValue == "All")
            {
                slp = Reports.GetYearlyValue(conMN);
            }
            else if (fValue == "1M")
            {
                slp = Reports.GetMonthlyValue(conMN, "1M");
            }
            else if (fValue == "1W")
            {
                slp = Reports.GetMonthlyValue(conMN, "1W");
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MFilterDashBoardChart", ex.Message);
        }
        return slp;
    }

    [WebMethod(EnableSession = true)]
    public static MonthlyChart MFilterDashBoardChartStatus(string fValue)
    {
        MonthlyChart slp = new MonthlyChart();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            slp = Reports.GetMonthlynYearlyValueStatus(conMN, fValue);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MFilterDashBoardChartStatus", ex.Message);
        }
        return slp;
    }

    public void BindUserName()
    {
        try
        {
            Strusername = CreateUser.GetLoggedUserName(conMN, Request.Cookies["med_aid"].Value);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindUserName", ex.Message);
        }
    }
    public void GetAllMembers()
    {
        try
        {
            strMembersCountry = "";
            strMembersOtherCountry = "";
            List<MemberDetails> lst = MemberDetails.GetAllMembersCountrisDetails(conMN);
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    if (string.IsNullOrEmpty(item.Country))
                    {
                        strMembersOtherCountry += @"<div class='mt-3'><p class='mb-0'>OTHERS<span class='float-end'>" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"%</span></p>
                                <div class='progress mt-2' style='height: 6px;'>
                                    <div class='progress-bar progress-bar-striped' role='progressbar' style='width: " + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"%;background:#5BBB7B;' aria-valuenow='" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"' aria-valuemin='0' aria-valuemax='" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"'></div>
                                </div></div>";
                    }
                    else
                    {
                        strMembersCountry += @"<div class='mt-3'><p class='mb-0'>" + item.Country.ToUpper() + @"<span class='float-end'>" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"%</span></p>
                                <div class='progress mt-2' style='height: 6px;'>
                                    <div class='progress-bar progress-bar-striped' role='progressbar' style='width: " + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"%;background:#5BBB7B;' aria-valuenow='" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"' aria-valuemin='0' aria-valuemax='" + Math.Ceiling(Convert.ToDecimal(item.Percentage)) + @"'></div>
                                </div></div>";

                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllMembers", ex.Message);
        }
    }
    public void GetOrderReports()
    {
        try
        {
            var orders = PUserCheckout.GetTop10Orders(conMN);
            if (orders != null && orders.Count > 0)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    string sts = "";
                    switch (orders[i].PaymentStatus.ToLower().Trim())
                    {
                        case "failed":
                            sts = "<a href='javascript:void(0);' id='sts_" + orders[i].OrderGuid + "' class='badge bg-danger text-light'>Failed</a>";
                            break;
                        case "paid":
                            sts = "<a href='javascript:void(0);' id='sts_" + orders[i].OrderGuid + "' class='badge bg-success text-light'>Paid</a>";
                            break;
                        case "initiated":
                            sts = "<a href='javascript:void(0);' id='sts_" + orders[i].OrderGuid + "' class='badge bg-primary text-light'>Pending</a>";
                            break;
                    }
                    string PayStatus = "";
                    var PaymentStatus = Convert.ToString(orders[i].PaymentStatus);
                    if (PaymentStatus == "Paid")
                    {
                        PayStatus = "<a href='javascript:void(0);' id='mute_" + orders[i].OrderGuid + @"' class='bs-tooltip fs-18 link-success' data-id='" + orders[i].OrderGuid + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Paid'><i id='icon_" + orders[i].OrderGuid + @"' class='mdi mdi-currency-inr text-muted'></i></a>";
                    }
                    else if (PaymentStatus == "Initiated")
                    {
                        PayStatus = "<a href='javascript:void(0);' id='mute_" + orders[i].OrderGuid + @"' class='bs-tooltip fs-18 link-success UpdatePayment' data-id='" + orders[i].OrderGuid + @"'  data-bs-toggle='tooltip' data-placement='top'  title='Update Payment'><i id='icon_" + orders[i].OrderGuid + @"' class='mdi mdi-currency-inr text-black'></i></a>";
                    }
                    strOrders += @"<tr class=''>" +
                                 "<td>" + (i + 1) + @"</td>" +
                                 "<td><span class='text-primary fw-bold'>" + orders[i].OrderId + @"</span></td>" +
                                 "<td><span class='text-primary fw-bold'>" + orders[i].UserName + @"</span><br><span class='text-info fw-bold'><a href='mailto:" + orders[i].EmailId + "' class='link'>" + orders[i].EmailId + @"</a></span><br><span class='text-info fw-bold'>" + orders[i].Contact + @"</span></td>" +
                                 "<td>" + orders[i].ProjectName + @"</td>" +
                                "<td>₹ " + orders[i].TotalPrice + @"</td>" +
                                 "<td>" + sts + @"</td>" +
                                    "<td>" + orders[i].OrderOn.ToString("dd MMM yyyy") + @"</td></tr>";
                }
        }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderReports", ex.Message);
        }

    }
}
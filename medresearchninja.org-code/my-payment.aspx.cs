using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class my_payment : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strPayment = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        int count = 0;
        if (Request.Cookies["med_uid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            CheckUserExist();
            count = Projects.GetPendingProjectDuesCount(conMN, Request.Cookies["med_uid"].Value);
            strDues = count > 0 ? "<span class='badge-circle'>" + count + "</span>" : "";

            BindProjectDues();
        }
        //GetPaymentStatus();
    }
    public void CheckUserExist()
    {
        try
        {
            if (Request.Cookies["med_uid"] == null)
            {

                StrLink = "/signup.aspx";
                StrText = "Sign Up";
                StrLoginBtn = "<a href='/signup.aspx' class='ud-btn1 btn-thm w-50'>Sign Up</a>";

            }
            else
            {
                var user = MemberDetails.GetMemberDetailsByGuid(conMN, Request.Cookies["med_uid"].Value);
                if (user != null)
                {
                    StrUserImage = user.ProfileImage == "" ? "<img src='/images/user.png' alt='user.png' width='30' />" : "<img src='/" + user.ProfileImage + @"' alt='user.png' width='30' />";
                    StrUserName = user.FullName;
                }
                StrLink = "/member-profile.aspx";
                StrText = "My Profile";
                StrLoginBtn = "<a href='/member-profile.aspx' class='ud-btn1 btn-thm w-50'>My Profile</a>";
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void BindProjectDues()
    {
        try
        {
            var userGuid = Request.Cookies["med_uid"].Value;
            var dues = Projects.GetUserProjectDues(conMN, userGuid);
            if (dues.Rows.Count > 0)
            {
                for (int i = 0; i < dues.Rows.Count; i++)
                {
                    decimal dueAmount = 0;
                    decimal.TryParse(Convert.ToString(dues.Rows[i]["Amount"]), out dueAmount);
                    decimal dueAmountUsd = 0;
                    decimal.TryParse(Convert.ToString(dues.Rows[i]["AmountUSD"]), out dueAmountUsd);

                    string pStatus = "", btnPayNow = "";
                    if (Convert.ToString(dues.Rows[i]["PaymentStatus"]).ToLower() == "paid")
                    {
                        pStatus = "<span class='bg-success'>Paid</span>";
                        btnPayNow = "<a href='javascript:void(0);' class='ud-btn btn-thm btn-sm disabled' aria-disabled='true'>Paid</a>";
                    }
                    else
                    {
                        pStatus = "<span class='bg-danger'>Pending</span>";
                        btnPayNow = "<a href='/pay-project-due.aspx?pid=" + Convert.ToString(dues.Rows[i]["PaymentGuid"]) + @"' class='ud-btn btn-thm btn-sm'>Pay Now</a>";
                    }

                    strPayment += "<tr>" +
                                       "<td>" + (i + 1) + "</td>" +
                                       "<td><span class='badge badge-outline-primary'>" + Convert.ToString(dues.Rows[i]["ProjectId"]) + "</span></td>" +
                                       "<td class='pName'>" + Convert.ToString(dues.Rows[i]["ProjectName"]) + "</td>" +
                                       "<td>₹" + dueAmount.ToString("##,##,##,###") + " or $" + dueAmountUsd.ToString("N0") + @"</td>" +
                                       "<td>" + pStatus + "</td>" +
                                       "<td>" + (!string.IsNullOrEmpty(Convert.ToString(dues.Rows[i]["PaymentDate"])) ? Convert.ToDateTime(dues.Rows[i]["PaymentDate"]).ToString("dd-MMM-yyyy hh:mm tt") : "--") + "</td>" +
                                       "<td>" + btnPayNow + @"</td>" +
                                   "</tr>";
                }
            }
            else
            {
                strPayment += "<tr><td colspan='7' align='center'><span style='color:#999; font-weight:500;'>No Payment Dues Found</span></td></tr>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "BindProjectDues", ex.Message);
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Cookies["med_uid"].Expires = TimeStamps.UTCTime().AddDays(-10);
            Response.Redirect("login.aspx");
        }
    }
    public void GetPaymentStatus()
    {
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["med_uid"];
            string userGuid = cookie != null ? cookie.Value : null;
            List<POrders> res = PUserCheckout.BindPaymentStatus(conMN, userGuid);

            for (int i = 0; i < res.Count; i++)
            {
                strPayment += "<tr>" +
                            "<th scope='row'><div class='details'><h5 class='title mb-2'>" + res[i].ProjectID + "</h5></div></th>" +
                            "<th scope='row'><div class='details'><h5 class='title mb-2'>" + res[i].ProjectName + "</h5></div></th>" +
                            "<td class='vam'><span class='pending-style style6'>" + res[i].PaymentStatus + "</span></td>" +
                            "<td class='fw-bold'>" + res[i].PStartDate + "</td>" +
                            "<th scope='row'><div class='details'><h5 class='title mb-2'>" + res[i].LastUpdatedOn.ToString("dd/MMM/yyyy") + "</h5></div></th>" +
                        "</tr>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPaymentStatus", ex.Message);
        }
    }
}
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
public partial class my_projects : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strPayment = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.Cookies["med_uid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        CheckUserExist();
        GetPaymentStatus();
        int count = Projects.GetPendingProjectDuesCount(conMN, Request.Cookies["med_uid"].Value);
        strDues = count > 0 ? "<span class='badge-circle'>" + count + "</span>" : "";

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
            if (res!=null && res.Count > 0) {
                for (int i = 0; i < res.Count; i++)
                {
                    strPayment += @"<tr>
                                    <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].ProjectID + @"</h5>
                                    </div>
                                    </th>
                                    <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].ProjectName + @"</h5>
                                    </div>
                                    </th>
                                     <td class='vam'><span class='pending-style style6'> " + res[i].PaymentStatus + @"</span></td>
                                     <td class='fw-bold'>" + res[i].PStartDate + @"</td>
                                     <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].LastUpdatedOn.ToString("dd/MMM/yyyy") + @"</h5>
                                    </div>
                                    </th>
                    </tr> ";
                }
            }
            else
            {
                strPayment = "<tr><td class='text-center' colspan='6'>No Data to display .</td></tr>";
            }
            
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPaymentStatus", ex.Message);
        }
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

}
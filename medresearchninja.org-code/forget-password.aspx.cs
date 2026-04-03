using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forget_password : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected  void ResetPasswordButton_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                string logins = MemberDetails.MemberResetPassword(conMN, txtemail.Text.Trim());
                if (logins != "")
                {
                    string r_id = Guid.NewGuid().ToString();
                    int reset = MemberDetails.SetRestId(conMN, logins, r_id);
                    var username = MemberDetails.GetLoggedMemberName(conMN, Convert.ToString(logins));
                    Emails.SendPasswordRestLink(username, txtemail.Text.Trim(), ConfigurationManager.AppSettings["domain"] + "/reset-password.aspx?r=" + r_id);
                    if (reset >= 1)
                    {
                        lblStatus.Text = "<strong>Success !</strong><br/>Password reset link has been sent to your email address.Please check SPAM folder if you haven’t received it.";
                        lblStatus.Attributes.Add("class", "alert alert-success d-block");
                    }
                    else
                    {
                        lblStatus.Text = "<strong>Error !</strong><br/>There is some problem now. Please try after some time";
                        lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                    }
                }
                else
                {
                    lblStatus.Text = "<strong>Error !</strong><br/>Entered email is not registered";
                    lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                }
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "<strong>Error !</strong><br/>There is some problem now. Please try after some time";
            lblStatus.Attributes.Add("class", "alert alert-danger d-block");
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnLogin_Click", ex.Message);
        }
    }

}
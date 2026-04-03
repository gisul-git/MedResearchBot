using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserExist();
    }
    public void CheckUserExist()
    {
        try
        {
            if (Request.Cookies["med_uid"] == null)
            {
                StrLink = "/login.aspx";
                StrText = "Sign In";
                StrLoginBtn = "<a href='/signup.aspx' class='ud-btn1 btn-thm w-50'>Sign In</a>";
                divlogin.Visible = true;
                divprofile.Visible = false;
            }
            else
            {
                StrLink = "/member-profile.aspx";
                StrText = "My Profile";
                StrLoginBtn = "<a href='/member-profile.aspx' class='ud-btn1 btn-thm w-50'>My Profile</a>";
                divlogin.Visible = false;
                divprofile.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
}

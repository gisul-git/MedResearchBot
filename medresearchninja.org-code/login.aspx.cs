using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Redirect("member-profile.aspx", false);
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                var inputs = new MemberDetails
                {
                    UserID = txtEmail.Text.Trim(),
                    Password = CommonModel.Encrypt(txtPassword.Text.Trim())
                };
                MemberDetails logins = MemberDetails.MemberDetails1(conMN, inputs);
                if (logins.UserGuid != null)
                {
                    if (logins.PaymentStatus == "Not Paid")
                    {
                        string UGuid = logins.UserGuid.ToString();
                        var Oguid = UserCheckout.GetOguidWithUguid(conMN, UGuid);
                        Response.Redirect("procced-to-pay.aspx?Oguid=" + Oguid);
                    }
                    else if (logins.PaymentStatus == "Paid")
                    {
                        if (logins.Status == "Active")
                        {
                            lblStatus.Text = "<strong>Success !</strong> Login success";
                            lblStatus.Attributes.Add("class", "alert alert-success d-block");

                            HttpCookie cookie = new HttpCookie("med_uid");
                            cookie.Value = logins.UserGuid;

                            //this cookie is to validate password key
                            HttpCookie cookie_pass_key = new HttpCookie("med_upkv");
                            cookie_pass_key.Value = logins.PassKey;
                            if (chkLogKeep.Checked == true)
                            {
                                cookie.Expires = DateTime.UtcNow.AddDays(30);
                                cookie_pass_key.Expires = DateTime.UtcNow.AddDays(30);
                            }
                            else
                            {
                                cookie.Expires = DateTime.UtcNow.AddDays(10);
                                cookie_pass_key.Expires = DateTime.UtcNow.AddDays(10);
                            }
                            MemberDetails.UpdateLastLoginTime(conMN, logins.UserGuid);
                            Response.Cookies.Add(cookie);
                            Response.Cookies.Add(cookie_pass_key);
                            Response.Redirect("member-profile.aspx", false);
                        }

                        else
                        {
                            lblStatus.Text = "<strong>Error !</strong><br/>Temporarily blocked by admin!";
                            lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                        }
                        
                    }
                    else
                    {
                        lblStatus.Text = "<strong>Error !</strong><br/>Contact Admin";
                        lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                    }
                }
                else
                {
                    lblStatus.Text = "<strong>Error !</strong><br/>User-Id or Password incorrect";
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
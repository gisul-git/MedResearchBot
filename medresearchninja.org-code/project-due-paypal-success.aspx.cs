using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class project_due_paypal_success : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["p"] != null)
        {
            strStatus = "<img style='height:300px;' class='mb-3' src='/assets/images/rb_20631.png' />" +
                 "<h3 class='main-heading text-success text-dark'>" +
                 "<strong>Project Due Payment Successful! </strong></h3><h5 class='mt-2'>Your payment has been successfully processed. Please check your email for the payment confirmation.</h5>";
        }
        else
        {
            Response.Redirect("/");
        }
    }
}
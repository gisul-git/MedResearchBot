using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paypal_success : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["O"] != null)
        {
            var orderid = Request.QueryString["O"];
            List<Orders> order = Reports.GetSingleOrderDetails(conMN, orderid);
            if (order.Count>0)
            {
                if (order[0].PaymentStatus == "Paid")
                {
                    strStatus = "<img style='height:300px;' class='mb-3' src='/assets/images/rb_20631.png' />" +
                                 "<h3 class='main-heading text-success text-dark'>" +
                                 "<strong>Thank you for your membership! </strong></h3><h5 class='mt-2'>Please check your email for further instructions, including a link to join our exclusive WhatsApp group." +
                                 "Stay connected, collaborate with fellow researchers, and stay tuned for exclusive updates, resources, and opportunities!</h5>";
                }
                else
                {
                    strStatus = "<img style='height:200px;' src='/images/x.gif' /><h3 class='main-heading text-danger'>Not Found!<br>Your order can not be found. please contact adminstration for furthur details.</h3>";
                }
            }
            else
            {
                strStatus = "<img style='height:200px;' src='/images/x.gif' /><h3 class='main-heading text-danger'>Not Found!<br>Your order can not be found. please contact adminstration for furthur details.</h3>";
            }
        }
        else
        {
            Response.Redirect("/");
        }
    }

}
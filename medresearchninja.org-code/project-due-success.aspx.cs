using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class project_due_success : System.Web.UI.Page
{
    public string strStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["p"]))
        {
            strStatus = "<img style='height:100px;' class='mb-3' src='/Img/success.gif' />" +
                        "<h3 class='main-heading text-success'><strong>Payment Successful!</strong></h3>" +
                        "<h5 class='mt-2'>Thank you for your payment. Your transaction has been successfully processed.</h5>" +
                        "<h5 class='mt-2'>Project ID: <span class='text-dark'><strong>" + Request.QueryString["p"] + "</strong></span></h5>" +
                        "<p class='mt-3'>A confirmation email has been sent to your registered email address.</p>";
        }
    }
}
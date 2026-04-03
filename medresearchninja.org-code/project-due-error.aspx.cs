using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class project_due_error : System.Web.UI.Page
{
    public string strStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["p"]))
        {
            strStatus = "<img style='height:100px;' class='mb-3' src='/Img/PayError.gif' />" +
            "<h3 class='main-heading text-danger'><strong>Payment Failed</strong></h3>" +
            "<h5 class='mt-2'>Unfortunately, your transaction could not be completed.</h5>" +
            "<h5 class='mt-2'>Project ID: <span class='text-dark'><strong>" + Request.QueryString["p"] + "</strong></span></h5>" +
            "<p class='mt-3'>Please try again or contact support if the issue persists.</p>";
        }
    }
}
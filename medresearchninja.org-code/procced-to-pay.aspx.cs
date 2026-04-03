using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class procced_to_pay : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Redirect("member-profile.aspx", false);
        }

    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            string url = HttpContext.Current.Request.Url.ToString();
            Uri uri = new Uri(url);
            string Oguid = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("Oguid");
            Response.Redirect("pay-now.aspx?order=" + Oguid);
         }

        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnProceed_Click", ex.Message);
        }

    }
}
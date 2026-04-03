using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class about_us : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strmembers = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllOthermembers();
    }
    private void BindAllOthermembers()
    {

        try
        {
            strmembers = "";
            var mem = Othermemberdetails.GetOthermembers(conMN).ToList();
            if (mem.Count > 0)
            {
                for (int i = 0; i < mem.Count; i++)
                {


                    strmembers += @"<div class='col-lg-2 col-md-6 col-6'>
                 <div class='item'>
                     <div class='freelancer-style1 text-center bdr1 bdrs16 hover-box-shadow'>
                         <div class='thumb new-thumb-img mb30'>
                             <img class=' mx-auto' src='" + mem[i].ThumbImage +@"' alt=''>
                         </div>
                         <div class='details d-flex justify-content-between align-items-center '>
                             <h4 class='title  fw-bold mb-1 new-font'>" + mem[i].Name +@"
                             </h4>
                             <a href='" + mem[i].LinkedinUrl +@";utm_campaign=share_via&amp;utm_content=profile&amp;utm_medium=ios_app'><i class='fa-brands fa-linkedin'></i></a>


                         </div>
                     </div>
                 </div>
             </div>";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllOthermembers", ex.Message);
        }
    }
}
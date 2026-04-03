using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using NLog.Targets;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Management;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class whitepaper_details : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrWhitepapers = "", strPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        BindWhitePapers();


    }
    public void BindWhitePapers()
    {
        try
        {
            List<Whitepaper> res = Whitepaper.BindWhitepaper(conMN);

            for (int i = 0; i < res.Count; i++)
            {
                var pdf = res[i].PDFFile;

                StrWhitepapers += @"<div class='col-lg-3 col-md-6'>
                                    <div class='listing-style1 default-box-shadow1 bdrs8'>
                                      <div class='list-thumb'>
                                        <img class='w-100' src='/" + res[i].ThumbImage + @"' alt=''>
                                      </div>
                                    <div class='list-content'>
                                   <p class='list-text body-color fz14 mb-1'></p>
                                   <h5 class='list-title fw-bold'><a href='javascript:void(0);' contenteditable='false' style='cursor: pointer;'>" + res[i].Title + @"</a></h5>
                                    <hr class='my-2'>
                                    <a href='/"+ pdf + @"' target='_blank' class='ud-btn1 btn-white2 double-border bdrs4'>Download<i class='fa-solid fa-cloud-arrow-down'></i></a>
                                      </div>
                                          </div>
                                     </div>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindWhitePapers", ex.Message);
        }
    }

}
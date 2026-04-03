using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class latest_work : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strProjects = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllProjects();
    }

    private void BindAllProjects()
    {
        try
        {
            strProjects = "";
            var Projects = LatestProject.GetAllLatestProject(conSQ).ToList();
            if (Projects.Count > 0)
            {
                for (int i = 0; i < Projects.Count; i++)
                {
                    

                    strProjects += @"<div class='col-sm-6 col-xl-3'>
                            <div class='listing-style1 bdrs16'>

                                <div class='list-thumb'> 
                                    <img class='w-100' src='/"+ Projects[i].ThumbImage+@"' alt=''>
                                </div>
                                <div class='list-content'>
                                    <p class='list-text date  body-color fz14 mb20 mb10-sm'>"+ Projects[i].Category+@" </p>
                                    <h5 class='list-title'>"+ Projects[i].ProjectTitle+ @" </h5>

                                    <hr class='my-2'>
                                    <div class='list-meta d-flex justify-content-between align-items-center mt15'>

                                        <div class='budget'>
    
                                          <p class='mb-0 body-color'>
                                                <a href='" + Projects[i].PDFLink + @"' target='_blank' class='ud-btn2 mt-2 ud-btn btn-thm bdrs4'>View<i class='mdi mdi-eye'></i></a>
                                            </p>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllProjects", ex.Message);
        }
    }

    [WebMethod]
    public static List<LatestProject> allProjects(string pno)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        List<LatestProject> Projects = null;
        try
        {
            Projects = LatestProject.GetAllListProjects(conSQ, Convert.ToInt32(pno));
        }
        catch (Exception ex)
        {

            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "allProjects", ex.Message);

        }
        return Projects;    
    }
   
}
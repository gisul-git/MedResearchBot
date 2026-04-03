using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class career_detail : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strJobs = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(RouteData.Values["jurl"]) != "")
        {
           
            BindJobOpenings();

        }
    }
    private void BindJobOpenings()
    {

        try
        {
            strJobs = "";
            var Jobs = JobDetails.GetAllJobDetails(conMN).Where(x => x.JobType.ToLower() == RouteData.Values["jurl"].ToString()).ToList();

      
            if (Jobs.Count > 0)
            {
                for (int i = 0; i < Jobs.Count; i++)
                {
                    var url = "/career-detail/" + Jobs[i].JobUrl;

                    strJobs += @"
                                <div class='col-sm-6 col-md-8 col-xl-8'>
                    <div class='job-list-style1 bdr1'>
                        <div class='d-md-flex new-md-flex justify-content-between align-items-start'>
                            <div class='details ml0-xl'>
                                <h5>" + Jobs[i].JobTitle + @"</h5>
<div class='new-car'>
                                <p class='list-inline-item mb-0'><i class='fa-solid fa-briefcase me-2'></i>" + Jobs[i].ExperienceYears + @" Years</p>
                                <p class='list-inline-item mb-0'><i class='fa-solid fa-indian-rupee-sign  me-2'></i>" + Jobs[i].Salary + @" LPA</p>
                                <p class='list-inline-item mb-0'><i class='fa-solid fa-location-dot  me-2'></i>" + Jobs[i].JobLocation + @"</p>
</div>
                            </div>
                            <div class=''>
                                <a href='" + url + @"' class='ud-btn btn-dark  mt15'>Apply Now<i class='fal fa-arrow-right-long'></i></a>
                            </div>
                        </div>
                        
                    </div>
                </div> ";
                }
            }
            else
            {
                strJobs += "<div class='text-center'>No data to show.</div>";
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllJobs", ex.Message);
        }
    }
}
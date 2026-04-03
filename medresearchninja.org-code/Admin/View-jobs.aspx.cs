using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_View_jobs : System.Web.UI.Page
{
    
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllJobs();
    }
    public string strJobs = "";
    public void BindAllJobs()
    {

        try
        {
            List<JobDetails> JD = JobDetails.GetAllJobDetails(conMN);

            for (int i = 0; i < JD.Count; i++)
            {
                strJobs += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + JD[i].JobType + @"</td>
                                        <td>" + JD[i].JobTitle + @"</td>
                                        <td>" + JD[i].JobLocation + @"</td>
                                        <td>" + JD[i].AddedOn.ToString("dd-MMM-yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href='add-new-job.aspx?id=" + JD[i].Id + @"' class='bs-tooltip  fs-18 link-success' data-id='" + JD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit Jobs'><i class='mdi mdi-pencil'></i></a> 
                                            <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + JD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete Jobs'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllJobs", ex.Message);
        }
    }



    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            JobDetails JD = new JobDetails();
            JD.Id = Convert.ToInt32(id);
            JD.AddedOn = TimeStamps.UTCTime();
            JD.AddedIP = CommonModel.IPAddress();
            int exec = JobDetails.DeleteJobDetails(conMN, JD);
            if (exec > 0)
            {
                x = "Success";
            }
            else
            {
                x = "W";
            }
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Delete", ex.Message);
        }
        return x;
    }
}

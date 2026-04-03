using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_job_applications : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrJobApplications = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllJobApplications();
    }
    private void GetAllJobApplications()
    {

        try
        {
            var jobApp = Applyjobs.GetAllJobApplications(conMN);
            if (jobApp != null && jobApp.Count > 0)
            {
                for (int i = 0; i < jobApp.Count; i++)
                {
                    StrJobApplications += @"<tr class=''>" +
                                        "<td>" + (i + 1) + @"</td>" +
                                        "<td>" + jobApp[i].FullName + @"</td>" +
                                        "<td><a href='/" + jobApp[i].ResumePath + @"' target ='_blank'/><img src='assets/images/pdf.png' style='height:40px;'/></td>" +
                                        "<td><a href='mailto:" + jobApp[i].EmailId + "' class='link'>" + jobApp[i].EmailId + @"</a></td>" +
                                        "<td>" + jobApp[i].ContactNumber + @"</td>" +
                                        "<td>" + jobApp[i].Experience + (jobApp[i].Experience == "1" ? " Year" : " Years") + @"</td>" +
                                        "<td>" + jobApp[i].Location + @"</td>" +
                                        "<td>" + jobApp[i].CurrentSalary + @"</td>" +
                                        "<td>" + jobApp[i].ExpectedSalary + @"</td>" +
                                        "<td>" + jobApp[i].JobType + @"</td>" +
                                        "<td>" + jobApp[i].NoticePeriod + @"</td>
                                        <td class='text-center'> 
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + jobApp[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                                <i class='mdi mdi-trash-can-outline fs-18'></i>
                                            </a> 
                                       </td>
                                   </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllJobApplications", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Applyjobs MR = new Applyjobs();
            MR.Id = Convert.ToInt32(id);
            MR.AddedOn = TimeStamps.UTCTime();
            MR.AddedIP = CommonModel.IPAddress();
            int exec = Applyjobs.DeleteJobApp(conMN, MR);
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_research_idea : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrResearchReports = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllResearchReports();
    }
    private void GetAllResearchReports()
    {

        try
        {
            var rr = ResearchReports.GetAllResearchReports(conMN);
            if (rr != null && rr.Count > 0)
            {
                for (int i = 0; i < rr.Count; i++)
                {
                    StrResearchReports += @"<tr class=''>" +
                                        "<td>" + (i + 1) + @"</td>" +
                                        "<td>" + rr[i].ResearchTopic + @"</td>" +
                                        "<td>" + rr[i].Reference + @"</td>" +
                                        "<td>" + rr[i].SubmittedByName + @"</td>" +
                                        "<td>" + rr[i].SubmittedByContact + @"</td>" +
                                        "<td>" + rr[i].SubmittedByAffiliation + @"</td>"+
                                        "<td><a href = 'javascript:void(0);' data-bs-toggle ='modal' data-bs-target ='#WhitePaperModal' class='badge badge-outline-info  btnViewInfo' data-id='" + rr[i].ID + "'>Click to view details</a></td>"+
                                        "<td class='text-center'><a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + rr[i].ID + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'>
                                                <i class='mdi mdi-trash-can-outline fs-18'></i>
                                            </a> 
                                       </td>
                                   </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllResearchReports", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ResearchReports MR = new ResearchReports();
            MR.ID = Convert.ToInt32(id);
            MR.AddedOn = TimeStamps.UTCTime();
            MR.AddedIp = CommonModel.IPAddress();
            int exec = ResearchReports.DeleteResearchReport(conMN, MR);
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
    [WebMethod(EnableSession = true)]
    public static string GetDetails(string id)
    {
        var details = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            details = ResearchReports.GetDetailsById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_case_reports : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrCaseReports = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllCaseReports();
    }
    private void GetAllCaseReports()
    {

        try
        {
            var cs = CaseReports.GetAllCaseReports(conMN);
            if (cs != null && cs.Count > 0)
            {
                for (int i = 0; i < cs.Count; i++)
                {
                    StrCaseReports += @"<tr class=''>" +
                                        "<td>" + (i + 1) + @"</td>" +
                                        "<td>" + cs[i].TitleOfCase + @"</td>" +
                                        "<td><a href='/" + cs[i].Evidence + @"' target ='_blank'/><img src='assets/images/pdf.png' style='height:40px;'/></td>" +
                                        "<td>" + cs[i].SubmittedByName + @"</td>" +
                                        "<td>" + cs[i].SubmittedByContact + @"</td>" +
                                        "<td>" + cs[i].SubmittedByAffiliation + @"</td>"+
                                        "<td><a href = 'javascript:void(0);' data-bs-toggle ='modal' data-bs-target ='#WhitePaperModal' class='badge badge-outline-info btnViewInfo' data-id='" + cs[i].ID + "'>Click to view details</a></td>"+
                                       "<td class='text-center'><a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + cs[i].ID + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'><i class='mdi mdi-trash-can-outline fs-18'></i></a></td>
                                   </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCaseReports", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            CaseReports MR = new CaseReports();
            MR.ID = Convert.ToInt32(id);
            MR.AddedOn = TimeStamps.UTCTime();
            MR.AddedIp = CommonModel.IPAddress();
            int exec = CaseReports.DeleteCaseReport(conMN, MR);
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
            details = CaseReports.GetDetailsById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }
}
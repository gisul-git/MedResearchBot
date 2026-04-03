using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_whitepaper_enquiries : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrWhitepapers = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllWhitepapers();

    }
    private void GetAllWhitepapers()
    {

        try
        {
            var art = Articles.GetAllWhitepapers(conMN);
            if (art != null && art.Count > 0)
            {
                for (int i = 0; i < art.Count; i++)
                {
                    StrWhitepapers += @"<tr class=''>" +
                                        "<td class='dtr-control sorting_1' tabindex='0'>" + (i + 1) + @"</td>" +
                                        "<td>" + art[i].AuthorFullName + @"</td>" +
                                        "<td><a href='mailto:" + art[i].AuthorEmailId + "' class='link'>" + art[i].AuthorEmailId + @"</a></td>" +
                                        "<td>" + art[i].AuthorPhoneNo + @"</td>" +
                                        "<td><a href = 'javascript:void(0);' data-bs-toggle ='modal' data-bs-target ='#WhitePaperModal1' class='badge badge-outline-primary btnCoAuthInfo' data-id='" + art[i].AuthorGuid + "'>Click to view details</a></td>" +
                                        "<td><a href='/" + art[i].AttachManuscript + @"' target ='_blank'/><img src='assets/images/pdf.png' style='height:40px;'/></td>" +
                                        "<td><a href='/" + art[i].AttachSupplementoryManuscript + @"' target ='_blank'/><img src='assets/images/pdf.png' style='height:40px;'/></td>" +
                                        "<td>" + Convert.ToDateTime(art[i].Date).ToString("dd-MMM-yyyy") + @"</td>" +
                                        "<td>" + art[i].Signature + @"</td>" +
                                        "<td><a href = 'javascript:void(0);' data-bs-toggle ='modal' data-bs-target ='#WhitePaperModal' class='badge badge-outline-primary btnViewInfo' data-id='" + art[i].Id + "'>Click to view details</a></td>" +
                                        "<td class='text-center'> <a href = 'javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + art[i].Id + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'><i class='mdi mdi-trash-can-outline fs-18'></i></a> </td>" +
                                    "</tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllWhitepapers  ", ex.Message);

        }
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Articles MR = new Articles();
            MR.Id = Convert.ToInt32(id);
            MR.AddedOn = TimeStamps.UTCTime();
            MR.AddedIp = CommonModel.IPAddress();
            int exec = Articles.DeleteArticle(conMN, MR);
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
            details = Articles.GetDetailsById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }

    [WebMethod(EnableSession = true)]
    public static string GetCoAuthDetails(string id)
    {
        var details = "";
        try
        {
            using (SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString))
            {
                details = Articles.GetDetailsByGuid(conMN, id);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCoAuthDetails", ex.Message);
        }
        return details;
    }



}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_mlagiarism_meport_mequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllPlagiarismRequests();
        }
    }

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrPlagiarismRequests = "";

    private void GetAllPlagiarismRequests()
    {
        try
        {
            var requests = PlagiarismRequest.GetAllPlagiarismRequest(conMN);
            if (requests != null && requests.Count > 0)
            {
                for (int i = 0; i < requests.Count; i++)
                {
                    StrPlagiarismRequests += @"<tr class=''>" +
                                        "<td class='dtr-control sorting_1' tabindex='0'>" + (i + 1) + @"</td>" +
                                        "<td>" + requests[i].Name + @"</td>" +
                                        "<td><a href='mailto:" + requests[i].EmailID + "' class='link'>" + requests[i].EmailID + @"</a></td>" +
                                        "<td>" + requests[i].ContactNumber + @"</td>" +
                                        "<td>" + requests[i].FirstAuthorName + @"</td>" +
                                        "<td>" + requests[i].Title + @"</td>" +
                                        "<td>" + requests[i].AddedOn.ToString("dd-MMM-yyyy") + @"</td>" +
                                        
                                        "<td class='text-center'>" +
                                        "<a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + requests[i].Id + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'>" +
                                        "<i class='mdi mdi-trash-can-outline fs-18'></i></a>" +
                                        "</td>" +
                                        "</tr>";
                }
            }
            else
            {
                StrPlagiarismRequests = "<tr><td colspan='11' class='text-center'>No plagiarism requests found</td></tr>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllPlagiarismRequests", ex.Message);
            StrPlagiarismRequests = "<tr><td colspan='11' class='text-center text-danger'>Error loading data</td></tr>";
        }
    } 

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string result = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            PlagiarismRequest request = new PlagiarismRequest();
            request.Id = Convert.ToInt32(id);

            int exec = PlagiarismRequest.DeletePlagiarismRequest(conMN, request);
            if (exec > 0)
            {
                result = "Success";
            }
            else
            {
                result = "Error";
            }
        }
        catch (Exception ex)
        {
            result = "Error";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeletePlagiarismRequest", ex.Message);
        }
        return result;
    }

}



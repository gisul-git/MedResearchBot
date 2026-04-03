using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_projects : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllProjects();
    }
    public string strProjects = "";
    public void BindAllProjects()
    {
        try
        {
            List<Projects> P = Projects.GetAllProjectsDetails(conMN);
            if (P.Count > 0)
            {
                for (int i = 0; i < P.Count; i++)
                {
                    string ft1 = Convert.ToString(P[i].Status) == "Published" ? "checked" : "";
                    string chk = @"<div class='text-center form-check form-switch form-switch-md form-switch-success'>
                                <input class='form-check-input blockItem' type='checkbox' role='switch' data-id='" + P[i].Id + @"' id='chk_" + P[i].Id + @"' " + ft1 + @">
                                </div>";
                    strProjects += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td><u><a class='text-primary fw-bold' href='project-details.aspx?id=" + Convert.ToString(P[i].ProjectGuid) + @"'>" + P[i].ProjectId + @"</a></u></td>
                                        <td class='maxWidth'>" + P[i].ProjectName + @"</td>
                                        <td class='text-center'><a href='" + P[i].ProjectLink + @"' class='text-secondary fw-bold' target='_blank'><i class='mdi mdi-whatsapp fs-18 text-success'></i></a></td>
                                        <td>" + P[i].Subject + @"</td>
                                        <td>" + P[i].MaxCollab + @"</td>
                                        <td>&#8377; " + Convert.ToDecimal(P[i].PriceINR).ToString("N0") + @"</td> 
                                        <td>$ " + Convert.ToString(P[i].PriceOther) + @"</td> 
                                        <td>" + P[i].PostedOn.ToString("dd-MMM-yyyy") + @"</td>
                                        <td>" + chk + @"</td>
                                        <td class='text-center'> 
                                            <a href='write-projects.aspx?id=" + P[i].Id + @"' class='bs-tooltip  fs-18 link-success' data-id='" + P[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'><i class='mdi mdi-pencil'></i></a> 
                                            <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + P[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "BindAllJobs", ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Projects P = new Projects();
            P.Id = Convert.ToInt32(id);
            P.AddedOn = TimeStamps.UTCTime();
            P.AddedIp = CommonModel.IPAddress();
            int exec = Projects.DeleteProjects(conMN, P);
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
    public static string Publish(string id, string ftr)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            if (CreateUser.CheckAccess(conMN, "view-projects.aspx", "Edit", HttpContext.Current.Request.Cookies["med_aid"].Value))
            {
                var Status = ftr == "Yes" ? "Published" : "Active";
                var pro = new Projects()
                {
                    Id = Convert.ToInt32(id),
                    AddedOn = TimeStamps.UTCTime(),
                    AddedIp = CommonModel.IPAddress(),
                    Status = Status,
                };
                int exec = Projects.PublishedProjects(conMN, pro);
                if (exec > 0)
                {
                    x = "Success";
                }
                else
                {
                    x = "W";
                }
            }
            else
            {
                x = "Permission";
            }
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Publish", ex.Message);
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
            details = Projects.GetDetailsById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }
}

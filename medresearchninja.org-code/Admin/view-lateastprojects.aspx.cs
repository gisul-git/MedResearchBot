using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_Lateastprojects : System.Web.UI.Page
{
    public string strProjects = "";
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllLateastprojects();
    }
    public void BindAllLateastprojects()
    {

        try
        {
            strProjects = "";
            List<LatestProject> BD = LatestProject.GetAllLatestProject(conMN);

            for (int i = 0; i < BD.Count; i++)
            {
                var image = "<a href='/" + BD[i].ThumbImage + @"' target='_blank'><img src='/" + BD[i].ThumbImage + @"' alt='' class='rounded-circle avatar-xs shadow'></a>";
                var link = "<a href='" + BD[i].PDFLink + "' target='_blank' class='text-secondary fw-bold'><u>Link</u></a>";
                strProjects += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                         <td>"+image+ @"</td>
                                        <td>" + BD[i].ProjectTitle + @"</td>
                                         <td>" + link + @"</td>
                                        <td>" + BD[i].Category + @"</td>
                                        <td>" + BD[i].AddedOn.ToString("dd/MMM/yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href='add-Lateastprojects.aspx?id=" + BD[i].Id + @"' class='bs-tooltip  fs-18 link-success' data-id='" + BD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit' aria-label='Edit Projects'><i class='mdi mdi-pencil'></i></a> 
                                            <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + BD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete' aria-label='Delete LateastProjects'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllLateastprojects", ex.Message);
        }
    }



    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            LatestProject BD = new LatestProject();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();
            BD.AddedIP = CommonModel.IPAddress();
            int exec = LatestProject.DeleteLatestProject(conMN, BD);    
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
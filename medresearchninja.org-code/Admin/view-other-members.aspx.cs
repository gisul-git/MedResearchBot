using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_other_members : System.Web.UI.Page
{
    public string strMembers = "";
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllOthermembers();
    }
    public void BindAllOthermembers()
    {

        try
        {
            strMembers = "";
            List<Othermemberdetails> BD = Othermemberdetails.GetAllOthermembers(conMN);

            for (int i = 0; i < BD.Count; i++)
            {
                var image = "<a href='/" + BD[i].ThumbImage + @"' target='_blank'><img src='/" + BD[i].ThumbImage + @"' alt='' class='rounded-circle avatar-xs shadow'></a>";
                var link = "<a href='" + BD[i].LinkedinUrl + "' target='_blank' class='text-secondary fw-bold'><u>Link</u></a>";
                strMembers += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                         <td>" + image + @"</td>
                                        <td>" + BD[i].Name + @"</td>
                                        <td>" + BD[i].Type + @"</td>
                                         <td>" + link + @"</td>
                                        <td>" + BD[i].AddedOn.ToString("dd/MMM/yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href='add-other-members.aspx?id=" + BD[i].Id + @"' class='bs-tooltip  fs-18 link-success' data-id='" + BD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit' aria-label='Edit Projects'><i class='mdi mdi-pencil'></i></a> 
                                            <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + BD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete' aria-label='Delete LateastProjects'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllOthermembers", ex.Message);
        }
    }



    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Othermemberdetails BD = new Othermemberdetails();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();
            BD.AddedIp = CommonModel.IPAddress();
            int exec = Othermemberdetails.DeleteOtherMembers(conMN, BD);
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
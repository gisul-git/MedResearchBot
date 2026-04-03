using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_subscribers : System.Web.UI.Page
{
    public string strSubscribers = "";
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllSubscribers();
    }
    public void BindAllSubscribers()
    {

        try
        {
            strSubscribers = "";
            List<EmailSubscription> BD = EmailSubscription.GetAllSubscribers(conMN);

            for (int i = 0; i < BD.Count; i++)
            {
                strSubscribers += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + BD[i].EmailId + @"</td>
                                        <td>" + BD[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + BD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' aria-label='Delete Contacts'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllSubscribers", ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            EmailSubscription BD = new EmailSubscription();
            BD.Id = Convert.ToInt32(id);
            int exec = EmailSubscription.DeleteSubscribers(conMN, BD);
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
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_view_contact_enquiry : System.Web.UI.Page
{

    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrContact = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllContact();
    }
    private void GetAllContact()
    {

        try
        {
            var contact = ContactUs.GetAllContactUs(conMN);
            if (contact != null && contact.Count > 0)
            {
                for (int i = 0; i < contact.Count; i++)
                {
                    StrContact += @"<tr class=''>" +
                                        "<td class='dtr-control sorting_1' tabindex='0'>" + (i + 1) + @"</td>" +
                                        "<td>" + contact[i].Fullname + @"</td>
                                        <td><a href = 'mailto:" + contact[i].EmailAdress + "' class='link'>" + contact[i].EmailAdress + @"</a></td>
                                        <td>" + contact[i].Phone + @"</td>

<td><a href='javascript:void(0);' data-bs-toggle='modal' data-bs-target='#fadeInRightModal' class='btn btn-sm btn-secondary badge-gradient-secondary btnmsg' data-id=" + contact[i].Id + @" data-name=" + contact[i].Fullname + @">View Message</a></td>
 <td><a href='javascript:void();' class='bs-tooltip' data-id='" + contact[i].Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title=''>" + contact[i].AddedOn.ToString("dd-MMM-yyyy") + @"</a></td>


                                        <td class='text-center'> 
                                        <a href = 'javascript:void(0);' class='bs-tooltip deleteItem warning confirm link-danger' data-id='" + contact[i].Id + @"' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'>
                                        <i class='mdi mdi-trash-can-outline fs-18'></i></a> </td>
                                   </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllContact", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string GetContactMessage(string id)
    {
        var message = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            message = ContactUs.GetMessageById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetContactMessage", ex.Message);
        }
        return message;
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ContactUs BD = new ContactUs();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();

            int exec = ContactUs.DeleteContactUs(conMN, BD);
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
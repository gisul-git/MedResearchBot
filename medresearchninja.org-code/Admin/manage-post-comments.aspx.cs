using Newtonsoft.Json;
using System;
using OfficeOpenXml;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Spreadsheet;
public partial class Admin_manage_post_comments : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod(EnableSession = true)]
    public static string GetComments(string PageNo, string PageLenght, string Key)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {

            var result = "";
            var f = Comments.GetForumsComments(conMN, PageNo, PageLenght, Key, "");
            if (f != null && f.Count > 0)
            {
                for (int i = 0; i < f.Count; i++)
                {
                    string sts = "";
                    string reject = "";
                    string Approve = "";
                    var user = MemberDetails.GetMemberDetailsByGuid(conMN, f[i].UserGuid);

                    switch (f[i].Status.ToLower().Trim())
                    {
                        case "rejected":
                            sts = "<a href='javascript:void(0);' class='badge bg-danger text-light'>Rejected</a>";
                            Approve = "<a href='javascript:void(0);' class='text-success btnAccept fs-18'  data-id='" + f[i].Id + @"' data-user='" + f[i].UserGuid + @"' data-question='" + ((f[i].Title) ?? "No Title") + @"' data-bs-toggle='tooltip' title='Accept Comment'><i class='mdi mdi-checkbox-marked-circle-outline text-success'></i></a>";
                            break;
                        case "accepted":
                            sts = "<a href='javascript:void(0);' class='badge bg-success text-light'>Approved</a>";
                            reject = @"<a href='javascript:void(0);' class='text-danger btnreject fs-18'  data-id='" + f[i].Id + @"' data-bs-toggle='tooltip' title='Block Forum'><i class='mdi mdi-cancel'></i></a>";
                            break;
                        case "pending":
                            sts = "<a href='javascript:void(0);' class='badge bg-primary text-light'>Pending</a>";
                            Approve = "<a href='javascript:void(0);' class='text-success btnAccept fs-18'  data-id='" + f[i].Id + @"' data-user='" + f[i].UserGuid + @"' data-question='" + ((f[i].Title) ?? "No Title") + @"' data-bs-toggle='tooltip' title='UnBlock Forum'><i class='mdi mdi-checkbox-marked-circle-outline text-success'></i></a>";
                            reject = @"<a href='javascript:void(0);' class='text-danger btnreject fs-18'  data-id='" + f[i].Id + @"' data-bs-toggle='tooltip' title='Block Forum'><i class='mdi mdi-cancel'></i></a>";
                            break;

                    }
                    if (user != null)
                    {
                        result += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + (f[i].Title ?? "No Title") + @"</td>
                                        <td class='fixed-width'>" + HttpUtility.UrlDecode(f[i].Message) + @"</td>
                                        <td class='fixed-width3'>
                                            <a class='collapsed' data-bs-toggle='collapse' href='#usericon" + i + @"' role='button' aria-expanded='false' aria-controls='usericon'>" + user.FullName + @"<small>(" + user.UserID + @")</small></a>
                                            <div class='collapse' id='usericon" + i + @"' style=''>" + user.EmailId + @",<br>" + user.Contact + @"</div>
                                        </td>
                                        <td>" + f[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                         <td>" + sts + @"</td>
                                        <td class='text-center'>" + Approve + reject + @"
                                        <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + f[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i>
                                            </a>
                                        </td>
                                     </tr>";
                    }
                    else
                    {
                        result += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + (f[i].Title ?? "No Title") + @"</td>
                                        <td class='fixed-width'>" + HttpUtility.UrlDecode(f[i].Message) + @"</td>
                                        <td class='fixed-width3'>
                                           <div class='text-muted'>Anonymous<div>
                                        </td>
                                        <td>" + f[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                         <td>" + sts + @"</td>
                                        <td class='text-center'>" + Approve + reject + @"
                                        <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + f[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i>
                                            </a>
                                        </td>
                                     </tr>";
                    }
                }
            }
            else
            {
                result = "<tr><td class='text-center' colspan='6'>No data to show.</td></tr>";
            }
            return JsonConvert.SerializeObject(new { table = result });
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetComments", ex.Message);
            return "Error";
        }
    }



    [WebMethod(EnableSession = true)]
    public static string AcceptComments(string id, string Uid, string Title, string response)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Comments()
            {
                Id = Convert.ToInt32(id),
                Status = "Accepted"
            };
            var exe = Comments.UpdateComments(conMN, user);
            if (exe > 0)
            {
                 
                var member = MemberDetails.GetMemberDetailsByGuid(conMN, Uid);
                if (member != null)
                {
                    Emails.NewPostReplyMail(member.FullName, member.EmailId, HttpUtility.UrlDecode(Title), response);
                    return "Success";
                }
                else
                {
                    return "Success";
                }
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AcceptComments", ex.Message);
            return "Error";
        }
    }
    [WebMethod(EnableSession = true)]
    public static string DeleteComment(string id)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Comments()
            {
                Id = Convert.ToInt32(id),
                Status = "Deleted"
            };
            var exe = Comments.UpdateComments(conMN, user);
            if (exe > 0)
            {
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteComment", ex.Message);
            return "Error";
        }
    }
    [WebMethod(EnableSession = true)]
    public static string RejectComments(string id)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Comments()
            {

                Id = Convert.ToInt32(id),
                Status = "Rejected"
            };
            var exe = Comments.UpdateComments(conMN, user);
            if (exe > 0)
            {
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RejectComments", ex.Message);
            return "Error";
        }
    }
}
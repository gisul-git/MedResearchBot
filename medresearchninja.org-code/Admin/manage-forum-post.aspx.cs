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
public partial class Admin_manage_forum_post : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    public string StrForumPost = "";
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    [WebMethod(EnableSession = true)]
    public static string DeleteForums(string id)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Forums()
            {
                MessageGuid = id,
                Status = "Deleted"
            };
            var exe = Forums.UpdateBlocked(conMN, user);
            if (exe > 0)
            {
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BlockCustomer", ex.Message);
            return "Error";
        }
    }
    [WebMethod(EnableSession = true)]
    public static string BlockForums(string id)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Forums()
            {

                UserGuid = id,
                Status = "Blocked"
            };
            var exe = Forums.UpdateBlocked(conMN, user);
            if (exe > 0)
            {
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BlockCustomer", ex.Message);
            return "Error";
        }
    }


    [WebMethod(EnableSession = true)]
    public static string AcceptForums(string id,string Uid)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Forums()
            {
                MessageGuid = id,
                Status = "Accepted"
            };
            var exe = Forums.UpdateBlocked(conMN, user);
            if (exe > 0)
            {
                var member = MemberDetails.GetMemberDetailsByGuid(conMN, Uid);
                if (member != null)
                {
                    Emails.NewPostMail(member.FullName, member.EmailId);
                }
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AcceptForums", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string RejectForums(string id)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            var user = new Forums()
            {
                MessageGuid = id,
                Status = "Rejected"
            };
            var exe = Forums.UpdateBlocked(conMN, user);
            if (exe > 0)
            {
                return "Success";
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RejectForums", ex.Message);
            return "Error";
        }
    }
    [WebMethod(EnableSession = true)]
    public static string GetForums(string PageNo, string PageLenght, string Key)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {

            var result = "";
            var total = "0";
            var f = Forums.GetALLForums(conMN, PageNo, PageLenght, Key);
            if (f != null && f.Count > 0)
            {
                for (int i = 0; i < f.Count; i++)
                {
                    var user = MemberDetails.GetMemberDetailsByGuid(conMN, f[i].UserGuid);
                    string sts = "";
                    string reject = "";
                    string Approve = "";
                    switch (f[i].Status.ToLower().Trim())
                    {
                        case "rejected":
                            sts = "<a href='javascript:void(0);' class='badge bg-danger text-light'>Rejected</a>";
                            Approve = "<a href='javascript:void(0);' class='text-success btnAccept fs-18'  data-id='" + f[i].MessageGuid + @"' data-user='" + f[i].UserGuid +@"' data-bs-toggle='tooltip' title='UnBlock Forum'><i class='mdi mdi-checkbox-marked-circle-outline text-success'></i></a>";
                            break;
                        case "accepted":
                            sts = "<a href='javascript:void(0);' class='badge bg-success text-light'>Approved</a>";
                            reject = @"<a href='javascript:void(0);' class='text-danger btnreject fs-18'  data-id='" + f[i].MessageGuid + @"' data-bs-toggle='tooltip' title='Block Forum'><i class='mdi mdi-cancel'></i></a>";
                            break;
                        case "pending":
                            sts = "<a href='javascript:void(0);' class='badge bg-primary text-light'>Pending</a>";
                            Approve = "<a href='javascript:void(0);' class='text-success btnAccept fs-18'  data-id='" + f[i].MessageGuid + @"' data-user='" + f[i].UserGuid +@"' data-bs-toggle='tooltip' title='UnBlock Forum'><i class='mdi mdi-checkbox-marked-circle-outline text-success'></i></a>";
                            reject = @"<a href='javascript:void(0);' class='text-danger btnreject fs-18'  data-id='" + f[i].MessageGuid + @"' data-bs-toggle='tooltip' title='Block Forum'><i class='mdi mdi-cancel'></i></a>";
                            break;

                    }
                    if (user != null)
                    {
                        result += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td class='fixed-width'>" + (f[i].Title ?? "No Title") + @"<br/>
                                            <a class='badge badge-outline-primary btndesc' data-bs-toggle='modal' data-bs-target='#DescModal' data-msg='" + System.Net.WebUtility.HtmlEncode(f[i].Description) + @"'>
                                               Click to view description </a></td>
                                        <td>" + (f[i].Topic ?? "No Topic") + @"</td>
                                        <td class='fixed-width3'>
                                            <a class='collapsed' data-bs-toggle='collapse' href='#usericon" + i + @"' role='button' aria-expanded='false' aria-controls='usericon'>" + user.FullName + @"<small>(" + user.UserID + @")</small></a>
                                            <div class='collapse' id='usericon" + i + @"' style=''>" + user.EmailId + @",<br>" + user.Contact + @"</div>
                                        </td>
                                        <td>" + f[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                         <td>" + sts + @"</td>
                                        <td class='text-center'>" + Approve + reject + @"
                                        <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + f[i].MessageGuid + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i>
                                            </a>
                                        </td>
                                     </tr>";
                    }
                    else
                    {
                        result += @"<tr>
                                        <td>" + f[i].RowNo + @"</td>
                                        <td class='fixed-width'>" + (f[i].Title ?? "No Title") + @"<br/><a class='badge badge-outline-primary collapsed' data-bs-toggle='collapse' href='#collapseWithicon" + i + @"' role='button' aria-expanded='false' aria-controls='collapseWithicon'>
                                               Click to view description 
                                            </a><div class='collapse' id='collapseWithicon" + i + @"' style=''>" + (f[i].Description ?? "No Message") + @"</div></td>
                                        <td>" + (f[i].Topic ?? "No Topic") + @"</td>
                                        <td class='fixed-width3'>
                                           <div class='text-muted'>Not Applicable<div>
                                        </td>
                                        <td>" + f[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                         <td>" + sts + @"</td>
                                        <td class='text-center'>" + Approve + reject + @"
                                        <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + f[i].MessageGuid + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i>
                                            </a>
                                        </td>
                                     </tr>";
                    }

                }
                total = f[0].TotalCount;
            }
            else
            {
                result = "<tr><td class='text-center' colspan='6'>No data to show.</td></tr>";
            }
            return JsonConvert.SerializeObject(new { table = result, count = total });
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetForums", ex.Message);
            return "Error";
        }
    }
}
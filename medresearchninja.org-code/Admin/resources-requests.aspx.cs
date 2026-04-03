using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_resources_requests : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strResourse = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllResourseRequest();
    }
    public void BindAllResourseRequest()
    {
        try
        {
            strResourse = "";
            List<ResourcesEnguiry> RQ = ResourcesEnguiry.GetAllResourcesQuery(conMN);

            for (int i = 0; i < RQ.Count; i++)
            {
                strResourse += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + RQ[i].FullName + @"</td>
                                        <td>" + RQ[i].Email + @"</td>
                                        <td>" + RQ[i].Contact + @"</td>
                                        <td>" + RQ[i].ResourceName + @"</td>
                                        <td>" + RQ[i].AddedOn.ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href ='javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + RQ[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete' aria-label='Delete Contacts'><i class='mdi mdi-trash-can-outline'></i></a> 
                                        </td>
                                        </tr>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllResourseRequest", ex.Message);
        }
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ResourcesEnguiry BD = new ResourcesEnguiry();
            BD.Id = Convert.ToInt32(id);
            int exec = ResourcesEnguiry.DeleteResourcesQuery(conMN, BD);
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
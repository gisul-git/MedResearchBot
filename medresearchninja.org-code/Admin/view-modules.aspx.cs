using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_modules : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllProjects();
    }
    public string strModules = "";
    public void BindAllProjects()
    {
        try
        {
            List<Modules> M = Modules.GetAllModules(conMN);
            if (M.Count > 0)
            {
                for (int i = 0; i < M.Count; i++)
                {

                    strModules += @"<tr>
    <td>" + (i + 1) + @"</td>
    <td class='maxWidth'>" + M[i].ModuleName + @"</td>
    <td class='maxWidth'>" + M[i].ModuleType + @"</td>
    <td class='text-center'>" +
        (!string.IsNullOrEmpty(M[i].videolink) ?
         @"<a href='" + M[i].videolink + @"' class='text-secondary fw-bold' target='_blank'><i class='mdi mdi-video fs-18 text-success'></i></a>" :
         @"<span class='text-muted'>-</span>") +
    @"</td>
   <td><a href='javascript:void(0);' data-bs-toggle='modal' data-bs-target='#viewModuleTextContent' class='btn btn-sm btn-secondary badge-gradient-secondary btnTextContent' data-id=" + M[i].Id + @" data-name='" + M[i].ModuleName + @"' data-textContent='" + M[i].TextContent + @"'>View Text content</a></td>
   <td><a href='javascript:void(0);' data-bs-toggle='modal' data-bs-target='#viewModuleFullDesc' class='btn btn-sm btn-secondary badge-gradient-secondary btnFullDesc' data-id=" + M[i].Id + @" data-name='" + M[i].ModuleName+ @"' data-fullDesc='" + M[i].FullDesc + @"'>View Full description</a></td>
    <td>" +
        (M[i].UpdatedOn != DateTime.MinValue ? M[i].UpdatedOn.ToString("dd-MMM-yyyy") : M[i].AddedOn.ToString("dd-MMM-yyyy")) +
    @"</td>
    <td class='text-center'> 
        <a href='add-modules.aspx?id=" + M[i].Id + @"' class='bs-tooltip fs-18 link-success' data-id='" + M[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'><i class='mdi mdi-pencil'></i></a> 
        <a href='javascript:void(0);' class='bs-tooltip fs-18 link-danger deleteItem' data-id='" + M[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete'><i class='mdi mdi-trash-can-outline'></i></a> 
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
            Modules M = new Modules();
            M.Id = Convert.ToInt32(id);
            M.AddedOn = TimeStamps.UTCTime();
            M.AddedIp = CommonModel.IPAddress();
            int exec = Modules.DeleteModules(conMN, M);
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
    public static Modules GetDetails(string id)
    {
        Modules details=new Modules();
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            details = Modules.GetModulesDetailsById(conMN, Convert.ToInt32(id));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_project_tags : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    public string strTag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            GetTagList();
            if (Request.QueryString["id"] != null)
            {
                GetTagDetails();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string aid = Request.Cookies["med_aid"].Value;
                ProjectTags st = new ProjectTags()
                {
                    TagTitle = txtName.Text,
                    AddedBy = aid,
                    Status = "Active",
                    Id = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]),
                };
                if (btnSave.Text == "Update")
                {
                    int result = ProjectTags.UpdateTag(conMN, st);
                    if (result > 0)
                    {
                        GetTagDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Tag Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = ProjectTags.AddTag(conMN, st);
                    if (result > 0)
                    {
                        txtName.Text = string.Empty;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Tag added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                GetTagList();
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            }
        }
    }

    public void GetTagDetails()
    {
        try
        {
            var Tag = ProjectTags.GetAllTagDetailsWithId(conMN, Convert.ToInt32(Request.QueryString["id"]));
            if (Tag != null)
            {
                btnSave.Text = "Update";
                txtName.Text = Tag.TagTitle;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTagDetails", ex.Message);
        }
    }
    public void GetTagList()
    {
        try
        {
            var sub = ProjectTags.GetAllTags(conMN);
            if (sub != null)
            {
                for (int i = 0; i < sub.Count; i++)
                {
                    strTag += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + sub[i].TagTitle + @"</td>
                                        <td>" + Convert.ToDateTime(sub[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='manage-project-tags.aspx?id=" + sub[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + sub[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'>
                                               <i class='mdi mdi-pencil'></i></a>
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + sub[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete'>
                                                <i class='mdi mdi-trash-can-outline'></i></a>
                                        </td>
                                    </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTagList", ex.Message);

        }
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ProjectTags BD = new ProjectTags();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = ProjectTags.DeleteTag(conMN, BD);
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
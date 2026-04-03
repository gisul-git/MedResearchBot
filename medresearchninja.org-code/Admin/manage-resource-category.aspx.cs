using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_category : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strResourcesCategory = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", " this.disabled = 'true';this.value='Please Wait...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
        GetAllResourcesCategory();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetResourcesCategory();
            }
            else
            {

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                ResourcesCategory rc = new ResourcesCategory();
                if (btnSave.Text == "Update")
                {
                    rc.AddCategory = txtTitle.Text.Trim();
                    rc.Id = Convert.ToInt32(Request.QueryString["id"]);
                    rc.AddedIP = CommonModel.IPAddress();
                    rc.AddedOn = TimeStamps.UTCTime();
                    rc.Status = "Active";
                    rc.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = ResourcesCategory.UpdateResourcesCategory(conMN, rc);
                    if (result > 0)
                    {
                        GetAllResourcesCategory();
                        GetResourcesCategory();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Category updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
            

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    rc.AddCategory = txtTitle.Text.Trim();
                    rc.Id = Convert.ToInt32(Request.QueryString["id"]);
                    rc.AddedIP = CommonModel.IPAddress();
                    rc.AddedOn = TimeStamps.UTCTime();
                    rc.Status = "Active";
                    rc.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = ResourcesCategory.InsertResourcesCategory(conMN, rc);
                    if (result > 0)
                    {
                        txtTitle.Text = "";
                        GetResourcesCategory();
                        GetAllResourcesCategory();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Category added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }

    public void GetAllResourcesCategory()
    {
        try
        {
            strResourcesCategory = "";
            List<ResourcesCategory> cas = ResourcesCategory.BindResourcesCategory(conMN).OrderByDescending(s => Convert.ToDateTime(s.AddedOn)).ToList();
            int i = 0;
            foreach (ResourcesCategory rc in cas)
            {

                strResourcesCategory += @"<tr>
                                                <td>" + (i + 1) + @"</td>  
                                                             <td>" + rc.AddCategory + @"</td>
                                         <td><a href='javascript:void();' class='bs-tooltip' data-id='" + rc.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title=''>" + rc.AddedOn.ToString("dd-MMM-yyyy") + @"</a></td>  

                                                <td class='text-center'>
                                                    <a href='manage-resource-category.aspx?id=" + rc.Id + @"' class='bs-tooltip fs-18 link-info' data-id='" + rc.Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'>
                                                        <i class='mdi mdi-pencil'></i></a>
                                                    <a href='javascript:void(0);' class='bs-tooltip fs-18 link-danger deleteItem' data-id='" + rc.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title='Delete'>
                                                        <i class='mdi mdi-trash-can-outline'></i></a>
                                                </td>
                                            </tr>";
                i++;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllResourcesCategory", ex.Message);
        }
    }
    public void GetResourcesCategory()
    {
        try
        {
            ResourcesCategory RC = ResourcesCategory.GetResourcesCategory(conMN, Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
            if (RC != null)
            {

                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtTitle.Text = RC.AddCategory;

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResourcesCategorys", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ResourcesCategory RC = new ResourcesCategory();
            RC.Id = Convert.ToInt32(id);
            RC.AddedOn = TimeStamps.UTCTime();
            RC.AddedIP = CommonModel.IPAddress();
            int exec = ResourcesCategory.DeleteResourcesCategory(conMN, RC);
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


    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage-resource-category.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_manage_category : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    public string strCat = "<tr><td colspan='4' class='text-center'>No data to show</td></tr>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            GetCategoryList();
            if (Request.QueryString["id"] != null)
            {
                GetCategoryDetails();
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
                Category st = new Category()
                {
                    CategoryName = txtCategory.Text,
                    AddedOn = DateTime.Now,
                    AddedIp = aid,
 
                    Status = "Active",
                    Id = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]),
                };
                if (btnSave.Text == "Update")
                {
                    int result = Category.UpdateCategory(conSQ, st);
                    if (result > 0)
                    {
                        GetCategoryDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: ' Category Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }
                else
                {
                    int result = Category.AddCategory(conSQ, st);
                    if (result > 0)
                    {
                        txtCategory.Text = "";
                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Category added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                GetCategoryList();

            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            }
        }
    }

    public void GetCategoryDetails()
    {
        try
        {
            var Cat = Category.GetAllCategoryDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (Cat != null)
            {
                btnNew.Visible = true;
                btnSave.Text = "Update";
                txtCategory.Text = Cat.CategoryName;
               
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCategoryDetails", ex.Message);
        }
    }

    public void GetCategoryList()
    {
        try
        {
            var sub = Category.GetAllCategory(conSQ);
            if (sub != null)
            {
                strCat = "";
                for (int i = 0; i < sub.Count; i++)
                {
                    strCat += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + sub[i].CategoryName + @"</td>
                                        <td>" + Convert.ToDateTime(sub[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                         <td>" + sub[i].AddedIp + @"</td>
                                        <td class='text-center'>
                                            <a href='manage-category.aspx?id=" + sub[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                               <i class='mdi mdi-pencil'></i></a>
                                            <a href='javascript:void(0);' class='bs-tooltip warning confirm text-danger fs-18 deleteItem' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i></a>
                                        </td>
                                    </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCategoryList", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Category BD = new Category();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = Category.DeleteCategory(conMN, BD);
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
        Response.Redirect("manage-category.aspx", false);
    }
}
using System.Collections.Generic;
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_blogs : System.Web.UI.Page
{
    public string strBlogs = "";
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllBlogDetails();

        }
    }

    public void GetAllBlogDetails()
    {
        try
        {
            strBlogs = "";
            List<BlogDetails> blog = BlogDetails.GetAllBlogDetails(conMN).ToList();
            int i = 0;
            foreach (BlogDetails pro in blog)
            {
                string pdby = pro.PostedBy == "" ? pro.AddedBy : pro.PostedBy;
                string ft1 = pro.Status == "Active" ? "checked" : "";
                string sts = pro.Status == "Active" ? "<span id='sts_" + pro.Id + @"' class='badge badge-outline-success shadow fs-13'>Published</span>" : "<span id='sts_" + pro.Id + @"' class='badge badge-outline-warning shadow fs-13'>Draft</span>";
                string chk = @"<div class='text-center form-check form-switch form-switch-lg form-switch-success'>
                               <input type='checkbox' data-id='" + pro.Id + @"' class='form-check-input PublishBlog' id='chk_" + pro.Id + @"' " + ft1 + @">
                               <span class='slider round'></span>
                              </div>";



                strBlogs += @"<tr>
                                <td>" + (i + 1) + @"</td>    
                                <td><a href='/" + pro.ThumbImage + @"'/><img src='/" + pro.ThumbImage + @"' style='height:60px;' /></td>
                                <td><a href='/" + pro.BlogImage + @"'/><img src='/" + pro.BlogImage + @"' style='height:60px;' /></td>
                                <td><a target='_blank' class='bs-tooltip' data-toggle='tooltip' data-placement='top' title='' data-original-title='Preview Journal' href='/blog/" + pro.BlogUrl + @"'>" + pro.BlogTitle + @"</a></td>
                                <td>" + pdby + @"</td> 
                                <td>" + Convert.ToDateTime(pro.PostedOn).ToString("dd/MM/yyyy hh:mm tt") + @"</td> 
                                <td>" + sts + @"</td> 
                                <td>" + chk + @"</td> 
                                <td class='text-center'> 
                                                <a href='add-blogs.aspx?id=" + pro.Id + @"' class='bs-tooltip fs-18' data-id='" + pro.Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'>
                                                        <i class='mdi mdi-pencil'></i></a>
                                                    <a href='javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + pro.Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete'>
                                                        <i class='mdi mdi-trash-can-outline'></i></a>
                                                      </td>
                                            </tr>";
                i++;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetails", ex.Message);
        }
    }
    [WebMethod(EnableSession = true)]
    public static string PublishBlog(string id, string ftr)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            BlogDetails b = new BlogDetails();
            b.Id = Convert.ToInt32(id);
            b.Status = ftr == "Yes" ? "Active" : "Draft";
            int exec = BlogDetails.PublishBlogDetails(conMN, b);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "PublishBlog", ex.Message);
        }
        return x;
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            BlogDetails BD = new BlogDetails();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();
            BD.AddedIP = CommonModel.IPAddress();
            int exec = BlogDetails.DeleteBlogDetails(conMN, BD);
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
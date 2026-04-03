using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blogs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod(EnableSession =true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<BlogDetails> allBlogs(string pno)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        List<BlogDetails> blogs = null;
        try
        {
            blogs = BlogDetails.GetAllListBlogDetails(conMN, Convert.ToInt32(pno));

        }
        catch (Exception ex)
        {

            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "allBlogs", ex.Message);

        }
        return blogs;
    }
}
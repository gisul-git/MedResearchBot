using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_details : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrImgUrl = "", strBlogUrl = "", StrBlogTitle = "", StrPostedBy = "", StrPostedOn = "", StrDesc, strPstedBy, StrRecentBlogs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strBlogUrl = Convert.ToString(RouteData.Values["burl"]);
        if (strBlogUrl != "")
        {
            BindBlogs();
            BindRecentBlogs();
        }
        else
        {
            Response.Redirect("/404.aspx");
        }
    }
    public void BindBlogs()
    {
        try
        {
            BlogDetails lst = BlogDetails.GetAllBlogDetailsWithUrl(conMN, strBlogUrl).FirstOrDefault();
            if (lst != null)
            {
                DateTime postedOn = Convert.ToDateTime(lst.PostedOn);
                StrDesc = lst.FullDesc;
                StrBlogTitle = lst.BlogTitle;
                strBlogUrl = lst.BlogUrl;
                StrPostedOn = postedOn.ToString("MMM dd, yyyy");
                StrPostedBy = lst.PostedBy;
                StrImgUrl = lst.BlogImage;
                Page.Title = lst.PageTitle;
                Page.MetaDescription = lst.MetaDesc;
                Page.MetaKeywords = lst.MetaKeys;
            }
            else
            {
                Response.Redirect("/404.aspx");
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindBlogs", ex.Message);
        }
    }
    public void BindRecentBlogs()
    {
        try
        {
            StrRecentBlogs = "";
            List<BlogDetails> blogs = BlogDetails.GetRecentBlogs(conMN);
            if (blogs.Count > 0)
            {
                foreach (BlogDetails del in blogs)
                {
                    StrRecentBlogs += @"<li class='recent-post-list-li'> 
											<a class='recent-post-thum' href='#'>
												<img src='/" + del.ThumbImage + @"' class='img-fluid' alt=''>
											</a>
											<div class='pbmit-rpw-content'>
												<span class='pbmit-rpw-title'>
													<a href='/blog/" + del.BlogUrl + @"'>" + del.BlogTitle + @"</a>
												</span>
												<span class='pbmit-rpw-date'>
													<a href='javascript:void(0)'>" + Convert.ToDateTime(del.PostedOn).ToString("MMM dd , yyyy") + @"</a>
												</span>
											</div> 
										</li>";
                }
            }
        }
        catch (Exception ex)
        {

            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindRecentBlogs", ex.Message);
        }
    }
}
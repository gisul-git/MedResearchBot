using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_write_blog : System.Web.UI.Page
{

    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strThumbImage = "", strBlogImage = "";
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                bindBlogDetails();
            }
        }
    }
    public void bindBlogDetails()
    {
        try
        {
            var blog = BlogDetails.getBlogDetailsById(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (blog != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtName.Text = blog.BlogTitle;
                txtUrl.Text = blog.BlogUrl;
                txtMetaDesc.Text = blog.MetaDesc;
                txtPostedBy.Text = blog.PostedBy;
                txtShortDesc.Text = blog.ShortDesc;
                txtPostedOn.Text = blog.PostedOn.ToString("dd MMM yyyy");
                txtMetaKey.Text = blog.MetaKeys;
                txtDesc.Text = blog.FullDesc;
                txtPageTitle.Text = blog.PageTitle;
                if (blog.ThumbImage != "")
                {
                    strThumbImage = "<img src='/" + blog.ThumbImage + "' style='max-height:60px;' />";
                    lblThumb.Text = blog.ThumbImage;
                }
                if (blog.BlogImage != "")
                {
                    strBlogImage = "<img src='/" + blog.BlogImage + "' style='max-height:60px;' />";
                    lblBlog.Text = blog.BlogImage;
                }
                divimg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "bindBlogDetails", ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                #region Upload Image
                var thumbimg = CheckThumbFormat();
                if (thumbimg == "Format")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image format. Please upload .png, .jpeg, .jpg, .webp, .gif for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }
                if (thumbimg == "Size")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image size.Please upload correct resolution image for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }

                var Blogimg = CheckBlogImageFormat();
                if (Blogimg == "Format")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image format. Please upload .png, .jpeg, .jpg, .webp, .gif for blog image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }
                if (Blogimg == "Size")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image size.Please upload correct resolution image for blog image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }
                #endregion

                var aid = Request.Cookies["med_aid"].Value;

                BlogDetails BD = new BlogDetails();                                         
                BD.BlogTitle = txtName.Text.Trim();
                BD.BlogUrl = txtUrl.Text.Trim();
                BD.Category = "";
                BD.ShortDesc = txtShortDesc.Text.Trim();
                BD.PostedBy = txtPostedBy.Text.Trim();
                BD.ThumbImage = UploadThumbImage();
                BD.BlogImage = UploadBlogImage();
                BD.FullDesc = txtDesc.Text.Trim();
                BD.MetaDesc = txtMetaDesc.Text.Trim();
                BD.MetaKeys = txtMetaKey.Text.Trim();
                BD.PageTitle = txtPageTitle.Text.Trim();
                BD.AddedIP = CommonModel.IPAddress();
                BD.AddedOn = TimeStamps.UTCTime();
                BD.PostedOn = Convert.ToDateTime(txtPostedOn.Text.Trim());
                BD.AddedBy = aid;

                if (string.IsNullOrEmpty(BD.ThumbImage))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please upload Thumbnail Image.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }

                if (string.IsNullOrEmpty(BD.BlogImage))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please upload Detail Image.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }

                if (btnSave.Text == "Update")
                {
                    BD.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = BlogDetails.UpdateBlogDetails(conSQ, BD);
                    if (result > 0)
                    {
                        bindBlogDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Blog Details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = BlogDetails.InsertBlogDetails(conSQ, BD);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Blog Details Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtName.Text = txtUrl.Text = txtPostedBy.Text = txtShortDesc.Text = txtDesc.Text = txtPageTitle.Text = txtMetaKey.Text = txtMetaDesc.Text = "";
                        strThumbImage = strBlogImage = "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
        }
    }
    private string CheckThumbFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (Thumbimage.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(Thumbimage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "_Blogthumb" + fileExtension;
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(Thumbimage.PostedFile.InputStream);
                    if ((bitimg.PhysicalDimension.Height != 400) || (bitimg.PhysicalDimension.Width != 600))
                    {
                        return "Size";
                }
                    }
                else
                {

                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckThumbFormat", ex.Message);

            }
        }
        #endregion
        return thumbImg;
    }
    public string UploadThumbImage()
    {
        #region upload file
        string thumbfile = "";
        try
        {
            if (Thumbimage.HasFile)
            {
                string fileExtension = Path.GetExtension(Thumbimage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-sample".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                try
                {
                    if (File.Exists(Server.MapPath("~/" + Convert.ToString(lblThumb.Text))))
                    {
                        File.Delete(Server.MapPath("~/" + Convert.ToString(lblThumb.Text)));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadThumbImage", eeex.Message);
                    return lblThumb.Text;
                }
                Thumbimage.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblThumb.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadThumbImage", ex.Message);

        }

        #endregion
        return thumbfile;
    }
    private string CheckBlogImageFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (BlogImage.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(BlogImage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "_Blogthumb" + fileExtension;
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(BlogImage.PostedFile.InputStream);
                    if ((bitimg.PhysicalDimension.Height != 600) || (bitimg.PhysicalDimension.Width != 900))
                    {
                        return "Size";
                    }
                }
                else
                {

                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckBlogImageFormat", ex.Message);

            }
        }
        #endregion
        return thumbImg;
    }
    public string UploadBlogImage()
    {
        #region upload file
        string thumbfile = ""; 
        try
        {
            if (BlogImage.HasFile)
            {
                string fileExtension = Path.GetExtension(BlogImage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-BlogImg".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                try
                {
                    if (File.Exists(Server.MapPath("~/" + Convert.ToString(lblBlog.Text))))
                    {
                        File.Delete(Server.MapPath("~/" + Convert.ToString(lblBlog.Text)));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadBlogImage", eeex.Message);
                    return lblBlog.Text;
                }
                BlogImage.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblBlog.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadBlogImage", ex.Message); 

        }

        #endregion
        return thumbfile;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
       Response.Redirect("write-blog.aspx", false);
    }
}
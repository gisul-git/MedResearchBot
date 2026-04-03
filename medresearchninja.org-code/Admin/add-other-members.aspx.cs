using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_add_other_members : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strThumbImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BindOthermembers();
            }
        }
    }
    public void BindOthermembers()
    {
        try
        {
            var mem = Othermemberdetails.GetOthermembersById(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (mem != null)
            {

                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtname.Text = mem.Name;
                txtlink.Text = mem.LinkedinUrl;
                ddltype.SelectedValue = mem.Type;
                if (mem.ThumbImage != "")

                {
                    strThumbImage = "<img src='/" + mem.ThumbImage + "' style='max-height:60px;' />";

                    lblThumb.Text = mem.ThumbImage;
                }


            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindOthermembers", ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (Page.IsValid)
            {
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


                var aid = Request.Cookies["med_aid"].Value;

                Othermemberdetails test = new Othermemberdetails();

                test.Name = txtname.Text.Trim();
                test.ThumbImage = UploadThumbImage();
                test.LinkedinUrl= txtlink.Text.Trim();
                test.Type = ddltype.Text.Trim();
                test.Status = "Active";
                test.AddedOn = TimeStamps.UTCTime();
                test.AddedIp = CommonModel.IPAddress();
                test.AddedBy = aid;
                test.Status = "Active";


                if (btnSave.Text == "Update")
                {
                    test.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = Othermemberdetails.UpdateOthermember(conSQ, test);
                    if (result > 0)
                    {
                        BindOthermembers();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Other Member Details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = Othermemberdetails.InsertOthermember(conSQ, test);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Other Member Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtname.Text = txtlink.Text = "";
                        ddltype.Text = "0";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please fill all required fields.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
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
                    if ((bitimg.PhysicalDimension.Height != 581) || (bitimg.PhysicalDimension.Width != 556))
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-other-members.aspx", false);
    }
}


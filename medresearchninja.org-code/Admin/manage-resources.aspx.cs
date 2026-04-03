using System;
using System.Activities.Expressions;
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

public partial class Admin_manage_resources : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strAllResources = "", strThumbImage="", strPDF="";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllResources();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetResources();
            }


            GetCategoryDDL();
        }
    }
    public void GetCategoryDDL()
    {
        try
        {
            List<ResourcesCategory> RC = ResourcesCategory.GetCategoryDDL(conMN);
            if (RC.Count > 0)
            {
                ddlCategory.DataSource = RC;
                ddlCategory.DataValueField = "AddCategory";
                ddlCategory.DataTextField = "AddCategory";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            }
            
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCategoryDDL", ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                ManageResources mr = new ManageResources();
                if (btnSave.Text == "Update")
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
                    var rPath = CheckPDFFormat();
                    if (rPath == "Format")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image size.Please upload correct resolution image for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                        return;
                    }

                    mr.ProjectTitle = txtResourseTitle.Text.Trim();
                    mr.Id = Convert.ToInt32(Request.QueryString["id"]);
                    mr.Category = ddlCategory.SelectedValue;
                    mr.PDFFile = UploadPDFFormat();
                    mr.ThumbImage = UploadThumbImage();
                    mr.AddedIP = CommonModel.IPAddress();
                    mr.AddedOn = TimeStamps.UTCTime();
                    mr.Status = "Active";
                    mr.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = ManageResources.UpdateResources(conMN, mr);
                    if (result > 0)
                    {
                       GetAllResources();
                       GetResources();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Resource updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
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
                    var rPath = CheckPDFFormat();
                    if (rPath == "Format")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please upload correct file format for PDF',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                        return;
                    }
                    mr.ProjectTitle = txtResourseTitle.Text.Trim();
                    mr.Id = Convert.ToInt32(Request.QueryString["id"]);
                    mr.Category = ddlCategory.SelectedValue;
                    mr.PDFFile = UploadPDFFormat();
                    mr.ThumbImage = UploadThumbImage();
                    mr.AddedIP = CommonModel.IPAddress();
                    mr.AddedOn = TimeStamps.UTCTime();
                    mr.Status = "Active";
                    mr.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = ManageResources.InsertResources(conMN, mr);
                    if (result > 0)
                    {
                        txtResourseTitle.Text = "";
                         GetResources();
                        GetAllResources();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Resource added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);

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

    private string CheckThumbFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (thumbImage.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(thumbImage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "_Resousethumb" + fileExtension;
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(thumbImage.PostedFile.InputStream);
                    if ((bitimg.PhysicalDimension.Height != 250) || (bitimg.PhysicalDimension.Width != 329))
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
            if (thumbImage.HasFile)
            {
                string fileExtension = Path.GetExtension(thumbImage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-sample".Replace(" ", "-").Replace(".", "");
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
                thumbImage.SaveAs(iconPath);
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

    private string CheckPDFFormat()
    {
        #region PDF
        string UploadPdf = "";
        if (UploadPDF.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(UploadPDF.PostedFile.FileName.ToLower()), ImageGuid1 = CommonModel.seourl(txtResourseTitle.Text.Trim()).ToLower();
                if ((fileExtension == ".pdf" || fileExtension == ".doc"))
                {

                    string iconPath = Server.MapPath(".") + "\\../Uploadpdf\\" + ImageGuid1 + fileExtension;
                }
                else
                {

                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckPDFFormat", ex.Message);

            }
        }
        #endregion
        return UploadPdf;
    }

    public string UploadPDFFormat()
    {
        #region upload file
        string thumbfile = "";
        try
        {
            if (UploadPDF.HasFile)
            {
                string fileExtension = Path.GetExtension(UploadPDF.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                UploadPDF.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblpdf.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadPDFFormat", ex.Message);

        }

        #endregion
        return thumbfile;
    }

    public void GetAllResources()
    {
        try
        {
            strAllResources = "";
            List<ManageResources> cas = ManageResources.GetAllResources(conMN).OrderByDescending(s => Convert.ToDateTime(s.AddedOn)).ToList();
            int i = 0;
            foreach (ManageResources nb in cas)
            {
                strAllResources += @"<tr>
                                                <td>" + (i + 1) + @"</td>
                                                <td><a href='/" + nb.ThumbImage + @"'/><img src='/" + nb.ThumbImage + @"' style='height:60px;' /></td>
                                                <td><a href='/" + nb.PDFFile + @"' target='_blank'/><img src='assets/images/pdf.png' style='height:60px;' /></td>
                                                <td>" + nb.Category + @"</td>
                                                 <td>" + nb.ProjectTitle + @"</td>
                                                <td><a href='javascript:void();' class='bs-tooltip' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title=''>" + nb.AddedOn.ToString("dd-MMM-yyyy") + @"</a></td>  
                                                <td class='text-center'>
                                                    <a href='manage-resources.aspx?id=" + nb.Id + @"' class='bs-tooltip fs-18 link-info' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'>
                                                        <i class='mdi mdi-pencil'></i></a>
                                                    <a href='javascript:void(0);' class='bs-tooltip fs-18 link-danger deleteItem' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title='Delete'>
                                                        <i class='mdi mdi-trash-can-outline'></i></a>
                                                </td>
                                            </tr>";
                i++;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllResources", ex.Message);
        }
    }

    public void GetResources()
    {
        try
        {
            ManageResources MR = ManageResources.GetResources(conMN, Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
            if (MR != null)
            {
                
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtResourseTitle.Text = MR.ProjectTitle;
                ddlCategory.SelectedValue = MR.Category;
                if (MR.ThumbImage != "")
                {
                    strThumbImage = "<img src='/" + MR.ThumbImage + "' style='max-height:60px;' />";
                    lblThumb.Text = MR.ThumbImage;
                }
                if (MR.PDFFile != "")
                {
                    divpdf.Visible = true;
                    strPDF = MR.PDFFile;
                }
                
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResources", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            ManageResources MR = new ManageResources();
            MR.Id = Convert.ToInt32(id);
            MR.AddedOn = TimeStamps.UTCTime();
            MR.AddedIP = CommonModel.IPAddress();
            int exec = ManageResources.DeleteResources(conMN, MR);
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
        Response.Redirect("manage-resources.aspx");
    }
}

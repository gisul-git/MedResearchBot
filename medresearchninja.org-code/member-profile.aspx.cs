using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class member_profile : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strProfileimg = "", strGovtImg = "", StrWLink = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
     if (Request.Cookies["med_uid"] == null)
        {

            Response.Redirect("login.aspx");
        }
        CheckUserExist();
        int count = Projects.GetPendingProjectDuesCount(conMN, Request.Cookies["med_uid"].Value);
        strDues = count > 0 ? "<span class='badge-circle'>" + count + "</span>" : "";
        if (!IsPostBack)
        {

            BindAllMemberDetails();
        }

    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Cookies["med_uid"].Expires = TimeStamps.UTCTime().AddDays(-10);
            Response.Redirect("login.aspx");
        }
    }
    public void BindAllMemberDetails()
    {
        try
        {
            var MemberDetail = MemberDetails.GetMemberDetailsByGuid(conMN, Convert.ToString(Request.Cookies["med_uid"].Value));
            if (MemberDetail != null)
            {

                btnUpdate.Text = "Update";
                btnUpdate.Visible = true;
                txtFullName.Text = MemberDetail.FullName;
                txtEmailAddress.Text = MemberDetail.EmailId;
                txtContactNumber.Text = MemberDetail.Contact;
                txtCountry.Text = MemberDetail.Country;
                txtCourse.Text = MemberDetail.MedicalSchoolName;
                txtCity.Text = MemberDetail.City;
                txtAddress.Text = MemberDetail.Address;
                txtState.Text = MemberDetail.State;
                txtPincode.Text = MemberDetail.Pincode;
                ddlWhoAreYou.SelectedIndex = ddlWhoAreYou.Items.IndexOf(ddlWhoAreYou.Items.FindByValue(MemberDetail.WhoAreYou));

                txtspecify.Text = MemberDetail.Specify;
                if (MemberDetail.ProfileImage != "")
                {
                    strProfileimg = "<img src='/" + MemberDetail.ProfileImage + "' style='max-height:60px;' class='w-100 rounded-circle wa-xs'/>";
                    lblThumb.Text = MemberDetail.ProfileImage;
                }
                if (MemberDetail.GovtID != "")
                {
                    strGovtImg = "<a href='/" + MemberDetail.GovtID + @"'><img src='/img/pdfimg.png' style='max-height:60px;' class='img-fluid'/></a>";
                    lblGovtID.Text = MemberDetail.GovtID;
                }
            }

            var Wlink = WhatsappLink.GetAllWhatsappLink(conMN).FirstOrDefault();
            if (Wlink != null)
            {
                StrWLink = Wlink.Wlink;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllMemberDetails", ex.Message);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        lblStatus.CssClass = "";

        try
        {
            if (Page.IsValid)
            {
                var thumbimg = CheckProfileFormat();
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
                var rPath = CheckGovtIDFormat();
                if (rPath == "Format")
                {
                    lblStatus.Text = "Invalid GovtID format.";
                    lblStatus.CssClass = "alert alert-danger d-block";
                    return;
                }
                MemberDetails CD = new MemberDetails();

                CD.UserGuid = Convert.ToString(Request.Cookies["med_uid"].Value);
                CD.UpdatedIp = CommonModel.IPAddress();
                CD.UpdatedBy = Convert.ToString(Request.Cookies["med_uid"].Value);
                CD.Address = txtAddress.Text.Trim();
                CD.City = txtCity.Text.Trim();
                CD.State = txtState.Text.Trim();
                CD.Pincode = txtPincode.Text.Trim();
                CD.GovtID = UploadGovtIDPath();
                CD.FullName = txtFullName.Text.Trim();
                CD.EmailId = txtEmailAddress.Text.Trim();
                CD.Contact = txtContactNumber.Text.Trim();
                CD.Country = txtCountry.Text.Trim();
                CD.MedicalSchoolName = txtCourse.Text.Trim();
                CD.ProfileImage = UploadProfileImage();
                CD.UpdatedOn = TimeStamps.UTCTime();
                CD.PaymentStatus = "Paid";
                CD.LastLoggedIn = TimeStamps.UTCTime();
                CD.LastLoggedIp = CommonModel.IPAddress();
                CD.WhoAreYou = ddlWhoAreYou.SelectedValue;
                CD.Specify = txtspecify.Text.Trim() == "" ? "" : txtspecify.Text.Trim();
                int res = MemberDetails.UpdateMemberProfile(conMN, CD);
                if (res > 0)
                {
                    BindAllMemberDetails();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Profile Details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#ff7f3e'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            }
        }

        catch (Exception ex)
        {
            lblStatus.Text = "There is some problem now. Please try after some time";
            lblStatus.CssClass = "alert alert-danger d-block";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnUpdate_Click", ex.Message);

        }
    }
    private string CheckGovtIDFormat()
    {
        #region ThumbImage
        string GovtIdPDF = "";
        if (UploadGovtID.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(UploadGovtID.PostedFile.FileName.ToLower());
                if (!(fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckGovtIDFormat", ex.Message);
            }
        }
        #endregion
        return GovtIdPDF;
    }
    public string UploadGovtIDPath()
    {
        #region upload file
        string thumbfile = "";
        try
        {
            if (UploadGovtID.HasFile)
            {
                string fileExtension = Path.GetExtension(UploadGovtID.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                UploadGovtID.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblGovtID.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadGovtIDPath", ex.Message);

        }

        #endregion
        return thumbfile;
    }
    private string CheckProfileFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (uploadProfileimg.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(uploadProfileimg.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if (!(fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    return "Format";
                }

            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckProfileFormat", ex.Message);

            }
        }
        #endregion
        return thumbImg;
    }

    public string UploadProfileImage()
    {
        #region upload Image
        string thumbfile = "";
        try
        {
            if (uploadProfileimg.HasFile)
            {
                string fileExtension = Path.GetExtension(uploadProfileimg.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-sample".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\./UploadImages\\" + ImageGuid1 + "" + fileExtension;
                try
                {
                    if (File.Exists(Server.MapPath("~/" + Convert.ToString(lblThumb.Text))))
                    {
                        File.Delete(Server.MapPath("~/" + Convert.ToString(lblThumb.Text)));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadProfileImage", eeex.Message);
                    return lblThumb.Text;
                }
                uploadProfileimg.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblThumb.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadProfileImage", ex.Message);

        }

        #endregion
        return thumbfile;
    }
    public void CheckUserExist()
    {
        try
        {
            if (Request.Cookies["med_uid"] == null)
            {

                StrLink = "/signup.aspx";
                StrText = "Sign Up";
                StrLoginBtn = "<a href='/signup.aspx' class='ud-btn1 btn-thm w-50'>Sign Up</a>";

            }
            else
            {
                var user = MemberDetails.GetMemberDetailsByGuid(conMN, Request.Cookies["med_uid"].Value);
                if (user != null)
                {
                    StrUserImage = user.ProfileImage == "" ? "<img src='/images/user.png' alt='user.png' width='30' />" : "<img src='/" + user.ProfileImage + @"' alt='user.png' width='30' />";
                    StrUserName = user.FullName;
                }
                StrLink = "/member-profile.aspx";
                StrText = "My Profile";
                StrLoginBtn = "<a href='/member-profile.aspx' class='ud-btn1 btn-thm w-50'>My Profile</a>";
            }
        }
        catch (Exception ex)
        {

        }
    }
}



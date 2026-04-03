using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_add_member : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);


    public string strThumbImage = "", strGovtImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetDetails();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
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


            var govtimg = CheckGovtIDFormat();
            if (govtimg == "Format")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image format. Please upload .png, .jpeg, .jpg, .webp, .gif for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                return;
            }
            if (govtimg == "Size")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image size.Please upload correct resolution image for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                return;
            }



            var aid = Request.Cookies["med_aid"].Value;

            var member = new MemberDetails()
            {
                AddedBy = aid,
                AddedIp = CommonModel.IPAddress(),
                AddedOn = TimeStamps.UTCTime(),
                Address = txtAddress.Text,
                City = txtCity.Text,
                Contact = txtContactNo.Text,
                Country = txtCountry.Text,
                EmailId = txtEmail.Text,
                ForgotId = "",
                FullName = txtName.Text,
                GovtID = UploadGovtIDPath(),
                Id = 0, //No dependancy
                LastLoggedIn = TimeStamps.UTCTime(),
                LastLoggedIp = CommonModel.IPAddress(),
                MedicalSchoolName = txtMedical.Text,
                PassKey = "",
                Password = CommonModel.Encrypt(txtPwd.Text),
                PaymentStatus = ddlPayStatus.SelectedValue,
                Pincode = txtPincode.Text,
                ProfileImage = UploadProfileImage(),
                Specify = "",
                State = txtState.Text,
                Status = ddlStatus.SelectedValue,
                UpdatedBy = aid,
                MsgCnt = "0",
                UpdatedIp = CommonModel.IPAddress(),
                UpdatedOn = TimeStamps.UTCTime(),
                UserGuid = Request.QueryString["id"] != null ? Convert.ToString(Request.QueryString["id"]) : Guid.NewGuid().ToString(),
                UserID = UserID(),
                WhoAreYou = ddlWho.SelectedValue,
            };

            if (btnSave.Text == "Update")
            {
                int res = MemberDetails.UpdateMemberProfile(conMN, member);
                if (res == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Email Id Already Registered. Please check again ',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    //lblStatus.Text = "Email Id Already Registered. Please Login To Proceed ";
                    return;
                }
                else if (res > 0)
                {
                    GetDetails();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Member details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
            else
            {
                int result = MemberDetails.InsertMemberDetails(conMN, member);
                if (result == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Email Id Already Registered. Please check again ',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    //lblStatus.Text = "Email Id Already Registered. Please Login To Proceed ";
                    return;
                }
                else if (result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Member details Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    txtName.Text = txtAddress.Text = txtCity.Text = txtContactNo.Text = txtCountry.Text = txtEmail.Text = txtMedical.Text = txtPincode.Text = txtState.Text = "";
                    strGovtImage = strThumbImage = "";
                    ddlStatus.ClearSelection();
                    ddlPayStatus.ClearSelection();
                    ddlWho.ClearSelection();
                    var Wlink = WhatsappLink.GetAllWhatsappLink(conMN).FirstOrDefault().Wlink;
                    Emails.NewMembershipMail(member.FullName, member.EmailId, txtPwd.Text, Wlink);
                    Emails.NewMembershipMailAdmin(member.FullName, member.EmailId);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);

        }
    }

    public void GetDetails()
    {
        try
        {
            var details = MemberDetails.GetMemberDetailsByGuid(conMN, Request.QueryString["Id"]);
            if (details != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;

                cnfpwd.Visible = false;
                pwd.Visible = false;

                txtPwd.Visible = false;
                txtConfirm.Visible = false;

                txtName.Text = details.FullName;
                txtEmail.Text = details.EmailId;
                txtContactNo.Text = details.Contact;
                txtCountry.Text = details.Country;
                txtPwd.Text = details.Password;
                txtConfirm.Text = details.Password;
                txtMedical.Text = details.MedicalSchoolName;
                txtCity.Text = details.City;
                txtAddress.Text = details.Address;
                txtState.Text = details.State;
                txtPincode.Text = details.Pincode;
                ddlWho.SelectedIndex = ddlWho.Items.IndexOf(ddlWho.Items.FindByValue(details.WhoAreYou));
                ddlStatus.SelectedValue = details.Status;
                ddlPayStatus.SelectedValue = details.PaymentStatus;

                //txtspecify.Text = details.Specify;
                if (details.ProfileImage != "")
                {
                    strThumbImage = "<img src='/" + details.ProfileImage + "' style='max-height:60px;' class='w-100 rounded-circle wa-xs'/>";
                    lblThumb.Text = details.ProfileImage;
                }
                if (details.GovtID != "")
                {
                    strGovtImage = "<a href='/" + details.GovtID + @"'><img src='/img/pdfimg.png' style='max-height:60px;' class='img-fluid'/></a>";
                    lblGovt.Text = details.GovtID;
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-member.aspx", false);
    }





    private string CheckGovtIDFormat()
    {
        #region ThumbImage
        string GovtIdPDF = "";
        if (fuGovt.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(fuGovt.PostedFile.FileName.ToLower());
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
            if (fuGovt.HasFile)
            {
                string fileExtension = Path.GetExtension(fuGovt.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                fuGovt.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblGovt.Text;
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
        if (fuProfile.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(fuProfile.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
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
            if (fuProfile.HasFile)
            {
                string fileExtension = Path.GetExtension(fuProfile.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-sample".Replace(" ", "-").Replace(".", "");
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
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadProfileImage", eeex.Message);
                    return lblThumb.Text;
                }
                fuProfile.SaveAs(iconPath);
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


    public string UserID()
    {
        try
        {
            string Mem = MemberDetails.GetUserID(conMN);
            if (!string.IsNullOrEmpty(Mem))
            {
                int nextId = Convert.ToInt32(Mem.Replace("MRNUSER", "")) + 1;
                return String.Format("MRNUSER{0:D4}", nextId);
            }
            else
            {
                return "MRNUSER0001";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UserID", ex.Message);
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

public partial class plagiarism_report_request : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strPortfolio = "", strPdf = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
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

        }
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
    protected void btnPortfolio_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                PlagiarismRequest req = new PlagiarismRequest();

                req.Name = txtName.Text.Trim();
                req.ContactNumber = txtPhone.Text.Trim();
                req.EmailID = txtEmail.Text.Trim();
                req.FirstAuthorName = TexFirstAuthorName.Text.Trim();
                req.Title = txtTitle.Text.Trim(); // Note: You might want to rename txtTitle to txtTitle for clarity
                req.AddedIp = CommonModel.IPAddress();
                req.AddedOn = TimeStamps.UTCTime();
                req.Status = "Active";
                req.AddedBy = Request.Cookies["med_uid"].Value;

                int result = PlagiarismRequest.InsertPlagiarismRequest(conMN, req);
                if (result > 0)
                {
                    ClearFormFields();
                    System.Threading.Thread.Sleep(2000);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Plagiarism request added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnPortfolio_Click", ex.Message);
        }
    }

    // Helper method to clear form fields
    private void ClearFormFields()
    {
        txtName.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
        TexFirstAuthorName.Text = "";
        txtTitle.Text = "";
        txtLink.Text = ""; // If you still want to clear this field
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            Portfolio PD = new Portfolio();
            PD.Id = Convert.ToInt32(id);
            int exec = Portfolio.DeletePortfolio(conMN, PD);
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Cookies["med_uid"].Expires = TimeStamps.UTCTime().AddDays(-10);
            Response.Redirect("login.aspx");
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("my-portfolio.aspx");
    }
}
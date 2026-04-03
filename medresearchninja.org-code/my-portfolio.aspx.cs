using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class my_portfolio : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strPortfolio = "", strPdf="", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
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
            if (Request.QueryString["id"] != null)
            {
                GetPortfolio();
            }
            GetAllPortfolio();
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
                Portfolio pf = new Portfolio();
                if (btnPortfolio.Text == "Update")
                {
                    var rPath = CheckPDFFormat();
                    if (rPath == "Format")
                    {
                        lblpdf.Text = "Invalid PDF format.";
                        lblpdf.CssClass = "alert alert-danger d-block";
                        return;
                    }
                    pf.Title = txtTitle.Text.Trim();
                    pf.Link = txtLink.Text.Trim();
                    pf.ResourceType = ddlResourceType.SelectedValue;
                    pf.UploadPdf = UploadPDFPath();
                    pf.PaymentStatus = txtStatus.Text.Trim();
                    pf.Id = Convert.ToInt32(Request.QueryString["id"]);
                    pf.AddedIp = CommonModel.IPAddress();
                    pf.UpdatedOn = TimeStamps.UTCTime();
                    pf.Status = "Active";
                    
                    int result = Portfolio.UpdatePortfolio(conMN, pf);
                    if (result > 0)
                    {
                        GetAllPortfolio();
                        GetPortfolio();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Research Portfolio updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtTitle.Text = txtStatus.Text = "";
                        ddlResourceType.SelectedValue = "";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    var rPath = CheckPDFFormat();
                    if (rPath == "Format")
                    {
                        lblpdf.Text = "Invalid PDF format.";
                        lblpdf.CssClass = "alert alert-danger d-block";
                        return;
                    }
                    pf.Title = txtTitle.Text.Trim();
                    pf.Link = txtLink.Text.Trim();
                    pf.UploadPdf = UploadPDFPath();
                    pf.ResourceType = ddlResourceType.SelectedValue;
                    pf.PaymentStatus = txtStatus.Text.Trim();
                    pf.UserGuid = Request.Cookies["med_uid"].Value;
                    pf.Id = Convert.ToInt32(Request.QueryString["id"]);
                    pf.AddedIp = CommonModel.IPAddress();
                    pf.AddedOn = TimeStamps.UTCTime();
                    pf.Status = "Active";
                    pf.AddedBy = Request.Cookies["med_uid"].Value;
                    pf.UpdatedOn = TimeStamps.UTCTime();

                    int result = Portfolio.InsertPortfolio(conMN, pf);
                    if (result > 0)
                    {

                        txtTitle.Text = txtStatus.Text = "";
                        ddlResourceType.SelectedValue = "";
                        // lblStatus.Text = "<h5 class='alert alert-success d-block'>Research Portfolio Added succesfully</h5>";
                        //lblStatus.Text = "<h5 class='text-success'>Research Portfolio Added succesfully</h5>";
                        System.Threading.Thread.Sleep(2000);
                        GetAllPortfolio();
                        GetPortfolio();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Research Portfolio Added succesfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
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
    public void GetAllPortfolio()
    {
        try
        {
            strPortfolio = "";
            var UserGuid = Request.Cookies["med_uid"].Value;
            List<Portfolio> cas = Portfolio.GetAllPortfolio(conMN, UserGuid);
            if (cas != null && cas.Count>0) {
                int i = 0;
                foreach (Portfolio nb in cas)
                {
                    string url = !string.IsNullOrEmpty(nb.Link) ? nb.Link : nb.UploadPdf;
                    strPortfolio += @" <tr>
                                       <th scope='row'>
                                        <div class='freelancer-style1 p-0 mb-0 box-shadow-none'>
                                          <div class='d-lg-flex align-items-lg-center'>
                                           <div class='details'>
                                            <h5 class='title mb-2'>" + nb.Title + @"</h5></div></div></div>
                                         </th>
                                        <th>" + nb.UpdatedOn.ToString("dd/MMM/yyyy") + @"</th>
                                          <td class='vam'>
                                          <span class='pending-style style6'>" + nb.PaymentStatus + @"</span>
                                                </td>
                                           <td class='vam'><a href = '" + url + @"'  target='_blank'class='table-action fz15 fw500 text-thm2' data-bs-toggle='tooltip' data-bs-placement='top' title='' data-bs-original-title='View'><span class='flaticon-website me-2 vam'></span>View</a></td><td>
                                                    <div class='d-flex'>
                                                        <a href = 'my-portfolio.aspx?id=" + nb.Id + @"' data-id='" + nb.Id + @"' class='icon me-2' data-bs-toggle='tooltip' data-bs-placement='top' title='Edit' data-bs-original-title='Edit' aria-label='Edit'><span class='flaticon-pencil'></span></a>
                                                        <a href = 'javascript:void(0);' class='bs-tooltip fs-18 link-danger icon deleteItem' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title='' data-bs-original-title='Delete' aria-label='Delete'><span class='flaticon-delete'></span></a>
                                                    </div>
                                                </td>
                                            </tr>";
                    i++;
                }
            }
            else
            {
                strPortfolio = "<tr><td class='text-center' colspan='6'>No Data to display .</td></tr>";
            }
            
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllPortfolio", ex.Message);
        }
    }
    public void GetPortfolio()
    {
        try
        {
            Portfolio PD = Portfolio.GetPortfolio(conMN, Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
            if (PD != null)
            {

                btnPortfolio.Text = "Update";
                btnNew.Visible = true;
                txtTitle.Text = PD.Title;
                ddlResourceType.SelectedValue = PD.ResourceType;
                txtLink.Text = PD.Link;
             
                txtStatus.Text = PD.PaymentStatus;
                if (PD.UploadPdf != "")
                {
                    divpdf.Visible = true;
                    strPdf = PD.UploadPdf;
                }

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetPortfolio", ex.Message);
        }
    }
    private string CheckPDFFormat()
    {
        #region ThumbImage
        string pdf = "";
        if (upldPdf.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(upldPdf.PostedFile.FileName.ToLower());
                if (!(fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx"))
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

        return pdf;
    }
    public string UploadPDFPath()
    {
        #region upload file
        string PDFbfile = "";
        try
        {
            if (upldPdf.HasFile)
            {
                string fileExtension = Path.GetExtension(upldPdf.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                upldPdf.SaveAs(iconPath);
                PDFbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                PDFbfile = lblpdf.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadPDFPath", ex.Message);

        }

        #endregion

        return PDFbfile;
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
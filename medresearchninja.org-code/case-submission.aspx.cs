using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class case_submission : System.Web.UI.Page
{
    public SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnCasesubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                var rPath = CheckEvidence();
                if (rPath == "Format")

                {
                    lblEvidence.Text = "Invalid resume format.";
                    lblEvidence.CssClass = "alert alert-danger d-block";
                    return;
                }
                var CaseReports = new CaseReports()
                {
                    TitleOfCase = txtTitleOfCase.Text.Trim(),
                    CaseSummary = txtCaseSummary.Text.Trim(),
                    WhyRareOrReportable = txtRareOrReportable.Text.Trim(),
                    SubmittedByName = txtName.Text.Trim(),
                    SubmittedByContact = txtPhone.Text.Trim(),
                    SubmittedByAffiliation = txtAffiliation.Text.Trim(),
                    Evidence = UploadEvidenceDoc(),
                    AddedIp = CommonModel.IPAddress(),
                    AddedOn = TimeStamps.UTCTime(),
                    Status = "Active"
                };

                var result = CaseReports.InsertCaseReports(conMN, CaseReports);

                if (result > 0)
                {
                    //lblStatus.Text = "Submited successfully";
                    Response.Redirect("thank-you.aspx");
                    txtTitleOfCase.Text = txtCaseSummary.Text = txtRareOrReportable.Text = txtName.Text = txtPhone.Text = txtAffiliation.Text = "";
                }

                else
                {
                    lblStatus.Text = "There is some problem now. Please try after some time";
                    lblStatus.CssClass = "alert alert-danger d-block";
                }
            }
            catch (Exception ex)
            {

                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnCasesubmit_Click", ex.Message);
            }
        }
    }

    private string CheckEvidence()
    {
        #region Evidence 
        string Attach = "";
        if (UploadEvidence.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(UploadEvidence.PostedFile.FileName.ToLower());
                if ((fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".jpg" || fileExtension == ".png"))
                {
                    string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + fileExtension;
                }
                else
                {
                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckEvidence", ex.Message);

            }
        }
        #endregion
        return Attach;
    }
    public string UploadEvidenceDoc()
    {
        #region Evidence file
        string Evidencefile = "";
        try
        {
            if (UploadEvidence.HasFile)
            {
                string fileExtension = Path.GetExtension(UploadEvidence.PostedFile.FileName.ToLower());
                string ImageGuid1 = Guid.NewGuid().ToString() + fileExtension;
                string iconPath = Server.MapPath("~/UploadImages/") + ImageGuid1;

                try
                {

                    if (File.Exists(Server.MapPath("~/" + lblEvidence.Text)))
                    {
                        File.Delete(Server.MapPath("~/" + lblEvidence.Text));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadEvidenceDoc", eeex.Message);
                    return lblEvidence.Text;
                }

                UploadEvidence.SaveAs(iconPath);
                Evidencefile = "UploadImages/" + ImageGuid1;
            }
            else
            {
                Evidencefile = lblEvidence.Text;
            }
        }

        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadEvidenceDoc", ex.Message);
        }
        #endregion

        return Evidencefile;
    }


     protected void btnIdeasubmit_Click(object sender, EventArgs e)
     {
         try
         {
             var ResearchReports = new ResearchReports()
             {
                 ResearchTopic = txtResearchTitle.Text.Trim(),
                 Abstract = txtAbstract.Text.Trim(),
                 Objectives = txtResearchObjectives.Text.Trim(),
                 Background = txtBackground.Text.Trim(),
                 Methods = txtResearchMethods.Text.Trim(),
                 ExpectedOutcomes = txtExpectedOutcomes.Text.Trim(),
                 Reference = txtReferences.Text.Trim(),
                 Comments = txtComments.Text.Trim(),
                 SubmittedByName = txtResName.Text.Trim(),
                 SubmittedByContact = txtResPhone.Text.Trim(),
                 SubmittedByAffiliation = txtResAffiliation.Text.Trim(),
                 AddedIp = CommonModel.IPAddress(),
                 AddedOn = TimeStamps.UTCTime(),
                 Status = "Active"
             };

             var result = ResearchReports.InsertResearchReports(conMN, ResearchReports);

             if (result > 0)
             {
                 //lblStatus.Text = "Submited successfully";
                 Response.Redirect("thank-you.aspx");
                    txtResearchTitle.Text = txtAbstract.Text = txtResearchObjectives.Text = txtBackground.Text = txtResearchMethods.Text = txtExpectedOutcomes.Text = txtReferences.Text = txtComments.Text = txtResName.Text = txtResPhone.Text = txtResAffiliation.Text = "";


             }
            else
             {
                 lblStatus.Text = "There is some problem now. Please try after some time";
                 lblStatus.CssClass = "alert alert-danger d-block";
             }
         }
         catch (Exception ex)
         {

             ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnIdeasubmit_Click", ex.Message);

         }
     }

}
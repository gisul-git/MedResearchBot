using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class apply_job : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strJobTitle = "", strKeySkills = "", strPostedOn = "", strAddedOn = "", strRoleCategory = "", strRole = "", strIndustryType = "", strFunctionalArea = "", strExperienceYears = "", strJobLocation = "", strEducation = "", strPrev = "", strNext = "", strJobResponsibilities = "", strRequirements = "", strSalaryLPA = "", strEmploymentType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        var jdurl = Convert.ToString(RouteData.Values["jdurl"]);

        if (!string.IsNullOrEmpty(jdurl))
        {
            BindJobDescription(jdurl);
        }
    }
    private void BindJobDescription(string jdurl)
    {
        try
        {
            var Job = JobDetails.getJobDetailsByUrl(conMN, jdurl);
            if (Job != null)
            {
                #region SEO
                if (!string.IsNullOrEmpty(Job.PageTitle))
                {
                    Page.Title = Job.PageTitle;
                }
                else
                {
                    Page.Title = Job.JobTitle + " | MedResearchNinja";
                }
                if (!string.IsNullOrEmpty(Job.MetaDesc))
                {
                    Page.MetaDescription = Job.MetaDesc;
                }
                if (!string.IsNullOrEmpty(Job.MetaKeys))
                {
                    Page.MetaKeywords = Job.MetaKeys;
                }
                #endregion

                strJobTitle = Job.JobTitle;

                strPostedOn = Job.PostedOn.ToString("MMMM dd");
                strAddedOn = Job.AddedOn.ToString("MMMM dd");
                strKeySkills = Job.KeySkills;
                strRole = Job.Role;
                strIndustryType = Job.IndustryType;
                strExperienceYears = Job.ExperienceYears;
                strJobLocation = Job.JobLocation;   
                strEducation = Job.Education;
                strJobResponsibilities += @"<p class='mb-0 p-2'>" + Job.JobResponsibilities + @"</p>";
                strRequirements += @"<p class='mb-0 p-2'>" + Job.Requirements + @"</p>"; 
                strFunctionalArea = Job.FunctionalArea;
                strSalaryLPA = Job.Salary.ToString();
                strEmploymentType = Job.EmploymentType;
                strRoleCategory = Job.RoleCategory;
                txtJobId.Value = Job.Id.ToString();
                txtJobTitle.Value = Job.JobTitle;


            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindJobDescription", ex.Message);
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            var rPath = CheckResumeFormat();
            if (rPath == "Format")
            {
                lblStatus.Text = "Invalid resume format.";
                lblStatus.CssClass = "alert alert-danger d-block";
                return;
            }

            var Applyjobs = new Applyjobs()
            {
                FullName = txtFullName.Text.Trim(),
                EmailId = txtEmailId.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim(),
                Experience = txtExperience.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                CurrentSalary = txtCurrentSalary.Text.Trim(),
                ExpectedSalary = txtExpectedSalary.Text.Trim(),
                ResumePath = UploadResumes(),
                NoticePeriod = ddlNoticePeriod.Text.Trim(),
                JobId = txtJobId.Value == "" ? 0 : Convert.ToInt32(txtJobId.Value),
                JobTitle = txtJobTitle.Value.Trim(),
                AddedIP = CommonModel.IPAddress(),
                AddedOn = TimeStamps.UTCTime(),
                JobType = ddlJobType.SelectedValue,
                Pageurl = HttpContext.Current.Request.Url.AbsoluteUri.ToString(),
                Status = "Active"

            };

            var result = Applyjobs.InsertApplyjobs(conMN, Applyjobs);
        
               
                if (result > 0)
                {
                lblStatus.Text = "Job applied Succefully, our team will reach out to you soon!";
                lblStatus.CssClass = "alert alert-success d-block";
                string Pageurl = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
                MailMessage mail = new MailMessage();
                mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CCMail"]))
                {
                    mail.CC.Add(ConfigurationManager.AppSettings["CCMail"]);
                }
                string path = HttpContext.Current.Server.MapPath(@"\" + Applyjobs.ResumePath + "");
                Attachment attachment = new Attachment(path);
                mail.Attachments.Add(attachment);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
                    mail.Subject = "Job Application - Med Research Ninja";
                    mail.Body = @"Hi Admin, <br><br>You have received a Job Application from " + txtFullName.Text + ".<br><br>" +
                        "<u><b><i>Application Details : </i></b></u>" +
                        "<br>First Name : " + txtFullName.Text + "" +
                        "<br>Email : " + txtEmailId.Text + "" +
                        "<br>City : " + txtContactNumber.Text + "" +
                        "<br>Experience: " + txtExperience.Text + "" +
                        "<br>Location: " + txtLocation.Text + "" +
                        "<br>Expected Salary: " + txtExpectedSalary.Text + "" +
                        "<br>Current Salary: " + txtCurrentSalary.Text + "" +
                        "<br>Job Title: " + txtJobTitle.Value + "" +
                        "<br>JobType : " + ddlJobType.SelectedItem.Value + "" +
                        "<br>PageURL : <a href='"+Pageurl+"'>" + Pageurl + "</a>" +
                        "<br><br>Regards,<br> Med Research Ninja";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["host"];
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                    smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

                    smtp.Send(mail);
                lblStatus.Text = "true";
                txtExperience.Text = txtFullName.Text = txtEmailId.Text = txtContactNumber.Text = txtLocation.Text = txtCurrentSalary.Text = txtExpectedSalary.Text = "";
                lblStatus.Text = "Job applied successfully";
                    //Response.Redirect("thank-you.aspx");

                }
            else
            {
                lblStatus.Text = "There is some problem now. Please try after some time";
                lblStatus.CssClass = "alert alert-danger d-block";
            }
        }
        catch (Exception ex)
        {
    
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadResumePath", ex.Message);

        }
    }
    private string CheckResumeFormat()
    {
        #region resumeFormat
        string resume = "";
        if (UploadResume.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(UploadResume.PostedFile.FileName.ToLower());
                if ((fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx"))
                {
                    string iconPath = Server.MapPath(".") + "\\../Uploadpdf\\" + fileExtension;
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
        return resume;
    }
    public string UploadResumes()
    {
        #region upload file
        string thumbfile = "";
        try
        {
            if (UploadResume.HasFile)
            {
                string fileExtension = Path.GetExtension(UploadResume.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                UploadResume.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblResume.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadResume", ex.Message);

        }

        #endregion
        return thumbfile;
    }

}
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_add_new_job : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BindJobDetails();
            }
        }
    }

    public void BindJobDetails()
    {
        try
        {
            var job = JobDetails.GetJobDetailsById(conMN, Convert.ToInt32(Request.QueryString["id"]));
            if (job != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtName.Text = job.JobTitle;
                ddlJobType.SelectedValue = job.JobType;
                txtUrl.Text = job.JobUrl;
                txtMetaDesc.Text = job.MetaDesc;
                txtEmpType.Text = job.EmploymentType;
                txtPostedOn.Text = job.PostedOn.ToString("dd MMM yyyy");
                txtMetaKey.Text = job.MetaKeys;
                txtResponsibilities.Text = job.JobResponsibilities;
                txtPageTitle.Text = job.PageTitle;
                txtEducation.Text = job.Education;
                txtIndustryType.Text = job.IndustryType;
                txtKeySkills.Text = job.KeySkills;
                txtRole.Text = job.Role;
                txtLocation.Text = job.JobLocation;
                txtExp.Text = job.ExperienceYears;
                txtSalary.Text = job.Salary;
                txtRequirements.Text = job.Requirements;

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindJobDetails", ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                var aid = Request.Cookies["med_aid"].Value;

                JobDetails job = new JobDetails();

                job.JobType=ddlJobType.SelectedValue;
                job.JobTitle = txtName.Text.Trim();
                job.FunctionalArea = txtFunctionalArea.Text.Trim();
                job.RoleCategory = txtRoleCat.Text.Trim();
                job.JobUrl = txtUrl.Text.Trim();
                job.EmploymentType = txtEmpType.Text.Trim();
                job.PostedOn = Convert.ToDateTime(txtPostedOn.Text.Trim());
                job.JobResponsibilities = txtResponsibilities.Text.Trim();
                job.MetaDesc = txtMetaDesc.Text.Trim();
                job.MetaKeys = txtMetaKey.Text.Trim();
                job.PageTitle = txtPageTitle.Text.Trim();
                job.Education = txtEducation.Text.Trim();
                job.IndustryType = txtIndustryType.Text.Trim();
                job.KeySkills = txtKeySkills.Text.Trim();
                job.Role = txtRole.Text.Trim();
                job.JobLocation = txtLocation.Text.Trim();
                job.ExperienceYears = txtExp.Text.Trim();
                job.Salary = txtSalary.Text.Trim();
                job.AddedIP = CommonModel.IPAddress();
                job.AddedOn = TimeStamps.UTCTime();
                job.AddedBy = aid;
                job.Requirements = txtRequirements.Text.Trim();



                if (btnSave.Text == "Update")
                {
                    job.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = JobDetails.UpdateJobDetails(conMN, job);
                    if (result > 0)
                    {
                        BindJobDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Job Details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = JobDetails.InsertJobDetails(conMN, job);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Job Details Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtName.Text = txtUrl.Text = txtMetaDesc.Text = txtEmpType.Text = txtPostedOn.Text = txtMetaKey.Text = txtResponsibilities.Text = txtPageTitle.Text = txtEducation.Text = txtIndustryType.Text = txtKeySkills.Text = txtRole.Text = txtLocation.Text = txtExp.Text = txtSalary.Text = txtRequirements.Text = txtRoleCat.Text = txtFunctionalArea.Text = "";
                        ddlJobType.SelectedIndex = 0;
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

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-new-job.aspx", false);
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_write_projects : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTags();
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BindProjectsDetails();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        try
        {
            if (Page.IsValid)
            {
                Projects pr = new Projects();
                if (btnSave.Text == "Update")
                {
                    pr.ProjectId = pr.ProjectId;
                    pr.Id = Convert.ToInt32(Request.QueryString["id"]);
                    pr.ProjectName = txtProjectName.Text.Trim();
                    pr.ProjectLink = txtProjectLink.Text.Trim();
                    pr.ProjectGuid = pr.ProjectGuid;
                    pr.Tags = SaveTags().ToString();
                    pr.StartDate = txtStart.Text;
                    pr.Subject = txtSubject.Text.Trim();
                    pr.PostedOn = Convert.ToDateTime(txtPostedOn.Text.Trim());
                    pr.ShortDesc = txtShortDesc.Text.Trim();
                    pr.MaxCollab = txtMaxColCount.Text.Trim();
                    pr.PriceINR = txtPriceINR.Text.Trim();
                    pr.PriceOther = txtPriceOther.Text.Trim();
                    pr.AddedIp = CommonModel.IPAddress();
                    pr.AddedOn = TimeStamps.UTCTime();
                    pr.Status = "Active";
                    pr.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = Projects.UpdateProjects(conMN, pr);
                    if (result > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Project updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {

                    pr.Id = Convert.ToInt32(Request.QueryString["id"]);
                    pr.ProjectId = ProjectID();
                    pr.ProjectName = txtProjectName.Text.Trim();
                    pr.ProjectGuid = Guid.NewGuid().ToString();
                    pr.ProjectLink = txtProjectLink.Text.Trim();
                    pr.Tags = SaveTags().ToString();
                    pr.Subject = txtSubject.Text.Trim();
                    pr.StartDate = txtStart.Text;
                    pr.PostedOn = Convert.ToDateTime(txtPostedOn.Text.Trim());
                    pr.ShortDesc = txtShortDesc.Text.Trim();
                    pr.MaxCollab = txtMaxColCount.Text.Trim();
                    pr.PriceINR = txtPriceINR.Text.Trim();
                    pr.PriceOther = txtPriceOther.Text.Trim();
                    pr.AddedIp = CommonModel.IPAddress();
                    pr.AddedOn = TimeStamps.UTCTime();
                    pr.Status = "Active";
                    pr.AddedBy = Request.Cookies["med_aid"].Value;

                    int result = Projects.InsertProjects(conMN, pr);
                    if (result > 0)
                    {
                        txtProjectName.Text = txtProjectLink.Text = txtSubject.Text = txtPostedOn.Text = txtShortDesc.Text = txtMaxColCount.Text = txtPriceINR.Text = txtPriceOther.Text = "";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Project added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);

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

    public void GetTags(string tags)
    {
        try
        {
            foreach (string str in tags.Split('|'))
            {
                foreach (ListItem li in ddlTags.Items)
                {
                    if (str.Trim() == li.Value.Trim())
                    {
                        li.Selected = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTags", ex.Message);
        }
    }

    public void BindTags()
    {
        try
        {
            List<ProjectTags> sub = ProjectTags.GetAllTags(conMN);
            ddlTags.Items.Clear();
            if (sub.Count > 0)
            {
                ddlTags.DataSource = sub;
                ddlTags.DataValueField = "TagTitle";
                ddlTags.DataTextField = "TagTitle";
                ddlTags.DataBind();

            }
            //ddlTags.Items.Insert(0, new ListItem("Select Tags", "0"));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTags", ex.Message);

        }
    }
    public string SaveTags()
    {
        string x = "";
        try
        {

            foreach (ListItem li in ddlTags.Items)
            {
                if (li.Selected)
                {
                    x += li.Text + "|";
                }

            }
            x = x.TrimEnd('|');

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SaveTags", ex.Message);

        }
        return x;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Write-projects.aspx");
    }

    public void BindProjectsDetails()
    {
        try
        {
            var proj = Projects.GetProjectsDetailsById(conMN, Convert.ToInt32(Request.QueryString["id"]));
            if (proj != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtProjectName.Text = proj.ProjectName;
                GetTags(proj.Tags);
                txtProjectLink.Text = proj.ProjectLink;
                txtSubject.Text = proj.Subject;
                txtStart.Text = proj.StartDate;
                txtPostedOn.Text = proj.PostedOn.ToString("dd mm yyyy HH m K");
                txtShortDesc.Text = proj.ShortDesc;
                txtMaxColCount.Text = proj.MaxCollab;
                txtPriceINR.Text = proj.PriceINR;
                txtPriceOther.Text = proj.PriceOther;


            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindProjectsDetails", ex.Message);
        }
    }
    public string ProjectID()
    {
        try
        {
            var proj = Projects.GetProjectId(conMN);
            if (!string.IsNullOrEmpty(proj))
            {
                int nextId = Convert.ToInt32(proj.Replace("MRNP", "")) + 1;
                return String.Format("MRNP{0:D4}", nextId);
            }
            else
            {

                return "MRNP0000";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ProjectID", ex.Message);
            return null;
        }
    }


}

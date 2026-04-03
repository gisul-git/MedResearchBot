using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_add_modules : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BindModuleDetails();
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
                Modules module = new Modules();
                module.ModuleName = txtModuleName.Text.Trim();
                module.ModuleType = ddlModuleType.SelectedValue;
                module.FullDesc = txtFullDesc.Text.Trim();
                module.AddedIp = CommonModel.IPAddress();
                module.UpdatedIp = CommonModel.IPAddress();
                module.AddedOn = TimeStamps.UTCTime();
                module.UpdatedOn = TimeStamps.UTCTime();
                module.Status = "Active";
                module.AddedBy = Request.Cookies["med_aid"].Value;
                if (module.ModuleType == "Text Content")
                {
                    module.TextContent = txtTextContent.Text.Trim();
                    module.videolink = ""; 
                }
                else if (module.ModuleType == "YouTube Video" || module.ModuleType == "Our Video")
                {
                    module.videolink = txtVideoLink.Text.Trim();
                    module.TextContent = ""; 
                }

                if (btnSave.Text == "Update")
                {
                    module.Id = Convert.ToInt32(Request.QueryString["id"]);

                    int result = Modules.UpdateModules(conMN, module);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message",
                            "Snackbar.show({pos: 'top-right',text: 'Module updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message",
                            "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                { 
                    int result = Modules.InsertModules(conMN, module);
                    if (result > 0)
                    {
                        txtModuleName.Text = "";
                        txtVideoLink.Text = "";
                        txtTextContent.Text = "";
                        txtFullDesc.Text = "";
                        ddlModuleType.SelectedValue = "Text Content"; // Reset to default
                        UpdateFieldVisibility();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message",
                            "Snackbar.show({pos: 'top-right',text: 'Module added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message",
                            "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message",
                "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }

 
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-modules.aspx");
    }

    public void BindModuleDetails()
    {
        try
        {
            int moduleId = Convert.ToInt32(Request.QueryString["id"]);
            var module = Modules.GetModulesDetailsById(conMN, moduleId);

            if (module != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;

                txtModuleName.Text = module.ModuleName;
                ddlModuleType.SelectedValue = module.ModuleType;
                txtFullDesc.Text = module.FullDesc;

                // Set type-specific fields based on module type
                if (module.ModuleType == "Text Content")
                {
                    txtTextContent.Text = module.TextContent;
                }
                else if (module.ModuleType == "YouTube Video" || module.ModuleType == "Our Video")
                {
                    txtVideoLink.Text = module.videolink;
                }

                // Update field visibility based on module type
                UpdateFieldVisibility();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindModuleDetails", ex.Message);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage-modules.aspx");
    }

    protected void ddlModuleType_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateFieldVisibility();

        // Clear the non-visible field
        string selectedType = ddlModuleType.SelectedValue;
        if (selectedType == "Text Content")
        {
            txtVideoLink.Text = "";
        }
        else if (selectedType == "YouTube Video" || selectedType == "Our Video")
        {
            txtTextContent.Text = "";
        }
    }

    private void UpdateFieldVisibility()
    {
        string selectedType = ddlModuleType.SelectedValue;

        // Update RequiredFieldValidator enable/disable state
        rfvTextContent.Enabled = (selectedType == "Text Content");
        rfvVideoLink.Enabled = (selectedType == "YouTube Video" || selectedType == "Our Video");

        // Show/hide fields using CSS classes (handled by JavaScript in UI)
        // The actual visibility is controlled by JavaScript in the ASPX page
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_add_whatsapp_link : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckWhatsappExist();
        }
    }

    public void CheckWhatsappExist()
    {
        var wlink = WhatsappLink.GetAllWhatsappLink(conMN).FirstOrDefault();
        if (wlink != null)
        {
            BtnSave.Text = "Update";
            txtLink.Text = wlink.Wlink.ToString();
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                var aid = Request.Cookies["med_aid"].Value;
                var Wlink = new WhatsappLink()
                {
                    AddedIP = CommonModel.IPAddress(),
                    AddedBy = aid,
                    AddedOn = TimeStamps.UTCTime(),
                    Status = "Active",
                    Wlink = txtLink.Text
                };
                if (BtnSave.Text == "Update")
                {
                    var exe = WhatsappLink.UpdateWhatsappLink(conMN, Wlink);
                    if (exe > 0)
                    {
                        CheckWhatsappExist();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Link Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    var result = WhatsappLink.InsertWhatsappLink(conMN, Wlink);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Link Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        CheckWhatsappExist();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BtnSave_Click", ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage_FAQ : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strFAQs = "<tr><td colspan='4' class='text-center'>No data to show.</td></tr>";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Pid"] != null)
        {
            if (!IsPostBack)
            {
                BindFaqList();
                if (Request.QueryString["id"] != null)
                {
                    BindFaq();
                }
            }
        }
        else
        {
            //Response.Redirect("/404", false);
        }

    }


    public void BindFaq()
    {
        try
        {
            var id = Request.QueryString["id"] == "" ? 0 : Convert.ToInt32(Request.QueryString["id"].ToString());
            var Faq = FaqDetails.GetAllFaqDetailsWithId(conSQ, id);
            if (Faq != null)
            {
                btnSave.Text = "Update";
                btnClear.Visible = true;
                txtQuestion.Text = Faq.FAQQuestion.ToString();
                txtDesc.Text = Faq.FAQAnswer.ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindFaq", ex.Message);
        }
    }
    public void BindFaqList()
    {
        try
        {
            strFAQs = "/";
            var list = FaqDetails.GetAllFaqDetails(conSQ, Request.QueryString["Pid"]);
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    strFAQs += @"<tr>
                            <td>" + (i + 1) + @"</td>
                            <td>" + list[i].FAQQuestion + @"</td>
                            <td><a href='javascript:void:(0);' data-bs-toggle='tooltip' data-placement='top' title='Added By : " + list[i].AddedBy + @"' >" + list[i].AddedOn.ToString("dd/MMM/yyyy") + @"</a></td>
                            <td class='text-center'>
                                <a href='manage-faq.aspx?id=" + list[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + list[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                   <i class='mdi mdi-pencil'></i></a>
                                <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + list[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                   <i class='mdi mdi-delete-forever'></i></a>
                            </td>
                        </tr>";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindFaqList", ex.Message);

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Manage-FAQ.aspx?Pid=" + Request.QueryString["Pid"].ToString(), false);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnClear_Click", ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string pageName = Path.GetFileName(Request.Path);

        if (Page.IsValid)
        {


            FaqDetails faq = new FaqDetails();

            faq.FAQQuestion = txtQuestion.Text.Trim();
            faq.FAQAnswer = txtDesc.Text;

            string aid = Request.Cookies["med_aid"].Value;
            if (btnSave.Text == "Update")
            {
                faq.Id = Convert.ToInt32(Request.QueryString["id"]);
                int result = FaqDetails.UpdateFaq(conSQ, faq);
                if (result > 0)
                {
                    BindFaq();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Faq details updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
            else
            {
                faq.Status = "Active";
                faq.AddedBy = aid;
                faq.AddedIp = CommonModel.IPAddress();
                faq.AddedOn = TimeStamps.UTCTime();
                int result = FaqDetails.InsertFaq(conSQ, faq);
                if (result > 0)
                {
                    txtQuestion.Text = txtDesc.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Faq details added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
            BindFaqList();
        }

    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conGV = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            FaqDetails BD = new FaqDetails();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();
            BD.AddedIp = CommonModel.IPAddress();
            int exec = FaqDetails.DeleteFaq(conGV, BD);
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
}
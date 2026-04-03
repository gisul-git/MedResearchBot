using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Management;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class resources : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrResources = "", strPDF = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        BindResources();


    }
    public void BindResources()
    {
        try
        {
            List<ManageResources> res = ManageResources.BindResources(conMN);

            for (int i = 0; i < res.Count; i++)
            {
                var pdf = res[i].PDFFile;

                StrResources += @"<div class='col-sm-6 col-xl-3'>
                    <div class='blog-style1 at-home7 bdr1'>
                        <div class='blog-img'>
 			<img class='w-100' src='/" + res[i].ThumbImage + @"' alt='blog" + i + @"'/>
                        </div>
                        <div class='blog-content'>
                            <a class='date' href='#'>" + res[i].Category + @"</a>
                            <h4 class='title mt-3 mb-4'><a href='#l'>" + res[i].ProjectTitle + @"</a></h4>
                            <a href='javascript:void(0)';  data-id='" + res[i].Id + @"' class='ud-btn1 btn-white2 double-border bdrs4 hidenId' data-bs-target='#exampleModal' data-bs-toggle='modal'>Download<i class='fa-solid fa-cloud-arrow-down'></i></a>
                        </div>
                    </div>
                </div> ";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindNoticeBoard", ex.Message);
        }
    }

    /* protected void BtnDownload_Click(object sender, EventArgs e)
     {
         try
         {
             ResourcesEnguiry RE = new ResourcesEnguiry();

             var ResName = ResourcesEnguiry.GetResName(conMN, spndownid.InnerText);
             var ResPDF = ResourcesEnguiry.GetResPDF(conMN, spndownid.InnerText);

             RE.FullName = textFname.Text.Trim();
             RE.ResourceName = ResName.ToString();
             RE.Email = txtemailAdress.Text.Trim();
             RE.Contact = txtContact.Text.Trim();
             RE.AddedIP = CommonModel.IPAddress();
             RE.AddedOn = TimeStamps.UTCTime();
             RE.Status = "Active";
             RE.AddedBy = Request.Cookies["med_uid"].Value;
             int result = ResourcesEnguiry.InsertResourcesEnguiry(conMN, RE);

             if (result > 0)
             {
                 strPDF = ResPDF;
             }
             else
             {
                 //lblStatus.Text = "There is some problem now. Please try after some time.";
                 //lblStatus.Attributes.Add("class", "alert alert-danger");
             }
         }
         catch (Exception ex)
         {
             ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnDownload_Click", ex.Message);
         }
     }*/


    [WebMethod(EnableSession = true)]
    public static string SaveDownloadEnquiry(string name, string email, string contact, int Id)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

        try
        {
            ResourcesEnguiry RE = new ResourcesEnguiry();

            var ResName = ResourcesEnguiry.GetResName(conMN, Id);
            var ResPDF = ResourcesEnguiry.GetResPDF(conMN, Id);

            RE.FullName = name;
            RE.ResourceName = ResName;
            RE.Email = email;
            RE.Contact = contact;
            RE.AddedIP = CommonModel.IPAddress();
            RE.AddedOn = TimeStamps.UTCTime();
            RE.Status = "Active";
            RE.AddedBy = "";
            int result = ResourcesEnguiry.InsertResourcesEnguiry(conMN, RE);

            if (result > 0)
            {

                return "Success | " + ResPDF;
            }
            else
            {
                return "Error";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SaveDownloadEnquiry", ex.Message);
            return "Error";
        }
    }




    /*public void GetCategoryDDL()
    {
        try
        {
            List<ResourcesCategory> RC = ResourcesCategory.GetCategoryDDL(conMN);
            if (RC.Count > 0)
            {
                ddlCategory.DataSource = RC;
                ddlCategory.DataValueField = "AddCategory";
                ddlCategory.DataTextField = "AddCategory";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCategoryDDL", ex.Message);
        }
    }*/
}
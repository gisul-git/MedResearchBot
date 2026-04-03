using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class submit_an_article : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAuthorGuid.Value = Guid.NewGuid().ToString();
    }




    /* protected void SubmitArticle(List<CoAuthor> coAuthors)
     {
         SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
         try
         {
             var authorGuid = Guid.NewGuid().ToString();


             var article = new Articles()
             {
                 AuthorFullName = txtAuthFullName.Text.Trim(),
                 AuthorGuid = authorGuid,
                 AuthorPosition = txtAuthTitle.Text.Trim(),
                 AuthorAffiliation = txtAuthAffiliation.Text.Trim(),
                 AuthorEmailId = txtAuthEmail.Text.Trim(),
                 AuthorPhoneNo = txtAuthPhone.Text.Trim(),
                 ArticleTitle = txtArticleTitle.Text.Trim(),
                 ArticleAbstract = txtAbstract.Text.Trim(),
                 ArticleKeywords = txtKeywords.Text.Trim(),
                 ArticleType = ddlArticleType.SelectedValue,
                 ArticleWordCount = txtWordCount.Text.Trim(),
                 ArticleTables = txtFigures.Text.Trim(),
                 ArticleAnyOtherJournal = RadioButtonList1.SelectedItem.Text,
                 ArticlePublishedWork = rabioBtnPublishedWorkCheck.SelectedItem.Text,
                 ArticlePrevPublishedWork = txtPublishWork.Text.Trim(),
                 ArticlePrevPublishedddl = ddlPrevPublishedWork.SelectedValue,
                 InterestToDeclare = rabioBtnInterestAndFunding.SelectedItem.Text,
                 DescInterestToDeclare = DescInterestAndFunding.Text.Trim(),
                 Organization = rabioBtnOrganization.SelectedItem.Text,
                 DescOrganization = DescOrganization.Text.Trim(),
                 Acknowledgments = DescAcknowledgment.Text.Trim(),
                 EthicalCompliance = rabioBtnReserach.SelectedItem.Text,
                 DescEthicalCompliance = DescEthicalCompliance.Text.Trim(),
                 // AttachManuscript = UploadAttach(), 
                 // AttachSupplementoryManuscript = UploadSupplimentAttach(),
                 Signature = txtSignature.Text.Trim(),
                 Date = txtDate.Text,
                 ContactInfoName = txtConName.Text.Trim(),
                 ContactInfoEmailId = txtConEmail.Text.Trim(),
                 ContactInfoPhoneNo = txtConPhone.Text.Trim(),
                 AddedOn = TimeStamps.UTCTime(),
                 AddedIP = CommonModel.IPAddress(),
                 Status = "Active",
                 PageURL = HttpContext.Current.Request.Url.AbsoluteUri,
                 CoAuthorFullName = "",
                 CoAuthorPosition = "",
                 CoAuthorAffiliation = "",
                 CoAuthorEmailId = "",



             };

             var articleResult = Articles.InsertArticles(conMN, article);
             var coAuthorsList = new List<CoAuthor>();
             foreach (var coAuthor in coAuthors)
             {
                 var coAuthorEntry = new CoAuthor()
                 {
                     CoAuthorFullName = coAuthor.CoAuthorFullName,
                     AuthorGuid = authorGuid,
                     CoAuthorPosition = coAuthor.CoAuthorPosition,
                     CoAuthorAffiliation = coAuthor.CoAuthorAffiliation,
                     CoAuthorEmailId = coAuthor.CoAuthorEmailId,
                     AddedOn = TimeStamps.UTCTime(),
                     AddedIp = CommonModel.IPAddress(),
                     Status = "Active"
                 };

                 Articles.InsertCoAuthors(conMN, coAuthorEntry);
             }

             if (articleResult > 0)
             {
                  HttpContext.Current.Response.Redirect("/thank-you.aspx");
             }
         }
         catch (Exception ex)
         {
             ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SubmitArticle", ex.Message);
         }
     }

 */
    [WebMethod(EnableSession = true)]
    public static string SubmitArticle(Articles Articles)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        if (Articles != null)
        {
            try
            {
                var article = new Articles()
                {
                    AuthorFullName = Articles.AuthorFullName,
                    AuthorGuid = Articles.AuthorGuid,
                    AuthorPosition = Articles.AuthorPosition,
                    AuthorAffiliation = Articles.AuthorAffiliation,
                    AuthorEmailId = Articles.AuthorEmailId,
                    AuthorPhoneNo = Articles.AuthorPhoneNo,
                    ArticleTitle = Articles.ArticleTitle,
                    ArticleAbstract = Articles.ArticleAbstract,
                    ArticleKeywords = Articles.ArticleKeywords,
                    ArticleType = Articles.ArticleType,
                    ArticleWordCount = Articles.ArticleWordCount,
                    ArticleTables = Articles.ArticleTables,
                    ArticleAnyOtherJournal = Articles.ArticleAnyOtherJournal,
                    ArticlePublishedWork = Articles.ArticlePublishedWork,
                    ArticlePrevPublishedWork = Articles.ArticlePrevPublishedWork,
                    ArticlePrevPublishedddl = Articles.ArticlePrevPublishedddl,
                    InterestToDeclare = Articles.InterestToDeclare,
                    DescInterestToDeclare = Articles.DescInterestToDeclare,
                    Organization = Articles.Organization,
                    DescOrganization = Articles.DescOrganization,
                    Acknowledgments = Articles.Acknowledgments,
                    EthicalCompliance = Articles.EthicalCompliance,
                    DescEthicalCompliance = Articles.DescEthicalCompliance,
                    Signature = Articles.Signature,
                    Date = Articles.Date,
                    ContactInfoName = Articles.ContactInfoName,
                    ContactInfoEmailId = Articles.ContactInfoEmailId,
                    ContactInfoPhoneNo = Articles.ContactInfoPhoneNo,
                    AddedOn = TimeStamps.UTCTime(),
                    AddedIp = CommonModel.IPAddress(),
                    Status = "Active",
                    PageURL = HttpContext.Current.Request.Url.AbsoluteUri,
                    CoAuthorFullName = "",
                    CoAuthorPosition = "",
                    CoAuthorAffiliation = "",
                    CoAuthorEmailId = "",
                    AttachSupplementoryManuscript = "",
                    AttachManuscript = ""
                };

                var articleResult = Articles.InsertArticles(conMN, Articles);
                if (articleResult > 0)
                {
                    foreach (var coAuthor in Articles.CoAuthors)
                    {
                        var coAuthorEntry = new CoAuthorData
                        {
                            CoAuthorFullName = coAuthor.CoAuthorFullName,
                            AuthorGuid = Articles.AuthorGuid,
                            CoAuthorGuid = Guid.NewGuid().ToString(),
                            CoAuthorPosition = coAuthor.CoAuthorPosition,
                            CoAuthorAffiliation = coAuthor.CoAuthorAffiliation,
                            CoAuthorEmailId = coAuthor.CoAuthorEmailId,
                            AddedOn = TimeStamps.UTCTime(),
                            Status = "Active"
                        };

                        var exe = Articles.InsertCoAuthors(conMN, coAuthorEntry);
                        if (exe < 1)
                        {
                            return "Error";
                        }

                    }
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SubmitArticle", ex.Message);
            }
            return "Error";
        }
        return "Error";
    }



    /* protected void btnsubmit_Click(object sender, EventArgs e)
     {
         if (Page.IsValid)
         {
             try
             {
                 var attach = CheckAttach();
                 if (attach == "Format")
                 {
                     lblStatus.Text = "Invalid Attach format.";
                     lblStatus.CssClass = "alert alert-danger d-block";
                     return;
                 }
                 var Supattach = CheckSupplimentAttach();
                 if (Supattach == "Format")
                 {
                     lblStatus.Text = "Invalid Attach format.";
                     lblStatus.CssClass = "alert alert-danger d-block";
                     return;
                 }
                 var authorGuid = Guid.NewGuid().ToString();
                 var Articles = new Articles()
                 {
                     AuthorFullName = txtAuthFullName.Text.Trim(),
                     AuthorGuid = authorGuid,

                     AuthorPosition = txtAuthTitle.Text.Trim(),
                     AuthorAffiliation = txtAuthAffiliation.Text.Trim(),
                     AuthorEmailId = txtAuthEmail.Text.Trim(),
                     AuthorPhoneNo = txtAuthPhone.Text.Trim(),
                     ArticleTitle = txtArticleTitle.Text.Trim(),
                     ArticleAbstract = txtAbstract.Text.Trim(),
                     ArticleKeywords = txtKeywords.Text.Trim(),
                     ArticleType = ddlArticleType.SelectedValue,
                     ArticleWordCount = txtWordCount.Text.Trim(),
                     ArticleTables = txtFigures.Text.Trim(),
                     ArticleAnyOtherJournal = RadioButtonList1.SelectedItem.Text,
                     ArticlePublishedWork = rabioBtnPublishedWorkCheck.SelectedItem.Text,
                     ArticlePrevPublishedWork = txtPublishWork.Text.Trim(),
                     ArticlePrevPublishedddl = ddlPrevPublishedWork.SelectedValue,
                     InterestToDeclare = rabioBtnInterestAndFunding.SelectedItem.Text,
                     DescInterestToDeclare = DescInterestAndFunding.Text.Trim(),
                     Organization = rabioBtnOrganization.SelectedItem.Text,
                     DescOrganization = DescOrganization.Text.Trim(),
                     Acknowledgments = DescAcknowledgment.Text.Trim(),
                     EthicalCompliance = rabioBtnReserach.SelectedItem.Text,
                     DescEthicalCompliance = DescEthicalCompliance.Text.Trim(),
                     AttachManuscript = UploadAttach(),
                     AttachSupplementoryManuscript = UploadSupplimentAttach(),
                     Signature = txtSignature.Text.Trim(),
                     Date = txtDate.Text,
                     ContactInfoName = txtConName.Text.Trim(),
                     ContactInfoEmailId = txtConEmail.Text.Trim(),
                     ContactInfoPhoneNo = txtConPhone.Text.Trim(),
                     AddedOn  = TimeStamps.UTCTime(),
                     AddedIP = CommonModel.IPAddress(),
                     Status  = "Active",
                     PageURL = HttpContext.Current.Request.Url.AbsoluteUri, 

                 };

                 var exe = Articles.InsertArticles(conMN, Articles);
                 //co-author data store to coauthor table
                 var CoAuthours = new CoAuthors()
                 {
                     CoAuthorFullName = txtCoAuthFullName.Text.Trim(),
                     AuthorGuid = authorGuid,//common for both table 
                     CoAuthorPosition = txtCoAuthTitle.Text.Trim(),
                     CoAuthorAffiliation = txtCoAuthAffiliation.Text.Trim(),
                     CoAuthorEmailId = txtCoAuthEmail.Text.Trim(),
                     AddedOn = TimeStamps.UTCTime(),
                     AddedIP = CommonModel.IPAddress(),
                     Status = "Active"
                 };
                 var exe1 = CoAuthors.InsertCoAuthors(conMN, CoAuthors);


                 if (exe > 0 && exe1 > 0)
                 {

                     lblStatus.Text = "Submitted succefully";
                     txtAuthFullName.Text = txtAuthTitle.Text = txtAuthAffiliation.Text = txtAuthEmail.Text = txtAuthPhone.Text = txtCoAuthFullName.Text = txtCoAuthTitle.Text = txtCoAuthAffiliation.Text = txtCoAuthEmail.Text = txtArticleTitle.Text = txtAbstract.Text = txtKeywords.Text = ddlArticleType.SelectedValue = txtWordCount.Text = txtFigures.Text = txtPublishWork.Text = ddlPrevPublishedWork.SelectedValue = DescInterestAndFunding.Text = DescOrganization.Text = DescAcknowledgment.Text = DescEthicalCompliance.Text = txtSignature.Text = txtDate.Text = txtConName.Text = txtConEmail.Text = txtConPhone.Text = "";

                    // Response.Redirect("thank-you.aspx");

                 }

             }
             catch (Exception ex)
             {
             }
         }

     }*/
    private string CheckAttach()
    {
        #region CheckAttach
        string Attach = "";
        if (AttachManuscript.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(AttachManuscript.PostedFile.FileName.ToLower());
                if ((fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx"))
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
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckAttach", ex.Message);

            }
        }
        #endregion
        return Attach;
    }
    private string CheckSupplimentAttach()
    {
        #region UpldSuppAttachManuscript
        string SupAttach = "";
        if (AttachSupplementoryManuscript.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(AttachSupplementoryManuscript.PostedFile.FileName.ToLower());
                if ((fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx"))
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
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckSupplimentAttach", ex.Message);

            }
        }
        #endregion
        return SupAttach;
    }


    public string UploadSupplimentAttach()
    {
        #region SupAttach file
        string Supattachfile = "";
        try
        {
            if (AttachSupplementoryManuscript.HasFile)
            {
                string fileExtension = Path.GetExtension(AttachSupplementoryManuscript.PostedFile.FileName.ToLower());
                string ImageGuid1 = Guid.NewGuid().ToString() + "-pdf".Replace(" ", "-").Replace(".", "");

                string iconPath = Server.MapPath("~/UploadImages/") + ImageGuid1 + fileExtension;

                try
                {
                    if (File.Exists(Server.MapPath("~/" + Convert.ToString(lblattach.Text))))
                    {
                        File.Delete(Server.MapPath("~/" + Convert.ToString(lblattach.Text)));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadSupplimentAttach", eeex.Message);
                    return lblattach.Text;
                }

                AttachSupplementoryManuscript.SaveAs(iconPath);
                Supattachfile = "UploadImages/" + ImageGuid1 + fileExtension;
            }
            else
            {
                Supattachfile = lblattach.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadSupplimentAttach", ex.Message);
        }
        #endregion

        return Supattachfile;
    }

    public string UploadAttach()
    {
        #region Attach file
        string attachfile = "";
        try
        {
            if (AttachManuscript.HasFile)
            {
                string fileExtension = Path.GetExtension(AttachManuscript.PostedFile.FileName.ToLower());
                string ImageGuid1 = Guid.NewGuid().ToString() + fileExtension;
                string iconPath = Server.MapPath("~/UploadImages/") + ImageGuid1;

                try
                {

                    if (File.Exists(Server.MapPath("~/" + lblattach.Text)))
                    {
                        File.Delete(Server.MapPath("~/" + lblattach.Text));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadAttach", eeex.Message);
                    return lblattach.Text;
                }

                AttachManuscript.SaveAs(iconPath);
                attachfile = "UploadImages/" + ImageGuid1;
            }
            else
            {
                attachfile = lblattach.Text;
            }
        }

        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadAttach", ex.Message);
        }
        #endregion

        return attachfile;
    }

}
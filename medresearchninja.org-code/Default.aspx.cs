using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Activities;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string StrNotice = "", str3Forums = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["med_aid"] == null)
        //{

        // }
        BindNoticeBoard();
        BindTop3Forums();

        
    }
    public void BindNoticeBoard()
    {
        try
        {
            var notice = NoticeBoard.BindNoticeBoard(conMN);
            if (notice != null && notice.Count > 0)
            {
                for (int i = 0; i < notice.Count; i++)
                {
                    StrNotice += @"<li><a href='" + notice[i].NoticeUrl + @"' target='_blank'><i class='fa fa-angle-double-right dark-color'></i>" + notice[i].NoticeTitle + @"</a></li>  ";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindNoticeBoard", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string EmailSubscriptions(string mail)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            {
                List<EmailSubscription> existingEmails = EmailSubscription.GetMails(conMN).Where(x => x.EmailId == mail).ToList();

                if (existingEmails.Count > 0)
                {
                    return "Exists";
                }
                EmailSubscription newSubscription = new EmailSubscription
                {
                    EmailId = mail,
                    AddedOn = TimeStamps.UTCTime(),
                    AddedIp = CommonModel.IPAddress(),
                    Status = "Active"
                };
                int result = EmailSubscription.InsertEmailSubscription(conMN, newSubscription);

                if (result > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Error";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "EmailSubscriptions", ex.Message);
            return "Error";
        }
    }

    public void BindTop3Forums()
    {
        var frm = Forums.BindTop3Forums(conMN).ToList();
        for (int i = 0; i < frm.Count; i++)
        {
            str3Forums += @"<div class='free freelancer-style1 bdr1 hover-box-shadow row ms-0 align-items-start'>
                                             <div class='col-xl-12 px-0'>

                                                    <div class='d-lg-flex'>

                                                        <div class='details'>
                                                            <h5 class='title mb-1'>" + frm[i].Title + @"</h5>
                                                            <div class='review d-flex'>
                                                                <p class='mb-0 fz14 list-inline-item mb5-sm mr10'><i class='fas fa-eye new-color mr10'></i>" + frm[i].ViewCount + @"</p>
                                                                <p class='mb-0 fz14 list-inline-item mb5-sm mr10'><i class='fa-regular fa-comments new-color  mr10'></i>" + frm[i].CommentCount + @"</p>
                                                                <p class='mb-0 fz14 list-inline-item mb5-sm mr10'><i class='fa-solid fa-thumbs-up new-color  mr10'></i>" + frm[i].ViewCount + @"</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>";

        }
    }
}
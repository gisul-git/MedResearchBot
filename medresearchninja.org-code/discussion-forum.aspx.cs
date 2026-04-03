using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Vml.Office;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class discussion_forum : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strForums = "", strTopics = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllForums();
    }

    
    [WebMethod(EnableSession = true)]
    public static string ForumDetails(string title, string topic, string description)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            string uGuid = "";
            string addedBy = "";

            // Check if user is logged in
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
            {
                // Logged-in user
                uGuid = loginCookie.Value;
                var uname = MemberDetails.GetMemberDetailsByGuid(conMN, uGuid);
                addedBy = uname != null ? uname.FullName : "Anonymous";

                // Merge any previous guest posts into this logged-in account
                if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                {
                    Forums.MergeGuestActivity(conMN, guestCookie.Value, uGuid,addedBy);

                    
                    guestCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(guestCookie);
                }
            }
            else
            {
              
                if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                {
                    uGuid = guestCookie.Value;
                    addedBy = "Anonymous";
                }
                else
                {
                    // First-time guest
                    uGuid = Guid.NewGuid().ToString();
                    HttpCookie newCookie = new HttpCookie("guest_uid", uGuid);
                    newCookie.Expires = DateTime.Now.AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(newCookie);
                    addedBy = "Anonymous";
                }
            }

            // Prepare forum object
            Forums f = new Forums
            {
                Title = title,
                Topic = topic,
                Description = description,
                PageUrl = HttpContext.Current.Request.Url.ToString(),
                ViewCount = 0,
                LikeCount = 0,
                AddedBy = addedBy,
                UserGuid = uGuid,
                MessageGuid = Guid.NewGuid().ToString(),
                AddedOn = TimeStamps.UTCTime(),
                AddedIp = CommonModel.IPAddress(),
                Status = "Pending"
            };

            int result = Forums.InsertForums(conMN, f);

            return result > 0 ? "Success" : "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ForumDetails", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string BindAllForums()
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

        try
        {
            var strForums = "";
            var strTopics = "";
            var frm = Forums.GetAllForumsDetails(conMN);

            if (frm.Count > 0)
            {
                for (int i = 0; i < frm.Count; i++)
                {
                    if (frm[i].Status == "Accepted")
                    {
                        var url = "forum-details/" + frm[i].MessageGuid;

                        var currDate = TimeStamps.UTCTime() - frm[i].AddedOn;
                        var ago = "";
                        if (currDate.TotalMinutes < 60)
                        {
                            ago = Convert.ToInt32(currDate.TotalMinutes) + " Minutes ago";
                        }
                        else if (currDate.TotalHours < 24)
                        {
                            ago = Convert.ToInt32(currDate.TotalHours) + " Hours ago";
                        }
                        else if (currDate.TotalDays < 30)
                        {
                            ago = Convert.ToInt32(currDate.TotalDays) + " Days ago";
                        }
                        else if (currDate.TotalDays < 365)
                        {
                            ago = Convert.ToInt32(currDate.TotalDays / 30) + " Months ago";
                        }
                        else
                        {
                            ago = Convert.ToInt32(currDate.TotalDays / 365) + " Years ago";
                        }

                        var topics = Forums.GetAllForumsTopics(conMN);

                        strForums += @"<div class='community-post wow fadeInUp' data-wow-delay='0.5s' style='visibility: visible; animation-delay: 0.5s; animation-name: fadeInUp;'>
                                            <div class='post-content'>
                                                <div class='author-avatar'>
                                                    <img src='new-img/question.png' alt='community post'>
                                                </div>
                                                <div class='entry-content'>
                                                    <h3 class='post-title'><a href='" + url + @"' data-guid='" + frm[i].MessageGuid + @"' id='cnt' data-toggle='modal' data-target='#exampleModal'>" + frm[i].Title + @"</a></h3>
                                                    <p>Last active: " + ago + @"</p>
                                                </div>
                                            </div>
                                            <div class='post-meta-wrapper'>
                                                <ul class='post-meta-info'>
                                                    <li><a href='JavaScript:void(0)'><i class='fas fa-eye'></i>" + frm[i].ViewCount + @"</a></li>
                                                    <li><a href='JavaScript:void(0)'><i class='fa-regular fa-comments'></i>" + frm[i].CommentCount + @"</a></li>
                                                    <li><a href='JavaScript:void(0)'><i class='fa-solid fa-thumbs-up'></i>" + frm[i].LikeCount + @"</a></li>
                                                </ul>
                                            </div>
                                        </div>";

                        strTopics += @"<ul class='cats pl0'><li><a href='JavaScript:void(0)'>" + frm[i].Topic + @"<span class='badge pull-right'>" + topics[0].TopicCnt + @"</span></a></li></ul>";
                    }
                }

                return JsonConvert.SerializeObject(new { Forum = strForums, Topics = strTopics });
            }
            else
            {
                return "Empty";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllForums", ex.Message);
            return "Error";
        }
    }
}

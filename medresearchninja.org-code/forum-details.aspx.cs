using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class fourm_details : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strTitle = "", strDescription = "", strLastseen = "", strComments = "", strTopics = "", strNoOfComments = "", strCat = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        GetTopcs();

        var furl = Convert.ToString(RouteData.Values["furl"]);
        if (!string.IsNullOrEmpty(furl))
        {
            UpdatePageCount(furl);
            BindForumsDetailsNew(furl);
        }
    }

    [WebMethod(EnableSession = true)]
    public static string BindForumsDetailsNew(string furl)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {
            var frm = Forums.getForumsDetailsByUrl(conMN, furl);
            if (frm == null) return "Empty";

            string uGuid = "";
            string addedBy = "";
            string profileImage = "";

            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
            {
                uGuid = loginCookie.Value;
                var uname = MemberDetails.GetMemberDetailsByGuid(conMN, uGuid);
                addedBy = uname != null ? uname.FullName : "Anonymous";
                profileImage = uname != null ? uname.ProfileImage : "images/user.png";
             
                if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                {
                    Forums.MergeGuestActivity(conMN, guestCookie.Value, uGuid, addedBy);
                    Forums.MergeGuestComments(conMN, guestCookie.Value, uGuid,addedBy);
                    Forums.MergeGuestLikes(conMN, guestCookie.Value, uGuid);

                    guestCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(guestCookie);
                }
            }
            else if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
            {
                uGuid = guestCookie.Value;
                addedBy = "Anonymous";
                profileImage = "images/user.png";
            }
            else
            {
                uGuid = Guid.NewGuid().ToString();
                HttpCookie newCookie = new HttpCookie("guest_uid", uGuid) 
                {
                    Expires = DateTime.Now.AddDays(10) 
                };
                HttpContext.Current.Response.Cookies.Add(newCookie);
                addedBy = "Anonymous";
                profileImage = "images/user.png";
            }

            var likeStatus = LikesCount.GetLikeStatus(conMN, furl, uGuid);
            var cls = likeStatus > 0 ? "text-warning" : "";

            var strComments = Forums.GetForumsComments(conMN, furl);
            var currDate = TimeStamps.UTCTime() - frm.AddedOn;
            string ago = currDate.TotalMinutes < 60 ? Convert.ToInt32(currDate.TotalMinutes) + " Minutes ago" :
                         currDate.TotalHours < 24 ? Convert.ToInt32(currDate.TotalHours) + " Hours ago" :
                         currDate.TotalDays < 30 ? Convert.ToInt32(currDate.TotalDays) + " Days ago" :
                         currDate.TotalDays < 365 ? Convert.ToInt32(currDate.TotalDays / 30) + " Months ago" :
                         Convert.ToInt32(currDate.TotalDays / 365) + " Years ago";

            return JsonConvert.SerializeObject(new
            {
                Cmnt = strComments,
                LikeCls = cls,
                Title = frm.Title,
                Desc = frm.Description,
                LastUpdate = ago,
                CommentCount = frm.CommentCount,
                Topics = frm.Topic,
                ProfileImage =profileImage,
                FullName = addedBy
            });
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindForumsDetailsNew", ex.Message);
            return "Error";
        }
    }

    public void GetTopcs()
    {
        try
        {
            var topics = Forums.GetAllTopicsCount(conMN);
            if (topics != null && topics.Count > 0)
            {
                strCat = "";
                foreach (var topic in topics)
                {
                    strCat += @"<ul class='cats pl0'>
                <li>
                    <a href='JavaScript:void(0)'>"
                    + topic.Topic
                    + "<span class='badge pull-right'>"
                    + topic.TopicCnt
                    + "</span></a>"
                     + "</ li >"
                     +" </ ul > ";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTopcs", ex.Message);
        }
    }

    private void UpdatePageCount(string furl)
    {
        try
        {
            string uGuid = "";
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
                uGuid = loginCookie.Value;
            else if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                uGuid = guestCookie.Value;
            else
            {
                uGuid = Guid.NewGuid().ToString();
                HttpCookie newCookie = new HttpCookie("guest_uid", uGuid) { Expires = DateTime.Now.AddDays(10) };
                HttpContext.Current.Response.Cookies.Add(newCookie);
            }

            var currentCount = Forums.GetPageCount(conMN, uGuid);
            Forums.UpdateCount(conMN, currentCount + 1, uGuid);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePageCount", ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public static string CommentsDetails(string message, string guid)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {
            string uGuid = "";
            string addedBy = "";

            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
            {
                uGuid = loginCookie.Value;
                var uname = MemberDetails.GetMemberDetailsByGuid(conMN, uGuid);
                addedBy = uname != null ? uname.FullName : "Anonymous";

                if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                {
                    Forums.MergeGuestActivity(conMN, guestCookie.Value, uGuid, addedBy);
                    Forums.MergeGuestComments(conMN, guestCookie.Value, uGuid,addedBy);
                    Forums.MergeGuestLikes(conMN, guestCookie.Value, uGuid);

                    guestCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(guestCookie);
                }
            }
            else if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
            {
                uGuid = guestCookie.Value;
                addedBy = "Anonymous";
            }
            else
            {
                uGuid = Guid.NewGuid().ToString();
                HttpCookie newCookie = new HttpCookie("guest_uid", uGuid) { Expires = DateTime.Now.AddDays(10) };
                HttpContext.Current.Response.Cookies.Add(newCookie);
                addedBy = "Anonymous";
            }

            Comments c = new Comments
            {
                Message = message,
                PageUrl = HttpContext.Current.Request.Url.AbsoluteUri,
                LikeCount = 0,
                AddedBy = addedBy,
                UserGuid = uGuid,
                MessageGuid = guid,
                AddedOn = TimeStamps.UTCTime(),
                AddedIp = CommonModel.IPAddress(),
                Status = "Pending"
            };

            int result = Comments.InsertComments(conMN, c);
            return result > 0 ? "Success" : "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CommentsDetails", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string AddLike(string mesGuid)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {
            string uGuid = "";
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
            {
                uGuid = loginCookie.Value;
                if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                {
                    Forums.MergeGuestLikes(conMN, guestCookie.Value, uGuid);
                    guestCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(guestCookie);
                }
            }
            else if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                uGuid = guestCookie.Value;
            else
            {
                uGuid = Guid.NewGuid().ToString();
                HttpCookie newCookie = new HttpCookie("guest_uid", uGuid) { Expires = DateTime.Now.AddDays(10) };
                HttpContext.Current.Response.Cookies.Add(newCookie);
            }

            LikesCount like = new LikesCount
            {
                MessageGuid = mesGuid.Trim(),
                UserGuid = uGuid,
                AddedIp = CommonModel.IPAddress(),
                AddedOn = TimeStamps.UTCTime()
            };

            int exe = LikesCount.InsertLikes(conMN, like);
            return exe > 0 ? "Success" : "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddLike", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string RemoveLike(string mesGuid)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {
            string uGuid = "";
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["med_uid"];
            HttpCookie guestCookie = HttpContext.Current.Request.Cookies["guest_uid"];

            if (loginCookie != null && !string.IsNullOrEmpty(loginCookie.Value))
                uGuid = loginCookie.Value;
            else if (guestCookie != null && !string.IsNullOrEmpty(guestCookie.Value))
                uGuid = guestCookie.Value;

            if (!string.IsNullOrEmpty(uGuid))
            {
                int exe = LikesCount.DeleteLikes(conMN, uGuid, mesGuid.Trim());
                if (exe > 0) return "Success";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RemoveLike", ex.Message);
        }
        return "Error";
    }
}

using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class my_discussion : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strPosts = "";
    public string strComments = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        CheckUserExist();
        int count = Projects.GetPendingProjectDuesCount(conMN, Request.Cookies["med_uid"].Value);
        strDues = count > 0 ? "<span class='badge-circle'>" + count + "</span>" : "";

        GetMyPosts();
        GetMyComments();
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Cookies["med_uid"].Expires = TimeStamps.UTCTime().AddDays(-10);
            Response.Redirect("login.aspx");
        }
    }
    public void CheckUserExist()
    {
        try
        {
            if (Request.Cookies["med_uid"] == null)
            {

                StrLink = "/signup.aspx";
                StrText = "Sign Up";
                StrLoginBtn = "<a href='/signup.aspx' class='ud-btn1 btn-thm w-50'>Sign Up</a>";

            }
            else
            {
                var user = MemberDetails.GetMemberDetailsByGuid(conMN, Request.Cookies["med_uid"].Value);
                if (user != null)
                {
                    StrUserImage = user.ProfileImage == "" ? "<img src='/images/user.png' alt='user.png' width='30' />" : "<img src='/" + user.ProfileImage + @"' alt='user.png' width='30' />";
                    StrUserName = user.FullName;
                }
                StrLink = "/member-profile.aspx";
                StrText = "My Profile";
                StrLoginBtn = "<a href='/member-profile.aspx' class='ud-btn1 btn-thm w-50'>My Profile</a>";
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void GetMyPosts()
    {
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["med_uid"];
            string userGuid = cookie != null ? cookie.Value : null;
            List<Forums> res = Forums.BindMyPosts(conMN, userGuid);

            if (res != null && res.Count > 0)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    string sts = "";
                    switch (res[i].Status.ToLower().Trim())
                    {
                        case "rejected":
                            sts = "<a href='javascript:void(0);' class='badge bg-danger text-light'>Rejected</a>";
                            break;
                        case "accepted":
                            sts = "<a href='javascript:void(0);' class='badge bg-success text-light'>Approved</a>";
                            break;
                        case "pending":
                            sts = "<a href='javascript:void(0);' class='badge bg-primary text-light'>Pending</a>";
                            break;
                    }
                    var url = "forum-details/" + res[i].MessageGuid;
                    strPosts += @"<tr>
                                    <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].Title + @"</br><span class='text-success fw-normal'>You raised this question</span></h5>
                                    </div>
                                    </th>
                                   
                                    <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].AddedOn.ToString("dd/MMM/yyyy") + @"</h5>
                                    </div>
                                    </th>
                                     <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + sts + @"</h5>
                                    </div>
                                    </th>
                                    <th scope='row'>
                                    <div class='details mt-2'>
                                    <h5 class='title mb-2 '><a href='" + url + @"'class='table-action fz15 fw500 text-thm2 " + (res[i].Status != "Accepted" ? "opacity-50" : "") + @" ' data-bs-toggle='tooltip' data-bs-placement='top' title='' data-bs-original-title='View' contenteditable='false' style='cursor: pointer;'><span class='flaticon-website me-2 vam'></span>View</a></h5>
                                    </div>
                                    </th>
                    </tr>  ";
                }
            }
            else
            {
                strPosts = "<tr><td class='text-center' colspan='6'>No posts to display .</td></tr>";
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMyPosts", ex.Message);
        }
    }
    public void GetMyComments()
    {
        try
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["med_uid"];
            string userGuid = cookie != null ? cookie.Value : null;
            List<Comments> res = Comments.BindMyComments(conMN, userGuid);

            if (res != null && res.Count > 0)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    string sts = "";
                    switch (res[i].Status.ToLower().Trim())
                    {
                        case "rejected":
                            sts = "<a href='javascript:void(0);' class='badge bg-danger text-light'>Rejected</a>";
                            break;
                        case "accepted":
                            sts = "<a href='javascript:void(0);' class='badge bg-success text-light'>Approved</a>";
                            break;
                        case "pending":
                            sts = "<a href='javascript:void(0);' class='badge bg-primary text-light'>Pending</a>";
                            break;

                    }
                    var url = "forum-details/" + res[i].MessageGuid;
                    strComments += @"<tr>
                                    <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + HttpUtility.UrlDecode(res[i].Message) + @"</br><span class='text-success fw-normal'>You raised this Comment</span></h5>
                                    </div>
                                    </th>
                                     <th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + res[i].AddedOn.ToString("dd/MMM/yyyy") + @"</h5>
                                    </div>
                                    </th>
<th scope='row'>
                                    <div class='details '>
                                    <h5 class='title mb-2'>" + sts + @"</h5>
                                    </div>
                                    </th>
                                    <th scope='row'>
                                    <div class='details mt-2'>
                                    <h5 class='title mb-2 '><a href='" + url + @"'class='table-action fz15 fw500 text-thm2 " + (res[i].Status != "Accepted" ? "opacity-50" : "") + @" ' data-bs-toggle='tooltip' data-bs-placement='top' title='' data-bs-original-title='View' contenteditable='false' style='cursor: pointer;'><span class='flaticon-website me-2 vam'></span>View</a></h5>
                                    </div>
                                    </th>
                    </tr>  ";
                }
            }
            else
            {
                strComments = "<tr><td class='text-center' colspan='6'>No comments to display.</td></tr>";
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMyComments", ex.Message);
        }
    }

}
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;


public partial class contact_us : System.Web.UI.Page

{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //SendExistingUserMail();
    }

    public void SendExistingUserMail()
    {
        try
        {
            var query = "select * from Memberdetails where  status ='Active' And Emailid IS NOT NULL AND EmailId !='' And Id between 301 And 400 order by id";
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }


            //var users = MemberDetails.GetAllMembersDetails(conMN).Where(x => x.EmailId != null).ToList();
            var count = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var guid = Convert.ToString(dt.Rows[i]["UserGuid"]);
                    var name = Convert.ToString(dt.Rows[i]["FullName"]);
                    var email = Convert.ToString(dt.Rows[i]["EmailId"]);
                    var pwd = CommonModel.Decrypt(Convert.ToString(dt.Rows[i]["Password"]));
                    var Link = ""; //Convert.ToString(dt.Rows[i]["Password"]);
                    var exe = Emails.ExistingMembershipMail(name, email, pwd, Link);
                    if (exe > 1)
                    {
                        MemberDetails.UpdateMsgCount(conMN, guid);
                        count++;
                    }
                }

                var total = count;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendExistingUserMail", ex.Message);

        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            lblStatus.Visible = true;
            
            if (Convert.ToString(Session["captchanum"]) != txtCaptcha.Text.Trim())
            {
                lblStatus.Text = "Invalid capcha!";
                lblStatus.Attributes.Add("class", "alert alert-danger");
                return;
            }
            else
            {
                try
                {

                    var code = txtCCodeMob1.Value;
                    ContactUs CD = new ContactUs
                    {

                        Fullname = txtName.Text.Trim(),
                        EmailAdress = txtEmail.Text.Trim(),
                        Phone = code + " " + txtPhone.Text.Trim(),
                        Message = txtMessage.Text.Trim(),
                        AddedOn = TimeStamps.UTCTime(),
                        AddedIp = CommonModel.IPAddress(),
                        Status = "Active",
                        pageurl = HttpContext.Current.Request.Url.AbsoluteUri.ToString()
                    };
                    int result = ContactUs.InsertContactUs(conMN, CD);
                    if (result > 0)
                    {
                        var exe = Emails.SendContactRequest(CD);
                        lblStatus.Text = "thank you for your request.our team will get back to you soon.";
                        lblStatus.CssClass = "alert alert-success d-block";
                        txtName.Text = txtEmail.Text = txtPhone.Text = txtMessage.Text = "";
                        Response.Redirect("/thank-you.aspx", false);
                    }
                    else
                    {
                        lblStatus.Text = "There is some problem now. Please try after some time.";
                        lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "There is some problem now. Please try after some time";
                    lblStatus.CssClass = "alert alert-danger d-block";
                    ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnsubmit_Click", ex.Message);
                }
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }
    void FillCapctha()
    {
        try
        {
            Image1.ImageUrl = "capcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }

}

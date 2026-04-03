using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_notice_board : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strNoticeBoard = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", " this.disabled = 'true';this.value='Please Wait...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
      GetAllNoticeBoard();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                 GetNoticeBoard();
            }
            else
            {

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
                NoticeBoard nb = new NoticeBoard();
            if (btnSave.Text == "Update")
            {
                    nb.NoticeTitle = txtTitle.Text.Trim();
                    nb.NoticeUrl = txtNoticeUrl.Text.Trim();
                    nb.Id = Convert.ToInt32(Request.QueryString["id"]);
                    nb.AddedIP = CommonModel.IPAddress();
                    nb.AddedOn = TimeStamps.UTCTime();
                    nb.Status = "Active";
                    nb.AddedBy = Request.Cookies["med_aid"].Value;

                int result = NoticeBoard.UpdateNoticeBoard(conMN, nb);
                if (result > 0)
                {
                        GetAllNoticeBoard();
                         GetNoticeBoard();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Notice updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }
            }
            else
            {
                    nb.NoticeTitle = txtTitle.Text.Trim();
                    nb.NoticeUrl = txtNoticeUrl.Text.Trim();
                    nb.Id = Convert.ToInt32(Request.QueryString["id"]);
                    nb.AddedIP = CommonModel.IPAddress();
                    nb.AddedOn = TimeStamps.UTCTime();
                    nb.Status = "Active";
                    nb.AddedBy = Request.Cookies["med_aid"].Value;

                int result = NoticeBoard.InsertNoticeBoard(conMN, nb);
                if (result > 0)
                {
                    txtTitle.Text = txtNoticeUrl.Text="";
                        GetNoticeBoard();
                        GetAllNoticeBoard();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Notice added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtTitle.Text = txtNoticeUrl.Text = "";
                    }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                }
            }
        }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }

    public void GetAllNoticeBoard()
    {
        try
        {
            strNoticeBoard = "";
            List<NoticeBoard> cas = NoticeBoard.GetAllNoticeBoard(conMN).OrderByDescending(s => Convert.ToDateTime(s.AddedOn)).ToList();
            int i = 0;
            foreach (NoticeBoard nb in cas)
            {

                strNoticeBoard += @"<tr>
                                                <td>" + (i + 1) + @"</td>  
                                                             <td>" + nb.NoticeTitle + @"</td>
                                                             <td><a href='" + nb.NoticeUrl + @"' target='_blank' class='text-secondary fw-bold'><u>Link</u></a></td>
                                         <td><a href='javascript:void();' class='bs-tooltip' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title=''>" + nb.AddedOn.ToString("dd-MMM-yyyy") + @"</a></td>  

                                                <td class='text-center'>
                                                    <a href='manage-notice-board.aspx?id=" + nb.Id + @"' class='bs-tooltip fs-18 link-info' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Edit'>
                                                        <i class='mdi mdi-pencil'></i></a>
                                                    <a href='javascript:void(0);' class='bs-tooltip fs-18 link-danger deleteItem' data-id='" + nb.Id + @"' data-bs-toggle='tooltip' data-bs-placement='top' title='Delete'>
                                                        <i class='mdi mdi-trash-can-outline'></i></a>
                                                </td>
                                            </tr>";
                i++;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllNoticeBoard", ex.Message);
        }
    }
    public void GetNoticeBoard()
    {
        try
        {
            NoticeBoard PD = NoticeBoard.GetNoticeBoard(conMN, Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
            if (PD != null)
            {

                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtTitle.Text = PD.NoticeTitle;
                txtNoticeUrl.Text = PD.NoticeUrl;   
                
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetNoticeBoards", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            NoticeBoard PD = new NoticeBoard();
            PD.Id = Convert.ToInt32(id);
            PD.AddedOn = TimeStamps.UTCTime();
            PD.AddedIP = CommonModel.IPAddress();
            int exec = NoticeBoard.DeleteNoticeBoard(conMN, PD);
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




    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage-notice-board.aspx");
    }
}
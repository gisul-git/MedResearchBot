using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Media;

public partial class Admin_members : System.Web.UI.Page
{
    public string strMembers = "";
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAllMembers();
    }
    public void BindAllMembers()
    {
        try
        {
            strMembers = "";
            var key = txtKey.Text;
            var Sdate = txtdates.Text.Split(' ').FirstOrDefault();
            var Edate = txtdates.Text.Split(' ').LastOrDefault();
            var Status = ddlStatus.SelectedValue == "All" ? "" : ddlStatus.SelectedValue;
            var Pay = ddlPayStatus.SelectedValue == "All" ? "" : ddlPayStatus.SelectedValue;
            List<MemberDetails> MD = MemberDetails.GetFilteredMembersDetails(conMN, key, Sdate, Edate, Status, Pay);

            for (int i = 0; i < MD.Count; i++)
            {

                string mds = MD[i].Status == "Blocked" ? "checked" : "";
                string sts = ""; //MD[i].Status == "Active" ?  : "<span id='sts_" + MD[i].Id + @"' class=' badge badge-outline-danger shadow fs-13'>Blocked</span>";
                switch (MD[i].Status)
                {
                    case "Active": sts = "<span id='sts_" + MD[i].Id + @"' class='badge badge-outline-success shadow fs-13'>Active</span>"; break;
                    case "Unverified":
                        sts = "<span id='sts_" + MD[i].Id + @"' class='badge badge-outline-warning shadow fs-13'>Unverified</span>"; break;
                    case "Blocked":
                        sts = "<span id='sts_" + MD[i].Id + @"' class='badge badge-outline-danger shadow fs-13'>Blocked</span>"; break;
                }

                string paysts = "";
                switch (MD[i].PaymentStatus)
                {
                    case "Paid": paysts = "<span id='sts_" + MD[i].Id + @"' class='badge badge-outline-success shadow fs-13'>Paid</span>"; break;
                    case "Not Paid":
                        paysts = "<span id='stsp_" + MD[i].Id + @"' class='badge badge-outline-warning shadow fs-13'>Initiated</span>"; break;

                    case "Failed":
                        paysts = "<span id='stsp_" + MD[i].Id + @"' class='badge badge-outline-danger shadow fs-13'>Failed</span>"; break;
                }
                string chk = @"<div class='text-center form-check form-switch form-switch-lg form-switch-danger'>
                                    <input class='form-check-input blockItem' type='checkbox' role='switch' data-id='" + MD[i].Id + @"' data-guid='" + MD[i].UserGuid + @"' id='chk_" + MD[i].Id + @"' " + mds + @">
                                    </div>";
                var msgcnt = MD[i].MsgCnt;


                // var GovtID = "<a href='/" + MD[i].GovtID + @"' target='_blank'><img src='/" + MD[i].GovtID + @"' alt='' class='rounded-circle avatar-xs shadow'></a>";
                strMembers += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                       <td class='minfowidth'>
                                            <div class='d-flex justify-content-between'><div>
                                                <a href='javascript:void(0);' data-bs-toggle ='modal' data-bs-target ='#WhitePaperModal' class='text-info fw-bold btnViewInfo fs-14' data-id='" + MD[i].Id + @"'>" + MD[i].UserID + @"<span class='ms-3 badge badge-outline-primary'>click for more info</span></a><br>
                                                <span class='fw-bold'>" + MD[i].FullName + @"</span><br>
                                                <span class='text-primary fw-bold'>" + MD[i].EmailId + @"</span><br>
                                                <span class='text-secondary fw-bold'>" + MD[i].Contact + @"</span><br>
                                                <small class='text-danger fw-bold'>" + CommonModel.Decrypt(MD[i].Password) + @"</small>
                                            </div>
                                            <a href='add-member.aspx?id=" + MD[i].UserGuid + @"' class='bs-tooltip text-info fs-16' data-toggle='tooltip' data-placement='top' title='Edit member details' data-original-title='Edit member details'>
                                            <i class='mdi mdi-pencil'></i></a>
                                           </div>
                                        </td>
                                        <td class='mwidth'>" + MD[i].MedicalSchoolName + @"</td>
                                        <td>" + MD[i].Country + @"</td>
                                        <td class='text-center'>" + chk + @"</td>
                                        <td class='text-center'>" + sts + @"</td>
                                        <td class='text-center'>" + paysts + @"</td>
                                         
                                        <td>" + MD[i].AddedOn.ToString("dd/MMM/yyyy") + @"</td>
                                        <td class='text-center'> 

                                            <a href='javascript:void(0);' id='ver_" + MD[i].Id + @"' class='bs-tooltip verifyItem text-success fs-18 " + (MD[i].Status == "Active" ? "d-none" : "") + @"' data-id='" + MD[i].Id + @"' data-guid='" + MD[i].UserGuid + @"' data-toggle='tooltip' data-placement='top' title='Verify User' data-original-title='Verify User'>
                                               <i class='mdi mdi-checkbox-marked-circle-outline'></i></a>
                                              <a href='javascript:void(0);' class='bs-tooltip pwdItem warning confirm text-danger fs-18' data-bs-toggle='modal' data-bs-target='#UserLogin' data-guid='" + MD[i].UserGuid + @"' data-email='" + MD[i].EmailId + @"' data-toggle='tooltip' data-placement='top' title='Change password' data-original-title='Logins'>
                                               <i class='mdi mdi-lock'></i></a>
                                           <a href='javascript:void(0);' class='bs-tooltip mailItem text-success fs-18' data-guid='" + MD[i].UserGuid + @"' data-email='" + MD[i].EmailId + @"' data-toggle='tooltip' data-placement='top' title='Send Mail to User' data-original-title='Send Mail to User'>
                                               <i class='mdi mdi-email-outline'></i><span class='position-absolute topbar-badge fs-8 translate-middle badge rounded-pill bg-info msgcnt'>" + msgcnt + @"</span></a>
                                           <a href = 'javascript:void(0);' class='bs-tooltip  fs-18 link-danger deleteItem' data-id='" + MD[i].Id + @"' data-bs-toggle='tooltip' data-placement='top' title='Delete Members'><i class='mdi mdi-trash-can-outline'></i></a> 
                                             
                                        </td>
                                        </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllMembers", ex.Message);
        }
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName.ToLower());
                if ((fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx"))
                {
                    // Perform operations on the workbook here
                    int totalRowExce = 0;
                    int totalRowUpd = 0;

                    string strNotUpdColumn = "";

                    int rowL = 0;
                    using (XLWorkbook workBook = new XLWorkbook(FileUpload1.PostedFile.InputStream))
                    {

                        //Read the first Sheet from Excel file.
                        IXLWorksheet workSheet = workBook.Worksheet(1);// Access the first worksheet

                        //Create a new DataTable.
                        DataTable dt = new DataTable();
                        string ip = CommonModel.IPAddress();
                        DateTime ct = TimeStamps.UTCTime();
                        string UpdatedBy = Request.Cookies["med_aid"].Value;
                        foreach (IXLRow row in workSheet.Rows())
                        {
                            //Excel Properties.
                            string FullName, EmailId, Contact, Password, Address, City, State, Country, Pincode, MedicalSchoolName = "";
                            string UserGuid = Guid.NewGuid().ToString();
                            string ForgotId = Guid.NewGuid().ToString();
                            string UserId = UserID();

                            if (rowL > 0)
                            {
                                //FullName
                                if (Convert.ToString(row.Cell(2).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    FullName = Convert.ToString(row.Cell(2).Value).Trim();
                                }

                                //EmailId
                                if (Convert.ToString(row.Cell(3).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    EmailId = Convert.ToString(row.Cell(3).Value).Trim();
                                }


                                //Contact
                                if (Convert.ToString(row.Cell(4).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    Contact = Convert.ToString(row.Cell(4).Value).Trim();
                                }

                                //Password
                                if (Convert.ToString(row.Cell(5).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    Password = CommonModel.Encrypt(Convert.ToString(row.Cell(5).Value).Trim());
                                }
                                //Address
                                if (Convert.ToString(row.Cell(6).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    Address = Convert.ToString(row.Cell(6).Value).Trim();
                                }

                                //City
                                if (Convert.ToString(row.Cell(7).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    City = Convert.ToString(row.Cell(7).Value).Trim();
                                }

                                //State
                                if (Convert.ToString(row.Cell(8).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    State = Convert.ToString(row.Cell(8).Value).Trim();
                                }
                                //Country
                                if (Convert.ToString(row.Cell(9).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    Country = Convert.ToString(row.Cell(9).Value).Trim();
                                }

                                //Pincode
                                if (Convert.ToString(row.Cell(10).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    Pincode = Convert.ToString(row.Cell(10).Value).Trim();
                                }

                                //MedicalSchoolName
                                if (Convert.ToString(row.Cell(11).Value).Trim() == "")
                                {
                                    strNotUpdColumn += Convert.ToString(row.Cell(1).Value).Trim() + "|";

                                    continue;
                                }
                                else
                                {
                                    MedicalSchoolName = Convert.ToString(row.Cell(11).Value).Trim();
                                }

                                int CheckMemberUpdate = 0;
                                int exe = 0;
                                var CD = new MemberDetails()
                                {
                                    FullName = FullName.Trim(),
                                    UserGuid = UserGuid,
                                    UserID = UserId,
                                    Password = Password,
                                    EmailId = EmailId,
                                    UpdatedBy = UpdatedBy,
                                    AddedIp = CommonModel.IPAddress(),
                                    AddedOn = TimeStamps.UTCTime(),
                                    LastLoggedIn = TimeStamps.UTCTime(),
                                    LastLoggedIp = "",
                                    UpdatedOn = TimeStamps.UTCTime(),
                                    UpdatedIp = "",
                                    GovtID = "",
                                    AddedBy = "",
                                    WhoAreYou = "",
                                    Specify = "",
                                    PassKey = "",
                                    ProfileImage = "",
                                    Contact = Contact,
                                    ForgotId = ForgotId,
                                    Address = Address,
                                    City = City,
                                    State = State,
                                    Country = Country,
                                    Pincode = Pincode,
                                    MedicalSchoolName = MedicalSchoolName == "" ? "" : MedicalSchoolName,
                                    Status = "Active",
                                    PaymentStatus = "Paid",   //change acordingly in xl or here
                                    MsgCnt = "0"
                                };
                                if (CheckEmailIdExist(EmailId.Trim()) || CheckUserIdExist(UserId.Trim()))
                                {
                                    exe = MemberDetails.UpdateMemberProfileExcel(conMN, CD);
                                    CheckMemberUpdate = 1;
                                }
                                else
                                {
                                    exe = MemberDetails.AddMember(conMN, CD);
                                }
                                if (CheckMemberUpdate == 1)
                                {
                                    totalRowUpd = totalRowUpd + exe;
                                }
                                else
                                {
                                    totalRowExce = totalRowExce + exe;
                                }
                            }
                            rowL++;

                        }
                        if (strNotUpdColumn.TrimEnd('|').Trim() != "")
                        {
                            strNotUpdColumn = strNotUpdColumn.TrimEnd('|') + " corresponding rows not updated";
                        }
                        else
                        {
                            strNotUpdColumn = "";

                        }
                        BindAllMembers();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: '" + totalRowExce + " No of rows executed and " + totalRowUpd + " No of rows Updated " + strNotUpdColumn + @".',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);

                    };
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid file format please upload .xls or .xlsx file format.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please select a file to upload',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BtnUpload_Click", ex.Message);

        }
    }

    public string UserID()
    {
        try
        {
            string Mem = MemberDetails.GetUserID(conMN);
            if (!string.IsNullOrEmpty(Mem))
            {
                int nextId = Convert.ToInt32(Mem.Replace("MRNUSER", "")) + 1;
                return String.Format("MRNUSER{0:D4}", nextId);
            }
            else
            {
                return "MRNUSER0001";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UserID", ex.Message);
            return null;
        }
    }

    public bool CheckUserIdExist(string uid)
    {
        try
        {
            var query = "Select Count(ID) as Cnt from MemberDetails where Trim(UserId)=@UserId and Status !=@Status";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = uid;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int cnt = 0;
                int.TryParse(Convert.ToString(dt.Rows[0]["Cnt"]), out cnt);
                return cnt > 0;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckUserIdExist", ex.Message);
        }
        return false;
    }
    public bool CheckEmailIdExist(string mail)
    {
        try
        {
            var query = "Select Count(ID) as Cnt from MemberDetails where Trim(EmailId)=@EmailId and Status !=@Status";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = mail;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int cnt = 0;
                int.TryParse(Convert.ToString(dt.Rows[0]["Cnt"]), out cnt);
                return cnt > 0;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckEmailIdExist", ex.Message);
        }
        return false;
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            MemberDetails MD = new MemberDetails();
            MD.Id = Convert.ToInt32(id);
            MD.AddedOn = TimeStamps.UTCTime();
            MD.Status = "Deleted";
            MD.AddedIp = CommonModel.IPAddress();
            int exec = MemberDetails.DeleteMemberDetails(conMN, MD);

            if (exec > 0)
            {
                x = "Success";
                HttpContext.Current.Response.Cookies["med_uid"].Expires = DateTime.UtcNow.AddDays(-1);
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

    [WebMethod(EnableSession = true)]
    public static string GetDetails(string id)
    {
        var details = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            details = MemberDetails.GetDetailsById(conMN, id);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetails", ex.Message);
        }
        return details;
    }
    [WebMethod(EnableSession = true)]
    public static string UpdatePassword(string Guid, string password)
    {
        string x = "";
        try
        {
            string pwd = CommonModel.Encrypt(password);
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
            x = MemberDetails.PasswordReset(conMN, pwd, Guid);
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePassword", ex.Message);
        }
        return x;


    }

    [WebMethod(EnableSession = true)]
    public static string BlockPartner(string id, string guid, string ftr)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var MD = new MemberDetails()
            {
                Id = Convert.ToInt32(id),
                Status = ftr == "Yes" ? "Blocked" : "Unverified",
                AddedOn = TimeStamps.UTCTime(),
                UpdatedOn = TimeStamps.UTCTime(),
                AddedIp = CommonModel.IPAddress(),
                UpdatedIp = CommonModel.IPAddress(),
            };

            int exec = MemberDetails.DeleteMember(conMN, MD);
            if (exec > 0)
            {
                x = "Success";
                //HttpContext.Current.Response.Cookies["med_uid"].Expires = DateTime.UtcNow.AddDays(-1);

            }
            else
            {
                x = "W";
            }
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BlockPartner", ex.Message);
        }
        return x;
    }

    [WebMethod(EnableSession = true)]
    public static string VerifyPartner(string id, string guid)
    {
        string x = "";
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var MD = new MemberDetails()
            {
                Id = Convert.ToInt32(id),
                Status = "Active",
                PaymentStatus = "Paid",
                AddedOn = TimeStamps.UTCTime(),
                UpdatedOn = TimeStamps.UTCTime(),
                AddedIp = CommonModel.IPAddress(),
                UpdatedIp = CommonModel.IPAddress(),
            };

            int exec = MemberDetails.UpdateMemberASVerified(conMN, MD);
            if (exec > 0)
            {
                var member = MemberDetails.GetMemberDetailsByGuid(conMN, guid);
                
                Emails.NewMembershipMail(member.FullName, member.EmailId, CommonModel.Decrypt(member.Password), member.WLink);
                Emails.NewMembershipMailAdmin(member.FullName, member.EmailId);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "VerifyPartner", ex.Message);
        }
        return x;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindAllMembers();
    }

    [WebMethod(EnableSession = true)]
    public static string ApprovedMsg(string guid)
    {
        try
        {
            SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

            var member = MemberDetails.GetMemberDetailsByGuid(conMN, guid);
            if (member != null)
            {
                var pwd = CommonModel.Decrypt(member.Password);
                var exe = Emails.ExistingMembershipMail(member.FullName, member.EmailId, pwd, member.WLink);
                var exe1 = Emails.ExistingMembershipMailAdmin(member.FullName, member.EmailId);
                if (exe > 0 && exe1 > 0)
                {
                    var exe2 = MemberDetails.UpdateMsgCount(conMN, guid);
                    if (exe2 > 0)
                    {
                        return "Success";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ApprovedMsg", ex.Message);
        }
        return "Empty";
    }

}
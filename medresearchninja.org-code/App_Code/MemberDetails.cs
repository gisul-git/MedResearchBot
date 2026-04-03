using DocumentFormat.OpenXml.Office.Word;
using Newtonsoft.Json;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MemberDetails
/// </summary>
public class MemberDetails
{
    // Properties
    public int Id { get; set; }
    public string UserID { get; set; }
    public string UserGuid { get; set; }
    public string FullName { get; set; }
    public string Specify { get; set; }
    public string TotalMembers { get; set; }
    public string WhoAreYou { get; set; }
    public string PaymentStatus { get; set; }
    public string EmailId { get; set; }
    public string Contact { get; set; }
    public string Password { get; set; }
    public string ForgotId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Pincode { get; set; }
    public DateTime LastLoggedIn { get; set; }
    public string LastLoggedIp { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string UpdatedIp { get; set; }
    public string UpdatedBy { get; set; }
    public string ProfileImage { get; set; }
    public string PassKey { get; set; }
    public string MedicalSchoolName { get; set; }
    public string GovtID { get; set; }
    public string MsgCnt { get; set; }
    public string Percentage { get; set; }

    //Extra 
    public string WLink { get; set; }
    public string OrderGuid { get; set; }

    public static int AddMember(SqlConnection conMN, MemberDetails cat)
    {
        int result = 0;
        try
        {
            string query = @"INSERT INTO MemberDetails (UserID, UserGuid, FullName, EmailId, Contact, Password, ForgotId, 
                                                  Address, City, State, Country, Pincode, LastLoggedIn, LastLoggedIp, 
                                                  AddedOn, AddedIp, AddedBy, Status, UpdatedOn, UpdatedIp, UpdatedBy, 
                                                  ProfileImage, MedicalSchoolName, GovtID,PaymentStatus,WhoAreYou,Specify,MsgCnt)
                             VALUES (@UserID, @UserGuid, @FullName, @EmailId, @Contact, @Password, @ForgotId, 
                                     @Address, @City, @State, @Country, @Pincode, @LastLoggedIn, @LastLoggedIp, 
                                     @AddedOn, @AddedIp, @AddedBy, @Status, @UpdatedOn, @UpdatedIp, @UpdatedBy, 
                                     @ProfileImage, @MedicalSchoolName, @GovtID,@PaymentStatus,@WhoAreYou,@Specify,@MsgCnt)";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = cat.UserID;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.UniqueIdentifier).Value = cat.UserGuid;
                cmd.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = cat.FullName;
                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = cat.EmailId;
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = cat.PaymentStatus;
                cmd.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = cat.Contact;
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = cat.Password;
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = cat.ForgotId;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = cat.Address;
                cmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = cat.City;
                cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = cat.State;
                cmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = cat.Country;
                cmd.Parameters.AddWithValue("@Pincode", SqlDbType.NVarChar).Value = cat.Pincode;
                cmd.Parameters.AddWithValue("@LastLoggedIn", SqlDbType.NVarChar).Value = cat.LastLoggedIn;
                cmd.Parameters.AddWithValue("@LastLoggedIp", SqlDbType.NVarChar).Value = cat.LastLoggedIp;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@WhoAreYou", SqlDbType.NVarChar).Value = cat.WhoAreYou;
                cmd.Parameters.AddWithValue("@Specify", SqlDbType.NVarChar).Value = cat.Specify;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = cat.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = cat.UpdatedIp;
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                cmd.Parameters.AddWithValue("@ProfileImage", SqlDbType.NVarChar).Value = cat.ProfileImage;
                cmd.Parameters.AddWithValue("@MedicalSchoolName", SqlDbType.NVarChar).Value = cat.MedicalSchoolName;
                cmd.Parameters.AddWithValue("@GovtID", SqlDbType.NVarChar).Value = cat.GovtID;
                cmd.Parameters.AddWithValue("@PassKey", SqlDbType.NVarChar).Value = cat.PassKey;
                cmd.Parameters.AddWithValue("@MsgCnt", SqlDbType.NVarChar).Value = cat.MsgCnt;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddMember", ex.Message);
        }

        return result;
    }
    public static int UpdateMember(SqlConnection conMN, MemberDetails comp)
    {
        int result = 0;
        try
        {
            string query = "Update MemberDetails Set UserGuid=@UserGuid,FullName=@FullName,EmailId=@EmailId,Contact=@Contact,Password=@Password,ForgotId=@ForgotId,Address=@Address,City=@City,State=@State,Country=@Country,Pincode=@Pincode,LastLoggedIn=@LastLoggedIn,LastLoggedIp=@LastLoggedIp,AddedOn=@AddedOn,AddedIp=@AddedIp,AddedBy=@AddedBy,Status=@Status,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp,ProfileImage=@ProfileImage,MedicalSchoolName=@MedicalSchoolName,GovtID=@GovtID  Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = comp.Id;
                cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = comp.UserID;
                cmd.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = comp.FullName;
                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = comp.EmailId;
                cmd.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = comp.Contact;
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = comp.Password;
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = comp.ForgotId;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = comp.Address;
                cmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = comp.City;
                cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = comp.State;
                cmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = comp.Country;
                cmd.Parameters.AddWithValue("@Pincode", SqlDbType.NVarChar).Value = comp.Pincode;
                cmd.Parameters.AddWithValue("@LastLoggedIn", SqlDbType.NVarChar).Value = comp.LastLoggedIn;
                cmd.Parameters.AddWithValue("@LastLoggedIp", SqlDbType.NVarChar).Value = comp.LastLoggedIp;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = comp.AddedOn;
                cmd.Parameters.AddWithValue("@ProfileImage", SqlDbType.NVarChar).Value = comp.ProfileImage;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = comp.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = comp.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = comp.Status;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = comp.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = comp.UpdatedIp;
                cmd.Parameters.AddWithValue("@MedicalSchoolName", SqlDbType.NVarChar).Value = comp.MedicalSchoolName;
                cmd.Parameters.AddWithValue("@GovtID", SqlDbType.NVarChar).Value = comp.GovtID;
                cmd.Parameters.AddWithValue("@PassKey", SqlDbType.NVarChar).Value = comp.PassKey;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateMember", ex.Message);
        }
        return result;
    }
    public static int DeleteMemberDetails(SqlConnection conMN, MemberDetails comp)
    {
        int result = 0;

        try
        {
            string query = "Update MemberDetails Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = comp.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = comp.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = comp.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = comp.AddedIp;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteMemberDetails", ex.Message);
        }
        return result;
    }
    public static decimal NoOfMember(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from MemberDetails Where Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cntB = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntB"]), out cntB);
                x = cntB;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfMember", ex.Message);
        }
        return x;
    }

    public static int CheckMemberExist(SqlConnection conMN, string Mail)
    {
        int result = 0;

        try
        {
            string query = "Select * from MemberDetails Where EmailId=@EmailId and Status !='Deleted'";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = Mail;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckMemberExist", ex.Message);

        }
        return result;
    }
    public static MemberDetails MemberDetails1(SqlConnection conMN, MemberDetails loginInputs)
    {
        MemberDetails login = new MemberDetails();
        try
        {
            string query = "Select *  from MemberDetails where EmailId=@UserID and Password=@Password and status!='deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = loginInputs.UserID;
            cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = loginInputs.Password;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                login.FullName = Convert.ToString(dt.Rows[0]["FullName"]);
                login.Contact = Convert.ToString(dt.Rows[0]["Contact"]);
                login.UserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);
                login.PassKey = Convert.ToString(dt.Rows[0]["PassKey"]);
                login.Status = Convert.ToString(dt.Rows[0]["Status"]);
                login.PaymentStatus = Convert.ToString(dt.Rows[0]["PaymentStatus"]);

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MemberDetails1", ex.Message);
        }
        return login;
    }
    public static string CheckPassKey(SqlConnection conMN, string uid)
    {
        string login = "";
        try
        {
            string query = "Select * from MemberDetails where UserGuid=@UserGuid ";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                login = Convert.ToString(dt.Rows[0]["pass_key"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckPassKey", ex.Message);
        }
        return login;
    }
    public static void UpdateLastLoginTime(SqlConnection conMN, string uid)
    {
        try
        {
            string query = "Update MemberDetails Set LastLoggedIn=@log_time,LastLoggedIp=@log_ip where UserGuid=@UserGuid ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@log_time", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@log_ip", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
                conMN.Open();
                cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateLastLoginTime", ex.Message);
        }

    }

    public static void UpdatePaymentStatus(SqlConnection conMN, string uid)
    {
        try
        {
            if (conMN.State != System.Data.ConnectionState.Open)
            {
                conMN.Open();
            }

            string query = "Update MemberDetails Set PaymentStatus=@PaymentStatus,Status=@Status where UserGuid=@UserGuid";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = "Paid";
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePaymentStatus", ex.Message);
        }
        finally
        {
            if (conMN.State == System.Data.ConnectionState.Open)
            {
                conMN.Close();
            }
        }
    }

    public static string MemberResetPassword(SqlConnection conMN, string email)
    {
        string login = "";
        try
        {
            string query = "Select * from MemberDetails where EmailId=@EmailId and Status='Active' ";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = email;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                login = Convert.ToString(dt.Rows[0]["UserGuid"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MemberResetPassword", ex.Message);
        }
        return login;
    }
    public static int SetRestId(SqlConnection conMN, string uid, string resetId)
    {
        int r = 0;
        try
        {
            string query = "Update MemberDetails Set ForgotId=@ForgotId,ResetON=@ResetON where UserGuid=@UserGuid ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@ResetON", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = resetId;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
                conMN.Open();
                r = cmd.ExecuteNonQuery();
                conMN.Close();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SetRestId", ex.Message);
        }
        return r;
    }
    public static string GetLoggedMemberName(SqlConnection conMN, string uid)
    {
        string login = "";
        try
        {
            string query = "Select * from MemberDetails where UserGuid=@UserGuid ";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                login = Convert.ToString(dt.Rows[0]["FullName"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetLoggedMemberName", ex.Message);
        }
        return login;
    }
    public static int InsertMemberDetails(SqlConnection conMN, MemberDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Select * from MemberDetails where EmailId=@EmailId AND Status!='Deleted'";
            SqlCommand cmdC = new SqlCommand(query, conMN);
            cmdC.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = cat.EmailId;
            SqlDataAdapter sda = new SqlDataAdapter(cmdC);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return -1;
            }

            string cmdText = "Insert Into MemberDetails (PaymentStatus,UserID,UserGuid,FullName,EmailId,Contact,Password,ForgotId,Address,City,State,Country,Pincode,LastLoggedIn,LastLoggedIp,AddedOn,AddedIp,AddedBy,Status,UpdatedOn,UpdatedIp,UpdatedBy,ProfileImage,MedicalSchoolName,GovtID,PassKey,WhoAreYou,Specify,MsgCnt) " +
                "values (@PaymentStatus,@UserID,@UserGuid,@FullName,@EmailId,@Contact,@Password,@ForgotId,@Address,@City,@State,@Country,@Pincode,@LastLoggedIn,@LastLoggedIp,@AddedOn,@AddedIp,@AddedBy,@Status,@UpdatedOn,@UpdatedIp,@UpdatedBy,@ProfileImage,@MedicalSchoolName,@GovtID,@PassKey,@WhoAreYou,@Specify,@MsgCnt) ";
            using (SqlCommand cmd = new SqlCommand(cmdText, conMN))
            {
                cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = cat.UserID;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.UniqueIdentifier).Value = cat.UserGuid;
                cmd.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = cat.FullName;
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = cat.PaymentStatus;
                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = cat.EmailId;
                cmd.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = cat.Contact;
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = cat.Password;
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = cat.ForgotId;
                cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = cat.Address;
                cmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = cat.City;
                cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = cat.State;
                cmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = cat.Country;
                cmd.Parameters.AddWithValue("@Pincode", SqlDbType.NVarChar).Value = cat.Pincode;
                cmd.Parameters.AddWithValue("@LastLoggedIn", SqlDbType.DateTime).Value = cat.LastLoggedIn;
                cmd.Parameters.AddWithValue("@LastLoggedIp", SqlDbType.NVarChar).Value = cat.LastLoggedIp;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@Specify", SqlDbType.NVarChar).Value = cat.Specify;
                cmd.Parameters.AddWithValue("@WhoAreYou", SqlDbType.NVarChar).Value = cat.WhoAreYou;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = cat.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = cat.UpdatedIp;
                cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = cat.UpdatedBy;
                cmd.Parameters.AddWithValue("@ProfileImage", SqlDbType.NVarChar).Value = cat.ProfileImage;
                cmd.Parameters.AddWithValue("@MedicalSchoolName", SqlDbType.NVarChar).Value = cat.MedicalSchoolName;
                cmd.Parameters.AddWithValue("@GovtID", SqlDbType.NVarChar).Value = cat.GovtID;
                cmd.Parameters.AddWithValue("@PassKey", SqlDbType.NVarChar).Value = cat.PassKey;
                cmd.Parameters.AddWithValue("@MsgCnt", SqlDbType.NVarChar).Value = cat.MsgCnt;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertMemberDetails", ex.Message);
        }

        return result;
    }
    public static string GetUserID(SqlConnection _con)
    {
        string MemberId = "";
        try
        {
            string query = "select max(Id) AS MaxMemberId from MemberDetails";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0 && dt.Rows[0]["MaxMemberId"] != DBNull.Value)
                {
                    MemberId = dt.Rows[0]["MaxMemberId"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetUserID", ex.Message);
        }
        return MemberId;
    }
    public static MemberDetails GetMemberDetailsByGuid(SqlConnection conMN, string userguid)
    {
        MemberDetails details = new MemberDetails();
        try
        {
            string query = "select *,(Select Top 1 WLink from WhatsappLink) as Wlink from MemberDetails Where UserGuid=@UserGuid Order by Id Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = userguid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                details = (from DataRow dr in dt.Rows
                           select new MemberDetails()
                           {
                               Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                               UserGuid = Convert.ToString(dr["UserGuid"]),
                               Contact = Convert.ToString(dr["Contact"]),
                               EmailId = Convert.ToString(dr["EmailId"]),
                               UserID = Convert.ToString(dr["UserID"]),
                               FullName = Convert.ToString(dr["FullName"]),
                               Password = Convert.ToString(dr["Password"]),
                               WLink = Convert.ToString(dr["WLink"]),
                               City = Convert.ToString(dr["City"]),
                               ForgotId = Convert.ToString(dr["ForgotId"]),
                               Address = Convert.ToString(dr["Address"]),
                               LastLoggedIn = Convert.ToString(dr["LastLoggedIn"]) != "" ? Convert.ToDateTime(Convert.ToString(dr["LastLoggedIn"])) : Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                               LastLoggedIp = Convert.ToString(dr["LastLoggedIp"]),
                               UpdatedOn = Convert.ToDateTime(Convert.ToString(dr["UpdatedOn"]) != "" ? Convert.ToDateTime(Convert.ToString(dr["UpdatedOn"])) : Convert.ToDateTime(Convert.ToString(dr["AddedOn"]))),
                               UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                               PassKey = Convert.ToString(dr["PassKey"]),
                               GovtID = Convert.ToString(dr["GovtID"]),
                               MedicalSchoolName = Convert.ToString(dr["MedicalSchoolName"]),
                               ProfileImage = Convert.ToString(dr["ProfileImage"]),
                               UpdatedBy = Convert.ToString(dr["UpdatedBy"]),
                               Pincode = Convert.ToString(dr["Pincode"]),
                               State = Convert.ToString(dr["State"]),
                               Country = Convert.ToString(dr["Country"]),
                               Status = Convert.ToString(dr["Status"]),
                               Specify = Convert.ToString(dr["Specify"]),
                               WhoAreYou = Convert.ToString(dr["WhoAreYou"]),
                               MsgCnt = Convert.ToString(dr["MsgCnt"]),
                           }).FirstOrDefault();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMemberDetailsByGuid", ex.Message);
        }
        return details;
    }
    public static int UpdateMemberProfileExcel(SqlConnection conMN, MemberDetails MemberDetails)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update  MemberDetails Set FullName=@FullName,PaymentStatus=@PaymentStatus,City=@City,EmailId=@EmailId,Contact=@Contact,Address=@Address,State=@State,Country=@Country,Pincode=@Pincode,LastLoggedIn=@LastLoggedIn,LastLoggedIp=@LastLoggedIp,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp,UpdatedBy=@UpdatedBy,MedicalSchoolName=@MedicalSchoolName,GovtID=@GovtID Where EmailId=@EmailId and UserId=@UserId", conMN);
            cmd.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = MemberDetails.FullName;
            cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = MemberDetails.UserID;
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = MemberDetails.EmailId;
            cmd.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = MemberDetails.Contact;
            cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = MemberDetails.PaymentStatus;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = MemberDetails.Address;
            cmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = MemberDetails.City;
            cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = MemberDetails.State;
            cmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = MemberDetails.Country;
            cmd.Parameters.AddWithValue("@Pincode", SqlDbType.NVarChar).Value = MemberDetails.Pincode;
            cmd.Parameters.AddWithValue("@LastLoggedIn", SqlDbType.DateTime).Value = MemberDetails.LastLoggedIn;
            cmd.Parameters.AddWithValue("@LastLoggedIp", SqlDbType.NVarChar).Value = MemberDetails.LastLoggedIp;
            cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = MemberDetails.UpdatedOn;
            cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = MemberDetails.UpdatedIp;
            cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = MemberDetails.UpdatedBy;
            cmd.Parameters.AddWithValue("@MedicalSchoolName", SqlDbType.NVarChar).Value = MemberDetails.MedicalSchoolName;
            cmd.Parameters.AddWithValue("@GovtID", SqlDbType.NVarChar).Value = MemberDetails.GovtID;
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateMemberProfile", ex.Message);

        }
        return x;

    }
    public static int UpdateMemberProfile(SqlConnection conMN, MemberDetails MemberDetails)
    {
        int x = 0;
        try
        {
            string query = "Select * from MemberDetails where EmailId=@EmailId and UserGuid != @UserGuid AND Status!='Deleted'";
            SqlCommand cmdC = new SqlCommand(query, conMN);
            cmdC.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = MemberDetails.EmailId;
            cmdC.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = MemberDetails.UserGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmdC);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return -1;
            }

            SqlCommand cmd = new SqlCommand("Update  MemberDetails Set WhoAreYou=@WhoAreYou,Specify=@Specify,FullName=@FullName,PaymentStatus=@PaymentStatus,City=@City,EmailId=@EmailId,Contact=@Contact,Address=@Address,State=@State,Country=@Country,Pincode=@Pincode,LastLoggedIn=@LastLoggedIn,LastLoggedIp=@LastLoggedIp,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp,UpdatedBy=@UpdatedBy,ProfileImage=@ProfileImage,MedicalSchoolName=@MedicalSchoolName,GovtID=@GovtID Where UserGuid=@UserGuid ", conMN);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.UniqueIdentifier).Value = MemberDetails.UserGuid;
            cmd.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = MemberDetails.FullName;
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = MemberDetails.EmailId;
            cmd.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = MemberDetails.Contact;
            cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = MemberDetails.PaymentStatus;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.NVarChar).Value = MemberDetails.Address;
            cmd.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = MemberDetails.City;
            cmd.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = MemberDetails.State;
            cmd.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = MemberDetails.Country;
            cmd.Parameters.AddWithValue("@Pincode", SqlDbType.NVarChar).Value = MemberDetails.Pincode;
            cmd.Parameters.AddWithValue("@LastLoggedIn", SqlDbType.DateTime).Value = MemberDetails.LastLoggedIn;
            cmd.Parameters.AddWithValue("@LastLoggedIp", SqlDbType.NVarChar).Value = MemberDetails.LastLoggedIp;
            cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = MemberDetails.UpdatedOn;
            cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = MemberDetails.UpdatedIp;
            cmd.Parameters.AddWithValue("@UpdatedBy", SqlDbType.NVarChar).Value = MemberDetails.UpdatedBy;
            cmd.Parameters.AddWithValue("@ProfileImage", SqlDbType.NVarChar).Value = MemberDetails.ProfileImage;
            cmd.Parameters.AddWithValue("@MedicalSchoolName", SqlDbType.NVarChar).Value = MemberDetails.MedicalSchoolName;
            cmd.Parameters.AddWithValue("@GovtID", SqlDbType.NVarChar).Value = MemberDetails.GovtID;
            cmd.Parameters.AddWithValue("@Specify", SqlDbType.NVarChar).Value = MemberDetails.Specify;
            cmd.Parameters.AddWithValue("@WhoAreYou", SqlDbType.NVarChar).Value = MemberDetails.WhoAreYou;
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateMemberProfile", ex.Message);

        }
        return x;

    }
    public static string CheckResetLink(SqlConnection conMN, string uid)
    {
        string login = "";
        try
        {
            string query = "Select * from MemberDetails where ForgotId=@ForgotId ";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = uid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                login = Convert.ToString(dt.Rows[0]["UserGuid"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckResetLink", ex.Message);
        }
        return login;
    }
    public static int SetResetTiming(SqlConnection conMN, string resetId, string pwd)
    {
        int x = 0;
        try
        {
            string query = "Update MemberDetails Set ForgotId=@ForgotId,ResetOn=@ResetOn, Password=@Password, passkey=@passkey  where ForgotId=@ForgotId1 ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@ForgotId1", SqlDbType.NVarChar).Value = resetId;
                cmd.Parameters.AddWithValue("@ResetOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = pwd;
                cmd.Parameters.AddWithValue("@passkey", SqlDbType.NVarChar).Value = Guid.NewGuid().ToString();
                conMN.Open();
                x = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SetResetTiming", ex.Message);
        }
        return x;
    }

    public static List<MemberDetails> GetAllMembersCountrisDetails(SqlConnection _con)
    {
        List<MemberDetails> categories = new List<MemberDetails>();
        try
        {
            //string query = "Select Distinct(Country), Count(Id) as cnt from Memberdetails where Status !='Deleted' Group by Country Order by Country;";
            string query = "SELECT Country, (COUNT(ID) * 100.0) / (SELECT COUNT(ID) FROM Memberdetails WHERE Status != 'Deleted') AS Percentage FROM Memberdetails WHERE Status != 'Deleted' GROUP BY Country ORDER BY Percentage desc;";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new MemberDetails()
                              {
                                  Country = Convert.ToString(dr["Country"]),
                                  Percentage = Convert.ToString(dr["Percentage"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllMembersDetails", ex.Message);
        }
        return categories;
    }
    public static List<MemberDetails> GetAllMembersDetails(SqlConnection _con)
    {
        List<MemberDetails> categories = new List<MemberDetails>();
        try
        {
            string query = "Select * from MemberDetails where Status !='Deleted' Order by id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new MemberDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  UserID = Convert.ToString(dr["UserID"]),
                                  UserGuid = Convert.ToString(dr["UserGuid"]),
                                  FullName = Convert.ToString(dr["FullName"]),
                                  EmailId = Convert.ToString(dr["EmailId"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                  Contact = Convert.ToString(dr["Contact"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                                  Password = Convert.ToString(dr["Password"]),

                                  ForgotId = Convert.ToString(dr["ForgotId"]),
                                  Address = Convert.ToString(dr["Address"]),
                                  City = Convert.ToString(dr["City"]),
                                  State = Convert.ToString(dr["State"]),
                                  Country = Convert.ToString(dr["Country"]),
                                  Pincode = Convert.ToString(dr["Pincode"]),
                                  LastLoggedIn = Convert.ToDateTime(dr["LastLoggedIn"]),
                                  LastLoggedIp = Convert.ToString(dr["LastLoggedIp"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                                  UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                                  UpdatedBy = Convert.ToString(dr["UpdatedBy"]),
                                  ProfileImage = Convert.ToString(dr["ProfileImage"]),
                                  PassKey = Convert.ToString(dr["PassKey"]),
                                  MedicalSchoolName = Convert.ToString(dr["MedicalSchoolName"]),
                                  WhoAreYou = Convert.ToString(dr["WhoAreYou"]),
                                  Specify = Convert.ToString(dr["Specify"]),
                                  GovtID = Convert.ToString(dr["GovtID"])

                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllMembersDetails", ex.Message);
        }
        return categories;
    }
    public static string GetDetailsById(SqlConnection conMN, string Id)
    {
        string result = "";

        try
        {
            string query = "select * from MemberDetails where Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var projects = (from DataRow dr in dt.Rows
                                select new MemberDetails()
                                {
                                    Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                    UserID = Convert.ToString(dr["UserID"]),
                                    UserGuid = Convert.ToString(dr["UserGuid"]),
                                    FullName = Convert.ToString(dr["FullName"]),
                                    EmailId = Convert.ToString(dr["EmailId"]),
                                    Contact = Convert.ToString(dr["Contact"]),
                                    Password = Convert.ToString(dr["Password"]),
                                    ForgotId = Convert.ToString(dr["ForgotId"]),
                                    Address = Convert.ToString(dr["Address"]),
                                    City = Convert.ToString(dr["City"]),
                                    State = Convert.ToString(dr["State"]),
                                    Country = Convert.ToString(dr["Country"]),
                                    Pincode = Convert.ToString(dr["Pincode"]),
                                    LastLoggedIn = Convert.ToDateTime(dr["LastLoggedIn"]),
                                    LastLoggedIp = Convert.ToString(dr["LastLoggedIp"]),
                                    UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                                    UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                                    UpdatedBy = Convert.ToString(dr["UpdatedBy"]),
                                    ProfileImage = Convert.ToString(dr["ProfileImage"]),
                                    PassKey = Convert.ToString(dr["PassKey"]),
                                    MedicalSchoolName = Convert.ToString(dr["MedicalSchoolName"]),
                                    GovtID = Convert.ToString(dr["GovtID"]),
                                    AddedIp = Convert.ToString(dr["AddedIp"]),
                                    AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                    AddedBy = Convert.ToString(dr["AddedBy"]),
                                    WhoAreYou = Convert.ToString(dr["WhoAreYou"]),
                                    Specify = Convert.ToString(dr["Specify"]),
                                    Status = Convert.ToString(dr["Status"])
                                }).FirstOrDefault();

                result = JsonConvert.SerializeObject(projects);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsById", ex.Message);
        }

        return result;
    }
    public static string CheckPassword(SqlConnection conMN, string cPassword, string uGuid)
    {
        string res = "";
        try
        {

            SqlCommand cmdUpdate = new SqlCommand("Select * from MemberDetails Where Password=@Password and UserGuid=@UserGuid ", conMN);
            cmdUpdate.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            cmdUpdate.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = cPassword;
            SqlDataAdapter sda = new SqlDataAdapter(cmdUpdate);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            res = dt.Rows.Count > 0 ? "Success" : "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ChangePassword", ex.Message);
            res = ex.Message;
        }
        return res;
    }
    public static string PasswordReset(SqlConnection conMN, string cPassword, string uGuid)
    {
        string res = "";
        try
        {

            SqlCommand cmdUpdate = new SqlCommand("Update MemberDetails Set Password=@Password Where UserGuid=@UserGuid ", conMN);
            cmdUpdate.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            cmdUpdate.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = cPassword;
            conMN.Open();
            int exec = cmdUpdate.ExecuteNonQuery();
            conMN.Close();
            res = exec > 0 ? "Success" : "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ChangePassword", ex.Message);
            res = ex.Message;
        }
        return res;
    }
    public static int DeleteMember(SqlConnection conMN, MemberDetails Partner)
    {
        int result = 0;
        try
        {
            string cmdText = "Update MemberDetails Set Status=@Status, UpdatedOn=@UpdatedOn, UpdatedIp=@UpdatedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(cmdText, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Partner.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Partner.Status;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = Partner.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = Partner.UpdatedIp;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteMembers", ex.Message);
        }

        return result;
    }
    public static int UpdateMemberASVerified(SqlConnection conMN, MemberDetails Partner)
    {
        int result = 0;
        try
        {
            string cmdText = "Update MemberDetails Set Status=@Status,PaymentStatus=@PaymentStatus, UpdatedOn=@UpdatedOn, UpdatedIp=@UpdatedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(cmdText, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Partner.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Partner.Status;
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = Partner.PaymentStatus;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = Partner.UpdatedOn;
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = Partner.UpdatedIp;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteMembers", ex.Message);
        }

        return result;
    }
    public static int UpdateAsBlocked(SqlConnection conMN, string uGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update MemberDetails Set Status='Blocked' Where UserGuid=@UserGuid", conMN);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateAsBlocked", ex.Message);
        }
        return x;
    }
    public static int UpdateAsUnBlocked(SqlConnection conMN, string uGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update MemberDetails Set Status='Unverified' Where UserGuid=@UserGuid", conMN);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateAsUnBlocked", ex.Message);
        }
        return x;
    }
    public static int UpdateAsVerifed(SqlConnection conMN, string uGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update MemberDetails Set Status='Verified' Where UserGuid=@UserGuid", conMN);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RegisterUser", ex.Message);
        }
        return x;
    }
    public static string CheckPasswordForgotId(SqlConnection conMN, string ForgotId)
    {
        string res = "";
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select UserGuid from MemberDetails where ForgotId=@ForgotId", conMN);
            cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = ForgotId;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = Convert.ToString(dt.Rows[0]["UserGuid"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckPasswordForgotId", ex.Message);
        }
        return res;
    }
    public static string GetPasswordWithUserGuid(SqlConnection conMN, string mGuid)
    {
        string res = "";
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Password from MemberDetails where UserGuid=@Guid", conMN);
            cmd.Parameters.AddWithValue("@PartnerGuid", SqlDbType.NVarChar).Value = mGuid;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = Convert.ToString(dt.Rows[0]["Password"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckPasswordForgotId", ex.Message);
        }
        return res;
    }



    public static List<MemberDetails> GetFilteredMembersDetails(SqlConnection _con, string key, string sdate, string edate, string status, string pstatus)
    {
        List<MemberDetails> categories = new List<MemberDetails>();
        try
        {

            var querypart = "";
            if (sdate != "" & edate != "")
            {
                querypart += " AND (Try_Convert(date,AddedOn) between @Sdate AND @Edate)";
            }
            if (status != "")
            {
                querypart += " AND Status = @Status";
            }
            if (pstatus != "")
            {
                querypart += " AND PaymentStatus = @PStatus";
            }
            string query = "Select *,(select Count(Id) from MemberDetails where Status != 'Deleted') as TotalMembers from MemberDetails md where Status !='Deleted' AND (@key =''  OR md.FullName Like '%'+@Key+'%' OR md.Contact Like '%'+@Key+'%' OR md.EmailId Like '%'+@Key+'%') " + querypart + @"  Order by id desc";



            SqlCommand cmd = new SqlCommand(query, _con);
            cmd.Parameters.AddWithValue("@key", SqlDbType.NVarChar).Value = key;
            cmd.Parameters.AddWithValue("@Sdate", SqlDbType.NVarChar).Value = sdate;
            cmd.Parameters.AddWithValue("@Edate", SqlDbType.NVarChar).Value = edate;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.AddWithValue("@PStatus", SqlDbType.NVarChar).Value = pstatus;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            categories = (from DataRow dr in dt.Rows
                          select new MemberDetails()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              UserID = Convert.ToString(dr["UserID"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              FullName = Convert.ToString(dr["FullName"]),
                              EmailId = Convert.ToString(dr["EmailId"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                              Contact = Convert.ToString(dr["Contact"]),
                              Status = Convert.ToString(dr["Status"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              Password = Convert.ToString(dr["Password"]),
                              MsgCnt = Convert.ToString(dr["MsgCnt"]),
                              ForgotId = Convert.ToString(dr["ForgotId"]),
                              Address = Convert.ToString(dr["Address"]),
                              City = Convert.ToString(dr["City"]),
                              State = Convert.ToString(dr["State"]),
                              Country = Convert.ToString(dr["Country"]),
                              Pincode = Convert.ToString(dr["Pincode"]),
                              LastLoggedIn = Convert.ToDateTime(dr["LastLoggedIn"]),
                              LastLoggedIp = Convert.ToString(dr["LastLoggedIp"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                              UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                              UpdatedBy = Convert.ToString(dr["UpdatedBy"]),
                              ProfileImage = Convert.ToString(dr["ProfileImage"]),
                              PassKey = Convert.ToString(dr["PassKey"]),
                              MedicalSchoolName = Convert.ToString(dr["MedicalSchoolName"]),
                              WhoAreYou = Convert.ToString(dr["WhoAreYou"]),
                              Specify = Convert.ToString(dr["Specify"]),
                              TotalMembers = Convert.ToString(dr["TotalMembers"]),
                              GovtID = Convert.ToString(dr["GovtID"])

                          }).ToList();

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetFilteredMembersDetails", ex.Message);
        }
        return categories;
    }
    public static int SetForgotId(SqlConnection conMN, string uid, string fId)
    {
        int x = 0;
        try
        {
            using (SqlCommand cmd = new SqlCommand("Update MemberDetails Set ForgotId=@ForgotId.UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp where UserGuid=@UserGuid ", conMN))
            {
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uid;
                cmd.Parameters.AddWithValue("@ForgotId", SqlDbType.NVarChar).Value = fId;
                cmd.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conMN.Open();
                x = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateLastLogDetails", ex.Message);
        }
        return x;
    }


    public static int UpdateMsgCount(SqlConnection conGV, string Guid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update MemberDetails Set MsgCnt = Try_Convert(int, ISNULL(MsgCnt, 0)) + 1 Where UserGuid=@UserGuid", conGV);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = Guid;
            conGV.Open();
            x = cmd1.ExecuteNonQuery();
            conGV.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BlockVenue", ex.Message);
        }
        return x;
    }

    //public static int deleteMemberdetails(sqlconnection conMN, MemberDetails cat)
    //{
    //    int result = 0;
    //    try
    //    {
    //        string query = "update memberdetails set status=@status, where id=@id ";
    //        using (sqlcommand cmd = new sqlcommand(query, conMN))
    //        {
    //            cmd.parameters.addwithvalue("@id", sqldbtype.nvarchar).value = cat.id;
    //            cmd.parameters.addwithvalue("@status", sqldbtype.nvarchar).value = "deleted";
    //            _con.open();
    //            result = cmd.executenonquery();
    //            _con.close();
    //        }
    //    }
    //    catch (exception ex)
    //    {
    //        exceptioncapture.captureexception(httpcontext.current.request.url.pathandquery, "deletememberdetails", ex.message);
    //    }
    //    return result;
    //}

    public static DataTable GetProjectMembers(SqlConnection _conn, string p_guid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT m.UserGuid,o.OrderGuid, m.UserID, m.FullName, m.EmailId, m.Contact FROM POrders o inner JOIN MemberDetails m ON m.UserGuid = o.UserGuid WHERE o.ProjectGuid = @project_guid AND o.Status != 'Deleted' and o.orderstatus='completed'";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@project_guid", SqlDbType.NVarChar).Value = p_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectMembers", ex.Message);
        }
        return dt;
    }

    public static List<MemberDetails> GetAllMembersList(SqlConnection _conn)
    {
        var categories = new List<MemberDetails>();
        try
        {
            var query = "Select FullName,UserID,USerGuid from MemberDetails where Status !='Deleted' Order by id desc";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new MemberDetails()
                              {
                                  UserGuid = Convert.ToString(dr["UserGuid"]),
                                  FullName = Convert.ToString(dr["FullName"]) + " (" + Convert.ToString(dr["UserID"]) + @")",
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllMembersList", ex.Message);
        }
        return categories;
    }
}
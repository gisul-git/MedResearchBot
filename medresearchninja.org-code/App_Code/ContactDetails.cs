using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactDetails
/// </summary>
public class ContactDetails
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string EmailAdress { get; set; }
    public string Phone { get; set; }
    public string Company { get; set; }
    public string Message { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string pageurl { get; set; }
    public static int InsertContactDetails(SqlConnection _con, ContactDetails cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into ContactDetails (Fullname, EmailAdress, Phone, Company, Message, Status, pageurl,SubmissionDate) values (@Fullname,@EmailAdress,@Phone,@Company,@Message,@Status,@pageurl,@SubmissionDate) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                
                cmd.Parameters.AddWithValue("@Fullname", SqlDbType.NVarChar).Value = cat.Fullname;
                cmd.Parameters.AddWithValue("@EmailAdress", SqlDbType.NVarChar).Value = cat.EmailAdress;
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = cat.Phone;
                cmd.Parameters.AddWithValue("@Company", SqlDbType.NVarChar).Value = cat.Company;
                cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = cat.Message;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@pageurl", SqlDbType.NVarChar).Value = cat.pageurl;
                cmd.Parameters.AddWithValue("@SubmissionDate", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertContactDetails", ex.Message);
        }
        return result;
    }
    public static List<ContactDetails> GetAllContactDetails(SqlConnection _con)
    {
        List<ContactDetails> categories = new List<ContactDetails>();
        try
        {
            string query = "Select * from ContactDetails  where Status !='Deleted'";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new ContactDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Fullname = Convert.ToString(dr["Fullname"]),
                                  EmailAdress = Convert.ToString(dr["EmailAdress"]),
                                  Phone = Convert.ToString(dr["Phone"]),
                                  Company = Convert.ToString(dr["Company"]),
                                  SubmissionDate = Convert.ToDateTime(dr["SubmissionDate"]),
                                  Message = Convert.ToString(dr["Message"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  pageurl = Convert.ToString(dr["pageurl"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllContactDetails", ex.Message);
        }
        return categories;
    }
    public static int DeleteContactDetails(SqlConnection _con, ContactDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update ContactDetails Set Status=@Status, Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteContactDetails", ex.Message);
        }
        return result;
    }
}

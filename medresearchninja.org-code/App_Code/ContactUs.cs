using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactUs
/// </summary>
public class ContactUs
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string EmailAdress { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }
    public string pageurl { get; set; }

    public static int InsertContactUs(SqlConnection _con, ContactUs cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into ContactUs (Fullname, EmailAdress, Phone, Message, AddedOn,AddedIp,Status,pageurl) values (@Fullname, @EmailAdress, @Phone, @Message, @AddedOn,@AddedIp,@Status,@pageurl ) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {

                cmd.Parameters.AddWithValue("@Fullname", SqlDbType.NVarChar).Value = cat.Fullname;
                cmd.Parameters.AddWithValue("@EmailAdress", SqlDbType.NVarChar).Value = cat.EmailAdress;
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.NVarChar).Value = cat.Phone;
                cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = cat.Message;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@pageurl", SqlDbType.NVarChar).Value = cat.pageurl;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertContactUs", ex.Message);
        }
        return result;
    }
    public static List<ContactUs> GetAllContactUs(SqlConnection _con)
    {
        List<ContactUs> categories = new List<ContactUs>();
        try
        {
            string query = "Select top 10 * from ContactUs where Status !='Deleted' order by Id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new ContactUs()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Fullname = Convert.ToString(dr["Fullname"]),
                                  EmailAdress = Convert.ToString(dr["EmailAdress"]),
                                  Phone = Convert.ToString(dr["Phone"]),
                                  Message = Convert.ToString(dr["Message"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                  pageurl = Convert.ToString(dr["pageurl"])

                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllContactUs", ex.Message);
        }
        return categories;
    }
    public static int DeleteContactUs(SqlConnection _con, ContactUs cat)
    {
        int result = 0;
        try
        {
            string query = "Update ContactUs Set Status=@Status Where Id=@Id";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteContactUs", ex.Message);
        }
        return result;
    }
    public static string GetMessageById(SqlConnection conMN, string id)
    {
        string result = null;
        try
        {
            string cmdText = "select Message from ContactUs WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                conMN.Open();
                object obj = sqlCommand.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = obj.ToString();
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMessageById", ex.Message);
        }
        finally
        {
            if (conMN.State == ConnectionState.Open)
            {
                conMN.Close();
            }
        }

        return result;
    }

}
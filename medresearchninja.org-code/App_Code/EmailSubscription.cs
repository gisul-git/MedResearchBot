using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmailSubscription
/// </summary>
public class EmailSubscription
{
    public int Id { get; set; }
    public string EmailId { get; set; }
    public string Status { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }

    public static List<EmailSubscription> GetMails(SqlConnection conMN)
    {
        List<EmailSubscription> categories = new List<EmailSubscription>();
        try
        {
            string query = "Select * from EmailSubscription where Status='Active'";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new EmailSubscription()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  EmailId = Convert.ToString(dr["EmailId"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMails", ex.Message);
        }
        return categories;
    }
    public static int InsertEmailSubscription(SqlConnection conMN, EmailSubscription subscription)
    {
        int result = 0;
        try
        {
            string query = "insert into EmailSubscription (EmailId, Status, AddedOn, AddedIp) values (@EmailId, @Status, @AddedOn, @AddedIp)";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@EmailId", subscription.EmailId);
                cmd.Parameters.AddWithValue("@Status", subscription.Status);
                cmd.Parameters.AddWithValue("@AddedOn", subscription.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", subscription.AddedIp);

                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertEmailSubscription", ex.Message);
        }

        return result;
    }
    public static List<EmailSubscription> GetAllSubscribers(SqlConnection _con)
    {
        List<EmailSubscription> categories = new List<EmailSubscription>();
        try
        {
            string query = "Select * from EmailSubscription where Status!='Deleted' order by Id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new EmailSubscription()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  EmailId = Convert.ToString(dr["EmailId"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllSubscribers", ex.Message);
        }
        return categories;
    }
    public static int DeleteSubscribers(SqlConnection _con, EmailSubscription cat)
    {
        int result = 0;
        try
        {
            string query = "Update EmailSubscription Set Status=@Status Where Id=@Id";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteSubscribers", ex.Message);
        }
        return result;
    }


}


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LikesCount
/// </summary>
public class LikesCount
{
    public string UserGuid { get; set; }
    public string MessageGuid { get; set; }
    public DateTime AddedOn { set; get; }
    public string AddedIp { set; get; }


    public static int GetLikeStatus(SqlConnection _conn, string MessageGuid,string UserGuid)
    {
        int count = 0;
        try
        {
            string query = "select Count(Id) as cntL from LikesCount where MessageGuid=@MessageGuid and UserGuid=@UserGuid";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = UserGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int.TryParse(Convert.ToString(dt.Rows[0]["cntL"]), out count);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetLikeStatus", ex.Message);
        }
        return count;
    }

    public static int InsertLikes(SqlConnection conMN, LikesCount cat)
    {
        int result = 0;
        try
        {
            string query = "Insert Into LikesCount (MessageGuid,UserGuid,AddedOn,AddedIp) values (@MessageGuid,@UserGuid,@AddedOn,@AddedIp)";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = cat.MessageGuid;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = cat.UserGuid;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertLikes", ex.Message);
        }
        return result;
    }


    public static int DeleteLikes(SqlConnection conMN, string UserGuid, string MessageGuid)
    {
        int result = 0;
        try
        {
            string query = "delete from LikesCount Where UserGuid=@UserGuid and MessageGuid=@MessageGuid";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = UserGuid;
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteLikes", ex.Message);
        }
        return result;
    }
}
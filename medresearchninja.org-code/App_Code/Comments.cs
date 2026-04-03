using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comments
/// </summary>
public class Comments
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string UserGuid { get; set; }
    public int LikeCount { get; set; }
    public string PageUrl { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public DateTime AddedOn { get; set; }
    public string MessageGuid { get; set; }
    public string Status { get; set; }

    public static int InsertComments(SqlConnection conMN, Comments cmt)
    {
        int result = 0;
        try
        {
            string query = "insert into Comments (Message,UserGuid, AddedBy,LikeCount,Status, AddedOn, AddedIp,MessageGuid,PageUrl) values (@Message,@UserGuid,@AddedBy,@LikeCount, @Status, @AddedOn, @AddedIp, @MessageGuid,@PageUrl)";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Message", cmt.Message);
                cmd.Parameters.AddWithValue("@UserGuid", cmt.UserGuid);
                cmd.Parameters.AddWithValue("@Status", cmt.Status);
                cmd.Parameters.AddWithValue("@LikeCount", cmt.LikeCount);
                cmd.Parameters.AddWithValue("@MessageGuid", cmt.MessageGuid);
                cmd.Parameters.AddWithValue("@AddedBy", cmt.AddedBy);
                cmd.Parameters.AddWithValue("@AddedOn", cmt.AddedOn);
                cmd.Parameters.AddWithValue("@PageUrl", cmt.PageUrl);
                cmd.Parameters.AddWithValue("@AddedIp", cmt.AddedIp);

                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertComments", ex.Message);
        }

        return result;
    }


    public static List<Forums> GetForumsComments(SqlConnection _con, string PageNo, string PLenght, string Key, string uid)
    {
        List<Forums> frm = new List<Forums>();
        try
        {
            string query = "select c.*, f.Title from comments c inner join forums f ON c.MessageGuid = f.MessageGuid where c.MessageGuid = f.MessageGuid and c.status !='Deleted' and (@Key='' or Title Like '%'+@Key+'%') order by id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Key", SqlDbType.NVarChar).Value = Key;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                frm = (from DataRow dr in dt.Rows
                       select new Forums()
                       {
                           Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                           Title = Convert.ToString(dr["Title"]),
                           Message = Convert.ToString(dr["Message"]),
                           UserGuid = Convert.ToString(dr["UserGuid"]),
                           MessageGuid = Convert.ToString(dr["MessageGuid"]),
                           AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                           Status = Convert.ToString(dr["Status"])
                       }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetForumsComments", ex.Message);
        }
        return frm;
    }


    public static List<Comments> GetAllCommentsDetails(SqlConnection _con, string MessageGuid)
    {
        List<Comments> categories = new List<Comments>();
        try
        {
            string query = "Select * from Comments where Status=@Status and MessageGuid=@MessageGuid Order by Id Desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", MessageGuid);
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Comments()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Message = Convert.ToString(dr["Message"]),
                                  LikeCount = Convert.ToInt32(dr["LikeCount"]),
                                  UserGuid = Convert.ToString(dr["UserGuid"]),
                                  MessageGuid = Convert.ToString(dr["MessageGuid"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCommentsDetails", ex.Message);
        }
        return categories;
    }

    //status change

    public static int UpdateComments(SqlConnection conMN, Comments user)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update Comments Set Status=@Status Where Id=@Id", conMN);
            cmd1.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = user.Id;
            cmd1.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = user.Status;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateComments", ex.Message);
        }
        return x;
    }

    public static List<Comments> BindMyComments(SqlConnection conMN, string userGuid)
    {

        List<Comments> result = new List<Comments>();
        try
        {
            string cmdText = "select * from Comments where UserGuid = @userGuid and Status!='Deleted'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@userGuid", SqlDbType.NVarChar).Value = userGuid;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Comments
                          {
                              Message = Convert.ToString(dr["Message"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                              PageUrl = Convert.ToString(dr["PageUrl"]),
                              Status = Convert.ToString(dr["Status"]),
                              MessageGuid = Convert.ToString(dr["MessageGuid"])
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindMyComments", ex.Message);
        }

        return result;
    }




    //public static decimal getNoOfComments(SqlConnection conMN, string messageGuid)
    //{
    //    decimal count = 0;
    //    try
    //    {
    //        if (conMN.State == ConnectionState.Closed)
    //        {
    //            conMN.Open();
    //        }
    //        string query = "select count(Id) as cntB from Comments WHERE MessageGuid = @MessageGuid";
    //        using (SqlCommand cmd = new SqlCommand(query, conMN))
    //        {
    //            cmd.Parameters.AddWithValue("@MessageGuid", messageGuid);

    //            object result = cmd.ExecuteScalar();
    //            if (result != null && result != DBNull.Value)
    //            {
    //                count = Convert.ToDecimal(result);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "getNoOfComments", ex.Message);
    //    }
    //    finally
    //    {
    //        if (conMN.State == ConnectionState.Open)
    //        {
    //            conMN.Close();
    //        }
    //    }
    //    return count;
    //}

}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NoticeBoard
/// </summary>
public class NoticeBoard
{
    public int Id { get; set; }

    public string NoticeTitle { get; set; }
    public string NoticeUrl { get; set; }


    public string Status { get; set; }

    public string AddedIP { get; set; }

    public DateTime AddedOn { get; set; }

    public string AddedBy { get; set; }



    public static int InsertNoticeBoard(SqlConnection conMN, NoticeBoard cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into NoticeBoard (NoticeTitle,NoticeUrl,Status,AddedIP,AddedOn,AddedBy) values(@NoticeTitle,@NoticeUrl,@Status,@AddedIP,@AddedOn,@AddedBy) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@NoticeTitle", SqlDbType.NVarChar).Value = cat.NoticeTitle;
                sqlCommand.Parameters.AddWithValue("@NoticeUrl", SqlDbType.NVarChar).Value = cat.NoticeUrl;
                sqlCommand.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertNoticeBoard", ex.Message);
        }

        return result;
    }
    public static int UpdateNoticeBoard(SqlConnection conMN, NoticeBoard cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update NoticeBoard Set NoticeTitle=@NoticeTitle,NoticeUrl=@NoticeUrl,Status=@Status where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@NoticeTitle", SqlDbType.NVarChar).Value = cat.NoticeTitle;
                sqlCommand.Parameters.AddWithValue("@NoticeUrl", SqlDbType.NVarChar).Value = cat.NoticeUrl;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateNoticeBoard", ex.Message);
        }

        return result;
    }
    public static List<NoticeBoard> GetAllNoticeBoard(SqlConnection conMN)
    {
        List<NoticeBoard> result = new List<NoticeBoard>();
        try
        {
            string cmdText = "Select * from NoticeBoard where Status='Active'";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new NoticeBoard
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              NoticeTitle = Convert.ToString(dr["NoticeTitle"]),
                              NoticeUrl = Convert.ToString(dr["NoticeUrl"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllNoticeBoard", ex.Message);
        }

        return result;
    }

    public static decimal NoOfNotice(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from NoticeBoard Where  Status != 'Deleted'";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfNotice", ex.Message);
        }
        return x;
    }
    public static List<NoticeBoard> GetNoticeBoard(SqlConnection conMN, int id)
    {
        List<NoticeBoard> result = new List<NoticeBoard>();
        try
        {
            string cmdText = "Select * from NoticeBoard where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new NoticeBoard
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              NoticeTitle = Convert.ToString(dr["NoticeTitle"]),
                              NoticeUrl = Convert.ToString(dr["NoticeUrl"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetNoticeBoard", ex.Message);
        }

        return result;
    }


    public static int DeleteNoticeBoard(SqlConnection conMN, NoticeBoard cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update NoticeBoard Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteNoticeBoard", ex.Message);
        }

        return result;
    }


    public static List<NoticeBoard> BindNoticeBoard(SqlConnection conMN)
    {
        List<NoticeBoard> result = new List<NoticeBoard>();
        try
        {
            string cmdText = "Select NoticeTitle,NoticeUrl from NoticeBoard where Status=@Status Order by Id Desc;";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {

                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new NoticeBoard
                          {
                              NoticeTitle = Convert.ToString(dr["NoticeTitle"]),
                              NoticeUrl = Convert.ToString(dr["NoticeUrl"]),
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindNoticeBoard", ex.Message);
        }

        return result;
    }




}
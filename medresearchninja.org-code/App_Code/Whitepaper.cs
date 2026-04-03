using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Whitepaper
/// </summary>
public class Whitepaper
{
    public int Id { get; set; }

    public string ThumbImage { get; set; }

    public string Title { get; set; }

    public string PDFFile { get; set; }

    public string Status { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string AddedBy { get; set; }



    public static int InsertWhitepaper(SqlConnection conMN, Whitepaper cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into Whitepaper (ThumbImage,Title,PDFFile,AddedIP,AddedOn,AddedBy,Status) values(@ThumbImage,@Title,@PDFFile,@AddedIP,@AddedOn,@AddedBy,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = cat.Title;
                sqlCommand.Parameters.AddWithValue("@PDFFile", SqlDbType.NVarChar).Value = cat.PDFFile;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertWhitepaper", ex.Message);
        }

        return result;
    }
    public static int UpdateWhitepaper(SqlConnection conMN, Whitepaper cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Whitepaper Set ThumbImage=@ThumbImage,Title=@Title,PDFFile=@PDFFile,Status=@Status where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = cat.Title;
                sqlCommand.Parameters.AddWithValue("@PDFFile", SqlDbType.NVarChar).Value = cat.PDFFile;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateWhitepaper", ex.Message);
        }

        return result;
    }

    public static List<Whitepaper> GetAllWhitepaper(SqlConnection conMN)
    {
        List<Whitepaper> result = new List<Whitepaper>();
        try
        {
            string cmdText = "Select * from Whitepaper where Status='Active'";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Whitepaper
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              ThumbImage = Convert.ToString(dr["ThumbImage"]),
                              PDFFile = Convert.ToString(dr["PDFFile"]),
                             Title = Convert.ToString(dr["Title"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindNoticeBoard", ex.Message);
        }

        return result;
    }

    public static List<Whitepaper> GetWhitepaper(SqlConnection conMN, int id)
    {
        List<Whitepaper> result = new List<Whitepaper>();
        try
        {
            string cmdText = "Select * from Whitepaper where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Whitepaper
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                             Title = Convert.ToString(dr["Title"]),
                              ThumbImage = Convert.ToString(dr["ThumbImage"]),
                              PDFFile = Convert.ToString(dr["PDFFile"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetWhitepaper", ex.Message);
        }

        return result;
    }
    public static int DeleteWhitepaper(SqlConnection conMN, Whitepaper cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Whitepaper Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteWhitepaper", ex.Message);
        }

        return result;
    }


    public static List<Whitepaper> BindWhitepaper(SqlConnection conMN)
    {
        List<Whitepaper> result = new List<Whitepaper>();
        try
        {
            string cmdText = "Select * from Whitepaper where Status=@Status Order by Id Desc";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {

                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Whitepaper
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              ThumbImage = Convert.ToString(dr["ThumbImage"]),
                              PDFFile = Convert.ToString(dr["PDFFile"]),
                              Title = Convert.ToString(dr["Title"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindWhitepaper", ex.Message);
        }

        return result;
    }


}
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Office2010.Excel;

/// <summary>
/// Summary description for Portfolio
/// </summary>
public class Portfolio
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string PaymentStatus { get; set; }
    public string UserGuid { get; set; }
    public string ResourceType { get; set; }
    public string Link { get; set; }
    public string UploadPdf { get; set; }
    public DateTime AddedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }


    public static int InsertPortfolio(SqlConnection conMN, Portfolio cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into ResearchPortfolio (Title,PaymentStatus,UserGuid,ResourceType,Link,UpdatedOn,UploadPdf,Status,AddedIp,AddedOn,AddedBy) values(@Title,@PaymentStatus,@UserGuid,@ResourceType,@Link,@UpdatedOn,@UploadPdf,@Status,@AddedIp,@AddedOn,@AddedBy) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = cat.Title;
                sqlCommand.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = cat.UserGuid;
                sqlCommand.Parameters.AddWithValue("@ResourceType", SqlDbType.NVarChar).Value = cat.ResourceType;
                sqlCommand.Parameters.AddWithValue("@Link", SqlDbType.NVarChar).Value = cat.Link;
                sqlCommand.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = cat.PaymentStatus;
                sqlCommand.Parameters.AddWithValue("@UploadPdf", SqlDbType.NVarChar).Value = cat.UploadPdf;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = cat.UpdatedOn;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertPortfolio", ex.Message);
        }

        return result;
    }
    public static int UpdatePortfolio(SqlConnection conMN, Portfolio cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update ResearchPortfolio Set Title=@Title,ResourceType=@ResourceType,PaymentStatus=@PaymentStatus,Link=@Link, AddedIp=@AddedIp,UpdatedOn=@UpdatedOn,UploadPdf=@UploadPdf where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = cat.Title;
                sqlCommand.Parameters.AddWithValue("@ResourceType", SqlDbType.NVarChar).Value = cat.ResourceType;
                sqlCommand.Parameters.AddWithValue("@Link", SqlDbType.NVarChar).Value = cat.Link;
                sqlCommand.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = cat.PaymentStatus;
                sqlCommand.Parameters.AddWithValue("@UploadPdf", SqlDbType.NVarChar).Value = cat.UploadPdf;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@UpdatedOn", SqlDbType.NVarChar).Value = cat.UpdatedOn;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdatePortfolio", ex.Message);
        }

        return result;
    }

    public static List<Portfolio> GetPortfolio(SqlConnection conMN, int id)
    {
        List<Portfolio> result = new List<Portfolio>();
        try
        {
            string cmdText = "Select * from ResearchPortfolio where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Portfolio
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Title = Convert.ToString(dr["Title"]),
                              Link = Convert.ToString(dr["Link"]),
                              UploadPdf = Convert.ToString(dr["UploadPdf"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              ResourceType = Convert.ToString(dr["ResourceType"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetPortfolio", ex.Message);
        }

        return result;
    }


    public static List<Portfolio> GetAllPortfolio(SqlConnection conMN ,string UserGuid)
    {
        List<Portfolio> result = new List<Portfolio>();
        try
        {
            string cmdText = "Select * from ResearchPortfolio where Status='Active' and UserGuid=@UserGuid Order by Id desc";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                selectCommand.Parameters.AddWithValue("@UserGuid", SqlDbType.Int).Value = UserGuid;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Portfolio
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Title = Convert.ToString(dr["Title"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              Link = Convert.ToString(dr["Link"]),
                              UploadPdf = Convert.ToString(dr["UploadPdf"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              UpdatedOn = Convert.ToDateTime(Convert.ToString(dr["UpdatedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllPortfolio", ex.Message);
        }

        return result;
    }
    public static int DeletePortfolio(SqlConnection conMN, Portfolio cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update ResearchPortfolio Set Status=@Status Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeletePortfolio", ex.Message);
        }

        return result;
    }

}
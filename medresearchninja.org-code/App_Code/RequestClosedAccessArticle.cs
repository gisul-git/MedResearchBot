using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequestClosedAccessArticle
/// </summary>
public class RequestClosedAccessArticle
{
    public RequestClosedAccessArticle()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string EmailID { get; set; }
    public string FirstAuthorName { get; set; }
    public string Title { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }


    public static int InsertRequestClosedAccessArticle(SqlConnection conMN, RequestClosedAccessArticle req)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into [request-closed-access-article] (Name,ContactNumber,EmailID,FirstAuthorName,Title,AddedOn,AddedIp,AddedBy,Status) values(@Name,@ContactNumber,@EmailID,@FirstAuthorName,@Title,@AddedOn,@AddedIp,@AddedBy,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = req.Name;
                sqlCommand.Parameters.AddWithValue("@ContactNumber", SqlDbType.NVarChar).Value = req.ContactNumber;
                sqlCommand.Parameters.AddWithValue("@EmailID", SqlDbType.NVarChar).Value = req.EmailID;
                sqlCommand.Parameters.AddWithValue("@FirstAuthorName", SqlDbType.NVarChar).Value = req.FirstAuthorName;
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = req.Title;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = req.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = req.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = req.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = req.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertRequestClosedAccessArticle", ex.Message);
        }

        return result;
    }

    public static int UpdateRequestClosedAccessArticle(SqlConnection conMN, RequestClosedAccessArticle req)
    {
        int result = 0;
        try
        {
            string cmdText = "Update [request-closed-access-article] Set Name=@Name,ContactNumber=@ContactNumber,EmailID=@EmailID,FirstAuthorName=@FirstAuthorName,Title=@Title,AddedIp=@AddedIp,Status=@Status where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = req.Id;
                sqlCommand.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = req.Name;
                sqlCommand.Parameters.AddWithValue("@ContactNumber", SqlDbType.NVarChar).Value = req.ContactNumber;
                sqlCommand.Parameters.AddWithValue("@EmailID", SqlDbType.NVarChar).Value = req.EmailID;
                sqlCommand.Parameters.AddWithValue("@FirstAuthorName", SqlDbType.NVarChar).Value = req.FirstAuthorName;
                sqlCommand.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = req.Title;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = req.AddedIp;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = req.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateRequestClosedAccessArticle", ex.Message);
        }

        return result;
    }

    public static List<RequestClosedAccessArticle> GetRequestClosedAccessArticle(SqlConnection conMN, int id)
    {
        List<RequestClosedAccessArticle> result = new List<RequestClosedAccessArticle>();
        try
        {
            string cmdText = "Select * from [request-closed-access-article] where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new RequestClosedAccessArticle
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Name = Convert.ToString(dr["Name"]),
                              ContactNumber = Convert.ToString(dr["ContactNumber"]),
                              EmailID = Convert.ToString(dr["EmailID"]),
                              FirstAuthorName = Convert.ToString(dr["FirstAuthorName"]),
                              Title = Convert.ToString(dr["Title"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetRequestClosedAccessArticle", ex.Message);
        }

        return result;
    }


    public static List<RequestClosedAccessArticle> GetAllRequestClosedAccessArticle(SqlConnection conMN)
    {
        List<RequestClosedAccessArticle> result = new List<RequestClosedAccessArticle>();
        try
        {
            string cmdText = "Select * from [request-closed-access-article] where Status='Active' Order by Id desc";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new RequestClosedAccessArticle
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Name = Convert.ToString(dr["Name"]),
                              ContactNumber = Convert.ToString(dr["ContactNumber"]),
                              EmailID = Convert.ToString(dr["EmailID"]),
                              FirstAuthorName = Convert.ToString(dr["FirstAuthorName"]),
                              Title = Convert.ToString(dr["Title"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllRequestClosedAccessArticle", ex.Message);
        }

        return result;
    }

    public static int DeleteRequestClosedAccessArticle(SqlConnection conMN, RequestClosedAccessArticle req)
    {
        int result = 0;
        try
        {
            string cmdText = "Update [request-closed-access-article] Set Status=@Status Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = req.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteRequestClosedAccessArticle", ex.Message);
        }

        return result;
    }
}
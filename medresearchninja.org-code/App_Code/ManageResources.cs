using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ManageResources
/// </summary>
public class ManageResources
{

    public int  Id { get; set; }

    public string  ThumbImage{  get; set; }
    public string  Category{  get; set; }
   
    public string  ProjectTitle{  get; set; }

    public string  PDFFile{  get; set; }

    public string  Status {  get; set; }
	public DateTime AddedOn { get; set; }
    public string  AddedIP { get; set; }
    public string  AddedBy { get; set; }


    public static int InsertResources(SqlConnection conMN, ManageResources cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into Resources (ThumbImage,Category,ProjectTitle,PDFFile,AddedIP,AddedOn,AddedBy,Status) values(@ThumbImage,@Category,@ProjectTitle,@PDFFile,@AddedIP,@AddedOn,@AddedBy,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                sqlCommand.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = cat.Category;
                sqlCommand.Parameters.AddWithValue("@ProjectTitle", SqlDbType.NVarChar).Value = cat.ProjectTitle;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertResources", ex.Message);
        }

        return result;
    }
    public static int UpdateResources(SqlConnection conMN, ManageResources cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Resources Set ThumbImage=@ThumbImage,Category=@Category,ProjectTitle=@ProjectTitle,PDFFile=@PDFFile,Status=@Status where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                sqlCommand.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = cat.Category;
                sqlCommand.Parameters.AddWithValue("@ProjectTitle", SqlDbType.NVarChar).Value = cat.ProjectTitle;
                sqlCommand.Parameters.AddWithValue("@PDFFile", SqlDbType.NVarChar).Value = cat.PDFFile;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateResources", ex.Message);
        }

        return result;
    }

    public static List<ManageResources> GetAllResources(SqlConnection conMN)
    {
        List<ManageResources> result = new List<ManageResources>();
        try
        {
            string cmdText = "Select * from Resources where Status='Active'";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ManageResources
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              ThumbImage=Convert.ToString(dr["ThumbImage"]),
                              PDFFile = Convert.ToString(dr["PDFFile"]),
                              ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
                              Category  = Convert.ToString(dr["Category"]),
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

    public static List<ManageResources> GetResources(SqlConnection conMN, int id)
    {
        List<ManageResources> result = new List<ManageResources>();
        try
        {
            string cmdText = "Select * from Resources where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ManageResources
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Category = Convert.ToString(dr["Category"]),
                              ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResources", ex.Message);
        }

        return result;
    }
    public static int DeleteResources(SqlConnection conMN, ManageResources cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Resources Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteResources", ex.Message);
        }

        return result;
    }


    public static List<ManageResources> BindResources(SqlConnection conMN)
    {
        List<ManageResources> result = new List<ManageResources>();
        try
        {
            string cmdText = "Select * from Resources where Status=@Status Order by Id Desc";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            { 

                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ManageResources
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              ThumbImage = Convert.ToString(dr["ThumbImage"]),
                              PDFFile = Convert.ToString(dr["PDFFile"]),
                              ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
                              Category = Convert.ToString(dr["Category"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindResources", ex.Message);
        }

        return result;
    }
   
   
}
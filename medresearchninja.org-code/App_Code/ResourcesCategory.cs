using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResourcesCategory
/// </summary>
public class ResourcesCategory
{
    public int Id { get; set; }

    public string AddCategory { get; set; }

    public string Status { get; set; }

    public string AddedIP { get; set; }

    public DateTime AddedOn { get; set; }

    public string AddedBy { get; set; }



    public static int InsertResourcesCategory(SqlConnection conMN, ResourcesCategory cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into ResourcesCategory (AddCategory,Status,AddedIP,AddedOn,AddedBy) values(@AddCategory,@Status,@AddedIP,@AddedOn,@AddedBy)";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@AddCategory", SqlDbType.NVarChar).Value = cat.AddCategory;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertResourcesCategory", ex.Message);
        }

        return result;
    }
    public static int UpdateResourcesCategory(SqlConnection conMN, ResourcesCategory cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update ResourcesCategory Set AddCategory=@AddCategory,Status=@Status where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@AddCategory", SqlDbType.NVarChar).Value = cat.AddCategory;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateResourcesCategory", ex.Message);
        }

        return result;
    }
    public static List<ResourcesCategory> BindResourcesCategory(SqlConnection conMN)
    {
        List<ResourcesCategory> result = new List<ResourcesCategory>();
        try
        {
            string cmdText = "Select * from ResourcesCategory where Status='Active'";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ResourcesCategory
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              AddCategory = Convert.ToString(dr["AddCategory"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindResourcesCategory", ex.Message);
        }

        return result;
    }
    public static List<ResourcesCategory> GetResourcesCategory(SqlConnection conMN, int id)
    {
        List<ResourcesCategory> result = new List<ResourcesCategory>();
        try
        {
            string cmdText = "Select * from ResourcesCategory where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ResourcesCategory
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              AddCategory = Convert.ToString(dr["AddCategory"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResourcesCategory", ex.Message);
        }

        return result;
    }
    public static int DeleteResourcesCategory(SqlConnection conMN, ResourcesCategory cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update ResourcesCategory Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteResourcesCategory", ex.Message);
        }

        return result;
    }

    public static List<ResourcesCategory> GetCategoryDDL(SqlConnection conMN)
    {
        List<ResourcesCategory> result = new List<ResourcesCategory>();
        try
        {
            string cmdText = "Select * from ResourcesCategory where Status=@Status";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new ResourcesCategory
                          {
                              Id=Convert.ToInt32(dr["Id"]),
                              AddCategory = Convert.ToString(dr["AddCategory"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }
            
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCategoryDDL", ex.Message);
        }

        return result;
    }



}
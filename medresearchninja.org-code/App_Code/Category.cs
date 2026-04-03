using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
   public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }
    public static int AddCategory(SqlConnection conMN, Category Cat)
    {
        int result = 0;
        try
        {
            string query = "Insert Into Category (CategoryName,AddedOn,AddedIP,Status) values (@CategoryName,@AddedOn,@AddedIP,@Status) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = Cat.CategoryName;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Cat.Status;

                conMN.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddCategory", ex.Message);
        }
        return result;
    }
    public static int UpdateCategory(SqlConnection conGV, Category Cat)
    {
        int result = 0;
        try
        {
            string query = "Update Category Set CategoryName=@CategoryName,AddedOn=@AddedOn,AddedIp=@AddedIp ,Status=@Status Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Cat.Id;
                cmd.Parameters.AddWithValue("@CategoryName", SqlDbType.NVarChar).Value = Cat.CategoryName;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Cat.Status;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCategory", ex.Message);
        }
        return result;
    }
    public static int DeleteCategory(SqlConnection conMN, Category Cat)
    {
        int result = 0;
        try
        {
            string query = "Update Category Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = Cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = Cat.AddedIp;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteCategory", ex.Message);
        }
        return result;
    }
    public static List<Category> GetAllCategory(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<Category>();
        try
        {
            string query = "Select * from Category where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new Category()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   CategoryName = Convert.ToString(dr["CategoryName"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCategory", ex.Message);
        }
        return ListOfBolgs;
    }
    public static Category GetAllCategoryDetailsWithId(SqlConnection conSQ, int id)
    {
        var cat = new Category();
        try
        {
            string query = "Select * from Category where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cat = (from DataRow dr in dt.Rows
                              select new Category()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  CategoryName = Convert.ToString(dr["CategoryName"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCategoryDetailsWithId", ex.Message);
        }
        return cat;
    }
}

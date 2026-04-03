using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResourcesEnguiry
/// </summary>
public class ResourcesEnguiry
{

    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public string ResourceName { get; set; }
    public string Status { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string AddedBy { get; set; }


    public static int InsertResourcesEnguiry(SqlConnection conMN, ResourcesEnguiry cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into ResourcesQuery (FullName,Email,Contact,ResourceName,AddedIP,AddedOn,AddedBy,Status) values(@FullName,@Email,@Contact,@ResourceName,@AddedIP,@AddedOn,@AddedBy,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = cat.FullName;
                sqlCommand.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = cat.Email;
                sqlCommand.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = cat.Contact;
                sqlCommand.Parameters.AddWithValue("@ResourceName", SqlDbType.NVarChar).Value = cat.ResourceName;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertResourcesEnguiry", ex.Message);
        }

        return result;
    }

    public static string GetResName(SqlConnection conMN, int mr)
    {
        string resName = "";
        try
        {
            string query = "Select ProjectTitle from Resources where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = mr;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
                resName = Convert.ToString(dt.Rows[0]["ProjectTitle"]);
           
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResName", ex.Message);
        }
        return resName;
    }
    public static string GetResPDF(SqlConnection conMN, int  Id)
    {
        string ResPDF = "";
        try
        {
            string query = "Select PDFFile from Resources where Id=@Id";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Id;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ResPDF = Convert.ToString(dt.Rows[0]["PDFFile"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetResPDF", ex.Message);
        }
        return ResPDF;
    }
    public static List<ResourcesEnguiry> GetAllResourcesQuery(SqlConnection _con)
    {
        List<ResourcesEnguiry> categories = new List<ResourcesEnguiry>();
        try
        {
            string query = "Select * from ResourcesQuery where Status !='Deleted' order by Id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new ResourcesEnguiry()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  FullName = Convert.ToString(dr["FullName"]),
                                  Email = Convert.ToString(dr["Email"]),
                                  Contact = Convert.ToString(dr["Contact"]),
                                  ResourceName = Convert.ToString(dr["ResourceName"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedBy = Convert.ToString(dr["AddedIp"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllResourcesQuery", ex.Message);
        }
        return categories;
    }

    public static int DeleteResourcesQuery(SqlConnection _con, ResourcesEnguiry cat)
    {
        int result = 0;
        try
        {
            string query = "Update ResourcesQuery Set Status=@Status Where Id=@Id";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteResourcesQuery", ex.Message);
        }
        return result;
    }
}
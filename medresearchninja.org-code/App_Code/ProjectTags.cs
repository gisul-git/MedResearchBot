using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProjectTags
/// </summary>
public class ProjectTags
{
    public int Id { get; set; }
    public string TagTitle { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    public static int AddTag(SqlConnection conMN, ProjectTags Tag)
    {
        int result = 0;
        try
        {
            string query = "Insert Into ProjectTags (TagTitle,AddedOn,AddedIp,Status,AddedBy) values (@TagTitle,@AddedOn,@AddedIp,@Status,@AddedBy)";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@TagTitle", SqlDbType.NVarChar).Value = Tag.TagTitle;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Tag.AddedBy;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Tag.Status;
                conMN.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTag", ex.Message);
        }
        return result;
    }
    public static int UpdateTag(SqlConnection conMN, ProjectTags Tag)
    {
        int result = 0;
        try
        {
            string query = "Update ProjectTags Set TagTitle=@TagTitle,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Tag.Id;
                cmd.Parameters.AddWithValue("@TagTitle", SqlDbType.NVarChar).Value = Tag.TagTitle;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Tag.AddedBy;

                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateTag", ex.Message);
        }
        return result;
    }
    public static ProjectTags GetAllTagDetailsWithId(SqlConnection conMN, int id)
    {
        var categories = new ProjectTags();
        try
        {
            string query = "Select * from ProjectTags where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new ProjectTags()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  TagTitle = Convert.ToString(dr["TagTitle"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTagDetailsWithId", ex.Message);
        }
        return categories;
    }

    public static List<ProjectTags> GetAllTags(SqlConnection conMN)
    {
        var tags = new List<ProjectTags>();
        try
        {
            string query = "Select * from ProjectTags where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                tags = (from DataRow dr in dt.Rows
                               select new ProjectTags()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   TagTitle = Convert.ToString(dr["TagTitle"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTags", ex.Message);
        }
        return tags;
    }

    public static int DeleteTag(SqlConnection conMN, ProjectTags Tags)
    {
        int result = 0;
        try
        {
            string query = "Update ProjectTags Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Tags.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = Tags.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = Tags.AddedIp;
                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTag", ex.Message);
        }
        return result;
    }
}

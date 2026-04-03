using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Othermemberdetails
/// </summary>
public class Othermemberdetails
{
    public Othermemberdetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string ThumbImage { get; set; }
    public string Type { get; set; }
    public string LinkedinUrl { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    public static int Count { get; set; }

    public static int InsertOthermember(SqlConnection _con, Othermemberdetails cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into Othermemberdetails (Name,ThumbImage,Type,LinkedinUrl,Status,AddedOn,AddedIp,AddedBy) values " +
                "(@Name,@ThumbImage,@Type,@LinkedinUrl,@Status,@AddedOn,@AddedIp,@AddedBy) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = cat.Name;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = cat.Type;
                cmd.Parameters.AddWithValue("@LinkedinUrl", SqlDbType.NVarChar).Value = cat.LinkedinUrl;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;


                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertOthermember", ex.Message);
        }
        return result;
    }
    public static int UpdateOthermember(SqlConnection _con, Othermemberdetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update Othermemberdetails Set Name=@Name, ThumbImage=@ThumbImage,Type=@Type,LinkedinUrl=@LinkedinUrl,Status=@Status,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy= @AddedBy" +
                  " Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = cat.Name;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = cat.Type;
                cmd.Parameters.AddWithValue("@LinkedinUrl", SqlDbType.NVarChar).Value = cat.LinkedinUrl;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;


                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateOthermember", ex.Message);
        }
        return result;
    }
    public static Othermemberdetails GetOthermembersById(SqlConnection _con, int id)
    {
        Othermemberdetails Test = new Othermemberdetails();
        try
        {
            string query = "Select top 1 * from Othermemberdetails where Status='Active' and Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Test.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Test.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    Test.ThumbImage = Convert.ToString(dt.Rows[0]["ThumbImage"]);
                    Test.Type = Convert.ToString(dt.Rows[0]["Type"]);
                    Test.LinkedinUrl = Convert.ToString(dt.Rows[0]["LinkedinUrl"]);
                    Test.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    Test.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Test.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    Test.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);



                }
                else
                {
                    Test = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOthermembersById", ex.Message);
        }
        return Test;
    }
    public static List<Othermemberdetails> GetAllOthermembers(SqlConnection _con)
    {
        List<Othermemberdetails> categories = new List<Othermemberdetails>();
        try
        {
            string query = "Select * from Othermemberdetails where Status!='Deleted' Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Othermemberdetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Name = Convert.ToString(dr["Name"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  Type = Convert.ToString(dr["Type"]),
                                  LinkedinUrl = Convert.ToString(dr["LinkedinUrl"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),

                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllOthermembers", ex.Message);
        }
        return categories;
    }
    public static int DeleteOtherMembers(SqlConnection _con, Othermemberdetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update Othermemberdetails Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteOtherMembers", ex.Message);
        }
        return result;
    }
    public static List<Othermemberdetails> GetOthermembers(SqlConnection _con)
    {
        List<Othermemberdetails> categories = new List<Othermemberdetails>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=Othermemberdetails.AddedBy) as UpdatedBy from Othermemberdetails where Status=@Status Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Othermemberdetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Name = Convert.ToString(dr["Name"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  Type = Convert.ToString(dr["Type"]),
                                  LinkedinUrl = Convert.ToString(dr["LinkedinUrl"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOthermembers", ex.Message);
        }
        return categories;
    }
}
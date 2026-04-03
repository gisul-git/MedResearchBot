using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Testimonial
/// </summary>
public class Testimonial
{
    public int Id { get; set; }
    public string PostedBy {  get; set; }
    public string TestimonialName { get; set; }
    public string FullDesc { get; set; }
    public string Status { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }


    public static int InsertTestimonial(SqlConnection _con, Testimonial cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into Testimonial (PostedBy, TestimonialName, FullDesc, status, AddedOn,AddedIp,AddedBy) values (@PostedBy, @TestimonialName, @FullDesc, @status, @AddedOn,@AddedIp,@AddedBy ) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {

                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = cat.PostedBy;
                cmd.Parameters.AddWithValue("@TestimonialName", SqlDbType.NVarChar).Value = cat.TestimonialName;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertTestimonial", ex.Message);
        }
        return result;
    }
    public static int UpdateTestimonial(SqlConnection _con, Testimonial cat)
    {
        int result = 0;
        try
        {
            string query = "Update Testimonial Set PostedBy=@PostedBy, TestimonialName=@TestimonialName,FullDesc=@FullDesc,Status=@Status,AddedOn=@AddedOn,AddedIp=@AddedIp,AddedBy=@AddedBy" +
                  " Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = cat.PostedBy;
                cmd.Parameters.AddWithValue("@TestimonialName", SqlDbType.NVarChar).Value = cat.TestimonialName;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateJobDetails", ex.Message);
        }
        return result;
    }
    public static int DeleteTestimonial(SqlConnection _con, Testimonial cat)
    {
        int result = 0;
        try
        {
            string query = "Update Testimonial Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTestimonial", ex.Message);
        }
        return result;
    }
    public static Testimonial GetTestimonialById(SqlConnection _con, int id)
    {
        Testimonial Job = new Testimonial();
        try
        {
            string query = "Select top 1 * from Testimonial where Status='Active' and Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Job.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Job.PostedBy = Convert.ToString(dt.Rows[0]["PostedBy"]);
                    Job.TestimonialName = Convert.ToString(dt.Rows[0]["TestimonialName"]);
                    Job.FullDesc = Convert.ToString(dt.Rows[0]["FullDesc"]);
                    Job.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    Job.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Job.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    Job.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    
                   

                }
                else
                {
                    Job = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTestimonialById", ex.Message);
        }
        return Job;
    }
    public static List<Testimonial> GetAllTestimonial(SqlConnection _con)
    {
        List<Testimonial> categories = new List<Testimonial>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=Testimonial.AddedBy) as UpdatedBy from Testimonial where Status=@Status Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Testimonial()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  TestimonialName = Convert.ToString(dr["TestimonialName"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                 
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTestimonial", ex.Message);
        }
        return categories;
    }


    public static decimal NoOfTestimonial(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntG from Testimonial Where  Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cntG = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntG"]), out cntG);
                x = cntG;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfTestimonial", ex.Message);
        }
        return x;
    }
}
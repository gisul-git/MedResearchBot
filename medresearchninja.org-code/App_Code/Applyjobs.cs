using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Applyjobs
/// </summary>
public class Applyjobs
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string EmailId { get; set; }

    public string ContactNumber { get; set; }

    public string Experience { get; set; }

    public string Location { get; set; }

    public string JobType { get; set; }
    public string CurrentSalary { get; set; }

    public string ExpectedSalary { get; set; }

    public string NoticePeriod { get; set; }

    public string ResumePath { get; set; }

    public string Pageurl { get; set; }

    
    public string Status { get; set; }

    public string AddedIP { get; set; }

    public DateTime AddedOn { get; set; }

    public string JobTitle { get; set; }

    public int JobId { get; set; }

    public static int InsertApplyjobs(SqlConnection conMN, Applyjobs cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into Applyjobs (FullName,EmailId,Status,JobTitle,JobId,AddedIP,AddedOn,ContactNumber,Experience,Location,CurrentSalary,ExpectedSalary,NoticePeriod,ResumePath,Pageurl,JobType) values (@FullName,@EmailId,@Status,@JobTitle,@JobId,@AddedIP,@AddedOn,@ContactNumber,@Experience,@Location,@CurrentSalary,@ExpectedSalary,@NoticePeriod,@ResumePath,@Pageurl,@JobType) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@FullName", SqlDbType.NVarChar).Value = cat.FullName;
                sqlCommand.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = cat.EmailId;
                sqlCommand.Parameters.AddWithValue("@ContactNumber", SqlDbType.NVarChar).Value = cat.ContactNumber;
                sqlCommand.Parameters.AddWithValue("@Experience", SqlDbType.NVarChar).Value = cat.Experience;
                sqlCommand.Parameters.AddWithValue("@Location", SqlDbType.NVarChar).Value = cat.Location;
                sqlCommand.Parameters.AddWithValue("@CurrentSalary", SqlDbType.NVarChar).Value = cat.CurrentSalary;
                sqlCommand.Parameters.AddWithValue("@ExpectedSalary", SqlDbType.NVarChar).Value = cat.ExpectedSalary;
                sqlCommand.Parameters.AddWithValue("@NoticePeriod", SqlDbType.NVarChar).Value = cat.NoticePeriod;
                sqlCommand.Parameters.AddWithValue("@JobType", SqlDbType.NVarChar).Value = cat.JobType;
                sqlCommand.Parameters.AddWithValue("@ResumePath", SqlDbType.NVarChar).Value = cat.ResumePath;
                sqlCommand.Parameters.AddWithValue("@Pageurl", SqlDbType.DateTime).Value = cat.Pageurl;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                sqlCommand.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@JobTitle", SqlDbType.NVarChar).Value = cat.JobTitle;
                sqlCommand.Parameters.AddWithValue("@JobId", SqlDbType.NVarChar).Value = cat.JobId;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }
               
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertJobDetails", ex.Message);
        }

        return result;
    }
    public static List<Applyjobs> GetAllJobApplications(SqlConnection conMN)
    {
        List<Applyjobs> result = new List<Applyjobs>();
        try
        {
            string query = "Select * from Applyjobs where Status != @Deleted Order by Id Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new Applyjobs()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              FullName = Convert.ToString(dr["FullName"]),
                              EmailId = Convert.ToString(dr["EmailId"]),
                              ContactNumber = Convert.ToString(dr["ContactNumber"]),
                              Experience = Convert.ToString(dr["Experience"]),
                              Location = Convert.ToString(dr["Location"]),
                              CurrentSalary = Convert.ToString(dr["CurrentSalary"]),
                              ExpectedSalary = Convert.ToString(dr["ExpectedSalary"]),
                              JobType = Convert.ToString(dr["JobType"]),
                              JobTitle = Convert.ToString(dr["JobTitle"]),
                              ResumePath = Convert.ToString(dr["ResumePath"]),
                              NoticePeriod = Convert.ToString(dr["NoticePeriod"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllJobApplications", ex.Message);
        }

        return result;
    }
    public static int DeleteJobApp(SqlConnection conMN, Applyjobs cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Applyjobs Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteJobApp", ex.Message);
        }

        return result;
    }
}
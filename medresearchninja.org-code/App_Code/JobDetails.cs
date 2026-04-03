using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JobDetails
/// </summary>
public class JobDetails
{
    public int Id { get; set; }
    public string JobTitle { get; set; }
    public string JobUrl { get; set; }
    public string EmploymentType { get; set; }
    public DateTime PostedOn { get; set; }
    public string JobResponsibilities { get; set; }
    public string MetaDesc { get; set; }
    public string MetaKeys { get; set; }
    public string PageTitle { get; set; }
    public string Education { get; set; }
    public string IndustryType { get; set; }
    public string KeySkills { get; set; }
    public string Role { get; set; }
    public string JobLocation { get; set; }
    public string ExperienceYears { get; set; }
    public string Salary { get; set; }
    public string AddedIP { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    public string ShortDesc { get; set; }
    public string FunctionalArea { get; set; }
    public string RoleCategory { get; set; }
    public string Requirements { get; set; }
    public string JobType { get; set; }


    public static int InsertJobDetails(SqlConnection _con, JobDetails cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into JobDetails (JobType,JobTitle,RoleCategory,JobUrl,MetaDesc,EmploymentType,PostedOn,FunctionalArea,MetaKeys,JobResponsibilities,Education,IndustryType,KeySkills,Role,JobLocation,ExperienceYears,Salary,AddedIP,AddedOn,AddedBy,Status,PageTitle,Requirements) values " +
                "(@JobType,@JobTitle ,@RoleCategory ,@JobUrl,@MetaDesc,@EmploymentType,@PostedOn,@FunctionalArea,@MetaKeys,@JobResponsibilities,@Education,@IndustryType,@KeySkills,@Role,@JobLocation,@ExperienceYears,@Salary,@AddedIP,@AddedOn,@AddedBy,@Status,@PageTitle,@Requirements) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@JobType", SqlDbType.NVarChar).Value = cat.JobType;
                cmd.Parameters.AddWithValue("@JobTitle", SqlDbType.NVarChar).Value = cat.JobTitle;
                cmd.Parameters.AddWithValue("@JobUrl", SqlDbType.NVarChar).Value = cat.JobUrl;
                cmd.Parameters.AddWithValue("@EmploymentType", SqlDbType.NVarChar).Value = cat.EmploymentType;
                cmd.Parameters.AddWithValue("@PostedOn", SqlDbType.DateTime).Value = cat.PostedOn;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@JobResponsibilities", SqlDbType.NVarChar).Value = cat.JobResponsibilities;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@Education", SqlDbType.NVarChar).Value = cat.Education;
                cmd.Parameters.AddWithValue("@IndustryType", SqlDbType.NVarChar).Value = cat.IndustryType;
                cmd.Parameters.AddWithValue("@KeySkills", SqlDbType.NVarChar).Value = cat.KeySkills;
                cmd.Parameters.AddWithValue("@Role", SqlDbType.NVarChar).Value = cat.Role;
                cmd.Parameters.AddWithValue("@JobLocation", SqlDbType.NVarChar).Value = cat.JobLocation;
                cmd.Parameters.AddWithValue("@ExperienceYears", SqlDbType.NVarChar).Value = cat.ExperienceYears;
                cmd.Parameters.AddWithValue("@Salary", SqlDbType.NVarChar).Value = cat.Salary;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@FunctionalArea", SqlDbType.NVarChar).Value = cat.FunctionalArea;
                cmd.Parameters.AddWithValue("@RoleCategory", SqlDbType.NVarChar).Value = cat.RoleCategory;
                cmd.Parameters.AddWithValue("@Requirements", SqlDbType.NVarChar).Value = cat.Requirements;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertJobDetails", ex.Message);
        }
        return result;
    }
    public static int UpdateJobDetails(SqlConnection _con, JobDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update JobDetails Set JobType=@JobType,JobTitle=@JobTitle,RoleCategory=@RoleCategory,JobUrl=@JobUrl,FunctionalArea=@FunctionalArea,MetaDesc=@MetaDesc,EmploymentType=@EmploymentType," +
                "PostedOn=@PostedOn,MetaKeys=@MetaKeys,JobResponsibilities=@JobResponsibilities,Education=@Education" +
                ",Requirements=@Requirements,IndustryType=@IndustryType,KeySkills=@KeySkills,Role=@Role,JobLocation=@JobLocation,ExperienceYears=@ExperienceYears,Salary=@Salary,AddedIP=@AddedIP,AddedOn=@AddedOn,AddedBy=@AddedBy,Status=@Status,PageTitle=@PageTitle Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@JobType",SqlDbType.NVarChar).Value=cat.JobType;
                cmd.Parameters.AddWithValue("@JobTitle", SqlDbType.NVarChar).Value = cat.JobTitle;
                cmd.Parameters.AddWithValue("@JobUrl", SqlDbType.NVarChar).Value = cat.JobUrl;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@EmploymentType", SqlDbType.NVarChar).Value = cat.EmploymentType;
                cmd.Parameters.AddWithValue("@PostedOn", SqlDbType.NVarChar).Value = cat.PostedOn;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@JobResponsibilities", SqlDbType.NVarChar).Value = cat.JobResponsibilities;
                cmd.Parameters.AddWithValue("@Education", SqlDbType.NVarChar).Value = cat.Education;
                cmd.Parameters.AddWithValue("@IndustryType", SqlDbType.NVarChar).Value = cat.IndustryType;
                cmd.Parameters.AddWithValue("@KeySkills", SqlDbType.DateTime).Value = cat.KeySkills;
                cmd.Parameters.AddWithValue("@Role", SqlDbType.DateTime).Value = cat.Role;
                cmd.Parameters.AddWithValue("@JobLocation", SqlDbType.DateTime).Value = cat.JobLocation;
                cmd.Parameters.AddWithValue("@ExperienceYears", SqlDbType.NVarChar).Value = cat.ExperienceYears;
                cmd.Parameters.AddWithValue("@Salary", SqlDbType.NVarChar).Value = cat.Salary;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@FunctionalArea", SqlDbType.NVarChar).Value = cat.FunctionalArea;
                cmd.Parameters.AddWithValue("@RoleCategory", SqlDbType.NVarChar).Value = cat.RoleCategory;
                cmd.Parameters.AddWithValue("@Requirements", SqlDbType.NVarChar).Value = cat.Requirements;
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
    public static JobDetails GetJobDetailsById(SqlConnection _con, int id)
    {
        JobDetails Job = new JobDetails();
        try
        {
            string query = "Select * from JobDetails where Status='Active' and Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Job.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Job.JobType= Convert.ToString(dt.Rows[0]["JobType"]);
                    Job.JobTitle = Convert.ToString(dt.Rows[0]["JobTitle"]);
                    Job.JobUrl = Convert.ToString(dt.Rows[0]["JobUrl"]);
                    Job.MetaDesc = Convert.ToString(dt.Rows[0]["MetaDesc"]);
                    Job.EmploymentType = Convert.ToString(dt.Rows[0]["EmploymentType"]);
                    Job.PostedOn = Convert.ToDateTime(dt.Rows[0]["PostedOn"]);
                    Job.MetaKeys = Convert.ToString(dt.Rows[0]["MetaKeys"]);
                    Job.JobResponsibilities = Convert.ToString(dt.Rows[0]["JobResponsibilities"]);
                    Job.Education = Convert.ToString(dt.Rows[0]["Education"]);
                    Job.IndustryType = Convert.ToString(dt.Rows[0]["IndustryType"]);
                    Job.KeySkills = Convert.ToString(Convert.ToString(dt.Rows[0]["KeySkills"]));
                    Job.Role = Convert.ToString(Convert.ToString(dt.Rows[0]["Role"]));
                    Job.JobLocation = Convert.ToString(dt.Rows[0]["JobLocation"]);
                    Job.ExperienceYears = Convert.ToString(dt.Rows[0]["ExperienceYears"]);
                    Job.Salary = Convert.ToString(dt.Rows[0]["Salary"]);
                    Job.AddedIP = Convert.ToString(dt.Rows[0]["AddedIP"]);
                    Job.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Job.PageTitle = Convert.ToString(dt.Rows[0]["PageTitle"]);
                    Job.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    Job.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    Job.FunctionalArea = Convert.ToString(dt.Rows[0]["FunctionalArea"]);
                    Job.RoleCategory = Convert.ToString(dt.Rows[0]["RoleCategory"]);
                    Job.Requirements = Convert.ToString(dt.Rows[0]["Requirements"]);

                }
                else
                {
                    Job = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetJobDetailsById", ex.Message);
        }
        return Job;
    }

    public static int DeleteJobDetails(SqlConnection _con, JobDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update JobDetails Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteJobDetails", ex.Message);
        }
        return result;
    }
    public static List<JobDetails> GetAllJobDetails(SqlConnection _con)
    {
        List<JobDetails> categories = new List<JobDetails>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=JobDetails.AddedBy) as UpdatedBy from JobDetails where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new JobDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  JobType = Convert.ToString(dr["JobType"]),
                                  JobTitle = Convert.ToString(dr["JobTitle"]),
                                  JobUrl = Convert.ToString(dr["JobUrl"]),
                                  EmploymentType = Convert.ToString(dr["EmploymentType"]),
                                  PostedOn = Convert.ToDateTime(Convert.ToString(dr["PostedOn"])),
                                  JobResponsibilities = Convert.ToString(dr["JobResponsibilities"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  Education = Convert.ToString(dr["Education"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  IndustryType = Convert.ToString(dr["IndustryType"]),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  KeySkills = Convert.ToString(dr["KeySkills"]),
                                  Role = Convert.ToString(dr["Role"]),
                                  JobLocation = Convert.ToString(dr["JobLocation"]),
                                  ExperienceYears = Convert.ToString(Convert.ToString(dr["ExperienceYears"])),
                                  Salary = Convert.ToString(dr["Salary"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  FunctionalArea = Convert.ToString(dr["FunctionalArea"]),
                                  RoleCategory = Convert.ToString(dr["RoleCategory"]),
                                  Requirements = Convert.ToString(dr["Requirements"]),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllJobDetails", ex.Message);
        }
        return categories;
    }
    public static JobDetails getJobDetailsByUrl(SqlConnection _con, string JobUrl)
    {
        JobDetails jobDetails = new JobDetails();
        try
        {
            string cmdText = "Select * from JobDetails where Status='Active' and JobUrl=@JobUrl";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, _con))
            {
                sqlCommand.Parameters.AddWithValue("@JobUrl", SqlDbType.NVarChar).Value = JobUrl;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    jobDetails.Id = Convert.ToInt32(Convert.ToString(dataTable.Rows[0]["Id"]));
                    jobDetails.JobTitle = Convert.ToString(dataTable.Rows[0]["JobTitle"]);
                    jobDetails.JobType = Convert.ToString(dataTable.Rows[0]["JobType"]);
                    jobDetails.JobUrl = Convert.ToString(dataTable.Rows[0]["JobUrl"]);
                    jobDetails.JobResponsibilities = Convert.ToString(dataTable.Rows[0]["JobResponsibilities"]);
                    jobDetails.Education = Convert.ToString(dataTable.Rows[0]["Education"]);
                    jobDetails.EmploymentType = Convert.ToString(dataTable.Rows[0]["EmploymentType"]);
                    jobDetails.PageTitle = Convert.ToString(dataTable.Rows[0]["PageTitle"]);
                    jobDetails.MetaKeys = Convert.ToString(dataTable.Rows[0]["MetaKeys"]);
                    jobDetails.MetaDesc = Convert.ToString(dataTable.Rows[0]["MetaDesc"]);
                    jobDetails.IndustryType = Convert.ToString(dataTable.Rows[0]["IndustryType"]);
                    jobDetails.AddedOn = Convert.ToDateTime(Convert.ToString(dataTable.Rows[0]["AddedOn"]));
                    jobDetails.PostedOn = Convert.ToDateTime(Convert.ToString(dataTable.Rows[0]["PostedOn"]));
                    jobDetails.KeySkills = Convert.ToString(dataTable.Rows[0]["KeySkills"]);
                    jobDetails.AddedBy = Convert.ToString(dataTable.Rows[0]["AddedBy"]);
                    jobDetails.AddedIP = Convert.ToString(dataTable.Rows[0]["AddedIP"]);
                    jobDetails.Status = Convert.ToString(dataTable.Rows[0]["Status"]);
                    jobDetails.Role = Convert.ToString(dataTable.Rows[0]["Role"]);
                    jobDetails.JobLocation = Convert.ToString(dataTable.Rows[0]["JobLocation"]);
                    jobDetails.ExperienceYears = Convert.ToString(dataTable.Rows[0]["ExperienceYears"]);
                    jobDetails.Salary = Convert.ToString(dataTable.Rows[0]["Salary"]);
                    jobDetails.FunctionalArea = Convert.ToString(dataTable.Rows[0]["FunctionalArea"]);
                    jobDetails.RoleCategory = Convert.ToString(dataTable.Rows[0]["RoleCategory"]);
                    jobDetails.Requirements = Convert.ToString(dataTable.Rows[0]["Requirements"]);
                }
                else
                {
                    jobDetails = null;
                }
            }
                
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "getJobDetailsByUrl", ex.Message);
        }

        return jobDetails;
    }













}
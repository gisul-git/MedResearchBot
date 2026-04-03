using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Projects
/// </summary>
public class Projects
{
    public int Id { get; set; }
    public string ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectLink { get; set; }
    public string Subject { get; set; }
    public string ProjectGuid { get; set; }
    public string Tags { get; set; }
    public string ShortDesc { get; set; }
    public string MaxCollab { get; set; }
    public string PriceINR { get; set; }
    public string PriceOther { get; set; }
    public string StartDate { get; set; }
    public string mCount { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    public string AddedIp { get; set; }
    public DateTime AddedOn { get; set; }
    public DateTime PostedOn { get; set; }

    #region Projects
    public static int InsertProjects(SqlConnection conMN, Projects cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into Projects (ProjectGuid,ProjectId,ProjectName,ProjectLink,Subject,AddedIp,ShortDesc,MaxCollab,PriceINR,PriceOther,StartDate,PostedOn,AddedOn,AddedBy,Status,Tags) " +
                "values(@ProjectGuid,@ProjectId,@ProjectName,@ProjectLink,@Subject,@AddedIp,@ShortDesc,@MaxCollab,@PriceINR,@PriceOther,@StartDate,@PostedOn,@AddedOn,@AddedBy,@Status,@Tags) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ProjectName", SqlDbType.NVarChar).Value = cat.ProjectName;
                sqlCommand.Parameters.AddWithValue("@ProjectGuid", SqlDbType.NVarChar).Value = cat.ProjectGuid;
                sqlCommand.Parameters.AddWithValue("@ProjectId", SqlDbType.NVarChar).Value = cat.ProjectId;
                sqlCommand.Parameters.AddWithValue("@ProjectLink", SqlDbType.NVarChar).Value = cat.ProjectLink;
                sqlCommand.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                sqlCommand.Parameters.AddWithValue("@MaxCollab", SqlDbType.NVarChar).Value = cat.MaxCollab;
                sqlCommand.Parameters.AddWithValue("@PriceINR", SqlDbType.NVarChar).Value = cat.PriceINR;
                sqlCommand.Parameters.AddWithValue("@Tags", SqlDbType.NVarChar).Value = cat.Tags;
                sqlCommand.Parameters.AddWithValue("@PriceOther", SqlDbType.NVarChar).Value = cat.PriceOther;
                sqlCommand.Parameters.AddWithValue("@StartDate", SqlDbType.NVarChar).Value = cat.StartDate;
                sqlCommand.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = cat.Subject;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@PostedOn", SqlDbType.DateTime).Value = cat.PostedOn;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertProjects", ex.Message);
        }

        return result;
    }
    public static int UpdateProjects(SqlConnection conMN, Projects cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Projects Set ProjectName=@ProjectName,ProjectLink=@ProjectLink,Subject=@Subject,StartDate=@StartDate,AddedIp=AddedIp,ShortDesc=@ShortDesc,MaxCollab=@MaxCollab,PriceINR=@PriceINR,PriceOther=@PriceOther,PostedOn=@PostedOn,AddedOn=@AddedOn,AddedBy=@AddedBy,Status=@Status ,Tags=@Tags where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@ProjectName", SqlDbType.NVarChar).Value = cat.ProjectName;
                sqlCommand.Parameters.AddWithValue("@ProjectLink", SqlDbType.NVarChar).Value = cat.ProjectLink;
                sqlCommand.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                sqlCommand.Parameters.AddWithValue("@MaxCollab", SqlDbType.NVarChar).Value = cat.MaxCollab;
                sqlCommand.Parameters.AddWithValue("@PriceINR", SqlDbType.NVarChar).Value = cat.PriceINR;
                sqlCommand.Parameters.AddWithValue("@Tags", SqlDbType.NVarChar).Value = cat.Tags;
                sqlCommand.Parameters.AddWithValue("@PriceOther", SqlDbType.NVarChar).Value = cat.PriceOther;
                sqlCommand.Parameters.AddWithValue("@StartDate", SqlDbType.NVarChar).Value = cat.StartDate;
                sqlCommand.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = cat.Subject;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@PostedOn", SqlDbType.DateTime).Value = cat.PostedOn;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertProjects", ex.Message);
        }

        return result;
    }
    public static decimal NoOfProjects(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = "Select Count(Id) as cntB from Projects Where  Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cntB = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntB"]), out cntB);
                x = cntB;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfProjects", ex.Message);
        }
        return x;
    }
    public static Projects GetProjectsDetailsById(SqlConnection _con, int id)
    {
        Projects Pro = new Projects();
        try
        {
            string query = "Select * from Projects where Status !='Deleted' and Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Pro.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Pro.ProjectName = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    Pro.ProjectGuid = Convert.ToString(dt.Rows[0]["ProjectGuid"]);
                    Pro.Tags = Convert.ToString(dt.Rows[0]["Tags"]);
                    Pro.ProjectLink = Convert.ToString(dt.Rows[0]["ProjectLink"]);
                    Pro.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                    Pro.ShortDesc = Convert.ToString(dt.Rows[0]["ShortDesc"]);
                    Pro.PostedOn = Convert.ToDateTime(dt.Rows[0]["PostedOn"]);
                    Pro.MaxCollab = Convert.ToString(dt.Rows[0]["MaxCollab"]);
                    Pro.PriceINR = Convert.ToString(dt.Rows[0]["PriceINR"]);
                    Pro.PriceOther = Convert.ToString(dt.Rows[0]["PriceOther"]);
                    Pro.StartDate = Convert.ToString(dt.Rows[0]["StartDate"]);
                    Pro.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    Pro.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Pro.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    Pro.Status = Convert.ToString(dt.Rows[0]["Status"]);

                }
                else
                {
                    Pro = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectsDetailsById", ex.Message);
        }
        return Pro;
    }
    public static Projects GetProjectDetailsByPGuid(SqlConnection conMN, string projectGuid)
    {
        Projects Pro = new Projects();
        try
        {
            string query = "Select * from Projects where Status !='Deleted' and ProjectGuid=@projectGuid";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@ProjectGuid", SqlDbType.Int).Value = projectGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Pro.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Pro.ProjectName = Convert.ToString(dt.Rows[0]["ProjectName"]);
                    Pro.ProjectId = Convert.ToString(dt.Rows[0]["ProjectId"]);
                    Pro.ProjectGuid = Convert.ToString(dt.Rows[0]["ProjectGuid"]);
                    Pro.Tags = Convert.ToString(dt.Rows[0]["Tags"]);
                    Pro.ProjectLink = Convert.ToString(dt.Rows[0]["ProjectLink"]);
                    Pro.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                    Pro.StartDate = Convert.ToString(dt.Rows[0]["StartDate"]);
                    Pro.ShortDesc = Convert.ToString(dt.Rows[0]["ShortDesc"]);
                    Pro.PostedOn = Convert.ToDateTime(dt.Rows[0]["PostedOn"]);
                    Pro.MaxCollab = Convert.ToString(dt.Rows[0]["MaxCollab"]);
                    Pro.PriceINR = Convert.ToString(dt.Rows[0]["PriceINR"]);
                    Pro.PriceOther = Convert.ToString(dt.Rows[0]["PriceOther"]);
                    Pro.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    Pro.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Pro.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    Pro.Status = Convert.ToString(dt.Rows[0]["Status"]);

                }
                else
                {
                    Pro = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectDetailsByPGuid", ex.Message);
        }
        return Pro;
    }
    public static Projects GetProjectDetails(SqlConnection _conn, string p_guid)
    {
        var Pro = new Projects();
        try
        {
            string query_old = "SELECT *, (SELECT TOP 1 UserName FROM CreateUser WHERE UserGuid = p.AddedBy) AS created_by FROM Projects p WHERE p.ProjectGuid = @project_guid AND p.Status != 'Deleted'";
            string query = @"SELECT p.*, 
                                (SELECT TOP 1 UserName FROM CreateUser WHERE UserGuid = p.AddedBy) AS created_by,
                                (SELECT COUNT(m.Id) FROM POrders o INNER JOIN MemberDetails m ON m.UserGuid = o.UserGuid WHERE o.ProjectGuid = p.ProjectGuid AND o.Status != 'Deleted' AND o.orderstatus = 'completed') AS mCount
                            FROM Projects p 
                            WHERE p.ProjectGuid = @project_guid AND p.Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@project_guid", SqlDbType.NVarChar).Value = p_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Pro.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                Pro.ProjectName = Convert.ToString(dt.Rows[0]["ProjectName"]);
                Pro.ProjectId = Convert.ToString(dt.Rows[0]["ProjectId"]);
                Pro.ProjectGuid = Convert.ToString(dt.Rows[0]["ProjectGuid"]);
                Pro.Tags = Convert.ToString(dt.Rows[0]["Tags"]);
                Pro.ProjectLink = Convert.ToString(dt.Rows[0]["ProjectLink"]);
                Pro.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                Pro.StartDate = Convert.ToString(dt.Rows[0]["StartDate"]);
                Pro.ShortDesc = Convert.ToString(dt.Rows[0]["ShortDesc"]);
                Pro.PostedOn = Convert.ToDateTime(dt.Rows[0]["PostedOn"]);
                Pro.MaxCollab = Convert.ToString(dt.Rows[0]["MaxCollab"]);
                Pro.PriceINR = Convert.ToString(dt.Rows[0]["PriceINR"]);
                Pro.PriceOther = Convert.ToString(dt.Rows[0]["PriceOther"]);
                Pro.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                Pro.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                Pro.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                Pro.Status = Convert.ToString(dt.Rows[0]["Status"]);

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectDetails", ex.Message);
        }
        return Pro;
    }
    public static string GetProjectId(SqlConnection _con)
    {
        string productId = "";
        try
        {
            string query = "select max(Id) AS MaxProductId from Projects";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0 && dt.Rows[0]["MaxProductId"] != DBNull.Value)
                {
                    productId = dt.Rows[0]["MaxProductId"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectId", ex.Message);
        }
        return productId;
    }
    public static int DeleteProjects(SqlConnection _con, Projects cat)
    {
        int result = 0;
        try
        {
            string query = "Update Projects Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProjects", ex.Message);
        }
        return result;
    }
    public static int PublishedProjects(SqlConnection _con, Projects cat)
    {
        int result = 0;
        try
        {
            string query = "Update Projects Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProjects", ex.Message);
        }
        return result;
    }
    public static string GetDetailsById(SqlConnection conMN, string id)
    {
        string result = "";

        try
        {
            string query = "select * from Projects where Id=@Id And Status !='Deleted'";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var projects = (from DataRow dr in dt.Rows
                                select new Projects()
                                {
                                    Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                    ProjectId = Convert.ToString(dr["ProjectId"]),
                                    ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                                    ProjectName = Convert.ToString(dr["ProjectName"]),
                                    ProjectLink = Convert.ToString(dr["ProjectLink"]),
                                    Tags = Convert.ToString(dr["Tags"]),
                                    PriceOther = Convert.ToString(dr["PriceOther"]),
                                    PriceINR = Convert.ToString(dr["PriceINR"]),
                                    Subject = Convert.ToString(dr["Subject"]),
                                    StartDate = Convert.ToString(dr["StartDate"]),
                                    ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                    MaxCollab = Convert.ToString(dr["MaxCollab"]),
                                    AddedIp = Convert.ToString(dr["AddedIp"]),
                                    PostedOn = Convert.ToDateTime(dr["PostedOn"]),
                                    AddedBy = Convert.ToString(dr["AddedBy"]),
                                    Status = Convert.ToString(dr["Status"])
                                }).FirstOrDefault();

                result = JsonConvert.SerializeObject(projects);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsById", ex.Message);
        }

        return result;
    }
    public static List<Projects> BindRecentProjects(SqlConnection conMN)
    {
        List<Projects> result = new List<Projects>();
        try
        {
            string cmdText = "Select * from Projects where Status=@Status Order by Id Desc";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {

                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Published";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Projects
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              ProjectName = Convert.ToString(dr["ProjectName"]),
                              ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                              ProjectId = Convert.ToString(dr["ProjectId"]),
                              ProjectLink = Convert.ToString(dr["ProjectLink"]),
                              ShortDesc = Convert.ToString(dr["ShortDesc"]),
                              Tags = Convert.ToString(dr["Tags"]),
                              PostedOn = Convert.ToDateTime(Convert.ToString(dr["PostedOn"])),
                              MaxCollab = Convert.ToString(dr["MaxCollab"]),
                              PriceINR = Convert.ToString(dr["PriceINR"]),
                              PriceOther = Convert.ToString(dr["PriceOther"]),
                              StartDate = Convert.ToString(dr["StartDate"]),
                              Subject = Convert.ToString(dr["Subject"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              Status = Convert.ToString(dr["Status"]),
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindRecentProjects", ex.Message);
        }

        return result;
    }
    public static List<Projects> GetAllProjectsDetails(SqlConnection _con)
    {
        List<Projects> categories = new List<Projects>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=Projects.AddedBy) as UpdatedBy from Projects where Status !=@Status Order by Id desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Projects()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  ProjectName = Convert.ToString(dr["ProjectName"]),
                                  ProjectId = Convert.ToString(dr["ProjectId"]),
                                  ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                                  ProjectLink = Convert.ToString(dr["ProjectLink"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  Tags = Convert.ToString(dr["Tags"]),
                                  PostedOn = Convert.ToDateTime(Convert.ToString(dr["PostedOn"])),
                                  MaxCollab = Convert.ToString(dr["MaxCollab"]),
                                  PriceINR = Convert.ToString(dr["PriceINR"]),
                                  PriceOther = Convert.ToString(dr["PriceOther"]),
                                  StartDate = Convert.ToString(dr["StartDate"]),
                                  Subject = Convert.ToString(dr["Subject"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"]),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllProjectsDetails", ex.Message);
        }
        return categories;
    }
    #endregion

    #region ProjectDues
    public static int InsertProjectDues(SqlConnection _conn, ProjectDues dues)
    {
        int result = 0;
        try
        {
            string query = "Insert Into ProjectDues (ProjectGuid,AmountUSD, UserGuid, PaymentGuid, Amount, Comments, PaymentMode, PaymentId, PaymentStatus, tr_id, AddedOn, AddedIP, AddedBy, Status) values (@ProjectGuid,@AmountUSD, @UserGuid, @PaymentGuid, @Amount, @Comments, @PaymentMode, @PaymentId, @PaymentStatus, @tr_id, @AddedOn, @AddedIP, @AddedBy, @Status)";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@ProjectGuid", SqlDbType.NVarChar).Value = dues.ProjectGuid;
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = dues.UserGuid;
                cmd.Parameters.AddWithValue("@PaymentGuid", SqlDbType.NVarChar).Value = dues.PaymentGuid;
                cmd.Parameters.AddWithValue("@Amount", SqlDbType.NVarChar).Value = dues.Amount;
                cmd.Parameters.AddWithValue("@AmountUSD", SqlDbType.NVarChar).Value = dues.AmountUSD;
                cmd.Parameters.AddWithValue("@Comments", SqlDbType.NVarChar).Value = dues.Comments;
                cmd.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = dues.PaymentMode;
                cmd.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = dues.PaymentId;
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = dues.PaymentStatus;
                cmd.Parameters.AddWithValue("@tr_id", SqlDbType.NVarChar).Value = dues.tr_id;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = dues.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = dues.AddedIP;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = dues.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = dues.Status;

                _conn.Open();
                result = cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertProjectDues", ex.Message);
        }
        return result;
    }
    public static DataTable GetProjectDues(SqlConnection _conn, string p_guid)
    {
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProjectDues pd inner join MemberDetails md on md.UserGuid = pd.UserGuid WHERE pd.ProjectGuid = @ProjectGuid AND pd.status != 'Deleted'", _conn);
            cmd.Parameters.AddWithValue("@ProjectGuid", SqlDbType.NVarChar).Value = p_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectDues", ex.Message);
        }
        return dt;
    }
    public static DataTable GetUserProjectDues(SqlConnection _conn, string u_guid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT * FROM ProjectDues pd INNER JOIN Projects p ON p.ProjectGuid = pd.ProjectGuid WHERE pd.UserGuid = @UserGuid AND pd.Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = u_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetUserProjectDues", ex.Message);
        }
        return dt;
    }
    public static DataTable GetPaymentDetailsBy_PaymentGuid(SqlConnection _conn, string PaymentGuid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT * FROM ProjectDues pd INNER JOIN Projects p ON p.ProjectGuid = pd.ProjectGuid INNER JOIN MemberDetails md ON md.UserGuid= pd.UserGuid where pd.PaymentGuid = @PaymentGuid AND pd.status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@PaymentGuid", SqlDbType.NVarChar).Value = PaymentGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetPaymentDetailsBy_PaymentGuid", ex.Message);
        }
        return dt;
    }
    public static int DeleteProjectDues(SqlConnection _conn, ProjectDues dues)
    {
        int result = 0;
        try
        {
            string query = "Update ProjectDues Set Status=@Status, AddedOn=@AddedOn, AddedBy=@AddedBy, AddedIP=@AddedIP Where id=@id";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = dues.id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = dues.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = dues.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = dues.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = dues.AddedIP;
                _conn.Open();
                result = cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProjectDues", ex.Message);
        }
        return result;
    }
    public static string GetRMax(SqlConnection conMN)
    {
        string x = "";
        try
        {
            SqlCommand cmd3 = new SqlCommand("Select Max(try_convert(decimal, RMax)) as mid from ProjectDues", conMN);
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt3.Rows[0]["mid"]);
                if (cc == "")
                {
                    cc = "0000";
                }
                x = (Convert.ToInt32(cc) + 1).ToString();
                if (x.Length <= 4)
                {
                    x = Convert.ToInt32(x).ToString("0000");
                }
            }
        }
        catch (Exception ex)
        {
            x = "0001";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetRMax", ex.Message);
        }
        return x;
    }
    public static int UpdateProjectDuesPayment(SqlConnection _conn, ProjectDues dues)
    {
        int x = 0;
        try
        {
            string query = "UPDATE ProjectDues SET PaymentId=@PaymentId, PaymentMode=@PaymentMode, PaymentStatus=@PaymentStatus, PaymentDate=@PaymentDate, tr_id=@tr_id, RMax=@RMax, ReceiptNo=@ReceiptNo WHERE PaymentGuid=@PaymentGuid";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = dues.PaymentId;
                cmd.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = dues.PaymentMode;
                cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = dues.PaymentStatus;
                cmd.Parameters.AddWithValue("@PaymentDate", SqlDbType.NVarChar).Value = dues.PaymentDate;
                cmd.Parameters.AddWithValue("@tr_id", SqlDbType.NVarChar).Value = dues.tr_id;
                cmd.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = dues.RMax;
                cmd.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = dues.ReceiptNo;
                cmd.Parameters.AddWithValue("@PaymentGuid", SqlDbType.NVarChar).Value = dues.PaymentGuid;
                _conn.Open();
                x = cmd.ExecuteNonQuery();
                _conn.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateProjectDuesPayment", ex.Message);
        }
        return x;
    }
    public static int GetPendingProjectDuesCount(SqlConnection _conn, string u_guid)
    {
        int dues = 0;
        try
        {
            string query = "SELECT COUNT(id) AS dues FROM ProjectDues WHERE UserGuid = @UserGuid AND PaymentStatus = 'Pending' AND Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = u_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int temp = 0;
                int.TryParse(Convert.ToString(dt.Rows[0]["dues"]), out temp);
                dues = temp;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetPendingProjectDuesCount", ex.Message);
        }
        return dues;
    }
    #endregion
}
public class ProjectDues
{
    public string id { get; set; }
    public string ProjectGuid { get; set; }
    public string UserGuid { get; set; }
    public string UserID { get; set; }
    public string FullName { get; set; }
    public string EmailId { get; set; }
    public string PaymentGuid { get; set; }
    public string Amount { get; set; }
    public string AmountUSD { get; set; }
    public string Comments { get; set; }
    public string PaymentMode { get; set; }
    public string PaymentId { get; set; }
    public string PaymentStatus { get; set; }
    public string PaymentDate { get; set; }
    public string tr_id { get; set; }
    public string RMax { get; set; }
    public string ReceiptNo { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    public string LastMailAt { get; set; }
    public string Email { get; set; }
}
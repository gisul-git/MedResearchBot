using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LatestProject
/// </summary>
public class LatestProject
{
  public int Id { get; set; }
  public string ProjectTitle { get; set; }
  public string ThumbImage {  get; set; }
  public string Category { get; set; }
  public string PDFLink { get; set; }
  public string Status {  get; set; }
  public DateTime AddedOn {  get; set; }
  public string AddedIP { get; set; }
  public string AddedBy {  get; set; }

    public static int InsertLatestProject(SqlConnection _con, LatestProject cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into LatestProject (ProjectTitle,ThumbImage,Category,PDFLink,Status,AddedOn,AddedIP,AddedBy) values " +
                "(@ProjectTitle,@ThumbImage,@Category,@PDFLink,@Status,@AddedOn,@AddedIP,@AddedBy) ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@ProjectTitle", SqlDbType.NVarChar).Value = cat.ProjectTitle;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = cat.Category;
                cmd.Parameters.AddWithValue("@PDFLink", SqlDbType.NVarChar).Value = cat.PDFLink;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
               

                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertLatestProject", ex.Message);
        }
        return result;
    }
    public static int UpdateLatestProject(SqlConnection _con, LatestProject cat)
    {
        int result = 0;
        try
        {
            string query = "Update LatestProject Set ProjectTitle=@ProjectTitle, ThumbImage=@ThumbImage,Category=@Category,PDFLink=@PDFLink,Status=@Status,AddedOn=@AddedOn,AddedIP=@AddedIP, AddedBy= @AddedBy" +
                  " Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@ProjectTitle", SqlDbType.NVarChar).Value = cat.ProjectTitle;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = cat.Category;
                cmd.Parameters.AddWithValue("@PDFLink", SqlDbType.NVarChar).Value = cat.PDFLink ;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;

                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateLatestProject", ex.Message);
        }
        return result;
    }
    public static LatestProject GetLatestProjectById(SqlConnection _con, int id)
    {
        LatestProject Test = new LatestProject();
        try
        {
            string query = "Select top 1 * from LatestProject where Status='Active' and Id=@Id";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Test.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Test.ProjectTitle = Convert.ToString(dt.Rows[0]["ProjectTitle"]);
                    Test.ThumbImage = Convert.ToString(dt.Rows[0]["ThumbImage"]);
                    Test.Category = Convert.ToString(dt.Rows[0]["Category"]);
                    Test.PDFLink = Convert.ToString(dt.Rows[0]["PDFLink"]);
                    Test.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    Test.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    Test.AddedIP = Convert.ToString(dt.Rows[0]["AddedIP"]);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetLatestProjectById", ex.Message);
        }
        return Test;
    }
    public static List<LatestProject> GetAllLatestProject(SqlConnection _con)
    {
        List<LatestProject> categories = new List<LatestProject>();
        try
        {
            string query = "Select * from LatestProject where Status!='Deleted' Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new LatestProject()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  Category = Convert.ToString(dr["Category"]),
                                  PDFLink = Convert.ToString(dr["PDFLink"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllLatestProject", ex.Message);
        }
        return categories;
    }
    public static int DeleteLatestProject(SqlConnection _con, LatestProject cat)
    {
        int result = 0;
        try
        {
            string query = "Update LatestProject Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteLatestProject", ex.Message);
        }
        return result;
    }
    public static List<LatestProject> GetAllListProjects(SqlConnection conGV, int cPage)
    {
        List<LatestProject> Project = new List<LatestProject>();
        try
        {
            var qry = @"SELECT TOP 8 *
                            FROM (
                                SELECT 
                                    ROW_NUMBER() OVER (ORDER BY PostedOn DESC) AS RowNo,
                                    (SELECT COUNT(id) FROM LatestProject WHERE Status = 'Active') AS TotalCount,
                                    *
                                FROM LatestProject
                                WHERE Status = 'Active'
                            ) AS x
                            WHERE RowNo > 0" + (8 * (cPage - 1));
            using (SqlCommand cmd = new SqlCommand(qry, conGV))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Project = (from DataRow dr in dt.Rows
                         select new LatestProject()
                         {
                             Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                             ProjectTitle = Convert.ToString(dr["ProjectTitle"]),
                             ThumbImage = Convert.ToString(dr["ThumbImage"]),
                             Category = Convert.ToString(dr["Category"]),
                             PDFLink = Convert.ToString(dr["PDFLink"]),
                             Status = Convert.ToString(dr["Status"]),
                             AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                             AddedIP = Convert.ToString(dr["AddedIP"]),
                             AddedBy = Convert.ToString(dr["AddedBy"]),
                            
                         }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllListBlogs", ex.Message);
        }
        return Project;
    }

    public static decimal NoOfLatestProjects(SqlConnection conMN)
    {
        decimal result = 0m;
        try
        {
            string cmdText = " Select Count(Id) as cntB from LatestProject Where Status != 'Deleted'";
            SqlCommand selectCommand = new SqlCommand(cmdText, conMN);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                decimal result2 = 0m;
                decimal.TryParse(Convert.ToString(dataTable.Rows[0]["cntB"]), out result2);
                result = result2;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfLatestProjects", ex.Message);
        }

        return result;
    }

}
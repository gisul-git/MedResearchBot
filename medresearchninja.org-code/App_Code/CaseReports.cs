using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public class CaseReports
{
	public int ID { get; set; }
	public string TitleOfCase { get; set; }
	public string CaseSummary { get; set; }
	public string WhyRareOrReportable { get; set; }
	public string SubmittedByName { get; set; }
	public string Evidence { get; set; }
	public string SubmittedByContact { get; set; }
	public string SubmittedByAffiliation { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
	public string Status { get; set; }

    public static int InsertCaseReports(SqlConnection conMN, CaseReports cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into CaseReports (TitleOfCase,CaseSummary,WhyRareOrReportable,SubmittedByName,SubmittedByContact,SubmittedByAffiliation,Evidence,AddedIp,AddedOn,Status) values (@TitleOfCase,@CaseSummary,@WhyRareOrReportable,@SubmittedByName,@SubmittedByContact,@SubmittedByAffiliation,@Evidence,@AddedIp,@AddedOn,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@TitleOfCase", SqlDbType.NVarChar).Value = cat.TitleOfCase;
                sqlCommand.Parameters.AddWithValue("@CaseSummary", SqlDbType.NVarChar).Value = cat.CaseSummary;
                sqlCommand.Parameters.AddWithValue("@WhyRareOrReportable", SqlDbType.NVarChar).Value = cat.WhyRareOrReportable;
                sqlCommand.Parameters.AddWithValue("@SubmittedByName", SqlDbType.NVarChar).Value = cat.SubmittedByName;
                sqlCommand.Parameters.AddWithValue("@SubmittedByContact", SqlDbType.NVarChar).Value = cat.SubmittedByContact;
                sqlCommand.Parameters.AddWithValue("@SubmittedByAffiliation", SqlDbType.NVarChar).Value = cat.SubmittedByAffiliation;
                sqlCommand.Parameters.AddWithValue("@Evidence", SqlDbType.NVarChar).Value = cat.Evidence;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();

            }
                
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertCaseReports", ex.Message);
        }

        return result;
    }

    public static List<CaseReports> GetAllCaseReports(SqlConnection conMN)
    {
        List<CaseReports> result = new List<CaseReports>();
        try
        {
            string query = "Select * from CaseReports where Status != @Deleted Order by ID Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new CaseReports()
                          {
                              ID = Convert.ToInt32(Convert.ToString(dr["ID"])),
                              TitleOfCase = Convert.ToString(dr["TitleOfCase"]),
                              CaseSummary = Convert.ToString(dr["CaseSummary"]),
                              WhyRareOrReportable = Convert.ToString(dr["SubmittedByName"]),
                              SubmittedByName = Convert.ToString(dr["SubmittedByName"]),
                              SubmittedByContact = Convert.ToString(dr["SubmittedByContact"]),
                              SubmittedByAffiliation = Convert.ToString(dr["SubmittedByAffiliation"]),
                              Evidence = Convert.ToString(dr["Evidence"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCaseReports", ex.Message);
        }

        return result;
    }

    public static int DeleteCaseReport(SqlConnection conMN, CaseReports cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update CaseReports Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where ID=@ID";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = cat.ID;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteCaseReport", ex.Message);
        }

        return result;
    }

    public static string GetDetailsById(SqlConnection conMN, string id)
    {
        string result = "";

        try
        {
            string query = "select * from CaseReports WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var article = (from DataRow dr in dt.Rows
                               select new CaseReports()
                               {
                                   ID = Convert.ToInt32(Convert.ToString(dr["ID"])),
                                   TitleOfCase = Convert.ToString(dr["TitleOfCase"]),
                                   CaseSummary = Convert.ToString(dr["CaseSummary"]),
                                   WhyRareOrReportable = Convert.ToString(dr["WhyRareOrReportable"]),
                                   SubmittedByName = Convert.ToString(dr["SubmittedByName"]),
                                   SubmittedByContact = Convert.ToString(dr["SubmittedByContact"]),
                                   SubmittedByAffiliation = Convert.ToString(dr["SubmittedByAffiliation"]),
                                   AddedIp = Convert.ToString(dr["AddedIp"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).FirstOrDefault();

                // Serialize the article object to a JSON string
                result = JsonConvert.SerializeObject(article);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsById", ex.Message);
        }

        return result;
    }
}

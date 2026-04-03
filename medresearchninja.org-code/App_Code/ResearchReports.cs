using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;

/// <summary>
/// Summary description for ResearchReports
/// </summary>
public class ResearchReports
{
  public int ID { get; set; }   
   public string ResearchTopic { get; set; }    
   public string Abstract { get; set; }    
   public string Objectives { get; set; }    
   public string Background { get; set; }    
   public string Methods { get; set; }    
   public string ExpectedOutcomes { get; set; }    
   public string Reference { get; set; }    
   public string Comments { get; set; }    
   public string SubmittedByName { get; set; }    
   public string SubmittedByContact { get; set; }    
   public string SubmittedByAffiliation { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }

    public static int InsertResearchReports(SqlConnection conMN, ResearchReports cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into ResearchReports (ResearchTopic,Abstract,Objectives,Background,Methods,ExpectedOutcomes,Reference,Comments,SubmittedByName,SubmittedByContact,SubmittedByAffiliation,AddedIp,AddedOn,Status) values (@ResearchTopic,@Abstract,@Objectives,@Background,@Methods,@ExpectedOutcomes,@Reference,@Comments,@SubmittedByName,@SubmittedByContact,@SubmittedByAffiliation,@AddedIp,@AddedOn,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ResearchTopic", SqlDbType.NVarChar).Value = cat.ResearchTopic;
                sqlCommand.Parameters.AddWithValue("@Abstract", SqlDbType.NVarChar).Value = cat.Abstract;
                sqlCommand.Parameters.AddWithValue("@Objectives", SqlDbType.NVarChar).Value = cat.Objectives;
                sqlCommand.Parameters.AddWithValue("@Background", SqlDbType.NVarChar).Value = cat.Background;
                sqlCommand.Parameters.AddWithValue("@Methods", SqlDbType.NVarChar).Value = cat.Methods;
                sqlCommand.Parameters.AddWithValue("@ExpectedOutcomes", SqlDbType.NVarChar).Value = cat.ExpectedOutcomes;
                sqlCommand.Parameters.AddWithValue("@Reference", SqlDbType.NVarChar).Value = cat.Reference;
                sqlCommand.Parameters.AddWithValue("@Comments", SqlDbType.NVarChar).Value = cat.Comments;
                sqlCommand.Parameters.AddWithValue("@SubmittedByName", SqlDbType.NVarChar).Value = cat.SubmittedByName;
                sqlCommand.Parameters.AddWithValue("@SubmittedByContact", SqlDbType.NVarChar).Value = cat.SubmittedByContact;
                sqlCommand.Parameters.AddWithValue("@SubmittedByAffiliation", SqlDbType.NVarChar).Value = cat.SubmittedByAffiliation;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertResearchReports", ex.Message);
        }

        return result;
    }

    public static List<ResearchReports> GetAllResearchReports(SqlConnection conMN)
    {
        List<ResearchReports> result = new List<ResearchReports>();
        try
        {
            string query = "Select * from ResearchReports where Status != @Deleted Order by ID Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new ResearchReports()
                          {
                              ID = Convert.ToInt32(Convert.ToString(dr["ID"])),
                              ResearchTopic = Convert.ToString(dr["ResearchTopic"]),
                              Abstract = Convert.ToString(dr["Abstract"]),
                              Objectives = Convert.ToString(dr["Objectives"]),
                              Methods = Convert.ToString(dr["Methods"]),
                              ExpectedOutcomes = Convert.ToString(dr["ExpectedOutcomes"]),
                              SubmittedByName = Convert.ToString(dr["SubmittedByName"]),
                              SubmittedByContact = Convert.ToString(dr["SubmittedByContact"]),
                              SubmittedByAffiliation = Convert.ToString(dr["SubmittedByAffiliation"]),
                              Reference = Convert.ToString(dr["Reference"]),
                              Comments = Convert.ToString(dr["Comments"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllResearchReports", ex.Message);
        }

        return result;
    }

    public static int DeleteResearchReport(SqlConnection conMN, ResearchReports cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update ResearchReports Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where ID=@ID";
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteResearchReport", ex.Message);
        }

        return result;
    }
  
    public static string GetDetailsById(SqlConnection conMN, string id)
    {
        string result = "";

        try
        {
            string query = "select * from ResearchReports WHERE ID = @ID";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var article = (from DataRow dr in dt.Rows
                               select new ResearchReports()
                               {
                                   ID = Convert.ToInt32(Convert.ToString(dr["ID"])),
                                   ResearchTopic = Convert.ToString(dr["ResearchTopic"]),
                                   Abstract = Convert.ToString(dr["Abstract"]),
                                   Objectives = Convert.ToString(dr["Objectives"]),
                                   Methods = Convert.ToString(dr["Methods"]),
                                   ExpectedOutcomes = Convert.ToString(dr["ExpectedOutcomes"]),
                                   SubmittedByName = Convert.ToString(dr["SubmittedByName"]),
                                   SubmittedByContact = Convert.ToString(dr["SubmittedByContact"]),
                                   SubmittedByAffiliation = Convert.ToString(dr["SubmittedByAffiliation"]),
                                   Reference = Convert.ToString(dr["Reference"]),
                                   Comments = Convert.ToString(dr["Comments"]),
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
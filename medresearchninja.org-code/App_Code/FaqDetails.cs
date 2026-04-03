using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary Answer for FaqDetails
/// </summary>
public class FaqDetails
{
    public FaqDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Faq Properties
    public int Id { get; set; }
    
    public string FAQQuestion { get; set; }
    public string FAQAnswer { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }
    #endregion

    #region Faq Methods

    public static int DeleteFaq(SqlConnection conGV, FaqDetails FaqDetails)
    {
        int result = 0;
        try
        {
            string query = "Update FAQDetails Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = FaqDetails.Id;
                cmd.Parameters.AddWithValue("@FAQQuestion", SqlDbType.NVarChar).Value = FaqDetails.Id;
                cmd.Parameters.AddWithValue("@FAQAnswer", SqlDbType.NVarChar).Value = FaqDetails.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = FaqDetails.AddedBy; 
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = FaqDetails.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = FaqDetails.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteFaq", ex.Message);
        }
        return result;
    }
    public static FaqDetails GetAllFaqDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new FaqDetails();
        try
        {
            string query = "Select * from FAQDetails where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new FaqDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),

                                  FAQQuestion = Convert.ToString(dr["FAQQuestion"]),
                                  FAQAnswer = Convert.ToString(dr["FAQAnswer"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"]),
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllFaqDetailsWithId", ex.Message);
        }
        return categories;
    }
    public static List<FaqDetails> GetAllFaqDetails(SqlConnection conSQ, string Pid)
    {
        var ListOfBolgs = new List<FaqDetails>();
        try
        {
            string query = "Select * from FAQDetails where Status=@Status Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@Pid", SqlDbType.NVarChar).Value = Pid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new FaqDetails()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),

                                   FAQQuestion = Convert.ToString(dr["Question"]),
                                   FAQAnswer = Convert.ToString(dr["Answer"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"]),
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllFaqDetails", ex.Message);
        }
        return ListOfBolgs;
    }

    public static int UpdateFaq(SqlConnection conGV, FaqDetails Faq)
    {
        int result = 0;
        try
        {
            string query = "Update FAQDetails Set FAQQuestion=@FAQQuestion,FAQAnswer=@FAQAnswer, AddedOn=@AddedOn,AddedIp=@AddedIp,AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Faq.Id;
                cmd.Parameters.AddWithValue("@FAQQuestion", SqlDbType.NVarChar).Value = Faq.FAQQuestion;
                cmd.Parameters.AddWithValue("@FAQAnswer", SqlDbType.NVarChar).Value = Faq.FAQAnswer;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Faq.AddedBy;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Faq.Status;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateFaq", ex.Message);
        }
        return result;
    }

    public static int InsertFaq(SqlConnection conSQ, FaqDetails FaqDetails)
    {
        int result = 0;
        try
        {
            string query = "Insert Into FAQDetails (FAQQuestion,FAQAnswer,AddedBy,AddedOn,AddedIP,Status) values (@FAQQuestion,@FAQAnswer,@AddedBy,@AddedOn,@AddedIp,@Status)";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                
                cmd.Parameters.AddWithValue("@FAQQuestion", SqlDbType.NVarChar).Value = FaqDetails.FAQQuestion;
                cmd.Parameters.AddWithValue("@FAQAnswer", SqlDbType.NVarChar).Value = FaqDetails.FAQAnswer;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = FaqDetails.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = FaqDetails.Status;
                conSQ.Open();
                result = cmd.ExecuteNonQuery();
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertFaq", ex.Message);
        }
        return result;
    }
    #endregion
}
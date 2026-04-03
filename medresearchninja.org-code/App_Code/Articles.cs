using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Collections;

/// <summary>
/// Summary description for Articles
/// </summary>
public class Articles
{

    public int Id { get; set; }
    public string AuthorFullName { get; set; }
    public string AuthorGuid { get; set; }
    public string CoAuthorFullName { get; set; }
    public string CoAuthorPosition { get; set; }
    public string CoAuthorAffiliation { get; set; }
    public string CoAuthorEmailId { get; set; }
    public string AuthorPosition { get; set; }
    public string AuthorAffiliation { get; set; }
    public string AuthorEmailId { get; set; }
    public string AuthorPhoneNo { get; set; }
    public string ArticleTitle { get; set; }
    public string ArticleAbstract { get; set; }
    public string ArticleKeywords { get; set; }
    public string ArticleType { get; set; }
    public string ArticleWordCount { get; set; }
    public string ArticleTables { get; set; }
    public string ArticleAnyOtherJournal { get; set; }
    public string ArticlePublishedWork { get; set; }
    public string ArticlePrevPublishedddl { get; set; }
    public string ArticlePrevPublishedWork { get; set; }
    public string ArticlePrevPublishedWorkddl { get; set; }
    public string InterestToDeclare { get; set; }
    public string DescInterestToDeclare { get; set; }
    public string Organization { get; set; }
    public string DescOrganization { get; set; }
    public string Acknowledgments { get; set; }
    public string EthicalCompliance { get; set; }
    public string DescEthicalCompliance { get; set; }
    public string AttachSupplementoryManuscript { get; set; }
    public string AttachManuscript { get; set; }
    public string Signature { get; set; }
    public DateTime Date { get; set; }
    public string ContactInfoName { get; set; }
    public string ContactInfoEmailId { get; set; }
    public string ContactInfoPhoneNo { get; set; }
    public List<CoAuthorData> CoAuthors { get; set; }
    public string PageURL { get; set; }

    public string Status { get; set; }

    public string AddedIp { get; set; }

    public DateTime AddedOn { get; set; }
    public static int InsertArticles(SqlConnection conMN, Articles cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into Articles (AuthorGuid,AuthorFullName,AuthorPosition,AuthorAffiliation,AuthorEmailId,AuthorPhoneNo,ArticleTitle," +
                "ArticleAbstract,ArticleKeywords,ArticleType,ArticleWordCount,ArticleTables,ArticleAnyOtherJournal,ArticlePublishedWork,ArticlePrevPublishedWork,ArticlePrevPublishedddl,InterestToDeclare," +
                "DescInterestToDeclare,Organization,DescOrganization,Acknowledgments,EthicalCompliance,DescEthicalCompliance,AttachManuscript,AttachSupplementoryManuscript,Signature,Date,ContactInfoName,ContactInfoEmailId,ContactInfoPhoneNo,AddedOn,AddedIp,Status) values (@AuthorGuid,@AuthorFullName,@AuthorPosition,@AuthorAffiliation,@AuthorEmailId,@AuthorPhoneNo,@ArticleTitle,@ArticleAbstract,@ArticleKeywords,@ArticleType,@ArticleWordCount,@ArticleTables,@ArticleAnyOtherJournal,@ArticlePublishedWork,@ArticlePrevPublishedWork,@ArticlePrevPublishedddl,@InterestToDeclare,@DescInterestToDeclare,@Organization,@DescOrganization,@Acknowledgments,@EthicalCompliance,@DescEthicalCompliance,@AttachManuscript,@AttachSupplementoryManuscript,@Signature,@Date,@ContactInfoName,@ContactInfoEmailId,@ContactInfoPhoneNo,@AddedOn,@AddedIp,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@AuthorFullName", SqlDbType.NVarChar).Value = cat.AuthorFullName;
                sqlCommand.Parameters.AddWithValue("@AuthorGuid", SqlDbType.NVarChar).Value = cat.AuthorGuid;
                sqlCommand.Parameters.AddWithValue("@AuthorPosition", SqlDbType.NVarChar).Value = cat.AuthorPosition;
                sqlCommand.Parameters.AddWithValue("@AuthorAffiliation", SqlDbType.NVarChar).Value = cat.AuthorAffiliation;
                sqlCommand.Parameters.AddWithValue("@AuthorEmailId", SqlDbType.NVarChar).Value = cat.AuthorEmailId;
                sqlCommand.Parameters.AddWithValue("@AuthorPhoneNo", SqlDbType.NVarChar).Value = cat.AuthorPhoneNo;
                sqlCommand.Parameters.AddWithValue("@ArticleTitle", SqlDbType.NVarChar).Value = cat.ArticleTitle;
                sqlCommand.Parameters.AddWithValue("@ArticleAbstract", SqlDbType.NVarChar).Value = cat.ArticleAbstract;
                sqlCommand.Parameters.AddWithValue("@ArticleKeywords", SqlDbType.NVarChar).Value = cat.ArticleKeywords;
                sqlCommand.Parameters.AddWithValue("@ArticleType", SqlDbType.NVarChar).Value = cat.ArticleType;
                sqlCommand.Parameters.AddWithValue("@ArticleWordCount", SqlDbType.NVarChar).Value = cat.ArticleWordCount;
                sqlCommand.Parameters.AddWithValue("@ArticleTables", SqlDbType.NVarChar).Value = cat.ArticleTables;
                sqlCommand.Parameters.AddWithValue("@ArticleAnyOtherJournal", SqlDbType.NVarChar).Value = cat.ArticleAnyOtherJournal;
                sqlCommand.Parameters.AddWithValue("@ArticlePublishedWork", SqlDbType.NVarChar).Value = cat.ArticlePublishedWork;
                sqlCommand.Parameters.AddWithValue("@ArticlePrevPublishedWork", SqlDbType.NVarChar).Value = cat.ArticlePrevPublishedWork;
                sqlCommand.Parameters.AddWithValue("@ArticlePrevPublishedddl", SqlDbType.NVarChar).Value = cat.ArticlePrevPublishedddl;
                sqlCommand.Parameters.AddWithValue("@InterestToDeclare", SqlDbType.NVarChar).Value = cat.InterestToDeclare;
                sqlCommand.Parameters.AddWithValue("@DescInterestToDeclare", SqlDbType.NVarChar).Value = cat.DescInterestToDeclare;
                sqlCommand.Parameters.AddWithValue("@Organization", SqlDbType.NVarChar).Value = cat.Organization;
                sqlCommand.Parameters.AddWithValue("@DescOrganization", SqlDbType.NVarChar).Value = cat.DescOrganization;
                sqlCommand.Parameters.AddWithValue("@Acknowledgments", SqlDbType.NVarChar).Value = cat.Acknowledgments;
                sqlCommand.Parameters.AddWithValue("@EthicalCompliance", SqlDbType.NVarChar).Value = cat.EthicalCompliance;
                sqlCommand.Parameters.AddWithValue("@DescEthicalCompliance", SqlDbType.NVarChar).Value = cat.DescEthicalCompliance;
                sqlCommand.Parameters.AddWithValue("@AttachManuscript", SqlDbType.NVarChar).Value = cat.AttachManuscript;
                sqlCommand.Parameters.AddWithValue("@AttachSupplementoryManuscript", SqlDbType.NVarChar).Value = cat.AttachSupplementoryManuscript;
                sqlCommand.Parameters.AddWithValue("@Signature", SqlDbType.NVarChar).Value = cat.Signature;
                sqlCommand.Parameters.AddWithValue("@ContactInfoPhoneNo", SqlDbType.NVarChar).Value = cat.ContactInfoPhoneNo;
                sqlCommand.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = cat.Date;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@ContactInfoName", SqlDbType.NVarChar).Value = cat.ContactInfoName;
                sqlCommand.Parameters.AddWithValue("@ContactInfoEmailId", SqlDbType.NVarChar).Value = cat.ContactInfoEmailId;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertArticles", ex.Message);
        }


        return result;
    }
    public static int InsertCoAuthors(SqlConnection conMN, CoAuthorData cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into CoAuthors (CoAuthorFullName,CoAuthorPosition,CoAuthorAffiliation,CoAuthorEmailId,AuthorGuid,CoAuthorGuid,AddedOn,Status) values (@CoAuthorFullName,@CoAuthorPosition,@CoAuthorAffiliation,@CoAuthorEmailId,@AuthorGuid,@CoAuthorGuid,@AddedOn,@Status) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {

                sqlCommand.Parameters.AddWithValue("@AuthorGuid", SqlDbType.NVarChar).Value = cat.AuthorGuid;
                sqlCommand.Parameters.AddWithValue("@CoAuthorFullName", SqlDbType.NVarChar).Value = cat.CoAuthorFullName;
                sqlCommand.Parameters.AddWithValue("@CoAuthorPosition", SqlDbType.NVarChar).Value = cat.CoAuthorPosition;
                sqlCommand.Parameters.AddWithValue("@CoAuthorAffiliation", SqlDbType.NVarChar).Value = cat.CoAuthorAffiliation;
                sqlCommand.Parameters.AddWithValue("@CoAuthorEmailId", SqlDbType.NVarChar).Value = cat.CoAuthorEmailId;
                sqlCommand.Parameters.AddWithValue("@CoAuthorGuid", SqlDbType.NVarChar).Value = cat.CoAuthorGuid;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertCoAuthors", ex.Message);
        }

        return result;
    }
    public static List<Articles> GetAllWhitepapers(SqlConnection conMN)
    {
        List<Articles> result = new List<Articles>();
        try
        {
            string query = "select a.*, c.* FROM articles a inner join CoAuthors c on a.AuthorGuid =c.AuthorGuid where a.Status != @Deleted order by a.Id desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new Articles()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              AuthorFullName = Convert.ToString(dr["AuthorFullName"]),
                              AuthorGuid = Convert.ToString(dr["AuthorGuid"]),
                              AuthorPosition = Convert.ToString(dr["AuthorPosition"]),
                              AuthorAffiliation = Convert.ToString(dr["AuthorAffiliation"]),
                              AuthorEmailId = Convert.ToString(dr["AuthorEmailId"]),
                              AuthorPhoneNo = Convert.ToString(dr["AuthorPhoneNo"]),
                              CoAuthorFullName = Convert.ToString(dr["CoAuthorFullName"]),
                              CoAuthorPosition = Convert.ToString(dr["CoAuthorPosition"]),
                              CoAuthorAffiliation = Convert.ToString(dr["CoAuthorAffiliation"]),
                              CoAuthorEmailId = Convert.ToString(dr["CoAuthorEmailId"]),
                              ArticleTitle = Convert.ToString(dr["ArticleTitle"]),
                              ArticleAbstract = Convert.ToString(dr["ArticleAbstract"]),
                              ArticleKeywords = Convert.ToString(dr["ArticleKeywords"]),
                              ArticleType = Convert.ToString(dr["ArticleType"]),
                              ArticleTables = Convert.ToString(dr["ArticleTables"]),
                              ArticleWordCount = Convert.ToString(dr["ArticleWordCount"]),
                              ArticleAnyOtherJournal = Convert.ToString(dr["ArticleAnyOtherJournal"]),
                              ArticlePublishedWork = Convert.ToString(dr["ArticlePublishedWork"]),
                              ArticlePrevPublishedWork = Convert.ToString(dr["ArticlePrevPublishedWork"]),
                              ArticlePrevPublishedddl = Convert.ToString(dr["ArticlePrevPublishedddl"]),
                              InterestToDeclare = Convert.ToString(dr["InterestToDeclare"]),
                              DescInterestToDeclare = Convert.ToString(dr["DescInterestToDeclare"]),
                              Organization = Convert.ToString(dr["Organization"]),
                              DescOrganization = Convert.ToString(dr["DescOrganization"]),
                              Acknowledgments = Convert.ToString(dr["Acknowledgments"]),
                              EthicalCompliance = Convert.ToString(dr["EthicalCompliance"]),
                              DescEthicalCompliance = Convert.ToString(dr["DescEthicalCompliance"]),
                              AttachManuscript = Convert.ToString(dr["AttachManuscript"]),
                              AttachSupplementoryManuscript = Convert.ToString(dr["AttachSupplementoryManuscript"]),
                              Signature = Convert.ToString(dr["Signature"]),
                              ContactInfoName = Convert.ToString(dr["ContactInfoName"]),
                              Date = Convert.ToDateTime(dr["Date"]),
                              ContactInfoEmailId = Convert.ToString(dr["ContactInfoEmailId"]),
                              ContactInfoPhoneNo = Convert.ToString(dr["ContactInfoPhoneNo"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllWhitepapers", ex.Message);
        }

        return result;
    }
    public static int DeleteArticle(SqlConnection conMN, Articles cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Articles Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteArticle", ex.Message);
        }

        return result;
    }
    public static string GetDetailsById(SqlConnection conMN, string id)
    {
        string result = "";

        try
        {
            string query = "select a.*, c.* FROM articles a inner join CoAuthors c on a.AuthorGuid =c.AuthorGuid where a.Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var article = (from DataRow dr in dt.Rows
                               select new Articles()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   AuthorFullName = Convert.ToString(dr["AuthorFullName"]),
                                   AuthorPosition = Convert.ToString(dr["AuthorPosition"]),
                                   AuthorAffiliation = Convert.ToString(dr["AuthorAffiliation"]),
                                   AuthorEmailId = Convert.ToString(dr["AuthorEmailId"]),
                                   AuthorPhoneNo = Convert.ToString(dr["AuthorPhoneNo"]),
                                   CoAuthorFullName = Convert.ToString(dr["CoAuthorFullName"]),
                                   CoAuthorPosition = Convert.ToString(dr["CoAuthorPosition"]),
                                   CoAuthorAffiliation = Convert.ToString(dr["CoAuthorAffiliation"]),
                                   CoAuthorEmailId = Convert.ToString(dr["CoAuthorEmailId"]),
                                   ArticleTitle = Convert.ToString(dr["ArticleTitle"]),
                                   ArticleAbstract = Convert.ToString(dr["ArticleAbstract"]),
                                   ArticleKeywords = Convert.ToString(dr["ArticleKeywords"]),
                                   ArticleType = Convert.ToString(dr["ArticleType"]),
                                   ArticleTables = Convert.ToString(dr["ArticleTables"]),
                                   ArticleWordCount = Convert.ToString(dr["ArticleWordCount"]),
                                   ArticleAnyOtherJournal = Convert.ToString(dr["ArticleAnyOtherJournal"]),
                                   ArticlePublishedWork = Convert.ToString(dr["ArticlePublishedWork"]),
                                   ArticlePrevPublishedWork = Convert.ToString(dr["ArticlePrevPublishedWork"]),
                                   ArticlePrevPublishedddl = Convert.ToString(dr["ArticlePrevPublishedddl"]),
                                   InterestToDeclare = Convert.ToString(dr["InterestToDeclare"]),
                                   DescInterestToDeclare = Convert.ToString(dr["DescInterestToDeclare"]),
                                   Organization = Convert.ToString(dr["Organization"]),
                                   DescOrganization = Convert.ToString(dr["DescOrganization"]),
                                   Acknowledgments = Convert.ToString(dr["Acknowledgments"]),
                                   EthicalCompliance = Convert.ToString(dr["EthicalCompliance"]),
                                   DescEthicalCompliance = Convert.ToString(dr["DescEthicalCompliance"]),
                                   AttachManuscript = Convert.ToString(dr["AttachManuscript"]),
                                   AttachSupplementoryManuscript = Convert.ToString(dr["AttachSupplementoryManuscript"]),
                                   Signature = Convert.ToString(dr["Signature"]),
                                   ContactInfoName = Convert.ToString(dr["ContactInfoName"]),
                                   Date = Convert.ToDateTime(dr["Date"]),
                                   ContactInfoEmailId = Convert.ToString(dr["ContactInfoEmailId"]),
                                   ContactInfoPhoneNo = Convert.ToString(dr["ContactInfoPhoneNo"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).FirstOrDefault();

                result = JsonConvert.SerializeObject(article);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsById", ex.Message);
        }

        return result;
    }
    public static string GetDetailsByGuidDemo(SqlConnection conMN, string AuthorGuid)
    {
        string result = "";

        try
        {
            string query = "select * from CoAuthors where AuthorGuid=@AuthorGuid order by Id desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@AuthorGuid", SqlDbType.NVarChar).Value = AuthorGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                var article = (from DataRow dr in dt.Rows
                               select new Articles()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   CoAuthorFullName = Convert.ToString(dr["CoAuthorFullName"]),
                                   CoAuthorPosition = Convert.ToString(dr["CoAuthorPosition"]),
                                   CoAuthorAffiliation = Convert.ToString(dr["CoAuthorAffiliation"]),
                                   CoAuthorEmailId = Convert.ToString(dr["CoAuthorEmailId"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).FirstOrDefault();

                result = JsonConvert.SerializeObject(article);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsByGuid", ex.Message);
        }

        return result;
    }
    public static string GetDetailsByGuid(SqlConnection conMN, string AuthorGuid)
    {
        List<Articles> coAuthorsList = new List<Articles>();
        string result = "";

        try
        {
            string query = "SELECT * FROM CoAuthors WHERE AuthorGuid = @AuthorGuid ORDER BY Id DESC";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@AuthorGuid", AuthorGuid);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var coAuthor = new Articles
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        CoAuthorFullName = Convert.ToString(dr["CoAuthorFullName"]),
                        CoAuthorPosition = Convert.ToString(dr["CoAuthorPosition"]),
                        CoAuthorAffiliation = Convert.ToString(dr["CoAuthorAffiliation"]),
                        CoAuthorEmailId = Convert.ToString(dr["CoAuthorEmailId"]),
                        Status = Convert.ToString(dr["Status"])
                    };
                    coAuthorsList.Add(coAuthor);
                }

                result = JsonConvert.SerializeObject(coAuthorsList);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDetailsByGuid", ex.Message);
        }

        return result;
    }
}

public class CoAuthorData
{
    public int Id { get; set; }
    public string AuthorGuid { get; set; }
    public string CoAuthorFullName { get; set; }
    public string CoAuthorGuid { get; set; }
    public string CoAuthorPosition { get; set; }
    public string CoAuthorAffiliation { get; set; }
    public string CoAuthorEmailId { get; set; }
    public string Status { get; set; }
    public string AddedIp { get; set; }
    public DateTime AddedOn { get; set; }
}
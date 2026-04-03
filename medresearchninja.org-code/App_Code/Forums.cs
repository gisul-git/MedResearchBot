using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.Web;

/// <summary>
/// Summary description for Forums
/// </summary>
public class Forums
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Topic { get; set; }
    public string PageUrl { get; set; }
    public string Description { get; set; }
    public string UserGuid { get; set; }
    public string Message { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public DateTime AddedOn { get; set; }
    public string MessageGuid { get; set; }
    public string MessageGuid1 { get; set; }
    public string Status { get; set; }
    //Extra 
    public string RowNo { get; set; }
    public string CommentCount { get; set; }
    public string TotalCount { get; set; }
    public string Question { get; set; }
    public List<Comments> comments { get; set; }

    //insert forumsssv
    public static int InsertForums(SqlConnection conMN, Forums frm)
    {
        int result = 0;
        try
        {
            string query = "insert into Forums (Title,Topic,PageUrl,Description,ViewCount,LikeCount,MessageGuid,UserGuid,Status,AddedOn,AddedIp,AddedBy) values (@Title,@Topic,@PageUrl,@Description,@ViewCount,@LikeCount,@MessageGuid,@UserGuid,@Status,@AddedOn, @AddedIp,@AddedBy)";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Title", frm.Title);
                cmd.Parameters.AddWithValue("@Topic", frm.Topic);
                cmd.Parameters.AddWithValue("@PageUrl", frm.PageUrl);
                cmd.Parameters.AddWithValue("@AddedBy", frm.AddedBy);
                cmd.Parameters.AddWithValue("@Description", frm.Description);
                cmd.Parameters.AddWithValue("@UserGuid", frm.UserGuid);
                cmd.Parameters.AddWithValue("@LikeCount", frm.LikeCount);
                cmd.Parameters.AddWithValue("@ViewCount", frm.ViewCount);
                cmd.Parameters.AddWithValue("@MessageGuid", frm.MessageGuid);
                cmd.Parameters.AddWithValue("@Status", frm.Status);
                cmd.Parameters.AddWithValue("@AddedOn", frm.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", frm.AddedIp);

                conMN.Open();
                result = cmd.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertForums", ex.Message);
        }

        return result;
    }
    public static int UpdateCount(SqlConnection _con, int ViewCount, string MessageGuid)
    {
        int result = 0;
        try
        {
            string query = "Update Forums Set ViewCount=@ViewCount Where MessageGuid=@MessageGuid ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@ViewCount", SqlDbType.Int).Value = ViewCount;
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCount", ex.Message);
        }
        return result;
    }
    public static int GetPageCount(SqlConnection _conn, string MessageGuid)
    {
        int count = 0;
        try
        {
            string query = "select top 1 ViewCount as cnt from Forums where MessageGuid=@MessageGuid and Status = 'Accepted'";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int.TryParse(Convert.ToString(dt.Rows[0]["cnt"]), out count);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetPageCount", ex.Message);
        }
        return count;
    }


    public static List<Topics> GetAllTopicsCount(SqlConnection conMN)
    {
        List<Topics> topicsList = new List<Topics>();
        try
        {
            string query = "Select Topic,Count(ID) as TopicCnt from Forums Group by Topic";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Status", "Accepted");

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    var topicInfo = new Topics
                    {
                        Topic = row["Topic"].ToString(),
                        TopicCnt = Convert.ToString(row["TopicCnt"])
                    };
                    topicsList.Add(topicInfo);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTopicsCount", ex.Message);
        }
        return topicsList;
    }



    public static int UpdateLikeCount(SqlConnection _con, int LikeCount, string MessageGuid)
    {
        int result = 0;
        try
        {
            string query = "Update Forums Set LikeCount=@LikeCount Where MessageGuid=@MessageGuid ";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@LikeCount", SqlDbType.Int).Value = LikeCount;
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                _con.Open();
                result = cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateLikeCount", ex.Message);
        }
        return result;
    }

    public static int UpdateBlocked(SqlConnection conMN, Forums user)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update Forums Set Status=@Status Where MessageGuid=@MessageGuid", conMN);
            cmd1.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = user.MessageGuid;
            cmd1.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = user.Status;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateBlocked", ex.Message);
        }
        return x;
    }
    public static int UpdateGuid(SqlConnection conMN, string userGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update Forums Set UserGuid=@UserGuid Where UserGuid=@UserGuid", conMN);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = userGuid;
            conMN.Open();
            x = cmd1.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateGuid", ex.Message);
        }
        return x;
    }


    public static int GetLikeCount(SqlConnection _conn, string MessageGuid)
    {
        int count = 0;
        try
        {
            string query = "select top 1 LikeCount as cntL from Forums where MessageGuid=@MessageGuid and Status = 'Active'";
            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = MessageGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int.TryParse(Convert.ToString(dt.Rows[0]["cntL"]), out count);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetLikeCount", ex.Message);
        }
        return count;
    }

    public static List<Forums> BindMyPosts(SqlConnection conMN, string userGuid)
    {

        List<Forums> result = new List<Forums>();
        try
        {
            string cmdText = "select * from Forums where UserGuid = @userGuid and Status!='Deleted'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@userGuid", SqlDbType.NVarChar).Value = userGuid;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Forums
                          {
                              Title = Convert.ToString(dr["Title"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                              Status = Convert.ToString(dr["Status"]),
                              MessageGuid = Convert.ToString(dr["MessageGuid"])
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindMyPosts", ex.Message);
        }

        return result;
    }


    public static List<Forums> BindForums(SqlConnection conMN)
    {
        List<Forums> result = new List<Forums>();
        try
        {
            string cmdText = "Select Title,Topic,Description,PageUrl,AddedOn,AddedIp,AddedBy,ViewCount,LikeCount,UserGuid,MessageGuid from Forums where Status=@Status Order by Id Desc;";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {

                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Forums
                          {
                              Topic = Convert.ToString(dr["Topic"]),
                              Title = Convert.ToString(dr["Title"]),
                              Description = Convert.ToString(dr["Description"]),
                              PageUrl = Convert.ToString(dr["PageUrl"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              ViewCount = Convert.ToInt32(dr["ViewCount"]),
                              LikeCount = Convert.ToInt32(dr["LikeCount"]),
                              MessageGuid = Convert.ToString(dr["MessageGuid"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindForums", ex.Message);
        }

        return result;
    }


    public static List<Forums> BindForumsAdmin(SqlConnection conMN)
    {
        List<Forums> result = new List<Forums>();
        try
        {
            string cmdText = "Select Title,Topic,Description,PageUrl,AddedOn,AddedIp,AddedBy,ViewCount,LikeCount,UserGuid,MessageGuid from Forums Order by Id Desc;";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Forums
                          {
                              Topic = Convert.ToString(dr["Topic"]),
                              Title = Convert.ToString(dr["Title"]),
                              Description = Convert.ToString(dr["Description"]),
                              PageUrl = Convert.ToString(dr["PageUrl"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              ViewCount = Convert.ToInt32(dr["ViewCount"]),
                              LikeCount = Convert.ToInt32(dr["LikeCount"]),
                              MessageGuid = Convert.ToString(dr["MessageGuid"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindForumsAdmin", ex.Message);
        }

        return result;
    }
    public static List<Forums> BindTop3Forums(SqlConnection conMN)
    {
        List<Forums> result = new List<Forums>();
        try
        {
            string cmdText = "Select top 3 *,(Select Count(Id) from Comments where MessageGuid=Forums.MessageGuid) as CommentCount from Forums where Status='Accepted' Order by Id Desc";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new Forums
                          {
                              Topic = Convert.ToString(dr["Topic"]),
                              Title = Convert.ToString(dr["Title"]),
                              Description = Convert.ToString(dr["Description"]),
                              PageUrl = Convert.ToString(dr["PageUrl"]),
                              AddedIp = Convert.ToString(dr["AddedIp"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              ViewCount = Convert.ToInt32(dr["ViewCount"]),
                              CommentCount = Convert.ToString(dr["CommentCount"]),
                              LikeCount = Convert.ToInt32(dr["LikeCount"]),
                              MessageGuid = Convert.ToString(dr["MessageGuid"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindForumsAdmin", ex.Message);
        }

        return result;
    }


    public static List<Forums> GetCustomerWithGuid(SqlConnection conGV, string PageNo, string PLenght, string Key, string uid)
    {
        int page = (Convert.ToInt32(PageNo) - 1) * Convert.ToInt32(PLenght);
        var result = new List<Forums>();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Forums", conGV);
            cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = uid;
            cmd.Parameters.AddWithValue("@Page", SqlDbType.Int).Value = page;
            cmd.Parameters.AddWithValue("@PageLength", SqlDbType.Int).Value = Convert.ToInt32(PLenght);
            cmd.Parameters.AddWithValue("@Key", SqlDbType.NVarChar).Value = Convert.ToString(Key);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            result = (from DataRow dr in dt.Rows
                      select new Forums()
                      {
                          Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                          Topic = Convert.ToString(dr["Topic"]),
                          Title = Convert.ToString(dr["Title"]),
                          Message = Convert.ToString(dr["Message"]),
                          Description = Convert.ToString(dr["Description"]),
                          UserGuid = Convert.ToString(dr["UserGuid"]),
                          Status = Convert.ToString(dr["Status"]),
                      }).ToList();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCustomerWithGuid", ex.Message);
        }
        return result;
    }
    public static Forums getForumsDetailsByUrl(SqlConnection _con, string MessageGuid)
    {
        Forums frm = new Forums();
        try
        {
            string query = "Select top 1 *,(Select Count(Id) from Comments where MessageGuid=@MessageGuid and Status ='Accepted') as CommentCount from Forums where Status!='Deleted' and MessageGuid=@MessageGuid";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.Int).Value = MessageGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    frm.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    frm.Title = Convert.ToString(dt.Rows[0]["Title"]);
                    frm.Topic = Convert.ToString(dt.Rows[0]["Topic"]);
                    frm.Description = Convert.ToString(dt.Rows[0]["Description"]);
                    frm.ViewCount = Convert.ToInt32(dt.Rows[0]["ViewCount"]);
                    frm.LikeCount = Convert.ToInt32(dt.Rows[0]["LikeCount"]);
                    frm.PageUrl = Convert.ToString(dt.Rows[0]["PageUrl"]);
                    frm.UserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);
                    frm.MessageGuid = Convert.ToString(dt.Rows[0]["MessageGuid"]);
                    frm.CommentCount = Convert.ToString(dt.Rows[0]["CommentCount"]);
                    frm.comments = Comments.GetAllCommentsDetails(_con, Convert.ToString(dt.Rows[0]["MessageGuid"]));
                    frm.AddedOn = Convert.ToDateTime(Convert.ToString(dt.Rows[0]["AddedOn"]));
                    frm.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    frm.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    frm.Status = Convert.ToString(dt.Rows[0]["Status"]);
                }
                else
                {
                    frm = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "getForumsDetailsByUrl", ex.Message);
        }
        return frm;
    }
    public static List<Forums> GetAllForumsDetails(SqlConnection _con)
    {
        List<Forums> categories = new List<Forums>();
        try
        {
            string query = "SELECT *,(SELECT COUNT(Id) FROM Comments WHERE MessageGuid = Forums.MessageGuid) AS CommentCount,(SELECT COUNT(Id) FROM LikesCount WHERE MessageGuid = Forums.MessageGuid) AS LikesCount FROM Forums WHERE Status ='Accepted' ORDER BY Id DESC";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Accepted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Forums()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  Title = Convert.ToString(dr["Title"]),
                                  Topic = Convert.ToString(dr["Topic"]),
                                  Description = Convert.ToString(dr["Description"]),
                                  PageUrl = Convert.ToString(dr["PageUrl"]),
                                  ViewCount = Convert.ToInt32(dr["ViewCount"]),
                                  LikeCount = Convert.ToInt32(dr["LikesCount"]),
                                  UserGuid = Convert.ToString(dr["UserGuid"]),
                                  CommentCount = Convert.ToString(dr["CommentCount"]),
                                  MessageGuid = Convert.ToString(dr["MessageGuid"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllForumsDetails", ex.Message);
        }
        return categories;
    }
    public static List<Forums> GetALLForums(SqlConnection _con, string PageNo, string PLenght, string Key)
    {
        var page = Convert.ToInt32(PLenght) * (Convert.ToInt32(PageNo) - 1);
        List<Forums> categories = new List<Forums>();
        try
        {
            string query = @"SELECT TOP (@PLenght) Id,RowNo, Title, Topic,Description,PageUrl,UserGuid, Status,TotalCount, CommentCount,MessageGuid,AddedOn,AddedBy,AddedIp,Status
                            FROM(
                                        SELECT
                                    ROW_NUMBER() OVER(ORDER BY Id DESC) AS RowNo,
                                    (SELECT COUNT(Id) FROM Forums WHERE Status != 'Deleted' and (@Key = '' OR Title LIKE '%' + @Key + '%' OR Topic LIKE '%' + @Key + '%')) AS TotalCount,
                                    (SELECT COUNT(Id) FROM Comments WHERE MessageGuid = Forums.MessageGuid) AS CommentCount,
                                    *
                                        FROM Forums
                                        WHERE Status != 'Deleted' AND
                                      (@Key = '' OR Title LIKE '%' + @Key + '%' OR Topic LIKE '%' + @Key + '%') 
                            ) AS x
                            WHERE RowNo > @page Order By Id desc;";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Key", SqlDbType.NVarChar).Value = Key;
                cmd.Parameters.AddWithValue("@page", SqlDbType.Int).Value = page;
                cmd.Parameters.AddWithValue("@PLenght", SqlDbType.Int).Value = Convert.ToInt32(PLenght);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Forums()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  RowNo = Convert.ToString(dr["RowNo"]),
                                  Title = Convert.ToString(dr["Title"]),
                                  Topic = Convert.ToString(dr["Topic"]),
                                  Description = Convert.ToString(dr["Description"]),
                                  PageUrl = Convert.ToString(dr["PageUrl"]),
                                  UserGuid = Convert.ToString(dr["UserGuid"]),
                                  CommentCount = Convert.ToString(dr["CommentCount"]),
                                  TotalCount = Convert.ToString(dr["TotalCount"]),
                                  MessageGuid = Convert.ToString(dr["MessageGuid"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllForumsDetails", ex.Message);
        }
        return categories;
    }


    public static List<Forums> GetForumsComments(SqlConnection _con, string PageNo, string PLenght, string Key, string uid)
    {
        List<Forums> frm = new List<Forums>();
        try
        {
            string query = "select c.*, f.Title from comments c inner join forums f ON c.MessageGuid = f.MessageGuid where c.MessageGuid = f.MessageGuid";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                // cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = "";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                frm = (from DataRow dr in dt.Rows
                       select new Forums()
                       {
                           Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                           Title = Convert.ToString(dr["Title"]),
                           Message = Convert.ToString(dr["Message"]),
                           MessageGuid = Convert.ToString(dr["MessageGuid"]),
                           AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                           Status = Convert.ToString(dr["Status"])
                       }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetForumsComments", ex.Message);
        }
        return frm;
    }
    public static List<Forums> GetForumsComments(SqlConnection _con, string uid)
    {
        List<Forums> frm = new List<Forums>();
        try
        {
            string query = "select * from Comments where Status='Accepted' and MessageGuid=@MessageGuid";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@MessageGuid", SqlDbType.NVarChar).Value = uid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                frm = (from DataRow dr in dt.Rows
                       select new Forums()
                       {
                           Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                           Message = Convert.ToString(dr["Message"]),
                           MessageGuid = Convert.ToString(dr["MessageGuid"]),
                           AddedBy = Convert.ToString(dr["AddedBy"]),
                           AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                           Status = Convert.ToString(dr["Status"])
                       }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetForumsComments", ex.Message);
        }
        return frm;
    }



    public static List<Topics> GetAllForumsTopics(SqlConnection _con)
    {
        List<Topics> categories = new List<Topics>();
        try
        {
            string query = "Select Top 10 Topic,Count(ID) as cnt from Forums Where Status !='Deleted' Group by Topic Order by cnt desc";
            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new Topics()
                              {
                                  Topic = Convert.ToString(Convert.ToString(dr["Topic"])),
                                  TopicCnt = Convert.ToString(Convert.ToString(dr["cnt"])),
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllForumsDetails", ex.Message);
        }
        return categories;
    }
    public static void MergeGuestActivity(SqlConnection _con, string guestGuid, string userGuid, string userName)
    {
        try
        {
            string query = "UPDATE Forums SET UserGuid = @UserGuid, AddedBy = @AddedBy WHERE UserGuid = @GuestGuid";

            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@UserGuid", userGuid);
                cmd.Parameters.AddWithValue("@AddedBy", userName);
                cmd.Parameters.AddWithValue("@GuestGuid", guestGuid);
                _con.Open();
                cmd.ExecuteNonQuery();
                _con.Close();
                 
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MergeGuestActivity", ex.Message);
        }
    }
    
    public static void MergeGuestLikes(SqlConnection con, string guestGuid, string userGuid)
    {
        string query = "UPDATE LikesCount SET UserGuid=@UserGuid WHERE UserGuid=@GuestGuid";
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@UserGuid", userGuid);
            cmd.Parameters.AddWithValue("@GuestGuid", guestGuid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public static void MergeGuestComments(SqlConnection _con, string guestGuid, string userGuid, string userName)
    {
        try
        {
            string query = "UPDATE Comments SET UserGuid=@UserGuid, AddedBy=@AddedBy WHERE UserGuid=@GuestGuid";

            using (SqlCommand cmd = new SqlCommand(query, _con))
            {
                cmd.Parameters.AddWithValue("@UserGuid", userGuid);
                cmd.Parameters.AddWithValue("@AddedBy", userName); 
                cmd.Parameters.AddWithValue("@GuestGuid", guestGuid);

                _con.Open();
                cmd.ExecuteNonQuery();
                _con.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "MergeGuestComments", ex.Message);
        }
    }

}

public class Topics
{
    public string Topic { get; set; }
    public string TopicCnt { get; set; }
}
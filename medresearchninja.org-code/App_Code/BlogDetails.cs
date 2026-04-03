using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BlogDetails
/// </summary>
public class BlogDetails
{
    public BlogDetails()
    {

    }

    #region Blog Details Properties
    public int Id { get; set; }
    public string ThumbImage { get; set; }
    public string BlogImage { get; set; }
    public string BlogTitle { get; set; }
    public string BlogUrl { get; set; }
    public string PostedBy { get; set; }
    public string PageTitle { get; set; }
    public string MetaKeys { get; set; }
    public string MetaDesc { get; set; }
    public string FullDesc { get; set; }
    public string AddedBy { get; set; }
    public string PostedOn { get; set; }
    public string DisplayHome { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string Status { get; set; }
    public string ShortDesc { get; set; }
    public int RowNumber { get; set; }
    public int TotalCount { get; set; }
    #endregion
    #region BlogDetails Methods

    /// <summary>
    /// Retrieves all details of a blog entry with a specific ID from the database.
    /// </summary>
    /// <param name="conDT">The SQL connection object.</param>
    /// <param name="id">The ID of the blog entry to retrieve.</param>
    /// <returns>A list of BlogDetails objects containing the details of the specified blog entry.</returns>

    public static List<BlogDetails> GetAllBlogDetailsWithId(SqlConnection conDT, int id)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select * from BlogDetails where Status=@Status and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToString(dr["PostedOn"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetailsWithId", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves all details of a blog entry with a specific URL from the database.
    /// </summary>
    /// <param name="conDT">The SQL connection object.</param>
    /// <param name="Url">The URL of the blog entry to retrieve.</param>
    /// <returns>A list of BlogDetails objects containing the details of the specified blog entry.</returns>

    public static List<BlogDetails> GetAllBlogDetailsWithUrl(SqlConnection conDT, string Url)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select * from BlogDetails where Status=@Status and BlogUrl=@BlogUrl ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.Int).Value = Url;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToString(dr["PostedOn"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetailsWithUrl", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves all details of all blog entries from the database.
    /// </summary>
    /// <param name="conDT">The SQL connection object.</param>
    /// <returns>A list of BlogDetails objects containing the details of all blog entries.</returns>

    public static List<BlogDetails> GetRecentBlogs(SqlConnection conDT)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select Top 3 *,(Select UserName from CreateUser Where UserGuid=BlogDetails.AddedBy) as UpdatedBy from BlogDetails where Status=@Status Order by AddedOn ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToString(dr["PostedOn"]),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetails", ex.Message);
        }
        return categories;
    }
    public static List<BlogDetails> GetRecentBlogsForFooter(SqlConnection conDT)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select Top 6 *,(Select UserName from CreateUser Where UserGuid=BlogDetails.AddedBy) as UpdatedBy from BlogDetails where Status=@Status Order by AddedOn ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToString(dr["PostedOn"]),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetails", ex.Message);
        }
        return categories;
    }
    public static List<BlogDetails> GetAllBlogDetails(SqlConnection conDT)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=BlogDetails.AddedBy) as UpdatedBy from BlogDetails where Status!='Deleted' Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToString(dr["PostedOn"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetails", ex.Message);
        }
        return categories;
    }
    public static List<BlogDetails> GetAllListBlogDetails(SqlConnection conDT, int cPage)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            var query = @"Select top 8 * from (Select ROW_NUMBER() OVER(ORDER BY Id DESC) AS RowNo,(select count(id) from BlogDetails where status='Active') as TotalCount,* 
  from BlogDetails
where Status='Active') x where RowNo > " + (8 * (cPage - 1));
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  RowNumber = Convert.ToInt32(Convert.ToString(dr["RowNo"])),
                                  TotalCount = Convert.ToInt32(Convert.ToString(dr["TotalCount"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  PostedOn = Convert.ToDateTime(Convert.ToString(dr["PostedOn"])).ToString("MMM dd , yyyy"),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  DisplayHome = Convert.ToString(dr["DisplayHome"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetails", ex.Message);
        }
        return categories;
    }
    public static int InsertBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into BlogDetails (ThumbImage,BlogImage,BlogTitle,BlogUrl,PostedBy,PageTitle,MetaKeys,MetaDesc,FullDesc,PostedOn,AddedOn,AddedBy,AddedIP,Status,DisplayHome,ShortDesc) values" +
                           "(@ThumbImage,@BlogImage,@BlogTitle,@BlogUrl,@PostedBy,@PageTitle,@MetaKeys,@MetaDesc,@FullDesc,@PostedOn,@AddedOn,@AddedBy,@AddedIP,@Status,@DisplayHome,@ShortDesc)";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@BlogImage", SqlDbType.NVarChar).Value = cat.BlogImage;
                cmd.Parameters.AddWithValue("@BlogTitle", SqlDbType.NVarChar).Value = cat.BlogTitle;
                cmd.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.NVarChar).Value = cat.BlogUrl;
                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = cat.PostedBy;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
                cmd.Parameters.AddWithValue("@PostedOn", SqlDbType.NVarChar).Value = cat.PostedOn;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@DisplayHome", SqlDbType.NVarChar).Value = "Yes";
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertBlogDetails", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Updates the details of an existing blog entry in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="cat">The BlogDetails object containing the updated details of the blog entry.</param>
    /// <returns>The number of rows affected by the update operation.</returns>

    public static int UpdateBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update BlogDetails Set DisplayHome=@DisplayHome,ShortDesc=@ShortDesc,ThumbImage=@ThumbImage,BlogImage=@BlogImage,PostedOn = @PostedOn,PostedBy=@PostedBy,BlogTitle=@BlogTitle,BlogUrl=@BlogUrl,PageTitle=@PageTitle,MetaKeys=@MetaKeys,MetaDesc=@MetaDesc,FullDesc=@FullDesc,AddedOn=@AddedOn,AddedBy=@AddedBy,AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@ShortDesc", SqlDbType.NVarChar).Value = cat.ShortDesc;
                cmd.Parameters.AddWithValue("@BlogImage", SqlDbType.NVarChar).Value = cat.BlogImage;
                cmd.Parameters.AddWithValue("@BlogTitle", SqlDbType.NVarChar).Value = cat.BlogTitle;
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.NVarChar).Value = cat.BlogUrl;
                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = cat.PostedBy;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
                cmd.Parameters.AddWithValue("@PostedOn", SqlDbType.NVarChar).Value = cat.PostedOn;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@DisplayHome", SqlDbType.NVarChar).Value = "Yes";
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateBlogDetails", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Deletes the details of a blog entry from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="cat">The BlogDetails object containing the details of the blog entry to be deleted.</param>
    /// <returns>The number of rows affected by the delete operation.</returns>

    public static int DeleteBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update BlogDetails Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteBlogDetails", ex.Message);
        }
        return result;
    }
    #endregion
    public static decimal NoOfBlogDetails(SqlConnection conZP)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from BlogDetails Where  Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conZP);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfBlogDetails", ex.Message);
        }
        return x;
    }
    public static int PublishBlogDetails(SqlConnection conAP, BlogDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update BlogDetails Set Status=@Status Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conAP))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conAP.Open();
                result = cmd.ExecuteNonQuery();
                conAP.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "PublishBlogDetails", ex.Message);
        }
        return result;
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderTimeline
/// </summary>
public class OrderTimeline
{
    #region OrderTimeline Properties
    public int Id { get; set; }
    public string OrderGuid { get; set; }
    public string OrderStatus { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    #endregion

    #region OrderTimeline Methods
    /// <summary>
    /// Retrieves the timeline details of an order from the database based on the order's unique identifier (GUID).
    /// </summary>
    /// <param name="conMN">The SQL connection object.</param>
    /// <param name="guid">The unique identifier (GUID) of the order.</param>
    /// <returns>A list of OrderTimeline objects containing timeline details of the specified order.</returns>

    public static List<OrderTimeline> GetOrderTimeline(SqlConnection conMN, string guid)
    {
        var categories = new List<OrderTimeline>();
        try
        {
            string query = "Select * from OrderTimeline where OrderGuid=@OrderGuid ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.Int).Value = guid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new OrderTimeline()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  OrderGuid = Convert.ToString(dr["OrderGuid"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  OrderStatus = Convert.ToString(dr["OrderStatus"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetGroupDetailsWithUrl", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Adds a new timeline entry for an order to the database.
    /// </summary>
    /// <param name="conMN">The SQL connection object.</param>
    /// <param name="timeline">An OrderTimeline object containing details of the timeline entry to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddTimeline(SqlConnection conMN, OrderTimeline timeline)
    {
        int result = 0;
        try
        {
            string query = "Insert Into OrderTimeline (OrderGuid,AddedOn,AddedIp,OrderStatus,AddedBy) values (@OrderGuid,@AddedOn,@AddedIp,@OrderStatus,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = timeline.OrderGuid;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = timeline.AddedBy;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = timeline.OrderStatus;
                conMN.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTimeline", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Checks if an order timeline entry with a specific order GUID and timeline status exists in the database.
    /// </summary>
    /// <param name="conMN">The SQL connection object.</param>
    /// <param name="Oguid">The GUID of the order.</param>
    /// <param name="OrderStatus">The status of the timeline entry.</param>
    /// <returns>An integer representing the number of matching records found in the database.</returns>
    public static int CheckOrderTimelineExist(SqlConnection conMN, string Oguid, string OrderStatus)
    {
        int result = 0;
        try
        {
            string query = "Count (ID) as cnt From OrderTimeline Where OrderGuid=@OrderGuid and OrderStatus=@OrderStatus ";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = Oguid;
                cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = OrderStatus;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = Convert.ToInt32(dt.Rows[0]["cnt"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTimeline", ex.Message);
        }
        return result;
    }
    #endregion
}
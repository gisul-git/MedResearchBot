using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DashBoard
/// </summary>
public class DashBoard
{
    public DashBoard()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    /// <summary>
    /// Get all  orders from db 
    /// </summary>
    /// <param name="conMN">DB connection</param>
    /// <returns>All list</returns>


    public static decimal GetTotalSales(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = "Select Sum(try_convert(decimal, TotalPrice)) as TotalPrice from POrders Where  PaymentStatus='Paid' and Status != 'Deleted'";
            string query2 = "Select Sum(try_convert(decimal, TotalPrice)) as TotalPrice from Orders Where  PaymentStatus='Paid' and Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlCommand cmd2 = new SqlCommand(query2, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            sda.Fill(dt);
            sda2.Fill(dt2);
            if (dt.Rows.Count > 0&&dt2.Rows.Count>0)
            {
                decimal cnt = 0;
                decimal cnt1 = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalPrice"]), out cnt);
                decimal.TryParse(Convert.ToString(dt2.Rows[0]["TotalPrice"]), out cnt1);
                x = cnt+cnt1;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTotalSales", ex.Message);
        }
        return x;
    }


    public static int GetOrderCount(SqlConnection conMN)
    {
        int x = 0;
        try
        {
            string query = " Select * from POrders Where Status!= 'Deleted' and OrderStatus!='Initiated'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            x = dt.Rows.Count;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderCount", ex.Message);
        }
        return x;
    }





    public static int GetCustomerCount(SqlConnection conMN)
    {
        int x = 0;
        try
        {
            string query = " Select * from CustomerDetails Where Status='Active'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            x = dt.Rows.Count;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetStudentCount", ex.Message);
        }
        return x;
    }

    public static int GetCustomerCountbyAguid(SqlConnection conMN)
    {
        int x = 0;
        try
        {
            string query = "Select * from CustomerDetails Where Status='Active' and ArchitectGuid=@ArchitectGuid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@ArchitectGuid", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Request.Cookies["arc_aaid"].Value);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            x = dt.Rows.Count;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetCustomerCountbyAguid", ex.Message);
        }
        return x;
    }
    public static int GetArchitectCount(SqlConnection conMN)
    {
        int x = 0;
        try
        {
            string query = " Select * from ArchitectDetails Where Status='Published'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            x = dt.Rows.Count;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetStudentCount", ex.Message);
        }
        return x;
    }





    public static decimal NoOfContacts(SqlConnection conMN)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from ContactUs Where  Status != 'Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cnt = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntB"]), out cnt);
                x = cnt;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTotalSales", ex.Message);
        }
        return x;
    }

    public static decimal TodaysOrder(SqlConnection conMN, string tDay)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from Orders Where  PaymentStatus = 'Paid' and Try_Convert(date, AddedOn)=@tDay";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@tDay", SqlDbType.NVarChar).Value = tDay;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cnt = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntB"]), out cnt);
                x = cnt;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfEmailSubscriptiond", ex.Message);
        }
        return x;
    }

    public static decimal MonthsOrder(SqlConnection conMN, string mnth, string yr)
    {
        decimal x = 0;
        try
        {
            string query = " Select Count(Id) as cntB from Orders Where  PaymentStatus = 'Paid' and (Month(AddedOn) = @mnth and Year(AddedOn) = @yr)";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@mnth", SqlDbType.NVarChar).Value = mnth;
            cmd.Parameters.AddWithValue("@yr", SqlDbType.NVarChar).Value = yr;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                decimal cnt = 0;
                decimal.TryParse(Convert.ToString(dt.Rows[0]["cntB"]), out cnt);
                x = cnt;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfEmailSubscriptiond", ex.Message);
        }
        return x;
    }




}


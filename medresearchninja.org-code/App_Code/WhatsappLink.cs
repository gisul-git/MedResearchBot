using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WhatsappLink
/// </summary>
public class WhatsappLink
{
    public int id { get; set; }
    public string Wlink { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }



    public static int InsertWhatsappLink(SqlConnection conMN, WhatsappLink cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Insert Into WhatsappLink (Wlink,Status,AddedIP,AddedOn,AddedBy) values(@Wlink,@Status,@AddedIP,@AddedOn,@AddedBy) ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Wlink", SqlDbType.NVarChar).Value = cat.Wlink;
                sqlCommand.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = cat.Status;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertWhatsappLink", ex.Message);
        }

        return result;
    }
    public static int UpdateWhatsappLink(SqlConnection conMN, WhatsappLink cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update WhatsappLink Set Wlink=@Wlink";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Wlink", SqlDbType.NVarChar).Value = cat.Wlink;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateWhatsappLink", ex.Message);
        }

        return result;
    }
    public static List<WhatsappLink> GetAllWhatsappLink(SqlConnection conMN)
    {
        List<WhatsappLink> result = new List<WhatsappLink>();
        try
        {
            string cmdText = "Select * from WhatsappLink where Status='Active'";
            using (SqlCommand selectCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new WhatsappLink
                          {
                              id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Wlink = Convert.ToString(dr["Wlink"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllWhatsappLink", ex.Message);
        }

        return result;
    }

    public static List<WhatsappLink> GetWhatsappLink(SqlConnection conMN, int id)
    {
        List<WhatsappLink> result = new List<WhatsappLink>();
        try
        {
            string cmdText = "Select * from WhatsappLink where Status=@Status and Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new WhatsappLink
                          {
                              id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              Wlink = Convert.ToString(dr["Wlink"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              AddedBy = Convert.ToString(dr["AddedBy"]),
                              AddedIP = Convert.ToString(dr["AddedIP"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetWhatsappLink", ex.Message);
        }

        return result;
    }
    public static int DeleteWhatsappLink(SqlConnection conMN, WhatsappLink cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update WhatsappLink Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteWhatsappLink", ex.Message);
        }

        return result;
    }
}
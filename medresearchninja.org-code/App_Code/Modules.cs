using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Modules
{
    public int Id { get; set; }
    public string ModuleName { get; set; }
    public string ModuleType { get; set; }
    public string videolink { get; set; }
    public string TextContent { get; set; }
    public string FullDesc { get; set; }
    public DateTime AddedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string AddedIp { get; set; }
    public string UpdatedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    #region Modules
    public static int InsertModules(SqlConnection conMN, Modules module)
    {
        int result = 0;
        try
        {
            string cmdText = "INSERT INTO Modules (ModuleName, ModuleType, videolink, TextContent, FullDesc, AddedOn, AddedIp, AddedBy, Status,UpdatedOn,UpdatedIp) " +
                           "VALUES (@ModuleName, @ModuleType, @videolink, @TextContent, @FullDesc, @AddedOn, @AddedIp, @AddedBy, @Status,@UpdatedOn,@UpdatedIp)";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ModuleName", SqlDbType.NVarChar).Value = module.ModuleName;
                sqlCommand.Parameters.AddWithValue("@ModuleType", SqlDbType.NVarChar).Value = module.ModuleType;
                sqlCommand.Parameters.AddWithValue("@videolink", SqlDbType.NVarChar).Value = module.videolink;
                sqlCommand.Parameters.AddWithValue("@TextContent", SqlDbType.NVarChar).Value = module.TextContent;
                sqlCommand.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = module.FullDesc;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = module.AddedOn;
                sqlCommand.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = module.UpdatedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = module.AddedIp;
                sqlCommand.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = module.UpdatedIp;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = module.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = module.Status;

                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertModules", ex.Message);
        }
        return result;
    }

    public static int UpdateModules(SqlConnection conMN, Modules module)
    {
        int result = 0;
        try
        {
            string cmdText = "UPDATE Modules SET ModuleName=@ModuleName, ModuleType=@ModuleType, videolink=@videolink, " +
                           "TextContent=@TextContent, FullDesc=@FullDesc, AddedOn=@AddedOn, AddedIp=@AddedIp, " +
                           "AddedBy=@AddedBy, Status=@Status,UpdatedOn=@UpdatedOn,UpdatedIp=@UpdatedIp WHERE Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = module.Id;
                sqlCommand.Parameters.AddWithValue("@ModuleName", SqlDbType.NVarChar).Value = module.ModuleName;
                sqlCommand.Parameters.AddWithValue("@ModuleType", SqlDbType.NVarChar).Value = module.ModuleType;
                sqlCommand.Parameters.AddWithValue("@videolink", SqlDbType.NVarChar).Value = module.videolink;
                sqlCommand.Parameters.AddWithValue("@TextContent", SqlDbType.NVarChar).Value = module.TextContent;
                sqlCommand.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = module.FullDesc;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = module.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = module.AddedIp;
                sqlCommand.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = module.AddedBy;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = module.Status;
                sqlCommand.Parameters.AddWithValue("@UpdatedOn", SqlDbType.DateTime).Value = module.UpdatedOn;
                sqlCommand.Parameters.AddWithValue("@UpdatedIp", SqlDbType.NVarChar).Value = module.UpdatedIp;

                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateModules", ex.Message);
        }
        return result;
    }

    public static int DeleteModules(SqlConnection conMN, Modules module)
    {
        int result = 0;
        try
        {
            string cmdText = "UPDATE Modules SET Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp WHERE Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = module.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = module.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = module.AddedIp;

                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteModules", ex.Message);
        }
        return result;
    }

    public static Modules GetModulesDetailsById(SqlConnection conMN,int id)
    {
        Modules module = new Modules();
        try
        {
            string cmdText = "SELECT * FROM Modules WHERE Status != 'Deleted' AND Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    module.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    module.ModuleName = Convert.ToString(dt.Rows[0]["ModuleName"]);
                    module.ModuleType = Convert.ToString(dt.Rows[0]["ModuleType"]);
                    module.videolink = Convert.ToString(dt.Rows[0]["videolink"]);
                    module.TextContent = Convert.ToString(dt.Rows[0]["TextContent"]);
                    module.FullDesc = Convert.ToString(dt.Rows[0]["FullDesc"]);
                    module.AddedOn = Convert.ToDateTime(dt.Rows[0]["AddedOn"]);
                    module.AddedIp = Convert.ToString(dt.Rows[0]["AddedIp"]);
                    module.AddedBy = Convert.ToString(dt.Rows[0]["AddedBy"]);
                    module.Status = Convert.ToString(dt.Rows[0]["Status"]);
                    module.UpdatedOn = Convert.ToDateTime(dt.Rows[0]["UpdatedOn"]);
                    module.UpdatedIp = Convert.ToString(dt.Rows[0]["UpdatedIp"]);
                }
                else
                {
                    module = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetModulesDetailsById", ex.Message);
        }
        return module;
    }

    public static List<Modules> GetModulesByType(SqlConnection conMN, string moduleType)
    {
        List<Modules> modules = new List<Modules>();
        try
        {
            string cmdText = "SELECT * FROM Modules WHERE Status != 'Deleted' AND ModuleType=@ModuleType ORDER BY Id DESC";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@ModuleType", SqlDbType.NVarChar).Value = moduleType;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                modules = (from DataRow dr in dt.Rows
                           select new Modules
                           {
                               Id = Convert.ToInt32(dr["Id"]),
                               ModuleName = Convert.ToString(dr["ModuleName"]),
                               ModuleType = Convert.ToString(dr["ModuleType"]),
                               videolink = Convert.ToString(dr["videolink"]),
                               TextContent = Convert.ToString(dr["TextContent"]),
                               FullDesc = Convert.ToString(dr["FullDesc"]),
                               AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                               AddedIp = Convert.ToString(dr["AddedIp"]),
                               AddedBy = Convert.ToString(dr["AddedBy"]),
                               Status = Convert.ToString(dr["Status"]),
                               UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                               UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                           }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetModulesByType", ex.Message);
        }
        return modules;
    }
    public static List<Modules> GetAllModules(SqlConnection conMN)
    {
        List<Modules> modules = new List<Modules>();
        try
        {
            string cmdText = "SELECT *, (SELECT UserName FROM CreateUser WHERE UserGuid = m.AddedBy) as UpdatedBy " +
                              "FROM Modules m WHERE Status != 'Deleted' ORDER BY Id DESC";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                modules = (from DataRow dr in dt.Rows
                           select new Modules
                           {
                               Id = Convert.ToInt32(dr["Id"]),
                               ModuleName = Convert.ToString(dr["ModuleName"]),
                               ModuleType = Convert.ToString(dr["ModuleType"]),
                               videolink = Convert.ToString(dr["videolink"]),
                               TextContent = Convert.ToString(dr["TextContent"]),
                               FullDesc = Convert.ToString(dr["FullDesc"]),
                               AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                               AddedIp = Convert.ToString(dr["AddedIp"]),
                               AddedBy = Convert.ToString(dr["AddedBy"]),
                               Status = Convert.ToString(dr["Status"]),
                               UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]),
                               UpdatedIp = Convert.ToString(dr["UpdatedIp"]),
                           }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetModulesByType", ex.Message);
        }
        return modules;
    }
    public static int NoOfModules(SqlConnection conMN)
    {
        int count = 0;
        try
        {
            string cmdText = "SELECT COUNT(Id) as cnt FROM Modules WHERE Status != 'Deleted'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "NoOfModules", ex.Message);
        }
        return count;
    }

    public static int UpdateModuleStatus(SqlConnection conMN, Modules module)
    {
        int result = 0;
        try
        {
            string cmdText = "UPDATE Modules SET Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp WHERE Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = module.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = module.Status;
                sqlCommand.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = module.AddedOn;
                sqlCommand.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = module.AddedIp;

                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateModuleStatus", ex.Message);
        }
        return result;
    }
    #endregion
}
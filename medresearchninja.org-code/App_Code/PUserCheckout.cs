using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using DocumentFormat.OpenXml.Bibliography;

/// <summary>
/// Summary description for PUserCheckout
/// </summary>
public class PUserCheckout
{

    public static string GetOMax(SqlConnection conMN)
    {
        string x = "";
        try
        {
            SqlCommand cmd3 = new SqlCommand("Select Max(id) as mid from POrders", conMN);
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt3.Rows[0]["mid"]);
                if (cc == "")
                {
                    cc = "0000";
                }
                x = (Convert.ToInt32(cc) + 1).ToString();
                if (x.Length <= 4)
                {
                    x = Convert.ToInt32(x).ToString("0000");
                }
            }
        }
        catch (Exception ex)
        {
            x = "0001";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOMax", ex.Message);
        }
        return x;
    }

    public static string GetRMax(SqlConnection conMN)
    {
        string x = "";
        try
        {
            SqlCommand cmd3 = new SqlCommand("Select Max(try_convert(decimal, RMax)) as mid from POrders", conMN);
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt3.Rows[0]["mid"]);
                if (cc == "")
                {
                    cc = "0000";
                }
                x = (Convert.ToInt32(cc) + 1).ToString();
                if (x.Length <= 4)
                {
                    x = Convert.ToInt32(x).ToString("0000");
                }
            }
        }
        catch (Exception ex)
        {
            x = "0001";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetRMax", ex.Message);
        }
        return x;
    }
    public static int InsertCheckOutItem(SqlConnection conMN, PCheckoutItems cItems)
    {
        int x = 0;
        try
        {
            SqlCommand cmdItem = new SqlCommand("Insert into OrderItems (OrderGuid,ProductId,ProductName,TaxGroup,PriceId,Qty,Price,ActualPrice,Size,AddedOn,ProductUrl,ProductImage,ProductGuid) values (@OrderGuid,@ProductId,@ProductName,@TaxGroup,@PriceId,@Qty,@Price,@ActualPrice,@Size,@AddedOn,@ProductUrl,@ProductImage,@ProductGuid)", conMN);
            cmdItem.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = cItems.OrderGuid;
            cmdItem.Parameters.AddWithValue("@ProductId", SqlDbType.NVarChar).Value = cItems.ProductId;
            cmdItem.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = cItems.ProductName;
            cmdItem.Parameters.AddWithValue("@TaxGroup", SqlDbType.NVarChar).Value = cItems.TaxGroup;
            cmdItem.Parameters.AddWithValue("@PriceId", SqlDbType.NVarChar).Value = cItems.PriceId;
            cmdItem.Parameters.AddWithValue("@Qty", SqlDbType.NVarChar).Value = cItems.Qty;
            cmdItem.Parameters.AddWithValue("@Price", SqlDbType.NVarChar).Value = cItems.Price;
            cmdItem.Parameters.AddWithValue("@ActualPrice", SqlDbType.NVarChar).Value = cItems.ActualPrice;
            cmdItem.Parameters.AddWithValue("@Size", SqlDbType.NVarChar).Value = cItems.Size;
            cmdItem.Parameters.AddWithValue("@ProductUrl", SqlDbType.NVarChar).Value = cItems.ProductUrl;
            cmdItem.Parameters.AddWithValue("@ProductImage", SqlDbType.NVarChar).Value = cItems.ProductImage;
            cmdItem.Parameters.AddWithValue("@ProductGuid", SqlDbType.NVarChar).Value = cItems.ProductGuid;
            cmdItem.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cItems.AddedOn;
            conMN.Open();
            x = cmdItem.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertCheckOutItem", ex.Message);
        }
        finally
        {
            conMN.Close();
        }
        return x;
    }
    public static int InsertBillingAddress(SqlConnection conMN, PUserBillingAddress address)
    {
        int x = 0;
        try
        {
            SqlCommand cmdBuyer = new SqlCommand("Insert into PUserBillingAddress (AltMobile,CompanyName,CustomerGSTN,Salutation,EmailId,UserGuid, OrderGuid,FirstName,LastName,Mobile,Address1,Address2,City,Country,Zip,AddedDateTime,AddedIp,State,Landmark,Block) values (@AltMobile, @CompanyName,@CustomerGSTN,@Salutation,@EmailId,@UserGuid, @OrderGuid,@FirstName,@LastName,@Mobile,@Address1,@Address2,@City,@Country,@Zip,@AddedDateTime,@AddedIp,@State,@Landmark,@Block)", conMN);
            cmdBuyer.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = address.OrderGuid;
            cmdBuyer.Parameters.AddWithValue("@CustomerGSTN", SqlDbType.NVarChar).Value = address.CustomerGSTN; cmdBuyer.Parameters.AddWithValue("@CompanyName", SqlDbType.NVarChar).Value = address.CompanyName;
            cmdBuyer.Parameters.AddWithValue("@Salutation", SqlDbType.NVarChar).Value = address.Salutation;
            cmdBuyer.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = address.UserGuid;
            cmdBuyer.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = address.FirstName;
            cmdBuyer.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = address.LastName;
            cmdBuyer.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = address.AddedIp;
            cmdBuyer.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = address.Country;
            cmdBuyer.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = address.State;
            cmdBuyer.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = address.Mobile;
            cmdBuyer.Parameters.AddWithValue("@AltMobile", SqlDbType.NVarChar).Value = address.AltMobile;
            cmdBuyer.Parameters.AddWithValue("@Address1", SqlDbType.NVarChar).Value = address.Address1;
            cmdBuyer.Parameters.AddWithValue("@Address2", SqlDbType.NVarChar).Value = address.Address2;
            cmdBuyer.Parameters.AddWithValue("@Block", SqlDbType.NVarChar).Value = address.Block;
            cmdBuyer.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = address.City;
            cmdBuyer.Parameters.AddWithValue("@Zip", SqlDbType.NVarChar).Value = address.Zip;
            cmdBuyer.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = address.EmailId;
            cmdBuyer.Parameters.AddWithValue("@Landmark", SqlDbType.NVarChar).Value = address.Landmark;
            cmdBuyer.Parameters.AddWithValue("@AddedDateTime", SqlDbType.NVarChar).Value = address.AddedDateTime;
            conMN.Open();
            x = cmdBuyer.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertBillingAddress", ex.Message);
        }
        return x;
    }
    public static int InsertDeliveryAddress(SqlConnection conMN, PUserDeliveryAddress address)
    {
        int x = 0;
        try
        {
            SqlCommand cmdBuyer = new SqlCommand("Insert into PUserDeliveryAddress (AltMobile, Salutation,UserGuid, OrderGuid,FirstName,LastName,Mobile,Address1,Address2,City,Country,Zip,AddedDateTime,AddedIp,State,Landmark,Block,Email,Apartment) values (@AltMobile, @Salutation,@UserGuid, @OrderGuid,@FirstName,@LastName,@Mobile,@Address1,@Address2,@City,@Country,@Zip,@AddedDateTime,@AddedIp,@State,@Landmark,@Block,@Email,@Apartment)", conMN);
            cmdBuyer.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = address.OrderGuid;
            cmdBuyer.Parameters.AddWithValue("@Salutation", SqlDbType.NVarChar).Value = address.Salutation;
            cmdBuyer.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = address.UserGuid;
            cmdBuyer.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = address.FirstName;
            cmdBuyer.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = address.LastName;
            cmdBuyer.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = address.Mobile;
            cmdBuyer.Parameters.AddWithValue("@AltMobile", SqlDbType.NVarChar).Value = address.AltMobile;
            cmdBuyer.Parameters.AddWithValue("@Address1", SqlDbType.NVarChar).Value = address.Address1;
            cmdBuyer.Parameters.AddWithValue("@Address2", SqlDbType.NVarChar).Value = address.Address2;
            cmdBuyer.Parameters.AddWithValue("@Country", SqlDbType.NVarChar).Value = address.Country;
            cmdBuyer.Parameters.AddWithValue("@City", SqlDbType.NVarChar).Value = address.City;
            cmdBuyer.Parameters.AddWithValue("@Zip", SqlDbType.NVarChar).Value = address.Zip;
            cmdBuyer.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = address.AddedIp;
            cmdBuyer.Parameters.AddWithValue("@State", SqlDbType.NVarChar).Value = address.State;
            cmdBuyer.Parameters.AddWithValue("@Landmark", SqlDbType.NVarChar).Value = address.Landmark;
            cmdBuyer.Parameters.AddWithValue("@Apartment", SqlDbType.NVarChar).Value = address.Apartment;
            cmdBuyer.Parameters.AddWithValue("@Block", SqlDbType.NVarChar).Value = address.Block;
            cmdBuyer.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = address.Email;
            cmdBuyer.Parameters.AddWithValue("@AddedDateTime", SqlDbType.NVarChar).Value = address.AddedDateTime;
            conMN.Open();
            x = cmdBuyer.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertDeliveryAddress", ex.Message);
        }
        return x;
    }
    public static int CreateUserOrder1(SqlConnection conMN, POrders order)
    {
        int x = 0;
        try
        {
            SqlCommand cmdOrder = new SqlCommand("Insert into POrders (BalAmount, AdvAmount,Status,CODAmount,OrderGuid,OrderId, UserGuid,OrderMax,ReceiptNo,RMax,SubTotal,ShippingPrice,Tax,Discount,TotalPrice,PromoCode,UserType,OrderStatus,PaymentMode,PaymentId,PaymentStatus,OrderOn,LastUpdatedOn,OrderedIp,PromoType,PromoValue,SubTotalWithoutTax) values (@BalAmount, @AdvAmount, @Status,@CODAmount,@OrderGuid,@OrderId, @UserGuid,@OrderMax,@ReceiptNo,@RMax,@SubTotal,@ShippingPrice,@Tax,@Discount,@TotalPrice,@PromoCode,@UserType,@OrderStatus,@PaymentMode,@PaymentId,@PaymentStatus,@OrderOn,@LastUpdatedOn,@OrderedIp,@PromoType,@PromoValue,@SubTotalWithoutTax)", conMN);
            cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
            cmdOrder.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = order.UserGuid;
            cmdOrder.Parameters.AddWithValue("@CODAmount", SqlDbType.NVarChar).Value = order.CODAmount;
            cmdOrder.Parameters.AddWithValue("@OrderId", SqlDbType.NVarChar).Value = order.OrderId;
            cmdOrder.Parameters.AddWithValue("@OrderMax", SqlDbType.NVarChar).Value = order.OrderMax;
            cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
            cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
            cmdOrder.Parameters.AddWithValue("@PromoType", SqlDbType.NVarChar).Value = order.PromoType;
            cmdOrder.Parameters.AddWithValue("@PromoValue", SqlDbType.NVarChar).Value = order.PromoValue;
            cmdOrder.Parameters.AddWithValue("@SubTotal", SqlDbType.NVarChar).Value = order.SubTotal;
            cmdOrder.Parameters.AddWithValue("@SubTotalWithoutTax", SqlDbType.NVarChar).Value = order.SubTotalWithoutTax;
            cmdOrder.Parameters.AddWithValue("@ShippingPrice", SqlDbType.NVarChar).Value = order.ShippingPrice;
            cmdOrder.Parameters.AddWithValue("@Tax", SqlDbType.NVarChar).Value = order.Tax;
            cmdOrder.Parameters.AddWithValue("@Discount", SqlDbType.NVarChar).Value = order.Discount;
            cmdOrder.Parameters.AddWithValue("@AdvAmount", SqlDbType.NVarChar).Value = order.AdvAmount;
            cmdOrder.Parameters.AddWithValue("@BalAmount", SqlDbType.NVarChar).Value = order.BalAmount;
            cmdOrder.Parameters.AddWithValue("@TotalPrice", SqlDbType.NVarChar).Value = order.TotalPrice;
            cmdOrder.Parameters.AddWithValue("@PromoCode", SqlDbType.NVarChar).Value = order.PromoCode;
            cmdOrder.Parameters.AddWithValue("@UserType", SqlDbType.NVarChar).Value = order.UserType;
            cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;
            cmdOrder.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = order.PaymentMode;
            cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
            cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
            cmdOrder.Parameters.AddWithValue("@OrderOn", SqlDbType.NVarChar).Value = order.OrderOn;
            cmdOrder.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = order.LastUpdatedOn;
            cmdOrder.Parameters.AddWithValue("@OrderedIp", SqlDbType.NVarChar).Value = order.OrderedIp;
            cmdOrder.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
            conMN.Open();
            x = cmdOrder.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreateUserOrder", ex.Message);
        }
        finally
        {
            conMN.Close();
        }
        return x;
    }

    public static int CreateUserOrder(SqlConnection conMN, POrders order)
    {
        conMN.Close();
        int x = 0;
        try
        {
            string query = "Insert into POrders (ProjectName,PriceUSD,BalAmount, AdvAmount,Status,CODAmount,OrderGuid,ProjectGuid,OrderId, UserGuid,UserName,EmailId,Contact,msgcnt,OrderMax,ReceiptNo,RMax,SubTotal,ShippingPrice,Tax,Discount,TotalPrice,PromoCode,UserType,OrderStatus,PaymentMode,PaymentId,PaymentStatus,OrderOn,LastUpdatedOn,OrderedIp,PromoType,PromoValue,SubTotalWithoutTax) values (@ProjectName,@PriceUSD,@BalAmount, @AdvAmount, @Status,@CODAmount,@OrderGuid,@ProjectGuid,@OrderId, @UserGuid,@UserName,@EmailId,@Contact,@msgcnt,@OrderMax,@ReceiptNo,@RMax,@SubTotal,@ShippingPrice,@Tax,@Discount,@TotalPrice,@PromoCode,@UserType,@OrderStatus,@PaymentMode,@PaymentId,@PaymentStatus,@OrderOn,@LastUpdatedOn,@OrderedIp,@PromoType,@PromoValue,@SubTotalWithoutTax)";
            SqlCommand cmdOrder = new SqlCommand(query, conMN);
            cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
            cmdOrder.Parameters.AddWithValue("@ProjectGuid", SqlDbType.NVarChar).Value = order.ProjectGuid;
            cmdOrder.Parameters.AddWithValue("@PriceUSD", SqlDbType.NVarChar).Value = order.PriceUSD;
            cmdOrder.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = order.UserGuid;
            cmdOrder.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = order.UserName == null ? "" : order.UserName;
            cmdOrder.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = order.EmailId;
            cmdOrder.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = order.Contact;
            cmdOrder.Parameters.AddWithValue("@msgcnt", SqlDbType.NVarChar).Value = "0";
            cmdOrder.Parameters.AddWithValue("@ProjectName", SqlDbType.NVarChar).Value = order.ProjectName;
            cmdOrder.Parameters.AddWithValue("@CODAmount", SqlDbType.NVarChar).Value = order.CODAmount;
            cmdOrder.Parameters.AddWithValue("@OrderId", SqlDbType.NVarChar).Value = order.OrderId;
            cmdOrder.Parameters.AddWithValue("@OrderMax", SqlDbType.NVarChar).Value = order.OrderMax;
            cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
            cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
            cmdOrder.Parameters.AddWithValue("@PromoType", SqlDbType.NVarChar).Value = order.PromoType;
            cmdOrder.Parameters.AddWithValue("@PromoValue", SqlDbType.NVarChar).Value = order.PromoValue;
            cmdOrder.Parameters.AddWithValue("@SubTotal", SqlDbType.NVarChar).Value = order.SubTotal;
            cmdOrder.Parameters.AddWithValue("@SubTotalWithoutTax", SqlDbType.NVarChar).Value = order.SubTotalWithoutTax;
            cmdOrder.Parameters.AddWithValue("@ShippingPrice", SqlDbType.NVarChar).Value = order.ShippingPrice;
            cmdOrder.Parameters.AddWithValue("@Tax", SqlDbType.NVarChar).Value = order.Tax;
            cmdOrder.Parameters.AddWithValue("@Discount", SqlDbType.NVarChar).Value = order.Discount;
            cmdOrder.Parameters.AddWithValue("@AdvAmount", SqlDbType.NVarChar).Value = order.AdvAmount;
            cmdOrder.Parameters.AddWithValue("@BalAmount", SqlDbType.NVarChar).Value = order.BalAmount;
            cmdOrder.Parameters.AddWithValue("@TotalPrice", SqlDbType.NVarChar).Value = order.TotalPrice;
            cmdOrder.Parameters.AddWithValue("@PromoCode", SqlDbType.NVarChar).Value = order.PromoCode;
            cmdOrder.Parameters.AddWithValue("@UserType", SqlDbType.NVarChar).Value = order.UserType;
            cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;
            cmdOrder.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = order.PaymentMode;
            cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
            cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
            cmdOrder.Parameters.AddWithValue("@OrderOn", SqlDbType.NVarChar).Value = order.OrderOn;
            cmdOrder.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = order.LastUpdatedOn;
            cmdOrder.Parameters.AddWithValue("@OrderedIp", SqlDbType.NVarChar).Value = order.OrderedIp;
            //cmdOrder.Parameters.AddWithValue("@GiftPack", SqlDbType.NVarChar).Value = "";
            cmdOrder.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
            conMN.Open();
            x = cmdOrder.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreateUserOrder", ex.Message);
        }
        return x;
    }
    /*   public static int CreateUserOrder(SqlConnection conMN, POrders order)
       {
           int x = 0;
           try
           {
               SqlCommand cmdOrder = new SqlCommand("Insert into POrders (BalAmount, AdvAmount,Status,CODAmount,OrderGuid,OrderId, UserGuid,OrderMax,ReceiptNo,RMax,SubTotal,ShippingPrice,Tax,Discount,TotalPrice,PromoCode,UserType,OrderStatus,PaymentMode,PaymentId,PaymentStatus,OrderOn,LastUpdatedOn,OrderedIp,PromoType,PromoValue,SubTotalWithoutTax) values (@BalAmount, @AdvAmount, @Status,@CODAmount,@OrderGuid,@OrderId, @UserGuid,@OrderMax,@ReceiptNo,@RMax,@SubTotal,@ShippingPrice,@Tax,@Discount,@TotalPrice,@PromoCode,@UserType,@OrderStatus,@PaymentMode,@PaymentId,@PaymentStatus,@OrderOn,@LastUpdatedOn,@OrderedIp,@PromoType,@PromoValue,@SubTotalWithoutTax)", conMN);
               cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
               cmdOrder.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = order.UserGuid;
               cmdOrder.Parameters.AddWithValue("@CODAmount", SqlDbType.NVarChar).Value = order.CODAmount;
               cmdOrder.Parameters.AddWithValue("@OrderId", SqlDbType.NVarChar).Value = order.OrderId;
               cmdOrder.Parameters.AddWithValue("@OrderMax", SqlDbType.NVarChar).Value = order.OrderMax;
               cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
               cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
               cmdOrder.Parameters.AddWithValue("@PromoType", SqlDbType.NVarChar).Value = order.PromoType;
               cmdOrder.Parameters.AddWithValue("@PromoValue", SqlDbType.NVarChar).Value = order.PromoValue;
               cmdOrder.Parameters.AddWithValue("@SubTotal", SqlDbType.NVarChar).Value = order.SubTotal;
               cmdOrder.Parameters.AddWithValue("@SubTotalWithoutTax", SqlDbType.NVarChar).Value = order.SubTotalWithoutTax;
               cmdOrder.Parameters.AddWithValue("@ShippingPrice", SqlDbType.NVarChar).Value = order.ShippingPrice;
               cmdOrder.Parameters.AddWithValue("@Tax", SqlDbType.NVarChar).Value = order.Tax;
               cmdOrder.Parameters.AddWithValue("@Discount", SqlDbType.NVarChar).Value = order.Discount;
               cmdOrder.Parameters.AddWithValue("@AdvAmount", SqlDbType.NVarChar).Value = order.AdvAmount;
               cmdOrder.Parameters.AddWithValue("@BalAmount", SqlDbType.NVarChar).Value = order.BalAmount;
               cmdOrder.Parameters.AddWithValue("@TotalPrice", SqlDbType.NVarChar).Value = order.TotalPrice;
               cmdOrder.Parameters.AddWithValue("@PromoCode", SqlDbType.NVarChar).Value = order.PromoCode;
               cmdOrder.Parameters.AddWithValue("@UserType", SqlDbType.NVarChar).Value = order.UserType;
               cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;
               cmdOrder.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = order.PaymentMode;
               cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
               cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
               cmdOrder.Parameters.AddWithValue("@OrderOn", SqlDbType.NVarChar).Value = order.OrderOn;
               cmdOrder.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = order.LastUpdatedOn;
               cmdOrder.Parameters.AddWithValue("@OrderedIp", SqlDbType.NVarChar).Value = order.OrderedIp;
               //cmdOrder.Parameters.AddWithValue("@GiftPack", SqlDbType.NVarChar).Value = "";
               cmdOrder.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
               conMN.Open();
               x = cmdOrder.ExecuteNonQuery();
               conMN.Close();
           }
           catch (Exception ex)
           {
               ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreateUserOrder", ex.Message);
           }
           finally
           {
               conMN.Close();
           }
           return x;
       }
   */
    public static string GetOrderId(SqlConnection conMN, string id)
    {
        string x = "";
        try
        {
            string query = "Select OrderId from POrders where OrderGuid=@id";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                x = dt.Rows[0]["OrderId"].ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderId", ex.Message);
        }
        return x;
    }

    public static string GetMxOrderIdByPGuid(SqlConnection conMN, string ProjectGuid)
    {
        string x = "";
        try
        {
            string query = "select COUNT(*) as ProjectCount from Porders where ProjectGuid=@ProjectGuid and PaymentStatus='Paid' and Status !='Deleted'";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@ProjectGuid", SqlDbType.NVarChar).Value = ProjectGuid;
            conMN.Open();
            object result = cmd.ExecuteScalar();
            conMN.Close();
            if (result != null)
            {
                x = result.ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMxOrderIdByPGuid", ex.Message);
        }
        return x;
    }




    public static string GetOguidWithUguid(SqlConnection conMN, string UGuid)
    {
        string x = "";
        try
        {
            string query = "Select OrderGuid from POrders where UserGuid=@UserGuid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = UGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                x = dt.Rows[0]["OrderGuid"].ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOguidWithUguid", ex.Message);
        }
        return x;
    }

    /* public static string GetOguidWithUguid(SqlConnection conMN, string UGuid)
     {
         string x = "";
         try
         {
             string query = "Select OrderGuid from POrders where UserGuid=@UGuid";
             SqlCommand cmd = new SqlCommand(query, conMN);
             cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = UGuid;
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                 x = dt.Rows[0]["OrderGuid"].ToString();
             }
         }
         catch (Exception ex)
         {
             ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOguidWithUguid", ex.Message);
         }
         return x;
     }*/
    public static int UpdateUserOrder(SqlConnection conMN, POrders order)
    {
        //conMN.Open();
        int x = 0;
        try
        {
            SqlCommand cmdOrder = new SqlCommand("Update POrders Set UserName=@UserName,PaymentMode=@PaymentMode,EmailId=@EmailId,Contact=@Contact, HostedCheckOutId=@hostedCheckoutId, PaymentStatus=@PaymentStatus,PaymentId=@PaymentId,ReceiptNo=@ReceiptNo,RMax=@RMax, OrderStatus=@OrderStatus Where OrderGuid=@OrderGuid", conMN);
            cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
            cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
            cmdOrder.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = order.UserName;
            cmdOrder.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = order.EmailId;
            cmdOrder.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = order.Contact;
            cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
            cmdOrder.Parameters.AddWithValue("@hostedCheckoutId", SqlDbType.NVarChar).Value = order.hostedCheckoutId;
            cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
            cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
            cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;
            cmdOrder.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = order.PaymentMode;
            conMN.Open();
            x = cmdOrder.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateUserOrder", ex.Message);
        }
        finally
        {
            conMN.Close();
        }
        return x;
    }
    public static int UpdateUserOrder1(SqlConnection conMN, POrders order)
    {
        //conMN.Open();
        int x = 0;
        try
        {
            SqlCommand cmdOrder = new SqlCommand("Update POrders Set HostedCheckOutId=@hostedCheckoutId, PaymentStatus=@PaymentStatus,PaymentId=@PaymentId,ReceiptNo=@ReceiptNo,RMax=@RMax, OrderStatus=@OrderStatus Where OrderGuid=@OrderGuid", conMN);
            cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
            cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
            cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
            cmdOrder.Parameters.AddWithValue("@hostedCheckoutId", SqlDbType.NVarChar).Value = order.hostedCheckoutId;
            cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
            cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
            cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;
            conMN.Open();
            x = cmdOrder.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateUserOrder", ex.Message);
        }
        finally
        {
            conMN.Close();
        }
        return x;
    }
    public static int UpdateUserOrderDetails(SqlConnection conMN, POrders order)
    {
        int x = 0;
        try
        {
            SqlCommand cmdOrder = new SqlCommand("Update POrders Set HostedCheckOutId=@hostedCheckoutId, PaymentStatus=@PaymentStatus,PaymentId=@PaymentId,ReceiptNo=@ReceiptNo" +
                                                ",RMax=@RMax,Contact=@Contact,UserName=@UserName,EmailId=@EmailId,PaymentMode=@PaymentMode,LastUpdatedIp=@LastUpdatedIp,LastUpdatedOn=@LastUpdatedOn," +
                                                "PaymentDate=@PaymentDate,ProofImg=@ProofImg,OrderStatus=@OrderStatus Where OrderGuid=@OrderGuid", conMN);

            cmdOrder.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = order.OrderGuid;
            cmdOrder.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = order.PaymentStatus;
            cmdOrder.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = order.PaymentId;
            cmdOrder.Parameters.AddWithValue("@Contact", SqlDbType.NVarChar).Value = order.Contact;
            cmdOrder.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = order.UserName;
            cmdOrder.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = order.EmailId;
            cmdOrder.Parameters.AddWithValue("@PaymentMode", SqlDbType.NVarChar).Value = order.PaymentMode;
            cmdOrder.Parameters.AddWithValue("@hostedCheckoutId", SqlDbType.NVarChar).Value = order.hostedCheckoutId;
            cmdOrder.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.NVarChar).Value = order.LastUpdatedIp;
            cmdOrder.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = order.LastUpdatedOn;
            cmdOrder.Parameters.AddWithValue("@PaymentDate", SqlDbType.NVarChar).Value = order.PaymentDate;
            cmdOrder.Parameters.AddWithValue("@ProofImg", SqlDbType.NVarChar).Value = order.ProofImg;
            cmdOrder.Parameters.AddWithValue("@ReceiptNo", SqlDbType.NVarChar).Value = order.ReceiptNo;
            cmdOrder.Parameters.AddWithValue("@RMax", SqlDbType.NVarChar).Value = order.RMax;
            cmdOrder.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = order.OrderStatus;

            conMN.Open();
            x = cmdOrder.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateUserOrder", ex.Message);
        }
        finally
        {
            conMN.Close();
        }
        return x;
    }
    public static void SendToUser(SqlConnection conMN, string oid)
    {
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName Name1, b.EmailId email1, b.Mobile Mobile1, b.Address1  Address11, b.Address2 Address21, b.City City1, b.Country Country1, b.Zip Zip1, b.State state1,b.Landmark landmark1,b.Block blblock," +
               " d.FirstName+' '+d.LastName Name2, d.Email email2,d.Mobile Mobile2,d.Address1 as Address12, d.Address2 as Address22, d.City City2, d.Country Country2, d.Zip Zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from POrders o inner join PUserBillingAddress b on b.OrderGuid = o.OrderGuid inner join PUserDeliveryAddress d on d.OrderGuid = o.OrderGuid Where o.Orderid=@Orderid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@Orderid", SqlDbType.NVarChar).Value = oid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string pType = Convert.ToString(dt.Rows[0]["PaymentMode"]);
                string pTable = ProductDetails(conMN, Convert.ToString(dt.Rows[0]["OrderGuid"]));

                string address1 = "" + Convert.ToString(dt.Rows[0]["Name1"]) + "<br>" + Convert.ToString(dt.Rows[0]["blblock"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address11"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address21"]) + "<br>" + Convert.ToString(dt.Rows[0]["City1"]) + "," + Convert.ToString(dt.Rows[0]["State1"]) + "," + Convert.ToString(dt.Rows[0]["Country1"]) + "-" + Convert.ToString(dt.Rows[0]["Zip1"]) + "<br>" + Convert.ToString(dt.Rows[0]["landmark1"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile1"]) + "<br>" + Convert.ToString(dt.Rows[0]["email1"]);
                string address2 = "" + Convert.ToString(dt.Rows[0]["Name2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Apartment"]) + "<br>" + Convert.ToString(dt.Rows[0]["dlblock"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address12"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address22"]) + "<br>" + Convert.ToString(dt.Rows[0]["City2"]) + "," + Convert.ToString(dt.Rows[0]["State2"]) + "," + Convert.ToString(dt.Rows[0]["Country2"]) + "-" + Convert.ToString(dt.Rows[0]["Zip2"]) + "<br>" + Convert.ToString(dt.Rows[0]["landmark2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile2"]) + "<br>" + Convert.ToString(dt.Rows[0]["email2"]);

                string Disc = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Discount"])))
                {
                    Disc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Discount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>- ₹" + Convert.ToString(dt.Rows[0]["Discount"]) + "</th></tr>";
                }

                string AddDisc = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Tax"])))
                {
                    AddDisc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Total Tax (included in price) </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["Tax"]) + "</th></tr>";
                }
                else
                {
                    AddDisc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Total Tax (included in price) </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹ 0</th></tr>";
                }
                string ship = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ShippingPrice"])))
                {
                    ship = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Shipping & Handling </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["ShippingPrice"]) + "</th></tr>";
                }
                string adv = "";
                if (pType == "COD")
                {
                    adv += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Advance Paid </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["AdvAmount"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["AdvAmount"]) + "</th></tr>";
                    adv += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Balance Amount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["BalAmount"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["BalAmount"]) + "</th></tr>";
                }

                string table = pTable +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Sub Total </th><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToDecimal(Convert.ToString(dt.Rows[0]["SubTotal"])).ToString() + "</th></tr>" +
                     Disc + adv +
                    AddDisc +
                    ship +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'>  Grand Total </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["TotalPrice"]) + "</th></tr>";

                //Emails.BookingConfirmed(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["Name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["TotalPrice"]), pType, address1, address2);
                //Emails.BookingConfirmedAdmin(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["Name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["TotalPrice"]), pType, address1, address2);

                //SMSServices.SendOrderSuccess(Convert.ToString(dt.Rows[0]["Mobile1"]).Replace("-", ""), Convert.ToString(dt.Rows[0]["OrderId"]));
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendToUser", ex.Message);
        }
    }
    public static string ProductDetails(SqlConnection conMN, string oGuid)
    {
        string pTable = "";
        try
        {
            string query = "Select * from OrderItems where OrderGuid= @OrderGuid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    decimal p1 = Convert.ToDecimal(Convert.ToString(dr["Price"]));
                    decimal qty = Convert.ToDecimal(Convert.ToString(dr["Qty"]));
                    decimal price = (p1 * qty);
                    pTable += @"<tr valign='middle'>
                                    <td align='left' valign='middle' style='float:left;width:60%;margin-bottom:10px;margin-top:20px;margin-bottom:25px;line-height:25px;padding:1%;' class='flexibleContainerCell'><span style='font-size:14px;'><b>" + dr["ProductName"] + @" - Qty(" + dr["Qty"] + @") </b></span><br />
                                                                      </td>
                                                                <td align='left' valign='middle' style='float:left;width:20%;margin-bottom:10px;margin-top:20px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + price + @" </td>
 </tr>";
                }
                pTable = @"<tr style='border-bottom:1px solid #573e40!important;margin-bottom:10px'>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:60%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'>ITEM NAME </th>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:40%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'> SUB TOTAL </th>
                                                            </tr>" + pTable + "";
            }
        }
        catch (Exception ex)
        {
        }
        return pTable;
    }

    public static List<POrders> BindPaymentStatus(SqlConnection conMN, string userGuid)
    {

        List<POrders> result = new List<POrders>();
        try
        {
            string cmdText = "Select O.*,P.ProjectID,P.ProjectName,P.ProjectLink,P.StartDate as PStartDate from Porders O inner join Projects P on P.ProjectGuid = O.ProjectGuid where O.USerGuid=@userguid and PaymentStatus=@PaymentStatus and O.Status !='Deleted'order by id desc";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@userguid", SqlDbType.NVarChar).Value = userGuid;
                sqlCommand.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = "Paid";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                result = (from DataRow dr in dataTable.Rows
                          select new POrders
                          {
                              ProjectID = Convert.ToString(dr["ProjectID"]),
                              ProjectName = Convert.ToString(dr["ProjectName"]),
                              ProjectLink = Convert.ToString(dr["ProjectLink"]),
                              ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              PStartDate = Convert.ToString(dr["PStartDate"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              LastUpdatedOn = Convert.ToDateTime(dr["LastUpdatedOn"]),
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPaymentStatus", ex.Message);
        }

        return result;
    }

    public static POrders GetOrderStatusDetailsByGuid(SqlConnection conMN, string UserGuid, string mGuid)
    {
        POrders Pro = new POrders();
        try
        {
            string cmdText = "select * from Porders where PaymentStatus='Paid' and UserGuid=@UserGuid and ProjectGuid=@ProjectGuid and Status !='Deleted'";
            using (SqlCommand cmd = new SqlCommand(cmdText, conMN))
            {
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.Int).Value = UserGuid;
                cmd.Parameters.AddWithValue("@ProjectGuid", SqlDbType.Int).Value = mGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Pro.Id = Convert.ToInt32(Convert.ToString(dt.Rows[0]["Id"]));
                    Pro.ProjectGuid = Convert.ToString(dt.Rows[0]["ProjectGuid"]);
                    Pro.PaymentStatus = Convert.ToString(dt.Rows[0]["PaymentStatus"]);
                    Pro.Status = Convert.ToString(dt.Rows[0]["Status"]);
                }
                else
                {
                    Pro = null;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProjectDetailsByPGuid", ex.Message);
        }
        return Pro;
    }


    public static List<POrders> GetAllOrders(SqlConnection conMN)
    {
        List<POrders> result = new List<POrders>();
        try
        {
            string query = "Select * from POrders where Status != @Deleted Order by Id Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new POrders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              UserName = Convert.ToString(dr["UserName"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              EmailId = Convert.ToString(dr["EmailId"]),
                              Contact = Convert.ToString(dr["Contact"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              PaymentDate = Convert.ToString(dr["PaymentDate"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              ProjectName = Convert.ToString(dr["ProjectName"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              msgcnt = Convert.ToString(dr["msgcnt"]),
                              OrderOn = Convert.ToDateTime(dr["OrderOn"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllOrders", ex.Message);
        }

        return result;
    }
    public static int DeleteOrders(SqlConnection conMN, POrders cat)
    {
        int result = 0;
        try
        {
            string cmdText = "Update Porders Set Status=@Status Where Id=@Id ";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, conMN))
            {
                sqlCommand.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                sqlCommand.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                conMN.Open();
                result = sqlCommand.ExecuteNonQuery();
                conMN.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteJobApp", ex.Message);
        }

        return result;
    }

    public static List<POrders> GetTop10Orders(SqlConnection conMN)
    {
        List<POrders> result = new List<POrders>();
        try
        {
            string query = "Select Top 10 * from POrders where Status != @Deleted Order by Id Desc";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Deleted", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                result = (from DataRow dr in dt.Rows
                          select new POrders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              UserName = Convert.ToString(dr["UserName"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              EmailId = Convert.ToString(dr["EmailId"]),
                              Contact = Convert.ToString(dr["Contact"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              ProjectGuid = Convert.ToString(dr["ProjectGuid"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              PaymentDate = Convert.ToString(dr["PaymentDate"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              ProjectName = Convert.ToString(dr["ProjectName"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              msgcnt = Convert.ToString(dr["msgcnt"]),
                              OrderOn = Convert.ToDateTime(dr["OrderOn"]),
                              Status = Convert.ToString(dr["Status"])
                          }).ToList();
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllOrders", ex.Message);
        }

        return result;
    }
    public static int UpdateMsgCount(SqlConnection conGV, string Guid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update POrders Set MsgCnt = Try_Convert(int, ISNULL(MsgCnt, 0)) + 1 Where OrderGuid=@OrderGuid", conGV);
            cmd1.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = Guid;
            conGV.Open();
            x = cmd1.ExecuteNonQuery();
            conGV.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BlockVenue", ex.Message);
        }
        return x;
    }

}
public class PCheckoutItems
{
    public int Id { get; set; }
    public string OrderGuid { get; set; }
    public string ProductGuid { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string TaxGroup { get; set; }
    public string PriceId { get; set; }
    public string Qty { get; set; }
    public string Price { get; set; }
    public string ActualPrice { get; set; }
    public string Size { get; set; }

    public DateTime AddedOn { get; set; }
    public string Discount { get; set; }
    public string ItemNumber { get; set; }
    public string ProductUrl { get; set; }
    public string ProductImage { get; set; }
}
public class PUserBillingAddress
{
    public int Id { get; set; }
    public string UserGuid { get; set; }
    public string Salutation { get; set; }
    public string EmailId { get; set; }
    public string OrderGuid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Block { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Mobile { get; set; }
    public string AltMobile { get; set; }
    public string CustomerGSTN { get; set; }
    public string CompanyName { get; set; }
    public string Landmark { get; set; }
    public string AddedIp { get; set; }
    public DateTime AddedDateTime { get; set; }
}

public class PUserDeliveryAddress
{
    public int Id { get; set; }
    public string UserGuid { get; set; }
    public string Salutation { get; set; }
    public string OrderGuid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Landmark { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Block { get; set; }
    public string Apartment { get; set; }
    public string Mobile { get; set; }
    public string AltMobile { get; set; }
    public DateTime AddedDateTime { get; set; }
    public string AddedIp { get; set; }
}

public class POrders
{
    public int Id { get; set; }
    public string UserGuid { get; set; }
    public string hostedCheckoutId { get; set; }
    public string OrderGuid { get; set; }
    public string ProjectGuid { get; set; }
    public string ProjectLink { get; set; }
    public string OrderId { get; set; }
    public string OrderMax { get; set; }
    public string UserName { get; set; }
    public string EmailId { get; set; }
    public string Contact { get; set; }
    public string ReceiptNo { get; set; }
    public string RMax { get; set; }
    public string SubTotal { get; set; }
    public string SubTotalWithoutTax { get; set; }
    public string ShippingPrice { get; set; }
    public string ShippingType { get; set; }
    public string Tax { get; set; }
    public string Discount { get; set; }
    public string CODAmount { get; set; }
    public string AddDiscount { get; set; }
    public string TotalPrice { get; set; }
    public string PriceUSD { get; set; }
    public string PromoCode { get; set; }
    public string UserType { get; set; }
    public string OrderStatus { get; set; }
    public string PaymentMode { get; set; }
    public string PaymentId { get; set; }
    public string PaymentStatus { get; set; }
    public string Status { get; set; }
    public DateTime OrderOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string OrderedIp { get; set; }
    public string LastUpdatedIp { get; set; }
    public string PromoType { get; set; }
    public string PromoValue { get; set; }
    public string BillingAddress { get; set; }
    public string DeliveryAddress { get; set; }
    public string OState { get; set; }
    public string AdvAmount { get; set; }
    public string BalAmount { get; set; }
    public string msgcnt { get; set; }

    //Extras
    public string PaymentDate { get; set; }
    public string ProofImg { get; set; }
    public string CompanyName { get; set; }
    public string ProjectID { get; set; }
    public string ProjectName { get; set; }
    public string POrderDetails { get; set; }
    public string PStartDate { get; set; }



    public PUserBillingAddress BillAdd { get; set; }
    public PUserDeliveryAddress DelivAdd { get; set; }
}
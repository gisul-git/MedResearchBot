using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

/// <summary>
/// Summary description for Reports
/// </summary>

public class Reports
{
    public static List<Orders> GetaAllOrders(SqlConnection conMN)
    {
        List<Orders> orders = new List<Orders>();
        try
        {
            string query = "Select o.*,c.CompanyName ," +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile mobile1, b.Address1 address11, b.Address2 address12, b.City city1, b.Country country1, b.Zip zip1, b.State state1,b.Landmark landmark1,b.Block blblock," +
               " d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile mobile2,d.Address1 address21, d.Address2 address22, d.City city2, d.Country country2, d.Zip zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid inner join Customers c on o.UserGuid=c.UserGuid Where (o.Status != 'Deleted' or o.Status is null) order by o.id desc";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new Orders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              OrderOn = Convert.ToDateTime(Convert.ToString(dr["OrderOn"])),
                              LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]) == "" ? Convert.ToDateTime(Convert.ToString(dr["OrderOn"])) : Convert.ToDateTime(Convert.ToString(dr["LastUpdatedOn"])),
                              OrderedIp = Convert.ToString(dr["OrderedIp"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              OrderMax = Convert.ToString(dr["OrderMax"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              PaymentMode = Convert.ToString(dr["PaymentMode"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              PromoCode = Convert.ToString(dr["PromoCode"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              RMax = Convert.ToString(dr["RMax"]),
                              ShippingPrice = Convert.ToString(dr["ShippingPrice"]),
                              ShippingType = Convert.ToString(dr["ShippingType"]),
                              SubTotal = Convert.ToString(dr["SubTotal"]),
                              SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                              Tax = Convert.ToString(dr["Tax"]),
                              Discount = Convert.ToString(dr["Discount"]),
                              AddDiscount = Convert.ToString(dr["AddDiscount"]),
                              CompanyName = Convert.ToString(dr["CompanyName"]),

                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              AdvAmount = Convert.ToString(dr["AdvAmount"]),
                              BalAmount = Convert.ToString(dr["BalAmount"]),

                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              UserType = Convert.ToString(dr["UserType"]),
                              UserName = Convert.ToString(dr["name1"]),
                              EmailId = Convert.ToString(dr["email1"]),
                              Contact = Convert.ToString(dr["Mobile1"]),
                              BillingAddress = Convert.ToString(dr["name1"]) + "| " + Convert.ToString(dr["email1"]) + "| " + Convert.ToString(dr["mobile1"]) + "| " + Convert.ToString(dr["blblock"]) + "| " + Convert.ToString(dr["address11"]) + "| " + Convert.ToString(dr["address12"]) + "| " + Convert.ToString(dr["city1"]) + "| " + Convert.ToString(dr["state1"]) + "-" + Convert.ToString(dr["zip1"]),
                              DeliveryAddress = Convert.ToString(dr["name2"]) + "| " + Convert.ToString(dr["email2"]) + "| " + Convert.ToString(dr["mobile2"]) + "| " + Convert.ToString(dr["Apartment"]) + "| " + Convert.ToString(dr["dlblock"]) + "| " + Convert.ToString(dr["address21"]) + "| " + Convert.ToString(dr["address22"]) + "| " + Convert.ToString(dr["city2"]) + "| " + Convert.ToString(dr["state2"]) + "-" + Convert.ToString(dr["zip2"]),
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetaAllOrders", ex.Message);
        }
        return orders;
    }

    public static List<Orders> GetaAllOrders(SqlConnection conMN, string AgentGuid)
    {
        List<Orders> orders = new List<Orders>();
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile mobile1, b.Address1 address11, b.Address2 address12, b.City city1, b.Country country1, b.Zip zip1, b.State state1,b.Landmark landmark1,b.Block blblock," +
               " d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile mobile2,d.Address1 address21, d.Address2 address22, d.City city2, d.Country country2, d.Zip zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid inner join Customers c on c.UserGuid=o.UserGuid Where (o.Status != 'Deleted' or o.Status is null) and c.Agent=@Agent order by o.id desc";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@Agent", SqlDbType.NVarChar).Value = AgentGuid;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new Orders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              OrderOn = Convert.ToDateTime(Convert.ToString(dr["OrderOn"])),
                              LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]) == "" ? Convert.ToDateTime(Convert.ToString(dr["OrderOn"])) : Convert.ToDateTime(Convert.ToString(dr["LastUpdatedOn"])),
                              OrderedIp = Convert.ToString(dr["OrderedIp"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              OrderMax = Convert.ToString(dr["OrderMax"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              PaymentMode = Convert.ToString(dr["PaymentMode"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              PromoCode = Convert.ToString(dr["PromoCode"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              RMax = Convert.ToString(dr["RMax"]),
                              ShippingPrice = Convert.ToString(dr["ShippingPrice"]),
                              ShippingType = Convert.ToString(dr["ShippingType"]),
                              SubTotal = Convert.ToString(dr["SubTotal"]),
                              SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                              Tax = Convert.ToString(dr["Tax"]),
                              Discount = Convert.ToString(dr["Discount"]),
                              AddDiscount = Convert.ToString(dr["AddDiscount"]),

                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              AdvAmount = Convert.ToString(dr["AdvAmount"]),
                              BalAmount = Convert.ToString(dr["BalAmount"]),

                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              UserType = Convert.ToString(dr["UserType"]),
                              UserName = Convert.ToString(dr["name1"]),
                              EmailId = Convert.ToString(dr["email1"]),
                              Contact = Convert.ToString(dr["Mobile1"]),
                              BillingAddress = Convert.ToString(dr["name1"]) + "| " + Convert.ToString(dr["email1"]) + "| " + Convert.ToString(dr["mobile1"]) + "| " + Convert.ToString(dr["blblock"]) + "| " + Convert.ToString(dr["address11"]) + "| " + Convert.ToString(dr["address12"]) + "| " + Convert.ToString(dr["city1"]) + "| " + Convert.ToString(dr["state1"]) + "-" + Convert.ToString(dr["zip1"]),
                              DeliveryAddress = Convert.ToString(dr["name2"]) + "| " + Convert.ToString(dr["email2"]) + "| " + Convert.ToString(dr["mobile2"]) + "| " + Convert.ToString(dr["Apartment"]) + "| " + Convert.ToString(dr["dlblock"]) + "| " + Convert.ToString(dr["address21"]) + "| " + Convert.ToString(dr["address22"]) + "| " + Convert.ToString(dr["city2"]) + "| " + Convert.ToString(dr["state2"]) + "-" + Convert.ToString(dr["zip2"]),
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetaAllOrders", ex.Message);
        }
        return orders;
    }

    public static List<Orders> GetaAllUserOrders(SqlConnection conMN, string UserGuid)
    {
        List<Orders> orders = new List<Orders>();
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile mobile1, b.Address1 address11, b.Address2 address12, b.City city1, b.Country country1, b.Zip zip1, b.State state1,b.Landmark landmark1,b.Block blblock,b.CustomerGSTN,b.CompanyName," +
               " d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile mobile2,d.Address1 address21, d.Address2 address22, d.City city2, d.Country country2, d.Zip zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid Where (o.Status != 'Deleted' or o.Status is null) and o.OrderStatus !='Initiated' and o.UserGuid=@UserGuid order by o.id desc";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = UserGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new Orders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              OrderOn = Convert.ToDateTime(Convert.ToString(dr["OrderOn"])),
                              LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]) == "" ? Convert.ToDateTime(Convert.ToString(dr["OrderOn"])) : Convert.ToDateTime(Convert.ToString(dr["LastUpdatedOn"])),
                              OrderedIp = Convert.ToString(dr["OrderedIp"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              OrderMax = Convert.ToString(dr["OrderMax"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              PaymentMode = Convert.ToString(dr["PaymentMode"]),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              PromoCode = Convert.ToString(dr["PromoCode"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              RMax = Convert.ToString(dr["RMax"]),
                              ShippingPrice = Convert.ToString(dr["ShippingPrice"]),
                              ShippingType = Convert.ToString(dr["ShippingType"]),
                              SubTotal = Convert.ToString(dr["SubTotal"]),
                              SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                              Tax = Convert.ToString(dr["Tax"]),
                              Discount = Convert.ToString(dr["Discount"]),
                              AddDiscount = Convert.ToString(dr["AddDiscount"]),

                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              UserType = Convert.ToString(dr["UserType"]),
                              UserName = Convert.ToString(dr["name1"]),
                              EmailId = Convert.ToString(dr["email1"]),
                              Contact = Convert.ToString(dr["Mobile1"]),
                              BillAdd = new UserBillingAddress()
                              {
                                  FirstName = Convert.ToString(dr["name1"]),
                                  EmailId = Convert.ToString(dr["email1"]),
                                  Mobile = Convert.ToString(dr["mobile1"]),
                                  Address1 = Convert.ToString(dr["address11"]),
                                  City = Convert.ToString(dr["city1"]),
                                  State = Convert.ToString(dr["state1"]),
                                  Zip = Convert.ToString(dr["zip1"]),
                                  CustomerGSTN = Convert.ToString(dr["CustomerGSTN"]),
                                  CompanyName = Convert.ToString(dr["CompanyName"]),
                                  Country = Convert.ToString(dr["country1"]),
                              },
                              BillingAddress = Convert.ToString(dr["name1"]) + "| " + Convert.ToString(dr["email1"]) + "| " + Convert.ToString(dr["mobile1"]) + "| " + Convert.ToString(dr["blblock"]) + "| " + Convert.ToString(dr["address11"]) + "| " + Convert.ToString(dr["address12"]) + "| " + Convert.ToString(dr["city1"]) + "| " + Convert.ToString(dr["state1"]) + "-" + Convert.ToString(dr["zip1"]),
                              DeliveryAddress = Convert.ToString(dr["name2"]) + "| " + Convert.ToString(dr["email2"]) + "| " + Convert.ToString(dr["mobile2"]) + "| " + Convert.ToString(dr["Apartment"]) + "| " + Convert.ToString(dr["dlblock"]) + "| " + Convert.ToString(dr["address21"]) + "| " + Convert.ToString(dr["address22"]) + "| " + Convert.ToString(dr["city2"]) + "| " + Convert.ToString(dr["state2"]) + "-" + Convert.ToString(dr["zip2"]),
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetaAllOrders", ex.Message);
        }
        return orders;
    }
    public static List<Orders> GetSingleOrderDetails(SqlConnection conMN, string oGuid)
    {
        List<Orders> orders = new List<Orders>();
        UserBillingAddress billingAdd = new UserBillingAddress();
        UserDeliveryAddress deliveryAdd = new UserDeliveryAddress();
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile mobile1, b.Address1 address11, b.Address2 address12, b.City city1, b.Country country1, b.Zip zip1, b.State state1,b.Landmark landmark1,b.Block blblock,b.CustomerGSTN,b.CompanyName," +
               "d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile mobile2,d.Address1 address21, d.Address2 address22, d.City city2, d.Country country2, d.Zip zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid Where (o.Status != 'Deleted' or o.Status is null) and o.OrderGuid=@OrderGuid order by o.id desc";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new Orders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              OrderOn = Convert.ToDateTime(Convert.ToString(dr["OrderOn"])),
                              LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]) == "" ? Convert.ToDateTime(Convert.ToString(dr["OrderOn"])) : Convert.ToDateTime(Convert.ToString(dr["LastUpdatedOn"])),
                              OrderedIp = Convert.ToString(dr["OrderedIp"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              OrderMax = Convert.ToString(dr["OrderMax"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              OState = Convert.ToString(dr["state1"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              PaymentMode = Convert.ToString(dr["PaymentMode"]),
                              PaymentDate = Convert.ToString(dr["PaymentDate"]) == "" ? "Not Applicable" : Convert.ToString(Convert.ToDateTime(dr["PaymentDate"])),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              PromoCode = Convert.ToString(dr["PromoCode"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              RMax = Convert.ToString(dr["RMax"]),
                              ShippingPrice = Convert.ToString(dr["ShippingPrice"]),
                              ShippingType = Convert.ToString(dr["ShippingType"]),
                              SubTotal = Convert.ToString(dr["SubTotal"]),
                              SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                              Tax = Convert.ToString(dr["Tax"]),
                              Discount = Convert.ToString(dr["Discount"]),
                              AddDiscount = Convert.ToString(dr["AddDiscount"]),
                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              UserType = Convert.ToString(dr["UserType"]),
                              UserName = Convert.ToString(dr["name1"]),
                              EmailId = Convert.ToString(dr["email1"]),
                              Contact = Convert.ToString(dr["Mobile1"]),
                              CODAmount = Convert.ToString(dr["CODAmount"]),
                              AdvAmount = Convert.ToString(dr["AdvAmount"]),
                              BalAmount = Convert.ToString(dr["BalAmount"]),
                              ProofImg = Convert.ToString(dr["ProofImg"]),
                              BillAdd = new UserBillingAddress()
                              {
                                  FirstName = Convert.ToString(dr["name1"]),
                                  EmailId = Convert.ToString(dr["email1"]),
                                  Mobile = Convert.ToString(dr["mobile1"]),
                                  Address1 = Convert.ToString(dr["address11"]),
                                  City = Convert.ToString(dr["city1"]),
                                  State = Convert.ToString(dr["state1"]),
                                  Zip = Convert.ToString(dr["zip1"]),
                                  CustomerGSTN = Convert.ToString(dr["CustomerGSTN"]),
                                  CompanyName = Convert.ToString(dr["CompanyName"]),
                                  Country = Convert.ToString(dr["country1"]),
                              }
                              ,
                              BillingAddress = Convert.ToString(dr["name1"]) + "| " + Convert.ToString(dr["email1"]) + "| " + Convert.ToString(dr["mobile1"]) + "| " + Convert.ToString(dr["blblock"]) + "| " + Convert.ToString(dr["address11"]) + "| " + Convert.ToString(dr["address12"]) + "| " + Convert.ToString(dr["city1"]) + "| " + Convert.ToString(dr["state1"]) + "-" + Convert.ToString(dr["zip1"]),

                              DeliveryAddress = Convert.ToString(dr["name2"]) + "| " + Convert.ToString(dr["email2"]) + "| " + Convert.ToString(dr["mobile2"]) + "| " + Convert.ToString(dr["Apartment"]) + "| " + Convert.ToString(dr["dlblock"]) + "| " + Convert.ToString(dr["address21"]) + "| " + Convert.ToString(dr["address22"]) + "| " + Convert.ToString(dr["city2"]) + "| " + Convert.ToString(dr["state2"]) + "-" + Convert.ToString(dr["zip2"]),
                          }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetaAllOrders", ex.Message);
        }
        return orders;
    }

    public static Orders GetSingleOrderDetailsWOid(SqlConnection conMN, string oid)
    {
        var orders = new Orders();
        UserBillingAddress billingAdd = new UserBillingAddress();
        UserDeliveryAddress deliveryAdd = new UserDeliveryAddress();
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile mobile1, b.Address1 address11, b.Address2 address12, b.City city1, b.Country country1, b.Zip zip1, b.State state1,b.Landmark landmark1,b.Block blblock,b.CustomerGSTN,b.CompanyName," +
               "d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile mobile2,d.Address1 address21, d.Address2 address22, d.City city2, d.Country country2, d.Zip zip2,d.State state2,d.Landmark landmark2,d.Block dlblock,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid Where (o.Status != 'Deleted' or o.Status is null) and o.OrderId=@OrderId order by o.id desc";

            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderId", SqlDbType.NVarChar).Value = oid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new Orders()
                          {
                              Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                              OrderOn = Convert.ToDateTime(Convert.ToString(dr["OrderOn"])),
                              LastUpdatedOn = Convert.ToString(dr["LastUpdatedOn"]) == "" ? Convert.ToDateTime(Convert.ToString(dr["OrderOn"])) : Convert.ToDateTime(Convert.ToString(dr["LastUpdatedOn"])),
                              OrderedIp = Convert.ToString(dr["OrderedIp"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              OrderId = Convert.ToString(dr["OrderId"]),
                              OrderMax = Convert.ToString(dr["OrderMax"]),
                              OrderStatus = Convert.ToString(dr["OrderStatus"]),
                              OState = Convert.ToString(dr["state1"]),
                              PaymentId = Convert.ToString(dr["PaymentId"]),
                              PaymentMode = Convert.ToString(dr["PaymentMode"]),
                              PaymentDate = Convert.ToString(dr["PaymentDate"]) == "" ? "Not Applicable" : Convert.ToString(Convert.ToDateTime(dr["PaymentDate"])),
                              PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                              PromoCode = Convert.ToString(dr["PromoCode"]),
                              ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                              RMax = Convert.ToString(dr["RMax"]),
                              ShippingPrice = Convert.ToString(dr["ShippingPrice"]),
                              ShippingType = Convert.ToString(dr["ShippingType"]),
                              SubTotal = Convert.ToString(dr["SubTotal"]),
                              SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                              Tax = Convert.ToString(dr["Tax"]),
                              Discount = Convert.ToString(dr["Discount"]),
                              AddDiscount = Convert.ToString(dr["AddDiscount"]),
                              TotalPrice = Convert.ToString(dr["TotalPrice"]),
                              UserGuid = Convert.ToString(dr["UserGuid"]),
                              UserType = Convert.ToString(dr["UserType"]),
                              UserName = Convert.ToString(dr["name1"]),
                              EmailId = Convert.ToString(dr["email1"]),
                              Contact = Convert.ToString(dr["Mobile1"]),
                              CODAmount = Convert.ToString(dr["CODAmount"]),
                              AdvAmount = Convert.ToString(dr["AdvAmount"]),
                              BalAmount = Convert.ToString(dr["BalAmount"]),
                              ProofImg = Convert.ToString(dr["ProofImg"]),
                              BillAdd = new UserBillingAddress()
                              {
                                  FirstName = Convert.ToString(dr["name1"]),
                                  EmailId = Convert.ToString(dr["email1"]),
                                  Mobile = Convert.ToString(dr["mobile1"]),
                                  Address1 = Convert.ToString(dr["address11"]),
                                  City = Convert.ToString(dr["city1"]),
                                  State = Convert.ToString(dr["state1"]),
                                  Zip = Convert.ToString(dr["zip1"]),
                                  CustomerGSTN = Convert.ToString(dr["CustomerGSTN"]),
                                  CompanyName = Convert.ToString(dr["CompanyName"]),
                                  Country = Convert.ToString(dr["country1"]),
                              }
                              ,
                              BillingAddress = Convert.ToString(dr["name1"]) + "| " + Convert.ToString(dr["email1"]) + "| " + Convert.ToString(dr["mobile1"]) + "| " + Convert.ToString(dr["blblock"]) + "| " + Convert.ToString(dr["address11"]) + "| " + Convert.ToString(dr["address12"]) + "| " + Convert.ToString(dr["city1"]) + "| " + Convert.ToString(dr["state1"]) + "-" + Convert.ToString(dr["zip1"]),

                              DeliveryAddress = Convert.ToString(dr["name2"]) + "| " + Convert.ToString(dr["email2"]) + "| " + Convert.ToString(dr["mobile2"]) + "| " + Convert.ToString(dr["Apartment"]) + "| " + Convert.ToString(dr["dlblock"]) + "| " + Convert.ToString(dr["address21"]) + "| " + Convert.ToString(dr["address22"]) + "| " + Convert.ToString(dr["city2"]) + "| " + Convert.ToString(dr["state2"]) + "-" + Convert.ToString(dr["zip2"]),
                          }).FirstOrDefault();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetaAllOrders", ex.Message);
        }
        return orders;
    }

    public static List<OrderItems> GetOrderItems(SqlConnection conMN, string oGuid)
    {
        List<OrderItems> orders = new List<OrderItems>();
        try
        {
            string query = "select *,(Select Top 1 ModelNo from Productdetails where Productdetails.ProductGuid=OrderItems.ProductGuid) as ModelNo from OrderItems where OrderGuid=@OrderGuid";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new OrderItems()
                          {
                              Id = Convert.ToString(dr["Id"]),
                              ProductId = Convert.ToString(dr["ProductId"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              ProductName = Convert.ToString(dr["ProductName"]),
                              ProductGuid = Convert.ToString(dr["ProductGuid"]),
                              ModelNo = Convert.ToString(dr["ModelNo"]),
                              Quantity = Convert.ToString(dr["Qty"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              ProductImage = Convert.ToString(dr["ProductImage"]),
                              Size = Convert.ToString(dr["Size"]),
                              TaxPercent = Convert.ToString(dr["TaxGroup"]),
                              Price = Convert.ToString(dr["Price"]),
                              ActualPrice = Convert.ToString(dr["ActualPrice"]),
                              ProductUrl = Convert.ToString(dr["ProductUrl"])
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderItems", ex.Message);
        }
        return orders;
    }

    public static List<OrderItems> GetOrderItemsDetails(SqlConnection conMN, string oGuid)
    {
        List<OrderItems> orders = new List<OrderItems>();
        try
        {
            string query = "select *,(select categoryUrl from Category where Id=OrderItems.ProductId)as CategoryUrl from OrderItems where OrderGuid=@OrderGuid";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                orders = (from DataRow dr in dt.Rows
                          select new OrderItems()
                          {
                              Id = Convert.ToString(dr["Id"]),
                              ProductId = Convert.ToString(dr["ProductId"]),
                              AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                              ProductName = Convert.ToString(dr["ProductName"]),
                              ProductGuid = Convert.ToString(dr["ProductGuid"]),
                              Quantity = Convert.ToString(dr["Qty"]),
                              OrderGuid = Convert.ToString(dr["OrderGuid"]),
                              ProductImage = Convert.ToString(dr["ProductImage"]),
                              Size = Convert.ToString(dr["Size"]),
                              TaxPercent = Convert.ToString(dr["TaxGroup"]),
                              Price = Convert.ToString(dr["Price"]),
                              ActualPrice = Convert.ToString(dr["ActualPrice"]),
                              ProductUrl = Convert.ToString(dr["ProductUrl"]),
                              CategoryUrl = Convert.ToString(dr["CategoryUrl"])
                          }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderItems", ex.Message);
        }
        return orders;
    }

    public static int DispatchOrder(SqlConnection conMN, string oGuid, string cName, string trkCode, string cLink)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update Orders Set OrderStatus=@OrderStatus,LastUpdatedOn=@LastUpdatedOn,CourierName=@CourierName,TrackingCode=@TrackingCode,TrackingLink=@TrackingLink,LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id and OrderStatus='In-Process'", conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = "Dispatched";
            cmd.Parameters.AddWithValue("@CourierName", SqlDbType.NVarChar).Value = cName;
            cmd.Parameters.AddWithValue("@TrackingCode", SqlDbType.NVarChar).Value = trkCode;
            cmd.Parameters.AddWithValue("@TrackingLink", SqlDbType.NVarChar).Value = cLink;
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = CommonModel.IPAddress();
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DispatchOrder", ex.Message);
        }
        return x;
    }
    public static int CompletedOrder(SqlConnection conMN, string oGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update Orders Set OrderStatus=@OrderStatus,PaymentStatus=@PaymentStatus,LastUpdatedOn=@LastUpdatedOn,LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id", conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = "Completed";
            cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = "Paid";
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = CommonModel.IPAddress();
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeliveredOrder", ex.Message);
        }
        return x;
    }
    public static int CancelOrder(SqlConnection conMN, string oGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update Orders Set OrderStatus=@OrderStatus,LastUpdatedOn=@LastUpdatedOn,LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id and OrderStatus!='Completed'", conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = "Cancelled";
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = CommonModel.IPAddress();
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CancelOrder", ex.Message);
        }
        return x;
    }
    public static int ReturnOrder(SqlConnection conMN, string oGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update Orders Set OrderStatus=@OrderStatus,LastUpdatedOn=@LastUpdatedOn,LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id and OrderStatus='Delivered'", conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@OrderStatus", SqlDbType.NVarChar).Value = "Returned";
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = CommonModel.IPAddress();
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ReturnOrder", ex.Message);
        }
        return x;
    }
    public static int DeleteOrder(SqlConnection conMN, string oGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update Orders Set Status=@Status,LastUpdatedOn=@LastUpdatedOn,LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id", conMN);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = CommonModel.IPAddress();
            conMN.Open();
            x = cmd.ExecuteNonQuery();
            conMN.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteOrder", ex.Message);
        }
        return x;
    }
    public static void SendToUserMail(SqlConnection conMN, string oGuid, string type, string delprname, string delprnumber, string link)
    {
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile Mobile1, b.Address1  Address11, b.Address2 Address21, b.City City1, b.Country Country1, b.Zip Zip1, b.State state1,b.Landmark landmark1," +
               " d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile Mobile2,d.Address1 as Address12, d.Address2 as Address22, d.City City2, d.Country Country2, d.Zip as Zip2,d.State state2,d.Landmark landmark2,d.Block,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid where o.OrderGuid=@OrderGuid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string pType = Convert.ToString(dt.Rows[0]["PaymentMode"]);
                string pTable = UserCheckout.ProductDetails(conMN, oGuid);
                string address1 = "" + Convert.ToString(dt.Rows[0]["name1"]) + "<br>" + Convert.ToString(dt.Rows[0]["Apartment"]) + "<br>" + Convert.ToString(dt.Rows[0]["Block"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address11"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address21"]) + "<br>" + Convert.ToString(dt.Rows[0]["landmark2"]) + "<br>" + Convert.ToString(dt.Rows[0]["City1"]) + "," + Convert.ToString(dt.Rows[0]["state1"]) + "-" + Convert.ToString(dt.Rows[0]["Zip1"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile1"]) + "<br>" + Convert.ToString(dt.Rows[0]["email1"]);
                string address2 = "" + Convert.ToString(dt.Rows[0]["name2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address12"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address22"]) + "<br>" + Convert.ToString(dt.Rows[0]["City2"]) + "," + Convert.ToString(dt.Rows[0]["Country2"]) + "-" + Convert.ToString(dt.Rows[0]["Zip2"]) + "<br>" + Convert.ToString(dt.Rows[0]["state2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile2"]) + "<br>" + Convert.ToString(dt.Rows[0]["email2"]);
                string table = pTable + "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Sub Total </th><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["SubTotal"]) + "</th></tr>" +
                     "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Tax </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["Tax"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                     "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Shipping </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["ShippingPrice"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Discount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["Discount"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'>  Grand Total </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["TotalPrice"]) + "</th></tr>";
                if (type.ToLower() == "dispatch")
                {
                    //Emails.OrderDispatched(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["Mobile1"]), Convert.ToString(dt.Rows[0]["TotalPrice"]), pType, delprname, delprnumber, link, address2);
                }
                else if (type.ToLower() == "deliver")
                {
                    // Emails.OrderDelivered(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["Mobile1"]), pType, address2, Convert.ToString(dt.Rows[0]["TotalPrice"]));
                }
                else if (type.ToLower() == "cancel")
                {
                    //Emails.CancellationMail(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["Mobile1"]), pType, address2, Convert.ToString(dt.Rows[0]["OrderOn"]));
                }
                else if (type.ToLower() == "return")
                {
                    //Emails.ReturnMail(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["Mobile1"]), pType, address2, Convert.ToString(dt.Rows[0]["OrderOn"]));
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendToUser", ex.Message);
        }
    }

    public static void SendToAdminMail(SqlConnection conMN, string oGuid, string type, string delprname, string delprnumber, string link)
    {
        try
        {
            string query = "Select o.*, " +
               " b.FirstName+' '+b.LastName name1, b.EmailId email1, b.Mobile Mobile1, b.Address1  Address11, b.Address2 Address21, b.City City1, b.Country Country1, b.Zip Zip1, b.State state1,b.Landmark landmark1," +
               " d.FirstName+' '+d.LastName name2, d.Email email2,d.Mobile Mobile2,d.Address1 as Address12, d.Address2 as Address22, d.City City2, d.Country Country2, d.Zip as Zip2,d.State state2,d.Landmark landmark2,d.Block,d.Apartment" +
               "  from Orders o inner join UserBillingAddress b on b.OrderGuid = o.OrderGuid inner join UserDeliveryAddress d on d.OrderGuid = o.OrderGuid where o.OrderGuid=@OrderGuid";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string pType = Convert.ToString(dt.Rows[0]["PaymentMode"]);
                string pTable = UserCheckout.ProductDetails(conMN, oGuid);
                string address1 = "" + Convert.ToString(dt.Rows[0]["name1"]) + "<br>" + Convert.ToString(dt.Rows[0]["Apartment"]) + "<br>" + Convert.ToString(dt.Rows[0]["Block"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address11"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address21"]) + "<br>" + Convert.ToString(dt.Rows[0]["landmark2"]) + "<br>" + Convert.ToString(dt.Rows[0]["City1"]) + "," + Convert.ToString(dt.Rows[0]["state1"]) + "-" + Convert.ToString(dt.Rows[0]["Zip1"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile1"]) + "<br>" + Convert.ToString(dt.Rows[0]["email1"]);
                string address2 = "" + Convert.ToString(dt.Rows[0]["name2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address12"]) + "<br>" + Convert.ToString(dt.Rows[0]["Address22"]) + "<br>" + Convert.ToString(dt.Rows[0]["City2"]) + "," + Convert.ToString(dt.Rows[0]["Country2"]) + "-" + Convert.ToString(dt.Rows[0]["Zip2"]) + "<br>" + Convert.ToString(dt.Rows[0]["state2"]) + "<br>" + Convert.ToString(dt.Rows[0]["Mobile2"]) + "<br>" + Convert.ToString(dt.Rows[0]["email2"]);
                string table = pTable + "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Sub Total </th><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["SubTotal"]) + "</th></tr>" +
                     "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Tax </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["Tax"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                     "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Shipping </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["ShippingPrice"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Discount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["Discount"]) + "</th></tr>" +
                    "<tr style='padding-bottom:15px;'><td style='border-bottom: 1px solid #573e40!important;'><br /></td></tr>" +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'>  Grand Total </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["TotalPrice"]) + "</th></tr>";
                if (type.ToLower() == "return")
                {
                    //Emails.BookingRetrurnAdmin(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["TotalPrice"]), pType, address1, address2);
                }
                else if (type.ToLower() == "cancel")
                {
                    //Emails.BookingCancelledAdmin(Convert.ToString(dt.Rows[0]["OrderId"]), table + "", Convert.ToString(dt.Rows[0]["name1"]), Convert.ToString(dt.Rows[0]["email1"]), Convert.ToString(dt.Rows[0]["TotalPrice"]), pType, address1, address2);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendToAdminMail", ex.Message);
        }
    }
    public static List<UserBillingAddress> GetBillingAddress(SqlConnection conGV, string oGuid)
    {
        List<UserBillingAddress> address = new List<UserBillingAddress>();
        try
        {
            string query = " Select * from UserBillingAddress Where OrderGuid = @OrderGuid";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                address = (from DataRow dr in dt.Rows
                           select new UserBillingAddress()
                           {
                               Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                               AddedDateTime = Convert.ToDateTime(Convert.ToString(dr["AddedDateTime"])),
                               Block = Convert.ToString(dr["Block"]),
                               Landmark = Convert.ToString(dr["Landmark"]),
                               Address1 = Convert.ToString(dr["Address1"]),
                               Address2 = Convert.ToString(dr["Address2"]),
                               City = Convert.ToString(dr["City"]),
                               Country = Convert.ToString(dr["Country"]),
                               EmailId = Convert.ToString(dr["EmailId"]),
                               FirstName = Convert.ToString(dr["FirstName"]),
                               LastName = Convert.ToString(dr["LastName"]),
                               Mobile = Convert.ToString(dr["Mobile"]),
                               OrderGuid = Convert.ToString(dr["OrderGuid"]),
                               State = Convert.ToString(dr["State"]),
                               CustomerGSTN = Convert.ToString(dr["CustomerGSTN"]),
                               Zip = Convert.ToString(dr["Zip"]),
                           }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBillingAddress", ex.Message);
        }
        return address;
    }

    public static List<UserDeliveryAddress> GetDeliveryAddress(SqlConnection conGV, string oGuid)
    {
        List<UserDeliveryAddress> address = new List<UserDeliveryAddress>();
        try
        {
            string query = " Select * from UserDeliveryAddress Where OrderGuid = @OrderGuid";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                address = (from DataRow dr in dt.Rows
                           select new UserDeliveryAddress()
                           {
                               Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                               AddedDateTime = Convert.ToDateTime(Convert.ToString(dr["AddedDateTime"])),
                               Email = Convert.ToString(dr["Email"]),
                               Block = Convert.ToString(dr["Block"]),
                               Apartment = Convert.ToString(dr["Apartment"]),
                               Address1 = Convert.ToString(dr["Address1"]),
                               Address2 = Convert.ToString(dr["Address2"]),
                               State = Convert.ToString(dr["State"]),
                               City = Convert.ToString(dr["City"]),
                               Country = Convert.ToString(dr["Country"]),
                               FirstName = Convert.ToString(dr["FirstName"]),
                               LastName = Convert.ToString(dr["LastName"]),
                               Mobile = Convert.ToString(dr["Mobile"]),
                               OrderGuid = Convert.ToString(dr["OrderGuid"]),
                               Zip = Convert.ToString(dr["Zip"]),
                               Landmark = Convert.ToString(dr["Landmark"])
                           }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDeliveryAddress", ex.Message);
        }
        return address;
    }

    public static string GetUserByOrder(SqlConnection conGV, string oGuid)
    {
        try
        {
            var query = "Select UserGuid from Orders where OrderGuid=@OrderGuid and Status !='Deleted'";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = oGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["UserGuid"].ToString();
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetDeliveryAddress", ex.Message);

        }
        return null;
    }

    public static DataTable GetOrderDetails(SqlConnection _conn, string o_guid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT * from POrders WHERE OrderGuid = @OrderGuid and Status!='Deleted';";
            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = o_guid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrderDetails", ex.Message);
        }
        return dt;
    }

    public static int UpdatePaymentStatus(SqlConnection _conn, string oGuid, string payId, DateTime addedon, string addedip)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("Update POrders Set PaymentStatus=@PaymentStatus,PaymentId=@PaymentId, LastUpdatedOn=@LastUpdatedOn, LastUpdatedIp=@LastUpdatedIp Where OrderGuid=@id", _conn);
            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = oGuid;
            cmd.Parameters.AddWithValue("@PaymentId", SqlDbType.NVarChar).Value = payId;
            cmd.Parameters.AddWithValue("@PaymentStatus", SqlDbType.NVarChar).Value = "Paid";
            cmd.Parameters.AddWithValue("@LastUpdatedOn", SqlDbType.NVarChar).Value = addedon;
            cmd.Parameters.AddWithValue("@LastUpdatedIp", SqlDbType.DateTime).Value = addedip;

            _conn.Open();
            x = cmd.ExecuteNonQuery();
            _conn.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateDeliveryDate", ex.Message);
        }
        return x;
    }

    public static DataTable GetAllMemberOrdersWithFilters(SqlConnection conAS, int pNo, int pSize, string fromDate, string toDate, string oStatus, string pStatus, string oParam)
    {
        DataTable result = new DataTable();
        try
        {
            string query = "GetAllMemberOrdersWithFilters";
            using (SqlCommand cmd = new SqlCommand(query, conAS))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNo", SqlDbType.NVarChar).Value = pNo;
                cmd.Parameters.AddWithValue("@pSize", SqlDbType.NVarChar).Value = pSize;
                cmd.Parameters.AddWithValue("@fromDate", SqlDbType.NVarChar).Value = fromDate;
                cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDate;
                cmd.Parameters.AddWithValue("@oStatus", SqlDbType.NVarChar).Value = oStatus;
                cmd.Parameters.AddWithValue("@pStatus", SqlDbType.NVarChar).Value = pStatus;
                cmd.Parameters.AddWithValue("@sParam", SqlDbType.NVarChar).Value = oParam;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(result);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllOrdersReportWithFilters", ex.Message);
        }
        return result;
    }
    public static DataTable GetAllOrdersReportWithFilters(SqlConnection conAS, int pNo, int pSize, string fromDate, string toDate, string oStatus, string pStatus, string oParam)
    {
        DataTable result = new DataTable();
        try
        {
            string query = "GetAllOrdersWithFilters";
            using (SqlCommand cmd = new SqlCommand(query, conAS))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNo", SqlDbType.NVarChar).Value = pNo;
                cmd.Parameters.AddWithValue("@pSize", SqlDbType.NVarChar).Value = pSize;
                cmd.Parameters.AddWithValue("@fromDate", SqlDbType.NVarChar).Value = fromDate;
                cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDate;
                cmd.Parameters.AddWithValue("@oStatus", SqlDbType.NVarChar).Value = oStatus;
                cmd.Parameters.AddWithValue("@pStatus", SqlDbType.NVarChar).Value = pStatus;
                cmd.Parameters.AddWithValue("@sParam", SqlDbType.NVarChar).Value = oParam;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(result);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllOrdersReportWithFilters", ex.Message);
        }
        return result;
    }
    public static DataTable GetAllProjectDues(SqlConnection conAS, int pNo, int pSize, string fromDate, string toDate, string oStatus, string pStatus, string oParam)
    {
        DataTable result = new DataTable();
        try
        {
            string query = "GetAllProjectDuesWithFilters";
            using (SqlCommand cmd = new SqlCommand(query, conAS))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pNo", SqlDbType.NVarChar).Value = pNo;
                cmd.Parameters.AddWithValue("@pSize", SqlDbType.NVarChar).Value = pSize;
                cmd.Parameters.AddWithValue("@fromDate", SqlDbType.NVarChar).Value = fromDate;
                cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDate;
                cmd.Parameters.AddWithValue("@oStatus", SqlDbType.NVarChar).Value = oStatus;
                cmd.Parameters.AddWithValue("@pStatus", SqlDbType.NVarChar).Value = pStatus;
                cmd.Parameters.AddWithValue("@sParam", SqlDbType.NVarChar).Value = oParam;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(result);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllProjectDues", ex.Message);
        }
        return result;
    }

    public static DataTable BindDashboardPaymentStatus(SqlConnection conMN, string fromDate, string toDate)
    {
        DataTable result = new DataTable();
        try
        {
            string query = "MBindDashboardOrderStatus";
            using (SqlCommand cmd = new SqlCommand(query, conMN))
            {
                cmd.Parameters.AddWithValue("@fromDate", SqlDbType.NVarChar).Value = fromDate;
                cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDate;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(result);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindDashboardPaymentStatus", ex.Message);
        }
        return result;
    }
    public static MonthlyChart GetMonthlynYearlyValueDefault(SqlConnection conMN)
    {
        MonthlyChart chart = new MonthlyChart();
        try
        {
            int[] lStatus = new int[3];
            int totalPaid = 0, totalInitiated = 0, totalInProcess = 0, totalRejected = 0, totalOrder = 0;
            decimal allTotalPaid = 0, allTotalInitiated = 0, allPercent = 0;


            DateTime toDayDate = TimeStamps.UTCTime();
            DateTime stDate = toDayDate.AddMonths(-11);
            DateTime newStDate = new DateTime(stDate.Year, stDate.Month, 1);

            var pStatus = BindDashboardPaymentStatus(conMN, "", "");
            if (pStatus.Rows.Count > 0)
            {
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalInitiated"]), out totalInitiated);
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalPaid"]), out totalPaid);
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalRejected"]), out totalRejected);

                lStatus[0] = totalInitiated;
                lStatus[1] = totalPaid;
                lStatus[2] = totalRejected;
            }
            else
            {
                lStatus[0] = 0;
                lStatus[1] = 0;
                lStatus[2] = 0;
            }
            chart.PayStatus = lStatus;

            string query = "MRevenueChart";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@chartType", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.NVarChar).Value = newStDate.ToString("dd/MMM/yyyy");
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDayDate.AddDays(1).ToString("dd/MMM/yyyy");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = ds.Tables[0];
            dt2 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalAmount"]), out allTotalPaid);
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalInitiatedAmount"]), out allTotalInitiated);
                for (int o = 0; o < dt.Rows.Count; o++)
                {
                    int tOrder = 0;
                    int.TryParse(Convert.ToString(dt.Rows[o]["OCount"]), out tOrder);
                    totalOrder += tOrder;
                }

                int i = 0;
                string[] dmons = new string[12];
                decimal[] sMts = new decimal[12];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {


                    var calls = dt.AsEnumerable().Where(v => ((v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {

                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("SaleAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddMonths(1);
                }

                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;


            }
            else
            {
                string[] dmons = null;
                decimal[] sMts = null;
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddMonths(1))
                {
                    dmons[i] = dtts.ToString("MMM yy");
                    sMts[i] = 0;
                    i++;
                }
                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }

            if (dt2.Rows.Count > 0)
            {


                int i = 0;
                string[] dmons = new string[12];
                decimal[] sMts = new decimal[12];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt2.AsEnumerable().Where(v => ((v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {
                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("InitiatedAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddMonths(1);
                }

                chart.MonthInitiated = sMts;

            }
            else
            {
                string[] dmons = new string[12];
                decimal[] sMts = new decimal[12];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddMonths(1))
                {
                    dmons[i] = dtts.ToString("MMM yy");
                    sMts[i] = 0;
                    i++;
                }
                chart.MonthInitiated = sMts;
            }

            if (allTotalPaid > 0 && allTotalInitiated > 0)
            {
                allPercent = allTotalPaid / ((allTotalInitiated + allTotalPaid) / (decimal)100);
            }
            if (allPercent > 0)
            {
                chart.ConvPercent = allPercent;
            }
            chart.TotalInitiated = allTotalInitiated;
            chart.TotalPaid = allTotalPaid;
            chart.TotalOrder = totalOrder;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMonthlynYearlyValueDefault", ex.Message);
        }
        return chart;
    }
    public static MonthlyChart GetMonthlynYearlyValueStatus(SqlConnection conMN, string fValue)
    {
        MonthlyChart chart = new MonthlyChart();
        try
        {
            int[] lStatus = new int[3];
            int totalPaid = 0, totalInitiated = 0, totalInProcess = 0, totalRejected = 0, totalDelivered = 0, totalCancelled = 0, totalOrder = 0;


            DateTime toDayDate = TimeStamps.UTCTime();
            //starts from 
            string stDate = "";
            string newStDate = "";

            if (fValue == "1W")
            {
                stDate = toDayDate.AddDays(-7).ToString("dd/MMM/yyyy");
                newStDate = toDayDate.ToString("dd/MMM/yyyy");
            }
            else if (fValue == "1M")
            {
                stDate = toDayDate.AddDays(-30).ToString("dd/MMM/yyyy");
                newStDate = toDayDate.ToString("dd/MMM/yyyy");
            }
            else if (fValue == "6M")
            {
                stDate = toDayDate.AddDays(-180).ToString("dd/MMM/yyyy");
                newStDate = toDayDate.ToString("dd/MMM/yyyy");
            }
            else if (fValue == "1Y")
            {
                stDate = toDayDate.AddDays(-365).ToString("dd/MMM/yyyy");
                newStDate = toDayDate.ToString("dd/MMM/yyyy");
            }


            var pStatus = BindDashboardPaymentStatus(conMN, stDate, newStDate);
            if (pStatus.Rows.Count > 0)
            {
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalInitiated"]), out totalInitiated);
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalPaid"]), out totalPaid);
                int.TryParse(Convert.ToString(pStatus.Rows[0]["TotalRejected"]), out totalRejected);

                lStatus[0] = totalInitiated;
                lStatus[1] = totalInProcess;
                lStatus[2] = totalRejected;
            }
            else
            {
                lStatus[0] = 0;
                lStatus[1] = 0;
                lStatus[2] = 0;
            }
            chart.PayStatus = lStatus;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMonthlynYearlyValueStatus", ex.Message);
        }
        return chart;
    }
    public static MonthlyChart GetMonthlynYearlyValue(SqlConnection conMN, string tps)
    {
        MonthlyChart chart = new MonthlyChart();
        try
        {
            int totalOrder = 0;
            int mIndex = tps == "6M" ? 6 : 12;
            decimal allTotalPaid = 0, allTotalInitiated = 0, allPercent = 0;


            DateTime toDayDate = TimeStamps.UTCTime();
            DateTime stDate = tps == "6M" ? toDayDate.AddMonths(-5) : toDayDate.AddMonths(-11);
            DateTime newStDate = new DateTime(stDate.Year, stDate.Month, 1);

            string query = "MRevenueChart";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@chartType", SqlDbType.NVarChar).Value = tps;
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.NVarChar).Value = newStDate.ToString("dd/MMM/yyyy");
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDayDate.AddDays(1).ToString("dd/MMM/yyyy");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = ds.Tables[0];
            dt2 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalAmount"]), out allTotalPaid);
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalInitiatedAmount"]), out allTotalInitiated);
                for (int o = 0; o < dt.Rows.Count; o++)
                {
                    int tOrder = 0;
                    int.TryParse(Convert.ToString(dt.Rows[o]["OCount"]), out tOrder);
                    totalOrder += tOrder;
                }

                int i = 0;
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {


                    var calls = dt.AsEnumerable().Where(v => ((v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {

                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("SaleAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddMonths(1);
                }

                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }
            else
            {
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddMonths(1))
                {
                    dmons[i] = dtts.ToString("MMM yy");
                    sMts[i] = 0;
                    i++;
                }
                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }

            if (dt2.Rows.Count > 0)
            {


                int i = 0;
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt2.AsEnumerable().Where(v => ((v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {
                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("InitiatedAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddMonths(1);
                }

                chart.MonthInitiated = sMts;

            }
            else
            {
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddMonths(1))
                {
                    dmons[i] = dtts.ToString("MMM yy");
                    sMts[i] = 0;
                    i++;
                }
                chart.MonthInitiated = sMts;
            }

            if (allTotalPaid > 0 && allTotalInitiated > 0)
            {
                allPercent = allTotalPaid / ((allTotalInitiated + allTotalPaid) / (decimal)100);
            }
            if (allPercent > 0)
            {
                chart.ConvPercent = allPercent;
            }
            chart.TotalInitiated = allTotalInitiated;
            chart.TotalPaid = allTotalPaid;
            chart.TotalOrder = totalOrder;


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMonthlynYearlyValue", ex.Message);
        }
        return chart;
    }
    public static MonthlyChart GetYearlyValue(SqlConnection conMN)
    {
        MonthlyChart chart = new MonthlyChart();
        try
        {

            int totalOrder = 0;
            decimal allTotalPaid = 0, allTotalInitiated = 0, allPercent = 0;


            DateTime toDayDate = TimeStamps.UTCTime();
            DateTime newStDate = new DateTime(2022, 1, 1);
            int mIndex = (toDayDate.Year - newStDate.Year) + 1;

            string query = "MRevenueChart";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@chartType", SqlDbType.NVarChar).Value = "All";
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = "";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = ds.Tables[0];
            dt2 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalAmount"]), out allTotalPaid);
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalInitiatedAmount"]), out allTotalInitiated);
                for (int o = 0; o < dt.Rows.Count; o++)
                {
                    int tOrder = 0;
                    int.TryParse(Convert.ToString(dt.Rows[o]["OCount"]), out tOrder);
                    totalOrder += tOrder;
                }

                int i = 0;
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt.AsEnumerable().Where(v => (v.Field<int>("Year_") == dtts.Year));
                    if (calls.Count() > 0)
                    {

                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("SaleAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("yyyy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("yyyy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddYears(1);
                }

                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;


            }
            else
            {
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddYears(1))
                {
                    dmons[i] = dtts.ToString("yyyy");
                    sMts[i] = 0;
                    i++;
                }
                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }

            if (dt2.Rows.Count > 0)
            {


                int i = 0;
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt2.AsEnumerable().Where(v => (v.Field<int>("Year_") == dtts.Year));
                    if (calls.Count() > 0)
                    {
                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("InitiatedAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("yyyy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("yyyy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddYears(1);
                }

                chart.MonthInitiated = sMts;

            }
            else
            {
                string[] dmons = new string[mIndex];
                decimal[] sMts = new decimal[mIndex];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate; dtts.AddYears(1))
                {
                    dmons[i] = dtts.ToString("yyyy");
                    sMts[i] = 0;
                    i++;
                }
                chart.MonthInitiated = sMts;
            }

            if (allTotalPaid > 0 && allTotalInitiated > 0)
            {
                allPercent = allTotalPaid / ((allTotalInitiated + allTotalPaid) / (decimal)100);
            }
            if (allPercent > 0)
            {
                chart.ConvPercent = allPercent;
            }
            chart.TotalInitiated = allTotalInitiated;
            chart.TotalPaid = allTotalPaid;
            chart.TotalOrder = totalOrder;



        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetYearlyValue", ex.Message);
        }
        return chart;
    }
    public static MonthlyChart GetMonthlyValue(SqlConnection conMN, string tps)
    {
        MonthlyChart chart = new MonthlyChart();
        try
        {
            int totalOrder = 0;
            decimal allTotalPaid = 0, allTotalInitiated = 0, allPercent = 0;
            DateTime toDayDate = TimeStamps.UTCTime();
            //DateTime stDate = toDayDate.AddMonths(-1);
            DateTime newStDate = tps == "1W" ? toDayDate.AddDays(-7) : toDayDate.AddMonths(-1);


            string query = "MRevenueChart";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@chartType", SqlDbType.NVarChar).Value = "1M";
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.NVarChar).Value = newStDate.ToString("dd/MMM/yyyy");
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDayDate.AddDays(1).ToString("dd/MMM/yyyy");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt = ds.Tables[0];
            dt2 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalAmount"]), out allTotalPaid);
                decimal.TryParse(Convert.ToString(dt.Rows[0]["TotalInitiatedAmount"]), out allTotalInitiated);
                for (int o = 0; o < dt.Rows.Count; o++)
                {
                    int tOrder = 0;
                    int.TryParse(Convert.ToString(dt.Rows[o]["OCount"]), out tOrder);
                    totalOrder += tOrder;
                }

                int i = 0, dateDiff = 0;

                dateDiff = Convert.ToInt32(Math.Ceiling((toDayDate.AddDays(1) - newStDate).TotalDays));

                string[] dmons = new string[dateDiff];
                decimal[] sMts = new decimal[dateDiff];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt.AsEnumerable().Where(v => ((v.Field<int>("Day_") == dtts.Day) && (v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {
                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("SaleAmount") }).FirstOrDefault();

                        decimal ldCnt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("dd MMM yy");
                        sMts[i] = ldCnt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("dd MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddYears(1);
                }

                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;


            }
            else
            {


                int i = 0, dateDiff = 0;
                dateDiff = Convert.ToInt32(Math.Ceiling((toDayDate.AddDays(1) - newStDate).TotalDays));
                string[] dmons = new string[dateDiff];
                decimal[] sMts = new decimal[dateDiff];

                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    dmons[i] = dtts.ToString("dd MMM yy");
                    sMts[i] = 0;
                    i++;
                    dtts = dtts.AddDays(1);
                }
                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }

            if (dt2.Rows.Count > 0)
            {
                int i = 0, dateDiff = 0;

                dateDiff = Convert.ToInt32(Math.Ceiling((toDayDate.AddDays(1) - newStDate).TotalDays));

                string[] dmons = new string[dateDiff];
                decimal[] sMts = new decimal[dateDiff];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt2.AsEnumerable().Where(v => ((v.Field<int>("Day_") == dtts.Day) && (v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {
                        var sl = calls.Select(x => new { InitiatedAmount = x.Field<decimal>("InitiatedAmount") }).FirstOrDefault();

                        decimal ldCnt = sl != null ? sl.InitiatedAmount : 0;
                        dmons[i] = dtts.ToString("dd MMM yy");
                        sMts[i] = ldCnt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("dd MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddDays(1);
                }
                chart.MonthInitiated = sMts;


            }
            else
            {
                int i = 0, dateDiff = 0;
                dateDiff = Convert.ToInt32(Math.Ceiling((toDayDate.AddDays(1) - newStDate).TotalDays));
                string[] dmons = new string[dateDiff];
                decimal[] sMts = new decimal[dateDiff];

                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    dmons[i] = dtts.ToString("dd MMM yy");
                    sMts[i] = 0;
                    i++;
                    dtts = dtts.AddDays(1);
                }
                chart.MonthInitiated = sMts;
            }

            if (allTotalPaid > 0 && allTotalInitiated > 0)
            {
                allPercent = allTotalPaid / ((allTotalInitiated + allTotalPaid) / (decimal)100);
            }
            if (allPercent > 0)
            {
                chart.ConvPercent = allPercent;
            }
            chart.TotalInitiated = allTotalInitiated;
            chart.TotalPaid = allTotalPaid;
            chart.TotalOrder = totalOrder;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMonthlyValue", ex.Message);
        }
        return chart;
    }
    public static MonthlyChartUser GetMonthlynYearlyValueDefaultUser(SqlConnection conMN, string uGuid)
    {
        MonthlyChartUser chart = new MonthlyChartUser();
        try
        {


            DateTime toDayDate = TimeStamps.UTCTime();
            DateTime stDate = toDayDate.AddMonths(-11);
            DateTime newStDate = new DateTime(stDate.Year, stDate.Month, 1);


            string queryState = "UserStateWiseSales";
            SqlCommand cmdState = new SqlCommand(queryState, conMN);
            cmdState.CommandType = CommandType.StoredProcedure;
            cmdState.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            SqlDataAdapter sdaState = new SqlDataAdapter(cmdState);
            DataTable dtState = new DataTable();
            sdaState.Fill(dtState);
            int[] lStatus = new int[dtState.Rows.Count];
            string[] lState = new string[dtState.Rows.Count];
            if (dtState.Rows.Count > 0)
            {
                for (int i = 0; i < dtState.Rows.Count; i++)
                {
                    int stCount = 0;
                    int.TryParse(Convert.ToString(dtState.Rows[i]["StateCount"]), out stCount);
                    lStatus[i] = stCount;
                    lState[i] = Convert.ToString(dtState.Rows[i]["States"]);
                }

            }
            chart.StateCounts = lStatus;
            chart.StateNames = lState;

            string query = "UserSalesChart";
            SqlCommand cmd = new SqlCommand(query, conMN);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            cmd.Parameters.AddWithValue("@chartType", SqlDbType.NVarChar).Value = "";
            cmd.Parameters.AddWithValue("@startDate", SqlDbType.NVarChar).Value = newStDate.ToString("dd/MMM/yyyy");
            cmd.Parameters.AddWithValue("@toDate", SqlDbType.NVarChar).Value = toDayDate.AddDays(1).ToString("dd/MMM/yyyy");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                string[] dmons = new string[12];
                decimal[] sMts = new decimal[12];
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    var calls = dt.AsEnumerable().Where(v => ((v.Field<int>("Month_") == dtts.Month) && (v.Field<int>("Year_") == dtts.Year)));
                    if (calls.Count() > 0)
                    {

                        var sl = calls.Select(x => new { SaleAmount = x.Field<decimal>("SaleAmount") }).FirstOrDefault();

                        decimal saleAmt = sl != null ? sl.SaleAmount : 0;
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = saleAmt;
                    }
                    else
                    {
                        dmons[i] = dtts.ToString("MMM yy");
                        sMts[i] = 0;
                    }
                    i++;
                    dtts = dtts.AddMonths(1);
                }

                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;


            }
            else
            {
                string[] dmons = new string[12];
                decimal[] sMts = new decimal[12];
                int i = 0;
                for (DateTime dtts = newStDate; dtts <= toDayDate;)
                {
                    dmons[i] = dtts.ToString("MMM yy");
                    sMts[i] = 0;
                    i++;
                    dtts = dtts.AddMonths(1);
                }
                chart.DayMonthNYear = dmons;
                chart.MonthSale = sMts;
            }

        }
        catch (Exception ex)
        {

            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetMonthlynYearlyValueDefaultUser", ex.Message + " ---------- " + uGuid);
        }
        return chart;
    }
}

public class OrderItems
{
    public string Id { get; set; }
    public string OrderGuid { get; set; }
    public string ProductGuid { get; set; }
    public string ProductId { get; set; }
    public string ProductUrl { get; set; }
    public string CategoryUrl { get; set; }
    public string PriceId { get; set; }
    public string ProductImage { get; set; }
    public string Size { get; set; }
    public string ProductName { get; set; }
    public string TaxPercent { get; set; }
    public string Quantity { get; set; }
    public string Price { get; set; }
    public string ActualPrice { get; set; }
    public DateTime AddedOn { get; set; }
    //Extra
    public string ModelNo { get; set; }

}

public class SearchReports
{
    public string LineItems { get; set; }
    public int TotalCount { get; set; }
    public string Status { get; set; }
    public string StatusMessage { get; set; }
}
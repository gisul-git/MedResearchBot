using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class project_payment_failed : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["O"] != null)
        {
            var orderid = Request.QueryString["O"];
            var order = PReports.GetSingleOrderDetailsWOid(conMN, orderid);
            if (order != null)
            {

                POrders orders = new POrders();
                string Oid = PUserCheckout.GetOrderId(conMN, orderid);
                string rId = PUserCheckout.GetRMax(conMN);
                orders.OrderGuid = order.OrderGuid;
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.PaymentMode = "";
                orders.RMax = "";
                orders.ReceiptNo = "";
                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
            }
        }
    }
}
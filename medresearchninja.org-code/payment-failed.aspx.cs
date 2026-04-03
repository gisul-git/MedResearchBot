using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class payment_failed : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["O"] != null)
        {
            var orderid = Request.QueryString["O"];
            var order = Reports.GetSingleOrderDetailsWOid(conMN, orderid);
            if (order != null)
            {

                Orders orders = new Orders();
                string Oid = UserCheckout.GetOrderId(conMN, orderid);
                string rId = UserCheckout.GetRMax(conMN);
                orders.OrderGuid = order.OrderGuid;
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.RMax = "";
                orders.ReceiptNo = "";
                int x = UserCheckout.UpdateUserOrder(conMN, orders);
            }
        }
    }
}
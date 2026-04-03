using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Specialized;
using System.Security.Cryptography;

public partial class project_payment_status : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string payStatus = "", token = "", orderGuid = "", CODOrderGuid = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        #region   4. Get details of this payment order Using TransactionId
        ////  Get details of this payment order Using TransactionId
        try
        {

            string paymentId = Request.Form["razorpay_payment_id"];
            string orderid = Request.Form["orderIdd"].ToString();
            string buyerAmount = Request.Form["buyerAmount"].ToString();
            string key = ConfigurationManager.AppSettings["razorid"];
            string secret = ConfigurationManager.AppSettings["razorsecret"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToInt32(Request.Form["buyerAmount"]));
            RazorpayClient client = new RazorpayClient(key, secret);
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);
            Utils.verifyPaymentSignature(attributes);
            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);
            var sts = payment.Attributes;
            NameValueCollection nvc = Request.Form;

            POrders orders = new POrders();
            if (sts.status == "captured")
            {
                string Oid = PUserCheckout.GetOrderId(conMN, orderid);
                string rId = PUserCheckout.GetRMax(conMN);
                orders.OrderGuid = orderid;
                orders.PaymentStatus = "Paid";
                orders.OrderStatus = "Completed";
                orders.PaymentId = paymentId;
                orders.hostedCheckoutId = "";
                orders.RMax = rId;
                orders.ReceiptNo = "MEDPROJECT" + rId;
                int x = PUserCheckout.UpdateUserOrder1(conMN, orders);
                if (x > 0)
                {
                    string uid = HttpContext.Current.Request.Cookies["med_uid"] != null ? HttpContext.Current.Request.Cookies["med_uid"].Value : HttpContext.Current.Request.Cookies["med_uid"].Value;
                     PUserCheckout.SendToUser(conMN, orderid);
                    var timeline = new OrderTimeline()
                    {
                        OrderGuid = orderid,
                        OrderStatus = "Completed",
                        AddedBy = uid,
                    };

                    var exe = OrderTimeline.AddTimeline(conMN, timeline);
                    Response.Redirect("pay-success.aspx?o=" + Oid);
                }
            }
            else
            {
                string Oid = PUserCheckout.GetOrderId(conMN, orderid);
                string rId = PUserCheckout.GetRMax(conMN);
                orders.OrderGuid = Request.QueryString["oGuid"];
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.RMax = "";
                orders.PaymentMode = "";
                orders.ReceiptNo = "";
                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                Response.Redirect("pay-error.aspx");
            }
        }
        catch (ArgumentNullException ex)
        {
            Response.Write(ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        catch (WebException ex)
        {
            Response.Write(ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        #endregion

    }
}



















/*{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string payStatus = "", token = "", orderGuid = "", CODOrderGuid = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        #region   4. Get details of this payment order Using TransactionId
        ////  Get details of this payment order Using TransactionId
        try
        {

            string paymentId = Request.Form["razorpay_payment_id"];
            string orderid = Request.Form["orderIdd"].ToString();
            string buyerAmount = Request.Form["buyerAmount"].ToString();
            string key = ConfigurationManager.AppSettings["razorid"];
            string secret = ConfigurationManager.AppSettings["razorsecret"];

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToInt32(Request.Form["buyerAmount"]));
            RazorpayClient client = new RazorpayClient(key, secret);
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);
            Utils.verifyPaymentSignature(attributes);
            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);
            var sts = payment.Attributes;
            NameValueCollection nvc = Request.Form;


            POrders orders = new POrders();
            if (sts.status == "captured")
            {
                string Oid = PUserCheckout.GetOrderId(conMN, orderid);
                string rId = PUserCheckout.GetRMax(conMN);
                orders.OrderGuid = orderid;
                orders.PaymentStatus = "Paid";
                orders.OrderStatus = "InProgress";
                orders.PaymentId = paymentId;
                orders.hostedCheckoutId = "";
                orders.RMax = rId;
                orders.ReceiptNo = "MEDIR" + rId;
                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                if (x > 0)
                {
                    var user = Convert.ToString(PReports.GetUserByOrder(conMN, orderid));
                    if (user != "")
                    {
                        //string uid = HttpContext.Current.Request.Cookies["med_uid"] != null ? HttpContext.Current.Request.Cookies["med_uid"].Value : HttpContext.Current.Request.Cookies["gluta_vi"].Value;
                        // CartDetails.RemoveAllItemsFromCart(con, uid);
                        PUserCheckout.SendToUser(conMN, orderid);
                        var timeline = new OrderTimeline()
                        {
                            OrderGuid = orderid,
                            OrderStatus = "Confirmed",
                            AddedBy = user,
                        };
                        var exe = OrderTimeline.AddTimeline(conMN, timeline);
                        MemberDetails.UpdatePaymentStatus(conMN, user); 
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        payStatus = @"There is some problem now. Please try again later";
                    }

                }
            }
            else
            {

                string Oid = PUserCheckout.GetOrderId(conMN, orderid);
                string rId = PUserCheckout.GetRMax(conMN);
                orders.OrderGuid = Request.QueryString["oGuid"];
                orders.PaymentStatus = "Failed";
                orders.OrderStatus = "Failed";
                orders.PaymentId = "";
                orders.hostedCheckoutId = "";
                orders.RMax = "";
                orders.ReceiptNo = "";
                int x = PUserCheckout.UpdateUserOrder(conMN, orders);
                // Response.Redirect("pay-error.aspx");
                Response.Redirect("signup.aspx");
            }
        }
        catch (ArgumentNullException ex)
        {
            Response.Write(ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        catch (WebException ex)
        {
            Response.Write(ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        catch (Exception ex)
        {
            Response.Write("Error:" + ex.Message);
            payStatus = @"There is some problem now. Please try again later ";
        }
        #endregion

    }
}
*/
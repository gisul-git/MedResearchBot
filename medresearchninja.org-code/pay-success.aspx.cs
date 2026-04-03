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

public partial class pay_success : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);

    public string strStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["o"] != null)
        {
            strStatus = "<img style='height:200px;' src='/images/shield.gif' /><h3 class='main-heading text-success'>Thank You !<br>Your order has been placed successfully. <br>Your order number is - <strong><u>" + Request.QueryString["o"] + "</u></strong><br>Details will be sent to your email shortly.";
            var orderid = Request.QueryString["o"];
            //UserCheckout.SendToUser(conMN, orderid);
            var order = PReports.GetSingleOrderDetailsWOid(conMN, orderid);
            if (order != null)
            {
        Emails.BookingConfirmedNew(order.UserName, order.EmailId,order.TotalPrice,order.OrderId,order.ProjectName, ConfigurationManager.AppSettings["domain"] + "/receipt.aspx?o=" + order.OrderGuid);
        Emails.BookingConfirmedAdminNew(order.UserName, order.EmailId, order.TotalPrice, order.ReceiptNo, order.ProjectName, ConfigurationManager.AppSettings["domain"] + "/receipt.aspx?o=" + order.OrderGuid);
            }
        }
        else
        {
            Response.Redirect("/");
        }
    }
}
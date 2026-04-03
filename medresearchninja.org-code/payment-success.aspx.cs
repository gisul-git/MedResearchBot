using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class payment_success : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strStatus = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["O"] != null)
        {
            strStatus = "<img style='height:300px;' class='mb-3' src='/assets/images/rb_20631.png' />" +
                "<h3 class='main-heading text-success text-dark'>" +
                "<strong>Thank you for your membership! </strong></h3><h5 class='mt-2'>Please check your email for further instructions, including a link to join our exclusive WhatsApp group." +

                "Stay connected, collaborate with fellow researchers, and stay tuned for exclusive updates, resources, and opportunities!</h5>";
            var orderid = Request.QueryString["O"];
            //UserCheckout.SendToUser(conMN, orderid);
            var order = Reports.GetSingleOrderDetailsWOid(conMN, orderid);
            if(order.PaymentStatus != "Paid")
            {   
                var exe1 = PayUAPI.VerifyPayment(order.OrderGuid);
                if (exe1 != null)
                {
                    if (exe1.Status == "1")
                    {

                        if (order != null)
                        {

                            Orders orders = new Orders();
                            string Oid = orderid;  //UserCheckout.GetOrderId(conMN, orderid);
                            string rId = UserCheckout.GetRMax(conMN);
                            orders.OrderGuid = order.OrderGuid;
                            orders.PaymentStatus = "Paid";
                            orders.OrderStatus = "Completed";
                            orders.PaymentId = exe1.Transaction_Details[order.OrderGuid].Mihpayid;
                            orders.hostedCheckoutId = "";
                            orders.RMax = rId;
                            orders.ReceiptNo = "MEDIR" + rId;
                            int x = UserCheckout.UpdateUserOrder(conMN, orders);
                            if (x > 0)
                            {
                                var user = Convert.ToString(Reports.GetUserByOrder(conMN, orders.OrderGuid));
                                if (user != "")
                                {
                                   
                                    MemberDetails.UpdatePaymentStatus(conMN, user);
                                    var userDetail = MemberDetails.GetMemberDetailsByGuid(conMN, user);
                                    var pwd = CommonModel.Decrypt(userDetail.Password);
                                    var mail = Emails.NewMembershipMail(userDetail.FullName, userDetail.EmailId, pwd, userDetail.WLink);
                                    var admmail = Emails.NewMembershipMailAdmin(userDetail.FullName, userDetail.EmailId);
                                    //MembershipConfirmMail(userDetail.EmailId, userDetail.FullName);
                                    //Response.Redirect("thank-you1.aspx");
                                }
                                else
                                {
                                    strStatus = @"There is some problem now. Please try again later";
                                }

                            }
                            //Emails.BookingConfirmedNew(order.UserName, order.EmailId, order.TotalPrice, order.OrderId, order.ProjectName, ConfigurationManager.AppSettings["domain"] + "/receipt.aspx?o=" + order.OrderGuid);
                            //Emails.BookingConfirmedAdminNew(order.UserName, order.EmailId, order.TotalPrice, order.ReceiptNo, order.ProjectName, ConfigurationManager.AppSettings["domain"] + "/receipt.aspx?o=" + order.OrderGuid);
                        }
                    }
                    else
                    {
                        strStatus = "<img style='height:200px;' src='/images/x.gif' /><h3 class='main-heading text-danger'>Not Found!<br>Your order can not be found. please contact adminstration for furthur details.</h3>";

                    }

                }

            }
            else
            {
                strStatus = "<img style='height:200px;' src='/images/x.gif' /><h3 class='main-heading text-danger'>Not Found!<br>Your order can not be found. please contact adminstration for furthur details.</h3>";
            }
        }
        else
        {
            Response.Redirect("/");
        }

    }

    //public static int MembershipConfirmMail(string email, string name)
    //{
    //    try
    //    {


    //        MailMessage mail = new MailMessage();
    //        mail.To.Add(email);

    //        mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
    //        mail.Subject = "Welcome to MedResarchNinja Your Membership Registration is Completed";

    //        string Body = "Dear " + name + ",<br/><br/><br/>Welcome to MedResarchNinja – we’re so happy to have you!<br/>Your registration was successful, and you’re all set to start exploring. Log in to your account<br/><br/><br/>Thanks & Regards<br/>MedResarchNinja<br/>";

    //        mail.Body = Body;
    //        mail.IsBodyHtml = true;
    //        SmtpClient smtp = new SmtpClient();
    //        smtp.Host = ConfigurationManager.AppSettings["host"];
    //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
    //        smtp.Credentials = new System.Net.NetworkCredential
    //               (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
    //        smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
    //        smtp.Send(mail);
    //        return 1;
    //    }
    //    catch (Exception exx)
    //    {
    //        return 0;
    //    }
    //}
}
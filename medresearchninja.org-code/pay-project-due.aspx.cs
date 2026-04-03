using PayPal.Api;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pay_project_due : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string ProjectCode = "", Projectname = "", buyerName = "", buyerEmail = "", BuyerMobile = "", paybleAmount = "", buyerAmount = "", strTotal = "";
    public string strKey = "", strTRid = "", strPInfo = "", strAmount = "", strEmail = "", strFName = "", strSUrl = "", strFUrl = "", strPhone = "", strHash = "";
    public bool IsPayPalPayment = false;
    public string UserCountryCode = "";
    public string PaymentGateway = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["pid"]))
        {
            Response.Redirect("/");
            return;
        }

        try
        {
            string userIP = CommonModel.GetUserIPAddress();
            UserCountryCode = CommonModel.GetCountryByIP(userIP);
            IsPayPalPayment = !CommonModel.IsIndianUser(UserCountryCode);
            PaymentGateway = IsPayPalPayment ? "PayPal" : "PayU";

            BindPaymentDetails();
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Pay_project_due_PageLoad", ex.Message);
            Response.Redirect("pay-error.aspx");
        }
    }

    private void BindPaymentDetails()
    {
        try
        {
            double cost = 0;
            var p_Details = Projects.GetPaymentDetailsBy_PaymentGuid(conMN, Request.QueryString["pid"]);

            if (p_Details.Rows.Count > 0)
            {
                strTotal = Convert.ToDecimal(Convert.ToString(p_Details.Rows[0]["Amount"])).ToString("C", CultureInfo.CreateSpecificCulture("en-IN"));
                buyerEmail = Convert.ToString(p_Details.Rows[0]["EmailId"]);
                buyerName = Convert.ToString(p_Details.Rows[0]["FullName"]);
                BuyerMobile = Convert.ToString(p_Details.Rows[0]["Contact"]);
                cost = Convert.ToDouble(Convert.ToString(p_Details.Rows[0]["Amount"]));
                paybleAmount = cost.ToString();

                // Set project details
                ProjectCode = Convert.ToString(p_Details.Rows[0]["ProjectId"]);
                Projectname = Convert.ToString(p_Details.Rows[0]["ProjectName"]);

                if (IsPayPalPayment)
                {
                    // Initialize PayPal payment
                    InitializePayPalPaymentForProjectDue(p_Details.Rows[0]);
                }
                else
                {
                    // Initialize PayU payment 
                    InitializePayUPayment(p_Details.Rows[0], cost);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPaymentDetails", ex.Message);
        }
    }

    private void InitializePayUPayment(System.Data.DataRow paymentDetails, double cost)
    {
        var salt = ConfigurationManager.AppSettings["SALTKey"];
        strKey = ConfigurationManager.AppSettings["KeyID"];
        var domain = ConfigurationManager.AppSettings["domain"];

        var details = new PayUAPIRequest()
        {
            Address1 = "",
            Address2 = "",
            Amount = cost,
            City = "",
            State = "",
            Country = "",
            Email = Convert.ToString(paymentDetails["EmailId"]),
            FirstName = Convert.ToString(paymentDetails["FullName"]),
            LastName = "",
            Furl = domain + "project-due-status.aspx?p=" + Convert.ToString(paymentDetails["PaymentGuid"]),
            Surl = domain + "project-due-status.aspx?p=" + Convert.ToString(paymentDetails["PaymentGuid"]),
            Phone = Convert.ToString(paymentDetails["Contact"]),
            ProductInfo = Convert.ToString(paymentDetails["ProjectName"]),
            Txnid = Convert.ToString(paymentDetails["PaymentGuid"]),
            Zipcode = "",
            Key = strKey
        };

        strTRid = details.Txnid;
        strPInfo = details.ProductInfo;
        strAmount = details.Amount.ToString();
        strEmail = details.Email;
        strFName = details.FirstName;
        strSUrl = details.Surl;
        strFUrl = details.Furl;
        strPhone = details.Phone;
        strHash = GenerateHash(details, salt);
    }

    private void InitializePayPalPaymentForProjectDue(System.Data.DataRow paymentDetails)
    {
        try
        {
            string clientId = ConfigurationManager.AppSettings["PaypalClientId"];
            string clientSecret = ConfigurationManager.AppSettings["PaypalSecretId"];
            string mode = ConfigurationManager.AppSettings["PaypalMode"];
            string domain = ConfigurationManager.AppSettings["domain"];

            var config = new Dictionary<string, string>();
            config.Add("mode", mode);
            config.Add("clientId", clientId);
            config.Add("clientSecret", clientSecret);

            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken) { Config = config };

            // Get amount from database
            decimal Amount = Convert.ToDecimal(paymentDetails["AmountUSD"]); 

            // Create PayPal payment
            var payment = PayPal.Api.Payment.Create(apiContext, new PayPal.Api.Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal",
                    payer_info = new PayerInfo()
                    {
                        email = Convert.ToString(paymentDetails["EmailId"]),
                        first_name = Convert.ToString(paymentDetails["FullName"]),
                        last_name = ""
                    }
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "MedResearch Ninja Project Due Payment: " + Convert.ToString(paymentDetails["ProjectName"]),
                        invoice_number = Convert.ToString(paymentDetails["PaymentGuid"]),
                        amount = new Amount
                        {
                            currency = "USD",
                            total = Amount.ToString("0.00", CultureInfo.InvariantCulture),
                            details = new Details
                            {
                                subtotal = Amount.ToString("0.00", CultureInfo.InvariantCulture)
                            }
                        },
                        item_list = new ItemList
                        {
                            items = new List<Item>
                            {
                                new Item
                                {
                                    name = Convert.ToString(paymentDetails["ProjectName"]),
                                    currency = "USD",
                                    price = Amount.ToString("0.00", CultureInfo.InvariantCulture),
                                    quantity = "1",
                                    sku = "DUE-" + Convert.ToString(paymentDetails["ProjectId"])
                                }
                            }
                        }
                    }
                },
                redirect_urls = new RedirectUrls
                {
                    return_url = domain + "project-due-paypal-status.aspx?p=" + Convert.ToString(paymentDetails["PaymentGuid"]),
                    cancel_url = domain + "project-due-paypal-failed.aspx?p=" + Convert.ToString(paymentDetails["PaymentGuid"])
                }
            });

            // Redirect to PayPal
            var links = payment.links.GetEnumerator();
            while (links.MoveNext())
            {
                var link = links.Current;
                if (link.rel.ToLower().Trim().Equals("approval_url"))
                {
                    Response.Redirect(link.href, false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    return;
                }
            }
        }
        catch (ThreadAbortException)
        { 
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InitializePayPalPaymentForProjectDue", ex.Message);
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

    // Keep existing GenerateHash method
    public static string GenerateHash(PayUAPIRequest details, string salt)
    {
        var hashString = details.Key + "|" + details.Txnid + "|" + details.Amount + "|" +
                         details.ProductInfo + "|" + details.FirstName + "|" + details.Email +
                         "|||||||||||" + salt;
        return Sha512(hashString);
    }

    private static string Sha512(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
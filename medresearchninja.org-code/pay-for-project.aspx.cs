using ClosedXML.Excel;
using DocumentFormat.OpenXml.Presentation;
using PayPal.Api;
using Razorpay.Api;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Query.Dynamic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pay_for_project : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strCategories, strContact, strEmail, strUserName, ProjectCode, Projectname = "";
    public string strScrollText = "", strMobLogin = "", strDeskLogin = "", strDeskText = "", strOrders = "", strDeskNavCategory = "", strMobNavCategories = "", strDelivery = "", strBilling = "", strSubTotal = "", strShipping = "", strDiscount = "", strCoupnDiscount = "", strTax = "", strTotal = "", buyerAmount = "", orderIdd = "", buyerName = "", BuyerMobile = "", buyerEmail = "", paybleAmount = "", strRazorId = "", strRazorSecret = "";
    public string strKey = "", strTRid = "", strPInfo = "", strFName = "", strAmount = "", strLname = "", strSUrl = "", strFUrl = "", strPhone = "", strHash = "";

    // PayPal related variables
    public bool IsPayPalPayment = false;
    public string UserCountryCode = "";
    public string PaymentGateway = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["order"] == null)
        {
            Response.Redirect("/");
            return;
        }

        try
        {
            // Detect user country
            string userIP = CommonModel.GetUserIPAddress();
            UserCountryCode = CommonModel.GetCountryByIP(userIP);
            IsPayPalPayment = !CommonModel.IsIndianUser(UserCountryCode);
            PaymentGateway = IsPayPalPayment ? "PayPal" : "PayU";

            double cost = 0;
            var ord = PReports.GetSingleOrderDetails(conMN, Request.QueryString["order"]).FirstOrDefault();

            if (ord != null)
            {
                strTotal = Convert.ToDecimal(ord.TotalPrice).ToString("C", CultureInfo.CreateSpecificCulture("en-IN"));
                buyerEmail = ord.EmailId;
                buyerName = ord.UserName;
                BuyerMobile = ord.Contact;
                cost = Convert.ToDouble(ord.TotalPrice);
                paybleAmount = cost.ToString();

                // Set project details
                ProjectCode = ord.ProjectID;
                Projectname = ord.ProjectName;

                if (IsPayPalPayment)
                {
                    // PayPal payment

                    InitializePayPalPaymentForProject(ord);
                }
                else
                {
                    // PayU payment 
                    InitializePayUPayment(ord, cost);
                }
            }
        }
        catch (ThreadAbortException)
        {
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Pay_for_Payment", ex.Message);
            Response.Redirect("pay-error.aspx");
        }
    }

    private void InitializePayUPayment(dynamic ord, double cost)
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
            Email = ord.EmailId,
            FirstName = ord.UserName,
            LastName = "",
            Furl = domain + "project-payment-failed.aspx?O=" + ord.OrderId,
            Surl = domain + "project-payment-success.aspx?O=" + ord.OrderId,
            Phone = ord.Contact,
            ProductInfo = ord.ProjectName,
            Txnid = ord.OrderGuid,
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

    private void InitializePayPalPaymentForProject(dynamic ord)
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

            // Create PayPal payment
            var payment = PayPal.Api.Payment.Create(apiContext, new PayPal.Api.Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal",
                    payer_info = new PayerInfo()
                    {
                        email = ord.EmailId,
                        first_name = ord.UserName,
                        last_name = ""
                    }
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "MedResearch Ninja Project Payment: " + ord.ProjectName,
                        invoice_number = ord.OrderId,
                        amount = new Amount
                        {
                            currency = "USD", // Change to your preferred currency
                            total = ord.PriceUSD.ToString(),
                            details = new Details
                            {
                                subtotal =  ord.PriceUSD.ToString()
                            }
                        },
                        item_list = new ItemList
                        {
                            items = new List<Item>
                            {
                                new Item
                                {
                                    name = ord.ProjectName,
                                    currency = "USD",
                                    price =  ord.PriceUSD.ToString(),
                                    quantity = "1",
                                    sku = "PROJECT-" + ord.OrderId
                                }
                            }
                        }
                    }
                },
                redirect_urls = new RedirectUrls
                {
                    return_url = domain + "project-paypal-status.aspx?o=" + ord.OrderGuid,
                    cancel_url = domain + "project-paypal-failed.aspx?o=" + ord.OrderGuid
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InitializePayPalPaymentForProject", ex.Message);
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

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
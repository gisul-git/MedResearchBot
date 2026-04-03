using ClosedXML.Excel;
using PayPal.Api;
using Razorpay.Api;
using System;
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

public partial class pay_now : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strCategories, strContact, strEmail, strUserName, strCountry, strSchool, strAmount = "";
    public string strScrollText = "", strMobLogin = "", strDeskLogin = "", strDeskText = "", strOrders = "", strDeskNavCategory = "", strMobNavCategories = "", strDelivery = "", strBilling = "", strSubTotal = "", strShipping = "", strDiscount = "", strCoupnDiscount = "", strTax = "", strTotal = "", buyerAmount = "", orderIdd = "", buyerName = "", BuyerMobile = "", buyerEmail = "", paybleAmount = "", strRazorId = "", strRazorSecret = "";
    public string strKey = "", strTRid = "", strPInfo = "", strFName = "", strLname = "", strSUrl = "", strFUrl = "", strPhone = "", strHash = "";

    // PayPal related variables
    public bool IsPayPalPayment = false;
    public string UserCountryCode = "";
    public string PaymentGateway = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["order"] == null)
        {
            Response.Redirect("/", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            return;
        }

        try
        {
            string userIP = CommonModel.GetUserIPAddress();
            UserCountryCode = CommonModel.GetCountryByIP(userIP);
            IsPayPalPayment = !CommonModel.IsIndianUser(UserCountryCode);
            PaymentGateway = IsPayPalPayment ? "PayPal" : "PayU";

            double cost = 0;
            var ord = Reports.GetSingleOrderDetails(conMN, Request.QueryString["order"]).FirstOrDefault();

            if (ord != null)
            {
                strTotal = Convert.ToDecimal(ord.TotalPrice).ToString("C", CultureInfo.CreateSpecificCulture("en-IN"));
                buyerEmail = ord.EmailId;
                buyerName = ord.UserName;
                BuyerMobile = ord.Contact;
                cost = Convert.ToDouble(ord.TotalPrice);
                paybleAmount = cost.ToString();
                // Force PayPal to charge $10 (USD)
                string usdAmount = "10.00";
                if (IsPayPalPayment)
                {
                    InitializePayPalPayment(ord.OrderGuid, usdAmount, ord.OrderId, ord.UserName, ord.EmailId);
                }
                else
                {
                    InitializePayUPayment(ord, cost);
                }
            }
        }
        catch (ThreadAbortException)
        {
            // This is expected - don't log it
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "pay_now_PageLoad", ex.Message);
            Response.Redirect("pay-error.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }

    private void InitializePayUPayment(dynamic ord, double cost)
    {
        try
        {
            buyerAmount = (cost * 100).ToString();
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
                Furl = domain + "payment-failed.aspx?O=" + ord.OrderId,
                Surl = domain + "payment-success.aspx?O=" + ord.OrderId,
                Phone = ord.Contact,
                ProductInfo = "New Membership",
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
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InitializePayUPayment", ex.Message);
            throw;
        }
    }

    private void InitializePayPalPayment(string orderGuid, string totalAmount, string orderId, string userName, string email)
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

            List<Item> itemList = new List<Item>();
            itemList.Add(new Item
            {
                name = "MedResearch Ninja Membership",
                currency = "USD", // Change to your preferred currency
                price = totalAmount,
                quantity = "1",
                sku = "MEMBERSHIP-" + orderId
            });

            ItemList items = new ItemList();
            items.items = itemList;

            // Create payment
            var payment = PayPal.Api.Payment.Create(apiContext, new PayPal.Api.Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal",
                    payer_info = new PayerInfo()
                    {
                        email = email,
                        first_name = userName,
                        last_name = ""
                    }
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "MedResearch Ninja Membership Payment",
                        invoice_number = orderId,
                        amount = new Amount
                        {
                            currency = "USD", // Change to your preferred currency
                            total = totalAmount,
                            details = new Details
                            {
                                subtotal = totalAmount
                            }
                        },
                        item_list = items
                    }
                },
                redirect_urls = new RedirectUrls
                {
                    return_url = domain + "paypal-status.aspx?o=" + orderGuid,
                    cancel_url = domain + "paypal-failed.aspx?o=" + orderGuid
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
            // Ignore ThreadAbortException - it's expected with Response.Redirect
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InitializePayPalPayment", ex.Message);
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
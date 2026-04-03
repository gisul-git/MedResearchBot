
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PayUAPI
/// </summary>
public class PayUAPI
{
    /// <summary>
    /// Creates a payment request to the PayU API by sending the necessary parameters.
    /// Generates a secure hash and submits an HTTP POST request to the PayU endpoint.
    /// </summary>
    /// <param name="details">An object containing the payment details like amount, customer info, and transaction ID.</param>
    /// <returns>
    /// A <see cref="PayUAPIResponse"/> object containing the response from the PayU API. 
    /// Returns null if an exception occurs.
    /// </returns>
    public static APIResponse<string> CreatePayment(PayUAPIRequest details)
    {
        try
        {
            // Fetch configuration values: SALT key, API key, and endpoint URL.
            var salt = ConfigurationManager.AppSettings["SALTKey"].ToString();
            details.Key = ConfigurationManager.AppSettings["KeyID"].ToString();
            var EndPoint = ConfigurationManager.AppSettings["ENVURL"].ToString();

            // Generate the secure hash for the payment request using the provided details and salt.
            // var hash = GenerateHash(details, salt);

            // Initialize RestSharp's RestClient with the API endpoint URL.
            var client = new RestClient(EndPoint);

            // Configure the REST request to the PayU payment API with POST method.
            var request = new RestRequest("/_payment", Method.POST);

            // Add headers to the request for proper content and format handling.
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("accept", "text/plain");

            // Add required payment parameters to the request body.
            request.AddParameter("key", details.Key);
            request.AddParameter("surl", details.Surl);                // Success URL
            request.AddParameter("furl", details.Furl);                // Failure URL
            request.AddParameter("amount", details.Amount);            // Payment amount
            request.AddParameter("productinfo", details.ProductInfo);  // Product details
            request.AddParameter("firstname", details.FirstName);      // User's first name
            request.AddParameter("email", details.Email);              // User's email
            request.AddParameter("phone", details.Phone);              // User's phone number
            request.AddParameter("address1", details.Address1);        // Address line 1
            request.AddParameter("address2", details.Address2);        // Address line 2
            request.AddParameter("city", details.City);                // City
            request.AddParameter("state", details.State);              // State
            request.AddParameter("country", details.Country);          // Country
            request.AddParameter("zipcode", details.Zipcode);          // Postal code
            request.AddParameter("lastname", details.LastName);        // User's last name
            request.AddParameter("api_version", "7");                  // API Version
            request.AddParameter("hash", details.Hash);                        // Security hash
            request.AddParameter("txnid", details.Txnid);              // Transaction ID

            // Ensure security protocols for the request.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Execute the API request and capture the response.
            IRestResponse response = client.Execute(request);

            // Deserialize the API response content into the PayUAPIResponse object.
            var res = JsonConvert.DeserializeObject<APIResponse<string>>(response.Content);

            // Return the API response to the caller.
            return res;
        }
        catch (Exception ex)
        {
            // Log any exceptions for debugging and tracking purposes.
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatePayment", ex.Message);
        }

        // Return null if an exception occurs.
        return null;
    }

    public static VerifyPaymentResponse VerifyPayment(string Oid)
    {
        try
        {
            // Fetch configuration values: SALT key, API key, and endpoint URL.
            var salt = ConfigurationManager.AppSettings["SALTKey"].ToString();
            var Key = ConfigurationManager.AppSettings["KeyID"].ToString();
            var EndPoint = "https://secure.payu.in/";
           //  var EndPoint = "https://test.payu.in/";
            //ConfigurationManager.AppSettings["ENVURL"].ToString();

            var hash = GenerateVerifyHash(Key, "verify_payment", Oid, salt);
            var client = new RestClient(EndPoint);
            var request = new RestRequest("/merchant/postservice?form=2", Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("key", Key);
            request.AddParameter("command", "verify_payment");
            request.AddParameter("var1", Oid);
            request.AddParameter("hash", hash);
            // Ensure security protocols for the request.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Execute the API request and capture the response.
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<VerifyPaymentResponse>(response.Content);
            return res;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "VerifyPayment", ex.Message);

        }
        return null;
    }

    public static string GenerateVerifyHash(string key, string command, string Oid, string salt)
    {
        //string input = "{key}|{txnid}|{amount}|{productinfo}|{firstname}|{email}|||||||||||{salt}";
        var hashString = key + "|" + command + "|" + Oid + "|" + salt;
        return Sha512(hashString);
    }
    public static string GenerateHash(PayUAPIRequest details, string salt)
    {
        //string input = "{key}|{txnid}|{amount}|{productinfo}|{firstname}|{email}|||||||||||{salt}";
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


    /// <summary>
    /// Generates a secure SHA-512 hash required for the PayU payment request.
    /// Combines the key, transaction ID, amount, product info, customer details, and salt in the required format.
    /// </summary>
    /// <param name="details">An object containing payment details like key, transaction ID, amount, and customer info.</param>
    /// <param name="salt">The secret salt key for hash generation.</param>
    /// <returns>
    /// A string representing the generated SHA-512 hash in hexadecimal format. 
    /// Returns null if an exception occurs.
    /// </returns>
    public static string GenerateHashOld(PayUAPIRequest details, string salt)
    {
        try
        {
            // Construct the hash string using the specified format required by PayU.
            // Format: key|txnid|amount|productinfo|firstname|email||||||salt
            var hashString = details.Key + "|" + details.Txnid + "|" + details.Amount + "|" +
                             details.ProductInfo + "|" + details.FirstName + "|" + details.Email +
                             "||||||" + salt;

            // Use SHA-512 cryptographic algorithm to create the hash.
            using (SHA512 sha512 = SHA512.Create())
            {
                // Convert the hash string to a byte array using UTF-8 encoding.
                byte[] inputBytes = Encoding.UTF8.GetBytes(hashString);

                // Compute the hash of the input bytes.
                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                // Convert the resulting hash bytes into a hexadecimal string representation.
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2")); // Convert each byte to a two-digit hex value.
                }

                string converted = hashStringBuilder.ToString();

                // Return the computed hash as a string.
                return converted;

            }
        }
        catch (Exception ex)
        {
            // Log any exceptions for debugging and tracking purposes.
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GenerateHash", ex.Message);
        }

        // Return null if an exception occurs.
        return null;
    }
}

public class APIResponse<T>
{
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; }
    public T Data { get; set; }
}
public class PayUAPIRequest
{
    public string Key { get; set; }
    public string Surl { get; set; }
    public string Furl { get; set; }
    public double Amount { get; set; }
    public string ProductInfo { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Zipcode { get; set; }
    public string LastName { get; set; }
    public string Hash { get; set; }
    public string Txnid { get; set; }
}
public class PayUAPIResponse
{
    public string mihpayid { get; set; }
    public string mode { get; set; }
    public string bankcode { get; set; }
    public string status { get; set; }
    public string unmappedstatus { get; set; }
    public string key { get; set; }
    public string error { get; set; }
    public string error_message { get; set; }
    public string bank_ref_num { get; set; }
    public string txnid { get; set; }
    public string amount { get; set; }
    public string cardCategory { get; set; }
    public string discount { get; set; }
    public string net_amount_debit { get; set; }
    public DateTime addedon { get; set; }
    public string productinfo { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string hash { get; set; }
    public string PG_TYPE { get; set; }
    public string success_at { get; set; }
    public string cardnum { get; set; }
    public string issuing_bank { get; set; }
}


public class VerifyPaymentResponse
{
    public string Status { get; set; }
    public string Msg { get; set; }
    public Dictionary<string, TransactionDetails> Transaction_Details { get; set; }
}

public class TransactionDetails
{
    public string Mihpayid { get; set; }
    public string RequestId { get; set; }
    public string BankRefNum { get; set; }
    public string Amt { get; set; }
    public string TransactionAmount { get; set; }
    public string Txnid { get; set; }
    public string AdditionalCharges { get; set; }
    public string Productinfo { get; set; }
    public string Firstname { get; set; }
    public string Bankcode { get; set; }
    public string Udf1 { get; set; }
    public string Udf2 { get; set; }
    public string Udf3 { get; set; }
    public string Udf4 { get; set; }
    public string Udf5 { get; set; }
    public string Field2 { get; set; }
    public string Field9 { get; set; }
    public string ErrorCode { get; set; }
    public string Addedon { get; set; }
    public string PaymentSource { get; set; }
    public string CardType { get; set; }
    public string ErrorMessage { get; set; }
    public decimal NetAmountDebit { get; set; }
    public string Disc { get; set; }
    public string Mode { get; set; }
    public string PGType { get; set; }
    public string CardNo { get; set; }
    public string Status { get; set; }
    public string Unmappedstatus { get; set; }
    public string MerchantUtr { get; set; }
    public string SettledAt { get; set; }
    public string CardToken { get; set; }
    public string OfferAvailed { get; set; }
}

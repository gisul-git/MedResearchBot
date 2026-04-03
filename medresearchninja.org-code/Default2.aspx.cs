using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{

    public string strKey = "JPM7FG"; 
    public string strTRid = "MEDORD0089"; 
    public string strPInfo = "New Membership"; 
    public string strAmount = "850"; 
    public string strEmail = "nwiuser1+ele@outlook.com"; 
    public string strFName = "Bharat"; 
    public string strLname = "lal saw"; 
    public string strSUrl = "https://host874.nextwebi.com/payment-success.aspx"; 
    public string strFUrl = "https://host874.nextwebi.com/payment-failed.aspx"; 
    public string strPhone = "7999456901"; 
    public string strHash = "";  

    protected void Page_Load(object sender, EventArgs e)
    {
        PayUAPIRequest details = new PayUAPIRequest();
        details.Key = strKey;
        details.Txnid = strTRid;
        details.Amount = Convert.ToDouble( strAmount);
        details.ProductInfo = strPInfo;
        details.FirstName = strFName;
        details.Email = strEmail;
        string salt = "TuxqAugd";
        strHash = GenerateHash(details, salt);
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


}
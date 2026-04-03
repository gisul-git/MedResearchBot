using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class CommonModel
{
    public static string IPAddress()
    {
        string ipadd = "";
        try
        {
            String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {

                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                string ipStr = ip.Replace("::ffff:", "");
                ip = ipStr;
            }
            ipadd = ip;
        }
        catch (Exception ex)
        {

        }
        return ipadd;
    }

    public static string GetCountryFromIP()
    {
        string Country = "";
        try
        {
            string ipaddr = IPAddress();
            HttpWebRequest objreq = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ipaddr);
            HttpWebResponse objres = (HttpWebResponse)objreq.GetResponse();
            StreamReader resreader = new StreamReader(objres.GetResponseStream());
            string responseread = resreader.ReadToEnd();
            resreader.Close();
            resreader.Dispose();
            dynamic dynObj = JsonConvert.DeserializeObject(responseread);
            if (dynObj.country != null)
            {
                Country = dynObj.country;
            }
        }
        catch (Exception ex)
        {
        }
        return Country;
    }
    public static string GetCityFromIP()
    {
        string city = "";
        try
        {
            // Retrieve the client's IP address.
            string ipaddr = IPAddress();

            // Make a request to the IP-API service for the JSON response.
            HttpWebRequest objreq = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ipaddr);
            HttpWebResponse objres = (HttpWebResponse)objreq.GetResponse();

            // Read the response stream.
            using (StreamReader resreader = new StreamReader(objres.GetResponseStream()))
            {
                string responseread = resreader.ReadToEnd();

                // Deserialize the JSON response to a dynamic object.
                dynamic dynObj = JsonConvert.DeserializeObject(responseread);

                // Check if the 'city' property exists in the response and assign it to the result.
                if (dynObj.city != null)
                {
                    city = dynObj.city;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions silently or log them as necessary.
        }

        // Return the city name or an empty string if unavailable.
        return city;
    }
    public static string GetStateFromIP()
    {
        string state = "";
        try
        {
            // Retrieve the client's IP address.
            string ipaddr = IPAddress();

            // Make a request to the IP-API service for the JSON response.
            HttpWebRequest objreq = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ipaddr);
            HttpWebResponse objres = (HttpWebResponse)objreq.GetResponse();

            // Read the response stream.
            using (StreamReader resreader = new StreamReader(objres.GetResponseStream()))
            {
                string responseread = resreader.ReadToEnd();

                // Deserialize the JSON response to a dynamic object.
                dynamic dynObj = JsonConvert.DeserializeObject(responseread);

                // Check if the 'city' property exists in the response and assign it to the result.
                if (dynObj.regionName != null)
                {
                    state = dynObj.regionName;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions silently or log them as necessary.
        }

        // Return the city name or an empty string if unavailable.
        return state;
    }


    public static void SaveJpeg(string path, System.Drawing.Image img, int quality)
    {
        if (quality < 0 || quality > 100)
            throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

        // Encoder parameter for image quality 
        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        // JPEG image codec 
        ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        //img.Width = 800;
        img.Save(path, jpegCodec, encoderParams);
    }

    public static void SavePNG(string path, System.Drawing.Image img, int quality)
    {
        if (quality < 0 || quality > 100)
            throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

        // Encoder parameter for image quality 
        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        // JPEG image codec 
        ImageCodecInfo jpegCodec = GetEncoderInfo("image/png");
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;

        //img.Width = 800;
        img.Save(path, jpegCodec, encoderParams);
    }
    public static System.Drawing.Image ScaleImageBig(System.Drawing.Image image, int height, int width)
    {
        var newImage = new Bitmap(width, height);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, width, height);
        }
        return newImage;
    }

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats 
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        // Find the correct image codec 
        for (int i = 0; i < codecs.Length; i++)
            if (codecs[i].MimeType == mimeType)
                return codecs[i];

        return null;
    }

    public static string Encrypt(string clearText)
    {
        string EncryptionKey = "MEDNINJA15431234567890$% ^&*MYQ";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public static string Decrypt(string cipherText)
    {
        string EncryptionKey = "MEDNINJA15431234567890$% ^&*MYQ";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    public static void ReassignCurrencyCookie(string val)
    {
        if (HttpContext.Current.Request.Cookies["ary_ctry"] == null)
        {
            HttpCookie cookie = new HttpCookie("ary_ctry");
            cookie.Value = val;
            cookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        else
        {
            var cookie = HttpContext.Current.Response.Cookies["ary_ctry"];
            cookie.Value = val;
            cookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }

    public static void AddRecentProductCookie(string cid, string pdid)
    {
        try
        {
            if (HttpContext.Current.Request.Cookies["ary_rv"] == null)
            {
                HttpCookie rv = new HttpCookie("ary_rv");
                rv.Value = CommonModel.Encrypt(pdid);
                rv.Expires = TimeStamps.UTCTime().AddDays(10);
                HttpContext.Current.Response.Cookies.Add(rv);
            }
            else
            {
                string actval = CommonModel.Decrypt(HttpContext.Current.Request.Cookies["ary_rv"].Value);
                List<string> val = actval.Split(',').ToList();
                string exist = val.Where(s => s == pdid).SingleOrDefault();
                if (val.Count > 9)
                {
                    HttpCookie rv = new HttpCookie("ary_rv");
                    if (exist == null)
                    {
                        val.RemoveAt(val.Count - 1);
                        val.Reverse();
                        val.Add(pdid);
                        val.Reverse();
                    }
                    string retval = "";
                    foreach (var lp in val)
                    {
                        retval += lp + ",";
                    }
                    rv.Value = CommonModel.Encrypt(retval.Substring(0, retval.Length - 1));
                    rv.Expires = TimeStamps.UTCTime().AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(rv);
                }
                else
                {
                    HttpCookie rv = new HttpCookie("ary_rv");
                    if (exist == null)
                    {
                        actval = pdid + "," + actval;
                    }
                    rv.Value = CommonModel.Encrypt(actval);
                    rv.Expires = TimeStamps.UTCTime().AddDays(10);
                    HttpContext.Current.Response.Cookies.Add(rv);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddRecentProduct", ex.Message);
        }
    }

    public static string urlval(string url)
    {
        string[] strArr = url.Split('-');
        string resulturl = string.Empty;
        for (int i = 0; i < strArr.Length; i++)
        {
            if (resulturl == "")
            {
                resulturl = strArr[i];
            }
            else
            {
                resulturl = resulturl + " " + strArr[i];
            }
        }
        return resulturl;
    }

    public static string seourl(string url)
    {
        string[] strArr = url.Split(' ');
        string resulturl = string.Empty;
        for (int i = 0; i < strArr.Length; i++)
        {
            if (resulturl == "")
            {
                resulturl = strArr[i];
            }
            else
            {
                resulturl = resulturl + "-" + strArr[i];
            }
        }
        return resulturl;
    }

    public static string GenerateURLByString(string URLParamenter)
    {
        string result = "";
        try
        {
            result = URLParamenter.ToLower()
                .Replace(".", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("\"", "")
                .Replace("'", "")
                .Replace("&", "and")
                .Replace("*", "-")
                .Replace("%", "-")
                .Replace("@", "-")
                .Replace("~", "-")
                .Replace("`", "-")
                .Replace("!", "-")
                .Replace(",", "-")
                .Replace("#", "-")
                .Replace("$", "-")
                .Replace("?", "-")
                .Replace("(", "-")
                .Replace(")", "-")
                .Replace("=", "-")
                .Replace("[", "-")
                .Replace("]", "-")
                .Replace(":", "-")
                .Replace(";", "-")
                .Replace("|", "-")
                .Replace("+", "-")
                .Replace(" ", "-")
                .ToLower()
                .Trim(); // Removes leading and trailing spaces
        }
        catch (Exception ex)
        {
        }
        return result;
    }

    public static string GetCountryByIP(string ipAddress)
    {
        try
        {
            if (ipAddress == "::1" || ipAddress == "127.0.0.1" || ipAddress.StartsWith("192.168."))
            {
                return "IN";
            }

            string url = "http://ip-api.com/json/" + ipAddress;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 5000;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                JObject data = JObject.Parse(json);

                if (data["status"].ToString() == "success")
                {
                    return data["countryCode"].ToString();
                    //return "US";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException("CountryHelper", "GetCountryByIP", ex.Message);
        }
        return "IN";
    }

    public static string GetUserIPAddress()
    {
        string ipAddress = string.Empty;

        try
        {
            ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (!string.IsNullOrEmpty(ipAddress) && ipAddress.Contains(","))
            {
                ipAddress = ipAddress.Split(',')[0].Trim();
            }
        }
        catch
        {
            ipAddress = "127.0.0.1";
        }

        return ipAddress;
    }

    public static bool IsIndianUser(string countryCode)
    {
        return countryCode.Equals("IN", StringComparison.OrdinalIgnoreCase);
    }

}

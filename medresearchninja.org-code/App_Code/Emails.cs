using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;

public class Emails
{
    public static async Task<int> SendPasswordRestLink(string name, string emails, string link)
    {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(emails);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Med Research Ninja Admin  Reset Password";
            mail.Body = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Med Research Ninja </title>
    <link rel='shortcut icon' href='https://www.Vision360 /images/Nextwebi-sq_Black_Logo2_1_140x.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>

                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px;background:#fff'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;width: 100%;margin-right:5%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' style='vertical-align: middle;' class='flexibleContainerCell'>
                                                                                <center>
                                                                                    <img style='width:110px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/logo.png' />
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:0px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <p style='font-size:22px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#cd6c73;padding:10px;'>PASSWORD RESET</p>
                                                                                <p style='font-size:20px;line-height:28px!important;text-align:center;color:#000;font-weight:bold!important'>Request for password reset</p>
                                                                                <p style='font-size:15px;color:#000;line-height:22px!important;margin-bottom:5px;text-align:center;padding:0px 20px !important'>Hello " + name + @". We have just received a request to reset your password for the Med Research Ninja account.<br><br></p>


                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px 60px;background:#fff;text-align: center;'>
                                                                    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top:0px;color:#573e40;margin-bottom:30px;'>If you have made this request, please click on the following link to reset your password</p>
                                                                   <a href='" + link + @"' style='padding: 10px 30px;background: #e7757f;text-decoration: none;color: #fff;font-size: 20px;'>Reset Password</a>
                                                                    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top: 20px;color:#573e40;margin-bottom:30px;'>
                                                                        If clicking the button does not work, copy the URL below and paste it into your browser:<br><a href='" + link + @"'>" + link + @"</a>
                                                                        <br><br>If you have not requested a password reset, please ignore this email.<br>
                                                                        Your password remains unchanged.
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px 20px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='center' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <ul style='list-style:none;width:400px;margin:0px auto;'>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.facebook.com/pages/category/Brand/Med Research Ninja -1404212866358535/' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/facebook.png' /></a>
                                                                                    </li>
                                                                                   
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.instagram.com/Med Research Ninja lifestyles/?hl=en' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/instagram.png' /></a>
                                                                                    </li>
                                                                                   
                                                                                </ul>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new System.Net.NetworkCredential
                           (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);

            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(() => smtp.Send(mail));
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendPasswordRestLink", ex.Message);
            return 0;
        }
    }
    public static async Task<int> SendEmailVerifyLink(string email, string name, string strlink)
    {
        try
        {
            #region mailBody
            string mailBody1 = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Med Research Ninja </title>
    <link rel='shortcut icon' href='https://www.Med Research Ninja /images/Nextwebi-sq_Black_Logo2_1_140x.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
                    
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'> 
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'> 
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px;background:#fff'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;width: 100%;margin-right:5%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' style='vertical-align: middle;' class='flexibleContainerCell'>
                                                                                <center>
                                                                                    <img style='width:110px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/logo(1).webp' />
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
<tr>
                                                                <td align='left' valign='top' style='padding:0px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <p style='font-size:22px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#cd6c73;padding:10px;'>VERIFY EMAIL</p>
                                                                                <p style='font-size:20px;line-height:28px!important;text-align:center;color:#000;font-weight:bold!important'>Request for account verification</p>
                                                                                <p style='font-size:15px;color:#000;line-height:22px!important;margin-bottom:5px;text-align:center;padding:0px 20px !important'>Hello " + name + @", You have successfully registered. Please click on the link below for verification.<br><br></p>


                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr> 
                                                            <tr>
                                                               <td align='left' valign='top' style='padding:20px 60px;background:#fff;text-align: center;'> 
<a href='" + strlink + @"' style='padding: 10px 30px;background: #e7757f;text-decoration: none;color: #fff;font-size: 20px;'>Verify Email</a>
    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top: 20px;color:#573e40;margin-bottom:30px;'>If clicking the button does not work, copy the URL below and paste it into your browser:<br>" + strlink + @"<br><br></p></td><tr>
                                                                <td align='left' valign='top' style='padding:20px 20px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='center' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <ul style='list-style:none;width:400px;margin:0px auto;'>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.facebook.com/pages/category/Brand/MedResearchNinja-1404212866358535/' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/facebook.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.youtube.com/channel/UCs3BrrlAc5K93z3jrlYVJZw' target='_blank'> <img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/youtube.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.instagram.com/MedResearchNinja lifestyles/?hl=en' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/instagram.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:0px;'>
                                                                                        <a href='https://twitter.com/MedResearchNinja Retail' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/twitter.png' /></a>
                                                                                    </li>
                                                                                </ul>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";


            #endregion
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Med Research Ninja  Account verification";
            mail.Body = mailBody1;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new System.Net.NetworkCredential
                           (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(() => smtp.Send(mail));
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendEmailVerifyLink", ex.Message);
            return 0;
        }
    }
    public static async Task<int> SendPasswordReset(string name, string email, string custId)
    {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);

            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], "Med Research Ninja  Password Reset");
            mail.Subject = "Request for password reset";

            #region mailBody
            string mailBody1 = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Med Research Ninja </title>
    <link rel='shortcut icon' href='https://www.MedResearchNinja/images/Nextwebi-sq_Black_Logo2_1_140x.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
                    
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'> 
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'> 
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px;background:#fff'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;width: 100%;margin-right:5%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' style='vertical-align: middle;' class='flexibleContainerCell'>
                                                                                <center>
                                                                                    <img style='width:110px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/logo(1).webp' />
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                    </table> 
                                                                </td>
                                                            </tr> 
                                                            <tr><td align='left' valign='top' style='padding:0px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <p style='font-size:22px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#cd6c73;padding:10px;'>PASSWORD RESET</p>
                                                                                <p style='font-size:20px;line-height:28px!important;text-align:center;color:#000;font-weight:bold!important'>Request for password reset!</p>
                                                                                <p style='font-size:14px;color:#000;line-height:22px!important;margin-bottom:5px;text-align:center;padding:0px 20px !important'>Hello " + name + @", <br>We have just received a request to reset your password for the Med Research Ninja  account.</p>
                                                                                <p style='font-size:14px;color:#000;line-height:22px!important;margin-bottom:5px;text-align:center;padding:0px 20px !important'>If you have made this request, please click on the following link to reset your password.</p>
                                                                                <p style='margin-bottom:30px;'><center> <a href='" + ConfigurationManager.AppSettings["domain"] + @"/reset-password.aspx?c=" + custId + @"' target='_blank' style='font-size:26px;line-height:32px!important;text-decoration:none; text-align:center;color:white;margin-top:0px;background:#cd6c73;padding:10px 25px;width:50%;margin:0px auto'>Reset Password</a></center></p>
            

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td> 
                                                            </tr> 
                                                            <tr>
                                                               <td align='left' valign='top' style='padding:20px 60px;background:#fff;text-align: center;'> 
    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top: 20px;color:#573e40;margin-bottom:30px;'>If clicking the button does not work, copy the URL below and paste it into your browser:<br>" + ConfigurationManager.AppSettings["domain"] + @"/reset-password.aspx?c=" + custId + @"<br><br>If you have not requested a password reset, please ignore this email.<br>
Your password remains unchanged.</p></td> </tr> <tr>
                                                                 <td align='left' valign='top' style='padding:20px 20px;background:#ffa8ae29'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='center' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <ul style='list-style:none;width:400px;margin:0px auto;'>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.facebook.com/pages/category/Brand/Med Research Ninja -1404212866358535/' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/facebook.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.youtube.com/channel/UCs3BrrlAc5K93z3jrlYVJZw' target='_blank'> <img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/youtube.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.instagram.com/Med Research Ninja lifestyles/?hl=en' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/instagram.png' /></a>
                                                                                    </li>
                                                                                    <li style='display:inline-block;margin-right:0px;'>
                                                                                        <a href='https://twitter.com/Med Research Ninja Retail' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/img/email-icons/twitter.png' /></a>
                                                                                    </li>
                                                                                </ul>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr> 
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";


            #endregion

            mail.Body = mailBody1;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();


            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new System.Net.NetworkCredential
                   (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);

            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(() => smtp.Send(mail));
            return 1;
        }
        catch (Exception exx)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendPasswordReset", exx.Message);
            return 0;
        }
    }
    public static int SendContactRequest(ContactUs con)
    {
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["CCMail"]))
            {
                mail.CC.Add(ConfigurationManager.AppSettings["CCMail"]);
            }
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Contact Request - MedResearchNinja";
            mail.Body = "Hi Admin, <br><br>You have received a contact request from " + con.Fullname + ".<br><br><u><b><i>Details : </i></b></u><br>Name : " + con.Fullname + "<br>EmailAdress : " + con.EmailAdress + "<br>Phone : " + con.Phone + "<br>Message :" + con.Message + "<br>Pageurl:<a href='" + con.pageurl + "'> " + con.pageurl + @"</a><br><br>Regards,<br>MedResearchNinja";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new System.Net.NetworkCredential
            (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "SendContactRequest", ex.Message);
            return 0;

        }

    }
    public static async Task<int> BookingConfirmedNew(string name, string email, string paidAmount, string ReceiptNo, string prjectName, string oid)
    {
        try
        {
            string mailBody = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Divoura</title>
    <link rel='shortcut icon' href='" + ConfigurationManager.AppSettings["domain"] + @"/assets/images/logo.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }
        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {         text-decoration: none !important;border-bottom: 1px solid;     }*/ h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'], table[id='emailBody'], table[id='emailFooter'], table[class='flexibleContainer'], td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>

                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:10px;background:#fcfcfc'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;float: left; margin-right: 0; width: 100%;'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <center><img style='height:90px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/Admin/assets/images/logo.png' /></center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                    <p style='font-size:22px;line-height:28px!important;text-align:center;color:#573e40;font-weight:bold!important'>
                                                                        Thank You for your order!
                                                                    </p>
                                                                    <p style='font-size:18px;color:#573e40;line-height:22px!important;margin-bottom:30px;text-align:left;padding:0px 50px;'>
                                                                        Hey " + name + @"
                                                                    </p>
                                                                    <p style='font-size:13px;line-height:25px!important;text-align:left;margin-top:0px;color:#573e40;margin-bottom:30px;padding:0px 50px;'>
                                                                        You’re awesome! Thank you so much for choosing to order from " + ConfigurationManager.AppSettings["domain"] + @"
                                                                        . If you have any queries about your order contact us at Projects@MedResearchNinja.com or by visiting our contact us page
                                                                    </p>
                                                                    <p style='font-size:26px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#FF9212;padding:10px;width:50%;margin:0px auto;margin-bottom:0px'>Order Number: " + ReceiptNo + @"</p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px 60px 20px 60px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='float:left;width:100%' class='flexibleContainerCell'>
                                                                    <p style='text-align:left;font-weight:600!important;margin-bottom:20px !important;font-size:16px;'>Stuff You Picked: </p>
                                                                </td>
                                                            </tr>
<h3>Project Name: " + prjectName + @" </h3>
<h3>Total Amount: " + paidAmount + @" </h3>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='left' valign='top' style='padding:10px 20px;background:#f2f2f2'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                <tr>
                                                                               <td align='center' valign='middle' width='100%' class='flexibleContainerCell'>
                                                                                    <ul style='list-style:none;width:390px;margin:0px auto;'>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.facebook.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/facebook.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.instagram.com//' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/instagram.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://twitter.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/twitter.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.youtube.com/c/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/youtube.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:0px;padding-right:5px;'>
                                                                                            <a href='mailto:hello@divoura.com' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/mail.png' /></a>
                                                                                        </li>

                                                                                    </ul>
                                                                                </td>

                                                                            </tr> 
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "MedResearchNinja project Order Confirmation";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(delegate
            {
                smtp.Send(mail);
            });
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "BookingConfirmedNew", ex.Message);

            return 0;
        }
    }
    public static int NewMembershipMail(string name, string email, string pwd, string Whastapplink)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                        <head>
                                            <meta charset='UTF-8'>
                                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                            <title>Welcome to MedResearch Ninja</title>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                background-color: #f7f7f7;
                                                margin: 0;
                                                padding: 0;
                                            }
                                            .container {
                                                max-width: 700px;
                                                margin: 20px auto;
                                                background: #ffffff;
                                                border-radius: 10px;
                                                padding: 20px;
                                                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                                            }
                                            h1 {
                                                color: #333333;
                                                font-size: 24px;
                                                text-align: center;
                                            }
                                            p {
                                                font-size: 16px;
                                                color: #555555;
                                                line-height: 1.6;
                                            }
                                            .cta-link {
                                                color: #1e90ff;
                                                text-decoration: none;
                                                font-weight: bold;
                                            }
                                            .credentials {
                                                background-color: #f9f9f9;
                                                padding: 15px;
                                                border: 1px solid #dddddd;
                                                border-radius: 8px;
                                                margin: 20px 0;
                                            }
                                            .credentials p {
                                                margin: 0 0 10px;
                                            }
                                            .features {
                                                list-style: none;
                                                padding: 0;
                                                margin: 20px 0;
                                            }
                                            .features li {
                                                padding: 10px 0;
                                                border-bottom: 1px solid #eeeeee;
                                                font-size: 16px;
                                                color: #555555;
                                            }
                                            .features li:last-child {
                                                border-bottom: none;
                                            }
                                            .button {
                                                display: inline-block;
                                                background-color: #1e90ff;
                                                color: white;
                                                padding: 10px 20px;
                                                border-radius: 5px;
                                                text-decoration: none;
                                                font-weight: bold;
                                            }
                                            .footer {
                                                font-size: 14px;
                                                color: #888888;
                                                text-align: center;
                                                margin-top: 20px;
                                            }
                                            .footer a {
                                                color: #1e90ff;
                                                text-decoration: none;
                                            }
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <div style='text-align: center;'><img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>
                                        <h1>Welcome to MedResearch Ninja!</h1>
                                            <p>Dear " + name + @",</p>
                                            <p>Welcome to <strong>MedResearch Ninja</strong>! We’re thrilled to have you as part of our growing community of researchers.</p>
                                            <p><a href='https://www.medresearchninja.org' class='cta-link'>Access the website here</a></p>
                                            <div class='credentials'>
                                                <p><strong>Your Login Credentials:</strong></p>
                                                <p><strong>Login URL:</strong> <a href='https://www.medresearchninja.org/login.aspx' class='cta-link'>https://www.medresearchninja.org/login.aspx</a></p>
                                                <p><strong>Username:</strong> " + email + @"</p>
                                                <p><strong>Password:</strong>" + pwd + @"</p>
                                                <p style='color: #ff4500;'>Please update your password after logging in for security purposes.</p>
                                            </div>
                                            <p><strong>Key Features to Explore:</strong></p>
                                            <ul class='features'>
                                                <li>Submit Research Snapshot Articles (Free!) – Share your insights and gain global visibility.</li>
                                                <li>Join Discussions – Exchange ideas and seek expert opinions.</li>
                                                <li>Access Premium Modules – Unlock advanced tools for research and data analysis.</li>
                                                <li>Enroll in Research Projects – Collaborate with experts and expand your portfolio.</li>
                                                <li>Share Research Ideas and Cases – Get valuable feedback and bring your concepts to life.</li>
                                            </ul>
                                            <p><strong>Join Our WhatsApp Group:</strong></p>
                                            <p>Stay connected with our community:</p>
                                            <p><a href='" + Whastapplink + @"' class='button'>Join WhatsApp Group</a></p>
        
                                            <p><strong>Next Steps:</strong></p>
                                            <ul class='features'>
                                                <li>Log in to the website.</li>
                                                <li>Join the WhatsApp group.</li>
                                                <li>Start exploring and connecting with fellow researchers!</li>
                                            </ul>
                                            <p>If you need assistance, feel free to contact us at <a href='mailto:connect@medresearchninja.org' class='cta-link'>connect@medresearchninja.org</a>.</p>
                                            <p>We’re thrilled to have you on board!</p>
                                            <p>Best regards,<br>The MedResearch Ninja Team</p>
                                            <div class='footer'>
                                                <p>© " + DateTime.UtcNow.Year + @" MedResearch Ninja. All rights reserved.</p>
                                            </div>
                                        </div>
                                    </body>
                                </html>";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Welcome to MedResearch Ninja – Let’s Get Started!";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewMembershipMail", ex.Message);

            return 0;
        }
    }
    public static int NewMembershipMailAdmin(string name, string email)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                        <title>New User Joined – Admin Notification</title>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                background-color: #f4f4f4;
                                                margin: 0;
                                                padding: 0;
                                            }
                                            .container {
                                                max-width: 700px;
                                                margin: 20px auto;
                                                background: #ffffff;
                                                padding: 20px;
                                                border-radius: 8px;
                                                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                                            }
                                            h1 {
                                                font-size: 20px;
                                                color: #333333;
                                                text-align: center;
                                                margin-bottom: 20px;
                                            }
                                            p {
                                                font-size: 16px;
                                                color: #555555;
                                                line-height: 1.6;
                                            }
                                            .details, .actions, .features {
                                                background-color: #f9f9f9;
                                                padding: 15px;
                                                border: 1px solid #dddddd;
                                                border-radius: 8px;
                                                margin-bottom: 20px;
                                            }
                                            ul {
                                                list-style: none;
                                                padding: 0;
                                            }
                                            ul li {
                                                padding: 10px 0;
                                                border-bottom: 1px solid #eeeeee;
                                            }
                                            ul li:last-child {
                                                border-bottom: none;
                                            }
                                            a {
                                                color: #1e90ff;
                                                text-decoration: none;
                                                font-weight: bold;
                                            }
                                            .footer {
                                                text-align: center;
                                                font-size: 14px;
                                                color: #888888;
                                                margin-top: 20px;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>
                                        <div style='text-align: center;'><img src='https://www.medresearchninja.org/Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>

                                            <h1>New User Joined MedResearch Ninja – Admin Notification</h1>
                                            <p>Dear Admin,</p>
                                            <p>We’re excited to inform you that a new user has joined <strong>MedResearch Ninja</strong>! Below are the details of the new member:</p>

                                            <div class='details'>
                                                <p><strong>User Details:</strong></p>
                                                <ul>
                                                    <li><strong>Name:</strong> " + name + @"</li>
                                                    <li><strong>Email Address:</strong> " + email + @"</li>
                                                    <li><strong>Date of Joining:</strong> " + DateTime.UtcNow.ToString("dd MMM yyyy") + @"</li>
                                                </ul>
                                            </div>
                                            <p>For additional information about the new member, please refer to the administration panel.</p>
                                            <p>Thank you for keeping our community vibrant and welcoming!</p>
                                            <p>Best regards,<br><strong>The MedResearch Ninja Team</strong></p>

                                            <div class='footer'>
                                                <p>© " + DateTime.UtcNow.ToString("yyyy") + @" MedResearch Ninja. All rights reserved. <a href='https://www.medresearchninja.org'>Visit Website</a></p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "New User Joined MedResearch Ninja – Admin Notification";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewMembershipMailAdmin", ex.Message);

            return 0;
        }
    }
    public static int ExistingMembershipMail(string name, string email, string pwd, string Whastapplink)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                        <html>
                                        <head>
                                            <title>Welcome to Med Research Ninja</title>
                                            <style>
                                                body {
                                                    font-family: Arial, sans-serif;
                                                    line-height: 1.6;
                                                    margin: 0;
                                                    padding: 0;
                                                    background-color: #f9f9f9;
                                                }
                                                .email-container {
                                                    max-width: 700px;
                                                    margin: 20px auto;
                                                    padding: 20px;
                                                    background-color: #ffffff;
                                                    border: 1px solid #dddddd;
                                                    border-radius: 8px;
                                                    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                                                }
                                                .email-header {
                                                    text-align: center;
                                                    margin-bottom: 20px;
                                                }
                                                .email-header h1 {
                                                    font-size: 24px;
                                                    color: #333333;
                                                }
                                                .email-content {
                                                    color: #555555;
                                                }
                                                .email-content h2 {
                                                    font-size: 20px;
                                                    color: #333333;
                                                    margin-top: 20px;
                                                }
                                                .email-content ul {
                                                    margin: 10px 0;
                                                    padding: 0 20px;
                                                    list-style-type: disc;
                                                }
                                                .cta-button {
                                                    display: inline-block;
                                                    margin: 20px 0;
                                                    padding: 10px 20px;
                                                    font-size: 16px;
                                                    color: #ffffff;
                                                    background-color: #007bff;
                                                    text-decoration: none;
                                                    border-radius: 5px;
                                                }
                                                .cta-button:hover {
                                                    background-color: #0056b3;
                                                }
                                                .footer {
                                                    font-size: 14px;
                                                    color: #777777;
                                                    text-align: center;
                                                    margin-top: 20px;
                                                }
                                            </style>
                                        </head>
                                        <body>
                                            <div class='email-container'>
                                                <div class='email-header'>

                                        <div style='text-align: center;'><img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>
                                                    <h1>Welcome to Our New Website – MedResearch Ninja!</h1>
                                                </div>
                                                <div class='email-content'=>
                                                    <p>Dear " + name + @",</p>
                                                    <p>We’re excited to introduce you to our brand-new website, MedResearch Ninja! Designed with you in mind, our platform offers an improved experience, seamless navigation, and enhanced features tailored to support your research journey.</p>
                                                    <p><strong>You can access the website at the link below:</strong></p>
                                                    <p><a href='https://www.medresearchninja.org/' class='cta-button'>Visit Med Research Ninja</a></p>
                                                    <p><strong>Your Login Credentials:</strong></p>
                                                    <ul>
                                                        <li><strong>Login URL:</strong> <a href='https://www.medresearchninja.org/login.aspx'>Med Research Ninja Login</a></li>
                                                        <li><strong>Username:</strong>" + email + @"</li>
                                                        <li><strong>Password:</strong> " + pwd + @"</li>
                                                    </ul>
                                                    <p>We recommend changing your password after logging in for the first time to ensure your account remains secure.</p>
        
                                                    <h2>Explore Our New Features:</h2>
                                                    <ul>
                                                        <li><strong>Submit Research Snapshot Articles to BlueprintRx – Free of Charge</strong>
                                                            <ul>
                                                                <li>Share your research insights quickly and effectively.</li>
                                                                <li>Gain visibility and contribute to the global research community.</li>
                                                                <li>Fast-track peer engagement and feedback on your work.</li>
                                                            </ul>
                                                        </li>
                                                        <li><strong>Engage in Our Discussion Forum</strong>
                                                            <ul>
                                                                <li>Post questions and exchange ideas with like-minded professionals.</li>
                                                                <li>Seek expert opinions and gain insights into trending topics.</li>
                                                                <li>Build valuable connections within our vibrant research community.</li>
                                                            </ul>
                                                        </li>
                                                        <li><strong>Access Premium Modules</strong>
                                                            <ul>
                                                                <li>Unlock exclusive tools and advanced resources tailored to enhance your research process.</li>
                                                                <li>Take advantage of high-performance modules designed for data analysis, visualization, and project management.</li>
                                                                <li>More innovative features are on the way—stay tuned for exciting updates!</li>
                                                            </ul>
                                                        </li>
                                                        <li><strong>Enroll in New Research Projects</strong>
                                                            <ul>
                                                                <li>Explore opportunities to join cutting-edge research initiatives.</li>
                                                                <li>Collaborate with experts across diverse fields.</li>
                                                                <li>Expand your portfolio and contribute to groundbreaking discoveries.</li>
                                                            </ul>
                                                        </li>
                                                        <li><strong>Submit New Research Ideas and Cases</strong>
                                                            <ul>
                                                                <li>Share your innovative research ideas and case studies directly through our platform.</li>
                                                                <li>Launch your ideas in the community to foster collaboration and gain valuable feedback.</li>
                                                                <li>Collaborate with peers and mentors to bring your concepts to life.</li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                    <h2>Getting Started:</h2>
                                                    <ol>
                                                        <li>Click the link above to visit the website.</li>
                                                        <li>Use your credentials to log in.</li>
                                                        <li>Explore and take advantage of the powerful tools and features designed to support your work.</li>
                                                    </ol>
                                                    <p>If you have any questions or encounter any issues, please don’t hesitate to contact us at <a href='mailto:support@medresearchninja.com'>support@medresearchninja.com</a>.</p>
                                                    <p>Thank you for being a valued member of MedResearch Ninja. We’re thrilled to have you with us as we embark on this exciting journey together!</p>
                                                </div>
                                                <div class='footer'>
                                                    <p>Best regards,<br>The MedResearch Ninja Team</p>
                                                </div>
                                            </div>
                                        </body>
                                        </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Welcome to MedResearch Ninja – Let’s Get Started!";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "ExistingMembershipMail", ex.Message);

            return 0;
        }
    }
    public static int ExistingMembershipMailAdmin(string name, string email)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                        <title>New User Joined – Admin Notification</title>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                background-color: #f4f4f4;
                                                margin: 0;
                                                padding: 0;
                                            }
                                            .container {
                                                max-width: 700px;
                                                margin: 20px auto;
                                                background: #ffffff;
                                                padding: 20px;
                                                border-radius: 8px;
                                                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                                            }
                                            h1 {
                                                font-size: 20px;
                                                color: #333333;
                                                text-align: center;
                                                margin-bottom: 20px;
                                            }
                                            p {
                                                font-size: 16px;
                                                color: #555555;
                                                line-height: 1.6;
                                            }
                                            .details, .actions, .features {
                                                background-color: #f9f9f9;
                                                padding: 15px;
                                                border: 1px solid #dddddd;
                                                border-radius: 8px;
                                                margin-bottom: 20px;
                                            }
                                            ul {
                                                list-style: none;
                                                padding: 0;
                                            }
                                            ul li {
                                                padding: 10px 0;
                                                border-bottom: 1px solid #eeeeee;
                                            }
                                            ul li:last-child {
                                                border-bottom: none;
                                            }
                                            a {
                                                color: #1e90ff;
                                                text-decoration: none;
                                                font-weight: bold;
                                            }
                                            .footer {
                                                text-align: center;
                                                font-size: 14px;
                                                color: #888888;
                                                margin-top: 20px;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>
                                        <div style='text-align: center;'><img src='https://www.medresearchninja.org/Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>

                                            <h1>Login Credentials Shared With Existing User </h1>
                                            <p>Dear Admin,</p>
                                            <p> <strong>MedResearch Ninja</strong>! Below are the details of the existing member:</p>

                                            <div class='details'>
                                                <p><strong>User Details:</strong></p>
                                                <ul>
                                                    <li><strong>Name:</strong> " + name + @"</li>
                                                    <li><strong>Email Address:</strong> " + email + @"</li>
                                                </ul>
                                            </div>
                                            <p>For additional information about the new member, please refer to the administration panel.</p>
                                            <p>Thank you for keeping our community vibrant and welcoming!</p>
                                            <p>Best regards,<br><strong>The MedResearch Ninja Team</strong></p>

                                            <div class='footer'>
                                                <p>© " + DateTime.UtcNow.ToString("yyyy") + @" MedResearch Ninja. All rights reserved. <a href='https://www.medresearchninja.org'>Visit Website</a></p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "New User Joined MedResearch Ninja – Admin Notification";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "ExistingMembershipMailAdmin", ex.Message);

            return 0;
        }
    }
    public static int NewProjectMail(string name, string proname, string email, string Whastapplink)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html>
                                    <head>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                color: #333333;
                                                line-height: 1.6;
                                                margin: 0;
                                                padding: 0;
                                                background-color: #f9f9f9;
                                            }
                                            .container {
                                                width: 100%;
                                                max-width: 600px;
                                                margin: 20px auto;
                                                background-color: #ffffff;
                                                border: 1px solid #dddddd;
                                                border-radius: 5px;
                                                padding: 20px;
                                                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                                            }
                                            .header {
                                                text-align: center;
                                                padding: 10px 0;
                                                background-color: #007bff;
                                                color: #ffffff;
                                                border-radius: 5px 5px 0 0;
                                            }
                                            .header h1 {
                                                margin: 0;
                                                font-size: 24px;
                                            }
                                            .content {
                                                padding: 20px;
                                            }
                                            .content p {
                                                margin: 10px 0;
                                            }
                                            .cta {
                                                margin: 20px 0;
                                                text-align: center;
                                            }
                                            .cta a {
                                                display: inline-block;
                                                padding: 10px 20px;
                                                background-color: #007bff;
                                                color: #ffffff;
                                                text-decoration: none;
                                                border-radius: 5px;
                                                font-size: 16px;
                                            }
                                            .cta a:hover {
                                                background-color: #0056b3;
                                            }
                                            .footer {
                                                text-align: center;
                                                font-size: 12px;
                                                color: #777777;
                                                margin-top: 20px;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>

                                            <div style='text-align: center;'><img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>
                                            <div class='header'>
                                                <h1>Welcome to the " + proname + @" Research Team!</h1>
                                            </div>
                                            <div class='content'>
                                                <p>Dear " + name + @",</p>
                                                <p>We’re excited to have you join the <strong>" + proname + @"</strong> research team! Your role is critical to the success of this project, and we’re confident that your contributions will make a significant impact.</p>
                                                <h2>Project Communication</h2>
                                                <p>To streamline communication, we’ve set up a dedicated WhatsApp group for this project. Please join using the link below:</p>
                                                <p><strong>WhatsApp Group Link:</strong> <a href='" + Whastapplink + @"' target='_blank'>Join WhatsApp Group</a></p>
                                                <h2>Resources and Support</h2>
                                                <p>The project team will provide all necessary resources and materials to help you get started. If you have any questions or need assistance, feel free to reach out via the WhatsApp group or message us directly at <a href='tel:+919364040500'>+91 93640 40500</a>.</p>
                                                <h2>Next Steps</h2>
                                                <p>Once you’ve joined the WhatsApp group, please introduce yourself to the team and familiarize yourself with the pinned resources.</p>
                                                <p>We’re excited to work with you and make <strong>" + proname + @"</strong> a great success!</p>
                                            </div>
                                            <div class='cta'>
                                                <a href='" + Whastapplink + @"' target='_blank'>Join WhatsApp Group</a>
                                            </div>
                                            <div class='footer'>
                                                <p>Best regards,<br>Team MedResearch Ninja</p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("projects@medresearchninja.org", ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Welcome to the " + proname + @" Research Team! - MedResearch Ninja";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewProjectMail", ex.Message);
            return 0;
        }
    }
    public static int NewProjectMailAdmin(string name, string email, string proname)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                      <html>
                                        <head>
                                            <style>
                                                body {
                                                    font-family: Arial, sans-serif;
                                                    color: #333333;
                                                    line-height: 1.6;
                                                    margin: 0;
                                                    padding: 0;
                                                    background-color: #f9f9f9;
                                                }
                                                .container {
                                                    width: 100%;
                                                    max-width: 600px;
                                                    margin: 20px auto;
                                                    background-color: #ffffff;
                                                    border: 1px solid #dddddd;
                                                    border-radius: 5px;
                                                    padding: 20px;
                                                    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                                                }
                                                .header {
                                                    text-align: center;
                                                    padding: 10px 0;
                                                    background-color: #007bff;
                                                    color: #ffffff;
                                                    border-radius: 5px 5px 0 0;
                                                }
                                                .header h1 {
                                                    margin: 0;
                                                    font-size: 24px;
                                                }
                                                .content {
                                                    padding: 20px;
                                                }
                                                .content p {
                                                    margin: 10px 0;
                                                }
                                                .details-table {
                                                    width: 100%;
                                                    border-collapse: collapse;
                                                    margin: 20px 0;
                                                }
                                                .details-table th, .details-table td {
                                                    border: 1px solid #dddddd;
                                                    padding: 10px;
                                                    text-align: left;
                                                }
                                                .details-table th {
                                                    background-color: #f2f2f2;
                                                }
                                                .footer {
                                                    text-align: center;
                                                    font-size: 12px;
                                                    color: #777777;
                                                    margin-top: 20px;
                                                }
                                            </style>
                                        </head>
                                        <body>
                                            <div class='container'>

                                        <div style='text-align: center;'><img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 30px 10px;'></div>
                                                <div class='header'>
                                                    <h1>New Enrollment Notification</h1>
                                                </div>
                                                <div class='content'>
                                                    <p>Dear Admin,</p>
                                                    <p>We’re excited to inform you that a new member has been successfully enrolled in the <strong>" + proname + @"</strong> research team. Below are the details:</p>
                                                    <table class='details-table'>
                                                        <tr>
                                                            <th>Member Name</th>
                                                            <td>" + name + @"</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Email</th>
                                                            <td>" + email + @"</td>
                                                        </tr>
                                                        <tr>
                                                            <th>Enrollment Date</th>
                                                            <td>" + DateTime.UtcNow.ToString("dd MMM yyyy") + @"</td>
                                                        </tr>
		                                        </table>
                                                    <p>Please ensure that the member has access to all necessary resources and has been added to the project communication channels.</p>
                                                    <p>If you have any questions or need further details, feel free to reach out to the team.</p>
                                                </div>
                                                <div class='footer'>
                                                    <p>Best regards,<br>Team MedResearch Ninja</p>
                                                </div>
                                            </div>
                                        </body>
                                        </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            mail.From = new MailAddress("projects@medresearchninja.org", ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "New Enrollment Notification  – " + proname;
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewProjectMailAdmin", ex.Message);
            return 0;
        }
    }
    public static int NewPostMail(string name, string email)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                        <title>Forum Notification</title>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                background-color: #f4f4f9;
                                                margin: 0;
                                                padding: 0;
                                                color: #333;
                                            }
                                            .container {
                                                width: 100%;
                                                max-width: 600px;
                                                margin: 20px auto;
                                                background: #fff;
                                                padding: 20px;
                                                border-radius: 8px;
                                                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                                            }
                                           
                                            .content {
                                                padding: 20px;
                                                line-height: 1.6;
                                            }
                                            .button {
                                                display: inline-block;
                                                margin: 20px 0;
                                                padding: 10px 20px;
                                                background-color: #0077cc;
                                                color: #fff;
                                                text-decoration: none;
                                                border-radius: 5px;
                                            }
                                            .footer {
                                                text-align: center;
                                                font-size: 12px;
                                                color: #aaa;
                                                margin-top: 20px;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='container'>

                                            <div class='header'>                                              
                                                <div style='text-align: center;'>
                                                    <img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 20px 10px;'>
                                                </div>

                                            </div>
                                            <div class='content'>  
                                                <p>Dear " + name + @",</p>
                                                <p>Thank you for contributing to the forum by sharing your post. We wanted to let you know that you will receive an email notification whenever someone responds to your post.</p>
                                                <p>This ensures you stay updated and can engage in meaningful discussions with the community.</p>
                                                <p>If you have any questions or need assistance, feel free to contact us at <a href='mailto:connect@medresearchninja.org'>connect@medresearchninja.org</a>.</p>
                                                <p>Happy posting!</p>
                                            </div>
                                            <div class='footer'>
                                                <p>&copy; " + DateTime.Now.ToString("yyyy") + @" MedResearch Ninja. All Rights Reserved.</p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Notification for Responses to Your Forum Post";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewPostMail", ex.Message);
            return 0;
        }
    }
    public static int NewPostReplyMail(string name, string email, string forumName, string response)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                        <head>
                                            <meta charset='UTF-8'>
                                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                            <title>New Forum Response</title>
                                            <style>
                                                body {
                                                    font-family: Arial, sans-serif;
                                                    background-color: #f9f9f9;
                                                    margin: 0;
                                                    padding: 0;
                                                    color: #333;
                                                }
                                                .header{
                                                    text-align: center;
                                                }
                                                .container {
                                                    width: 100%;
                                                    max-width: 600px;
                                                    margin: 20px auto;
                                                    background: #ffffff;
                                                    padding: 20px;
                                                    border-radius: 8px;
                                                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                                                }
                                                
                                                .content {
                                                    padding: 20px;
                                                    line-height: 1.6;
                                                }
                                                .button {
                                                    display: inline-block;
                                                    margin: 20px 0;
                                                    padding: 12px 20px;
                                                    background-color: #0077cc;
                                                    color: #ffffff;
                                                    text-decoration: none;
                                                    border-radius: 5px;
                                                    font-size: 16px;
                                                }
                                                .footer {
                                                    text-align: center;
                                                    font-size: 12px;
                                                    color: #888888;
                                                    margin-top: 20px;
                                                }
                                            </style>
                                        </head>
                                        <body>
                                            <div class='container'>
                                                <div class='header'>
                                                    <img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 20px 10px;'>
                                                </div>
                                                <div class='content'>
                                                    <p>Dear " + name + @",</p>
                                                    <p>Good news! Someone has responded to your post on " + forumName + @".</p>
                                                    <p>New Response:<br>
                                                    " + response + @"</p>

                                                    <p>We encourage you to continue the discussion and engage with the community. If you have any questions, feel free to reach out to us.</p>
                                                    <p>Happy connecting!</p>
                                                </div>
                                                <div class='footer'>
                                                    <p>Best regards,<br>Team MedResearch Ninja</p>
                                                </div>
                                            </div>
                                        </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Notification for Responses to Your Forum Post";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewPostMail", ex.Message);
            return 0;
        }
    }
    public static int ReminderMail(string name, string email, string protitle, string prostart)
    {
        try
        {
            string mailBody = @"<!DOCTYPE html>
                                    <html lang='en'>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                        <title>Project Reminder</title>
                                        <style>
                                            body {
                                                font-family: Arial, sans-serif;
                                                line-height: 1.6;
                                                color: #333333;
                                                margin: 0;
                                                padding: 0;
                                                background-color: #f9f9f9;
                                            }
                                            .email-container {
                                                max-width: 600px;
                                                margin: 20px auto;
                                                background: #ffffff;
                                                border: 1px solid #dddddd;
                                                border-radius: 5px;
                                                padding: 20px;
                                            }
                                            .header {
                                                font-size: 20px;
                                                font-weight: bold;
                                                margin-bottom: 20px;
                                            }
                                            .content {
                                                font-size: 16px;
                                                margin-bottom: 20px;
                                            }
                                            .details {
                                                margin-bottom: 20px;
                                            }
                                            .details p {
                                                margin: 5px 0;
                                            }
                                            .cta {
                                                margin-top: 20px;
                                            }
                                            .cta a {
                                                display: inline-block;
                                                text-decoration: none;
                                                background-color: #007bff;
                                                color: #ffffff;
                                                padding: 10px 15px;
                                                border-radius: 5px;
                                                font-weight: bold;
                                            }
                                            .footer {
                                                margin-top: 20px;
                                                font-size: 14px;
                                                color: #555555;
                                            }
                                        </style>
                                    </head>
                                    <body>
                                        <div class='email-container'>
                                            <div class='header'>
                                                <div style='text-align: center;'>
                                                    <img src='https://www.medresearchninja.org//Img/websiteLogos/logo.png' style='width: 200px;margin: 20px 10px;'>
                                                </div>
                                                    <h3>Reminder: " + protitle + @" Starts on " + prostart + @"</h3>
                                            </div>
                                            <div class='content'>
                                                Dear " + name + @",
                                                <p>We noticed you showed interest in the project <strong>" + protitle + @"</strong>, which is scheduled to begin on <strong>" + prostart + @"</strong>. This is a fantastic opportunity to work on meaningful research that will lead to an article submission in a reputable journal.</p>
                                                <p>If you haven’t completed the process yet, we encourage you to secure your spot soon as the start date is approaching quickly!</p>
                                            </div>
                                            <div class='details'>
                                                <p><strong>Project Details:</strong></p>
                                                <p>• Title: " + protitle + @"</p>
                                                <p>• Start Date: " + prostart + @"</p>
                                            </div>
                                            <div class='cta'>
                                                <a href='https://www.medresearchninja.org/login.aspx'>Login to complete your registration.</a>
                                            </div>
                                            <div class='footer'>
                                                <p>If you have any questions or require assistance, feel free to reach out to us on WhatsApp. We look forward to seeing you on board!</p>
                                                <p>Best regards,<br>Team MedResearch Ninja</p>
                                            </div>
                                        </div>
                                    </body>
                                    </html>";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("projects@medresearchninja.org", ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Reminder: " + protitle + @" Starts on " + prostart + @"";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.AbsoluteUri, "NewPostMail", ex.Message);
            return 0;
        }
    }
    public static async Task<int> BookingConfirmedAdminNew(string name, string email, string paidAmount, string ReceiptNo, string prjectName, string oid)
    {
        try
        {


            #region mailBody
            string mailBody = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Divoura</title>
    <link rel='shortcut icon' href='" + ConfigurationManager.AppSettings["domain"] + @"Img/websiteLogos/fab.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
 
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>


                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>



                                                            <tr>
                                                                <td align='left' valign='top' style='padding:10px;background:#fcfcfc'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;float: left; margin-right: 0; width: 100%;'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <center><img style='height:90px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/websiteLogos/logo.png' /></center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                        </table>




                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                    <p style='font-size:22px;line-height:28px!important;text-align:center;color:#573e40;font-weight:bold!important'>
                                                                        Hi Admin, You have received on order, Below are the details
                                                                    </p>

                                                                    <p style='font-size:26px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#FF9212;padding:10px;width:50%;margin:0px auto;margin-bottom:0px'>Order Number: " + oid + @"</p>

                                                                </td> 
                                                            </tr> 
                                                        </table>
                                                    </td>
                                                </tr>  
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px 60px 20px 60px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>


                                                            <tr>
                                                               
                                                                <td align='left' valign='top' style='float:left;width:100%' class='flexibleContainerCell'>
                                                                    <p style='text-align:left;font-weight:600!important;margin-bottom:20px !important;font-size:16px;'>Stuff Picked:</p>
<h3>Project Name: " + prjectName + @" </h3>
<h3>Total Amount:  ₹" + paidAmount + @" </h3>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr> 
                                            </table>
                                        </td>
                                    </tr> 

                                    <tr>
                                        <td align='left' valign='top' style='padding:10px 20px;background:#f2f2f2'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                  <tr>
                                                                               <td align='center' valign='middle' width='100%' class='flexibleContainerCell'>
                                                                                    <ul style='list-style:none;width:390px;margin:0px auto;'>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.facebook.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/facebook.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.instagram.com//' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/instagram.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://twitter.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/twitter.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.youtube.com/c/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/youtube.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:0px;padding-right:5px;'>
                                                                                            <a href='mailto:hello@divoura.com' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"Img/mail.png' /></a>
                                                                                        </li>

                                                                                    </ul>
                                                                                </td>

                                                                            </tr> 

                                            </table>
                                        </td>
                                    </tr> 
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
    </center>
</body>
</html>";
            #endregion
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "MedResearchNinja Project Order Confirmation";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(delegate
            {
                smtp.Send(mail);
            });
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }
    public static int SendMailtoMember(string display_name, string emails, string ccEmail, string bccEmail, string mailSubject, string mailBody)
    {
        try
        {
            #region mailBody
            string mailBody1 = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
  <head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>medresearchninja</title>
    <link rel='shortcut icon' href='https://www.medresearchninja/images/medresearchninja_Black_Logo2_1_140x.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>html{background-color:#fff;margin:0;font-family:'Lato',sans-serif;padding:0}body,#bodyTable,#bodyCell,#bodyCell{height:100%!important;margin:0;padding:0;width:100%!important}table{border-collapse:collapse}table[id='bodyTable']{width:100%!important;margin:auto;max-width:500px!important;color:#212121;font-weight:400}img,a img{border:0;outline:none;text-decoration:none;height:auto;line-height:100%}h1,h2,h3,h4,h5,h6{color:#5f5f5f;font-weight:400;font-size:20px;line-height:125%;text-align:Left;letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0}.ReadMsgBody{width:100%}.ExternalClass{width:100%}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%}table,td{mso-table-lspace:0pt;mso-table-rspace:0pt}#outlook a{padding:0}img{-ms-interpolation-mode:bicubic;display:block;outline:none;text-decoration:none}body,table,td,p,a,li,blockquote{-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;font-weight:500!important}.ExternalClass td[class='ecxflexibleContainerBox'] h3{padding-top:10px!important}h1{display:block;font-size:26px;font-style:normal;font-weight:400;line-height:100%}h2{display:block;font-size:20px;font-style:normal;font-weight:400;line-height:120%}h3{display:block;font-size:17px;font-style:normal;font-weight:400;line-height:110%}h4{display:block;font-size:18px;font-style:italic;font-weight:400;line-height:100%}.flexibleImage{height:auto}.linkRemoveBorder{border-bottom:0!important}table[class='flexibleContainerCellDivider']{padding-bottom:0!important;padding-top:0!important}body,#bodyTable{background-color:#e1e1e1}#emailHeader{background-color:#fff}#emailBody{background-color:#fff}#emailFooter{background-color:#e1e1e1}.nestedContainer{background-color:#f8f8f8;border:1px solid #ccc}.emailButton{background-color:#205478;border-collapse:separate}.buttonContent{color:#fff;font-family:Helvetica;font-size:18px;font-weight:700;line-height:100%;padding:15px;text-align:center}.buttonContent a{color:#fff;display:block;text-decoration:none!important;border:0!important}.emailCalendar{background-color:#fff;border:1px solid #ccc}.emailCalendarMonth{background-color:#205478;color:#fff;font-size:16px;font-weight:700;padding-top:10px;padding-bottom:10px;text-align:center}.emailCalendarDay{color:#205478;font-size:60px;font-weight:700;line-height:100%;padding-top:20px;padding-bottom:20px;text-align:center}.imageContentText{margin-top:10px;line-height:0}.imageContentText a{line-height:0}#invisibleIntroduction{display:none!important}span[class='ios-color-hack'] a{color:#275100!important;text-decoration:none!important}span[class='ios-color-hack2'] a{color:#205478!important;text-decoration:none!important}span[class='ios-color-hack3'] a{color:#8b8b8b!important;text-decoration:none!important}.a[href^='tel'],a[href^='sms']{text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important}.mobile_link a[href^='tel'],.mobile_link a[href^='sms']{text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important}@media only screen and (max-width:480px){body{width:100%!important;min-width:100%!important}table[id='emailHeader'],table[id='emailBody'],table[id='emailFooter'],table[class='flexibleContainer'],td[class='flexibleContainerCell']{width:100%!important}td[class='flexibleContainerBox'],td[class='flexibleContainerBox'] table{display:block;width:100%;text-align:left}td[class='imageContent'] img{height:auto!important;width:100%!important;max-width:100%!important}img[class='flexibleImage']{height:auto!important;width:100%!important;max-width:100%!important}img[class='flexibleImageSmall']{height:auto!important;width:auto!important}table[class='flexibleContainerBoxNext']{padding-top:10px!important}table[class='emailButton']{width:100%!important}td[class='buttonContent']{padding:0!important}td[class='buttonContent'] a{padding:15px!important}}.blink_text{-webkit-animation-name:blinker;-webkit-animation-duration:2s;-webkit-animation-timing-function:linear;-webkit-animation-iteration-count:infinite;-moz-animation-name:blinker;-moz-animation-duration:2s;-moz-animation-timing-function:linear;-moz-animation-iteration-count:infinite;animation-name:blinker;animation-duration:2s;animation-timing-function:linear;animation-iteration-count:infinite;color:#fff}@-moz-keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}@-webkit-keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}@keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}    </style>
  </head>
  <body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color: #e1e1e1'>
      <table
        border='0'
        cellpadding='0'
        cellspacing='0'
        height='100%'
        width='100%'
        id='bodyTable'
        style='table-layout: fixed; max-width: 100% !important; width: 100% !important; min-width: 100% !important'>
        <tr>
          <td align='center' valign='top' id='bodyCell'>
            <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top: 20px; margin-bottom: 20px'>
              <tr>
                <td align='center' valign='top' style=''>
                  <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                    <tr>
                      <td align='center' valign='top'>
                        <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                          <tr>
                            <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                              <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                <tr>
                                  <td align='left' valign='top' style='padding: 20px; background: #000'>
                                    <table border='0' cellpadding='0' cellspacing='0' style='float: left; width: 100%; margin-right: 5%'>
                                      <tr>
                                        <td align='left' valign='top' width='48%' style='vertical-align: middle' class='flexibleContainerCell'>
                                          <img style='width: 130px; margin-bottom: 0px' src='https://www.medresearchninja.org/new-img/logo4.png' />
                                        </td>
                                        <td align='right' valign='top' width='48%' style='vertical-align: middle' class='flexibleContainerCell'>
                                          <a style='color: #ff7f3e' href='https://www.medresearchninja.org/'>www.medresearchninja.org</a>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding: 0px; background: #ff7f3e4f'>
                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                      <tr>
                                        <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                          <p style='font-size: 22px; line-height: 32px !important; text-align: center; color: white; margin-top: 0px; background: #ff7f3e; padding: 10px'>
                                            " + mailSubject + @"
                                          </p>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding-top: 0px'>
                                    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='margin-top: 15px;'>
                                      <tr style='margin-bottom: 15px'>
                                        <td style='font-size: 14px' align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                          " + mailBody + @"
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding: 20px 20px; background: #ff7f3e4f'>
                                    <br />
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </center>
  </body>
</html>";
            #endregion
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(emails);
            if (ccEmail != "")
                mail.CC.Add(ccEmail);
            if (bccEmail != "")
                mail.Bcc.Add(bccEmail);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], display_name);
            mail.Subject = mailSubject;
            mail.Body = mailBody1;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;



        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendMailtoCustomer", ex.Message);
            return 0;
        }
    }
    public static int SendMailtoAdmin(string display_name, string mailSubject, string mailBody)
    {
        try
        {
            #region mailBody
            string mailBody1 = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
  <head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>medresearchninja</title>
    <link rel='shortcut icon' href='https://www.medresearchninja/images/medresearchninja_Black_Logo2_1_140x.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>html{background-color:#fff;margin:0;font-family:'Lato',sans-serif;padding:0}body,#bodyTable,#bodyCell,#bodyCell{height:100%!important;margin:0;padding:0;width:100%!important}table{border-collapse:collapse}table[id='bodyTable']{width:100%!important;margin:auto;max-width:500px!important;color:#212121;font-weight:400}img,a img{border:0;outline:none;text-decoration:none;height:auto;line-height:100%}h1,h2,h3,h4,h5,h6{color:#5f5f5f;font-weight:400;font-size:20px;line-height:125%;text-align:Left;letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0}.ReadMsgBody{width:100%}.ExternalClass{width:100%}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%}table,td{mso-table-lspace:0pt;mso-table-rspace:0pt}#outlook a{padding:0}img{-ms-interpolation-mode:bicubic;display:block;outline:none;text-decoration:none}body,table,td,p,a,li,blockquote{-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;font-weight:500!important}.ExternalClass td[class='ecxflexibleContainerBox'] h3{padding-top:10px!important}h1{display:block;font-size:26px;font-style:normal;font-weight:400;line-height:100%}h2{display:block;font-size:20px;font-style:normal;font-weight:400;line-height:120%}h3{display:block;font-size:17px;font-style:normal;font-weight:400;line-height:110%}h4{display:block;font-size:18px;font-style:italic;font-weight:400;line-height:100%}.flexibleImage{height:auto}.linkRemoveBorder{border-bottom:0!important}table[class='flexibleContainerCellDivider']{padding-bottom:0!important;padding-top:0!important}body,#bodyTable{background-color:#e1e1e1}#emailHeader{background-color:#fff}#emailBody{background-color:#fff}#emailFooter{background-color:#e1e1e1}.nestedContainer{background-color:#f8f8f8;border:1px solid #ccc}.emailButton{background-color:#205478;border-collapse:separate}.buttonContent{color:#fff;font-family:Helvetica;font-size:18px;font-weight:700;line-height:100%;padding:15px;text-align:center}.buttonContent a{color:#fff;display:block;text-decoration:none!important;border:0!important}.emailCalendar{background-color:#fff;border:1px solid #ccc}.emailCalendarMonth{background-color:#205478;color:#fff;font-size:16px;font-weight:700;padding-top:10px;padding-bottom:10px;text-align:center}.emailCalendarDay{color:#205478;font-size:60px;font-weight:700;line-height:100%;padding-top:20px;padding-bottom:20px;text-align:center}.imageContentText{margin-top:10px;line-height:0}.imageContentText a{line-height:0}#invisibleIntroduction{display:none!important}span[class='ios-color-hack'] a{color:#275100!important;text-decoration:none!important}span[class='ios-color-hack2'] a{color:#205478!important;text-decoration:none!important}span[class='ios-color-hack3'] a{color:#8b8b8b!important;text-decoration:none!important}.a[href^='tel'],a[href^='sms']{text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important}.mobile_link a[href^='tel'],.mobile_link a[href^='sms']{text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important}@media only screen and (max-width:480px){body{width:100%!important;min-width:100%!important}table[id='emailHeader'],table[id='emailBody'],table[id='emailFooter'],table[class='flexibleContainer'],td[class='flexibleContainerCell']{width:100%!important}td[class='flexibleContainerBox'],td[class='flexibleContainerBox'] table{display:block;width:100%;text-align:left}td[class='imageContent'] img{height:auto!important;width:100%!important;max-width:100%!important}img[class='flexibleImage']{height:auto!important;width:100%!important;max-width:100%!important}img[class='flexibleImageSmall']{height:auto!important;width:auto!important}table[class='flexibleContainerBoxNext']{padding-top:10px!important}table[class='emailButton']{width:100%!important}td[class='buttonContent']{padding:0!important}td[class='buttonContent'] a{padding:15px!important}}.blink_text{-webkit-animation-name:blinker;-webkit-animation-duration:2s;-webkit-animation-timing-function:linear;-webkit-animation-iteration-count:infinite;-moz-animation-name:blinker;-moz-animation-duration:2s;-moz-animation-timing-function:linear;-moz-animation-iteration-count:infinite;animation-name:blinker;animation-duration:2s;animation-timing-function:linear;animation-iteration-count:infinite;color:#fff}@-moz-keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}@-webkit-keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}@keyframes blinker{0%{opacity:1}50%{opacity:0}100%{opacity:1}}    </style>
  </head>
  <body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color: #e1e1e1'>
      <table
        border='0'
        cellpadding='0'
        cellspacing='0'
        height='100%'
        width='100%'
        id='bodyTable'
        style='table-layout: fixed; max-width: 100% !important; width: 100% !important; min-width: 100% !important'>
        <tr>
          <td align='center' valign='top' id='bodyCell'>
            <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top: 20px; margin-bottom: 20px'>
              <tr>
                <td align='center' valign='top' style=''>
                  <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                    <tr>
                      <td align='center' valign='top'>
                        <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                          <tr>
                            <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                              <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                <tr>
                                  <td align='left' valign='top' style='padding: 20px; background: #000'>
                                    <table border='0' cellpadding='0' cellspacing='0' style='float: left; width: 100%; margin-right: 5%'>
                                      <tr>
                                        <td align='left' valign='top' width='48%' style='vertical-align: middle' class='flexibleContainerCell'>
                                          <img style='width: 130px; margin-bottom: 0px' src='https://www.medresearchninja.org/new-img/logo4.png' />
                                        </td>
                                        <td align='right' valign='top' width='48%' style='vertical-align: middle' class='flexibleContainerCell'>
                                          <a style='color: #ff7f3e' href='https://www.medresearchninja.org/'>www.medresearchninja.org</a>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding: 0px; background: #ff7f3e4f'>
                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                      <tr>
                                        <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                          <p style='font-size: 22px; line-height: 32px !important; text-align: center; color: white; margin-top: 0px; background: #ff7f3e; padding: 10px'>
                                            " + mailSubject + @"
                                          </p>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding-top: 0px'>
                                    <table border='0' cellpadding='0' cellspacing='0' width='100%' style='margin-top: 15px;'>
                                      <tr style='margin-bottom: 15px'>
                                        <td style='font-size: 14px' align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                          " + mailBody + @"
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td align='left' valign='top' style='padding: 20px 20px; background: #ff7f3e4f'>
                                    <br />
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </center>
  </body>
</html>";
            #endregion
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            if (ConfigurationManager.AppSettings["CCMail"] != "")
                mail.CC.Add(ConfigurationManager.AppSettings["CCMail"]);
            if (ConfigurationManager.AppSettings["BCCMail"] != "")
                mail.Bcc.Add(ConfigurationManager.AppSettings["BCCMail"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], display_name);
            mail.Subject = mailSubject;
            mail.Body = mailBody1;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);

            smtp.Send(mail);
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendMailtoCustomer", ex.Message);
            return 0;
        }
    }
}

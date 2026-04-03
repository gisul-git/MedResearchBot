using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signup : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strThumbImage = "";
    //public string oGuid = Guid.NewGuid().ToString();
    //the below is create one userguid for and it is usd for both payment and regiester

    public string uid = Guid.NewGuid().ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }




    protected void btnRegister_Click(object sender, EventArgs e)
    {
        lblStatus.Visible = true;
        lblstatus2.Visible = true;
        lblStatus.Text = "";
        lblStatus.CssClass = "";
        try
        {
            var rPath = CheckPDFFormat();
            if (rPath == "Format")
            {
                lblStatus.Text = "Invalid PDF format.";
                lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                lblstatus2.Text = "Invalid PDF format.";
                lblstatus2.Attributes.Add("class", "alert alert-danger d-block");
                return;
            }
            MemberDetails CD = new MemberDetails();
            CD.UserID = UserID();
            CD.UserGuid = uid;
            CD.ForgotId = Guid.NewGuid().ToString();
            CD.UpdatedIp = CommonModel.IPAddress();
            CD.PaymentStatus = "Not Paid";
            CD.UpdatedBy = CD.UserID;
            CD.GovtID = UploadGovtIdPath();
            CD.Address = "";
            CD.MsgCnt = "0";
            CD.City = "";
            CD.State = "";
            CD.Pincode = "";
            CD.PassKey = Guid.NewGuid().ToString();
            CD.FullName = txtFullName.Text.Trim();
            CD.EmailId = txtemail.Text.Trim();
            CD.Password = CommonModel.Encrypt(txtPassword.Text.Trim());
            CD.Country = txtCountry.Text.Trim();
            CD.Contact = txtContactnumber.Text.Trim();
            CD.MedicalSchoolName = txtCourse.Text.Trim();
            CD.ProfileImage = "";
            CD.AddedIp = CommonModel.IPAddress();
            CD.AddedOn = TimeStamps.UTCTime();
            CD.AddedBy = "";
            CD.LastLoggedIn = TimeStamps.UTCTime();
            CD.LastLoggedIp = CommonModel.IPAddress();
            CD.UpdatedOn = TimeStamps.UTCTime();
            CD.Status = "Unverified";
            CD.WhoAreYou = ddlWhoAreYou.SelectedValue;
            CD.Specify = txtspecify.Text.Trim();

            int result = MemberDetails.InsertMemberDetails(conMN, CD);
            if (result == -1)
            {
                lblStatus.Attributes.Add("class", "alert alert-danger d-block");
                lblStatus.Text = "Email Id Already Registered. Please Login To Proceed ";
                lblstatus2.Text = "Email Id Already Registered. Please Login To Proceed ";
                lblstatus2.Attributes.Add("class", "alert alert-danger d-block");
                btnRegister.Focus();
                return;
            }
            if (result > 0)
            {
                txtFullName.Text = txtemail.Text = txtPassword.Text = txtCountry.Text = txtContactnumber.Text = txtCourse.Text = "";
                lblStatus.Text = "Registered Successfully";
                lblStatus.CssClass = "alert alert-success d-block"; 
                
                lblstatus2.Text = "Registered Successfully";
                lblstatus2.CssClass = "alert alert-success d-block";

                MemberDetails.UpdateLastLoginTime(conMN, CD.UserGuid);


                //payment
                try
                {
                    //lblStatus.Visible = true;

                    decimal price = 0;
                    string oid = UserCheckout.GetOMax(conMN);
                    string OGuid = Guid.NewGuid().ToString();
                    // string uid = HttpContext.Current.Request.Cookies["gluta_ui"] != null ? HttpContext.Current.Request.Cookies["gluta_ui"].Value : HttpContext.Current.Request.Cookies["gluta_vi"].Value;
                    // string bType = HttpContext.Current.Request.Cookies["gluta_ui"] != null ? "Customer" : "Guest";
                    string bType = HttpContext.Current.Request.Cookies[uid] != null ? "Customer" : "Guest";
                    string payType = "Payment Gateway";
                    string ipAddress = CommonModel.IPAddress();
                    DateTime orderedOn = TimeStamps.UTCTime();


                    #region User Billing Address
                    UserBillingAddress bill = new UserBillingAddress();
                    bill.AddedDateTime = orderedOn;
                    bill.Landmark = "";
                    bill.CustomerGSTN = "";
                    bill.Salutation = "";
                    bill.CompanyName = "";
                    bill.Address1 = "";
                    bill.Address2 = "";
                    bill.Block = "";
                    bill.City = "";
                    bill.State = "";
                    bill.Country = CD.Country;
                    bill.FirstName = CD.FullName;
                    bill.LastName = "";
                    bill.Mobile = CD.Contact;
                    bill.AltMobile = "";
                    bill.OrderGuid = OGuid;
                    bill.UserGuid = uid;
                    bill.Zip = "";
                    bill.EmailId = CD.EmailId;
                    bill.AddedIp = ipAddress;
                    UserCheckout.InsertBillingAddress(conMN, bill);
                    #endregion

                    #region User Delivery Address
                    UserDeliveryAddress delA = new UserDeliveryAddress();
                    delA.AddedDateTime = orderedOn;
                    delA.Apartment = "";
                    delA.Block = "";
                    delA.Landmark = "";
                    delA.Salutation = "";
                    delA.Address1 = "";
                    delA.Address2 = "";
                    delA.Country = CD.Country;
                    delA.City = "";
                    delA.State = "";
                    delA.FirstName = CD.FullName;
                    delA.LastName = "";
                    delA.Email = CD.EmailId;
                    delA.Mobile = CD.Contact;
                    delA.AltMobile = "";
                    delA.OrderGuid = OGuid;
                    delA.UserGuid = uid;
                    delA.AddedIp = ipAddress;
                    delA.Zip = "";
                    UserCheckout.InsertDeliveryAddress(conMN, delA);
                    #endregion

                    price = 850;
                    #region Order Table
                    Orders od = new Orders();
                    od.LastUpdatedOn = orderedOn;
                    od.LastUpdatedIp = ipAddress;
                    od.OrderedIp = ipAddress;
                    od.OrderGuid = OGuid;
                    od.OrderId = "MEDORD" + oid;
                    od.OrderMax = oid;
                    od.OrderOn = orderedOn;
                    od.OrderStatus = "Initiated";
                    od.PaymentId = "";
                    od.PaymentMode = payType;
                    od.PaymentStatus = "Initiated";
                    od.ReceiptNo = "";
                    od.RMax = "";
                    od.UserName = CD.FullName;
                    od.EmailId = CD.EmailId;
                    od.Contact = CD.Contact;
                    od.PromoCode = "";
                    od.PromoType = "";
                    od.PromoValue = "";
                    od.CODAmount = "";
                    od.Discount = "";
                    od.ShippingPrice = "";
                    od.SubTotal = "";
                    od.SubTotalWithoutTax = "";
                    od.Tax = "";
                    od.TotalPrice = (price).ToString(".##");
                    od.AdvAmount = "";
                    od.BalAmount = "";
                    od.UserGuid = CD.UserGuid;
                    od.UserType = bType;
                    int ord = UserCheckout.CreateUserOrder(conMN, od);
                    if (ord > 0)
                    {
                        Orders orders = new Orders();
                        string rId = UserCheckout.GetRMax(conMN);
                        orders.OrderGuid = OGuid;
                        orders.PaymentStatus = "Not Paid";
                        orders.OrderStatus = "In-Process";
                        orders.PaymentId = "";
                        orders.hostedCheckoutId = "";
                        orders.RMax = rId;
                        orders.ReceiptNo = "MEDRESNIN" + rId;
                        int x = UserCheckout.UpdateUserOrder(conMN, orders);


                        //var timeline = new OrderTimeline()
                        //{
                        //    OrderGuid = OGuid,
                        //    OrderStatus = "Created",
                        //    AddedBy = uid,
                        //};

                        // var exe = OrderTimeline.AddTimeline(conMN, timeline);

                        if (x > 0)
                        {
                            Response.Redirect("pay-now.aspx?order=" + OGuid);
                        }
                    }


                    else
                    {
                        lblStatus.Text = "There is some problem now. Please try after sometime.";
                        lblStatus.Attributes.Add("class", "alert alert-danger");

                        lblstatus2.Text = "There is some problem now. Please try after sometime.";
                        lblstatus2.Attributes.Add("class", "alert alert-danger");
                    }
                    #endregion



                }
                catch (Exception ex)
                {
                    ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnMembership_Click", ex.Message);
                }

                // Response.Redirect("member-profile.aspx", false);
            }
            else
            {
                lblStatus.Text = "There is some problem now. Please try after some time";
                lblStatus.CssClass = "alert alert-danger d-block";

                lblstatus2.Text = "There is some problem now. Please try after some time";
                lblstatus2.CssClass = "alert alert-danger d-block";
                btnRegister.Focus();
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "There is some problem now. Please try after some time";
            lblStatus.CssClass = "alert alert-danger d-block";
            lblstatus2.Text = "There is some problem now. Please try after some time";
            lblstatus2.CssClass = "alert alert-danger d-block";
            btnRegister.Focus();
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadGovtIdPath", ex.Message);

        }



    }
    private string CheckPDFFormat()
    {
        #region ThumbImage
        string GovtIdPDF = "";
        if (UploadGovtID.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(UploadGovtID.PostedFile.FileName.ToLower());
                if (!(fileExtension == ".pdf" || fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckPDFFormat", ex.Message);

            }
        }
        #endregion

        return GovtIdPDF;
    }

    public string UploadGovtIdPath()
    {
        #region upload file
        string PDFbfile = "";
        try
        {
            if (UploadGovtID.HasFile)
            {
                string fileExtension = Path.GetExtension(UploadGovtID.PostedFile.FileName.ToLower()),
                ImageGuid1 = Guid.NewGuid().ToString() + "_resume".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                UploadGovtID.SaveAs(iconPath);
                PDFbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                PDFbfile = lblGovtId.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadGovtIdPath", ex.Message);

        }

        #endregion

        return PDFbfile;
    }
    public string UserID()
    {
        try
        {
            string Mem = MemberDetails.GetUserID(conMN);
            if (!string.IsNullOrEmpty(Mem))
            {
                int nextId = Convert.ToInt32(Mem.Replace("MRNUSER", "")) + 1;
                return String.Format("MRNUSER{0:D4}", nextId);
            }
            else
            {
                return "MRNUSER0001";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UserID", ex.Message);
            return null;
        }
    }

}

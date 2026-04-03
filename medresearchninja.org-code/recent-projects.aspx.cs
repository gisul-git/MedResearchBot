using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recent_projects : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strProjects = "", strDues = "", StrUserImage = "", StrUserName = "", StrLink = "", StrText = "", StrLoginBtn = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["med_uid"] == null)
        {
            Response.Redirect("login.aspx");
        }
        CheckUserExist();
        int count = Projects.GetPendingProjectDuesCount(conMN, Request.Cookies["med_uid"].Value);
        strDues = count > 0 ? "<span class='badge-circle'>" + count + "</span>" : "";
        if (!IsPostBack)
        {

            BindRecentProjects();
        }
    }
    public void CheckUserExist()
    {
        try
        {
            if (Request.Cookies["med_uid"] == null)
            {

                StrLink = "/signup.aspx";
                StrText = "Sign Up";
                StrLoginBtn = "<a href='/signup.aspx' class='ud-btn1 btn-thm w-50'>Sign Up</a>";

            }
            else
            {
                var user = MemberDetails.GetMemberDetailsByGuid(conMN, Request.Cookies["med_uid"].Value);
                if (user != null)
                {
                    StrUserImage = user.ProfileImage == "" ? "<img src='/images/user.png' alt='user.png' width='30' />" : "<img src='/" + user.ProfileImage + @"' alt='user.png' width='30' />";
                    StrUserName = user.FullName;
                }
                StrLink = "/member-profile.aspx";
                StrText = "My Profile";
                StrLoginBtn = "<a href='/member-profile.aspx' class='ud-btn1 btn-thm w-50'>My Profile</a>";
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindRecentProjects()
    {
        try
        {
            List<Projects> res = Projects.BindRecentProjects(conMN);

            if (res.Count > 0)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    int projectGuidCount = 0;
                    var Proj = PUserCheckout.GetMxOrderIdByPGuid(conMN, res[i].ProjectGuid);

                    if (int.TryParse(Proj, out projectGuidCount))
                    {
                        if (projectGuidCount < Convert.ToInt32(res[i].MaxCollab))
                        {
                            // Retrieve the  cookies

                            string userGuid = Request.Cookies["med_uid"] != null ? Request.Cookies["med_uid"].Value : null;
                            var ProjectBought = PUserCheckout.GetOrderStatusDetailsByGuid(conMN, userGuid, res[i].ProjectGuid);
                            if (ProjectBought != null)
                            {

                            }
                            else
                            {
                                List<string> tags = res[i].Tags.Split('|').ToList();
                                var strtags = "";
                                for (int j = 0; j < tags.Count; j++)
                                {
                                    strtags += "<span class='tag bgc-thm3 " + (j > 0 ? "mx10" : "") + @"'>" + tags[j] + @"</span>";

                                }
                                strProjects += @"<div class='col-lg-12'>
                                                    <div class='ps-widget  position-relative'>
                                                        <div class='freelancer-style1 bdr1 hover-box-shadow row ms-0 bdrs12'>
                                                            <div class='col-lg-12 p-0'>
                                                                <div class='d-lg-flex align-items-center justify-content-lg-between  mb-3'>
                                                                    <div>
                                                                        <div class='d-lg-flex align-items-center'>
                                                                            <div class='ml20 mr20 ml0-md'>
                                                                                <div class='new-flex-project mb20'>
                                                                                    <div>
                                                                                        <h5 class='title mb-1'>" + res[i].ProjectName + @"</h5>
                                                                                        <p class='mb-0'>Start Date : " + res[i].StartDate + @" , Project code: " + res[i].ProjectId + @"</p>
                                                                                    </div>
                                                                                    <div class='review mb5'>
                                                                                        <div class='pending-style style1'>
                                                                                            <i class='flaticon-income fz16 dark-color pr10'></i>
                                                                                            <span class='dark-color fw500'>₹ " + Convert.ToInt32(res[i].PriceINR).ToString("N2") + @"  or $" + Convert.ToInt32(res[i].PriceOther) + @"</span>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <div class='new-dec-container'>
                                                                                  <div class='new-dec'>
                                                                                    <p class='text'>" + res[i].ShortDesc + @"</p>
                                                                                  </div>
                                                                                    <a href='javascript:void(0);' class='toggle-button text-light btnoverview' data-bs-toggle='modal' data-bs-target='#OverviewModal' data-id='" + res[i].Id + @"' data-msg='" + System.Net.WebUtility.HtmlEncode(res[i].ShortDesc) + @"'>Read More</a>

                                                                                </div>

                                                                                <div class='skill-tags d-flex align-items-center justify-content-between mt20'>
                                                                                    <div class='new-flex-tags'> " + strtags + @"
                                                                                    </div>
                                                                                    <a href='javascript:void(0);' class='ud-btn btn-thm-border hover-default-box-shadow1 btnPurchase' data-id='" + res[i].ProjectGuid + @"'>Enroll Now</a>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>";
                            }


                        }
                    }
                }
            }
            else
            {
                strProjects = "<h3 class='text-center' style='font-style: italic;'>We’re constantly working on groundbreaking studies, insightful reviews, unique case reports, and engaging conference abstracts. There’s always something new and exciting on the horizon—stay tuned for our upcoming releases!</h3>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindRecentProjects", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string BuyProject(string projectGuid)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        try
        {
            // Retrieve the  cookies
            HttpCookie cookie = HttpContext.Current.Request.Cookies["med_uid"];
            string userGuid = cookie != null ? cookie.Value : null;


            if (string.IsNullOrEmpty(userGuid))
            {
                return "error";
            }

            var Po = PUserCheckout.GetOrderStatusDetailsByGuid(conMN, userGuid, projectGuid);
            if (Po != null)
            {
                return "Paid";
            }
            else
            {
                var MD = MemberDetails.GetMemberDetailsByGuid(conMN, userGuid);
                var Proj = Projects.GetProjectDetailsByPGuid(conMN, projectGuid);
                decimal price = Convert.ToDecimal(Proj.PriceINR);
                decimal priceUsd = Convert.ToDecimal(Proj.PriceOther);
                string oid = PUserCheckout.GetOMax(conMN);
                string OGuid = Guid.NewGuid().ToString();
                string payType = "PayU";
                string ipAddress = CommonModel.IPAddress();
                DateTime orderedOn = TimeStamps.UTCTime();

                // Billingelivery 
                PUserBillingAddress bill = new PUserBillingAddress
                {
                    AddedDateTime = orderedOn,
                    FirstName = MD.FullName,
                    Mobile = MD.Contact,
                    OrderGuid = OGuid,
                    UserGuid = MD.UserGuid,
                    EmailId = MD.EmailId,
                    AddedIp = ipAddress,
                    Landmark = "",
                    CustomerGSTN = "",
                    Salutation = "",
                    CompanyName = "",
                    Address1 = "",
                    Address2 = "",
                    Block = "",
                    City = "",
                    State = "",
                    Country = "",
                    LastName = "",
                    AltMobile = "",
                    Zip = "",
                };
                PUserCheckout.InsertBillingAddress(conMN, bill);

                PUserDeliveryAddress delA = new PUserDeliveryAddress
                {
                    AddedDateTime = orderedOn,
                    FirstName = MD.FullName,
                    Email = MD.EmailId,
                    Mobile = MD.Contact,
                    OrderGuid = OGuid,
                    UserGuid = MD.UserGuid,
                    AddedIp = ipAddress,
                    Apartment = "",
                    Block = "",
                    Landmark = "",
                    Salutation = "",
                    Address1 = "",
                    Address2 = "",
                    Country = MD.Country,
                    City = "",
                    State = "",
                    LastName = "",
                    AltMobile = "",
                    Zip = "",
                };
                PUserCheckout.InsertDeliveryAddress(conMN, delA);

                price = Convert.ToDecimal(Proj.PriceINR);
                priceUsd = Convert.ToDecimal(Proj.PriceOther);

                // Insert the order
                POrders od = new POrders
                {
                    LastUpdatedOn = orderedOn,
                    LastUpdatedIp = ipAddress,
                    OrderedIp = ipAddress,
                    OrderGuid = OGuid,
                    ProjectGuid = projectGuid,
                    OrderId = "MEDPROJORD" + oid,
                    OrderMax = oid,
                    OrderOn = orderedOn,
                    OrderStatus = "Initiated",
                    PaymentMode = payType,
                    PaymentStatus = "Initiated",
                    TotalPrice = (price).ToString(".##"),
                    PriceUSD = (priceUsd).ToString(".##"),
                    UserGuid = MD.UserGuid,
                    UserName = MD.FullName,
                    EmailId = MD.EmailId,
                    Contact = MD.Contact,
                    PaymentId = "",
                    ReceiptNo = "",
                    RMax = "",
                    PromoCode = "",
                    PromoType = "",
                    PromoValue = "",
                    CODAmount = "",
                    Discount = "",
                    ShippingPrice = "",
                    SubTotal = "",
                    SubTotalWithoutTax = "",
                    Tax = "",
                    AdvAmount = "",
                    BalAmount = "",
                    UserType = "",
                    ProjectName = Proj.ProjectName
                };

                int ord = PUserCheckout.CreateUserOrder(conMN, od);
                if (ord > 0)
                {
                    string rId = PUserCheckout.GetRMax(conMN);
                    od.RMax = rId;
                    od.ReceiptNo = "MEDPROJECT" + rId;
                    od.OrderStatus = "In-Process";
                    od.hostedCheckoutId = "";
                    od.UserName = MD.FullName;
                    od.EmailId = MD.EmailId;
                    od.Contact = MD.Contact;
                    od.PaymentMode = payType;
                    int x = PUserCheckout.UpdateUserOrder(conMN, od);

                    if (x > 0)
                    {
                        return "Success|" + od.OrderGuid;
                    }
                }
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btn_Buy_Project_Click", ex.Message);
        }
        return "error";

    }


    protected void btnLogout_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["med_uid"] != null)
        {
            Response.Cookies["med_uid"].Expires = TimeStamps.UTCTime().AddDays(-10);
            Response.Redirect("login.aspx");
        }
    }
}
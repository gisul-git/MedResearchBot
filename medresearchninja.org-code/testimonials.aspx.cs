using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testimonials : System.Web.UI.Page
{
    SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
    public string strTestimonials = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        BindTestimonials();

    }




    private void BindTestimonials()
    {

        try
        {
            strTestimonials = "";
            var testimonial = Testimonial.GetAllTestimonial(conMN).ToList();
            if (testimonial.Count > 0)
            {
                for (int i = 0; i < testimonial.Count; i++)
                {
                    //var url = "testimonial/" + testimonial[i].JobUrl;

                    //string sDec = Jobs[i].ShortDesc;
                    //if (sDec.Length > 125)
                    //{
                    //    sDec = sDec.Substring(0, 125) + "...";
                    //}


                    //var currDate = TimeStamps.UTCTime() - Jobs[i].AddedOn;
                    //var ago = "";
                    //if (currDate.TotalMinutes < 60)
                    //{
                    //    ago = Convert.ToInt32(currDate.TotalMinutes) + " Minute ago";
                    //}
                    //else if (currDate.TotalHours < 24)
                    //{
                    //    ago = currDate.TotalHours.ToString("N0") + " Hours ago";
                    //}
                    //else if (currDate.TotalDays < 30)
                    //{
                    //    ago = currDate.TotalDays.ToString("N0") + " Days ago";
                    //}
                    //else if (currDate.TotalDays < 365 / 30)
                    //{
                    //    ago = currDate.TotalDays.ToString("N0") + " Month ago";
                    //}
                    //else if (currDate.TotalDays > 365)
                    //{
                    //    ago = currDate.TotalDays.ToString("N0") + " Year ago";
                    //}



                    strTestimonials += @"<div class='col-lg-12'>
                                    <div class='testimonial'>
                                <div class='details'>
                                    " + testimonial[i].FullDesc + @"
                                </div>
                               <div class='source'>
                               <span>" + testimonial[i].PostedBy + @" </span>

                              <p> " + testimonial[i].TestimonialName + @" </p>
                        </div>
                        </div>
                </div>";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAllTestimonials", ex.Message);
        }
    }
    [WebMethod]
    public static List<Testimonial> allTestimonials(string pno)
    {
        SqlConnection conMN = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);
        List<Testimonial> Testimonials = null;
        try
        {
            Testimonials = Testimonial.GetAllTestimonial(conMN);
        }
        catch (Exception ex)
        {

            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "allTestimonials", ex.Message);

        }
        return Testimonials;
    }
}
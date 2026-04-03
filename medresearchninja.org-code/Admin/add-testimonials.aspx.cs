using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_add_testimonials : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conMN"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                BindAllTestimonial();
            }
        }
    }



    public void BindAllTestimonial()
    {
        try
        {
            var Testimonials = Testimonial.GetTestimonialById(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (Testimonials != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtPostedBy.Text = Testimonials.PostedBy;
                txtInstitute.Text = Testimonials.TestimonialName;
                txtFullDesc.Text = Testimonials.FullDesc;

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindJobDetails", ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                var aid = Request.Cookies["med_aid"].Value;

                Testimonial test = new Testimonial();

                test.PostedBy = txtPostedBy.Text.Trim();
                test.TestimonialName = txtInstitute.Text.Trim();
                test.FullDesc= txtFullDesc.Text.Trim();
                test.Status = "Active";
                test.AddedOn = TimeStamps.UTCTime();
                test.AddedIp = CommonModel.IPAddress();
                test.AddedBy = aid;
                



                if (btnSave.Text == "Update")
                {
                    test.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = Testimonial.UpdateTestimonial(conSQ, test);
                    if (result > 0)
                    {
                        BindAllTestimonial();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Testimonial Details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                  
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = Testimonial.InsertTestimonial(conSQ, test);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Testimonial Details Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtFullDesc.Text = txtInstitute.Text = txtPostedBy.Text = "";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please fill all required fields.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-testimonials.aspx", false);
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Online_Examination
{
    public partial class SiteMaster1 : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {                
                int mid=Convert.ToInt32(Session["mid"]);
                MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand ca = new MySqlCommand();
            ca.CommandText = "select * from usr_data where mid=@mid";
            ca.Parameters.AddWithValue("mid", Convert.ToInt32(Session["mid"]));
            ca.Connection = con;            
            MySqlDataReader dr = ca.ExecuteReader();
                if (dr.Read() == true)
                {
                    login_name.Text = dr[1].ToString();
                    con.Close();
                    
                }
                else
                {
                    login_name.Text = "error";
                }
                    
                
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(Session["mid"]);
            if (mid.Equals(null) || (mid == 0))
            {
                pre_login.Visible = true;

            }
            else
            {
                post_login.Visible = true;
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Abandon();
        }


        protected void loginform_submit(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand ca = new MySqlCommand();
            ca.CommandText = "select * from usr_data where uname=@a and pswd=@b";
            ca.Connection = con;

            ca.Parameters.AddWithValue("a", Username.Text);
            ca.Parameters.AddWithValue("b", Password.Text);
            MySqlDataReader dr = ca.ExecuteReader();
            if (dr.Read() == true)
            {
                Session["name"] = dr[1].ToString();
                Session["mid"] = dr[0].ToString();
                if (dr[5].ToString() == "student")
                {
                    con.Close();
                    Response.Redirect("Home.aspx");
                }

                else
                {
                    Response.Redirect("Home.aspx#login_form");
                    Username.Focus();
                    Label2.Text = "Error";
                }
                dr.Close();


            }


        }
    }
}
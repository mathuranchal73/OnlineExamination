using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;

namespace OnlineExam
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void doUpload(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            System.Threading.Thread.Sleep(4000);
            if (AsyncFileUpload1.HasFile)
            {
                string filename = Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);

                AsyncFileUpload1.SaveAs(Server.MapPath("UploadImages/" + filename));


            }


        }
        protected void Username_Changed(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand ca = new MySqlCommand();
            ca.CommandText = "select * from usr_data where uname=@a";
            ca.Connection = con;

            ca.Parameters.AddWithValue("a", UserName.Text);
            MySqlDataReader dr = ca.ExecuteReader();
            if (dr.Read() == true)
            {
                Username_available.Visible = true;
                Username_available.Text = UserName.Text + " Not Available";
                SetFocus(UserName);


            }
            else
            {
                Username_available.Visible = true;
                Username_available.Text = UserName.Text + "Available";


            }

            dr.Close();
        }

        protected void Register(object sender, EventArgs e)
        {
            if (terms.Checked == true)
            {
                if (Page.IsValid) //Will be true if captcha text is correct otherwise it will be false
                {
                    string filename = Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
                    MySqlCommand ca = new MySqlCommand("select  ifnull(max(mid),0) + 1 from usr_data", con);
                    con.Open();                    
                    int mid = Convert.ToInt32(ca.ExecuteScalar());
                    // insert row into usr_data

                    ca.Parameters.Clear();
                    ca.CommandText = "insert into usr_data values(@mid,@fname,@lname,@uname,@email,@pswd,@img,@terms,@usr_role,Now(),Now())";
                    ca.Connection = con;
                    ca.Parameters.AddWithValue("fname", fname.Text);
                    ca.Parameters.AddWithValue("lname", lname.Text);
                    ca.Parameters.AddWithValue("uname", UserName.Text);
                    ca.Parameters.AddWithValue("email", Email.Text);
                    ca.Parameters.AddWithValue("pswd", Password.Text);
                    ca.Parameters.AddWithValue("img", "UploadImages/" + filename);
                    ca.Parameters.AddWithValue("terms", 1);
                    ca.Parameters.AddWithValue("usr_role", "student");
                    ca.Parameters.Add("@mid",MySqlDbType.Int32).Value = mid;                    
                    Session["mid"] = mid;
                    ca.ExecuteNonQuery();
                    Response.Redirect("Home.aspx");
                }

                else
                {
                    captcharesult.Visible = true;
                    captcharesult.Text = "*Incorrect Captcha";

                }
            }
            else
                terms.Text = "*Please Check the Terms & Conditions";
        }


    }
}

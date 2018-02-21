using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;


namespace OnlineExam
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Submit_Exam(object sender, EventArgs e)
        {
            String sname;
            int sid;
            
            int mid = Convert.ToInt32(Session["mid"].ToString());
            //sid = ddlSubjects.SelectedItem.Value;
            sname = ddlSubjects.SelectedItem.Text;
            if (sname == "VB.NET")
            {
                sid = 1;
            }
            else if (sname == "ASP.NET")
            {
                sid = 2;
            }
            else if (sname == "C#.NET")
            {
                sid = 3;
            }
            else if (sname == "Java")
            {
                sid = 4;
            }
            else
            {
                sid = 5;
            }

            Examination exam = new Examination(mid, sid, sname);
            exam.GetQuestions();
            Response.Write("done");
            Session.Add("questions", exam);
            Response.Redirect("examination.aspx");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(Session["mid"]);            
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand ca = new MySqlCommand();
            ca.CommandText = "select * from usr_data where mid=@a";
            ca.Connection = con;
            ca.Parameters.AddWithValue("a", mid);
            MySqlDataReader dr = ca.ExecuteReader();
            if (dr.Read() == true)
            {

                profile_img.ImageUrl = dr[6].ToString();
                name.Text = dr[1].ToString() + "" + dr[2].ToString();

            }
            else
            {
                Response.Write("Error");
            }
            dr.Close();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Online_Examination
{
    public partial class showresult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // show exam result
            Examination exam = (Examination)Session["questions"];
            lblSubject.Text = exam.sname;
            lblStime.Text = exam.StartTime.ToString(); TimeSpan ts = DateTime.Now.Subtract(exam.StartTime);
            lblMin.Text = ts.Minutes.ToString();
            lblNquestions.Text = exam.SIZE.ToString();
           
            // find how many correct answers
            int cnt = 0;
            foreach (Question q in exam.questionlist)
            {
                if (q.IsCorrect())
                    cnt++;
            }

            lblNcans.Text = cnt.ToString();
            exam.ncans = cnt;
            Session.Add("questions", exam);

            if (cnt > 3)
                lblGrade.Text = "Excellent";
            else
                if (cnt > 1)
                    lblGrade.Text = "Average";
                else
                    lblGrade.Text = "Poor";
            // add row to OE_EXAMS table
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select ifnull( max(examid),0) + 1 from oe_exams", con);
            Int32 examid = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.CommandText = "insert into oe_exams values(@examid,@mid,@sid,@noq,@ncans,@stdate,Now())";
            cmd.Parameters.Add("@examid", MySqlDbType.Int32).Value = examid;
            cmd.Parameters.Add("@mid", MySqlDbType.Int32).Value = exam.mid;
            cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = exam.sid;
            cmd.Parameters.Add("@noq", MySqlDbType.Int32).Value = exam.SIZE;
            cmd.Parameters.Add("@ncans", MySqlDbType.Int32).Value = exam.ncans;
            cmd.Parameters.Add("@stdate", MySqlDbType.DateTime).Value = exam.StartTime;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        
       

        protected void lbRank_Click(object sender, EventArgs e)
        {

            Examination exam = (Examination)Session["questions"];
            double per = (double)exam.ncans / exam.SIZE;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) from oe_exams where nocans * 1.0 / noq >= @per and  sid = @sid", con);
            cmd.Parameters.Add("@per", MySqlDbType.Decimal).Value = per;
            cmd.Parameters.Add("@sid", MySqlDbType.Int32).Value = exam.sid;
            int rank = Convert.ToInt32(cmd.ExecuteScalar());

            cmd.CommandText = "select count(*) from oe_exams where sid = @sid";
            int total = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            lblRank.Text = "<h4>Your Rank : " + rank.ToString() + " out of " + total.ToString() + " </h4>";

        }
    }
}
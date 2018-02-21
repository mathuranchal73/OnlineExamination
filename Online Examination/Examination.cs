using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;



/// <summary>
/// Summary description for Examination
/// </summary>
public class Examination
{
    public int SIZE = 5;
    public int mid;
    public int sid;
    public String sname;
    public int ncans;
    public List<Question> questionlist;
    public DateTime StartTime;
    public int curpos = 0;
    public Examination(int mid, int sid, String sname)
    {
        this.mid = mid;
        this.sid = sid;
        this.sname = sname;
        StartTime = DateTime.Now;
    }
    public void GetQuestions()
    {
        // get questions from OE_QUESTIONS table
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"SERVER=localhost;DATABASE=dbo;UID=root;PASSWORD=;";
        con.Open();
        MySqlDataAdapter da = new MySqlDataAdapter("select question,ans1,ans2,ans3,ans4,cans from oe_questions where sid = " + sid, con);
        DataSet ds = new DataSet();
        questionlist = new List<Question>();
        da.Fill(ds, "questionlist");
        int nquestions = ds.Tables[0].Rows.Count;

        /* // get N no. of random number
         Random r = new Random();
         int[] positions = new int[SIZE];
         int num;
         for (int pos = 0; pos < SIZE; )
         {
             num = Math.Abs(r.Next(nquestions));
             // check whether the number is already in the array
             bool found = false;
             for (int i = 0; i < pos; i++)
                 if (num == positions[i]) { found = true; break; }

             if (!found)
             {
                 positions[pos] = num;
                 pos++;
             }
         } // end of for*/

        // load data from DataSet into Question Objects

        DataRow dr;
        Question q;
        //foreach (int pos in positions)
        for (int i = 0; i <= 4; i++)
        {

            dr = ds.Tables[0].Rows[i];

            q = new Question(dr["question"].ToString(), dr["ans1"].ToString(), dr["ans2"].ToString(), dr["ans3"].ToString(), dr["ans4"].ToString(), dr["cans"].ToString());
            questionlist.Add(q);

        }
    }
}


  


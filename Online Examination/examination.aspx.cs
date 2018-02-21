using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination
{
    public partial class examination : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
       
       
         int totltime = 300,totltimemin;
        
        if (!Page.IsPostBack)
        {
           
                totltimemin = totltime / 60;
                Session["time"] = DateTime.Now.AddSeconds(totltime);
                DisplayQuestion();
                Label4.Text = "" + totltimemin.ToString() + "" + "minutes";
            }
       
        
       
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        TimeSpan time1 = new TimeSpan();
        time1 = ((DateTime)Session["time"]) - DateTime.Now;
        if (time1.Minutes <= 0 && time1.Seconds <= 0)
        {
            Label3.Text = "TimeOut!";
            ProcessQuestion();
            Examination exam = (Examination)Session["questions"];
            if (exam.curpos == exam.SIZE - 1)
                Response.Redirect("showresult.aspx");
            else
            {
                exam.curpos++;
                Session.Add("questions", exam);
                DisplayQuestion();
            }
            
            
            
        }
        else
        {
            Label3.Text = String.Format("{0} minutes  {1} seconds ", time1.Minutes.ToString(), time1.Seconds.ToString());
            
        }

    }

    public void DisplayQuestion()
    {
        // get data from session object
        Examination e = (Examination)Session["questions"];
        // display data
        lblSubject.Text = e.sname;
        lblQno.Text = e.curpos + 1 + "/" + e.SIZE;
        lblCtime.Text = DateTime.Now.ToString();
        lblStime.Text = e.StartTime.ToString();

        Question q = e.questionlist[e.curpos];
        // display details of question
        question.InnerHtml = q.question;
        ans1.InnerHtml = q.ans1;
        ans2.InnerHtml = q.ans2;
        ans3.InnerHtml = q.ans3;
        ans4.InnerHtml = q.ans4;
        
        // reset all radio buttons
        rbAns1.Checked = false;
        rbAns2.Checked = false;
        rbAns3.Checked = false;
        rbAns4.Checked = false;

        // disable and enable buttons
        if (e.curpos == 0)
        {
            btnPrev.Enabled = false;
            
        }
        else
            btnPrev.Enabled = true;
       
        if (e.curpos == 1)
        {
            Examination exam = (Examination)Session["questions"];
            DataList1.DataSource = exam.questionlist;
            DataList1.DataBind();
        
          
           
        }
        else if (e.curpos == 2)
        {
            Examination exam = (Examination)Session["questions"];
            DataList1.DataSource = exam.questionlist;
            DataList1.DataBind();
           
        }
        else if (e.curpos == 3)
        {
            Examination exam = (Examination)Session["questions"];
            DataList1.DataSource = exam.questionlist;
            DataList1.DataBind();
           
        }
        else if (e.curpos == 4)
        {
            Examination exam = (Examination)Session["questions"];
            DataList1.DataSource = exam.questionlist;
            DataList1.DataBind();
           
           
          
        }
       
        if (e.curpos == e.SIZE - 1)
            btnNext.Text = "Finish";
        else
            btnNext.Text = "Next";
    }

    public void ProcessQuestion()
    {
        Examination exam = (Examination)Session["questions"];
        Question q = exam.questionlist[exam.curpos];
        String answer;
        // find out the answer and assign it to 
        if (rbAns1.Checked)
            answer = "1";
        else
            if (rbAns2.Checked)
                answer = "2";
            else
                if (rbAns3.Checked)
                    answer = "3";
                else
                    if (rbAns4.Checked)
                        answer = "4";
                    else
                        answer = "0";  // error
        q.answer = answer;
        exam.questionlist[exam.curpos] = q;
        Session.Add("questions", exam);
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        ProcessQuestion();
        Examination exam = (Examination)Session["questions"];
        if (exam.curpos == exam.SIZE - 1)
            Response.Redirect("showresult.aspx");
        else
        {
            exam.curpos++;
            Session.Add("questions", exam);
            DisplayQuestion();
        }
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        // ProcessQuestion();
        Examination exam = (Examination)Session["questions"];
        exam.curpos--;
        Session.Add("questions", exam);
        DisplayQuestion();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Examination exam = (Examination)Session["questions"];
        Session.Remove("questions");
        //exam = null;
        Response.Redirect("Default.aspx");
    }
    }
}
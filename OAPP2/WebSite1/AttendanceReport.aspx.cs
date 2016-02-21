using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class AttendanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["Date"] != null)
        {
            Label1.Text = "Attendance for " + Request.QueryString["Date"];
            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(Request.QueryString["Date"], "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
               
            }
            AttendanceLogic al = new AttendanceLogic();
            Repeater2.DataSource = al.SelectForAttendanceReport(d1);
            Repeater2.DataBind();
        }
        else
        {
            Label1.Text = "Today's Attendance";
            AttendanceLogic al = new AttendanceLogic();
            Repeater2.DataSource = al.SelectForAttendanceReport(DateTime.Today);
            Repeater2.DataBind();
        }
       
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using System.Data.SqlClient;

public partial class ViewAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN"))
        {

            AttendanceLogic al = new AttendanceLogic();
            DataTable dt = al.Select();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            if (dt.Rows.Count == 0)
            {
                Table1.Visible = false;
                Label3.Visible = true;
            }
            else
            {
                Table1.Visible = true;
                Label3.Visible = false;
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals(""))
        {
            Label2.Visible = true;
        }
        else
        {

            AttendanceLogic al = new AttendanceLogic();

            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {

            }
            DataTable dt = al.Search(d1);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            if (dt.Rows.Count == 0)
            {
                Table1.Visible = false;
                Label3.Visible = true;
            }
            else
            {
                Table1.Visible = true;
                Label3.Visible = false;
            }
        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals(""))
        {
            Label1.Visible = true;
        }
        else
        {
            Label1.Visible = false;
            Response.Redirect("AttendanceReport.aspx?Date=" + TextBox1.Text);
        }
    }
}
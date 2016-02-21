using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class EmpAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN"))
        {
            Label1.Text="Employee's Attendance Analysis";
            empreport.Visible = false;
            EmployeeLogic OL = new EmployeeLogic();
            DataTable dt = OL.SelectAll();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        
        repdiv.Visible = false;
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(e.CommandArgument));
        Label1.Text = "Attendance Report for "+e1.Name;
        empreport.Visible = true;
        AttendanceLogic al = new AttendanceLogic();
        DataTable dt = al.SelectForEmp(Convert.ToInt32(e.CommandArgument));
        Repeater2.DataSource = dt;
        Repeater2.DataBind(); 

    }
}
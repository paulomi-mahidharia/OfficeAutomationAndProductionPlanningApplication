using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EmployeeID"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Session["LastLink"] = Request.Url.PathAndQuery;
        }
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        Label1.Text = e1.Name;
        Image1.ImageUrl = e1.Photo;
        if (e1.Designation.Equals("MANAGING DIRECTOR"))
        {
            MDDiv.Visible = true;
        }
        else if (e1.Designation.Equals("MARKETING MANAGER"))
        {
            MarketingDiv.Visible = true;
        }
        else if (e1.Designation.Equals("MARKETING EMPLOYEE"))
        {
            MarketingDiv.Visible = true;
        }
        else if (e1.Designation.Equals("DESIGNER"))
        {
            DesignerDiv.Visible = true;
        }
        else if (e1.Designation.Equals("COMERCIAL MANAGER"))
        {
            ComercialDiv.Visible = true;
        }
        else if (e1.Designation.Equals("COMERCIAL EMPLOYEE"))
        {
            ComercialDiv.Visible = true;
        }
        else if (e1.Designation.Equals("STOCK MANAGER"))
        {
            StockDiv.Visible = true;
        }
        else if (e1.Designation.Equals("STOCK EMPLOYEE"))
        {
            StockDiv.Visible = true;
        }
        else if (e1.Designation.Equals("PRODUCTION MANAGER"))
        {
            ProDiv.Visible = true;
        }
        else if (e1.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            ProDiv.Visible = true;
        }
        else if (e1.Designation.Equals("HR MANAGER"))
        {
            HRDiv.Visible = true;
        }
        else if (e1.Designation.Equals("HR EMPLOYEE"))
        {
            HRDiv.Visible = true;
        }
        else if (e1.Designation.Equals("EMPLOYEE"))
        {
            EmpDiv.Visible = true;
        }
        else if (e1.Designation.Equals("CHAIRMAN"))
        {
            MDDiv.Visible = true;
        }
        else if (e1.Designation.Equals("ACCOUNTATANT"))
        {
            AccDiv.Visible = true;
        }





        DataTable dt = new AttendanceLogic().SelectForAttendanceReport(DateTime.Today);

        float present = Convert.ToSingle(dt.Rows[0][1]);
        float absent = Convert.ToSingle(dt.Rows[1][1]);


        lblPResentPerc.Text = (present * 100) / (present + absent)+"";
        attendanceperc.Attributes["aria-valuenow"] = (present * 100) / (present + absent) + "";
        attendanceperc.Attributes["style"] = "width: "+((present * 100) / (present + absent)) + "%";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        Session["EmployeeID"] = null;
        Response.Redirect("login.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));

        Session["PhotoPath"] = e1.Photo;
        Session["LockID"]=Session["EmployeeID"];
        Response.Redirect("Lock_screen.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
}

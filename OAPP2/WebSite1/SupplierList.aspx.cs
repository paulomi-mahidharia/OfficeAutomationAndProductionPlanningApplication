using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class SupplirList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN"))
        {
            SupplierLogic SL = new SupplierLogic();
            DataTable dt = SL.SelectAll();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            if (dt.Rows.Count == 0)
            {
                Table1.Visible = false;
                Label1.Visible = true;
            }
            else
            {
                Table1.Visible = true;
                Label1.Visible = false;
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            SupplierLogic sl = new SupplierLogic();
            Supplier e1 = sl.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (e1 != null)
            {
                int i = sl.Delete(e1.SupplierID);
                Response.Redirect("SupplierList.aspx");
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("SupplierHistory.aspx?ID="+e.CommandArgument);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SupplierLogic sl = new SupplierLogic();
        DataTable dt = sl.Search(TextBox1.Text);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        if (dt.Rows.Count == 0)
        {
            Table1.Visible = false;
            Label1.Visible = true;
        }
        else
        {
            Table1.Visible = true;
            Label1.Visible = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class CustomerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MARKETING MANAGER") || e2.Designation.Equals("MARKETING EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER") || e2.Designation.Equals("EMPLOYEE"))
        {
             
            if(!IsPostBack){
                CustomerLogic CL = new CustomerLogic();
                DataTable dt = CL.SelectAll();

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
        else
        {
            Response.Redirect("Access.aspx");
        }


    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MARKETING MANAGER") || e2.Designation.Equals("MARKETING EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER"))
        {
            CustomerLogic cl = new CustomerLogic();
            Customer c1 = cl.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (c1 != null)
            {
                int i = cl.Delete(c1.CustomerID);
                Response.Redirect("CustomerList.aspx");
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CustomerLogic cl = new CustomerLogic();
        DataTable dt = cl.Search(TextBox2.Text);

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

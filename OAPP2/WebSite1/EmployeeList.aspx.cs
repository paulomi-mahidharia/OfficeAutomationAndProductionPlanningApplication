using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class EmployeeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        
            


            if (!IsPostBack)
            {
                if (!e2.Designation.Equals("DESIGNER"))
                {
                EmployeeLogic EL = new EmployeeLogic();
                DataTable dt1 = EL.SelectDes();
                dt1.Rows.Add("All Designation");
                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "Designation";
                DropDownList1.DataValueField = "Designation";
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = "All Designation";
                DataTable dt = EL.SelectAll();
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

       
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE"))
        {
            
            Employee e1 = el.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (e1 != null)
            {
                int i = el.Delete(e1.EmployeeID);
                Response.Redirect("EmployeeList.aspx");
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        DataTable dt = el.Search(TextBox2.Text,DropDownList1.Text);

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
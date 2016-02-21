using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class RawMatList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            if (!IsPostBack)
            {
                RawMaterialLogic RL = new RawMaterialLogic();
                DataTable dt = RL.SelectAllJoined();
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

                RawMaterialLogic rl = new RawMaterialLogic();
                DataTable dt1 = rl.SelectAll();
                dt1.Rows.Add(0, null, null, null, null, null, null, "All Category", null);
                dt1.DefaultView.Sort = "SupplierID";
                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "Category";
                DropDownList1.DataValueField = "SupplierID";
                //DropDownList1.DataBind();
                DropDownList1.SelectedItem.Text = "All Category";

                SupplierLogic sl = new SupplierLogic();
                DataTable dt2 = sl.SelectAll();
                dt2.Rows.Add(0, "All Supplier", null, null, null);
                dt2.DefaultView.Sort = "SupplierID";
                DropDownList2.DataSource = dt2;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "SupplierID";
                DropDownList2.DataBind();
                DropDownList2.SelectedItem.Text = "All Supplier";
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        RawMaterialLogic rl = new RawMaterialLogic();
        DataTable dt = rl.Search(TextBox1.Text,DropDownList1.SelectedItem.Text,Convert.ToInt32(DropDownList2.SelectedItem.Value));
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
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            RawMaterialLogic rl = new RawMaterialLogic();
            RawMaterial r1 = rl.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (r1 != null)
            {
                int i = rl.Delete(r1.RawMaterialID);
                if (i==1)
                {
                    Response.Redirect("RawMatList.aspx");
                }
                else
                {
                    Response.Redirect("CustomerList.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }

    }
}
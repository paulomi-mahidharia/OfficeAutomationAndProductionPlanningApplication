using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class SupplierHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN"))
        {
            if (!IsPostBack)
            {
                SupplierLogic SL = new SupplierLogic();
                DataTable dt = SL.SelectHistory(Convert.ToInt32(Request.QueryString["ID"]));
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                if (dt.Rows.Count == 0)
                {
                    Table1.Visible = false;
                    Label2.Visible = true;
                }
                else
                {
                    Table1.Visible = true;
                    Label2.Visible = false;
                    Label1.Text = dt.Rows[0]["Name"].ToString();
                }
               
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SupplierLogic SL = new SupplierLogic();
        DateTime d1 = new DateTime();
        DateTime d2 = new DateTime();
       
            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                d1 = DateTime.Now.AddYears(-100);
            }

            if (!DateTime.TryParseExact(TextBox3.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
            {
                d2 = DateTime.Now.AddYears(10);
            }
       
        DataTable dt = SL.SearchHistory(Convert.ToInt32(Request.QueryString["ID"]),TextBox1.Text,d1,d2);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        if (dt.Rows.Count == 0)
        {
            Table1.Visible = false;
            Label2.Visible = true;
        }
        else
        {
            Table1.Visible = true;
            Label2.Visible = false;
        }
    }
}
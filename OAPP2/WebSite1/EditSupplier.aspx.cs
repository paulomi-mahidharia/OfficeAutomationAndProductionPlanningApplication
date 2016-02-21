using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class EditSupplier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            if (!IsPostBack)
            {
                SupplierLogic sl = new SupplierLogic();
                Supplier s1 = sl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
                TextBox1.Text = s1.Name;
                TextBox2.Text = s1.Email;
                TextBox3.Text = s1.ContactPerson;
                TextBox8.Text = s1.Phone;
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((Convert.ToInt32(Request.QueryString["id"])) > 0)
        {
            Supplier s1 = new Supplier();
            s1.Name = TextBox1.Text;
            s1.Phone = TextBox8.Text;
            s1.Email = TextBox2.Text;
            s1.ContactPerson = TextBox3.Text;
            s1.SupplierID = Convert.ToInt32(Request.QueryString["id"]);
            SupplierLogic sl = new SupplierLogic();
            sl.Update(s1);

            Response.Redirect("SupplierList.aspx");
        }
        else
        {
            Supplier s1 = new Supplier();
            s1.Name = TextBox1.Text;
            s1.Phone = TextBox8.Text;
            s1.Email = TextBox2.Text;
            s1.ContactPerson = TextBox3.Text;

            SupplierLogic sl = new SupplierLogic();
            sl.Insert(s1);

            Response.Redirect("SupplierList.aspx");
        }
    }
}
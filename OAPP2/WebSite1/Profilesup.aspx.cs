using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;



public partial class Profilesup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN"))
        {
            SupplierLogic sl = new SupplierLogic();
            Supplier c1 = sl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

            if (c1 != null)
            {

                Label1.Text = c1.Name;
                Label2.Text = c1.Email;
                Label3.Text = c1.ContactPerson;
                Label4.Text = c1.Phone;
          
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
}
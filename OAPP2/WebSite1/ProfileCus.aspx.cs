using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MARKETING MANAGER") || e2.Designation.Equals("MARKETING EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER") || e2.Designation.Equals("EMPLOYEE"))
        {
            CustomerLogic cl = new CustomerLogic();
            Customer c1 = cl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

            if (c1 != null)
            {

                Label1.Text = c1.Name;
                Label2.Text = c1.Email;
                Label3.Text = c1.ContactPerson;
                Label4.Text = c1.Phone;
                Label5.Text = c1.OfficeAddress;
                Label6.Text = c1.DeliveryAddress;

                Label7.Text = c1.FactoryAddress;
                Label8.Text = c1.GodownAddress;
                Label9.Text = c1.OtherAddress;
                Label10.Text = c1.HeadOffice;
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class EditCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MARKETING MANAGER") || e2.Designation.Equals("MARKETING EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER"))
        {
            if (!IsPostBack)
            {
                CustomerLogic CL = new CustomerLogic();
                Customer c1 = CL.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
                TextBox1.Text = c1.Name;
                TextBox2.Text = c1.Email;
                TextBox3.Text = c1.ContactPerson;
                TextBox8.Text = c1.Phone;
                TextArea1.Text = c1.OfficeAddress;
                TextBox5.Text = c1.DeliveryAddress;
                TextBox6.Text = c1.FactoryAddress;
                TextBox7.Text = c1.GodownAddress;
                TextBox9.Text = c1.OtherAddress;
                TextBox4.Text = c1.HeadOffice;
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if((Convert.ToInt32(Request.QueryString["id"])>0))
        {

            CustomerLogic CL = new CustomerLogic();
            Customer c1 = new Customer();
            c1.Name = TextBox1.Text;
            c1.Email = TextBox2.Text;
            c1.Phone = TextBox8.Text;
            c1.ContactPerson = TextBox3.Text;
            c1.OfficeAddress = TextArea1.Text;
            c1.DeliveryAddress = TextBox5.Text;
            c1.HeadOffice = TextBox4.Text;
            c1.FactoryAddress = TextBox6.Text;
            c1.GodownAddress = TextBox7.Text;
            c1.OtherAddress = TextBox9.Text;
            c1.CustomerID = Convert.ToInt32(Request.QueryString["id"]);
            CL.Update(c1);
            Response.Redirect("CustomerList.aspx");
        
        }
        else
        {
            Customer c1 = new Customer();
            c1.Name = TextBox1.Text;
            c1.Email = TextBox2.Text;
            c1.Phone = TextBox8.Text;
            c1.ContactPerson = TextBox3.Text;
            c1.OfficeAddress = TextArea1.Text;
            c1.DeliveryAddress = TextBox5.Text;
            c1.HeadOffice = TextBox4.Text;
            c1.FactoryAddress = TextBox6.Text;
            c1.GodownAddress = TextBox7.Text;
            c1.OtherAddress = TextBox9.Text;

            CustomerLogic CL = new CustomerLogic();
            CL.Insert(c1);

            Response.Redirect("CustomerList.aspx");
        }
      
    }
}
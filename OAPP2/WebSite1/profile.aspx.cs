using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeLogic el = new EmployeeLogic();
            Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
            if (!e2.Designation.Equals("DESIGNER"))
            {

                Employee e1;

                if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                {
                    e1 = el.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
                }
                if (e1 != null)
                {
                    //Image1.ImageUrl = "Images/" + e1.Photo;
                    Image1.ImageUrl = e1.Photo;
                    Label1.Text = e1.Name;
                    Label2.Text = e1.Address;
                    Label3.Text = e1.Email;
                    Label4.Text = e1.Phone;
                    Label5.Text = e1.DOB.ToString("dd/MM/yyyy"); ;
                    Label6.Text = e1.DOJ.ToString("dd/MM/yyyy");

                    Label7.Text = e1.Gender;
                    Label8.Text = e1.Designation;
                }
            }
            else
            {
                Response.Redirect("Access.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class ProfileProd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (!IsPostBack)
        {
            if (!(e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
            {
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"])); ;

                if (p1 != null)
                {
                    Label1.Text = p1.Name;
                    Label2.Text = p1.CreateDate.ToString("dd/MM/yyyy");

                    String st = p1.DesignFiles;
                    String[] arr = st.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length > 0)
                    {
                        lnkImage1.Text = arr[0].Substring(25);
                        lnkImage1.NavigateUrl = arr[0];
                    }
                    else
                    {
                        lnkImage1.Visible = false;
                    }

                    if (arr.Length > 1)
                    {
                        lnkImage2.Text = arr[1].Substring(25);
                        lnkImage2.NavigateUrl = arr[1];
                    }
                    else
                    {
                        lnkImage2.Visible = false;
                    }
                    if (arr.Length > 2)
                    {
                        lnkImage3.Text = arr[2].Substring(25);
                        lnkImage3.NavigateUrl = arr[2];
                    }
                    else
                    {
                        lnkImage3.Visible = false;
                    }
                    if (arr.Length > 3)
                    {
                        lnkImage4.Text = arr[3].Substring(25);
                        lnkImage4.NavigateUrl = arr[3];
                    }
                    else
                    {
                        lnkImage4.Visible = false;
                    }
                    if (arr.Length > 4)
                    {
                        lnkImage5.Text = arr[4].Substring(25);
                        lnkImage5.NavigateUrl = arr[4];
                    }
                    else
                    {
                        lnkImage5.Visible = false;
                    }
                    Label4.Text = p1.Status;
                    Label5.Text = p1.Description;
                    Label6.Text = p1.Size;
                    Label7.Text = p1.Colors;
                    Label8.Text = p1.Type;

                    CustomerLogic cl = new CustomerLogic();
                    Customer c1 = cl.SelectByID(p1.CustomerID);
                    Label9.Text = c1.Name;

                }
            }
            else
            {
                Response.Redirect("Access.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BusinessLogic;
using System.Data;


public partial class LockScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {/*
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        Image1.ImageUrl = "Images/" + e1.Photo;
    */}

    protected void Button1_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e1.EmployeeID > 0)
        {
            if (TextBox1.Text.Equals(e1.Password))
            {
                Response.Redirect("Home.aspx");
     
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            Session["EmployeeID"] = null;
            Label3.Visible = false;
            if (!(Request.QueryString["UN"] == null && Request.QueryString["PW"] == null))
            {
                EmployeeLogic el = new EmployeeLogic();
                Employee e1 = el.selectUP(Request.QueryString["UN"], Request.QueryString["PW"]);
                if (e1.EmployeeID > 0)
                {
                    Session["EmployeeID"] = e1.EmployeeID;
                    Response.Redirect("AllReports.aspx");

                }
            }

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
       if ((TextBox3.Text.Equals("")) && (TextBox2.Text.Equals("")))
        {
            Label3.Visible = true;
           
        }
        
       
       else if (TextBox2.Text.Equals(""))
       {
           Label2.Visible = true;
       }
        else if (TextBox3.Text.Equals(""))
        {
            Label1.Visible = true;
        }
       else
       {
           EmployeeLogic el = new EmployeeLogic();
           Employee e1 = el.selectUP(TextBox3.Text, TextBox2.Text);
           if (e1.EmployeeID > 0)
           {
               Session["EmployeeID"] = e1.EmployeeID;
               Response.Redirect("home.aspx");

           }
           else
           {
               //Response.Redirect("login.aspx");
               Label3.Text = "Invalid Username or Password";
               Label3.Visible = true;
           }
       }
    }

}
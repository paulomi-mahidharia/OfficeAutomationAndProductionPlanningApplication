using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (TextBox1.Text.Equals(e1.Password))
        {
            if (txtPassword.Text.Equals(TextBox3.Text))
            {
                e1.Password = txtPassword.Text;
                el.Update(e1);
                Response.Redirect("home.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(txtPassword, this.GetType(), "alertMessage", "alert('Password do not match, Please enter the password again')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(TextBox1, this.GetType(), "alertMessage", "alert('"+e1.Password+"')", true);
           
        }
    }
}
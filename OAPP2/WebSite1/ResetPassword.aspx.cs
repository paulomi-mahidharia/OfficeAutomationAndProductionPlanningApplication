using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtPassword.Text.Equals(TextBox3.Text))
        {
            EmployeeLogic el = new EmployeeLogic();

            if (Request.QueryString["uic"] != null)
            {
                Employee e1 = el.SelectByUIC((Request.QueryString["uic"]));
                e1.Password = TextBox3.Text;
                el.Update(e1);
                Response.Redirect("Login.aspx");
            }
            else if (Request.QueryString["code"] != null)
            {
                Employee e1 = el.SelectByCode((Request.QueryString["code"]));
                e1.Password = TextBox3.Text;
                el.Update(e1);
                Response.Redirect("Login.aspx");
            }
        }
        else
        {
            Label1.Visible = true;
        }
    }
}
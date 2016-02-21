using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class SCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e1 = el.SelectByCode(TextBox2.Text);

        if (e1!=null)
        {
            Response.Redirect("ResetPassword.aspx?code=" + e1.SMSCode);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class Lock_screen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            Session["EmployeeID"] = null;
            myimage.Src = Session["PhotoPath"].ToString();
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e1=el.SelectByID(Convert.ToInt32(Session["LockID"]));
        Employee e2=el.selectUP(e1.Username, TextBox1.Text);
        if (e2.EmployeeID > 0)
        {
            Session["EmployeeID"] = e2.EmployeeID;
            Response.Redirect(Session["LastLink"].ToString());
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(Invalid Password!)", true);
        }
    }
}
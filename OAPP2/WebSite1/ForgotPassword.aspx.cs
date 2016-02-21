using System;
using System.Collections.Generic;
using ASPSnippets.SmsAPI;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            Response.Redirect("PassRecoveryOption.aspx?type=Email");
        }
        else if (RadioButton2.Checked)
        {
            Response.Redirect("PassRecoveryOption.aspx?type=SMS");
        }
        else
        {
            Label1.Text = "Select atleast one option!";
            Label1.Visible = true;
        }
    }
}
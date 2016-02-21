using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class Report1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerLogic CL = new CustomerLogic();
        Repeater1.DataSource = CL.SelectForReport1();
        Repeater1.DataBind();

        Repeater2.DataSource = CL.SelectForReport1();
        Repeater2.DataBind();
    }
    
}
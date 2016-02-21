using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class ProPlanning : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransitionLogic tl = new TransitionLogic();
        DataTable dt = tl.SelectForOrderReport();
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
   
}
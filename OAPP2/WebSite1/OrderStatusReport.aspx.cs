using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class OrderStatusReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TransitionLogic ol = new TransitionLogic();
        Repeater9.DataSource = ol.SelectOrderStatus1(DateTime.Today);
        Repeater9.DataBind();
    }
    
}
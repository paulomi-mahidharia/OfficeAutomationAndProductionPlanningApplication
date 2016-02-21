using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class TodayStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt6 = new InventoryLogic().SelectRawStock();
        Repeater1.DataSource = dt6;
        Repeater1.DataBind();
    }
}
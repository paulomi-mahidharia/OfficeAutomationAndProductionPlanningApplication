using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;


public partial class Stock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt6 = new InventoryLogic().SelectRawStock();
    
       
        Repeater2.DataSource = dt6;
        Repeater2.DataBind();
    }
    
}
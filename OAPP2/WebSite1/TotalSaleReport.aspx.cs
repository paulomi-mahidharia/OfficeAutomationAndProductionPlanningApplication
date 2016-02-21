using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class TotalSaleReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt5 = new InvoiceLogic().SelectTotalSale2();
        Repeater2.DataSource = dt5;
        Repeater2.DataBind();
    }
   
}
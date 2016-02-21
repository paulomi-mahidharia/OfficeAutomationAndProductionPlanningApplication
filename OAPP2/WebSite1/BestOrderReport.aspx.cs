using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class BestOrderReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt1 = new InvoiceLogic().SelectForBestOrder();

        bestOrd.Text = dt1.Rows[0]["ProductName"].ToString();
        totalAmt.Text = dt1.Rows[0]["GrandTotal"].ToString();
        txtCustomer.Text = dt1.Rows[0]["CustomerName"].ToString();
        string dp = dt1.Rows[0]["ProductImage"].ToString();
        String[] arr = dp.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        proimg.Src = arr[arr.Length - 1];
    }
    
}
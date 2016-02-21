using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class TopProductReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt3 = new ProductLogic().SelectBestProduct();
        OrderNumber.Text = dt3.Rows[0]["Total"].ToString() + " Orders";
        string dp1 = dt3.Rows[0]["DesignFiles"].ToString();
        String[] arr1 = dp1.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        topProimg.Src = arr1[arr1.Length - 1];

        ProName.Text = dt3.Rows[0]["Name"].ToString();
    }
   
}
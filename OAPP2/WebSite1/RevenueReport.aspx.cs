using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class RevenueReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt2 = new InvoiceLogic().SelectForRevenue();
        txtTotIncome.Text = dt2.Rows[0]["TotalIncome"].ToString();

        DataTable dt4 = new InvoiceLogic().SelectIndividualInvoiceAmount();
        string s = "";
        for (int i = 0; i < dt4.Rows.Count; i++)
        {
            s += dt4.Rows[i]["GrandTotal"] + ",";
        }
        s = "[" + s.TrimEnd(',') + "]";
        individualInvoiceAmount.Attributes.Add("data-data", s);
    }
   
}
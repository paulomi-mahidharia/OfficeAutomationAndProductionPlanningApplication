using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new AttendanceLogic().SelectForAttendanceReport(DateTime.Today);

        int present = Convert.ToInt32(dt.Rows[0][1]);
        int absent = Convert.ToInt32(dt.Rows[1][1]);


        lblPResentPerc.Text = ((float)present * 100) / ((float)present + absent) + "";
        lblPResentPerc.Attributes.Add("Present", present.ToString());
        lblPResentPerc.Attributes.Add("Absent", absent.ToString());

        DataTable dt1 = new InvoiceLogic().SelectForBestOrder();

        bestOrd.Text = dt1.Rows[0]["ProductName"].ToString();
        totalAmt.Text = dt1.Rows[0]["GrandTotal"].ToString();
        txtCustomer.Text = dt1.Rows[0]["CustomerName"].ToString();
        string dp = dt1.Rows[0]["ProductImage"].ToString();
        String[] arr = dp.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        proimg.Src = arr[arr.Length - 1];

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


        DataTable dt3 = new ProductLogic().SelectBestProduct();
        OrderNumber.Text = dt3.Rows[0]["Total"].ToString() + " Orders";
        string dp1 = dt3.Rows[0]["DesignFiles"].ToString();
        String[] arr1 = dp1.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        topProimg.Src = arr1[arr1.Length - 1];

        ProName.Text = dt3.Rows[0]["Name"].ToString();
        
        DataTable dt5 = new InvoiceLogic().SelectTotalSale2();
        Repeater2.DataSource = dt5;
        Repeater2.DataBind();
        DataTable dt6 = new InventoryLogic().SelectRawStock();
        Repeater1.DataSource = dt6;
        Repeater1.DataBind();

        CustomerLogic CL = new CustomerLogic();
        Repeater3.DataSource = CL.SelectForReport1();
        Repeater3.DataBind();
        TransitionLogic ol = new TransitionLogic();
        Repeater9.DataSource = ol.SelectProductStatus1(DateTime.Today);
        Repeater9.DataBind();

        TransitionLogic ol2 = new TransitionLogic();
        Repeater4.DataSource = ol2.SelectOrderStatus1(DateTime.Today);
        Repeater4.DataBind();

    }
}
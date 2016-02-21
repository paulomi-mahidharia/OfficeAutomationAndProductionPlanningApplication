using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

public partial class ViewInvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InvoiceLogic il = new InvoiceLogic();
        DataTable dt = il.SelectAllJoined();
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        if (dt.Rows.Count == 0)
        {
            Table1.Visible = false;
            Label1.Visible = true;
        }
        else
        {
            Table1.Visible = true;
            Label1.Visible = false;
        }

    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        InvoiceLogic il = new InvoiceLogic();
        Invoice i1 = il.SelectByID(Convert.ToInt32(e.CommandArgument));
        if (i1 != null)
        {
            int i = il.Delete(i1.InvoiceID);
            Response.Redirect("ViewInvoice.aspx");
        }
    }
   
}
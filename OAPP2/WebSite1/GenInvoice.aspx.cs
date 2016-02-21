using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;


public partial class GenInvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (!IsPostBack)
        {
        if (e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT"))
        {
           
            InvoiceLogic iv=new InvoiceLogic();
            DataTable dt=iv.SelectForInvoice(Convert.ToInt32(Request.QueryString["ID"]));
            Label1.Text = dt.Rows[0]["CustomerName"].ToString();
            TextArea1.InnerText = dt.Rows[0]["OfficeAddress"].ToString();
            TextBox8.Text = "27460000277C";
            TextBox9.Text = "400016/C/6, DTD.01.04.96";
            Label2.Text = dt.Rows[0]["CustomerName"].ToString();
            txt.InnerText = dt.Rows[0]["officeAddress"].ToString();
            TextBox11.Text = "400016/C/6, DTD.01.04.96";
            TextBox12.Text = "27460000277C";
            TextBox16.Text = "27460000277C";
            TextBox17.Text = "400016/C/6, DTD.01.04.96";
            TextBox18.Text = dt.Rows[0]["ProductName"].ToString();
            TextBox33.Text = dt.Rows[0]["Quantity"].ToString();
            TextBox20.Text = dt.Rows[0]["Rate"].ToString();
            txtAmount.Text = (Convert.ToSingle(TextBox33.Text) * Convert.ToSingle(TextBox20.Text)).ToString();
            }
        else
        {
            Response.Redirect("Access.aspx");
        }
        }
       
    }

    protected void btnUpload_OnClick(object sender, EventArgs e)
    {

        InvoiceLogic il = new InvoiceLogic();
        Invoice i1 = new Invoice();
        i1.OrderID = Convert.ToInt32(Request.QueryString["ID"]);
        i1.InvoiceNo = TextBox2.Text;
        DateTime d1 = new DateTime();
        if (!DateTime.TryParseExact(TextBox3.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
        {
            i1.InvoiceDate = DateTime.Today;
        }
        else
        {
            i1.InvoiceDate = d1;
        }
        i1.GrandTotal = Convert.ToSingle(txtGTotal.Text);
        string path;
        string ticks = DateTime.Now.Ticks.ToString();
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
            path = "Images/" + ticks + FileUpload1.FileName;
            i1.InvoicePDF = path;
        }
        il.Insert(i1);
        Response.Redirect("ViewInvoice.aspx");
    }
}
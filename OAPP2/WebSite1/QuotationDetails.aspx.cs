using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;
using System.IO;


public partial class QuotationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE"))
        {
            if (!IsPostBack)
            {
                ProductLogic pl = new ProductLogic();
                DropDownList1.DataSource = pl.SelectAll();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ProductID";
                DropDownList1.DataBind();
                QuotationLogic ql = new QuotationLogic();
                Quotation q1 = ql.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

                if (q1.QuotationID > 0)
                {
                    Product p1 = pl.SelectByProductID(q1.ProductID);
                    DropDownList1.SelectedItem.Value = p1.ProductID.ToString();
                    TextBox1.Text = q1.MOQ.ToString();
                    TextBox2.Text = q1.Rate.ToString();
                    TextBox3.Text = q1.CreateDate.ToString("dd/MM/yyyy");
                    TextBox4.Text = q1.Status;
                    TextBox5.Text = q1.Remarks;
                    TextBox6.Text = q1.TermsConditions;

                }
                else
                {
                    TextBox3.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
       
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {

            QuotationLogic ql = new QuotationLogic();
            Quotation objQuotation = ql.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));

            //objQuotation.ProductID = new ProductLogic().SelectByProductName(DropDownList1.Text).ProductID;
            objQuotation.ProductID =Convert.ToInt32(DropDownList1.SelectedItem.Value);
            objQuotation.MOQ = Convert.ToInt32(TextBox1.Text);
            objQuotation.Rate = Convert.ToInt32(TextBox2.Text);
           // objQuotation.CreateDate = Convert.ToDateTime(TextBox3.Text);
            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox3.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objQuotation.CreateDate = DateTime.Now;
            }
            if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
            {
                objQuotation.CreateDate = DateTime.Now;
            }
            else
            {
                objQuotation.CreateDate = d1;
            }
           
            objQuotation.Status = TextBox4.Text;
            objQuotation.Remarks = TextBox5.Text;
            objQuotation.TermsConditions = TextBox6.Text;
            objQuotation.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
            objQuotation.QuotationPath = "";
            ql.Update(objQuotation);
            Response.Redirect("QuotationList.aspx");
        }
        else
        {
                QuotationLogic ql = new QuotationLogic();
                Quotation objQuotation = new Quotation();

                //objQuotation.ProductID = new ProductLogic().SelectByProductName(DropDownList1.Text).ProductID;
                objQuotation.ProductID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                objQuotation.MOQ = Convert.ToInt32(TextBox1.Text);
                objQuotation.Rate = Convert.ToInt32(TextBox2.Text);
             //   objQuotation.CreateDate = Convert.ToDateTime(TextBox3.Text);
                DateTime d1 = new DateTime();
                if (!DateTime.TryParseExact(TextBox3.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {
                    objQuotation.CreateDate = DateTime.Today;
                }
                if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                {
                    objQuotation.CreateDate = DateTime.Now;
                }
                else
                {
                    objQuotation.CreateDate = d1;
                }
                objQuotation.Status = TextBox4.Text;
                objQuotation.Remarks = TextBox5.Text;
                objQuotation.TermsConditions = TextBox6.Text;
                objQuotation.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
                objQuotation.QuotationPath = "";
                ql.Insert(objQuotation);
                Response.Redirect("QuotationList.aspx");
          
        }
    }
}
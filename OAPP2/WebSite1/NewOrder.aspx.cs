using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class NewOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            if (!IsPostBack)
            {

                ProductLogic pl = new ProductLogic();
                DropDownList1.DataSource = pl.SelectAll();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ProductID";
                DropDownList1.DataBind();

                if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                {

                    OrderLogic ol = new OrderLogic();
                    Order o1 = ol.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

                    Product p1 = pl.SelectByProductID(o1.ProductID);
                    DropDownList1.SelectedItem.Text = p1.Name;
                    QuotationLogic ql = new QuotationLogic();
                    TextBox1.Text = ql.SelectByProductID(Convert.ToInt32(DropDownList1.SelectedValue)).QuotationID.ToString();
                    TextBox2.Text = o1.Quantity.ToString();
                    TextBox3.Text = o1.Rate.ToString();
                    TextBox4.Text = o1.PODate.ToString("dd/MM/yyyy");

                    TextBox5.Text = o1.PONumber.ToString();
                    TextBox6.Text = o1.CreateDate.ToString("dd/MM/yyyy");

                    DropDownList2.SelectedItem.Text = o1.Status;
                    TextBox8.Text = o1.StatusRemarks;
                    TextArea2.Text = o1.DeliveryAddress;
                    TextBox9.Text = o1.DeliveryDate.ToString("dd/MM/yyyy");

                    String po = o1.AttachPO;
                    string ticks = DateTime.Now.Ticks.ToString();
                    if (FileUpload1.HasFile)
                    {
                        FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
                        FileUpload1.Visible = false;
                        lnkImage1.Text = po.Substring(25);
                        lnkImage1.NavigateUrl = po;
                    }
                    else
                    {
                        lnkImage1.Visible = false;
                        LinkButton1.Visible = false;

                    }


                }


                else
                {
                    lnkImage1.Visible = false;
                    LinkButton1.Visible = false;
                    QuotationLogic ql = new QuotationLogic();
                    TextBox1.Text = ql.SelectByProductID(Convert.ToInt32(DropDownList1.SelectedItem.Value)).QuotationID.ToString();
                    TextBox6.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            Label2.Visible = false;
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
            //edit mode
            if (Convert.ToInt32(TextBox1.Text) > 0)
            {
            OrderLogic ol = new OrderLogic();
            Order o1 = ol.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

            ProductLogic pl = new ProductLogic();
            Product p1 = pl.SelectByProductID(o1.ProductID);
            // = Convert.ToInt32(DropDownList1.SelectedValue) 

           
                o1.ProductID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                o1.QuotationID = Convert.ToInt32(TextBox1.Text.ToString());
                o1.Quantity = Convert.ToInt32(TextBox2.Text);
                o1.Rate = Convert.ToInt32(TextBox3.Text);
                DateTime d1 = new DateTime();
                if (!DateTime.TryParseExact(TextBox4.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {
                    d1 = DateTime.Today;
                }
                o1.PODate = d1;

                o1.PONumber = Convert.ToInt32(TextBox5.Text);
                DateTime d2 = new DateTime();
                if (!DateTime.TryParseExact(TextBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
                {
                    d2 = DateTime.Today;
                }
                if (d2.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                {
                    o1.CreateDate = DateTime.Now;
                }
                else
                {
                    o1.CreateDate = d2;
                }
                if (o1.Status.Equals(DropDownList2.SelectedItem.Text))
                {
                    o1.Status = DropDownList2.SelectedItem.Text;
                }
                else
                {
                    TransitionLogic tl = new TransitionLogic();
                    Transition t1 = new Transition();
                    t1.KeyID = o1.OrderID;
                    t1.KeyType = "Ord";
                    t1.TranDate = DateTime.Now;
                    t1.NewStatus = DropDownList2.SelectedItem.Text;
                    t1.Remarks = "";
                    tl.Insert(t1);

                    o1.Status = DropDownList2.SelectedItem.Text;
                }

                o1.StatusRemarks = TextBox8.Text;
                o1.DeliveryAddress = TextArea2.Text;
                DateTime d3 = new DateTime();
                if (!DateTime.TryParseExact(TextBox9.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d3))
                {
                    d3 = DateTime.Today;
                }
                o1.DeliveryDate = d3;

                String po = "";

                string ticks = DateTime.Now.Ticks.ToString();
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
                    po = "Images/" + ticks + FileUpload1.FileName;
                    o1.AttachPO = po;
                }
               

                ol.Update(o1);

                Response.Redirect("OrderList.aspx");
            }
            else
            {
                Label2.Visible = true;
            }
            

        }
        else
        {
            //Insert mode
            if (Convert.ToInt32(TextBox1.Text) > 0)
            {
                OrderLogic ol = new OrderLogic();
                Order o1 = new Order();

                ProductLogic pl = new ProductLogic();

                o1.ProductID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                o1.QuotationID = Convert.ToInt32(TextBox1.Text);
                o1.Quantity = Convert.ToInt32(TextBox2.Text);
                o1.Rate = Convert.ToInt32(TextBox3.Text);
                DateTime d1 = new DateTime();
                if (!DateTime.TryParseExact(TextBox4.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {
                    d1 = DateTime.Today;
                }
                o1.PODate = d1;
                o1.JobPath = "";
                o1.PONumber = Convert.ToInt32(TextBox5.Text);

                DateTime d2 = new DateTime();
                if (!DateTime.TryParseExact(TextBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
                {
                    d2 = DateTime.Today;
                }
                if (d2.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
                {
                    o1.CreateDate = DateTime.Now;
                }
                else
                {
                    o1.CreateDate = d2;
                }

                o1.Status = DropDownList2.SelectedItem.Text;
                o1.StatusRemarks = TextBox8.Text;
                o1.DeliveryAddress = TextArea2.Text;
                DateTime d3 = new DateTime();
                if (!DateTime.TryParseExact(TextBox9.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d3))
                {
                    d3 = DateTime.Today;
                }
                o1.DeliveryDate = d3;

                String po = "";

                string ticks = DateTime.Now.Ticks.ToString();
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
                    po = "Images/" + ticks + FileUpload1.FileName;
                }
                o1.AttachPO = po;
                ol.Insert(o1);

                Response.Redirect("OrderList.aspx");

            }
            else
            {
                Label2.Visible = true;
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        OrderLogic pl = new OrderLogic();
        Order o1 = pl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

        o1.AttachPO = "";
        pl.Update(o1);
        Response.Redirect("OrderList.aspx");

    }

    protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        QuotationLogic ql = new QuotationLogic();
        TextBox1.Text = ql.SelectByProductID(Convert.ToInt32(DropDownList1.SelectedItem.Value)).QuotationID.ToString();
    }
}
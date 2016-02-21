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

public partial class InventoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        
            if (!IsPostBack)
            {
                if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
                {
                RawMaterialLogic rl = new RawMaterialLogic();
                DropDownList1.DataSource = rl.SelectAll();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "RawMaterialID";
                DropDownList1.DataBind();

                InventoryLogic il = new InventoryLogic();
                Inventory i1 = il.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));
                if (i1.InventoryID > 0)
                {
                    RawMaterial r1 = rl.SelectByID(i1.RawMaterialID);
                    DropDownList1.SelectedItem.Value = r1.RawMaterialID.ToString();
                    TextBox1.Text = i1.Quantity.ToString();
                    TextBox2.Text = i1.TrDate.ToString("dd/MM/yyyy");
                    TextBox3.Text = i1.Remarks;
                }
            }
            else
            {
                Response.Redirect("Access.aspx");
            }
        }
          /*  else
            {
                RawMaterialLogic rl = new RawMaterialLogic();
                DropDownList1.DataSource = rl.SelectAll();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "RawMaterialID";
                DropDownList1.DataBind();
            }*/
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {

            InventoryLogic il = new InventoryLogic();
            Inventory objInventory = il.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));

            objInventory.RawMaterialID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            objInventory.Quantity = Convert.ToInt32(TextBox1.Text);
            //objInventory.TrDate = Convert.ToDateTime(TextBox2.Text);
            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objInventory.TrDate = DateTime.Now;
            }
            if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
            {
                objInventory.TrDate = DateTime.Now;
            }
            else
            {
                objInventory.TrDate = d1;
            }
            objInventory.Remarks = TextBox3.Text;
            objInventory.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
            objInventory.GRNID = 0;
            il.Update(objInventory);
            Response.Redirect("InventoryList.aspx");
        }
        else
        {
            InventoryLogic il = new InventoryLogic();
            Inventory objInventory = new Inventory();

            objInventory.RawMaterialID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            objInventory.Quantity = Convert.ToInt32(TextBox1.Text);
            //objInventory.TrDate = Convert.ToDateTime(TextBox2.Text);
            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objInventory.TrDate = DateTime.Today;
            }
            if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
            {
                objInventory.TrDate = DateTime.Now;
            }
            else
            {
                objInventory.TrDate = d1;
            }
            
            objInventory.Remarks = TextBox3.Text;
            objInventory.EmployeeID = Convert.ToInt32(Session["EmployeeID"]);
            objInventory.GRNID = 0;
            il.Insert(objInventory);

            Response.Redirect("InventoryList.aspx");
        }
    }
}
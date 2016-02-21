using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;
public partial class profileinv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            InventoryLogic iil = new InventoryLogic();
            Inventory c1 = iil.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
            RawMaterialLogic rrl = new RawMaterialLogic();
            RawMaterial r1 = rrl.SelectByID(c1.RawMaterialID);

            if (c1 != null)
            {

                Label1.Text = r1.Name;
                Label2.Text = c1.Quantity.ToString();
                Label3.Text = c1.TrDate.ToString();
                Label4.Text = c1.Remarks;

            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class ProfileRaw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeLogic el = new EmployeeLogic();
            Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
            if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
            {
                RawMaterialLogic rl = new RawMaterialLogic();
                RawMaterial r1 = rl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));

                SupplierLogic sl = new SupplierLogic();


                if (r1 != null)
                {

                    Label1.Text = r1.Name;
                    Label2.Text = r1.Code.ToString();
                    Label3.Text = r1.Descrition;
                    Label4.Text = r1.Unit;
                    Label5.Text = r1.MinQuantity.ToString();
                    Supplier s1 = sl.SelectByID(r1.SupplierID);
                    if (s1 != null)
                    {
                        Label6.Text = s1.Name;
                    }
                    else
                    {
                        Label6.Text = "-----";
                    }
                    Label7.Text = r1.Category;
                    Label8.Text = r1.Type;

                }
            }
            else
            {
                Response.Redirect("Access.aspx");
            }
        }
    }
}
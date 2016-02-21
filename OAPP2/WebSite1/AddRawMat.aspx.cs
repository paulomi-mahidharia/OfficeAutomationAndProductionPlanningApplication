using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class AddRawMat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                {
                
                    RawMaterialLogic rl = new RawMaterialLogic();
                    RawMaterial r1 = rl.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
                    TextBox2.Text = r1.Name;
                    TextBox3.Text = r1.Code.ToString();
                    TextArea1.Text = r1.Descrition;
                    TextBox4.Text = r1.Unit;
                    TextBox5.Text = r1.MinQuantity.ToString();
                    SupplierLogic sl = new SupplierLogic();
                    DropDownList1.DataSource = sl.SelectAll();
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "SupplierID";
                    DropDownList1.DataBind();
                    Supplier s = sl.SelectByID(r1.SupplierID);
                    DropDownList1.SelectedItem.Text = s.Name;
                    DropDownList2.SelectedItem.Text = r1.Category;
                    DropDownList3.SelectedItem.Text = r1.Type;
                }


                else
                {
                
                    SupplierLogic sl = new SupplierLogic();
                    DropDownList1.DataSource = sl.SelectAll();
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "SupplierID";
                    DropDownList1.DataBind();
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
        if ((Convert.ToInt32(Request.QueryString["id"])) > 0)
        {

            RawMaterialLogic rl = new RawMaterialLogic();
            RawMaterial r1 = new RawMaterial();
            r1.Name = TextBox2.Text;
            r1.Code = Convert.ToInt32(TextBox3.Text);
            r1.Unit = TextBox4.Text;
            r1.MinQuantity = Convert.ToInt32(TextBox5.Text);
            r1.Descrition = TextArea1.Text;
            r1.Category = DropDownList2.SelectedItem.Text;
            r1.Type = DropDownList3.SelectedItem.Text;
            r1.SupplierID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            r1.RawMaterialID = Convert.ToInt32(Request.QueryString["id"]);
            
            rl.Update(r1);

            Response.Redirect("RawMatList.aspx");
        }
        else
        {
            RawMaterialLogic rl = new RawMaterialLogic();
            RawMaterial r1 = new RawMaterial();
            r1.Name = TextBox2.Text;
            r1.Code = Convert.ToInt32(TextBox3.Text);
            r1.Unit = TextBox4.Text;
            r1.MinQuantity = Convert.ToInt32(TextBox5.Text);
            r1.Descrition = TextArea1.Text;
            r1.Category = DropDownList2.SelectedItem.Text;
            r1.Type = DropDownList3.SelectedItem.Text;
            r1.SupplierID = Convert.ToInt32(DropDownList1.SelectedItem.Value);

            //r1.RawMaterialID = Convert.ToInt32(Request.QueryString["id"]);
           
            rl.Insert(r1);

            Response.Redirect("RawMatList.aspx");
        }
    }
}
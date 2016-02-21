using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class InventoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
       
            if (!IsPostBack)
            {
                if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT"))
                {

                InventoryLogic IL = new InventoryLogic();
                DataTable dt = IL.SelectAllJoined();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                if (dt.Rows.Count == 0)
                {
                    Table1.Visible = false;
                    Label3.Visible = true;
                }
                else
                {
                    Table1.Visible = true;
                    Label3.Visible = false;
                }

                 SupplierLogic sl = new SupplierLogic();
                DataTable dt1 = sl.SelectAll();
                dt1.Rows.Add(0,"All Supplier",null,null,null);
                dt1.DefaultView.Sort = "SupplierID";
                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "SupplierID";
                DropDownList1.DataBind();
                DropDownList1.SelectedItem.Text = "All Supplier";
            }
                else
                {
                    Response.Redirect("Access.aspx");
                }
        }
        
    }


    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            InventoryLogic il = new InventoryLogic();
            BusinessLogic.Inventory e1 = il.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (e1 != null)
            {

                il.Delete(e1.InventoryID);
                Response.Redirect("InventoryList.aspx");
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label2.Visible = false;
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE"))
        {
            string ans = "";
            foreach (RepeaterItem ri in Repeater1.Items)
            {
                CheckBox cb = (CheckBox)ri.FindControl("Checkbox1");
                if (cb.Checked)
                {
                    int invid = Convert.ToInt32(((Label)ri.FindControl("Label1")).Text);
                    ans += invid + ",";
                }
            }
            if (ans.Length > 1)
            {
                ans = ans.Substring(0, ans.Length - 1);
                Session["invids"] = ans;
                DataTable dt = new InventoryLogic().selectForPrint(ans);
                int c = 0;
                String s = "";
                foreach (DataRow row in dt.Rows)
                {

                    if (c == 0)
                    {
                        s = row["SupplierName"].ToString();
                        c++;
                    }
                    else
                    {
                        if (!row["SupplierName"].ToString().Equals(s))
                        {
                            Label2.Visible = true;
                            break;
                        }
                        else
                        {
                            Label2.Visible = false;
                        }

                        c++;


                    }
                }

                if (Label2.Visible == false)
                {
                    Response.Redirect("GenGRN.aspx");
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
        InventoryLogic il = new InventoryLogic();
        DateTime d1 = new DateTime();
        DateTime d2 = new DateTime();
        
            if (!DateTime.TryParseExact(TextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                    d1 = DateTime.Now.AddYears(-100);
            }

            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
            {
                    d2 = DateTime.Now.AddYears(+10);
            }
        
       
        DataTable dt = il.Search(d1,d2,Convert.ToInt32(DropDownList1.SelectedItem.Value));
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        if (dt.Rows.Count == 0)
        {
            Table1.Visible = false;
            Label3.Visible = true;
        }
        else
        {
            Table1.Visible = true;
            Label3.Visible = false;
        }
    }
       

}

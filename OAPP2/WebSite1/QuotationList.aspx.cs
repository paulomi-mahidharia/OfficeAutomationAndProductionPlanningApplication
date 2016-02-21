using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class QuotationList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
       
            if (!IsPostBack)
            {
                if (e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("MARKETING MANAGER") || e2.Designation.Equals("MARKETING EMPLOYEE") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
                {
                QuotationLogic QL = new QuotationLogic();
                DataTable dt = QL.SelectAllJoined();
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

                CustomerLogic cl = new CustomerLogic();
                DataTable dt1 = cl.SelectAll();
                dt1.Rows.Add(0, "All Customer", null, null, null, null, null, null, null, null, null);
                dt1.DefaultView.Sort = "CustomerID";
                DropDownList1.DataSource = dt1;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "CustomerID";
                DropDownList1.DataBind();
                DropDownList1.SelectedItem.Text = "All Customer";

                ProductLogic pl = new ProductLogic();
                DataTable dt2 = pl.SelectAll();
                dt2.Rows.Add(0, "All Product", null, null, null, null, null, null, null, null);
                dt2.DefaultView.Sort = "ProductID";
                DropDownList2.DataSource = dt2;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "ProductID";
                DropDownList2.DataBind();
                DropDownList2.SelectedItem.Text = "All Product";
            }
                else
                {
                    Response.Redirect("Access.aspx");
                }
        }
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Visible = false;
        //ScriptManager.RegisterClientScriptBlock(this , this.GetType(), "alertMessage", "alert('All selected quotations shoud be of same customer.')", true);
        string ans = "";
        foreach (RepeaterItem ri in Repeater1.Items)
        {
            CheckBox cb = (CheckBox)ri.FindControl("Checkbox1");
            if (cb.Checked)
            {
                int quoid = Convert.ToInt32(((Label)ri.FindControl("Label1")).Text);
                ans += quoid + ",";
            }
        }
        if (ans.Length > 1)
        {
            ans = ans.Substring(0, ans.Length - 1);
            Session["quoids"] = ans;



            DataTable dt = new QuotationLogic().selectForPrint(ans);
           // Repeater1.DataSource = dt;
           // Repeater1.DataBind();
            int c = 0;
            String s = "";
            foreach (DataRow row in dt.Rows)
            {

                if (c == 0)
                {
                    s = row["CustomerName"].ToString();
                    c++;
                }
                else
                {
                    if (!row["CustomerName"].ToString().Equals(s))
                    {
                        Label2.Visible = true;
                        break;
                        // Response.Redirect("QuotationList.aspx");
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
                Response.Redirect("PrintQuotation.aspx");
            }



           
        }
       
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE"))
        {
            QuotationLogic ql = new QuotationLogic();
            Quotation q1 = ql.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (q1 != null)
            {

                ql.Delete(q1.QuotationID);
                Response.Redirect("QuotationList.aspx");
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE"))
        {
            QuotationLogic ql = new QuotationLogic();
            DateTime d1 = new DateTime();
            DateTime d2 = new DateTime();
       
                if (!DateTime.TryParseExact(TextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {
                    d1 = DateTime.Now.AddYears(-100);
                }

                if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
                {
                    d2 = DateTime.Now.AddYears(10);
                }
       

            DataTable dt = ql.Search(Convert.ToInt32(DropDownList1.SelectedItem.Value), Convert.ToInt32(DropDownList2.SelectedItem.Value), d1, d2);
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
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
}
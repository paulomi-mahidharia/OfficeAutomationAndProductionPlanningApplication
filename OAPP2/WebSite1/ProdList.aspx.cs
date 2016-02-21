using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;


public partial class ProdList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
       
            if (!IsPostBack)
            {
                if (!(e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
                {
                ProductLogic PL = new ProductLogic();

                DataTable dt = PL.SelectAllJoined();

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
                dt1.Rows.Add(0, "All Customers", null, null, null, null, null, null, null, null, null);
                dt1.DefaultView.Sort = "CustomerID";
                DropDownList2.DataSource = dt1;
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "CustomerID";
                DropDownList2.DataBind();
                //DropDownList2.SelectedValue = "All Customers";
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
        if (!(e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
        {
            ProductLogic pl = new ProductLogic();
            Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
            if (p1 != null)
            {
                int i = pl.Delete(p1.ProductID);

                Response.Redirect("ProdList.aspx");

            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        DataTable dt = pl.Search(TextBox1.Text, DropDownList1.SelectedItem.Text, Convert.ToInt32(DropDownList2.SelectedItem.Value));
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (!(e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("EMPLOYEE") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
        {
            if(e.CommandName.Equals("Product Designed")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Product Designed";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Product Designed";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Product Sent for client design approval")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Product Sent for client design approval";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Product Sent for client design approval";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Design approved by client")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Design approved by client";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Design approved by client";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Trial product prepared")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Trial product prepared";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Trial product prepared";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Trial product sent for client approval")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Trial product sent for client approval";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Trial product sent for client approval";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Trial product approved by client")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "Trial product approved by client";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Trial product approved by client";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("product approved")){
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(Convert.ToInt32(e.CommandArgument));
                p1.Status = "product approved";
                pl.Update(p1);
                DataTable dt = pl.SelectAllJoined();

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
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = p1.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "product approved";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox2")).Text;
                tl.Insert(t1);
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }
}
  

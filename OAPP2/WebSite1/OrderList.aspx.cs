using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        
            if (!IsPostBack)
            {
                if (!(e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
                {
                OrderLogic OL = new OrderLogic();
                DataTable dt = OL.SelectAllJoined();
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
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("DESIGNER") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            OrderLogic ol = new OrderLogic();
            Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
            if (o1 != null)
            {
                int i = ol.Delete(o1.OrderID);

                Response.Redirect("OrderList.aspx");

            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        OrderLogic ol = new OrderLogic();
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
        DataTable dt = ol.Search(Convert.ToInt32(DropDownList1.SelectedItem.Value), Convert.ToInt32(DropDownList2.SelectedItem.Value), d1, d2);
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
    /*
    protected void ImageButton1_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Performa invoice generated";
        ol.Update(o1);
    }
    protected void ImageButton2_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Performa invoice approved";
        ol.Update(o1);
    }
    protected void ImageButton3_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Cylinder requested";
        ol.Update(o1);
    }
    protected void ImageButton4_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Cylinder received";
        ol.Update(o1);
    }
    protected void ImageButton5_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Print pending";
        ol.Update(o1);
    }
    protected void ImageButton6_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Converting";
        ol.Update(o1);
    }
    protected void ImageButton7_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Ready";
        ol.Update(o1);
    }
    protected void ImageButton8_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Dispached";
        ol.Update(o1);
    }
    protected void ImageButton9_Command(object sender, CommandEventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
        o1.Status = "Closed";
        ol.Update(o1);
    }*/
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
          EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (!(e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
        {
            if(e.CommandName.Equals("Performa invoice generated")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Performa invoice generated";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Performa invoice generated";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Performa invoice approved")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Performa invoice approved";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Performa invoice approved";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Cylinder requested")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Cylinder requested";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Cylinder requested";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Cylinder received")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Cylinder received";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Cylinder received";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Print pending")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Print pending";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Print pending";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Converting")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Converting";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Converting";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Ready")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Ready";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Ready";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Dispached")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Dispached";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Dispached";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }else if(e.CommandName.Equals("Closed")){
                OrderLogic ol = new OrderLogic();
                Order o1 = ol.SelectByID(Convert.ToInt32(e.CommandArgument));
                o1.Status = "Closed";
                ol.Update(o1);
                DataTable dt = ol.SelectAllJoined();
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
                t1.KeyID = o1.OrderID;
                t1.KeyType = "Ord";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = "Closed";
                t1.Remarks = ((TextBox)e.Item.FindControl("TextBox3")).Text;
                tl.Insert(t1);
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
        
    }
    protected void Button2_OnCommand(object sender, CommandEventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("COMERCIAL MANAGER") || e2.Designation.Equals("COMERCIAL EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT"))
        {
            Response.Redirect("GenInvoice.aspx?ID=" + e.CommandArgument);
        }
        else
        {
            Response.Redirect("Access.aspx");
        }   
    }
    protected void Button3_OnCommand(object sender, CommandEventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
        {
            Response.Redirect("jobCard.aspx?ID="+e.CommandArgument);
        }
        else
        {
            Response.Redirect("Access.aspx");
        }
    }

}
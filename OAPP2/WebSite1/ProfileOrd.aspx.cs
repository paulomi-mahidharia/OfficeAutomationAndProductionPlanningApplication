using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class ProfileOrd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (!(e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
        {
            OrderLogic ol = new OrderLogic();
            Order o1=ol.SelectByID(Convert.ToInt32(Request.QueryString["id"]));;

            if (o1 != null)
            {
                ProductLogic pl = new ProductLogic();
                Product p1 = pl.SelectByProductID(o1.ProductID);
                Label1.Text = p1.Name;
                Label2.Text = o1.QuotationID.ToString();
                Label3.Text = o1.Quantity.ToString();
                Label4.Text = o1.Rate.ToString();
                Label5.Text = o1.PONumber.ToString();
                Label6.Text = o1.PODate.ToString("dd/MM/yyyy");
                Label7.Text = o1.CreateDate.ToString("dd/MM/yyyy");
                Label8.Text = o1.Status;
                Label9.Text = o1.StatusRemarks;
                Label10.Text = o1.DeliveryAddress;
                Label11.Text = o1.DeliveryDate.ToString("dd/MM/yyyy");
                String oo = o1.AttachPO;
                lnkImage1.Text = oo.Substring(25);
                lnkImage1.NavigateUrl = oo;
            
            }
        }
        else
        {
            Response.Redirect("Access.aspx");
        }      
     }

}
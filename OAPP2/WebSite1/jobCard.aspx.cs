using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class jobCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EmployeeLogic el = new EmployeeLogic();
            Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
            if (e2.Designation.Equals("MANAGING DIRECTOR") || e2.Designation.Equals("CHAIRMAN") || e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("PRODUCTION MANAGER") || e2.Designation.Equals("PRODUCTION EMPLOYEE"))
            {
                OrderLogic ol = new OrderLogic();

                DataTable dt = ol.SelectJob(Convert.ToInt32(Request.QueryString["ID"]));
                Label12.Text = dt.Rows[0]["CustomerName"].ToString();
                Label14.Text = dt.Rows[0]["JobName"].ToString();
                Label13.Text = dt.Rows[0]["PONumber"].ToString();
                Label15.Text = Convert.ToDateTime(dt.Rows[0]["PODate"]).ToString("dd/MM/yyyy");
                Label11.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Label16.Text = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"]).ToString("dd/MM/yyyy");
                Label17.Text = dt.Rows[0]["Quantity"].ToString();

            }
            else
            {
                Response.Redirect("Access.aspx");
            }
        }
    }

    protected void DropDownList1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Label18.Text = DropDownList1.SelectedItem.Text;
    }
    
    protected void DropDownList2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Label19.Text = DropDownList2.SelectedItem.Text;
    }

    protected void DropDownList3_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Label20.Text = DropDownList3.SelectedItem.Text;
    }
    protected void btnUpload_OnClick(object sender, EventArgs e)
    {
        OrderLogic ol = new OrderLogic();
        Order o = ol.SelectByID(Convert.ToInt32(Request.QueryString["ID"])); ;
        string path;
        string ticks = DateTime.Now.Ticks.ToString();
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
            path = "Images/" + ticks + FileUpload1.FileName;
            o.JobPath = path;
            ol.Update(o);
        }
    }
}


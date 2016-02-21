using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class GenGRN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string invids = Session["invids"].ToString();


        DataTable dt = new InventoryLogic().selectForPrint(invids);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();

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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Multiple customer can not have same quotation.')", true);
                    Response.Redirect("InventoryList.aspx");
                }
                c++;
            }
        }

        TextBox2.Text = dt.Rows[0]["SupplierName"].ToString();
    }

  

    protected void btnUpload_OnClick(object sender, EventArgs e)
    {

        string invids = Session["invids"].ToString();
        string[] arr = invids.Split(',');
        InventoryLogic il = new InventoryLogic();
        RawMaterialLogic rl = new RawMaterialLogic();
        GRNLogic gl = new GRNLogic();
        GRN g = new GRN();
        g.SupplierID = rl.SelectByID(il.SelectByID(Convert.ToInt32(arr[0])).RawMaterialID).SupplierID;
        string path;
        string ticks = DateTime.Now.Ticks.ToString();
        Inventory inv;
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
            path = "Images/" + ticks + FileUpload1.FileName;
            g.GRNPath = path;
            int id =  gl.Insert(g);
            
            for (int i = 0; i < arr.Length; i++)
            {
                inv = il.SelectByID(Convert.ToInt32(arr[i]));
                inv.GRNID = id;
                il.Update(inv);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage" + arr[i], "alert(" + arr[i] + ")", true);
            }

        }
        // Response.Redirect("QuotationList.aspx");
        Response.Redirect("InventoryList.aspx");

    }

}

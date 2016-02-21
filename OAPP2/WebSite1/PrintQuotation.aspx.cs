using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;

public partial class PrintQuotation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string quoids = Session["quoids"].ToString();
        DataTable dt = new QuotationLogic().selectForPrint(quoids);
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Multiple customer can not have same quotation.')", true);
                    Response.Redirect("QuotationList.aspx");
                }
                c++;
            }
        }

        Label5.Text = s;
        Label6.Text = dt.Rows[0]["Address"].ToString();
        Label7.Text = dt.Rows[0]["Phone"].ToString();
        Label8.Text = dt.Rows[0]["Email"].ToString();
        Label9.Text = DateTime.Today.ToString("dd/MM/yyyy");
    }

    protected void btnUpload_OnClick(object sender, EventArgs e)
    {
        string quoids = Session["quoids"].ToString();
        string[] arr = quoids.Split(',');
        QuotationLogic ql = new QuotationLogic();
        Quotation q;
        string path;
        string ticks = DateTime.Now.Ticks.ToString();
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
            path = "Images/" + ticks + FileUpload1.FileName;
            for (int i = 0; i < arr.Length; i++)
            {
                q = ql.SelectByID(Convert.ToInt32(arr[i]));
                q.QuotationPath = path;
                ql.Update(q);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage" + arr[i], "alert(" + arr[i] + ")", true);
            }

        }
        // Response.Redirect("QuotationList.aspx");

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;


public partial class TrackProductStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = DateTime.Today.ToString("dd/MM/yyyy");
        TransitionLogic ol = new TransitionLogic();

        DataTable dt1 = ol.SelectProductStatus("Product Created",DateTime.Today);
        DataTable dt2 = ol.SelectProductStatus("Product Designed",DateTime.Today);
        DataTable dt3 = ol.SelectProductStatus("Product Sent for client design approval",DateTime.Today);
        DataTable dt4 = ol.SelectProductStatus("Design approved bt client",DateTime.Today);
        DataTable dt5 = ol.SelectProductStatus("Trial product prepared",DateTime.Today);
        DataTable dt6 = ol.SelectProductStatus("Trial product sent for client approval",DateTime.Today);
        DataTable dt7 = ol.SelectProductStatus("Trial product approved by client",DateTime.Today);
        DataTable dt8 = ol.SelectProductStatusApproved("product approved",DateTime.Today);

        int[] arr = { dt1.Rows.Count, dt2.Rows.Count, dt3.Rows.Count, dt4.Rows.Count, dt5.Rows.Count, dt6.Rows.Count, dt7.Rows.Count, dt8.Rows.Count};




        int max = findMax(dt1.Rows.Count, dt2.Rows.Count, dt3.Rows.Count, dt4.Rows.Count, dt5.Rows.Count, dt6.Rows.Count, dt7.Rows.Count, dt8.Rows.Count);
        
        if (dt1.Rows.Count < max)
           {
               for (int i = dt1.Rows.Count; i < max; i++)
               {
                   dt1.Rows.Add("-");
               }
           }

        if (dt2.Rows.Count < max)
        {
            for (int i = dt2.Rows.Count; i < max; i++)
            {
                dt2.Rows.Add("-");
            }
        }
        if (dt3.Rows.Count < max)
        {
            for (int i = dt3.Rows.Count; i < max; i++)
            {
                dt3.Rows.Add("-");
            }
        }
        if (dt4.Rows.Count < max)
        {
            for (int i = dt4.Rows.Count; i < max; i++)
            {
                dt4.Rows.Add("-");
            }
        }
        if (dt5.Rows.Count < max)
        {
            for (int i = dt5.Rows.Count; i < max; i++)
            {
                dt5.Rows.Add("-");
            }
        }
        if (dt6.Rows.Count < max)
        {
            for (int i = dt6.Rows.Count; i < max; i++)
            {
                dt6.Rows.Add("-");
            }
        }
        if (dt7.Rows.Count < max)
        {
            for (int i = dt7.Rows.Count; i < max; i++)
            {
                dt7.Rows.Add("-");
            }
        }
        if (dt8.Rows.Count < max)
        {
            for (int i = dt8.Rows.Count; i < max; i++)
            {
                dt8.Rows.Add("-");
            }
        }
        Repeater1.DataSource = dt1;
        Repeater2.DataSource = dt2;
        Repeater3.DataSource = dt3;
        Repeater4.DataSource = dt4;
        Repeater5.DataSource = dt5;
        Repeater6.DataSource = dt6;
        Repeater7.DataSource = dt7;
        Repeater8.DataSource = dt8;

        Repeater1.DataBind();
        Repeater2.DataBind();
        Repeater3.DataBind();
        Repeater4.DataBind();
        Repeater5.DataBind();
        Repeater6.DataBind();
        Repeater7.DataBind();
        Repeater8.DataBind();


       }
        
      
    
    public int findMax(int a1,int a2,int a3,int a4,int a5,int a6,int a7,int a8)
    {
        int[] arr = {a1,a2,a3,a4,a5,a6,a7,a8};
        int max=0;
        for (int i = 0; i < 7; i++)
        {
            if (arr[i] >max)
            {
                max = arr[i];
                
            }
            
        }
        
        return max;


    }
    protected void Button2_click(object sender, EventArgs e)
    {


        DateTime d1 = new DateTime();
        // d1 = Convert.ToDateTime(TextBox1.Text);
        if (!DateTime.TryParseExact(TextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
        {

        }

        Label2.Text = d1.ToString("dd/MM/yyyy");

        TransitionLogic ol = new TransitionLogic();
        DataTable dt1 = ol.SelectProductStatus("Product Created",d1);
        DataTable dt2 = ol.SelectProductStatus("Product Designed",d1);
        DataTable dt3 = ol.SelectProductStatus("Product Sent for client design approval",d1);
        DataTable dt4 = ol.SelectProductStatus("Design approved bt client",d1);
        DataTable dt5 = ol.SelectProductStatus("Trial product prepared",d1);
        DataTable dt6 = ol.SelectProductStatus("Trial product sent for client approval",d1);
        DataTable dt7 = ol.SelectProductStatus("Trial product approved by client",d1);
        DataTable dt8 = ol.SelectProductStatus("product approved",d1);
      

        int max = findMax(dt1.Rows.Count, dt2.Rows.Count, dt3.Rows.Count, dt4.Rows.Count, dt5.Rows.Count, dt6.Rows.Count, dt7.Rows.Count, dt8.Rows.Count);

        if (dt1.Rows.Count < max)
        {
            for (int i = dt1.Rows.Count; i < max; i++)
            {
                dt1.Rows.Add("-");
            }
        }

        if (dt2.Rows.Count < max)
        {
            for (int i = dt2.Rows.Count; i < max; i++)
            {
                dt2.Rows.Add("-");
            }
        }
        if (dt3.Rows.Count < max)
        {
            for (int i = dt3.Rows.Count; i < max; i++)
            {
                dt3.Rows.Add("-");
            }
        }
        if (dt4.Rows.Count < max)
        {
            for (int i = dt4.Rows.Count; i < max; i++)
            {
                dt4.Rows.Add("-");
            }
        }
        if (dt5.Rows.Count < max)
        {
            for (int i = dt5.Rows.Count; i < max; i++)
            {
                dt5.Rows.Add("-");
            }
        }
        if (dt6.Rows.Count < max)
        {
            for (int i = dt6.Rows.Count; i < max; i++)
            {
                dt6.Rows.Add("-");
            }
        }
        if (dt7.Rows.Count < max)
        {
            for (int i = dt7.Rows.Count; i < max; i++)
            {
                dt7.Rows.Add("-");
            }
        }
        if (dt8.Rows.Count < max)
        {
            for (int i = dt8.Rows.Count; i < max; i++)
            {
                dt8.Rows.Add("-");
            }
        }
        
        Repeater1.DataSource = dt1;
        Repeater2.DataSource = dt2;
        Repeater3.DataSource = dt3;
        Repeater4.DataSource = dt4;
        Repeater5.DataSource = dt5;
        Repeater6.DataSource = dt6;
        Repeater7.DataSource = dt7;
        Repeater8.DataSource = dt8;
       

        Repeater1.DataBind();
        Repeater2.DataBind();
        Repeater3.DataBind();
        Repeater4.DataBind();
        Repeater5.DataBind();
        Repeater6.DataBind();
        Repeater7.DataBind();
        Repeater8.DataBind();
       
    }
    
}
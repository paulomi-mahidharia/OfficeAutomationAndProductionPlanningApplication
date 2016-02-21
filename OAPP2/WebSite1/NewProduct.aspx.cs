using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class NewProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
       
            if (!IsPostBack)
            {
                if (!(e2.Designation.Equals("STOCK MANAGER") || e2.Designation.Equals("STOCK EMPLOYEE") || e2.Designation.Equals("ACCOUNTATANT") || e2.Designation.Equals("EMPLOYEE") || e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE")))
                {

                CustomerLogic sl = new CustomerLogic();
                DropDownList2.DataSource = sl.SelectAll();
                DropDownList2.DataTextField = "Name";
                DropDownList2.DataValueField = "CustomerID";
                DropDownList2.DataBind();
                if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                {
                    // edit mode

                    ProductLogic pl = new ProductLogic();
                    Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
                    TextBox1.Text = p1.Name;
                    TextBox2.Text = p1.CreateDate.ToString("dd/MM/yyyy");
                   DropDownList3.SelectedItem.Text = p1.Status;
                    TextArea1.Text = p1.Description;
                    TextBox4.Text = p1.Size;
                    TextBox5.Text = p1.Colors;

                    String images = p1.DesignFiles;
                    String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length > 0)
                    {
                        FileUpload1.Visible = false;
                        lnkImage1.Text = arr[0].Substring(25);
                        lnkImage1.NavigateUrl = arr[0];
                    }
                    else
                    {
                        lnkImage1.Visible = false;
                        LinkButton1.Visible = false;
                    }
                    if (arr.Length > 1)
                    {
                        lnkImage2.Text = arr[1].Substring(25);
                        lnkImage2.NavigateUrl = arr[1];
                    }
                    else
                    {
                        lnkImage2.Visible = false;
                        LinkButton2.Visible = false;
                    }
                    if (arr.Length > 2)
                    {
                        lnkImage3.Text = arr[2].Substring(25);
                        lnkImage3.NavigateUrl = arr[2];
                    }
                    else
                    {
                        lnkImage3.Visible = false;
                        LinkButton3.Visible = false;
                    }
                    if (arr.Length > 3)
                    {
                        lnkImage4.Text = arr[3].Substring(25);
                        lnkImage4.NavigateUrl = arr[3];
                    }
                    else
                    {
                        lnkImage4.Visible = false;
                        LinkButton4.Visible = false;
                    }
                    if (arr.Length > 4)
                    {
                        lnkImage5.Text = arr[4].Substring(25);
                        lnkImage5.NavigateUrl = arr[4];
                    }
                    else
                    {
                        lnkImage5.Visible = false;
                        LinkButton5.Visible = false;
                    }

                    DropDownList1.SelectedItem.Text = p1.Type;


                    Customer s = sl.SelectByID(p1.CustomerID);
                    DropDownList2.SelectedItem.Text = s.Name;
                }
                else
                {
                    lnkImage1.Visible = false;
                    lnkImage2.Visible = false;
                    lnkImage3.Visible = false;
                    lnkImage4.Visible = false;
                    lnkImage5.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = false;
                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;
                    TextBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
                else
                {
                    Response.Redirect("Access.aspx");
                }
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {
            //edit mode
            ProductLogic PL = new ProductLogic();
            Product objPro = PL.SelectByProductID(Convert.ToInt32(Request.QueryString["ID"]));

            objPro.Name = TextBox1.Text;

            if (objPro.Status.Equals(DropDownList3.SelectedItem.Text))
            {
                objPro.Status = DropDownList3.SelectedItem.Text;
            }
            else
            {
                TransitionLogic tl = new TransitionLogic();
                Transition t1 = new Transition();
                t1.KeyID = objPro.ProductID;
                t1.KeyType = "Prod";
                t1.TranDate = DateTime.Now;
                t1.NewStatus = DropDownList3.SelectedItem.Text;
                t1.Remarks = "";
                tl.Insert(t1);
                objPro.Status = DropDownList3.SelectedItem.Text;
            }
            objPro.Description = TextArea1.Text;
            objPro.Size = TextBox4.Text;
            objPro.Colors = TextBox5.Text;
            objPro.Type = DropDownList1.SelectedItem.Text;
            objPro.CustomerID = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objPro.CreateDate = DateTime.Now;
            }
            if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
            {
                objPro.CreateDate = DateTime.Now;
            }
            else
            {
                objPro.CreateDate = d1;
            }
            String path = objPro.DesignFiles;


            string ticks = DateTime.Now.Ticks.ToString();

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));

                path += "Images/" + ticks + FileUpload1.FileName + "#,#";
            }
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(Server.MapPath("Images/" + ticks + FileUpload2.FileName));
                path += "Images/" + ticks + FileUpload2.FileName + "#,#";
            }
            if (FileUpload3.HasFile)
            {
                FileUpload3.SaveAs(Server.MapPath("Images/" + ticks + FileUpload3.FileName));
                path += "Images/" + ticks + FileUpload3.FileName + "#,#";
            }
            if (FileUpload4.HasFile)
            {
                FileUpload4.SaveAs(Server.MapPath("Images/" + ticks + FileUpload4.FileName));
                path += "Images/" + ticks + FileUpload4.FileName + "#,#";
            }
            if (FileUpload5.HasFile)
            {
                FileUpload5.SaveAs(Server.MapPath("Images/" + ticks + FileUpload5.FileName));
                path += "Images/" + ticks + FileUpload5.FileName + "#,#";
            }

            objPro.DesignFiles = path;

            objPro.ProductID = Convert.ToInt32(Request.QueryString["id"]);
            PL.Update(objPro);

            Response.Redirect("ProdList.aspx");
        }
        else
        {
            // insert mode
            Product objPro = new Product();
            objPro.Name = TextBox1.Text;

            objPro.Status =DropDownList3.SelectedItem.Text;
            objPro.Description = TextArea1.Text;
            objPro.Size = TextBox4.Text;
            objPro.Colors = TextBox5.Text;
            objPro.Type = DropDownList1.Text;
            objPro.CustomerID = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox2.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objPro.CreateDate = DateTime.Now;
            }
            if (d1.ToShortDateString().Equals(DateTime.Today.ToShortDateString()))
            {
                objPro.CreateDate = DateTime.Now;
            }
            else
            {
                objPro.CreateDate = d1;
            }

            String path = "";
            string ticks = DateTime.Now.Ticks.ToString();

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));

                path += "Images/" + ticks + FileUpload1.FileName + "#,#";
            }
            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(Server.MapPath("Images/" + ticks + FileUpload2.FileName));
                path += "Images/" + ticks + FileUpload2.FileName + "#,#";
            }
            if (FileUpload3.HasFile)
            {
                FileUpload3.SaveAs(Server.MapPath("Images/" + ticks + FileUpload3.FileName));
                path += "Images/" + ticks + FileUpload3.FileName + "#,#";
            }
            if (FileUpload4.HasFile)
            {
                FileUpload4.SaveAs(Server.MapPath("Images/" + ticks + FileUpload4.FileName));
                path += "Images/" + ticks + FileUpload4.FileName + "#,#";
            }
            if (FileUpload5.HasFile)
            {
                FileUpload5.SaveAs(Server.MapPath("Images/" + ticks + FileUpload5.FileName));
                path += "Images/" + ticks + FileUpload5.FileName + "#,#";
            }

            objPro.DesignFiles = path;


            ProductLogic PL = new ProductLogic();
            PL.Insert(objPro);

            Response.Redirect("ProdList.aspx");

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
        String images = p1.DesignFiles;
        String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        p1.DesignFiles = "";
        for (int i = 1; i < arr.Length; i++)
        {
            p1.DesignFiles += arr[i] + "#,#";
        }
        pl.Update(p1);
        Response.Redirect("NewProduct.aspx?id=" + Request.QueryString["id"]);

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
        String images = p1.DesignFiles;
        String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        p1.DesignFiles = arr[0] + "#,#";
        for (int i = 2; i < arr.Length; i++)
        {
            p1.DesignFiles += arr[i] + "#,#";
        }
        pl.Update(p1);
        Response.Redirect("NewProduct.aspx?id=" + Request.QueryString["id"]);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
        String images = p1.DesignFiles;
        String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        p1.DesignFiles = arr[0] + "#,#";
        p1.DesignFiles += arr[1] + "#,#";
        for (int i = 3; i < arr.Length; i++)
        {
            p1.DesignFiles += arr[i] + "#,#";
        }
        pl.Update(p1);
        Response.Redirect("NewProduct.aspx?id=" + Request.QueryString["id"]);
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
        String images = p1.DesignFiles;
        String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        p1.DesignFiles = arr[0] + "#,#";
        p1.DesignFiles += arr[1] + "#,#";
        p1.DesignFiles += arr[2] + "#,#";
        for (int i = 4; i < arr.Length; i++)
        {
            p1.DesignFiles += arr[i] + "#,#";
        }
        pl.Update(p1);
        Response.Redirect("NewProduct.aspx?id=" + Request.QueryString["id"]);
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        ProductLogic pl = new ProductLogic();
        Product p1 = pl.SelectByProductID(Convert.ToInt32(Request.QueryString["id"]));
        String images = p1.DesignFiles;
        String[] arr = images.Split(new String[] { "#,#" }, StringSplitOptions.RemoveEmptyEntries);
        p1.DesignFiles = arr[0] + "#,#";
        p1.DesignFiles += arr[1] + "#,#";
        p1.DesignFiles += arr[2] + "#,#";
        p1.DesignFiles += arr[3] + "#,#";

        pl.Update(p1);
        Response.Redirect("NewProduct.aspx?id=" + Request.QueryString["id"]);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class EditEmp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE"))
        {
            if (!IsPostBack)
            {

                Employee e1 = el.SelectByID(Convert.ToInt32(Request.QueryString["id"]));
                if (e1.EmployeeID > 0)
                {
                    TextBox1.Text = e1.Name;
                    TextArea1.Text = e1.Address;
                    TextBox2.Text = e1.Email;
                    TextBox3.Text = e1.Phone;
                    TextBox5.Text = e1.DOB.ToString("dd/MM/yyyy");
                    TextBox6.Text = e1.DOJ.ToString("dd/MM/yyyy");
                    Image1.ImageUrl = e1.Photo;
                    if (e1.Gender.Equals("Male"))
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                    DropDownList1.SelectedItem.Text = e1.Designation;
                    //ImageButton1.ImageUrl = "Images/"+e1.Photo;

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
        if (Convert.ToInt32(Request.QueryString["ID"]) > 0)
        {

            EmployeeLogic EL = new EmployeeLogic();
            Employee objEmployee = EL.SelectByID(Convert.ToInt32(Request.QueryString["ID"]));

            objEmployee.Name = TextBox1.Text;
            objEmployee.Email = TextBox2.Text;
            objEmployee.Phone = TextBox3.Text;
            objEmployee.Username = TextBox1.Text;
            objEmployee.Password = TextBox1.Text;
                if (FileUpload1.HasFile)
                {
                    string ticks = DateTime.Now.Ticks.ToString();

                    FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
                    objEmployee.Photo = "Images/" + ticks + FileUpload1.FileName;
                }
                //else
                //{
                //    objEmployee.Photo = "Images/default.png";
                //}


            objEmployee.Address = TextArea1.Text;
            if (RadioButton1.Checked)
            {
                objEmployee.Gender = "Male";
            }
            else
            {
                objEmployee.Gender = "Female";
            }
            objEmployee.EmpType = "Office Employee";
            objEmployee.IsActive = "True";
           
            objEmployee.Designation = DropDownList1.SelectedItem.Text;
           

            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox5.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objEmployee.DOB = DateTime.Today;
            }
            else 
            {
                objEmployee.DOB = d1;
            }

            DateTime d2 = new DateTime();
            if (!DateTime.TryParseExact(TextBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
            {
                objEmployee.DOJ = DateTime.Today;
            }
            else
            {
                objEmployee.DOJ = d2;
            }
            
            objEmployee.EmployeeID = Convert.ToInt32(Request.QueryString["id"]);

          
            EL.Update(objEmployee);

            Response.Redirect("EmployeeList.aspx");
        }
        else
        {
            Employee objEmployee = new Employee();
            objEmployee.Name = TextBox1.Text;
            objEmployee.Email = TextBox2.Text;
            objEmployee.Phone = TextBox3.Text;
            objEmployee.Username = TextBox1.Text;
            objEmployee.Password = TextBox1.Text;
            if (FileUpload1.HasFile)
            {
                string ticks = DateTime.Now.Ticks.ToString();

                FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));
                objEmployee.Photo = "Images/" + ticks + FileUpload1.FileName;

            }
            else
            {
                objEmployee.Photo = "Images/default.png";
            }

            objEmployee.Address = TextArea1.Text;
            if (RadioButton1.Checked)
            {
                objEmployee.Gender = "Male";
            }
            else
            {
                objEmployee.Gender = "Female";
            }
            objEmployee.EmpType = "Office Employee";
            objEmployee.IsActive = "True";

            objEmployee.Designation = DropDownList1.SelectedItem.Text;
          

            DateTime d1 = new DateTime();
            if (!DateTime.TryParseExact(TextBox5.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
            {
                objEmployee.DOB = DateTime.Today;
            }
            
                objEmployee.DOB = d1;
            
            DateTime d2 = new DateTime();
            if (!DateTime.TryParseExact(TextBox6.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d2))
            {
                objEmployee.DOJ = DateTime.Today;
            }
           
                objEmployee.DOJ = d2;
                objEmployee.EmailCode = "";
                objEmployee.SMSCode = "";

            EmployeeLogic EL = new EmployeeLogic();
            EL.Insert(objEmployee);

            Response.Redirect("EmployeeList.aspx");
        }
    }
}
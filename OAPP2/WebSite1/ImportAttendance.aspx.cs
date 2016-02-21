using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel;
using System.IO;
using System.Data;
using BusinessLogic;
using System.Data.SqlClient;

public partial class ImportAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee e2 = el.SelectByID(Convert.ToInt32(Session["EmployeeID"]));
        if (e2.Designation.Equals("HR MANAGER") || e2.Designation.Equals("HR EMPLOYEE"))
        {

        }
        else
        {
            Response.Redirect("Access.aspx");
        }
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {

            Label1.Visible = false;


            DataSet ds = new DataSet();
            String path = "";
            string ticks = DateTime.Now.Ticks.ToString();

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("Images/" + ticks + FileUpload1.FileName));

                path = Server.MapPath("Images/" + ticks + FileUpload1.FileName);
                OpenExcelFile(path, ref ds);
            }
            AttendanceLogic al = new AttendanceLogic();
            Attendance a = new Attendance();
            DateTime d1 = new DateTime();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                a.EmployeeID = Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeID"]);

                if (!DateTime.TryParseExact(ds.Tables[0].Rows[i]["ADate"].ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out d1))
                {

                }
                a.Adate = d1;
                if (ds.Tables[0].Rows[i]["Mark"].ToString().Equals("P"))
                {
                    a.Mark = true;
                }
                else if (ds.Tables[0].Rows[i]["Mark"].ToString().Equals("A"))
                {
                    a.Mark = false;
                }
                al.Insert(a);
            }
            ds.Tables[0].Columns.Add(new DataColumn("EmployeeName"));
            EmployeeLogic el = new EmployeeLogic();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ds.Tables[0].Rows[i]["EmployeeName"] = (el.SelectByID(Convert.ToInt32(ds.Tables[0].Rows[i]["EmployeeID"]))).Name;
            }
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

        }
        else {
            Label1.Visible = true;
        }
        
    }

    private bool OpenExcelFile(string strFilePath, ref DataSet ds)
    {
        try
        {
            FileStream stream = File.Open(strFilePath, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = excelReader.AsDataSet();
            //...
            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods
            //if (result.Tables.Count == 1)
            //{
            //if (excelReader.IsFirstRowAsColumnNames)
            //{
            //    excelReader.Read();
            //}
            //while (excelReader.Read())
            //{
            //    result.Tables[0].Rows[resultIndex][1] = excelReader.GetDateTime(1).ToString("dd-MM-yyyy"); //"Bill Date"
            //    resultIndex++;
            //}
            //}
            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            //result.AcceptChanges();

            ds = result;
            return true;
        }
        catch { return false; }
        
    }

   
}
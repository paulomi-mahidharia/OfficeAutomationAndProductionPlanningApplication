using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Text;
//using System.Security.Cryptography;

public partial class AndroidSupport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] == "login")
        {
            // login request
            string un = Request.QueryString["un"].ToString();
            string pw = Request.QueryString["pw"].ToString();

            Employee e1 = new EmployeeLogic().selectUP(un, pw);
            
            Response.Write(e1.EmployeeID+ ";"+e1.Username+";"+e1.Password+"---");
            return;
        }

        else if (Request.QueryString["type"] == "notification")
        {
            // no other data is needed
            QuotationLogic ql = new QuotationLogic();
            DataTable dt = ql.SelectNotification();
            String resp = "";
            foreach (DataRow dr in dt.Rows)
            {
                resp = resp + dr["ID"].ToString() + ";";
                resp = resp + dr["Data"].ToString() + ";";
                
                resp = resp + dr["Type"].ToString() + ";";
                resp = resp + Convert.ToDateTime(dr["Date"]).ToString("dd-MM-yyyy HH:mm:ss") + "---";
            }

            Response.Write(resp);
        }
        else if (Request.QueryString["type"] == "employee")
        {
            // no other data is needed
            EmployeeLogic el = new EmployeeLogic();
            DataTable dt = el.SelectForAndroid();
            String resp = "";
            foreach (DataRow dr in dt.Rows)
            {
                resp = resp + dr["EmployeeID"].ToString() + ";";
                resp = resp + dr["Name"].ToString() + ";";
                resp = resp + dr["Phone"].ToString() + "---";
            }

            Response.Write(resp);
        }
        else if (Request.QueryString["type"] == "employeeInfo")
        {
            // no other data is needed
            EmployeeLogic el = new EmployeeLogic();
            Employee e1 = el.SelectByID(Convert.ToInt32 (Request.QueryString["ID"]));
            String resp = "";
            
                resp = resp + e1.EmployeeID + ";";
                resp = resp + e1.Name + ";";
                resp = resp + e1.Designation + ";";
                resp = resp + e1.Address+ ";";
                resp = resp + e1.Email+ ";";
                resp = resp + e1.Phone + ";";
                resp = resp + Convert.ToDateTime(e1.DOB.ToString("dd-MM-yyyy"))+ ";";
                resp = resp + Convert.ToDateTime(e1.DOJ.ToString("dd-MM-yyyy"))+ ";";
                resp = resp + e1.Photo + "---";
            

            Response.Write(resp);
        }


        //else if (Request.QueryString["type"] == "Teamlist")
        //{
        //    // no other data is needed
        //    TeamLogic tl = new TeamLogic();
        //    DataTable dt = tl.SelectAll();
        //    String resp = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        resp = resp + dr["TeamID"].ToString() + "-";
        //        resp = resp + dr["Name"].ToString() + "-";
        //        resp = resp + dr["CreateDate"].ToString() + "-";
        //        resp = resp + dr["TeamLeadID"].ToString() + "-";
        //        resp = resp + dr["ProjectID"].ToString() + "#";

        //    }

        //    Response.Write(resp);
        //}

        //else if (Request.QueryString["type"] == "Versionlist")
        //{
        //    // no other data is needed
        //    ProjectVersionLogic PVL = new ProjectVersionLogic();
        //    DataTable dt = PVL.SelectAll();
        //    String resp = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        resp = resp + dr["ProjectVersionID"].ToString() + "-";
        //        resp = resp + dr["Name"].ToString() + "-";
        //        // resp = resp + dr["ProjectID"].ToString() + "-";
        //        resp = resp + dr["ScheduledStartDate"].ToString() + "-";
        //        // resp = resp + dr["ActualStartDate"].ToString() + "-";
        //        resp = resp + dr["ScheduledEndDate"].ToString() + "#";

        //    }

        //    Response.Write(resp);
        //}


        ////public string MD5Hash(string Password)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();

        //    //compute hash from the bytes of text
        //    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));
        //    //get hash result after compute it
        //    byte[] result = md5.Hash;

        //    StringBuilder strBuilder = new StringBuilder();
        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        //change it into 2 hexadecimal digits
        //        //for each byte
        //        strBuilder.Append(result[i].ToString("x2"));
        //    }

        //    return strBuilder.ToString();
        //}
    }

}
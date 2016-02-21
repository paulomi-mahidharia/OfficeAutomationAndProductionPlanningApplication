using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class EmployeeLogic : ILogic<Employee>
    {
        public int Insert(Employee objEmployee)
        {
            string query = "insert Employee values (@Name, @Email, @Phone, @Photo, @Address, @DOB, @Gender, @EmpType, @Username, @Password, @IsActive, @Designation, @DOJ, @EmailCode, @SMSCode)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", objEmployee.Name));
            lstParams.Add(new SqlParameter("@Email", objEmployee.Email));
            lstParams.Add(new SqlParameter("@Phone", objEmployee.Phone));
            lstParams.Add(new SqlParameter("@Photo", objEmployee.Photo));
            lstParams.Add(new SqlParameter("@Address", objEmployee.Address));
            lstParams.Add(new SqlParameter("@DOB", objEmployee.DOB));
            lstParams.Add(new SqlParameter("@Gender", objEmployee.Gender));
            lstParams.Add(new SqlParameter("@EmpType", objEmployee.EmpType));
            lstParams.Add(new SqlParameter("@Username", objEmployee.Username));
            lstParams.Add(new SqlParameter("@Password", objEmployee.Password));
            lstParams.Add(new SqlParameter("@IsActive", objEmployee.IsActive));
            lstParams.Add(new SqlParameter("@Designation", objEmployee.Designation));
            
            lstParams.Add(new SqlParameter("@DOJ", objEmployee.DOJ));
            lstParams.Add(new SqlParameter("@EmailCode", objEmployee.EmailCode));
            lstParams.Add(new SqlParameter("@SMSCode", objEmployee.SMSCode));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Employee objEmployee)
        {
            string query = "update Employee set Name = @Name, Email = @Email, Phone = @Phone, Photo = @Photo, Address = @Address, DOB = @DOB, Gender = @Gender, EmpType = @EmpType, Username = @Username, Password = @Password, IsActive = @IsActive, Designation = @Designation, DOJ = @DOJ, EmailCode = @EmailCode, SMSCode = @SMSCode WHERE EmployeeID = @EmployeeID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", objEmployee.Name));
            lstParams.Add(new SqlParameter("@Email", objEmployee.Email));
            lstParams.Add(new SqlParameter("@Phone", objEmployee.Phone));
            lstParams.Add(new SqlParameter("@Photo", objEmployee.Photo));
            lstParams.Add(new SqlParameter("@Address", objEmployee.Address));
            lstParams.Add(new SqlParameter("@DOB", objEmployee.DOB));
            lstParams.Add(new SqlParameter("@Gender", objEmployee.Gender));
            lstParams.Add(new SqlParameter("@EmpType", objEmployee.EmpType));
            lstParams.Add(new SqlParameter("@Username", objEmployee.Username));
            lstParams.Add(new SqlParameter("@Password", objEmployee.Password));
            lstParams.Add(new SqlParameter("@IsActive", objEmployee.IsActive));
            lstParams.Add(new SqlParameter("@Designation", objEmployee.Designation));
            
            lstParams.Add(new SqlParameter("@DOJ", objEmployee.DOJ));
            lstParams.Add(new SqlParameter("@EmployeeID", objEmployee.EmployeeID));
            lstParams.Add(new SqlParameter("@EmailCode", objEmployee.EmailCode));
            lstParams.Add(new SqlParameter("@SMSCode", objEmployee.SMSCode));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int EmployeeID)
        {
            string query = "delete Employee WHERE EmployeeID = @EmployeeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmployeeID", EmployeeID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Employee SelectByID(int EmployeeID)
        {
            string query = "select * from Employee WHERE EmployeeID = @EmployeeID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmployeeID", EmployeeID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();
                
                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();
               
            }

            return objEmployee;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Employee";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectDes()
        {
            string query = "select DISTINCT Designation from Employee";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectEmp()
        {
            string query = "select Name,Designation,Email from Employee";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public Employee selectUP(String Username, String Password)
        {
            String query = "select * from Employee where Username=@Username AND Password=@Password";
             List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Username", Username));
             lstParams.Add(new SqlParameter("@Password", Password));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();
                
                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();
            }
            return objEmployee;
            
       
        }

      

        public DataTable Search(String name,String Designation)
        {
            string Query = "select * from Employee where Name like '%'+@Name+'%' and (@Designation = 'All Designation' OR Designation = @Designation)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", name));
            lstParams.Add(new SqlParameter("@Designation", Designation));
            //DataTable dt = DBUtility.SelectData(Query, lstParams);
            return DBUtility.SelectData(Query, lstParams);

           
        }
        public Employee SelectEmail(string Email)
        {
            string query = "select * from Employee WHERE Email = @Email";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Email", Email));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();

                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();
            }

            return objEmployee;
        }

        public Employee SelectByUIC(string EmailCode)
        {
            string query = "select * from Employee WHERE EmailCode = @EmailCode";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmailCode", EmailCode));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();
                
                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();
               
            }

            return objEmployee;
        }


        public Employee SelectPhone(long Phone)
        {
            string query = "select * from Employee WHERE Phone = @Phone";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Phone", Phone));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();

                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();
            }

            return objEmployee;
        }

        public Employee SelectByCode(string SMSCode)
        {
            string query = "select * from Employee WHERE SMSCode = @SMSCode";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@SMSCode", SMSCode));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Employee objEmployee = new Employee();
            if (dt.Rows.Count > 0)
            {
                objEmployee.Name = dt.Rows[0]["Name"].ToString();
                objEmployee.Email = dt.Rows[0]["Email"].ToString();
                objEmployee.Phone = dt.Rows[0]["Phone"].ToString();
                objEmployee.Photo = dt.Rows[0]["Photo"].ToString();
                objEmployee.Address = dt.Rows[0]["Address"].ToString();
                objEmployee.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
                objEmployee.Gender = dt.Rows[0]["Gender"].ToString();
                objEmployee.EmpType = dt.Rows[0]["EmpType"].ToString();
                objEmployee.Username = dt.Rows[0]["Username"].ToString();
                objEmployee.Password = dt.Rows[0]["Password"].ToString();
                objEmployee.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objEmployee.IsActive = dt.Rows[0]["IsActive"].ToString();
                objEmployee.Designation = dt.Rows[0]["Designation"].ToString();

                objEmployee.DOJ = Convert.ToDateTime(dt.Rows[0]["DOJ"]);
                objEmployee.EmailCode = dt.Rows[0]["EmailCode"].ToString();
                objEmployee.SMSCode = dt.Rows[0]["SMSCode"].ToString();

            }

            return objEmployee;
        }

        public DataTable SelectForAndroid()
        {
            string query = "select EmployeeID,Name,Phone from Employee";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLogic
{
    public class AttendanceLogic : ILogic<Attendance>
    {
        public int Insert(Attendance objAttendance)
        {
            string query = "insert Attendance values (@EmployeeID, @Adate, @Mark)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmployeeID", objAttendance.EmployeeID));
            lstParams.Add(new SqlParameter("@Adate", objAttendance.Adate));
            lstParams.Add(new SqlParameter("@Mark", objAttendance.Mark));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Attendance objAttendance)
        {
            string query = "update Attendance set EmployeeID = @EmployeeID, Adate = @Adate, Mark = @Mark where AttendanceID = @AttendanceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmployeeID", objAttendance.EmployeeID));
            lstParams.Add(new SqlParameter("@Adate", objAttendance.Adate));
            lstParams.Add(new SqlParameter("@Mark", objAttendance.Mark));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int AttendanceID)
        {
            string query = "delete Attendance WHERE AttendanceID = @AttendanceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Attendance", AttendanceID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Attendance SelectByID(int AttendanceID)
        {
            string query = "select * from Attendance WHERE AttendanceID = @AttendanceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@AttendanceID", AttendanceID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Attendance objAttendance = new Attendance();
            if (dt.Rows.Count > 0)
            {
                objAttendance.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objAttendance.AttendanceID = Convert.ToInt32(dt.Rows[0]["AttendanceID"]);
                objAttendance.Adate = Convert.ToDateTime(dt.Rows[0]["Adate"]);
                objAttendance.Mark = Convert.ToBoolean(dt.Rows[0]["Mark"]);
            }
            return objAttendance;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Attendance";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable Select()
        {
            string query = @"select A.*,E.Name as EmployeeName,E.EmployeeID
                                from Attendance as A
                                inner join Employee as E on A.EmployeeID = E.EmployeeID
                                order by A.ADate desc";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable Search(DateTime dt)
        {
            string query = @"select A.*,E.Name as EmployeeName,E.EmployeeID
                                from Attendance as A
                                inner join Employee as E on A.EmployeeID = E.EmployeeID
                                where A.ADate = @Date
                                order by A.ADate desc";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Date", dt));

            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectForAttendanceReport(DateTime ADate)
        {
           /* string query = @"select A.*, COUNT(Mark) AS 'ProductsCount'
                                from Customer 
                                INNER JOIN Product ON Product.CustomerID = Customer.CustomerID
                                GROUP BY Customer.CustomerID, Customer.Name";
            */
            string query = @"SELECT Name='Present',COUNT(AttendanceID) as Count 
                                FROM Attendance
                                where Mark = '1' and ADate=@Date 
                                
                            union 

                             SELECT Name='Absent',COUNT(AttendanceID) as Count 
                                FROM Attendance 
                                where Mark = '0' and ADate=@Date
                                


                        ";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Date", ADate));
            return DBUtility.SelectData(query, lstParams);
        }


        public DataTable SelectForEmp(int EmployeeID)
        {

            string query = @"SELECT Name='Present',COUNT(AttendanceID) as Count 
                                FROM Attendance
                                where Mark = '1' and EmployeeID=@EmployeeID
                                
                            union 

                             SELECT Name='Absent',COUNT(AttendanceID) as Count 
                                FROM Attendance 
                                where Mark = '0' and EmployeeID=@EmployeeID
                                ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@EmployeeID", EmployeeID));
            return DBUtility.SelectData(query, lstParams);
        }
    }
}

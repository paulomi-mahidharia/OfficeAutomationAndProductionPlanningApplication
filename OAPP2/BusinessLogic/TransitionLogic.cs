using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class TransitionLogic : ILogic<Transition>
    {
        public int Insert(Transition objTransition)
        {
            string query = "insert Transition values (@KeyID, @KeyType, @TranDate, @NewStatus, @Remarks)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@KeyID", objTransition.KeyID));
            lstParams.Add(new SqlParameter("@KeyType", objTransition.KeyType));
            lstParams.Add(new SqlParameter("@TranDate", objTransition.TranDate));
            lstParams.Add(new SqlParameter("@NewStatus", objTransition.NewStatus));
            lstParams.Add(new SqlParameter("@Remarks", objTransition.Remarks));
            
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Transition objTransition)
        {
            string query = "update Transition set KeyID = @KeyID, KeyType = @KeyType, TranDate = @TranDate, NewStatus = @NewStatus, Remarks = @Remarks ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@KeyID", objTransition.KeyID));
            lstParams.Add(new SqlParameter("@KeyType", objTransition.KeyType));
            lstParams.Add(new SqlParameter("@TranDate", objTransition.TranDate));
            lstParams.Add(new SqlParameter("@NewStatus", objTransition.NewStatus));
            lstParams.Add(new SqlParameter("@Remarks", objTransition.Remarks));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int TransitionID)
        {
            string query = "delete Transition WHERE TransitionID = @TransitionID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@TransitionID", TransitionID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Transition SelectByID(int TransitionID)
        {
            string query = "select * from Transition WHERE TransitionID = @TransitionID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@TransitionID", TransitionID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Transition objTransition = new Transition();
            if (dt.Rows.Count > 0)
            {
                objTransition.KeyID = Convert.ToInt32(dt.Rows[0]["KeyID"]);
                objTransition.KeyType = dt.Rows[0]["KeyType"].ToString();
                objTransition.TranDate = Convert.ToDateTime(dt.Rows[0]["TranDate"].ToString());
                objTransition.NewStatus = dt.Rows[0]["NewStatus"].ToString();
                objTransition.Remarks = dt.Rows[0]["Remarks"].ToString();
                
            }

            return objTransition;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Transition";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectForOrderReport()
        {
           /* string query = @"select T.*,CO.PONumber,CO.PODate,CO.CreateDate,CO.Quantity,P.Name as ProductName,C.Name as CustomerName 
                            from Transition as T
                            inner join COrder as CO on T.KeyID = CO.OrderID
                            inner join Product as P on CO.ProductID = P.ProductID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            where T.KeyType = 'Ord' and TranDate Between @today and @tomorrow";*/
            string query = @"select Distinct T.KeyID,T.Remarks,CO.PONumber,CO.PODate,CO.CreateDate,CO.Quantity,CO.Status,P.Name as ProductName,C.Name as CustomerName 
                            from COrder as CO 
                            inner join Product as P on CO.ProductID = P.ProductID
                            left join Transition as T on CO.OrderID = T.KeyID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            where (T.KeyType = 'Ord' or CO.Status='Order Created') and (CO.Status <> 'Closed' OR (CO.Status = 'Closed' and T.TranDate Between @today and @tomorrow))
                            ";
                           
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@today", DateTime.Today));
            lstParams.Add(new SqlParameter("@tomorrow", DateTime.Today.AddDays(1)));

            return DBUtility.SelectData(query, lstParams);
        }

       /* public DataTable SelectOrderStatus(string Status,DateTime dt)
        {
            string query = @"select P.Name
             from Transition as T
             inner join COrder as co on T.KeyID = co.OrderID
             inner join Product as P on co.ProductID = P.ProductID
             where T.KeyType = 'Ord' and co.Status = @Status and T.TranDate = @Date";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@Date", dt));
            return DBUtility.SelectData(query, lstParams);
        }*/
        public DataTable SelectOrderStatus(string Status, DateTime dt)
        {
            string query = @"select DISTINCT P.Name
             from Transition as T
             inner join COrder as co on T.KeyID = co.OrderID
             inner join Product as P on co.ProductID = P.ProductID
             where T.KeyType = 'Ord' and co.Status = @Status";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@today", dt));
            lstParams.Add(new SqlParameter("@tomorrow", dt.AddDays(1)));
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectOrderStatusClosed(string Status, DateTime dt)
        {
            string query = @"select distinct top 1 P.Name, T.Trandate as Tdate
             from Transition as T
             inner join COrder as co on T.KeyID = co.OrderID
             inner join Product as P on co.ProductID = P.ProductID
             where T.KeyType = 'Ord' and co.Status = @Status
             order by T.TranDate desc
             ";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@today", dt));
            lstParams.Add(new SqlParameter("@tomorrow", dt.AddDays(1)));
            return DBUtility.SelectData(query, lstParams);
        }
        

        public DataTable SelectForProductReport()
        {
            /*string query = @"select T.*,P.*,C.Name as CustomerName 
                            from Transition as T
                            inner join Product as P on T.KeyID = P.ProductID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            where T.KeyType = 'Prod' and TranDate Between @today and @tomorrow";*/
            string query = @"select Distinct T.KeyID,P.*,C.Name as CustomerName 
                            from Product as P
                            inner join Transition as T on P.ProductID = T.KeyID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            where (T.KeyType = 'Prod' OR P.Status = 'Product Created' )and(P.Status <> 'product approved' or (P.Status = 'product approved' and T.TranDate Between @today and @tomorrow))";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@today", DateTime.Today));
            lstParams.Add(new SqlParameter("@tomorrow", DateTime.Today.AddDays(1)));

            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectProductStatus(string Status, DateTime dt)
        {
            string query = @"select Distinct P.Name
             from Transition as T
       
             inner join Product as P on T.KeyID = P.ProductID
             where T.KeyType = 'Prod' and P.Status = @Status";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@today", dt));
            lstParams.Add(new SqlParameter("@tomorrow", dt.AddDays(1)));
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectProductStatusApproved(string Status, DateTime dt)
        {
            string query = @"select Distinct top 1 P.Name
             from Transition as T
       
             inner join Product as P on T.KeyID = P.ProductID
             where T.KeyType = 'Prod' and P.Status = @Status";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            lstParams.Add(new SqlParameter("@today", dt));
            lstParams.Add(new SqlParameter("@tomorrow", dt.AddDays(1)));
            return DBUtility.SelectData(query, lstParams);
        }

public DataTable SelectProductStatus1(DateTime dt)
        {
            string query = @"SELECT Status, COUNT(ProductID) AS 'Total' FROM Product GROUP BY Status";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Date", dt));
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectOrderStatus1(DateTime dt)
        {
            string query = @"SELECT Status, COUNT(OrderID) AS 'Total' FROM COrder GROUP BY Status";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Date", dt));
            return DBUtility.SelectData(query, lstParams);
        }
    }
}

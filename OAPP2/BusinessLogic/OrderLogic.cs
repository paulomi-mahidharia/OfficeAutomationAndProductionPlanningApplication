using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class OrderLogic : ILogic<Order>
    {
        public int Insert(Order objOrder)
        {
            string query = "insert COrder values ( @QuotationID, @ProductID, @Quantity, @Rate, @PONumber, @PODate, @CreateDate, @Status, @StatusRemarks, @EmployeeID, @DeliveryAddress, @DeliveryDate, @AttachPO, @JobPath)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@QuotationID", objOrder.QuotationID));
            lstParams.Add(new SqlParameter("@ProductID", objOrder.ProductID));
            lstParams.Add(new SqlParameter("@Quantity", objOrder.Quantity));
            lstParams.Add(new SqlParameter("@Rate", objOrder.Rate));
            lstParams.Add(new SqlParameter("@PONumber", objOrder.PONumber));
            lstParams.Add(new SqlParameter("@PODate", objOrder.PODate));
            lstParams.Add(new SqlParameter("@CreateDate", objOrder.CreateDate));
            lstParams.Add(new SqlParameter("@Status", objOrder.Status));
            lstParams.Add(new SqlParameter("@StatusRemarks", objOrder.StatusRemarks));
            lstParams.Add(new SqlParameter("@EmployeeID", objOrder.EmployeeID));
            lstParams.Add(new SqlParameter("@DeliveryAddress", objOrder.DeliveryAddress));
            lstParams.Add(new SqlParameter("@DeliveryDate", objOrder.DeliveryDate));
            lstParams.Add(new SqlParameter("@AttachPO", objOrder.AttachPO));
            lstParams.Add(new SqlParameter("@JobPath", objOrder.JobPath));
           
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Order objOrder)
        {
            string query = "update COrder set QuotationID = @QuotationID, ProductID = @ProductID, Quantity = @Quantity, Rate = @Rate, @PONumber = @PONumber, PODate = @PODate, CreateDate = @CreateDate, Status = @Status, StatusRemarks = @StatusRemarks, EmployeeID = @EmployeeID, DeliveryAddress = @DeliveryAddress, DeliveryDate = @DeliveryDate, AttachPO = @AttachPO, JobPath = @JobPath WHERE OrderID = @OrderID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@QuotationID", objOrder.QuotationID));
            lstParams.Add(new SqlParameter("@ProductID", objOrder.ProductID));
            lstParams.Add(new SqlParameter("@Quantity", objOrder.Quantity));
            lstParams.Add(new SqlParameter("@Rate", objOrder.Rate));
            lstParams.Add(new SqlParameter("@PONumber", objOrder.PONumber));
            lstParams.Add(new SqlParameter("@PODate", objOrder.PODate));
            lstParams.Add(new SqlParameter("@CreateDate", objOrder.CreateDate));
            lstParams.Add(new SqlParameter("@Status", objOrder.Status));
            lstParams.Add(new SqlParameter("@StatusRemarks", objOrder.StatusRemarks));
            lstParams.Add(new SqlParameter("@EmployeeID", objOrder.EmployeeID));
            lstParams.Add(new SqlParameter("@DeliveryAddress", objOrder.DeliveryAddress));
            lstParams.Add(new SqlParameter("@DeliveryDate", objOrder.DeliveryDate));
            lstParams.Add(new SqlParameter("@AttachPO", objOrder.AttachPO));
            lstParams.Add(new SqlParameter("@JobPath", objOrder.JobPath));
            lstParams.Add(new SqlParameter("@OrderID", objOrder.OrderID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int OrderID)
        {
            string query = "delete COrder WHERE OrderID = @OrderID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderID", OrderID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Order SelectByID(int OrderID)
        {
            string query = "select * from COrder WHERE OrderID = @OrderID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderID", OrderID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Order objOrder = new Order();
            if (dt.Rows.Count > 0)
            {
                objOrder.QuotationID = Convert.ToInt32(dt.Rows[0]["QuotationID"]);
                objOrder.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                objOrder.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
                objOrder.Rate = Convert.ToInt32(dt.Rows[0]["Rate"]);
                objOrder.PONumber = Convert.ToInt32(dt.Rows[0]["PONumber"]);
                objOrder.PODate = Convert.ToDateTime(dt.Rows[0]["PODate"]);
                objOrder.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                objOrder.Status = dt.Rows[0]["Status"].ToString();
                objOrder.StatusRemarks = dt.Rows[0]["StatusRemarks"].ToString();
                objOrder.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objOrder.DeliveryAddress = dt.Rows[0]["DeliveryAddress"].ToString();
                objOrder.DeliveryDate = Convert.ToDateTime(dt.Rows[0]["DeliveryDate"]);
                objOrder.AttachPO = dt.Rows[0]["AttachPO"].ToString();
                objOrder.JobPath = dt.Rows[0]["JobPath"].ToString();
                objOrder.OrderID = Convert.ToInt32(dt.Rows[0]["OrderID"]);
            }

            return objOrder;
        }

        public DataTable SelectAll()
        {
            string query = "select * from COrder";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectAllJoined()
        {
            string query = @"select  O.*, P.Name as 'ProductName', C.Name as CustomerName
                                    from COrder as O
                                    inner join Product as P on O.ProductID = P.ProductID
                                    inner join Customer as C on P.CustomerID = C.CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable Search(int CustomerID, int ProductID, DateTime From, DateTime To)
        {
            string query = @"select O.*,P.Name as ProductName,C.Name as CustomerName
                                from COrder as O
                                inner join Product as P on O.ProductID = P.ProductID
                                inner join Customer as C on P.CustomerID = C.CustomerID
                                where (@CustomerID = 0 or C.CustomerID = @CustomerID) and (@ProductID = 0 or P.ProductID = @ProductID)
                                and  O.CreateDate BETWEEN @StartDT AND @EndDT 
                                    ORDER BY O.CreateDate DESC";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StartDT", From));
            lstParams.Add(new SqlParameter("@EndDT", To));
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));
            lstParams.Add(new SqlParameter("@ProductID", ProductID));
            return DBUtility.SelectData(query, lstParams);
        }
	public DataTable SelectJob(int OrderID)
        {
            string q = @"select O.*, P.Name as JobName,C.Name as CustomerName
                            from COrder as O
                            inner join Product as P on O.ProductID = P.ProductID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            WHERE OrderID = @OrderID ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderID", OrderID));

            return DBUtility.SelectData(q, lstParams);
        }
    }
}

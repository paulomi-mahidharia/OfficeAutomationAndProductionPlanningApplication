using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class QuotationLogic : ILogic<Quotation>
    {
        public int Insert(Quotation objQuotation)
        {
            string query = "insert Quotation values (@ProductID, @MOQ, @Rate, @CreateDate, @Status, @Remarks, @TermsConditions, @EmployeeID, @QuotationPath)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ProductID", objQuotation.ProductID));
            lstParams.Add(new SqlParameter("@MOQ", objQuotation.MOQ));
            lstParams.Add(new SqlParameter("@Rate", objQuotation.Rate));
            lstParams.Add(new SqlParameter("@CreateDate", objQuotation.CreateDate));
            lstParams.Add(new SqlParameter("@Status", objQuotation.Status));
            lstParams.Add(new SqlParameter("@Remarks", objQuotation.Remarks));
            lstParams.Add(new SqlParameter("@TermsConditions", objQuotation.TermsConditions));
            lstParams.Add(new SqlParameter("@EmployeeID", objQuotation.EmployeeID));
            lstParams.Add(new SqlParameter("@QuotationPath", objQuotation.QuotationPath));
     
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Quotation objQuotation)
        {
            string query = "update Quotation set ProductID = @ProductID, MOQ = @MOQ, Rate = @Rate, CreateDate = @CreateDate, Status = @Status, Remarks = @Remarks, TermsConditions = @TermsConditions, EmployeeID = @EmployeeID, QuotationPath = @QuotationPath WHERE QuotationID = @QuotationID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ProductID", objQuotation.ProductID));
            lstParams.Add(new SqlParameter("@MOQ", objQuotation.MOQ));
            lstParams.Add(new SqlParameter("@Rate", objQuotation.Rate));
            lstParams.Add(new SqlParameter("@CreateDate", objQuotation.CreateDate));
            lstParams.Add(new SqlParameter("@Status", objQuotation.Status));
            lstParams.Add(new SqlParameter("@Remarks", objQuotation.Remarks));
            lstParams.Add(new SqlParameter("@TermsConditions", objQuotation.TermsConditions));
            lstParams.Add(new SqlParameter("@EmployeeID", objQuotation.EmployeeID));
            lstParams.Add(new SqlParameter("@QuotationID", objQuotation.QuotationID));
            lstParams.Add(new SqlParameter("@QuotationPath", objQuotation.QuotationPath));
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int QuotationID)
        {
            string query = "delete Quotation WHERE QuotationID = @QuotationID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@QuotationID", QuotationID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Quotation SelectByID(int QuotationID)
        {
            string query = "select * from Quotation WHERE QuotationID = @QuotationID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@QuotationID", QuotationID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Quotation objQuotation = new Quotation();
            if (dt.Rows.Count > 0)
            {
                objQuotation.ProductID =  Convert.ToInt32(dt.Rows[0]["ProductID"]);
                objQuotation.MOQ =  Convert.ToInt32(dt.Rows[0]["MOQ"]);
                objQuotation.Rate = Convert.ToInt32(dt.Rows[0]["Rate"]);
                objQuotation.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                objQuotation.Status = dt.Rows[0]["Status"].ToString();
                objQuotation.Remarks = dt.Rows[0]["Remarks"].ToString();
                objQuotation.TermsConditions = dt.Rows[0]["TermsConditions"].ToString();
                
                objQuotation.EmployeeID =  Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objQuotation.QuotationPath = dt.Rows[0]["QuotationPath"].ToString();
                objQuotation.QuotationID = Convert.ToInt32(dt.Rows[0]["QuotationID"]);
            }

            return objQuotation;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Quotation";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public Quotation SelectByProductID(int ProductID)
        {
            string query = "select * from Quotation WHERE ProductID = @ProductID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ProductID", ProductID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Quotation objQuotation = new Quotation();
            if (dt.Rows.Count > 0)
            {
                objQuotation.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                objQuotation.MOQ = Convert.ToInt32(dt.Rows[0]["MOQ"]);
                objQuotation.Rate = Convert.ToInt32(dt.Rows[0]["Rate"]);
                objQuotation.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                objQuotation.Status = dt.Rows[0]["Status"].ToString();
                objQuotation.Remarks = dt.Rows[0]["Remarks"].ToString();
                objQuotation.TermsConditions = dt.Rows[0]["TermsConditions"].ToString();
                objQuotation.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                objQuotation.QuotationPath = dt.Rows[0]["QuotationPath"].ToString();
                objQuotation.QuotationID = Convert.ToInt32(dt.Rows[0]["QuotationID"]);
            }

            return objQuotation;
        }

        public DataTable SelectAllJoined()
        {
            string query = @"select  Q.*, P.Name as 'ProductName', C.Name as CustomerName
                                    from Quotation as Q
                                    inner join Product as P on Q.ProductID = P.ProductID
                                    inner join Customer as C on P.CustomerID = C.CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

       

       public DataTable selectForPrint(string quoids)
        {
            /*string q = @"select I.*, R.Name as RawMaterialName, R.Code as RawMaterialCode
                            from Inventory as I
                            inner join RawMaterial as R on R.RawMaterialID = I.RawMaterialID
                            where InventoryID in (" + quoids + @")  ";*/
            string q = @"select Q.*, P.Name as ProductName,P.Size,P.Colors,C.Name as CustomerName, C.Email, C.Phone, C.OfficeAddress as Address
                            from Quotation as Q
                            inner join Product as P on Q.ProductID = P.ProductID
                            inner join Customer as C on P.CustomerID = C.CustomerID
                            where QuotationID in (" + quoids + @")
                             ";

            return DBUtility.SelectData(q, new List<SqlParameter>());
        }

        public DataTable SelectNotification()
        {
            string query = @"select top 10 * from
                                (
                                select top 10 
                                O.OrderID as ID,'An Order has been placed by '+C.Name+'.' as Data, 'Order' as Type,O.CreateDate as Date 
                                from COrder as O
                                inner join Product as P on O.ProductID = P.ProductID
                                inner join Customer as C on P.CustomerID = C.CustomerID
                                order by O.OrderID desc

                                 union

                                select top 10
                                ProductID as ID,'New Product '+Name+' has been created.' as Data, 'Product' as Type, CreateDate as Date
                                from Product
                                order by ProductID desc

                                union
                                
                                select top 10
                                Q.QuotationID as ID,'Quotation Generated for '+C.Name+'.' as Data, 'Quotation' as Type, Q.CreateDate as Date
                                from Quotation as Q
                                inner join Product as P on Q.ProductID = P.ProductID
                                inner join Customer as C on P.CustomerID = C.CustomerID
                                order by QuotationID desc
        
                                union

                                select top 10
                                I.InventoryID as ID,R.Name+' placed in Inventory.' as Data, 'Inventory' as Type, I.TrDate as Date
                                from Inventory as I
                                inner join RawMaterial as R on I.RawMaterialID = R.RawMaterialID
                                order by I.InventoryID desc
                                
                                union 
                                
                                select top 10
                                T.TransitionID as ID,P.Name+' has entered into status - '+T.NewStatus COLLATE DATABASE_DEFAULT as Data, 'Transition-Product' as Type, T.TranDate as Date
                                from Transition as T
                                inner join Product as P on T.KeyID = P.ProductID
                                where T.KeyType = 'Prod'
                                order by T.TranDate desc

                                union 
                                
                                select top 10
                                T.TransitionID as ID, 'Order for '+P.Name+' changed to status - '+T.NewStatus COLLATE DATABASE_DEFAULT as Data, 'Transition-Order' as Type, T.TranDate as Date
                                from Transition as T
                                inner join COrder as CO on T.KeyID = CO.OrderID
                                inner join Product as P on CO.ProductID = P.ProductID
                                where T.KeyType = 'ord'
                                order by T.TranDate desc

                                )T1
                                
                                order by Date desc";
                            List<SqlParameter> lstParams = new List<SqlParameter>();
                            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable Search(int CustomerID, int ProductID, DateTime From, DateTime To)
        {
            string query = @"select  Q.*, P.Name as 'ProductName', C.Name as CustomerName
                                    from Quotation as Q
                                    inner join Product as P on Q.ProductID = P.ProductID
                                    inner join Customer as C on P.CustomerID = C.CustomerID
                                    where (@CustomerID = 0 or C.CustomerID = @CustomerID) and (@ProductID = 0 or P.ProductID = @ProductID)
                                    and  Q.CreateDate BETWEEN @StartDT AND @EndDT 
                                    ORDER BY Q.CreateDate DESC";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StartDT", From));
            lstParams.Add(new SqlParameter("@EndDT", To));
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));
            lstParams.Add(new SqlParameter("@ProductID", ProductID));
            return DBUtility.SelectData(query, lstParams);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
  public  class InvoiceLogic : ILogic<Invoice>
    {
        public int Insert(Invoice objInvoice)
        {
            string query = "insert Invoice values (@OrderID, @InvoiceNo, @InvoiceDate, @GrandTotal, @InvoicePDF)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderID", objInvoice.OrderID));
            lstParams.Add(new SqlParameter("@InvoiceNo", objInvoice.InvoiceNo));
            lstParams.Add(new SqlParameter("@InvoiceDate", objInvoice.InvoiceDate));
            lstParams.Add(new SqlParameter("@GrandTotal", objInvoice.GrandTotal));
            lstParams.Add(new SqlParameter("@InvoicePDF", objInvoice.InvoicePDF));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Invoice objInvoice)
        {
            string query = "update Invoice set OrderID = @OrderID, InvoiceNo = @InvoiceNo, InvoiceDate= @InvoiceDate, GrandTotal = @GrandTotal WHERE InvoiceID = @InvoiceID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            
            lstParams.Add(new SqlParameter("@OrderID", objInvoice.OrderID));
            lstParams.Add(new SqlParameter("@InvoiceNo", objInvoice.InvoiceNo));
            lstParams.Add(new SqlParameter("@InvoiceDate", objInvoice.InvoiceDate));
            lstParams.Add(new SqlParameter("@GrandTotal", objInvoice.GrandTotal));
            lstParams.Add(new SqlParameter("@InvoicePDF", objInvoice.InvoicePDF));
            lstParams.Add(new SqlParameter("@InvoiceID", objInvoice.InvoiceID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int InvoiceID)
        {
            string query = "delete Invoice WHERE InvoiceID = @InvoiceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@InvoiceID", InvoiceID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Invoice SelectByID(int InvoiceID)
        {
            string query = "select * from Invoice WHERE InvoiceID = @InvoiceID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@InvoiceID", InvoiceID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Invoice objInvoice = new Invoice();
            if (dt.Rows.Count > 0)
            {
                objInvoice.OrderID = Convert.ToInt32(dt.Rows[0]["OrderID"]);
                objInvoice.InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
                objInvoice.InvoiceDate = Convert.ToDateTime(dt.Rows[0]["InvoiceDate"]);
                objInvoice.GrandTotal = Convert.ToSingle(dt.Rows[0]["GrandTotal"]);
                objInvoice.InvoicePDF = dt.Rows[0]["InvoicePDF"].ToString();
                objInvoice.InvoiceID = Convert.ToInt32(dt.Rows[0]["InvoiceID"]);
            }

            return objInvoice;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Invoice";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectForInvoice(int OrderID)
        {
            string query = @"select C.Name as CustomerName, C.OfficeAddress, P.Name as ProductName, CO.Quantity, CO.Rate  
            from COrder as CO 
            INNER JOIN Product as P on CO.ProductID = P.ProductID
            INNER JOIN Customer as C on P.CustomerID = C.CustomerID
            where CO.OrderID = @OrderID
                ";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@OrderID", OrderID));
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectAllJoined()
        {
            string query = @"select I.*, P.Name as ProductName
                from Invoice as I
                INNER JOIN COrder as CO on I.OrderID = CO.OrderID
                INNER JOIN Product as P on CO.ProductID = P.ProductID
                ";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectForBestOrder()
        {
            string query = @"select TOP 1 I.GrandTotal,P.Name as ProductName, C.Name as CustomerName, P.DesignFiles as ProductImage
                from Invoice as I
                INNER JOIN COrder as CO on I.OrderID=CO.OrderID
                INNER JOIN Product as P on CO.ProductID=P.ProductID
                INNER JOIN Customer as C on P.CustomerID=C.CustomerID
                ORDER BY I.GrandTotal DESC

                ";
         
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectForRevenue()
        {
            string query = @"select Sum(GrandTotal) as TotalIncome
                from Invoice
                where InvoiceDate between @FromDate and @ToDate
                

                ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FromDate", DateTime.Today.AddDays(-30)));
            lstParams.Add(new SqlParameter("@ToDate", DateTime.Today));
            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectIndividualInvoiceAmount()
        {
            string query = @"select GrandTotal
                from Invoice
                where InvoiceDate between @FromDate and @ToDate
                

                ";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FromDate", DateTime.Today.AddDays(-30)));
            lstParams.Add(new SqlParameter("@ToDate", DateTime.Today));
            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectTotalSale()
        {
            string query = @"select MONTH(InvoiceDate) as Month, SUM(GrandTotal) AS 'TotalValue'
                            from Invoice
                            where InvoiceDate between @FromDate and @ToDate
                            GROUP BY MONTH(InvoiceDate)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FromDate", DateTime.Today.AddDays(-365)));
            lstParams.Add(new SqlParameter("@ToDate", DateTime.Today));
           
            return DBUtility.SelectData(query, lstParams);



        }
        public DataTable SelectTotalSale2()
        {
            string query = @"select MONTH(InvoiceDate) as Month, SUM(GrandTotal) AS 'TotalValue',CASE MONTH(InvoiceDate)
		                                                                                        When 1 then 'January'
		                                                                                        When 2 then 'February'
		                                                                                        When 3 then 'March'
		                                                                                        When 4 then 'April'
		                                                                                        When 5 then 'May'
		                                                                                        When 6 then 'June'
		                                                                                        When 7 then 'July'
		                                                                                        When 8 then 'August'
		                                                                                        When 9 then 'September'
		                                                                                        When 10 then 'October'
		                                                                                        When 11 then 'November'
		                                                                                        When 12 then 'December'
	                                                                                        End as MonthName
                            from Invoice
                            where InvoiceDate between @FromDate and @ToDate
                            GROUP BY MONTH(InvoiceDate)";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@FromDate", DateTime.Today.AddDays(-365)));
            lstParams.Add(new SqlParameter("@ToDate", DateTime.Today));

            return DBUtility.SelectData(query, lstParams);



        }

       
    }
}

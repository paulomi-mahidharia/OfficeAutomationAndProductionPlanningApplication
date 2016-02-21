using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
using System.Data;

namespace BusinessLogic
{
    public class ProductLogic
    {

        public int Insert(Product objProduct)
        {
            string query = "insert Product values (@name, @CreateDate, @DesignFiles, @Status, @Description, @Size, @Colors, @Type, @CustomerID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", objProduct.Name));
            lstParams.Add(new SqlParameter("@CreateDate", objProduct.CreateDate));
            lstParams.Add(new SqlParameter("@DesignFiles", objProduct.DesignFiles));
            lstParams.Add(new SqlParameter("@Status", objProduct.Status));
            lstParams.Add(new SqlParameter("@Description", objProduct.Description));
            lstParams.Add(new SqlParameter("@Size", objProduct.Size));
            lstParams.Add(new SqlParameter("@Colors", objProduct.Colors));
            lstParams.Add(new SqlParameter("@Type", objProduct.Type));
            lstParams.Add(new SqlParameter("@CustomerID", objProduct.CustomerID));
            
            return DataAccess.DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Product objProduct)
        {
            string query = "update Product set name = @name, CreateDate = @CreateDate, DesignFiles = @DesignFiles, Status = @Status, Description = @Description, Size = @Size, Colors = @Colors, Type = @Type, CustomerID = @CustomerID WHERE ProductID = @ProductID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", objProduct.Name));
            lstParams.Add(new SqlParameter("@CreateDate", objProduct.CreateDate));
            lstParams.Add(new SqlParameter("@DesignFiles", objProduct.DesignFiles));
            lstParams.Add(new SqlParameter("@Status", objProduct.Status));
            lstParams.Add(new SqlParameter("@Description", objProduct.Description));
            lstParams.Add(new SqlParameter("@Size", objProduct.Size));
            lstParams.Add(new SqlParameter("@Colors", objProduct.Colors));
            lstParams.Add(new SqlParameter("@Type", objProduct.Type));
            lstParams.Add(new SqlParameter("@CustomerID", objProduct.CustomerID));
            lstParams.Add(new SqlParameter("@ProductID", objProduct.ProductID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int ProductID)
        {
            string query = "delete Product WHERE ProductID = @ProductID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ProductID", ProductID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Product SelectByProductID(int ProductID)
        {
            string query = "select * from Product WHERE ProductID = @ProductID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ProductID", ProductID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Product objProduct = new Product();
            if (dt.Rows.Count > 0)
            {
                objProduct.Name = dt.Rows[0]["Name"].ToString();
                objProduct.CreateDate = Convert.ToDateTime(dt.Rows[0]["CreateDate"]);
                objProduct.DesignFiles = dt.Rows[0]["DesignFiles"].ToString();
                objProduct.Status = dt.Rows[0]["Status"].ToString();
                objProduct.Description = dt.Rows[0]["Description"].ToString();
                objProduct.Size = dt.Rows[0]["Size"].ToString();
                objProduct.Colors = dt.Rows[0]["Colors"].ToString();
                objProduct.Type = dt.Rows[0]["Type"].ToString();
                objProduct.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                objProduct.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
              
            }

            return objProduct;
        }

        public System.Data.DataTable SelectAll()
        {
            string query = "select * from Product";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectAllJoined()
        {
            string query = @"select  P.*, C.Name as 'CustomerName'
                                    from Product as P
                                    inner join Customer as C on C.CustomerID = P.CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
	 public DataTable Search(String Name,String Type,int CustomerID)
        {
            string query = @"select P.*,C.Name as CustomerName
                                from Product as P
                                inner join Customer as C on P.CustomerID = C.CustomerID
                                where P.Name like '%'+@Name+'%' and (@Type = 'All Types' OR Type = @Type) 
                                and (@CustomerID = 0 OR P.CustomerID = @CustomerID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", Name));
            lstParams.Add(new SqlParameter("@Type", Type));
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));
            return DBUtility.SelectData(query, lstParams);
        }

     public DataTable SelectBestProduct()
     {
         string query = @"select top 1 count(C.OrderID) as Total, P.ProductID, P.Name, P.DesignFiles
                from Product as P
                inner join COrder as C on C.ProductID = P.ProductID
                group by P.ProductID, P.Name, P.DesignFiles
                order by Total desc
                ";

         List<SqlParameter> lstParams = new List<SqlParameter>();
         lstParams.Add(new SqlParameter("@FromDate", DateTime.Today.AddDays(-30)));
         lstParams.Add(new SqlParameter("@ToDate", DateTime.Today));
         return DBUtility.SelectData(query, lstParams);
     }

	public System.Data.DataTable SelectStatus(String Status)
        {
            string query = "select Name from Product where Status = @Status";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Status", Status));
            return DBUtility.SelectData(query, lstParams);
        }
    }
}
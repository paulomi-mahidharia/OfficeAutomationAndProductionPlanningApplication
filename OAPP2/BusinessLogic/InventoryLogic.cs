using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class InventoryLogic : ILogic<Inventory>
    {
        public int Insert(Inventory objInventory)
        {
            string query = "insert Inventory values (@RawMaterialID, @Quantity, @TrDate, @Remarks, @EmployeeID, @GRNID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RawMaterialID", objInventory.RawMaterialID));
            lstParams.Add(new SqlParameter("@Quantity", objInventory.Quantity));
            lstParams.Add(new SqlParameter("@TrDate", objInventory.TrDate));
            lstParams.Add(new SqlParameter("@Remarks", objInventory.Remarks));
            lstParams.Add(new SqlParameter("@EmployeeID", objInventory.EmployeeID));
            lstParams.Add(new SqlParameter("@GRNID", objInventory.GRNID));
     
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Inventory objInventory)
        {
            string query = "update Inventory set RawMaterialID = @RawMaterialID, Quantity = @Quantity, TrDate = @TrDate, Remarks = @Remarks, EmployeeID = @EmployeeID, GRNID = @GRNID WHERE InventoryID = @InventoryID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RawMaterialID", objInventory.RawMaterialID));
            lstParams.Add(new SqlParameter("@Quantity", objInventory.Quantity));
            lstParams.Add(new SqlParameter("@TrDate", objInventory.TrDate));
            lstParams.Add(new SqlParameter("@Remarks", objInventory.Remarks));
            
            lstParams.Add(new SqlParameter("@EmployeeID", objInventory.EmployeeID));
            lstParams.Add(new SqlParameter("@GRNID", objInventory.GRNID));
            lstParams.Add(new SqlParameter("@InventoryID", objInventory.InventoryID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int InventoryID)
        {
            string query = "delete Inventory WHERE InventoryID = @InventoryID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@InventoryID", InventoryID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Inventory SelectByID(int InventoryID)
        {
            string query = "select * from Inventory WHERE InventoryID = @InventoryID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@InventoryID", InventoryID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Inventory objInventory = new Inventory();
            if (dt.Rows.Count > 0)
            {
                objInventory.RawMaterialID =  Convert.ToInt32(dt.Rows[0]["RawMaterialID"]);
                objInventory.Quantity =  Convert.ToInt32(dt.Rows[0]["Quantity"]);
                objInventory.TrDate = Convert.ToDateTime(dt.Rows[0]["TrDate"]);
                objInventory.Remarks = dt.Rows[0]["Remarks"].ToString();
                objInventory.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
               // objInventory.GRNID = Convert.ToInt32(dt.Rows[0]["GRNID"]);
                objInventory.InventoryID = Convert.ToInt32(dt.Rows[0]["InventoryID"]);
            }

            return objInventory;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Inventory";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
        public DataTable SelectAllJoined()
        {
           /* string query = @"select  I.*, R.Name as 'RawMaterialName',S.Name as SupplierName
                                    from Inventory as I
                                    inner join RawMaterial as R on R.RawMaterialID = I.RawMaterialID";*/
            string query = @"select  I.*, R.Name as RawMaterialName,S.Name as SupplierName,G.GRNPath
                                    from Inventory as I
                                    inner join RawMaterial as R on R.RawMaterialID = I.RawMaterialID
                                     inner join Supplier as S  on S.SupplierID = R.SupplierID
                                     left join GRN as G on G.GRNID = I.GRNID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable selectForPrint(string invids)
        {
            /*string q = @"select I.*, R.Name as RawMaterialName, R.Code as RawMaterialCode
                            from Inventory as I
                            inner join RawMaterial as R on R.RawMaterialID = I.RawMaterialID
                            where InventoryID in ("+invids+@")  ";
            return DBUtility.SelectData(q, new List<SqlParameter>());*/
            string q = @"select I.*, R.Name as ProductName,R.Name as RawMaterialName,R.Code as RawMaterialCode,S.Name as SupplierName
                            from Inventory as I
                            inner join RawMaterial as R on I.RawMaterialID = R.RawMaterialID
                            inner join Supplier as S on R.SupplierID = S.SupplierID
                            where InventoryID in (" + invids + @")
                             ";


            return DBUtility.SelectData(q, new List<SqlParameter>());
        }
             public DataTable Search(DateTime From,DateTime To,int SupplierID)
        {
            string query = @"select I.*,S.Name as SupplierName,R.Name as RawMaterialName,G.GRNPath
                                from Inventory as I
                                inner join RawMaterial as R on I.RawMaterialID = R.RawMaterialID
                                inner join Supplier as S on R.SupplierID = S.SupplierID
                                 left join GRN as G on G.GRNID = I.GRNID
                                 WHERE (@SupplierID = 0 OR R.SupplierID = @SupplierID) and  I.TrDate BETWEEN @StartDT AND @EndDT 
                                    ORDER BY I.TrDate DESC";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@StartDT", From));
            lstParams.Add(new SqlParameter("@EndDT", To));
            lstParams.Add(new SqlParameter("@SupplierID", SupplierID));
            return DBUtility.SelectData(query, lstParams);
        }


             public DataTable SelectRawStock()
             {
                 string query = @"select R.Name as RawMaterialName,Sum(I.Quantity) as Stock
                                from Inventory as I
                                inner join RawMaterial as R on I.RawMaterialID = R.RawMaterialID
                              group by R.Name";
                 List<SqlParameter> lstParams = new List<SqlParameter>();
                 return DBUtility.SelectData(query, lstParams);
             }
    }
}

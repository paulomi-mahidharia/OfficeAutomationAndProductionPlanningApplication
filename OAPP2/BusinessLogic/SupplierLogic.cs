using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class SupplierLogic : ILogic<Supplier>
    {
       
            public int Insert(Supplier objSupplier)
            {
                string query = "insert Supplier values (@Name, @Phone, @Email, @ContactPerson)";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@Name", objSupplier.Name));
                lstParams.Add(new SqlParameter("@Phone", objSupplier.Phone));
                lstParams.Add(new SqlParameter("@Email", objSupplier.Email));
                lstParams.Add(new SqlParameter("@ContactPerson", objSupplier.ContactPerson));

                return DBUtility.ModifyData(query, lstParams);
            }

            public int Update(Supplier objSupplier)
            {
                string query = "update Supplier set name = @name, email = @email, Phone = @phone, ContactPerson = @ContactPerson WHERE SupplierID = @SupplierID";

                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@name", objSupplier.Name));
                lstParams.Add(new SqlParameter("@Phone", objSupplier.Phone));
                lstParams.Add(new SqlParameter("@Email", objSupplier.Email));
                lstParams.Add(new SqlParameter("@ContactPerson", objSupplier.ContactPerson));
                lstParams.Add(new SqlParameter("@SupplierID", objSupplier.SupplierID));

                return DBUtility.ModifyData(query, lstParams);
            }

            public int Delete(int SupplierID)
            {
                string query = "delete Supplier WHERE SupplierID = @SupplierID";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@SupplierID", SupplierID));

                return DBUtility.ModifyData(query, lstParams);
            }

            public Supplier SelectByID(int SupplierID)
            {
                string query = "select * from Supplier WHERE SupplierID = @SupplierID";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@SupplierID", SupplierID));

                DataTable dt = DBUtility.SelectData(query, lstParams);

                Supplier objSupplier = new Supplier();
                if (dt.Rows.Count > 0)
                {
                    objSupplier.Name = dt.Rows[0]["Name"].ToString();
                    objSupplier.Phone = dt.Rows[0]["Phone"].ToString();
                    objSupplier.Email = dt.Rows[0]["Email"].ToString();
                    objSupplier.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                    objSupplier.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"]);
                }

                return objSupplier;
            }

            public DataTable SelectAll()
            {
                string query = "select * from Supplier";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                return DBUtility.SelectData(query, lstParams);
            }

            public DataTable SelectHistory(int SupplierID)
            {
                string query = @"select S.*,R.Name as RawMaterialName,R.Code,R.Category,R.Type,I.TrDate,I.Quantity
                                 from Supplier as S
                                 inner join RawMaterial as R on S.SupplierID = R.SupplierID
                                 inner join Inventory as I on R.RawMaterialID = I.RawMaterialID
                                 where S.SupplierID = @SupplierID
                                    order by I.TrDate desc";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@SupplierID", SupplierID));
                return DBUtility.SelectData(query, lstParams);
            }

            public DataTable SearchHistory(int SupplierID,string RawMaterialName,DateTime From,DateTime To)
            {
                string query = @"select S.*,R.Name as RawMaterialName,R.Code,R.Category,R.Type,I.TrDate,I.Quantity
                                    from Supplier as S
                                    inner join RawMaterial as R on S.SupplierID = R.SupplierID
                                    inner join Inventory as I on R.RawMaterialID = I.RawMaterialID
                                    where S.SupplierID = @SupplierID and R.Name like '%'+@Name+'%'
                                    and  I.TrDate BETWEEN @StartDT AND @EndDT 
                                    order by I.TrDate desc";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@SupplierID", SupplierID));
                lstParams.Add(new SqlParameter("@StartDT", From));
                lstParams.Add(new SqlParameter("@EndDT", To));
                lstParams.Add(new SqlParameter("@Name", RawMaterialName));
                return DBUtility.SelectData(query, lstParams);
            }

            public DataTable Search(string Name)
            {
                string query = "select * from Supplier where Name like '%'+@Name+'%'";
                List<SqlParameter> lstParams = new List<SqlParameter>();
                lstParams.Add(new SqlParameter("@Name",Name));
                return DBUtility.SelectData(query, lstParams);
            }
        }
}
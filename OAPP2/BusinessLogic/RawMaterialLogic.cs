using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;



namespace BusinessLogic
{
    public class RawMaterialLogic : ILogic<RawMaterial>
    {
        public int Insert(RawMaterial objRawMaterial)
        {
            string query = "insert RawMaterial values (@name, @code, @Description, @Unit, @MinQuantity,  @SupplierID, @Category, @Type)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", objRawMaterial.Name));
            lstParams.Add(new SqlParameter("@code", objRawMaterial.Code));
            lstParams.Add(new SqlParameter("@Description", objRawMaterial.Descrition));
            lstParams.Add(new SqlParameter("@Unit", objRawMaterial.Unit));
            lstParams.Add(new SqlParameter("@MinQuantity", objRawMaterial.MinQuantity));
            lstParams.Add(new SqlParameter("@SupplierID", objRawMaterial.SupplierID));
            lstParams.Add(new SqlParameter("@Category", objRawMaterial.Category));
           
            lstParams.Add(new SqlParameter("@Type", objRawMaterial.Type));
            
            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(RawMaterial objRawMaterial)
        {
            string query = "update RawMaterial set name = @name, code = @code, Description = @Description, Unit = @Unit, MinQuantity = @MinQuantity, SupplierID = @SupplierID, Category = @Category, Type = @Type WHERE RawMaterialID = @RawMaterialID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
           
            lstParams.Add(new SqlParameter("@name", objRawMaterial.Name));
            lstParams.Add(new SqlParameter("@code", objRawMaterial.Code));
            lstParams.Add(new SqlParameter("@Description", objRawMaterial.Descrition));
            lstParams.Add(new SqlParameter("@Unit", objRawMaterial.Unit));
            lstParams.Add(new SqlParameter("@MinQuantity", objRawMaterial.MinQuantity));
            lstParams.Add(new SqlParameter("@SupplierID", objRawMaterial.SupplierID));
            lstParams.Add(new SqlParameter("@Category", objRawMaterial.Category));
            lstParams.Add(new SqlParameter("@Type", objRawMaterial.Type));
            lstParams.Add(new SqlParameter("@RawMaterialID", objRawMaterial.RawMaterialID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int RawMaterialID)
        {
            string query = "delete RawMaterial WHERE RawMaterialID = @RawMaterialID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RawMaterialID", RawMaterialID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public RawMaterial SelectByID(int RawMaterialID)
        {
            string query = "select * from RawMaterial WHERE RawMaterialID = @RawMaterialID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@RawMaterialID", RawMaterialID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            RawMaterial objRawMaterial = new RawMaterial();
            if (dt.Rows.Count > 0)
            {
                objRawMaterial.Name = dt.Rows[0]["Name"].ToString();
                objRawMaterial.Code = Convert.ToInt32(dt.Rows[0]["Code"]);
                objRawMaterial.Descrition = dt.Rows[0]["Description"].ToString();
                objRawMaterial.Unit = dt.Rows[0]["Unit"].ToString();
                objRawMaterial.MinQuantity = Convert.ToInt32(dt.Rows[0]["MinQuantity"]);
                objRawMaterial.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"]);
                objRawMaterial.Category = dt.Rows[0]["Category"].ToString();
                objRawMaterial.Type = dt.Rows[0]["Type"].ToString();
                objRawMaterial.RawMaterialID = Convert.ToInt32(dt.Rows[0]["RawMaterialID"]);
                
            }

            return objRawMaterial;
        }

        public DataTable SelectAll()
        {
            string query = "select * from RawMaterial";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }

        public DataTable SelectAllJoined()
        {
            string Query = @"select R.*,S.Name as SupplierName
                                from RawMaterial as R
                                inner join Supplier as S on R.SupplierID = S.SupplierID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(Query, lstParams);
            
        }

        public DataTable Search(String Name, String Category, int SupplierID)
        {
            string Query = @"select R.*,S.Name as SupplierName
                                from RawMaterial as R
                                inner join Supplier as S on R.SupplierID = S.SupplierID
                                where R.Name like '%'+@Name+'%' and (@Category = 'All Category' OR R.Category = @Category) 
                                and (@SupplierID = 0 OR R.SupplierID = @SupplierID)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", Name));
            lstParams.Add(new SqlParameter("@Category", Category));

            lstParams.Add(new SqlParameter("@SupplierID", SupplierID));
            //DataTable dt = DBUtility.SelectData(Query, lstParams);
            return DBUtility.SelectData(Query, lstParams);


        }


       
    }
}

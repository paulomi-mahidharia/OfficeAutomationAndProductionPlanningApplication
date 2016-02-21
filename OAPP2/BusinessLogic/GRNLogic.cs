using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class GRNLogic : ILogic<GRN>
    {
        public int Insert(GRN objGRN)
        {
            string query = "insert GRN values (@SupplierID, @GRNPath);SELECT @@IDENTITY;";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@SupplierID", objGRN.SupplierID));
            lstParams.Add(new SqlParameter("@GRNPath", objGRN.GRNPath));
            

            DataTable DT = DBUtility.SelectData(query, lstParams);
            return Convert.ToInt32(DT.Rows[0][0]);
        }

        public int Update(GRN objGRN)
        {
            string query = "update GRN set SupplierID = @SupplierID, GRNPath = @GRNPath WHERE GRNID = @GRNID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@SupplierID", objGRN.SupplierID));
            lstParams.Add(new SqlParameter("@GRNPath", objGRN.GRNPath)); 
           
            lstParams.Add(new SqlParameter("@GRNID", objGRN.GRNID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int GRNID)
        {
            string query = "delete GRN WHERE GRNID = @GRNID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@GRNID", GRNID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public GRN SelectByID(int GRNID)
        {
            string query = "select * from GRN WHERE GRNID = @GRNID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@GRNID", GRNID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            GRN objGRN = new GRN();
            if (dt.Rows.Count > 0)
            {
                objGRN.GRNID = Convert.ToInt32(dt.Rows[0]["GRNID"]);
                objGRN.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"]);
                objGRN.GRNPath = dt.Rows[0]["GRNPath"].ToString();
               
            }

            return objGRN;
        }

        public DataTable SelectAll()
        {
            string query = "select * from GRN";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DBUtility
    {
        public static DataTable SelectData(string query, List<SqlParameter> lstParams)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True;User Instance=True");

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddRange(lstParams.ToArray());

            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        public static int ModifyData(string query, List<SqlParameter> lstParams)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True;User Instance=True");

            SqlCommand comm = new SqlCommand(query, conn);
            comm.Parameters.AddRange(lstParams.ToArray());

            conn.Open();
            int x = comm.ExecuteNonQuery();
            conn.Close();

            return x;
        }
    }
}

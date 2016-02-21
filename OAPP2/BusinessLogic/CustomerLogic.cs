using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class CustomerLogic : ILogic<Customer>
    {
        public int Insert(Customer objCustomer)
        {
            string query = "insert Customer values (@name, @Email, @Phone, @ContactPerson, @OfficeAddress, @DeliveryAddress, @HeadOffice, @FactoryAddress, @GodownAddress, @OtherAddress)";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", objCustomer.Name));
            lstParams.Add(new SqlParameter("@Email", objCustomer.Email));
            lstParams.Add(new SqlParameter("@Phone", objCustomer.Phone));
            lstParams.Add(new SqlParameter("@ContactPerson", objCustomer.ContactPerson));
            lstParams.Add(new SqlParameter("@OfficeAddress", objCustomer.OfficeAddress));
            lstParams.Add(new SqlParameter("@DeliveryAddress", objCustomer.DeliveryAddress));
            lstParams.Add(new SqlParameter("@HeadOffice", objCustomer.HeadOffice));
            lstParams.Add(new SqlParameter("@FactoryAddress", objCustomer.FactoryAddress));
            lstParams.Add(new SqlParameter("@GodownAddress", objCustomer.GodownAddress));
            lstParams.Add(new SqlParameter("@OtherAddress", objCustomer.OtherAddress));
            lstParams.Add(new SqlParameter("@IsActive", objCustomer.OtherAddress));
           

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Update(Customer objCustomer)
        {
            string query = "update Customer set name = @name, email = @email, Phone = @phone, ContactPerson = @ContactPerson, OfficeAddress = @OfficeAddress, DeliveryAddress = @DeliveryAddress, HeadOffice = @HeadOffice, FactoryAddress = @FactoryAddress, GodownAddress = @GodownAddress, OtherAddress = @OtherAddress WHERE CustomerID = @CustomerID";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@name", objCustomer.Name));
            lstParams.Add(new SqlParameter("@Email", objCustomer.Email));
            lstParams.Add(new SqlParameter("@Phone", objCustomer.Phone));
            lstParams.Add(new SqlParameter("@ContactPerson", objCustomer.ContactPerson));
            lstParams.Add(new SqlParameter("@OfficeAddress", objCustomer.OfficeAddress));
            lstParams.Add(new SqlParameter("@DeliveryAddress", objCustomer.DeliveryAddress));
            lstParams.Add(new SqlParameter("@HeadOffice", objCustomer.HeadOffice));
            lstParams.Add(new SqlParameter("@FactoryAddress", objCustomer.FactoryAddress));
            lstParams.Add(new SqlParameter("@GodownAddress", objCustomer.GodownAddress));
            lstParams.Add(new SqlParameter("@OtherAddress", objCustomer.OtherAddress));
            lstParams.Add(new SqlParameter("@CustomerID", objCustomer.CustomerID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public int Delete(int CustomerID)
        {
            string query = "delete Customer WHERE CustomerID = @CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));

            return DBUtility.ModifyData(query, lstParams);
        }

        public Customer SelectByID(int CustomerID)
        {
            string query = "select * from Customer WHERE CustomerID = @CustomerID";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@CustomerID", CustomerID));

            DataTable dt = DBUtility.SelectData(query, lstParams);

            Customer objCustomer = new Customer();
            if (dt.Rows.Count > 0)
            {
                objCustomer.Name = dt.Rows[0]["Name"].ToString();
                objCustomer.Email = dt.Rows[0]["Email"].ToString();
                objCustomer.Phone = dt.Rows[0]["Phone"].ToString();
                objCustomer.ContactPerson = dt.Rows[0]["ContactPerson"].ToString();
                objCustomer.OfficeAddress = dt.Rows[0]["OfficeAddress"].ToString();
                objCustomer.DeliveryAddress = dt.Rows[0]["DeliveryAddress"].ToString();
                objCustomer.HeadOffice = dt.Rows[0]["HeadOffice"].ToString();
                objCustomer.FactoryAddress = dt.Rows[0]["FactoryAddress"].ToString();
                objCustomer.CustomerID = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                objCustomer.GodownAddress = dt.Rows[0]["GodownAddress"].ToString();
                objCustomer.OtherAddress = dt.Rows[0]["OtherAddress"].ToString();
               
            }

            return objCustomer;
        }

        public DataTable SelectAll()
        {
            string query = "select * from Customer";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
	
	public DataTable Search(String Name)
        {
          
         string Query = @"select * from Customer where Name like '%'+@Name+'%'";

          List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Name", Name));
          
            //DataTable dt = DBUtility.SelectData(Query, lstParams);
            return DBUtility.SelectData(Query, lstParams);


        }

        public DataTable SelectForReport1()
        {
            string query = @"select Customer.CustomerID, Customer.Name, COUNT(ProductID) AS 'ProductsCount'
                                from Customer 
                                INNER JOIN Product ON Product.CustomerID = Customer.CustomerID
                                GROUP BY Customer.CustomerID, Customer.Name";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            return DBUtility.SelectData(query, lstParams);
        }
    }
}

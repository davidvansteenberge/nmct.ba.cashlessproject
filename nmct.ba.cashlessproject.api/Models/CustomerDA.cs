using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace nmct.ba.cashlessproject.api.Models
{
    public class CustomerDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;
            return Database.CreateConnectionString("System.Data.SqlClient", @"LUNALAPPY\SQLEXPRESS", Cryptography.Decrypt(dbname), Cryptography.Decrypt(dblogin), Cryptography.Decrypt(dbpass));
        }

        public static List<Customer> GetCustomers(IEnumerable<Claim> claims)
        {
            List<Customer> list = new List<Customer>();
            string sql = "SELECT * FROM Customer";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
            return list;
        }

        public static Customer GetCustomerByID(int id, IEnumerable<Claim> claims)
        {
            string sql = "SELECT * FROM Customer WHERE ID=@ID";
            DbParameter parID = Database.AddParameter(Database.ADMIN_DB, "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            reader.Read();
            Customer c = Create(reader);
            reader.Close();
            return c;
        }

        public static int InsertCustomer(Customer c, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Customer VALUES(@CustomerName,@Address,@Picture,@Balance)";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@CustomerName", c.CustomerName);
            DbParameter par2 = Database.AddParameter(Database.ADMIN_DB, "@Address", c.Address);
            DbParameter par3 = Database.AddParameter(Database.ADMIN_DB, "@Picture", c.Picture);
            DbParameter par4 = Database.AddParameter(Database.ADMIN_DB, "@Balance", c.Balance);
            return Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4);
        }

        public static void UpdateCustomer(Customer c, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Customer SET CustomerName=@CustomerName, Address=@Address, Picture=@Picture, Balance=@Balance WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@CustomerName", c.CustomerName);
            DbParameter par2 = Database.AddParameter(Database.ADMIN_DB, "@Address", c.Address);
            DbParameter par3 = Database.AddParameter(Database.ADMIN_DB, "@Picture", c.Picture);
            DbParameter par4 = Database.AddParameter(Database.ADMIN_DB, "@Balance", c.Balance);
            DbParameter par5 = Database.AddParameter(Database.ADMIN_DB, "@ID", c.ID);
            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5);
        }

        public static void DeleteCustomer(int id, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM Customer WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@ID", id);
            DbConnection con = Database.GetConnection(CreateConnectionString(claims));
            Database.ModifyData(con, sql, par1);
        }

        private static Customer Create(IDataRecord record)
        {
            byte[] pic = (!DBNull.Value.Equals(record["Picture"]))?(byte[])record["Picture"]:new byte[0];

            return new Customer()
            {
                ID = Int32.Parse(record["ID"].ToString()),
                CustomerName = record["CustomerName"].ToString(),
                Address = record["Address"].ToString(),
                Picture = pic,
                Balance = Double.Parse(record["Balance"].ToString())
            };
        }
    }
}
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
    public class SalesDA
    {
        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"LUNALAPPY\SQLEXPRESS", Cryptography.Decrypt(dbname), Cryptography.Decrypt(dblogin), Cryptography.Decrypt(dbpass));
        }

        public static List<Sale> GetSales(IEnumerable<Claim> claims)
        {
            List<Sale> list = new List<Sale>();
            string sql = "SELECT * FROM Sales";
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql);
            while (reader.Read())
            {
                list.Add(Create(reader, claims));
            }
            reader.Close();
            return list;
        }

        public static List<Sale> GetSalesByID(int id, IEnumerable<Claim> claims)
        {
            string sql = "SELECT * FROM Sales WHERE ID=@ID";
            DbParameter parID = Database.AddParameter(Database.ADMIN_DB, "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql, parID);
            reader.Read();
            Sale s = Create(reader, claims);
            reader.Close();
            return s;
        }

        public static List<Sale> GetSalesByCustomerID(Customer c, IEnumerable<Claim> claims)
        {
            List<Sale> list = new List<Sale>();
            string sql = "SELECT * FROM Sales WHERE CustomerID=@ID";
            DbParameter parID = Database.AddParameter(Database.ADMIN_DB, "@ID", c.ID);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql, parID);
            while (reader.Read())
            {
                list.Add(Create(reader, claims));
            }
            reader.Close();
            return list;
        }

        public static List<Sale> GetSalesByRegisterID(Register r, IEnumerable<Claim> claims)
        {
            List<Sale> list = new List<Sale>();
            string sql = "SELECT * FROM Sales WHERE RegisterID=@ID";
            DbParameter parID = Database.AddParameter(Database.ADMIN_DB, "@ID", r.ID);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql,parID);
            while (reader.Read())
            {
                list.Add(Create(reader, claims));
            }
            reader.Close();
            return list;
        }

        public static List<Sale> GetSalesByProductID(Product p, IEnumerable<Claim> claims)
        {
            List<Sale> list = new List<Sale>();
            string sql = "SELECT * FROM Sales WHERE ProductID=@ID";
            DbParameter parID = Database.AddParameter(Database.ADMIN_DB, "@ID", p.ID);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql, parID);
            while (reader.Read())
            {
                list.Add(Create(reader, claims));
            }
            reader.Close();
            return list;
        }

        public static List<Sale> GetSalesByCustRegProdID(Customer c, Register r, Product p, IEnumerable<Claim> claims)
        {
            List<Sale> list = new List<Sale>();
            string sql = "SELECT * FROM Sales WHERE CustomerID=@CID And RegisterID=@RID And ProductID=@PID";
            DbParameter parCID = Database.AddParameter(Database.ADMIN_DB, "@CID", c.ID);
            DbParameter parRID = Database.AddParameter(Database.ADMIN_DB, "@RID", r.ID);
            DbParameter parPID = Database.AddParameter(Database.ADMIN_DB, "@PID", p.ID);
            DbDataReader reader = Database.GetData(Database.GetConnection(CreateConnectionString(claims)), sql, parCID, parRID, parPID);
            while (reader.Read())
            {
                list.Add(Create(reader, claims));
            }
            reader.Close();
            return list;
        }

        public static int InsterSale(Sale s, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Sales VALUES(@Timestamp,@CustomerID,@RegisterID,@ProductID,@Ammount,@TotalPrice)";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@Timestamp", s.Timestamp);
            DbParameter par2 = Database.AddParameter(Database.ADMIN_DB, "@CustomerID", s.CustomerID.ID);
            DbParameter par3 = Database.AddParameter(Database.ADMIN_DB, "@RegisterID", s.RegisterID.ID);
            DbParameter par4 = Database.AddParameter(Database.ADMIN_DB, "@ProductID", s.ProductID.ID);
            DbParameter par5 = Database.AddParameter(Database.ADMIN_DB, "@Ammount", s.Ammount);
            DbParameter par6 = Database.AddParameter(Database.ADMIN_DB, "@TotalPrice", s.TotalPrice);
            return Database.InsertData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5, par6);
        }

        public static void UpdateSale(Sale s, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Sales SET Timestamp=@Timestamp, CustomerID=@CustomerID, RegisterID=@RegisterID, ProductID=@ProductID, Ammount=@Ammount, TotalPrice=@TotalPrice WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@Timestamp", s.Timestamp);
            DbParameter par2 = Database.AddParameter(Database.ADMIN_DB, "@CustomerID", s.CustomerID.ID);
            DbParameter par3 = Database.AddParameter(Database.ADMIN_DB, "@RegisterID", s.RegisterID.ID);
            DbParameter par4 = Database.AddParameter(Database.ADMIN_DB, "@ProductID", s.ProductID.ID);
            DbParameter par5 = Database.AddParameter(Database.ADMIN_DB, "@Ammount", s.Ammount);
            DbParameter par6 = Database.AddParameter(Database.ADMIN_DB, "@TotalPrice", s.TotalPrice);
            DbParameter par7 = Database.AddParameter(Database.ADMIN_DB, "@ID", s.ID);
            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1, par2, par3, par4, par5, par6, par7);
        }

        public static void DeleteSale(int id, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM Sales WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@ID", id);
            Database.ModifyData(Database.GetConnection(CreateConnectionString(claims)), sql, par1);
        }

        private static Sale Create(IDataRecord record, IEnumerable<Claim> claims)
        {
            int cID = Int32.Parse(record["CustomerID"].ToString());
            Customer c = CustomerDA.GetCustomerByID(cID, claims);
            int rID = Int32.Parse(record["RegisterID"].ToString());
            Register r = RegistersDA.GetRegisterByIDClient(rID, claims);
            int pID = Int32.Parse(record["ProductID"].ToString());
            Product p = ProductsDA.GetProductByID(pID, claims);
            return new Sale()
            {
                ID = Int32.Parse(record["ID"].ToString()),
                Timestamp = record["Timestamp"].ToString(),
                CustomerID = c,
                RegisterID = r,
                ProductID = p,
                Ammount = Int32.Parse(record["Ammount"].ToString()),
                TotalPrice = Double.Parse(record["TotalPrice"].ToString()),
            };
        }
    }
}
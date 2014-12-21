using nmct.ba.cashlessproject.api.Helper;
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
    public class Organisation_RegisterDA
    {
        
        public static int GetFromDate(int orgID, int regID)
        {
            int result = 0;
            string sql = "SELECT FromDate FROM Organisation_Register WHERE OrganisationID=@OrganisationID And RegisterID=@RegisterID";
            DbParameter parOrgID = Database.AddParameter(Database.ADMIN_DB, "@OrganisationID", orgID);
            DbParameter parRegID = Database.AddParameter(Database.ADMIN_DB, "@RegisterID", regID);
            DbDataReader reader = Database.GetData(Database.GetConnection(Database.ADMIN_DB), sql, parOrgID, parRegID);

            while (reader.Read())
            {
                result = Int32.Parse(reader["FromDate"].ToString());
            }
            reader.Close();
            return result;
        }

        public static int GetUntillDate(int orgID, int regID)
        {
            int result = 0;
            string sql = "SELECT UntillDate FROM Organisation_Register WHERE OrganisationID=@OrganisationID And RegisterID=@RegisterID";
            DbParameter parOrgID = Database.AddParameter(Database.ADMIN_DB, "@OrganisationID", orgID);
            DbParameter parRegID = Database.AddParameter(Database.ADMIN_DB, "@RegisterID", regID);
            DbDataReader reader = Database.GetData(Database.GetConnection(Database.ADMIN_DB), sql, parOrgID, parRegID);
            while (reader.Read())
            {
                result = Int32.Parse(reader["UntillDate"].ToString());
            }
            reader.Close();
            return result;
        }

        public static int InsertOrganisationRegister(int orgID, int regID, int fromDate, int untillDate)
        {
            string sql = "INSERT INTO Organisation_Register VALUES(@OrganisationID,@RegisterID,@FromDate,@UntillDate)";
            DbParameter par1 = Database.AddParameter(Database.ADMIN_DB, "@OrganisationID", orgID);
            DbParameter par2 = Database.AddParameter(Database.ADMIN_DB, "@RegisterID", regID);
            DbParameter par3 = Database.AddParameter(Database.ADMIN_DB, "@FromDate", fromDate);
            DbParameter par4 = Database.AddParameter(Database.ADMIN_DB, "@UntillDate", untillDate);
            return Database.InsertData(Database.GetConnection(Database.ADMIN_DB), sql, par1, par2, par3, par4);
        }
    }
}
using System.Configuration;
using System.Data.SqlClient;

namespace Supermarket.Model.DataAccessLayer
{
    public class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDB"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}

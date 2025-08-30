// using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace CarRentalSystem.Utils
{
    public static class DBConnection
    {
        private static SqlConnection connection;

        /// <summary>
        /// Provides a SqlConnection object using PropertyUtil
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = PropertyUtil.GetPropertyString();
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
    }
}

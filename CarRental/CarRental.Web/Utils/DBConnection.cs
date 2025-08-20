using System.Data;
using Microsoft.Data.SqlClient;

namespace CarRental.Web.Utils
{
    public static class DBConnection
    {
        public static IDbConnection GetConnection(string connectionString)
            => new SqlConnection(connectionString);
    }
}

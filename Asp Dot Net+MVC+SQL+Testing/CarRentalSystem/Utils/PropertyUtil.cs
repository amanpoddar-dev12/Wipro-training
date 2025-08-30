using Microsoft.Extensions.Configuration;
using System.IO;

namespace CarRentalSystem.Utils
{
    public static class PropertyUtil
    {
        /// <summary>
        /// Reads the connection string from appsettings.json
        /// </summary>
        /// <param name="connectionName">Name of the connection string</param>
        /// <returns>Connection string</returns>
        public static string GetPropertyString(string connectionName = "DefaultConnection")
        {
            // Load configuration from appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString(connectionName);
        }
    }
}

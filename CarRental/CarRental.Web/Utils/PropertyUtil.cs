using Microsoft.Extensions.Configuration;

namespace CarRental.Web.Utils
{
    public static class PropertyUtil
    {
        public static string GetConnectionString(IConfiguration cfg, string name = "DefaultConnection")
            => cfg.GetConnectionString(name)
               ?? throw new InvalidOperationException($"Connection string '{name}' not found.");
    }
}

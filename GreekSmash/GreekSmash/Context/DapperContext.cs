using Microsoft.Data.SqlClient;
using System.Data;


namespace GreekSmash.Context
{
    /// <summary>
    /// Wrapper class for database context.
    /// </summary>
    public class DapperContext
    {
        /// <summary>
        /// This service reads key-value pairs from appsettings.
        /// </summary>
        private readonly IConfiguration _configuration;
        private string _connectionString;

        // Inject IConfiguration service - Dependency Injection
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;

            // Gets the database connection string we have set in appsettings.
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <returns>The db connection</returns>
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
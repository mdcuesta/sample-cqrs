using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sampler.CQRS.Data
{
    public class SqlConnectionManager : IConnectionManager
    {
        private const string DB_CONNECTION = "DbConnection";

        private readonly IConfiguration configuration;

        public SqlConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection Create()
        {
            string connectionString = this.configuration.GetConnectionString(DB_CONNECTION);
            return new SqlConnection(connectionString);
        }
    }
}

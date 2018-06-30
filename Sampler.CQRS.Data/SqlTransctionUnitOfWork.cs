using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Sampler.CQRS.Data
{
    public class SqlUnitOfWork : IUnitOfWork, IDisposable
    {
        private const string DB_CONNECTION = "DbConnection";

        private readonly IConfiguration configuration;
        private IDbTransaction transaction;

        private string ConnectionString =>
            configuration.GetConnectionString(DB_CONNECTION);

        public IDbConnection Connection { get; private set; }

        public SqlUnitOfWork(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Begin()
        {
            if (this.transaction != null)
                return;

            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            Connection = connection;
            this.transaction = Connection.BeginTransaction();
        }

        public void BeginAsync()
        {
            if (this.transaction != null)
                return;

            var connection = new SqlConnection(ConnectionString);
            connection.OpenAsync();
            Connection = connection;
            this.transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            this.transaction?.Commit();
        }

        public void RollBack()
        {
            this.transaction?.Rollback();
        }

        public void Dispose()
        {
            if (Connection == null)
                return;

            if (Connection.State != ConnectionState.Closed)
                Connection.Close();

            Connection.Dispose();
        }
    }
}

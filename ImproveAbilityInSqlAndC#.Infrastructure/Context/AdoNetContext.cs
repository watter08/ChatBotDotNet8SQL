using Microsoft.Data.SqlClient;
using System.Data;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Context
{
    public class AdoNetContext: IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public AdoNetContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public async Task OpenConnectionAsync()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                await _connection.OpenAsync();
            }
        }

        public async Task<DataTable> ExecuteQueryAsync(string query, params SqlParameter[] parameters)
        {
            await OpenConnectionAsync();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }

        }

        public async Task<int> ExecuteNonQueryAsync(string query, params SqlParameter[] parameters)
        {
            await OpenConnectionAsync();
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                return await command.ExecuteNonQueryAsync();
            }
        }

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }
    }
}

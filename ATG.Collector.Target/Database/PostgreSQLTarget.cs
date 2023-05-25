using System;
using System.Threading.Tasks;
using ATG.Collector.Types;

namespace ATG.Collector.Target.Database
{
    public class PostgreSQLTarget : IDisposable
    {
        private readonly string _connectionString;
        private NpgsqlConnection _connection;

        public PostgreSQLTarget(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new NpgsqlConnection(_connectionString);
        }

        public async Task<StoreResult> StoreAsync(List<CollectResultRow> data)
        {
            try
            {
                await _connection.OpenAsync();

                using var command = new NpgsqlCommand
                {
                    Connection = _connection,
                    CommandText =
                        "INSERT INTO YourTableName (key, tstamp, string_value, int_value, long_value, bool_value, tstamp_value) "
                        + "VALUES (@Key, @Tstamp, @StringValue, @IntValue, @LongValue, @BoolValue, @TstampValue)"
                };

                foreach (var row in data)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Key", data.Key);
                    command.Parameters.AddWithValue("@Tstamp", data.Tstamp ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue(
                        "@StringValue",
                        data.StringValue ?? string.Empty
                    );
                    command.Parameters.AddWithValue(
                        "@IntValue",
                        data.IntValue ?? (object)DBNull.Value
                    );
                    command.Parameters.AddWithValue(
                        "@LongValue",
                        data.LongValue ?? (object)DBNull.Value
                    );
                    command.Parameters.AddWithValue(
                        "@BoolValue",
                        data.BoolValue ?? (object)DBNull.Value
                    );
                    command.Parameters.AddWithValue(
                        "@TstampValue",
                        data.TstampValue ?? (object)DBNull.Value
                    );

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception here, log or throw as needed
                Console.WriteLine($"An error occurred while storing data: {ex.Message}");
            }
            finally
            {
                // Close the connection after use
                await _connection.CloseAsync();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}

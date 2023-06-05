using System;
using System.Data.Common;
using System.Threading.Tasks;
using ATG.Collector.Types;
using ATG.Collector.Types.Collect;
using ATG.Collector.Types.Interfaces;
using ATG.Collector.Types.Shared;
using Npgsql;

namespace ATG.Collector.Target.Database
{
    public class PostgreSQLTarget : IDisposable, IGeneralStore
    {
        private const string PROGRAM_NAME = "ATG.Collector.Target.Database.PostgreSQLTarget";

        private readonly string _connectionString;
        private NpgsqlConnection _connection;

        public PostgreSQLTarget(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new NpgsqlConnection(_connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
        }

        public void CloseConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
        }

        public StoreResult Store(CollectResult data)
        {
            // create the result instance we will return
            var result = new StoreResult();
            result.InvokeTstamp = DateTime.UtcNow;
            result.Reference = data.Reference;

            // open a new connection to the database
            // begin a transaction
            // and get the parametized insert command we can use
            OpenConnection();
            using var transaction = _connection.BeginTransaction();
            using var command = GetInsertCommand();

            // save each of the rows using the parametized sql command
            try
            {
                foreach (var row in data.Value)
                {
                    command.Parameters.Clear();
                    AddCommandParameters(command, row, data);
                    command.ExecuteNonQuery();
                }

                // if here, then no errors and we can commit the transaction
                transaction.Commit();
            }
            catch (DbException ex)
            {
                // something didn't work out, roll things back
                transaction.Rollback();

                // emit to console some details
                Console.WriteLine(
                    $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{Symbols.TABSYMBOL}{PROGRAM_NAME}{Symbols.TABSYMBOL}StoreAsync{Symbols.TABSYMBOL}Exception Thrown:"
                );
                Console.WriteLine("----------");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("----------");

                // return an error object
                return StoreResult.NewWithSingleError(
                    CollectErrors.EXCEPTION_THROWN,
                    ex.InnerException.ToString()
                );
            }

            // if here, then all good, set the execution time and return the result object
            result.ExecutionMillseconds = (long)
                DateTime.UtcNow.Subtract(result.InvokeTstamp).TotalMilliseconds;
            return result;
        }

        #region Private Helpers

        private NpgsqlCommand GetInsertCommand()
        {
            return new NpgsqlCommand
            {
                Connection = _connection,
                CommandText =
                    "INSERT INTO dataraw (key, tstamp, row_key, string_value, int_value, long_value, bool_value, tstamp_value) "
                    + "VALUES (@Key, @Tstamp, @RowKey, @StringValue, @IntValue, @LongValue, @BoolValue, @TstampValue)"
            };
        }

        private void AddCommandParameters(
            NpgsqlCommand command,
            CollectResultRow row,
            CollectResult data
        )
        {
            command.Parameters.AddWithValue("@Key", data.Reference);
            command.Parameters.AddWithValue("@Tstamp", data.InvokeTstamp);
            command.Parameters.AddWithValue("@RowKey", row.Key);
            command.Parameters.AddWithValue("@StringValue", row.StringValue ?? string.Empty);
            command.Parameters.AddWithValue("@IntValue", row.IntValue ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LongValue", row.LongValue ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BoolValue", row.BoolValue ?? (object)DBNull.Value);
            command.Parameters.AddWithValue(
                "@TstampValue",
                row.TstampValue ?? (object)DBNull.Value
            );
        }

        #endregion

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}

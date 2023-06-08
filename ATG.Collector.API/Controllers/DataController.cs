using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ATG.Collector.API.DataModels;

namespace ATG.Collector.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private enum AggregateToEnum
        {
            None = 0,
            FiveMinute = 5,
            ThirtyMinute = 30,
            Hour = 60
        }

        private readonly string _connectionString;

        public DataController(IConfiguration conf)
        {
            if (string.IsNullOrEmpty(_connectionString = conf.GetConnectionString("ValuesDB")))
            {
                throw new NullReferenceException(
                    "A connection string to the values database is required when constructing the controller."
                );
            }
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayData()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime tomorrow = DateTime.Today.AddDays(1);

                List<DataRaw> data = await GetDataAsync(
                    today,
                    tomorrow,
                    AggregateToEnum.FiveMinute
                );

                return Ok(data);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching today's data.");
            }
        }

        [HttpGet("yesterday")]
        public async Task<IActionResult> GetYesterdayData()
        {
            try
            {
                DateTime today = DateTime.Today.AddDays(-2);
                DateTime tomorrow = DateTime.Today.AddDays(-1);

                List<DataRaw> data = await GetDataAsync(
                    today,
                    tomorrow,
                    AggregateToEnum.FiveMinute
                );

                return Ok(data);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching yesterday's data.");
            }
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentData()
        {
            try
            {
                DateTime today = DateTime.Today.AddDays(-9);
                DateTime tomorrow = DateTime.Today.AddDays(1);

                List<DataRaw> data = await GetDataAsync(today, tomorrow, AggregateToEnum.Hour);

                return Ok(data);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching recent data.");
            }
        }

        [HttpGet("trend")]
        public async Task<IActionResult> GetTrendData()
        {
            try
            {
                DateTime today = DateTime.Today.AddDays(-31);
                DateTime tomorrow = DateTime.Today.AddDays(1);

                List<DataRaw> data = await GetDataAsync(today, tomorrow, AggregateToEnum.Hour);

                return Ok(data);
            }
            catch
            {
                return StatusCode(500, "An error occurred while fetching trend data.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDataRange(DateTime from, DateTime to)
        {
            try
            {
                var days = to.Subtract(from).Days;
                var aggregate =
                    days < 1
                        ? AggregateToEnum.None
                        : days < 2
                            ? AggregateToEnum.FiveMinute
                            : days < 3
                                ? AggregateToEnum.ThirtyMinute
                                : AggregateToEnum.Hour;
                List<DataRaw> data = await GetDataAsync(from, to, aggregate);

                return Ok(data);
            }
            catch
            {
                return StatusCode(
                    500,
                    "An error occurred while fetching data for the specified range."
                );
            }
        }

        private async Task<List<DataRaw>> GetDataAsync(
            DateTime from,
            DateTime to,
            AggregateToEnum aggregate = AggregateToEnum.None
        )
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string nonAggregatedQuery =
                    "SELECT tstamp, row_key, int_value FROM dataraw WHERE tstamp >= @From AND tstamp < @To";

                string aggregatedQuery =
                    $"SELECT date_trunc('minute', tstamp) - INTERVAL '1 minute' * (EXTRACT(MINUTE FROM tstamp)::integer % {(int)aggregate}) AS truncated_tstamp, "
                    + "row_key, avg(int_value) "
                    + "FROM dataraw WHERE tstamp >= @From AND tstamp < @To "
                    + "GROUP BY truncated_tstamp, row_key "
                    + "ORDER BY truncated_tstamp, row_key";

                string query =
                    aggregate == AggregateToEnum.None ? nonAggregatedQuery : aggregatedQuery;

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@From", from);
                    command.Parameters.AddWithValue("@To", to);

                    var data = new List<DataRaw>();

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new DataRaw
                            {
                                Tstamp = reader.GetDateTime(0),
                                RowKey = reader.GetString(1),
                                IntValue = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2)
                            };

                            data.Add(item);
                        }
                    }

                    return data;
                }
            }
        }
    }
}

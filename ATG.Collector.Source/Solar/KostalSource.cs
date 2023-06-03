using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ATG.Collector.Types;
using HtmlAgilityPack;

namespace ATG.Collector.Source.Solar
{
    public class KostalSource : ISolarSource
    {
        private const string PROGRAM_NAME = "ATG.Collector.Source.Solar.KostalSource";
        private const string TABSYMBOL = "\t";
        private CollectParameter _args;
        private HttpClient _client;

        public KostalSource(CollectParameter args)
        {
            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}Constructor{TABSYMBOL}Start"
            );

            // store the arguments
            _args = args;

            // construct the http client
            var authString = Convert.ToBase64String(
                System.Text.ASCIIEncoding.UTF8.GetBytes($"{_args.Username}:{_args.Password}")
            );
            _client = new HttpClient { BaseAddress = new Uri(_args.Endpoint) };
            _client.DefaultRequestHeaders.Add("Authorization", "Basic " + authString);
            _client.Timeout = TimeSpan.FromSeconds(5);

            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}Constructor{TABSYMBOL}End"
            );
        }

        public async Task<CollectResult> CollectAsync()
        {
            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}Start"
            );

            // need this for later
            var invokeTstamp = DateTime.UtcNow;

            // validation
            if (_args.Username == null || _args.Password == null)
            {
                return CollectResult.NewWithSingleError(CollectErrors.EMPTY_USERNAME_PASS, "");
            }

            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}Arguments valid"
            );

            // download and parse the webpage
            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync("/");
                response.EnsureSuccessStatusCode();
            }
            catch (System.AggregateException ex)
            {
                Console.WriteLine(
                    $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}Exception Thrown:"
                );
                Console.WriteLine("----------");
                Console.WriteLine(ex.Flatten().InnerException);
                Console.WriteLine("----------");

                return CollectResult.NewWithSingleError(
                    CollectErrors.EXCEPTION_THROWN,
                    ex.Flatten().InnerException.ToString()
                );
            }

            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}HTML response received"
            );

            var html = await response.Content.ReadAsStringAsync();
            var results = ParsePowerGeneration(html, invokeTstamp);
            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}HTML response parsed"
            );

            // update the return object to include the starting tstamp and the execution time
            results.InvokeTstamp = invokeTstamp;
            results.ExecutionMillseconds = (long)
                DateTime.UtcNow.Subtract(invokeTstamp).TotalMilliseconds;

            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}CollectAsync{TABSYMBOL}End"
            );

            return results;
        }

        private CollectResult ParsePowerGeneration(string html, DateTime invokeTstamp)
        {
            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}ParsePowerGeneration{TABSYMBOL}Start"
            );

            var results = new CollectResult();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // nasty html.. we will find what we need by starting at the label rows for each string
            var stringCells = doc.DocumentNode
                .SelectNodes("//td/u")
                .Where(e => e.InnerText.StartsWith("String "));

            foreach (var tdString in stringCells)
            {
                // jump up to the parent tr
                var parentRow = tdString.Ancestors("tr").First();

                // we are now at the header row for a string
                // next comes two rows, one for the Spannung, and the next row for the Strom and Leistung
                // we want the Leistung, so iterate until we get that row
                // we also need to skip empty rows which get produced unfortunately, these are known as Text types
                HtmlNode tr = parentRow.NextSibling;
                while (
                    tr.NodeType == HtmlNodeType.Text
                    || string.IsNullOrEmpty(tr.InnerText.Trim())
                    || tr.InnerText.Trim().StartsWith("Spannung")
                )
                    tr = tr.NextSibling;

                // we should now have the next row with the data we want
                // first we can get the cell just before the watt value by looking for Leistung in the value
                // unfortunately, to get the value we need to do a similar trick though to iterate through the siblings again
                var tdLeistung = tr.Descendants()
                    .First(td => td.InnerText.Trim().StartsWith("Leistung"));
                HtmlNode tdWatts = tdLeistung.NextSibling;
                while (
                    tdWatts.NodeType == HtmlNodeType.Text
                    || string.IsNullOrEmpty(tdWatts.InnerText.Trim())
                )
                    tdWatts = tdWatts.NextSibling;

                var keyString = tdString.InnerText.Trim();
                var valueString = tdWatts.InnerText.Trim();
                if (!string.IsNullOrEmpty(keyString) && !string.IsNullOrEmpty(valueString))
                {
                    results.Value.Add(
                        new CollectResultRow { Key = keyString, IntValue = int.Parse(valueString) }
                    );
                }
            }

            Console.WriteLine(
                $"{DateTime.UtcNow.ToString("yyyy.MM.dd HH:MM:ss")}{TABSYMBOL}{PROGRAM_NAME}{TABSYMBOL}ParsePowerGeneration{TABSYMBOL}End"
            );
            return results;
        }
    }
}

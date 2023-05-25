using System;
using System.Threading.Tasks;
using ATG.Collector.Source.Solar;
using ATG.Collector.Types;

namespace ATG.Collector.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("start..");

            var collector = new KostalSource(
                new CollectParameter()
                {
                    Endpoint = "http://192.168.178.150",
                    Username = "pvserver",
                    Password = "pvwr"
                }
            );
            var results = await collector.CollectAsync();

            Console.WriteLine(results?.ToJsonString());
            Console.WriteLine("end..");
        }
    }
}

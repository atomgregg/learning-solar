using System;
using System.Threading.Tasks;
using ATG.Collector.Source.Solar;
using ATG.Collector.Target.Database;
using ATG.Collector.Types;
using ATG.Collector.Types.Interfaces;
using CommandLine;

namespace ATG.Collector.Host
{
    class Program
    {
        public enum CollectModeEnum
        {
            Normal,
            GenData
        }

        public enum StoreModeEnum
        {
            Postgresql
        }

        public class Options
        {
            [Option(
                "collect-mode",
                Required = false,
                Default = CollectModeEnum.Normal,
                HelpText = "Set a mode to indicate how to collect the data (from an inverter or data generation)."
            )]
            public CollectModeEnum CollectMode { get; set; }

            [Option(
                "store-mode",
                Required = false,
                Default = StoreModeEnum.Postgresql,
                HelpText = "Set a mode to indicate where to store the data."
            )]
            public StoreModeEnum StoreMode { get; set; }

            [Option(
                "inverter-endpoint",
                Required = false,
                HelpText = "Sets the endpoint where the inverter web server can be reached."
            )]
            public string InverterEndpoint { get; set; } = string.Empty;

            [Option(
                "inverter-username",
                Required = false,
                HelpText = "Sets the username to use to authenticate (basic auth) with the inverter web server."
            )]
            public string InverterUsername { get; set; } = string.Empty;

            [Option(
                "inverter-password",
                Required = false,
                HelpText = "Sets the password to use to authenticate (basic auth) with the inverter web server."
            )]
            public string InverterPassword { get; set; } = string.Empty;

            [Option(
                "store-connection",
                Required = false,
                HelpText = "Sets the connection string where for the target store."
            )]
            public string StoreConnectionString { get; set; } = string.Empty;
        }

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    DoWork(o).Wait();
                });
        }

        static async Task DoWork(Options o)
        {
            try
            {
                // validate the arguments provided
                if (!IsValid(o))
                    return;

                // create a collector for the given arguments
                ISolarSource collector = ResolveCollector(o);

                // do the collection and print to console
                var collectResult = await collector.CollectAsync();
                Console.WriteLine("===== Inverter Data =====");
                Console.WriteLine(collectResult?.ToJsonString());
                Console.WriteLine();
                Console.WriteLine();

                // write to the postgresql store
                IGeneralStore store = ResolveStore(o);
                store.OpenConnection();
                var storeResult = store.Store(collectResult);
                store.CloseConnection();
                Console.WriteLine("===== Store Results =====");
                Console.WriteLine(storeResult?.ToJsonString());
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("---------- ERROR ----------");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("---------- ERROR ----------");
                throw;
            }
        }

        static ISolarSource ResolveCollector(Options o)
        {
            // Normal: we get the real data using the provided arguments
            // GenData: we generate some data points to emulate a solar inverter and test other facets of the program
            return o.CollectMode == CollectModeEnum.Normal
                ? new KostalSource(
                    new CollectParameter
                    {
                        Endpoint = o.InverterEndpoint,
                        Username = o.InverterUsername,
                        Password = o.InverterPassword
                    }
                )
                : new SolarGenerator();
        }

        static IGeneralStore ResolveStore(Options o)
        {
            return new PostgreSQLTarget(o.StoreConnectionString);
        }

        static bool IsValid(Options o)
        {
            // always valid if generating data
            if (o.CollectMode == CollectModeEnum.GenData)
                return true;

            // check the endpoint, username and password have been provided
            if (
                string.IsNullOrEmpty(o.InverterEndpoint)
                || string.IsNullOrEmpty(o.InverterUsername)
                || string.IsNullOrEmpty(o.InverterPassword)
            )
            {
                Console.WriteLine(
                    "Missing one or more required arguments: endpoint, username, password."
                );
                return false;
            }

            // if here, then all rules passed
            return true;
        }
    }
}

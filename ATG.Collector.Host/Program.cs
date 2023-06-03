using System;
using ATG.Collector.Source.Solar;
using ATG.Collector.Types;
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

        public class Options
        {
            [Option(
                "collect-mode",
                Required = false,
                Default = CollectModeEnum.Normal,
                HelpText = "Set a mode to indicate a test execution of the application."
            )]
            public CollectModeEnum CollectMode { get; set; }

            [Option(
                "endpoint",
                Required = false,
                HelpText = "Sets the endpoint where the inverter web server can be reached."
            )]
            public string Endpoint { get; set; } = string.Empty;

            [Option(
                "username",
                Required = false,
                HelpText = "Sets the username to use to authenticate (basic auth) with the inverter web server."
            )]
            public string Username { get; set; } = string.Empty;

            [Option(
                "password",
                Required = false,
                HelpText = "Sets the password to use to authenticate (basic auth) with the inverter web server."
            )]
            public string Password { get; set; } = string.Empty;
        }

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(async o =>
                {
                    // validate the arguments provided
                    if (!IsValid(o))
                        return;

                    // create a collector for the given arguments
                    ISolarSource collector = ResolveCollector(o);

                    // do the collection and print to console
                    var results = await collector.CollectAsync();
                    Console.WriteLine(results?.ToJsonString());
                });
        }

        static ISolarSource ResolveCollector(Options o)
        {
            // Normal: we get the real data using the provided arguments
            // GenData: we generate some data points to emulate a solar inverter and test other facets of the program
            return o.CollectMode == CollectModeEnum.Normal
                ? new KostalSource(
                    new CollectParameter
                    {
                        Endpoint = o.Endpoint,
                        Username = o.Username,
                        Password = o.Password
                    }
                )
                : new SolarGenerator();
        }

        static bool IsValid(Options o)
        {
            // always valid if generating data
            if (o.CollectMode == CollectModeEnum.GenData)
                return true;

            // check the endpoint, username and password have been provided
            if (
                string.IsNullOrEmpty(o.Endpoint)
                || string.IsNullOrEmpty(o.Username)
                || string.IsNullOrEmpty(o.Password)
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

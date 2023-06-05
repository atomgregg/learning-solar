using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATG.Collector.Types.Collect;
using ATG.Collector.Types.Interfaces;

namespace ATG.Collector.Source.Solar
{
    public class SolarGenerator : ISolarSource
    {
        public Task<CollectResult> CollectAsync()
        {
            // create the result
            var result = new CollectResult();
            result.InvokeTstamp = DateTime.UtcNow;
            result.Reference = Guid.NewGuid().ToString();

            // generate some measurements for groups of solar panels (strings)
            var random = new Random();
            var randomVal = random.Next(450);
            result.Value = new List<CollectResultRow>
            {
                new CollectResultRow { Key = "String 1", IntValue = randomVal },
                new CollectResultRow { Key = "String 2", IntValue = randomVal + random.Next(20) },
                new CollectResultRow { Key = "String 3", IntValue = randomVal + random.Next(20) }
            };

            // set the execution ms
            result.ExecutionMillseconds = (long)
                DateTime.UtcNow.Subtract(result.InvokeTstamp).TotalMilliseconds;

            // done
            return Task.FromResult(result);
        }
    }
}

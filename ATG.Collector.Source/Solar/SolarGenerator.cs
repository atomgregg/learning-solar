using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATG.Collector.Types;

namespace ATG.Collector.Source.Solar
{
    public class SolarGenerator : ISolarSource
    {
        public Task<CollectResult> CollectAsync()
        {
            var result = new CollectResult();
            var random = new Random();
            var randomVal = random.Next(450);

            result.InvokeTstamp = DateTime.UtcNow;
            result.Reference = new Guid().ToString();
            result.Value = new List<CollectResultRow>
            {
                new CollectResultRow { Key = "String 1", IntValue = randomVal },
                new CollectResultRow { Key = "String 2", IntValue = randomVal + random.Next(20) },
                new CollectResultRow { Key = "String 3", IntValue = randomVal + random.Next(20) }
            };

            return Task.FromResult(result);
        }
    }
}

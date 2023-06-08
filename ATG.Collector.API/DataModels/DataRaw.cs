using System;

namespace ATG.Collector.API.DataModels
{
    public class DataRaw
    {
        public string Key { get; set; }
        public DateTime Tstamp { get; set; }
        public string RowKey { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
        public long? LongValue { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? TstampValue { get; set; }
    }
}

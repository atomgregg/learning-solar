using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ATG.Collector.Types.Collect
{
    public class CollectResult
    {
        public string Reference { get; set; } = string.Empty;
        public DateTime InvokeTstamp { get; set; }
        public long ExecutionMillseconds { get; set; }
        public List<CollectResultRow> Value { get; set; } = new List<CollectResultRow>();
        public List<CollectError> Errors { get; set; } = new List<CollectError>();

        public static CollectResult NewWithSingleError(string error, string srcError)
        {
            return new CollectResult
            {
                Errors = new List<CollectError>
                {
                    new CollectError { ErrorMessage = error, SourceErrorMessage = srcError }
                }
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Reference: {Reference}");
            sb.AppendLine($"InvokeTstamp: {InvokeTstamp}");
            sb.AppendLine($"ExecutionMillseconds: {ExecutionMillseconds}");
            sb.AppendLine("Value:");
            foreach (var row in Value)
            {
                sb.AppendLine(row.ToString());
            }
            sb.AppendLine("Errors:");
            foreach (var error in Errors)
            {
                sb.AppendLine(error.ToString());
            }
            return sb.ToString();
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CollectResultRow
    {
        public string Key { get; set; } = string.Empty;
        public DateTime? Tstamp { get; set; }
        public string StringValue { get; set; } = string.Empty;
        public int? IntValue { get; set; }
        public long? LongValue { get; set; }
        public bool? BoolValue { get; set; }
        public DateTime? TstampValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Key: {Key}");
            sb.AppendLine($"Tstamp: {Tstamp}");
            sb.AppendLine($"StringValue: {StringValue}");
            sb.AppendLine($"IntValue: {IntValue ?? null}");
            sb.AppendLine($"LongValue: {LongValue ?? null}");
            sb.AppendLine($"BoolValue: {BoolValue ?? null}");
            sb.AppendLine($"TstampValue: {TstampValue ?? null}");
            return sb.ToString();
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CollectError
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string SourceErrorMessage { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ErrorMessage: {ErrorMessage}");
            sb.AppendLine($"SourceErrorMessage: {SourceErrorMessage}");
            return sb.ToString();
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

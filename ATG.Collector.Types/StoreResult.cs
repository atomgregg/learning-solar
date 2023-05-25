using System;
using System.Collections.Generic;
using System.Text;

namespace ATG.Collector.Types
{
    public class StoreResult
    {
        public string Reference { get; set; } = string.Empty;
        public DateTime InvokeTstamp { get; set; }
        public long ExecutionMillseconds { get; set; }
        public bool StoreSuccessful { get; set; }
        public List<StoreError> Errors { get; set; } = new List<StoreError>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Reference: {Reference}");
            sb.AppendLine($"InvokeTstamp: {InvokeTstamp}");
            sb.AppendLine($"ExecutionMillseconds: {ExecutionMillseconds}");
            sb.AppendLine($"StoreSuccessful: {StoreSuccessful}");
            sb.AppendLine("Errors:");
            foreach (var error in Errors)
            {
                sb.AppendLine(error.ToString());
            }
            return sb.ToString();
        }
    }

    public class StoreError
    {
        public string ReferenceRow { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string SourceErrorMessage { get; set; } = string.Empty;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ReferenceRow: {ReferenceRow}");
            sb.AppendLine($"ErrorMessage: {ErrorMessage}");
            sb.AppendLine($"SourceErrorMessage: {SourceErrorMessage}");
            return sb.ToString();
        }
    }
}

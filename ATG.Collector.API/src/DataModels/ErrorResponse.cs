namespace ATG.Collector.API.DataModels
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStack { get; set; }

        public static ErrorResponse FromException(string msg, Exception ex)
        {
            return new ErrorResponse
            {
                ErrorMessage = msg,
                ExceptionMessage = ex.Message,
                ExceptionStack = ex.StackTrace ?? ""
            };
        }
    }
}

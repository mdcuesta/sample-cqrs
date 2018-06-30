namespace Sampler.CQRS.Core
{
    public class CommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public CommandResult()
        {    
        }

        public CommandResult(bool success, object data = null, string message = null)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    } 
}

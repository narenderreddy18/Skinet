
namespace API.Errors
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }       

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You made a bad Request",
                401 => "You are not Authorized",
                404 => "Your Resource is Not Found",
                500 => "your serve not found",
                _ => null
            };
        }
    }
}

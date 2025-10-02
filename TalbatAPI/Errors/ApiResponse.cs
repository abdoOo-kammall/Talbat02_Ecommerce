
namespace TalbatAPI.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statuscode , string? message = null)
        {
            StatusCode = statuscode;
            Message = message ?? getDefaultErrorMessage(statuscode);
        }

        private string? getDefaultErrorMessage(int statuscode)
        {
            return statuscode switch
            {
                400 => "A bad Request , U have made",
                401 => "Authorized , U are not",
                404 => "Resource Not Found",
                500 => "Errors are the path to the darkSide",
                _ => null

            };
            
        }
    }
   
}

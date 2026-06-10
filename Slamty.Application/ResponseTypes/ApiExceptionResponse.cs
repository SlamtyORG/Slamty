using System.Net;

namespace Slamty.Application.ResponseTypes
{
    public class ApiExceptionResponse : ApiResponse<string>
    {
        public string? Details { get; set; }

        public ApiExceptionResponse(HttpStatusCode statusCode, string? message = null, string? details = null) : base(statusCode, null, message)
        {
            Details = details;
        }
    }
}

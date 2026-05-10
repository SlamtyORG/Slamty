using System.Net;

namespace Slamty.Core.ResponseTypes
{
    public class ApiResponse<T>
    {
        public ApiResponse(HttpStatusCode statusCode, T data, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = data;
        }

        private string? GetDefaultMessageForStatusCode(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.BadRequest => "Bad Request",
                HttpStatusCode.Unauthorized => "Not Authorize",
                HttpStatusCode.NotFound => "Not Found",
                HttpStatusCode.InternalServerError => "Internal Server Error",
                HttpStatusCode.OK => "Success",
                _ => null
            };
        }

        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode, string? message = null, object? data = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Data = data;
        }

        private string? GetDefaultMessageForStatusCode(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.BadRequest => "Bad Request",
                HttpStatusCode.Unauthorized => "Not Authorize",
                HttpStatusCode.NotFound => "Not Found",
                HttpStatusCode.InternalServerError => "Internal Server Error",
                HttpStatusCode.OK => "Success",
                _ => null
            };
        }

        public object? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}

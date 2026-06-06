using System.Net;

namespace Slamty.Application.ResponseTypes
{
    public class ApiValidationExceptionResponse : ApiResponse<IEnumerable<ValidationError>>
    {
        public ApiValidationExceptionResponse(HttpStatusCode statusCode, IEnumerable<ValidationError>? errors, string? message = null) : base(statusCode, errors, message)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError>? Errors { get; set; }
    }
}

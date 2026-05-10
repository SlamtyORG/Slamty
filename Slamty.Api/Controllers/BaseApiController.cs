using MediatR;
using Microsoft.AspNetCore.Mvc;
using Slamty.Core.ResponseTypes;
using System.Net;

namespace Slamty.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected IActionResult HandleResult<T>(ApiResponse<T> result)
        {
            return result.StatusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.Created => StatusCode((int)HttpStatusCode.Created, result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.Unauthorized => Unauthorized(result),
                HttpStatusCode.Forbidden => StatusCode((int)HttpStatusCode.Forbidden, result),
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.PreconditionRequired => StatusCode((int)HttpStatusCode.PreconditionRequired, result),
                HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, result),
                _ => StatusCode((int)result.StatusCode, result)
            };
        }
    }
}

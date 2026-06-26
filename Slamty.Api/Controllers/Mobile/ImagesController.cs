using Microsoft.AspNetCore.Mvc;
using Slamty.Api.Requests;
using Slamty.Application.Features.Images.Commands.UploadImage;

namespace Slamty.Api.Controllers.Mobile
{
    public class ImagesController : BaseMobileApiController
    {
        [HttpPost("upload/image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest request)
        {
            if (request.File == null)
            {
                return BadRequest("No file uploaded.");
            }

            await using var stream = request.File.OpenReadStream();

            var command = new UploadImageCommand(
                stream,
                request.File.FileName,
                request.File.ContentType,
                request.File.Length);

            var response = await Mediator.Send(command);

            return HandleResult(response);
        }
    }
}

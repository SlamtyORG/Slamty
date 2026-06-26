using Microsoft.AspNetCore.Http;

namespace Slamty.Api.Requests
{
    public sealed class UploadImageRequest
    {
        public IFormFile File { get; set; } = default!;
    }
}

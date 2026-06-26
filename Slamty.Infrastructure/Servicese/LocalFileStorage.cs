using Microsoft.AspNetCore.Hosting;
using Slamty.Application.Features.Common.Models;
using Slamty.Application.Interfaces.Servicese;

namespace Slamty.Infrastructure.Servicese
{
    public sealed class LocalFileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment _environment;

        public LocalFileStorage(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<FileUploadResult> UploadAsync(
            Stream content,
            string fileName,
            string contentType,
            CancellationToken cancellationToken)
        {
            var uploadsPath = Path.Combine(_environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");

            Directory.CreateDirectory(uploadsPath);

            var path = Path.Combine(uploadsPath, fileName);

            await using var fileStream = new FileStream(path, FileMode.Create);

            await content.CopyToAsync(fileStream, cancellationToken);

            var url = $"/uploads/{fileName}";

            return new FileUploadResult(fileName, url);
        }
    }
}

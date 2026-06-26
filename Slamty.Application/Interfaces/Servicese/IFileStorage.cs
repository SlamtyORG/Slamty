using Slamty.Application.Features.Common.Models;

namespace Slamty.Application.Interfaces.Servicese
{
    public interface IFileStorage
    {
        Task<FileUploadResult> UploadAsync(
            Stream content,
            string fileName,
            string contentType,
            CancellationToken cancellationToken);
    }
}

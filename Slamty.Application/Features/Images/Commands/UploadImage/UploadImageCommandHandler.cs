using MediatR;
using Microsoft.Extensions.Logging;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using System.Net;

namespace Slamty.Application.Features.Images.Commands.UploadImage
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, ApiResponse<UploadImageResponse>>
    {
        private readonly IFileStorage _fileStorage;
        private readonly ILogger<UploadImageCommandHandler> _logger;

        public UploadImageCommandHandler(IFileStorage fileStorage, ILogger<UploadImageCommandHandler> logger)
        {
            _fileStorage = fileStorage;
            _logger = logger;
        }

        public async Task<ApiResponse<UploadImageResponse>> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var extension = Path.GetExtension(request.FileName);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";

            _logger.LogInformation("Uploading image: {FileName}", uniqueFileName);

            var result = await _fileStorage.UploadAsync(
                request.Content,
                uniqueFileName,
                request.ContentType,
                cancellationToken);

            _logger.LogInformation("Image uploaded successfully: {Url}", result.Url);

            return new ApiResponse<UploadImageResponse>(
                HttpStatusCode.Created,
                new UploadImageResponse(result.FileName, result.Url),
                "Image uploaded successfully."
            );
        }
    }
}

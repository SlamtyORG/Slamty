using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Images.Commands.UploadImage
{
    public sealed record UploadImageCommand(
        Stream Content,
        string FileName,
        string ContentType,
        long Length) : IRequest<ApiResponse<UploadImageResponse>>;
}

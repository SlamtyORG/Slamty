using MediatR;
using Microsoft.AspNetCore.Http;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.UpdateProfileImage
{
    public class UpdateProfileImageCommand : IRequest<ApiResponse<string>>
    {
        public string ProfileId { get; set; }
        public IFormFile Image { get; set; }
    }
}

using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public record DeleteProfileCommand(string UserEmail) : IRequest<ApiResponse<bool>>;

}

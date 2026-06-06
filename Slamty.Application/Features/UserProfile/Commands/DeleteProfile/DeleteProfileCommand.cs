using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public record DeleteProfileCommand(string Email, string Password) : IRequest<ApiResponse<bool>>;

}

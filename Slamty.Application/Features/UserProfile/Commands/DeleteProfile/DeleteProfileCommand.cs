using MediatR;
using Slamty.Application.Features.UserProfile.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public record DeleteProfileCommand(DeleteProfileDto DeleteProfileDto) : IRequest<ApiResponse<bool>>;

}

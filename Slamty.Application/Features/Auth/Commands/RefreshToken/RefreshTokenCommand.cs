using MediatR;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public string RefreshToken { get; set; }
    }
}

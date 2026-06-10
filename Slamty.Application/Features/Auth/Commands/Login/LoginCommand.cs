using MediatR;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.Login
{
    public record LoginCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public string NationalId { get; set; }
        public string Password { get; set; }
    }
}

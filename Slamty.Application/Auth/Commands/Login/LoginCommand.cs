using MediatR;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Command.Login
{
    public record LoginCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public int NationalId { get; set; }
        public string Password { get; set; }
    }
}

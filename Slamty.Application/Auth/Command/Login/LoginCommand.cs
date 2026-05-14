using MediatR;
using Slamty.Application.Auth.DTOs;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Command.Login
{
    public class LoginCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public int NationalId { get; set; }
        public string Password { get; set; }
    }
}

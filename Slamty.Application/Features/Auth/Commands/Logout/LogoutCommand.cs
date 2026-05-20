using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommand : IRequest<ApiResponse<string>>
    {
        public string Id { get; set; }
    }
}

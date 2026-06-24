using MediatR;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommand : IRequest<ApiResponse<string>>
    {
        public Guid Id { get; set; }
    }
}

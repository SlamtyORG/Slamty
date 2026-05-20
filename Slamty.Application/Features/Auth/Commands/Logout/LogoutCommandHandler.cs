using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using System.Net;

namespace Slamty.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, ApiResponse<string>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<LogoutCommandHandler> _logger;

        public LogoutCommandHandler(UserManager<AppUser> userManager, ILogger<LogoutCommandHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ApiResponse<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            if (user == null)
            {
                _logger.LogWarning("Logout failed: User with ID {UserId} not found.", request.Id);
                return new ApiResponse<string>(HttpStatusCode.NotFound, null, "User not found.");
            }

            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                _logger.LogInformation("Revoking active refresh tokens for user ID {UserId}.", request.Id);
                var activeTokens = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                activeTokens.RevokedOn = DateTime.UtcNow;
            }

            await _userManager.UpdateAsync(user);
            return new ApiResponse<string>(HttpStatusCode.OK, "Logout successful.", "Logout successful.");
        }
    }
}

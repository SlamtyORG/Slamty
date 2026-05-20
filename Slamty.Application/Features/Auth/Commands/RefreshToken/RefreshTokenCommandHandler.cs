using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using System.Net;

namespace Slamty.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RefreshTokenCommandHandler> _logger;

        public RefreshTokenCommandHandler(ITokenService tokenService,
                                          UserManager<AppUser> userManager,
                                          IUnitOfWork unitOfWork,
                                          ILogger<RefreshTokenCommandHandler> logger)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var authResponse = new AuthResponseDto();

            var user = _userManager.Users.FirstOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.RefreshToken));

            if (user is null)
            {
                _logger.LogWarning("Refresh token not found: {RefreshToken}", request.RefreshToken);
                return new ApiResponse<AuthResponseDto>
                (HttpStatusCode.Unauthorized, null, "Invalid token.");
            }

            var refreshToken = user.RefreshTokens.FirstOrDefault(t => t.Token == request.RefreshToken);

            if (refreshToken is null || !refreshToken.IsActive)
            {
                _logger.LogWarning("Refresh token is inactive : {RefreshToken}", request.RefreshToken);
                return new ApiResponse<AuthResponseDto>
                (HttpStatusCode.Unauthorized, null, "InActive token.");
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var NewRefreshToken = await _tokenService.GenerateRefreshToken();

            var userProfile = await _unitOfWork.Repository<MobileUser>().FindByCriatria(u => u.UserId == user.Id);

            authResponse.AccessToken = await _tokenService.CreateTokenAsync(user);
            authResponse.RefreshToken = NewRefreshToken.Token;
            authResponse.RefreshTokenExpiration = NewRefreshToken.ExpiresOn;
            authResponse.UserId = user.Id;
            authResponse.FullName = user.FullName;
            authResponse.ProfileId = userProfile.Id.ToString();

            return new ApiResponse<AuthResponseDto>
            (HttpStatusCode.OK, authResponse, "Token refreshed successfully.");

        }
    }
}

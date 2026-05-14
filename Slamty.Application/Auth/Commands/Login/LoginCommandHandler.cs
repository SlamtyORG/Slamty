using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Auth.DTOs;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(ITokenService tokenService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _unitOfWork.Repository<MobileUser>().FindByCriatria(u => u.NationalId == request.NationalId);
            if (userProfile == null)
            {
                _logger.LogWarning("Login attempt failed for National ID: {NationalId}. User not found.", request.NationalId);
                return new ApiResponse<AuthResponseDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.Unauthorized,
                    message: "Invalid National ID or Password"
                );
            }
            var user = await _userManager.FindByIdAsync(userProfile.UserId);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                _logger.LogWarning("Login attempt failed for National ID: {NationalId}. Invalid password.", request.NationalId);
                return new ApiResponse<AuthResponseDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.Unauthorized,
                    message: "Invalid National ID or Password"
                );
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var accessToken = await _tokenService.CreateTokenAsync(user, userRoles.ToList());
            var refreshToken = await _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            var authResponse = new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = user.Id,
                ProfileId = userProfile.Id.ToString(),
                FullName = user.FullName
            };

            return new ApiResponse<AuthResponseDto>
            (
                data: authResponse,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Login successful"
            );

        }
    }
}

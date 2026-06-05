using MediatR;
using Microsoft.AspNetCore.Identity;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using System.Net;

namespace Slamty.Application.Features.UserProfile.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public ChangePasswordCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
        _unitOfWork = unitOfWork;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, request.CurrentPassword);
            if (!isCurrentPasswordValid)
                return new ApiResponse<AuthResponseDto>(HttpStatusCode.BadRequest, null, "Current password is incorrect.");

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                var errors = string.Join("; ", changePasswordResult.Errors.Select(e => e.Description));
                return new ApiResponse<AuthResponseDto>(HttpStatusCode.BadRequest, null, $"Failed to change password: {errors}");
            }

            var refreshTokenResult = await _tokenService.GenerateRefreshToken();

            var authResponse = new AuthResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                AccessToken = await _tokenService.CreateTokenAsync(user),
                RefreshToken = refreshTokenResult.Token,
                RefreshTokenExpiration = refreshTokenResult.ExpiresOn
            };

            return new ApiResponse<AuthResponseDto>(HttpStatusCode.OK, authResponse, "Password changed successfully.");
        }
    }

}

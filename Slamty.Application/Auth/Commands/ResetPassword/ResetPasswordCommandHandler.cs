using MediatR;
using Microsoft.AspNetCore.Identity;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;
        public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.ResetPasswordDto.UserEmail);
            if (user == null)
                return new ApiResponse<bool>(data: false, statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User not found.");

            var tokenVeryfication = await _userManager.ResetPasswordAsync(user, request.ResetPasswordDto.ValidationToken, request.ResetPasswordDto.NewPassword);

            if (!tokenVeryfication.Succeeded)
                return new ApiResponse<bool>(data: false, statusCode: System.Net.HttpStatusCode.Unauthorized,
                    message: "Your token is not valid.");
            return new ApiResponse<bool>(data: true, statusCode: System.Net.HttpStatusCode.OK,
                message: "Password has changed.");

        }
    }


}

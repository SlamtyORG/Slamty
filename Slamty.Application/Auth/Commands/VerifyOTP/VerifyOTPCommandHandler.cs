using MediatR;
using Microsoft.AspNetCore.Identity;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Commands.VerifyOTP
{
    public class VerifyOTPCommandHandler : IRequestHandler<VerifyOTPCommand, ApiResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;
        public VerifyOTPCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.OTPVerificationDto.EmailAddress);

            if (user == null)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.NotFound, false, "User not found.");

            var otpChecker = await _userManager.ConfirmEmailAsync(user, request.OTPVerificationDto.OTP);

            if (!otpChecker.Succeeded)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.Unauthorized, false, "OTP is wrong.");

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return new ApiResponse<bool>(System.Net.HttpStatusCode.OK, true, "Email is confirmed");
        }
    }


}

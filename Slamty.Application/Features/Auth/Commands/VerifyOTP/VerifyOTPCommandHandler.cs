using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using System.Net;

namespace Slamty.Application.Features.Auth.Commands.VerifyOTP
{
    public class VerifyOTPCommandHandler : IRequestHandler<VerifyOTPCommand, ApiResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMemoryCache _cache;
        public VerifyOTPCommandHandler(UserManager<AppUser> userManager, IMemoryCache cache)
        {
            _userManager = userManager;
            _cache = cache;
        }

        public async Task<ApiResponse<bool>> Handle(VerifyOTPCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.EmailAddress);


            if (user == null)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.NotFound, false, "User not found.");

            if (user.EmailConfirmed)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.BadRequest, false, "User already confirmed.");

            if (!_cache.TryGetValue(
                $"email-otp:{user.Id}",
                out string? storedOtp))
            {
                return new ApiResponse<bool>(
                    HttpStatusCode.Unauthorized,
                    false,
                    "OTP expired.");
            }
            bool otpChecker = storedOtp == request.OTP;

            if (!otpChecker)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.Unauthorized, false, "OTP is wrong.");

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return new ApiResponse<bool>(System.Net.HttpStatusCode.OK, true, "Email is confirmed");
        }
    }


}

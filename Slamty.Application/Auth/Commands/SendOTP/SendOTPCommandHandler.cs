using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Commands.SendOTP
{
    public class SendOTPCommandHandler : IRequestHandler<SendOTPCommand, ApiResponse<bool>>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        public SendOTPCommandHandler(IEmailSenderService emailSenderService, UserManager<AppUser> userManager, IConfiguration config)
        {
            _emailSenderService = emailSenderService;
            _userManager = userManager;
            _config = config;
        }

        public async Task<ApiResponse<bool>> Handle(SendOTPCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.EmailAddress);

            if (user == null)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.NotFound, false, "User not found.");

            var otp = await _userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultEmailProvider);

            return await _emailSenderService.SendEmailService(
                _config["SmtpSettings:AdminEmail"]!,
                request.EmailAddress,
                new EmailSenderDto
                {
                    Subject = "Email Confirmation Code",
                    Body = $"Your confirmation code is: {otp}"
                });

        }
    }

}

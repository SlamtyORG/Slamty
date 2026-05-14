using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, ApiResponse<bool>>
    {
        private readonly IEmailSenderService _emailSender;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public ForgetPasswordCommandHandler(IEmailSenderService emailSender, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApiResponse<bool>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
                return new ApiResponse<bool>(data: false, statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User not found.");
            var generatedToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await _emailSender.SendEmailService(
                _configuration["SmtpSettings:AdminEmail"]!,
                user!.Email!,
                new EmailSenderDto
                {
                    Subject = "Reset Password Code",
                    Body = $"Your confirmation code is: {generatedToken}"
                },
                "Plain"
                );


        }
    }

}

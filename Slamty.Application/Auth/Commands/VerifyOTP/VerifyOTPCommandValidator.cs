using FluentValidation;

namespace Slamty.Application.Auth.Commands.VerifyOTP
{
    public class VerifyOTPCommandValidator : AbstractValidator<VerifyOTPCommand>
    {
        public VerifyOTPCommandValidator()
        {
            RuleFor(c => c.OTPVerificationDto.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required.");

            RuleFor(c => c.OTPVerificationDto.OTP)
                .NotEmpty()
                .WithMessage("OTP is required.");
        }
    }


}

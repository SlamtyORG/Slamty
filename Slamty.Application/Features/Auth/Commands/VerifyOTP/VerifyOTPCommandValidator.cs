using FluentValidation;

namespace Slamty.Application.Features.Auth.Commands.VerifyOTP
{
    public class VerifyOTPCommandValidator : AbstractValidator<VerifyOTPCommand>
    {
        public VerifyOTPCommandValidator()
        {
            RuleFor(c => c.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address format.");

            RuleFor(c => c.OTP)
                .NotEmpty()
                .WithMessage("OTP is required.")
                .MinimumLength(6)
                .WithMessage("OTP must contain 6 numbers only.")
                .MaximumLength(6)
                .WithMessage("OTP must contain 6 numbers only.");
        }
    }


}

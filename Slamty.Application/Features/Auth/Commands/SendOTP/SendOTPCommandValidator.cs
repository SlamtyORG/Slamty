using FluentValidation;

namespace Slamty.Application.Features.Auth.Commands.SendOTP
{
    public class SendOTPCommandValidator : AbstractValidator<SendOTPCommand>
    {
        public SendOTPCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required.")
                .EmailAddress()
                .WithMessage("Invalid email address format.");
        }
    }

}

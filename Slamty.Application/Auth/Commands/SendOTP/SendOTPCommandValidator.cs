using FluentValidation;

namespace Slamty.Application.Auth.Commands.SendOTP
{
    public class SendOTPCommandValidator : AbstractValidator<SendOTPCommand>
    {
        public SendOTPCommandValidator()
        {
            RuleFor(v => v.EmailAddress)
                .NotEmpty()
                .WithMessage("Email Address is required.");
        }
    }

}

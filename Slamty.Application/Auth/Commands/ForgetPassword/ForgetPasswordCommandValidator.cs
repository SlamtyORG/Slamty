using FluentValidation;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(f => f.email)
                .NotEmpty()
                .WithMessage("Email address is required.");
        }
    }
   
}

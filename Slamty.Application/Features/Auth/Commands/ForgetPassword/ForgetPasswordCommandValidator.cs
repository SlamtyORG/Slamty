using FluentValidation;

namespace Slamty.Application.Features.Auth.Commands.ForgetPassword
{
    public class ForgetPasswordCommandValidator : AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetPasswordCommandValidator()
        {
            RuleFor(f => f.Email)
                .NotEmpty()
                .WithMessage("Email address is required.");
        }
    }

}

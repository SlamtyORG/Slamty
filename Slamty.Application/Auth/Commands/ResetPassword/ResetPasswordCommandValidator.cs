using FluentValidation;

namespace Slamty.Application.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(r => r.ResetPasswordDto.UserEmail)
                .NotEmpty()
                .WithMessage("Email is required")
                .MinimumLength(15)
                .WithMessage("Email must be greater than 15");
            RuleFor(r => r.ResetPasswordDto.ValidationToken)
                .NotEmpty()
                .WithMessage("ValidationToken is required");


        }
    }


}

using FluentValidation;

namespace Slamty.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(r => r.UserEmail)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email address format.")
                .MinimumLength(15)
                .WithMessage("Email must be greater than 15 characters");
            RuleFor(r => r.ValidationToken)
                .NotEmpty()
                .WithMessage("ValidationToken is required");
            RuleFor(r => r.NewPassword)
                .NotEmpty()
                .WithMessage("New password is required")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain a lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a digit.");
            RuleFor(r => r.ConfirmNewPassword)
                .Equal(r => r.NewPassword)
                .WithMessage("Confirm Password must be equal to the new password.");


        }
    }


}

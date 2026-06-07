using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .WithMessage("email can`t be empty.")
                .EmailAddress()
                .WithMessage("Invalid email address format.");

            RuleFor(d => d.Password)
                .NotEmpty()
                .WithMessage("password can`t be empty.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain a lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a digit.");

        }
    }

}

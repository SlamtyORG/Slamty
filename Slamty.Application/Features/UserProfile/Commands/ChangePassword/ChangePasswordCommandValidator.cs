using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Current Password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New Password is required.")
                .MinimumLength(6).WithMessage("New Password must be at least 6 characters long.")
                .Matches(@"(?=.*[a-z])").WithMessage("New Password must contain at least one lowercase letter.")
                .Matches(@"(?=.*[A-Z])").WithMessage("New Password must contain at least one uppercase letter.")
                .Matches(@"(?=.*\d)").WithMessage("New Password must contain at least one number.")
                .Matches(@"(?=.*[@$!%*?&])").WithMessage("New Password must contain at least one special character.");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage("Confirm New Password is required.")
                .Equal(x => x.NewPassword).WithMessage("Confirm New Password must match New Password.");
        }
    }
}

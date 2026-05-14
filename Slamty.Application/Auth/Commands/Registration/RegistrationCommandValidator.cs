using FluentValidation;

namespace Slamty.Application.Auth.Commands.Registration
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        public RegistrationCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .Matches(@"(?=.*[a-z])").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"(?=.*[A-Z])").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"(?=.*\d)").WithMessage("Password must contain at least one number.")
                .Matches(@"(?=.*[@$!%*?&])").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.NationalId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.BloodType)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}

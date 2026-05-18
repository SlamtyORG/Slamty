using FluentValidation;

namespace Slamty.Application.Features.Auth.Commands.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("User ID must be a valid GUID.");
        }

    }
}

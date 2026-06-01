using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.AddNotify
{
    public class AddNotifyValidator : AbstractValidator<AddNotifyCommand>
    {
        public AddNotifyValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.NotifyType).NotEmpty().WithMessage("NotifyType is required")
                .IsInEnum().WithMessage("NotifyType is not valid");
        }
    }
}

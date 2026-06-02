using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.RemoveNotify
{
    public class RemoveNotifyValidator : AbstractValidator<RemoveNotifyCommand>
    {
        public RemoveNotifyValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
            RuleFor(x => x.NotifyType).NotEmpty().WithMessage("NotifyType is required")
                .IsInEnum().WithMessage("NotifyType is not valid");
        }
    }
}

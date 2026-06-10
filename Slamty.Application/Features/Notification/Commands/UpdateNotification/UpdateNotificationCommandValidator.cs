using FluentValidation;

namespace Slamty.Application.Features.Notification.Commands.UpdateNotification
{
    public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
    {
        public UpdateNotificationCommandValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEmpty().WithMessage("Notification ID is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Notification ID format.");
        }
    }
}

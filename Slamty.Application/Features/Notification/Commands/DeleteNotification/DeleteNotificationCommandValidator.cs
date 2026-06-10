using FluentValidation;

namespace Slamty.Application.Features.Notification.Commands.DeleteNotification
{
    public class DeleteNotificationCommandValidator : AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEmpty().WithMessage("NotificationId is required")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("NotificationId must be a valid GUID");
        }
    }
}

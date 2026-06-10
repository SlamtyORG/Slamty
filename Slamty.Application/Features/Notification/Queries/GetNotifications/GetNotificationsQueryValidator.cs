using FluentValidation;

namespace Slamty.Application.Features.Notification.Queries.GetNotifications
{
    public class GetNotificationsQueryValidator : AbstractValidator<GetNotificationsQuery>
    {
        public GetNotificationsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                .Must(userId => Guid.TryParse(userId, out _)).WithMessage("UserId must be a valid GUID.");
        }
    }
}

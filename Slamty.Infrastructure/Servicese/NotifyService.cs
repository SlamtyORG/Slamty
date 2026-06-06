using Microsoft.Extensions.Logging;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Domain.Entities;
using Slamty.Domain.Enums;
using Slamty.Domain.Specifications;

namespace Slamty.Infrastructure.Servicese
{
    public class NotifyService : INotifyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotifyService> _logger;

        public NotifyService(IUnitOfWork unitOfWork, ILogger<NotifyService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Interested(NotifyType notifyType, string userId)
        {
            _logger.LogInformation("Add User with Id {userId} to Notify {notifyType}", [userId, notifyType]);
            await _unitOfWork.Repository<Notify>().AddAsync(new Notify
            {
                NotifyType = notifyType,
                UserId = userId
            });

            await _unitOfWork.Complete();

        }

        public async Task NotifyAllUsers(NotifyType notifyType, string message)
        {
            _logger.LogInformation("Notify all user with {message}", message);
            var NotifySpec = new NotifySpecification(notifyType);
            var NotifyList = await _unitOfWork.Repository<Notify>().GetBySpecAsync(NotifySpec);
            foreach (var Notify in NotifyList)
            {
                _logger.LogInformation("Notify User {userId} by {message}", [Notify.UserId, message]);
                await _unitOfWork.Repository<Notification>().AddAsync(new Notification
                {
                    Date = DateTime.Now,
                    Message = message,
                    UserId = Notify.UserId,
                    NotificationStatus = NotificationStatus.Pending
                });
            }
            await _unitOfWork.Complete();
        }

        public async Task NotifyUser(NotifyType notifyType, string userId, string message)
        {
            _logger.LogInformation("Notify user {userId} with {message}", [userId, message]);

            var NotifySpec = new NotifySpecification(notifyType, userId);
            var NotifyList = await _unitOfWork.Repository<Notify>().GetBySpecAsync(NotifySpec);
            foreach (var Notify in NotifyList)
            {
                _logger.LogInformation("Notify User {userId} by {message}", [Notify.UserId, message]);
                await _unitOfWork.Repository<Notification>().AddAsync(new Notification
                {
                    Message = message,
                    UserId = Notify.UserId,
                    NotificationStatus = NotificationStatus.Pending,
                    Date = DateTime.Now
                });
            }
            await _unitOfWork.Complete();
        }

        public async Task NotInterested(NotifyType notifyType, string userId)
        {
            _logger.LogInformation("Remove User with Id {userId} from Notify {notifyType}", [userId, notifyType]);
            var notify = await _unitOfWork.Repository<Notify>().FindByCriatria(n => (n.NotifyType == notifyType) && (n.UserId == userId));
            _unitOfWork.Repository<Notify>().Delete(notify);
            await _unitOfWork.Complete();
        }

        public async Task removeNotify(string notifyId)
        {
            _logger.LogInformation("Remove Notification WithId {Id}", notifyId);
            var notification = await _unitOfWork.Repository<Notification>().GetByIdAsync(Guid.Parse(notifyId));
            _unitOfWork.Repository<Notification>().Delete(notification);
            await _unitOfWork.Complete();

        }
    }
}

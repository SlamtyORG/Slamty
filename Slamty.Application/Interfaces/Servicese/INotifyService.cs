using Slamty.Domain.Enums;

namespace Slamty.Application.Interfaces.Servicese
{
    public interface INotifyService
    {
        public Task NotifyUser(NotifyType notifyType, Guid userId, string message);
        public Task NotifyAllUsers(NotifyType notifyType, string message);
        public Task removeNotify(Guid notifyId);
        public Task Interested(NotifyType notifyType, Guid userId);
        public Task NotInterested(NotifyType notifyType, Guid userId);
    }
}

using Slamty.Domain.Enums;

namespace Slamty.Application.Interfaces.Servicese
{
    public interface INotifyService
    {
        public Task NotifyUser(NotifyType notifyType, string userId, string message);
        public Task NotifyAllUsers(NotifyType notifyType, string message);
        public Task removeNotify(string notifyId);
        public Task Interested(NotifyType notifyType, string userId);
        public Task NotInterested(NotifyType notifyType, string userId);
    }
}

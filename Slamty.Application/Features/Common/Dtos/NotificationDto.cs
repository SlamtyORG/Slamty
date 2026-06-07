using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Common.Dtos
{
    public class NotificationDto
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public NotificationStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}

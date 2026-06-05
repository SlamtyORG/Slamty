using Microsoft.AspNetCore.Identity;
using Slamty.Domain.Contracts;

namespace Slamty.Domain.Entities
{
    public class AppUser : IdentityUser, ISoftDeletable
    {
        public string FullName { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}

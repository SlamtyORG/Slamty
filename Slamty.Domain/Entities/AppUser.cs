using Microsoft.AspNetCore.Identity;

namespace Slamty.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}

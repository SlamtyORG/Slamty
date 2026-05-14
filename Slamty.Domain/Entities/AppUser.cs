using Microsoft.AspNetCore.Identity;

namespace Slamty.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; } = null!;
        public DateTime? RefreshTokenExpiresAt { get; set; }
    }
}

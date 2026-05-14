using Slamty.Domain.Entities;

namespace Slamty.Domain.Interfaces.Servicese
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(AppUser user, List<string> roles);
        public Task<string> GenerateRefreshToken();

    }
}

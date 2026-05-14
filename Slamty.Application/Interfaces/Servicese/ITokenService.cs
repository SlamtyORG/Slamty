using Slamty.Domain.Entities;

namespace Slamty.Application.Interfaces.Servicese
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(AppUser user, List<string> roles);

    }
}

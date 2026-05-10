using Microsoft.AspNetCore.Identity;

namespace Slamty.Core.Interfaces.Application
{
    public interface ITokenService<TUser> where TUser : IdentityUser
    {
        public Task<string> CreateTokenAsync(TUser user, List<string> roles);

    }
}

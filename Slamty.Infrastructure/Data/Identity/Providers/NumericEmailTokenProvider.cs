using Microsoft.AspNetCore.Identity;

namespace Slamty.Infrastracture.Data.Identity.Providers
{
    public class NumericEmailTokenProvider<TUser> : EmailTokenProvider<TUser> where TUser : class
    {
        public override Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            var otpCode = new Random().Next(100000, 999999).ToString();
            return Task.FromResult(otpCode);
        }
    }
}
namespace Slamty.Application.Auth.Dtos
{
    public sealed record OTPVerificationDto(string EmailAddress, string OTP);

}

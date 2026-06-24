namespace Slamty.Application.Features.Auth.Dtos
{
    public sealed record AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        public string FullName { get; set; }
    }
}

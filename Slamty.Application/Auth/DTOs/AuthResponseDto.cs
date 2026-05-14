namespace Slamty.Application.Auth.Dtos
{
    public sealed record AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
        public string ProfileId { get; set; }
        public string FullName { get; set; }
    }
}

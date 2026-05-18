namespace Slamty.Application.Auth.Dtos
{
    public sealed record ProfileResponseDto
    {
        public string ProfileId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int NationalId { get; set; }
        public string BloodType { get; set; }
        public bool IsDeaf { get; set; }
        public string? ImageUrl { get; set; }
    }
}

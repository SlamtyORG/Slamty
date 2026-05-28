using System.ComponentModel.DataAnnotations;

namespace Slamty.Application.Features.UserProfile.Dtos
{
    public sealed record DeleteProfileDto
    {
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Slamty.Application.Auth.Dtos
{
    public class ResetPasswordDto
    {
        [EmailAddress(ErrorMessage = "Invalide email address syntax")]
        public string UserEmail { get; set; }
        public string ValidationToken { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm Password must be as new password")]
        public string ConfirmNewPassword { get; set; }
    }
}

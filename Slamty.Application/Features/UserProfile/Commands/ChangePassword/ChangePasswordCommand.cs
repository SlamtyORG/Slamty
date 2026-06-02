namespace Slamty.Application.Features.UserProfile.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<ApiResponse<bool>>
{
#pragma warning disable CS8618
    public string Id { get; set; }

    [DataType(DataType.Password)]
    public string NewPassword { get; set; }


    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Confirm Password must be as new password")]
    public string ConfirmNewPassword { get; set; }
}
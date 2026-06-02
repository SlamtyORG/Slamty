namespace Slamty.Application.Features.UserProfile.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UpdateProfileCommandHandler> _logger;

    public ChangePasswordCommandHandler(IUnitOfWork unitOfWork,
                                       UserManager<AppUser> userManager,
                                       ILogger<UpdateProfileCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<ApiResponse<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var oldProfile = await _unitOfWork.Repository<MobileUser>().GetByIdAsync(Guid.Parse(request.Id));

        if (oldProfile is null)
        {
            _logger.LogWarning("Profile with ID {ProfileId} not found", request.Id);
            return new ApiResponse<bool>(HttpStatusCode.NotFound, false, "Profile not found");
        }

        var user = await _userManager.FindByEmailAsync(oldProfile.User.Email!);


        if (user == null)
            return new ApiResponse<bool>(data: false, statusCode: System.Net.HttpStatusCode.NotFound,
                message: "User not found.");

        var generatedToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        var tokenVeryfication = await _userManager
        .ResetPasswordAsync(user, generatedToken, request.NewPassword);

        if (!tokenVeryfication.Succeeded)
            return new ApiResponse<bool>(data: false, statusCode: System.Net.HttpStatusCode.Unauthorized,
                message: "Error try Later");

        return new ApiResponse<bool>(data: true, statusCode: System.Net.HttpStatusCode.OK,
            message: "Password has changed.");
    }

}
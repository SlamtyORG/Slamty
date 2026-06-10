using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Features.UserProfile.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using Slamty.Domain.Enums;
using System.Net;

namespace Slamty.Application.Features.UserProfile.Commands.UpdateProfile
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ApiResponse<ProfileResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<UpdateProfileCommandHandler> _logger;

        public UpdateProfileCommandHandler(IUnitOfWork unitOfWork,
                                           UserManager<AppUser> userManager,
                                           ILogger<UpdateProfileCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<ApiResponse<ProfileResponseDto>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var oldProfile = await _unitOfWork.Repository<MobileUser>().GetByIdAsync(Guid.Parse(request.Id));

            if (oldProfile is null)
            {
                _logger.LogWarning("Profile with ID {ProfileId} not found for update", request.Id);
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.NotFound, null, "Profile not found");
            }

            var user = await _userManager.FindByIdAsync(oldProfile.UserId);

            if (user is null)
            {
                _logger.LogWarning("User with ID {UserId} not found for profile update", oldProfile.UserId);
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.NotFound, null, "User not found");
            }

            if ((!string.IsNullOrEmpty(request.FullName)) && (user.FullName != request.FullName))
            {
                _logger.LogInformation("Updating FullName for User ID {UserId} from {OldFullName} to {NewFullName}", user.Id, user.FullName, request.FullName);
                user.FullName = request.FullName;
            }

            if ((!string.IsNullOrEmpty(request.PhoneNumber)) && (user.PhoneNumber != request.PhoneNumber))
            {
                _logger.LogInformation("Updating PhoneNumber for User ID {UserId} from {OldPhoneNumber} to {NewPhoneNumber}", user.Id, user.PhoneNumber, request.PhoneNumber);
                user.PhoneNumber = request.PhoneNumber;
            }

            if ((!string.IsNullOrEmpty(request.Email)) && (user.Email != request.Email))
            {
                _logger.LogInformation("Updating Email for User ID {UserId} from {OldEmail} to {NewEmail}", user.Id, user.Email, request.Email);
                user.Email = request.Email;
            }

            if (string.IsNullOrEmpty(request.NationalId) && (oldProfile.NationalId != request.NationalId))
            {
                _logger.LogInformation("Updating NationalId for User ID {UserId} from {OldNationalId} to {NewNationalId}", user.Id, oldProfile.NationalId, request.NationalId);
                oldProfile.NationalId = request.NationalId;
            }

            if ((!string.IsNullOrEmpty(request.BloodType)) && (oldProfile.BloodType.ToString() != request.BloodType))
            {
                _logger.LogInformation("Updating BloodType for User ID {UserId} from {OldBloodType} to {NewBloodType}", user.Id, oldProfile.BloodType, request.BloodType);
                oldProfile.BloodType = Enum.Parse<BloodTypes>(request.BloodType);
            }

            if ((request.IsDeaf != oldProfile.IsDeaf))
            {
                _logger.LogInformation("Updating IsDeaf for User ID {UserId} from {OldIsDeaf} to {NewIsDeaf}", user.Id, oldProfile.IsDeaf, request.IsDeaf);
                oldProfile.IsDeaf = request.IsDeaf;
            }

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("Failed to update profile for User ID {UserId}. Database save operation returned {Result}", user.Id, result);
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.InternalServerError, null, "Failed to update profile");
            }

            var identityResult = await _userManager.UpdateAsync(user);

            if (!identityResult.Succeeded)
            {
                _logger.LogError("Failed to update user information for User ID {UserId}. IdentityResult: {IdentityResult}", user.Id, identityResult);
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.InternalServerError, null, "Failed to update user information");
            }

            _logger.LogInformation("Profile for User ID {UserId} updated successfully", user.Id);

            return new ApiResponse<ProfileResponseDto>(HttpStatusCode.OK, new ProfileResponseDto
            {
                ProfileId = oldProfile.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                NationalId = oldProfile.NationalId,
                BloodType = oldProfile.BloodType.ToString(),
                IsDeaf = oldProfile.IsDeaf,
            }, "Profile updated successfully");
        }
    }
}

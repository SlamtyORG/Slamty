using MediatR;
using Microsoft.AspNetCore.Identity;
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

        public UpdateProfileCommandHandler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<ApiResponse<ProfileResponseDto>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var oldProfile = await _unitOfWork.Repository<MobileUser>().GetByIdAsync(Guid.Parse(request.Id));

            if (oldProfile is null)
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.NotFound, null, "Profile not found");

            var user = await _userManager.FindByIdAsync(oldProfile.UserId);

            if (user is null)
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.NotFound, null, "User not found");

            if ((!string.IsNullOrEmpty(request.FullName)) && (user.FullName != request.FullName))
                user.FullName = request.FullName;

            if ((!string.IsNullOrEmpty(request.PhoneNumber)) && (user.PhoneNumber != request.PhoneNumber))
                user.PhoneNumber = request.PhoneNumber;

            if ((!string.IsNullOrEmpty(request.Email)) && (user.Email != request.Email))
                user.Email = request.Email;

            if ((request.NationalId != 0) && (oldProfile.NationalId != request.NationalId))
                oldProfile.NationalId = request.NationalId;

            if ((!string.IsNullOrEmpty(request.BloodType)) && (oldProfile.BloodType.ToString() != request.BloodType))
                oldProfile.BloodType = Enum.Parse<BloodTypes>(request.BloodType);

            if ((request.IsDeaf != oldProfile.IsDeaf))
                oldProfile.IsDeaf = request.IsDeaf;

            var result = await _unitOfWork.Complete();

            if (result <= 0)
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.InternalServerError, null, "Failed to update profile");

            var identityResult = await _userManager.UpdateAsync(user);

            if (!identityResult.Succeeded)
                return new ApiResponse<ProfileResponseDto>(HttpStatusCode.InternalServerError, null, "Failed to update user information");

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

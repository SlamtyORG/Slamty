using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Auth.Queries.GetProfile
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, ApiResponse<ProfileResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProfileQueryHandler> _logger;

        public GetProfileQueryHandler(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ILogger<GetProfileQueryHandler> logger)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<ProfileResponseDto>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("GetProfile failed. User with ID {UserId} not found.", request.UserId);
                return new ApiResponse<ProfileResponseDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User not found."
                );
            }

            var userProfile = await _unitOfWork.Repository<MobileUser>().FindByCriatria(p => p.UserId == request.UserId);
            if (userProfile == null)
            {
                _logger.LogWarning("GetProfile failed. Profile for User ID {UserId} not found.", request.UserId);
                return new ApiResponse<ProfileResponseDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User profile not found."
                );
            }

            _logger.LogInformation("Profile retrieved successfully for User ID {UserId}.", request.UserId);

            var profileResponse = new ProfileResponseDto
            {
                ProfileId = userProfile.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                NationalId = userProfile.NationalId,
                BloodType = userProfile.BloodType.ToString(),
                IsDeaf = userProfile.IsDeaf,
                ImageUrl = userProfile.ImageUrl
            };

            return new ApiResponse<ProfileResponseDto>
            (
                data: profileResponse,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Profile retrieved successfully."
            );
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using Slamty.Domain.Enums;

namespace Slamty.Application.Auth.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, ApiResponse<AuthResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly ILogger<RegistrationCommandHandler> _logger;

        public RegistrationCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService, IUnitOfWork unitOfWork, ILogger<RegistrationCommandHandler> logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<AuthResponseDto>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber
            };

            var accessTtoken = await _tokenService.CreateTokenAsync(user, ["User"]);
            user.RefreshToken = await _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);

            var CreateUserResult = await _userManager.CreateAsync(user, request.Password);
            if (!CreateUserResult.Succeeded)
            {
                _logger.LogError("User creation failed for {PhoneNumber}. Errors: {Errors}", request.PhoneNumber, string.Join(", ", CreateUserResult.Errors.Select(e => e.Description)));
                return new ApiResponse<AuthResponseDto>(
                    System.Net.HttpStatusCode.BadRequest,
                    null,
                    string.Join(", ", CreateUserResult.Errors.Select(e => e.Description))
                    );
            }
            _logger.LogInformation("User created successfully with ID {UserId} for phone number {PhoneNumber}", user.Id, request.PhoneNumber);
            await _userManager.AddToRoleAsync(user, "User");

            var userProfile = new MobileUser
            {
                NationalId = request.NationalId,
                BloodType = Enum.Parse<BloodTypes>(request.BloodType),
                IsDeaf = request.IsDeaf
            };

            _unitOfWork.Repository<MobileUser>().Add(userProfile);

            var CreateProfileResult = await _unitOfWork.Complete();
            if (CreateProfileResult == 0)
            {
                _logger.LogError("Failed to create user profile for user ID {UserId}. Rolling back user creation.", user.Id);
                await _userManager.DeleteAsync(user);
                _logger.LogInformation("User with ID {UserId} deleted successfully after profile creation failure.", user.Id);
                return new ApiResponse<AuthResponseDto>(
                    System.Net.HttpStatusCode.InternalServerError,
                    null,
                    "Failed to create user profile."
                    );
            }

            _logger.LogInformation("User profile created successfully for user ID {UserId} with profile ID {ProfileId}", user.Id, userProfile.Id);
            var apiResponse = new ApiResponse<AuthResponseDto>
            (
                statusCode: System.Net.HttpStatusCode.Created,
                data: new AuthResponseDto
                {
                    AccessToken = accessTtoken,
                    RefreshToken = user.RefreshToken,
                    UserId = user.Id,
                    ProfileId = userProfile.Id.ToString(),
                    FullName = user.FullName
                },
                message: "User registered successfully."
            );
            return apiResponse;
        }
    }
}

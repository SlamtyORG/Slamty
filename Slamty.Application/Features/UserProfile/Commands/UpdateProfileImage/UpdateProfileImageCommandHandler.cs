using MediatR;
using Microsoft.Extensions.Logging;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using System.Net;

namespace Slamty.Application.Features.UserProfile.Commands.UpdateProfileImage
{
    public class UpdateProfileImageCommandHandler : IRequestHandler<UpdateProfileImageCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateProfileImageCommandHandler> _logger;

        public UpdateProfileImageCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateProfileImageCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<string>> Handle(UpdateProfileImageCommand request, CancellationToken cancellationToken)
        {
            var profile = await _unitOfWork.Repository<MobileUser>().GetByIdAsync(Guid.Parse(request.ProfileId));

            if (profile is null)
            {
                _logger.LogWarning("Profile with ID {ProfileId} not found", request.ProfileId);
                return new ApiResponse<string>(HttpStatusCode.NotFound, null, "Profile not found");
            }

            if (request.Image is null || request.Image.Length == 0)
            {
                _logger.LogWarning("No image file provided for profile ID {ProfileId}", request.ProfileId);
                return new ApiResponse<string>(HttpStatusCode.BadRequest, null, "No image file provided");
            }

            var imageUrl = Utitly.DocumentSetting.UploadFile(request.Image, "Images");

            if (string.IsNullOrEmpty(imageUrl))
            {
                _logger.LogError("Failed to upload image for profile ID {ProfileId}", request.ProfileId);
                return new ApiResponse<string>(HttpStatusCode.InternalServerError, null, "Failed to upload image");
            }

            if (profile.ImageUrl is not null)
            {
                _logger.LogInformation("Deleted old image for profile ID {ProfileId}", request.ProfileId);
                Utitly.DocumentSetting.DeleteFile(profile.ImageUrl);
            }

            profile.ImageUrl = imageUrl;

            _unitOfWork.Repository<MobileUser>().Update(profile);

            await _unitOfWork.Complete();

            _logger.LogInformation("Updated profile image for profile ID {ProfileId}", request.ProfileId);

            return new ApiResponse<string>(HttpStatusCode.OK, imageUrl, "Profile image updated successfully");

        }
    }
}

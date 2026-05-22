using MediatR;
using Microsoft.AspNetCore.Identity;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, ApiResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;
        public DeleteProfileCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApiResponse<bool>> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserEmail);

            if (user == null)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.NotFound, false, "User not found.");

            await _userManager.DeleteAsync(user);

            return new ApiResponse<bool>(System.Net.HttpStatusCode.OK, true, "User deleted successfuly.");
        }
    }

}

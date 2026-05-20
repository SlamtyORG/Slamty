using MediatR;
using Slamty.Application.Features.UserProfile.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<ApiResponse<ProfileResponseDto>>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int NationalId { get; set; }
        public string BloodType { get; set; }
        public bool IsDeaf { get; set; }
    }
}

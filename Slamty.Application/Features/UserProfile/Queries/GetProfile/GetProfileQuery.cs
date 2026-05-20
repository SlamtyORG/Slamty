using MediatR;
using Slamty.Application.Features.UserProfile.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.UserProfile.Queries.GetProfile
{
    public class GetProfileQuery : IRequest<ApiResponse<ProfileResponseDto>>
    {
        public string UserId { get; set; }

        public GetProfileQuery(string userId)
        {
            UserId = userId;
        }
    }
}

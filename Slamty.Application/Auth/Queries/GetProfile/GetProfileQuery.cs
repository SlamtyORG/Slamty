using MediatR;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Auth.Queries.GetProfile
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

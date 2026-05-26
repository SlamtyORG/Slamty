using MediatR;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Home.Queries.GetHome
{
    public class GetHomeQuery : IRequest<ApiResponse<HomeResponseDto>>
    {
        public string UserId { get; set; }

        public GetHomeQuery(string userId)
        {
            UserId = userId;
        }
    }
}

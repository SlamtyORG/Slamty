using MediatR;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Queries.GetReports
{
    public class GetReportsQuery : IRequest<ApiResponse<List<ReportDto>>>
    {
        public string UserId { get; set; }

        public GetReportsQuery(string userId)
        {
            UserId = userId;
        }
    }
}

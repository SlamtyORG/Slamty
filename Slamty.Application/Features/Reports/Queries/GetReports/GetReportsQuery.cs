using MediatR;
using Slamty.Application.Features.Common.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Queries.GetReports
{
    public class GetReportsQuery : IRequest<ApiResponse<List<ReportDto>>>
    {
        public Guid UserId { get; set; }

        public GetReportsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

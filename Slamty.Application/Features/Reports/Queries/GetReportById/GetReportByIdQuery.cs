using MediatR;
using Slamty.Application.Features.Common.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<ApiResponse<ReportDto>>
    {
        public Guid ReportId { get; set; }

        public GetReportByIdQuery(Guid reportId)
        {
            ReportId = reportId;
        }
    }
}

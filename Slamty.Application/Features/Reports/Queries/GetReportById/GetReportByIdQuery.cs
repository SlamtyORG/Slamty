using MediatR;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<ApiResponse<ReportDto>>
    {
        public string ReportId { get; set; }

        public GetReportByIdQuery(string reportId)
        {
            ReportId = reportId;
        }
    }
}

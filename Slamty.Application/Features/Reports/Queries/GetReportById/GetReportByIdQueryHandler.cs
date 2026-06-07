using MediatR;
using Microsoft.Extensions.Logging;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ApiResponse<ReportDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetReportByIdQueryHandler> _logger;

        public GetReportByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetReportByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<ReportDto>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _unitOfWork.Repository<Report>().FindByCriatria(r => r.Id == request.ReportId);
            if (report == null)
            {
                _logger.LogWarning("GetReportById failed. Report with ID {ReportId} not found.", request.ReportId);
                return new ApiResponse<ReportDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "Report not found."
                );
            }

            var reportDto = new ReportDto
            {
                Id = report.Id,
                Lat = report.Lat,
                Lng = report.Lng,
                Description = report.Description,
                Attachments = report.Attachments ?? new List<string>(),
                Type = report.Type.ToString(),
                Date = report.Date,
                Status = report.Status.ToString()
            };

            _logger.LogInformation("Report with ID {ReportId} retrieved successfully.", request.ReportId);

            return new ApiResponse<ReportDto>
            (
                data: reportDto,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Report retrieved successfully."
            );
        }
    }
}

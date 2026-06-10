using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Features.Common.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;
using Slamty.Domain.Specifications.ReportsSpecifications;

namespace Slamty.Application.Features.Reports.Queries.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, ApiResponse<List<ReportDto>>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetReportsQueryHandler> _logger;

        public GetReportsQueryHandler(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ILogger<GetReportsQueryHandler> logger)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<List<ReportDto>>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("GetReports failed. User with ID {UserId} not found.", request.UserId);
                return new ApiResponse<List<ReportDto>>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User not found."
                );
            }

            var mobileUser = await _unitOfWork.Repository<MobileUser>().FindByCriatria(m => m.UserId == request.UserId);
            if (mobileUser == null)
            {
                _logger.LogWarning("GetReports failed. Mobile profile for User ID {UserId} not found.", request.UserId);
                return new ApiResponse<List<ReportDto>>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User profile not found."
                );
            }

            var reportIds = mobileUser.Reports?.Select(r => r.Id).ToList() ?? new List<string>();

            List<Report> reports;
            if (reportIds.Any())
            {
                var spec = new GetReportsByUserIdSpecification(reportIds);
                reports = await _unitOfWork.Repository<Report>().GetBySpecAsync(spec);
            }
            else
            {
                reports = new List<Report>();
            }

            var reportDtos = reports.Select(r => new ReportDto
            {
                Id = r.Id,
                Lat = r.Lat,
                Lng = r.Lng,
                Description = r.Description,
                Attachments = r.Attachments ?? new List<string>(),
                Type = r.Type.ToString(),
                Date = r.Date,
                Status = r.Status.ToString()
            }).ToList();

            _logger.LogInformation("Reports retrieved successfully for User ID {UserId}. Returned {Count} reports.", request.UserId, reportDtos.Count);

            return new ApiResponse<List<ReportDto>>
            (
                data: reportDtos,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Reports retrieved successfully."
            );
        }
    }
}

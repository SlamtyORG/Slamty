using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Slamty.Application.Features.Home.Dtos;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Home.Queries.GetHome
{
    public class GetHomeQueryHandler : IRequestHandler<GetHomeQuery, ApiResponse<HomeResponseDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetHomeQueryHandler> _logger;

        public GetHomeQueryHandler(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ILogger<GetHomeQueryHandler> logger)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ApiResponse<HomeResponseDto>> Handle(GetHomeQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                _logger.LogWarning("GetHome failed. User with ID {UserId} not found.", request.UserId);
                return new ApiResponse<HomeResponseDto>
                (
                    data: null,
                    statusCode: System.Net.HttpStatusCode.NotFound,
                    message: "User not found."
                );
            }

            var spec = new GetLatestReportsSpecification();
            var latestReports = await _unitOfWork.Repository<Report>().GetBySpecAsync(spec);

            var reportDtos = latestReports.Select(r => new ReportDto
            {
                Id = r.Id,
                Lat = r.Lat,
                Lng = r.Lng,
                Description = r.Description,
                Attachments = r.Attachments ?? new List<string>(),
                Type = r.Type.ToString(),
                IsNow = r.ActiveNow,
                Status = r.Status.ToString()
            }).ToList();

            _logger.LogInformation("Home data retrieved successfully for User ID {UserId}. Returned {Count} reports.", request.UserId, reportDtos.Count);

            var homeResponse = new HomeResponseDto
            {
                LatestReports = reportDtos
            };

            return new ApiResponse<HomeResponseDto>
            (
                data: homeResponse,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Home data retrieved successfully."
            );
        }
    }
}

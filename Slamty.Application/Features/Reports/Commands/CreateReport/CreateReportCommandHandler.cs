using MediatR;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ApiResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                Lat = request.ReportDto.Lat,
                Lng = request.ReportDto.Lng,
                Description = request.ReportDto.Description,
                Attachments = request.ReportDto.Attachments,
                Type = request.ReportDto.Type,
                ActiveNow = request.ReportDto.ActiveNow,
                Date = request.ReportDto.Date,

            };
            await _unitOfWork.Repository<Report>()
                .AddAsync(report);
            await _unitOfWork.Complete();

            return new ApiResponse(System.Net.HttpStatusCode.Created, "Report created successfully", report.Id);
        }
    }
}

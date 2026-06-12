using MediatR;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ApiResponse<string>>

    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                Lat = request.Lat,
                Lng = request.Lng,
                Description = request.Description,
                Attachments = request.Attachments,
                Type = request.Type,
                Date = request.Date,

            };
            await _unitOfWork.Repository<Report>()
                .AddAsync(report);
            await _unitOfWork.Complete();

            return new ApiResponse<string>(System.Net.HttpStatusCode.Created, "Report created successfully", report.Id);

        }
    }
}

using MediatR;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
<<<<<<< HEAD
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ApiResponse<string>>
=======
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ApiResponse>
>>>>>>> FixesBugesAtOTP
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

<<<<<<< HEAD
        public async Task<ApiResponse<string>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
=======
        public async Task<ApiResponse> Handle(CreateReportCommand request, CancellationToken cancellationToken)
>>>>>>> FixesBugesAtOTP
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

<<<<<<< HEAD
            return new ApiResponse<string>(System.Net.HttpStatusCode.Created, "Report created successfully", report.Id);
=======
            return new ApiResponse(System.Net.HttpStatusCode.Created, "Report created successfully", report.Id);
>>>>>>> FixesBugesAtOTP
        }
    }
}

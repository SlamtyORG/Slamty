using MediatR;
using Slamty.Application.Interfaces.Repositores;
using Slamty.Application.ResponseTypes;
using Slamty.Domain.Entities;

namespace Slamty.Application.Features.Reports.Commands.DeleteReport
{
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _unitOfWork.Repository<Report>().GetByIdAsync(request.ReportId);
            if (report == null)
                return new ApiResponse<bool>(System.Net.HttpStatusCode.NotFound, false, "Report not found.");
            _unitOfWork.Repository<Report>().Delete(report);
            await _unitOfWork.Complete();

            return new ApiResponse<bool>(System.Net.HttpStatusCode.OK, true, "Report deleted successfully.");
        }
    }


}

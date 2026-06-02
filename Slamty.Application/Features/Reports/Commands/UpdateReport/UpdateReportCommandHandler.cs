using Microsoft.EntityFrameworkCore;
using Slamty.Application.Features.Reports.Dtos;
using Slamty.Domain.Enums;

namespace Slamty.Application.Features.Reports.Commands.UpdateReport;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, ApiResponse<ReportResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UpdateProfileCommandHandler> _logger;
    private readonly DbContext _context;
    public UpdateReportCommandHandler(IUnitOfWork unitOfWork,
                                       UserManager<AppUser> userManager,
                                       ILogger<UpdateProfileCommandHandler> logger,
                                       DbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _logger = logger;
        _context = dbContext;
    }

    public async Task<ApiResponse<ReportResponseDto>> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var oldReport = await _unitOfWork.Repository<Report>().GetByIdAsync(Guid.Parse(request.Id));

        if (oldReport is null)
        {
            _logger.LogWarning($"Report with ID {request.Id} not found for update");

            return new ApiResponse<ReportResponseDto>(HttpStatusCode.NotFound, null!, "Report not found");
        }

        if (oldReport.Status == ReportStatus.Approved || oldReport.Status == ReportStatus.Rejected)
        {
            _logger.LogWarning($"Report Can not updated because its {oldReport.Status}");

            return new ApiResponse<ReportResponseDto>(HttpStatusCode.NotFound, null!, $"Report Can not updated because its {oldReport.Status}");
        }

        var strategy = _context.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync(cancellationToken);

            List<string> oldAttachments =
                oldReport.Attachments?.ToList() ?? [];

            List<string> uploadedFiles = [];

            try
            {
                // Upload first
                if (request.Attatchments?.Any() == true)
                {
                    foreach (var file in request.Attatchments)
                    {
                        var path = Utitly.DocumentSetting.UploadFile(file, "Images");
                        uploadedFiles.Add(path);
                    }
                }

                _updateReportInfo(
                    request,
                    oldReport,
                    uploadedFiles);

                await _unitOfWork.Complete();

                await transaction.CommitAsync(cancellationToken);

                // Delete old files 
                foreach (var oldFile in oldAttachments)
                {
                    Utitly.DocumentSetting.DeleteFile(oldFile);
                }
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);

                // Remove uploaded files because DB failed
                foreach (var uploadedFile in uploadedFiles)
                {
                    Utitly.DocumentSetting.DeleteFile(uploadedFile);
                }

                throw;
            }
        });

        return new ApiResponse<ReportResponseDto>(HttpStatusCode.OK,
            new ReportResponseDto
            {
                Date = oldReport.Date,
                Description = oldReport.Description,
                Id = oldReport.Id,
                IsNow = oldReport.IsNow,
                Lat = oldReport.Lat,
                Lng = oldReport.Lng,
                Type = oldReport.Type
            },
            "Report updated successfully");
    }


    private void _updateReportInfo(
        UpdateReportCommand request,
        Report oldReport,
        List<string> uploadedFiles)
    {
        oldReport.Lat = request.Lat;
        oldReport.Lng = request.Lng;
        oldReport.Description = request.Description;
        oldReport.Type = request.Type;

        if (request.IsNow)
        {
            oldReport.Date = DateTime.UtcNow;
            oldReport.IsNow = true;
        }
        else
        {
            oldReport.Date = request.Date;
            oldReport.IsNow = false;
        }

        if (uploadedFiles.Any())
        {
            oldReport.Attachments = uploadedFiles;
        }
    }
}
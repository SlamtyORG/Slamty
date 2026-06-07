using FluentValidation;

namespace Slamty.Application.Features.Reports.Commands.DeleteReport
{
    public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
    {
        public DeleteReportCommandValidator()
        {
            RuleFor(d => d.ReportId)
                .NotEmpty()
                .WithMessage("Report ID is required.");
        }

    }

    
}

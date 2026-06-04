using FluentValidation;

namespace Slamty.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQueryValidator : AbstractValidator<GetReportByIdQuery>
    {
        public GetReportByIdQueryValidator()
        {
            RuleFor(x => x.ReportId)
                .NotEmpty().WithMessage("Report ID is required.")
                .NotNull().WithMessage("Report ID cannot be null.");
        }
    }
}

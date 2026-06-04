using FluentValidation;

namespace Slamty.Application.Features.Reports.Queries.GetReports
{
    public class GetReportsQueryValidator : AbstractValidator<GetReportsQuery>
    {
        public GetReportsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .NotNull().WithMessage("User ID cannot be null.");
        }
    }
}

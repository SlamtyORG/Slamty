using FluentValidation;

namespace Slamty.Application.Features.Home.Queries.GetHome
{
    public class GetHomeQueryValidator : AbstractValidator<GetHomeQuery>
    {
        public GetHomeQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .NotNull().WithMessage("User ID cannot be null.");
        }
    }
}

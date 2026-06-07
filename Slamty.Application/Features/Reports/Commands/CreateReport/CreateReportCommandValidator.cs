using FluentValidation;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MinimumLength(20)
                .WithMessage("Description must be at least 20 characters long.")
                .MaximumLength(250)
                .WithMessage("Description must be at most 250 characters long.");


            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Invalid report type.");


        }

    }
}

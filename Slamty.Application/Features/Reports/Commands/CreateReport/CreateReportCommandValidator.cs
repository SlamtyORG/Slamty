using FluentValidation;

namespace Slamty.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.ReportDto.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(x => x.ReportDto.Type)
                .IsInEnum()
                .WithMessage("Invalid report type.");


        }

    }
}

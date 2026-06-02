namespace Slamty.Application.Features.Reports.Commands.UpdateReport;

public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
{
    public UpdateReportCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Report ID is required.");

        RuleFor(x => x.Lat)
            .InclusiveBetween(-90, 90)
            .WithMessage("Latitude must be between -90 and 90.");

        RuleFor(x => x.Lng)
            .InclusiveBetween(-180, 180)
            .WithMessage("Longitude must be between -180 and 180.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters.");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date is required.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Invalid report type.");

        RuleForEach(x => x.Attatchments)
            .Must(file => file.Length <= 50 * 1024 * 1024) // 50 MB
            .WithMessage("Attachment size cannot exceed 10 MB.")
            .When(x => x.Attatchments != null);
    }
}
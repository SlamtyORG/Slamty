using FluentValidation;

namespace Slamty.Application.Features.Images.Commands.UploadImage
{
    public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
    {
        public UploadImageCommandValidator()
        {
            RuleFor(x => x.Length)
                .GreaterThan(0).WithMessage("File cannot be empty.")
                .LessThanOrEqualTo(5 * 1024 * 1024).WithMessage("File size must not exceed 5 MB.");

            RuleFor(x => x.ContentType)
                .Must(BeSupportedImageType).WithMessage("Only image/jpeg, image/png, and image/webp are supported.");
        }

        private bool BeSupportedImageType(string contentType)
        {
            return contentType is "image/jpeg" or "image/png" or "image/webp";
        }
    }
}

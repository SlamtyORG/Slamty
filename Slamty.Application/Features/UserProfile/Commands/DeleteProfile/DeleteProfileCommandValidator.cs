using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(d => d.UserEmail)
                .NotEmpty()
                .WithMessage("email can`t be empty.");
        }
    }

}

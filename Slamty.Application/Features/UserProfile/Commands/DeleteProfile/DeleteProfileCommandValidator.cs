using FluentValidation;

namespace Slamty.Application.Features.UserProfile.Commands.DeleteProfile
{
    public class DeleteProfileCommandValidator : AbstractValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(d => d.DeleteProfileDto.Email)
                .NotEmpty()
                .WithMessage("email can`t be empty.");

            RuleFor(d => d.DeleteProfileDto.Password)
                .NotEmpty()
                .WithMessage("password can`t be empty.");
        }
    }

}

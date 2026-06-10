using MediatR;
using Slamty.Application.Features.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Features.Auth.Commands.Registration
{
    public class RegistrationCommand : IRequest<ApiResponse<AuthResponseDto>>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string BloodType { get; set; }
        public bool IsDeaf { get; set; }
    }
}

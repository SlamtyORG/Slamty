using Slamty.Application.Auth.Dtos;
using Slamty.Application.ResponseTypes;

namespace Slamty.Application.Interfaces.Servicese
{
    public interface IEmailSenderService
    {
        Task<ApiResponse<bool>> SendEmailService(string fromEmail, string toEmail, EmailSenderDto contactDto, string plainType = "plain");
    }
}

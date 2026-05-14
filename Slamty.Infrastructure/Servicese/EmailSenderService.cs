using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Slamty.Application.Auth.Dtos;
using Slamty.Application.Interfaces.Servicese;
using Slamty.Application.ResponseTypes;

namespace Slamty.Infrastructure.Servicese
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _config;

        public EmailSenderService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ApiResponse<bool>> SendEmailService(string fromEmail, string toEmail, EmailSenderDto contactDto, string plainType = "plain")
        {
            string adminEmail = _config["SmtpSettings:AdminEmail"]!;

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Slamty App", adminEmail));

            message.To.Add(new MailboxAddress("Admin", toEmail));

            message.ReplyTo.Add(new MailboxAddress("User", fromEmail));

            message.Subject = contactDto.Subject;

            message.Body = new TextPart(plainType)
            {
                Text = contactDto.Subject
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(
                        host: _config["SmtpSettings:SmtpServer"]!,
                        port: int.Parse(_config["SmtpSettings:Port"]!),
                        options: MailKit.Security.SecureSocketOptions
                        .StartTls
                        );

                    var userName = _config["SmtpSettings:SmtpEmail"]!;
                    var emailPassword = _config["SmtpSettings:Password"]!;

                    await client.AuthenticateAsync(userName, emailPassword);
                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
                catch
                {
                    return new ApiResponse<bool>(data: false,
                        statusCode: System.Net.HttpStatusCode.InternalServerError,
                        message: "Error happend when sending message");
                }
            }
            return new ApiResponse<bool>(data: true,
                statusCode: System.Net.HttpStatusCode.OK,
                message: "Message sent successfuly");
        }
    }
}

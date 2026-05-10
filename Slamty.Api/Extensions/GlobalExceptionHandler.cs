using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Slamty.Core.ResponseTypes;
using System.Net;
using System.Text.Json;

namespace Slamty.API.Extensions
{
    public static class GlobalExceptionHandler
    {
        public static void HandelExceptions(this WebApplication app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async (context) =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature?.Error;
                    if (exception is null) return;

                    context.Response.ContentType = "application/json";
                    var Options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    if (exception is not ValidationException)
                    {
                        var errorResponse = new ApiExceptionResponse
                        (
                            HttpStatusCode.InternalServerError,
                            exception.Message,
                            exception.StackTrace
                        );
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, Options));
                    }

                    var validationException = exception as ValidationException;
                    var errors = validationException?.Errors.Select(e => new ValidationError
                    {
                        ErrorMessage = e.ErrorMessage,
                        PropertyName = e.PropertyName
                    }).ToList();
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    var validationErrorResponse = new ApiValidationExceptionResponse((HttpStatusCode)context.Response.StatusCode, errors ?? null, "Validation Error");

                    await context.Response.WriteAsync(JsonSerializer.Serialize(validationErrorResponse, Options));

                });
            });
        }
    }
}
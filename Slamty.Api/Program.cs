using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;
using Slamty.Api.Extensions;
using Slamty.Application;
using Slamty.Infrastracture;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File("logs/app-.log",
                   rollingInterval: RollingInterval.Day,
                   retainedFileCountLimit: 30,
                   outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
               .MinimumLevel.Information()
               .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Error)
               .MinimumLevel.Override("System", LogEventLevel.Warning)
               .CreateLogger();

builder.Services.AddSerilog();
builder.Services.AddControllers();
builder.Services.AddInfrastractureRegister(builder.Configuration);
builder.Services.AddApplicationRegister();
builder.Services.AddJWTConfigration(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddRateLimiter(
        opt =>
        {
            opt.AddFixedWindowLimiter("requestLimit", options =>
            {
                options.PermitLimit = 10;
                options.Window = TimeSpan.FromMinutes(1);
                options.QueueLimit = 0;
            });
        }
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapSwagger("/openapi/{documentName}.json");
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRateLimiter();

app.MapControllers();

app.Run();

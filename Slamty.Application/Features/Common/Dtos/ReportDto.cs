<<<<<<< HEAD:Slamty.Application/Features/Common/Dtos/ReportDto.cs
namespace Slamty.Application.Features.Common.Dtos
=======
namespace Slamty.Application.Features.Home.Dtos
>>>>>>> FixesBugesAtOTP:Slamty.Application/Features/Home/Dtos/ReportDto.cs
{
    public sealed record ReportDto
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Description { get; set; }
        public List<string> Attachments { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

using Slamty.Domain.Entities;
using Slamty.Domain.Specifications;

namespace Slamty.Application.Features.Reports.Queries.GetReports
{
    public class GetReportsByUserIdSpecification : BaseSpecification<Report>
    {
        public GetReportsByUserIdSpecification(List<string> reportIds)
            : base(r => reportIds.Contains(r.Id))
        {
            OrderByDesc = r => r.Date;
        }
    }
}

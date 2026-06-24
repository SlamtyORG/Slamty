using Slamty.Domain.Entities;

namespace Slamty.Domain.Specifications.ReportsSpecifications
{
    public class GetReportsByUserIdSpecification : BaseSpecification<Report>
    {
        public GetReportsByUserIdSpecification(List<Guid> reportIds)
            : base(r => reportIds.Contains(r.Id))
        {
            OrderByDesc = r => r.Date;
        }
    }
}

using Slamty.Domain.Entities;

namespace Slamty.Domain.Specifications.ReportsSpecifications
{
    public class GetLatestReportsSpecification : BaseSpecification<Report>
    {
        public GetLatestReportsSpecification()
        {
            OrderByDesc = r => r.Date;
            ApplyPagination(0, 3);
        }
    }
}

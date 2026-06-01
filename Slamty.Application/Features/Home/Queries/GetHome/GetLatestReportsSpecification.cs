using Slamty.Domain.Entities;
using Slamty.Domain.Specifications;

namespace Slamty.Application.Features.Home.Queries.GetHome
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

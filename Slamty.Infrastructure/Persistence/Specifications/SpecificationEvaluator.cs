using Microsoft.EntityFrameworkCore;
using Slamty.Core.Entities;
using Talabat.Core.Specifications;

namespace Slamty.Infrastracture.Persistence.Specifications
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GenerateQuery(IQueryable<T> StartQuery, ISpecification<T> Spec)
        {
            var Query = StartQuery;
            if (Spec.Criteria != null)
            {
                Query = Query.Where(Spec.Criteria);
            }
            Query = Spec.OrderBy is not null ? Query.OrderBy(Spec.OrderBy) : Query;
            Query = Spec.OrderByDesc is not null ? Query.OrderByDescending(Spec.OrderByDesc) : Query;
            if (Spec.Take > 0)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }
            Query = Spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            return Query;
        }
    }
}

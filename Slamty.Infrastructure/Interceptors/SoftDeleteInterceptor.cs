using Microsoft.EntityFrameworkCore.Diagnostics;
using Slamty.Domain.Contracts;

namespace Slamty.Infrastructure.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is null ||
                    entry.State != Microsoft.EntityFrameworkCore.EntityState.Deleted ||
                    entry.Entity is not ISoftDeletable entity)
                    continue;

                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                entity.Delete();

            }
            return result;

        }


    }
}

using Application.Abstractions.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SharedKernel;

namespace Infrastructure.Interceptors;

public class AuditInterceptor(IUserContext userContext) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(
                eventData, result, cancellationToken);
        }

        foreach (EntityEntry<IAuditableEntity> entry in eventData.Context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOnUtc = SystemClock.Now;
                // Only set CreatedBy if it's not already set (to handle login scenarios)
                if (entry.Entity.CreatedBy.Equals(default(Ulid)))
                {
                    try
                    {
                        entry.Entity.CreatedBy = userContext.GetUserId();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // During login, user is not authenticated yet, so we'll leave the field as is
                        // It should be set manually in the login handler
                    }
                }
                entry.Entity.LastModifiedOnUtc = SystemClock.Now;
                // Only set LastModifiedBy if it's not already set (to handle login scenarios)
                if (entry.Entity.LastModifiedBy.Equals(default(Ulid)))
                {
                    try
                    {
                        entry.Entity.LastModifiedBy = userContext.GetUserId();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // During login, user is not authenticated yet, so we'll leave the field as is
                        // It should be set manually in the login handler
                    }
                }
            }

            else if (entry.State == EntityState.Modified)
            {

                    entry.Entity.LastModifiedOnUtc = SystemClock.Now;
                    // Only set LastModifiedBy if it's not already set or if user is authenticated
                    if (entry.Entity.LastModifiedBy.Equals(default(Ulid)))
                    {
                        try
                        {
                            entry.Entity.LastModifiedBy = userContext.GetUserId();
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // During login or other unauthenticated operations, leave the field as is
                        }
                    }

            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}

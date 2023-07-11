using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MassTransitBug.Data;

public class DemoExceptionInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var shouldThrow = eventData.Context!.ChangeTracker
            .Entries<InboxState>()
            .Any(e => e.State is EntityState.Added);

        if (shouldThrow)
            throw new DemoException();
            
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MassTransitBug.Data;

public class DemoExecutionStrategy : ExecutionStrategy
{
    public DemoExecutionStrategy(DbContext context, int maxRetryCount, TimeSpan maxRetryDelay)
        : base(context, maxRetryCount, maxRetryDelay)
    {
    }

    public DemoExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay)
        : base(dependencies, maxRetryCount, maxRetryDelay)
    {
    }

    protected override bool ShouldRetryOn(Exception exception)
    {
        return exception is DemoException;
    }
}
using MassTransit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MassTransitBug.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new SqlConnectionStringBuilder
        {
            UserID = "sa",
            Password = "yourStrong(!)Password",
            DataSource = "localhost",
            InitialCatalog = "demo",
            TrustServerCertificate = true
        };

        var connectionString = builder.ConnectionString;
        
        optionsBuilder.UseSqlServer(connectionString, options =>
        {
            options.ExecutionStrategy(c => new DemoExecutionStrategy(c, 2, TimeSpan.FromSeconds(10)));
        });
        
        optionsBuilder.AddInterceptors(new DemoExceptionInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }
}
using MassTransit;
using MassTransitBug.Data;

namespace MassTransitBug.Consumers;

public class PingConsumerDefinition : ConsumerDefinition<PingConsumer>
{
    private readonly IServiceProvider _serviceProvider;

    public PingConsumerDefinition(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<PingConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseEntityFrameworkOutbox<AppDbContext>(_serviceProvider);
    }
}
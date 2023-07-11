using MassTransit;
using MassTransitBug.Messages;

namespace MassTransitBug.Consumers;

public class PingConsumer : IConsumer<PingMessage>
{
    public Task Consume(ConsumeContext<PingMessage> context)
    {
        Console.WriteLine("Consumed ping message.");
        
        return Task.CompletedTask;
    }
}
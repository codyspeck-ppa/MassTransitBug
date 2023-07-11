using MassTransit;
using MassTransitBug.Consumers;
using MassTransitBug.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddMassTransit(mt =>
{
    mt.SetKebabCaseEndpointNameFormatter();
    
    mt.AddConsumer<PingConsumer, PingConsumerDefinition>();
    
    mt.UsingInMemory((ctx, cfg) =>
    {
        cfg.ConfigureEndpoints(ctx);
    });
    
    mt.AddEntityFrameworkOutbox<AppDbContext>(options =>
    {
        options.UseBusOutbox();
        options.UseSqlServer();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

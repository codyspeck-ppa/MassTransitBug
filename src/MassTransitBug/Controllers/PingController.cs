using MassTransit;
using MassTransitBug.Data;
using MassTransitBug.Messages;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitBug.Controllers;

[ApiController]
public class PingController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly AppDbContext _appDbContext;

    public PingController(IPublishEndpoint publishEndpoint, AppDbContext appDbContext)
    {
        _publishEndpoint = publishEndpoint;
        _appDbContext = appDbContext;
    }

    [HttpGet("ping")]
    public async Task<ActionResult> Ping()
    {
        await _publishEndpoint.Publish(new PingMessage());
        await _appDbContext.SaveChangesAsync();
        
        return Ok();
    }
}

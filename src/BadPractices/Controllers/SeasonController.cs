using BadPractices.Domain.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BadPractices.Controllers;

[ApiController]
[Route("[controller]")]
public class SeasonController : ControllerBase
{
    private readonly ILogger<SeasonController> _logger;
    private readonly IMediator _mediator;

    public SeasonController(ILogger<SeasonController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("bad/{country}")]
    public async Task<SeasonsResult> GetBad([FromRoute] string country)
    {
        var command = new SeasonCommand
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Country = country
        };

        return await _mediator.Send<SeasonsResult>(command);
    }

    [HttpGet("refactored/{country}")]
    public async Task<SeasonsResult> GetRefactored([FromRoute] string country)
    {
        var command = new SeasonCommand
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Country = country
        };

        return await _mediator.Send<SeasonsResult>(new SeasonWrapper(command));
    }
}

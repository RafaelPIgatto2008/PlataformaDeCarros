using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeCarros.Commands;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DriverController(IMediator mediator, ILogger<DriverController> logger) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly ILogger<DriverController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    [HttpPost("register-driver")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterDriver([FromBody] DriverDto driverDto, CancellationToken ct)
    {
        try
        {
            var result = await _mediator.Send(new CreateDriverCommand(driverDto), ct);
            if (!result.IsSuccess)
                return BadRequest(result.Errors);
            
            return Ok(result.Value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
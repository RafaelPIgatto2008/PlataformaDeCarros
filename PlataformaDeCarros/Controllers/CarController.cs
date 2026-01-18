using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeCarros.Commands.Car;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CarController(IMediator mediator, ILogger<CarController> logger): ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CarController> _logger;
    
    [HttpPost("register-car")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCar( [FromBody] CarDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediator.Send(new CreateCarCommand(dto), cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error on register car: {dto}", ex.Message);
            throw new Exception(ex.Message);
        }
    }
}
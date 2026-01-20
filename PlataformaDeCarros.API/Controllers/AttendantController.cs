using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlataformaDeCarros.Commands;
using PlataformaDeCarros.DTOs;

namespace PlataformaDeCarros.Controllers;


[ApiController]
[Route("api/[controller]")]

public class AttendantController(ILogger<AttendantController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<AttendantController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IMediator _mediator =  mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpPost("register-attendant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAttendant([FromBody] AttendantDto attendantDto,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediator.Send(new CreateAttendantCommand(attendantDto), cancellationToken);
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
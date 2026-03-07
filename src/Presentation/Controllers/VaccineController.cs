using backend.src.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using backend.src.Application.DTOs;
using backend.src.Application.Commands;
using backend.src.Application.Queries;

namespace backend.src.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaccineController : ControllerBase
{
    private readonly IMediator _mediator;

    public VaccineController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vaccine>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllVaccinesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Vaccine>> Create([FromBody] VaccineDto vaccineDto)
    {
        var result = await _mediator.Send(new CreateVaccineCommand(vaccineDto));
        if (!result)
            return StatusCode(500, new { message = "Erro ao criar vacina" });
        return Ok(new { message = "Vacina criada com sucesso" });
    }
}

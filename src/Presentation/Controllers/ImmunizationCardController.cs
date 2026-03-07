using backend.src.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using backend.src.Application.DTOs;
using backend.src.Application.Commands;
using backend.src.Application.Queries;

namespace backend.src.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImmunizationCardController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImmunizationCardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImmunizationSummaryDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllCardsQuery());
        return Ok(result);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<PatientImmunizationDto>> GetByPatientId(int patientId)
    {
        var result = await _mediator.Send(new GetPatientImmunizationQuery(patientId));
        if (result == null)
            return NotFound(new { message = "Esse paciente não existe ou não tem cartão de vacinação" });

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ImmunizationCard>> Create([FromBody] CardDto cardDto)
    {
        var result = await _mediator.Send(new CreateCardCommand(cardDto));
        if (!result)
            return StatusCode(500, new { message = "Erro ao criar registro de vacinação" });
        return Ok(new { message = "Registro de vacinação criado com sucesso" });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDoseById(int id)
    {
        var result = await _mediator.Send(new DeleteCardCommand(id));

        if (!result)
            return NotFound(new { message = "Registro de vacinação não encontrado" });

        return Ok();
    }
}

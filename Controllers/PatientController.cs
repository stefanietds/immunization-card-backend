using backend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using backend.DTO;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllPatientsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> Create([FromBody] DTO.PatientDto patientDto)
    {
        var result = await _mediator.Send(new CreatePatientCommand(patientDto));
        if (!result)
            return StatusCode(500, new { message = "Erro ao criar paciente" });
        return Ok(new { message = "Paciente criado com sucesso" });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeletePatientCommand(id));

        if (!result)
            return NotFound(new { message = "Paciente não encontrado" });

        return Ok();
    }
}
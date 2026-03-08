using backend.src.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using backend.src.Application.DTOs;
using backend.src.Application.Commands;
using backend.src.Application.Queries;
using FluentValidation;

namespace backend.src.Presentation.Controllers;

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
        try
        {
            var result = await _mediator.Send(new GetAllPatientsQuery());
            return Ok(ApiResponse<object>.SuccessResponse(result, "Dados de pacientes recuperados com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<IEnumerable<Patient>>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> Create([FromBody] PatientDto patientDto)
    {
        try
        {
            var result = await _mediator.Send(new CreatePatientCommand(patientDto));
            if (!result)
                return StatusCode(500, ApiResponse<bool>.ErrorResponse("Erro ao criar paciente"));
            return Ok(ApiResponse<object>.SuccessResponse(result, "Paciente criado com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<Patient>.ErrorResponse(ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeletePatientCommand(id));
            if (!result)
                return NotFound(ApiResponse<bool>.ErrorResponse(
                    "Paciente não encontrado"
                ));

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Paciente removido com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.ErrorResponse(ex.Message));
        }
    }
}

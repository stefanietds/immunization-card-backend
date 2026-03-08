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
        try
        {
            var result = await _mediator.Send(new GetAllCardsQuery());
            return Ok(ApiResponse<object>.SuccessResponse(result, "Dados de cartões de vacinação recuperados com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<IEnumerable<ImmunizationSummaryDto>>.ErrorResponse(ex.Message));
        }
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<ApiResponse<PatientImmunizationDto>>> GetByPatientId(int patientId)
    {
        try
        {
            var result = await _mediator.Send(new GetPatientImmunizationQuery(patientId));

            if (result == null)
                return NotFound(ApiResponse<PatientImmunizationDto>.ErrorResponse(
                    "Esse paciente não existe ou não tem cartão de vacinação"
                ));

            return Ok(ApiResponse<PatientImmunizationDto>.SuccessResponse(result));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<PatientImmunizationDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> Create([FromBody] CardDto cardDto)
    {
        try
        {
            var result = await _mediator.Send(new CreateCardCommand(cardDto));

            if (!result)
                return StatusCode(500,
                    ApiResponse<bool>.ErrorResponse("Erro ao criar registro de vacinação")
                );

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Registro de vacinação criado com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.ErrorResponse(ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteDoseById(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteCardCommand(id));

            if (!result)
                return NotFound(ApiResponse<bool>.ErrorResponse(
                    "Registro de vacinação não encontrado"
                ));

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Registro removido com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<bool>.ErrorResponse(ex.Message));
        }
    }
}

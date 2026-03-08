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
        try
        {
            var result = await _mediator.Send(new GetAllVaccinesQuery());
            return Ok(ApiResponse<object>.SuccessResponse(result, "Dados de vacinas recuperados com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<IEnumerable<Vaccine>>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost]
    public async Task<ActionResult<Vaccine>> Create([FromBody] VaccineDto vaccineDto)
    {
        try
        {
            var result = await _mediator.Send(new CreateVaccineCommand(vaccineDto));
            if (!result)
                return StatusCode(500, ApiResponse<bool>.ErrorResponse("Erro ao criar vacina"));
            return Ok(ApiResponse<object>.SuccessResponse(result, "Vacina criada com sucesso"));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                ApiResponse<Vaccine>.ErrorResponse(ex.Message));
        }
    }
}

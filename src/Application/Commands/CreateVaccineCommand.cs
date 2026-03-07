using MediatR;
using backend.src.Application.DTOs;

namespace backend.src.Application.Commands;

public class CreateVaccineCommand : IRequest<bool>
{
    public VaccineDto VaccineDto { get; set; }

    public CreateVaccineCommand(VaccineDto vaccineDto)
    {
        VaccineDto = vaccineDto;
    }
}

using MediatR;
using backend.DTO;

public class CreateVaccineCommand : IRequest<bool>
{
    public VaccineDto VaccineDto { get; set; }

    public CreateVaccineCommand(VaccineDto vaccineDto)
    {
        VaccineDto = vaccineDto;
    }
}
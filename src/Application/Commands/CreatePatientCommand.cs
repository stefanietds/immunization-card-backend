using MediatR;
using backend.src.Application.DTOs;

namespace backend.src.Application.Commands;

public class CreatePatientCommand : IRequest<bool>
{
    public PatientDto PatientDto { get; set; }

    public CreatePatientCommand(PatientDto patientDto)
    {
        PatientDto = patientDto;
    }
}

using MediatR;
using backend.DTO;

public class CreatePatientCommand : IRequest<bool>
{
    public PatientDto PatientDto { get; set; }

    public CreatePatientCommand(PatientDto patientDto)
    {
        PatientDto = patientDto;
    }
}
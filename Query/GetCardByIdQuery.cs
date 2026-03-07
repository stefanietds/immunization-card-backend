using backend.DTO;
using MediatR;

public class GetPatientImmunizationQuery : IRequest<PatientImmunizationDto?>
{
    public int PatientId { get; set; }

    public GetPatientImmunizationQuery(int patientId)
    {
        PatientId = patientId;
    }
}
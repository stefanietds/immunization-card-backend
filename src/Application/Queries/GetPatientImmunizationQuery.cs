using backend.src.Application.DTOs;
using MediatR;

namespace backend.src.Application.Queries;

public class GetPatientImmunizationQuery : IRequest<PatientImmunizationDto?>
{
    public int PatientId { get; set; }

    public GetPatientImmunizationQuery(int patientId)
    {
        PatientId = patientId;
    }
}

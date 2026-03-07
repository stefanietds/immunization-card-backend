using backend.DTO;
using MediatR;

public class GetPatientImmunizationQueryHandler
    : IRequestHandler<GetPatientImmunizationQuery, PatientImmunizationDto?>
{
    private readonly IRepositoryCard _repository;

    public GetPatientImmunizationQueryHandler(IRepositoryCard repository)
    {
        _repository = repository;
    }

    public async Task<PatientImmunizationDto?> Handle(
        GetPatientImmunizationQuery request,
        CancellationToken cancellationToken)
    {
        if (request.PatientId <= 0)
        {
            throw new ArgumentException("ID do paciente deve ser maior que zero");
        }
        
        return await _repository.GetByPatientId(request.PatientId);
    }
}
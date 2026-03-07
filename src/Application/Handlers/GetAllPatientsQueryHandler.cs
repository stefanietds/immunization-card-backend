using MediatR;
using backend.src.Domain.Models;
using backend.src.Application.Queries;
using backend.src.Infrastructure.Repositories;

namespace backend.src.Application.Handlers;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<Patient>>
{
    private readonly IRepositoryPatient _repository;

    public GetAllPatientsQueryHandler(IRepositoryPatient repository)
    {
        _repository = repository;
    }

    public async Task<List<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repository.GetAll();
        return patients.ToList();
    }
}

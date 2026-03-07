using MediatR;
using backend.src.Domain.Models;
using backend.src.Application.Queries;
using backend.src.Infrastructure.Repositories;

namespace backend.src.Application.Handlers;

public class GetAllVaccinesQueryHandler : IRequestHandler<GetAllVaccinesQuery, List<Vaccine>>
{
    private readonly IRepositoryVaccine _repository;

    public GetAllVaccinesQueryHandler(IRepositoryVaccine repository)
    {
        _repository = repository;
    }

    public async Task<List<Vaccine>> Handle(GetAllVaccinesQuery request, CancellationToken cancellationToken)
    {
        var vaccines = await _repository.GetAll();
        return vaccines.ToList();
    }
}

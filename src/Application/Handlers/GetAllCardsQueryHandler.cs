using backend.src.Application.DTOs;
using MediatR;
using backend.src.Application.Queries;
using backend.src.Infrastructure.Repositories;

namespace backend.src.Application.Handlers;

public class GetAllCardsQueryHandler 
    : IRequestHandler<GetAllCardsQuery, List<ImmunizationSummaryDto>>
{
    private readonly IRepositoryCard _repository;

    public GetAllCardsQueryHandler(IRepositoryCard repository)
    {
        _repository = repository;
    }

    public async Task<List<ImmunizationSummaryDto>> Handle(
        GetAllCardsQuery request,
        CancellationToken cancellationToken)
    {
        var cards = await _repository.GetAll();
        return cards.ToList();
    }
}

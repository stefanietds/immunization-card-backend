using MediatR;
using backend.DTO;

public class GetAllCardsQuery : IRequest<List<ImmunizationSummaryDto>>
{
}
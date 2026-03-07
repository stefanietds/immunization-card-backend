using MediatR;
using backend.src.Application.DTOs;

namespace backend.src.Application.Queries;

public class GetAllCardsQuery : IRequest<List<ImmunizationSummaryDto>>
{
}

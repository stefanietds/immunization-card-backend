using MediatR;
using backend.src.Domain.Models;

namespace backend.src.Application.Queries;

public class GetAllVaccinesQuery : IRequest<List<Vaccine>>
{
}

using MediatR;
using backend.src.Domain.Models;

namespace backend.src.Application.Queries;

public class GetAllPatientsQuery : IRequest<List<Patient>>
{
}

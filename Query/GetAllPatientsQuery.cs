using MediatR;
using backend.Models;

public class GetAllPatientsQuery : IRequest<List<Patient>>
{
}
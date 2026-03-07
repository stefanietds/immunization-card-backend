using MediatR;
using backend.Models;

public class GetAllVaccinesQuery : IRequest<List<Vaccine>>
{
}
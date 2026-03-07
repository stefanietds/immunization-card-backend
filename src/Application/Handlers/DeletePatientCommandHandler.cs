using MediatR;
using backend.src.Application.Commands;
using backend.src.Infrastructure.Repositories;

namespace backend.src.Application.Handlers;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
{
    private readonly IRepositoryPatient _repository;

    public DeletePatientCommandHandler(IRepositoryPatient repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new ArgumentException("ID deve ser maior que zero");
        }
        
        return await _repository.RemovePatient(request.Id);
    }
}

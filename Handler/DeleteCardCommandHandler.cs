using MediatR;

public class DeleteCardCommandHandler 
    : IRequestHandler<DeleteCardCommand, bool>
{
    private readonly IRepositoryCard _repository;

    public DeleteCardCommandHandler(IRepositoryCard repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteCardCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            throw new ArgumentException("ID deve ser maior que zero");
        }

        return await _repository.DeleteRegisterById(request.Id);
    }
}
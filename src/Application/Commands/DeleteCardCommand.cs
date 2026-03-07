using MediatR;

namespace backend.src.Application.Commands;

public class DeleteCardCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteCardCommand(int id)
    {
        Id = id;
    }
}

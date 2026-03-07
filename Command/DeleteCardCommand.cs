using MediatR;

public class DeleteCardCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteCardCommand(int id)
    {
        Id = id;
    }
}
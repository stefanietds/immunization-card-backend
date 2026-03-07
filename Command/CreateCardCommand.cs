using MediatR;
using backend.DTO;

public class CreateCardCommand : IRequest<bool>
{
    public CardDto CardDto { get; set; }

    public CreateCardCommand(CardDto cardDto)
    {
        CardDto = cardDto;
    }
}
using MediatR;
using backend.src.Application.DTOs;

namespace backend.src.Application.Commands;

public class CreateCardCommand : IRequest<bool>
{
    public CardDto CardDto { get; set; }

    public CreateCardCommand(CardDto cardDto)
    {
        CardDto = cardDto;
    }
}

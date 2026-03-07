using MediatR;
using FluentValidation;
using AutoMapper;
using backend.src.Domain.Models;
using backend.src.Application.DTOs;
using backend.src.Application.Commands;
using backend.src.Infrastructure.Repositories;

namespace backend.src.Application.Handlers;

public class CreateCardCommandHandler 
    : IRequestHandler<CreateCardCommand, bool>
{
    private readonly IRepositoryCard _repository;
    private readonly IValidator<CardDto> _validator;
    private readonly IMapper _mapper;

    public CreateCardCommandHandler(IRepositoryCard repository, IValidator<CardDto> validator, IMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<bool> Handle(
        CreateCardCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.CardDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var card = _mapper.Map<ImmunizationCard>(request.CardDto);
        card.ApplicationDate = DateTime.Now;
        return await _repository.AddCard(card);
    }
}

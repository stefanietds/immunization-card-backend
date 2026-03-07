using MediatR;
using FluentValidation;
using AutoMapper;
using backend.Models;
using backend.DTO;

public class CreateVaccineCommandHandler : IRequestHandler<CreateVaccineCommand, bool>
{
    private readonly IRepositoryVaccine _repository;
    private readonly IValidator<VaccineDto> _validator;
    private readonly IMapper _mapper;

    public CreateVaccineCommandHandler(IRepositoryVaccine repository, IValidator<VaccineDto> validator, IMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateVaccineCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.VaccineDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var vaccine = _mapper.Map<Vaccine>(request.VaccineDto);
        return await _repository.AddVaccine(vaccine);
    }
}
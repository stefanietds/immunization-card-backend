using MediatR;
using FluentValidation;
using AutoMapper;
using backend.Models;
using backend.DTO;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, bool>
{
    private readonly IRepositoryPatient _repository;
    private readonly IValidator<PatientDto> _validator;
    private readonly IMapper _mapper;

    public CreatePatientCommandHandler(IRepositoryPatient repository, IValidator<PatientDto> validator, IMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.PatientDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var patient = _mapper.Map<Patient>(request.PatientDto);
        return await _repository.AddPatient(patient);
    }
}
using FluentValidation;
using backend.src.Application.DTOs;

namespace backend.src.Application.Validators;

public class CardDtoValidator : AbstractValidator<CardDto>
{
    public CardDtoValidator()
    {
        RuleFor(c => c.PatientId)
            .NotEmpty().WithMessage("ID do paciente é obrigatório")
            .GreaterThan(0).WithMessage("ID do paciente deve ser maior que zero");
        RuleFor(c => c.VaccineId)
            .NotEmpty().WithMessage("ID da vacina é obrigatório")
            .GreaterThan(0).WithMessage("ID da vacina deve ser maior que zero");
        RuleFor(c => c.Dose)
            .NotEmpty().WithMessage("Dose é obrigatória")
            .GreaterThan(0).WithMessage("Dose deve ser maior que zero");
    }
}

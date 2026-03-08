using FluentValidation;
using backend.src.Application.DTOs;

namespace backend.src.Application.Validators;

public class PatientDtoValidator : AbstractValidator<PatientDto>
{
    public PatientDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");
        
        RuleFor(p => p.Cpf)
            .NotEmpty().WithMessage("CPF é obrigatório")
            .Matches(@"^\d{11}$").WithMessage("CPF deve conter exatamente 11 dígitos numéricos");
    }
}

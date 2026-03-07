using FluentValidation;
using backend.DTO;

namespace backend.Validators;

public class PatientDtoValidator : AbstractValidator<PatientDto>
{
    public PatientDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");
    }
}

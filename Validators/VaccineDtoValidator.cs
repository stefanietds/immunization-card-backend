using FluentValidation;
using backend.DTO;

namespace backend.Validators;

public class VaccineDtoValidator : AbstractValidator<VaccineDto>
{
    public VaccineDtoValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");
    }
}
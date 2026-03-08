using FluentValidation;
using backend.src.Application.DTOs;

namespace backend.src.Application.Validators;

public class VaccineDtoValidator : AbstractValidator<VaccineDto>
{
    public VaccineDtoValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");
        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Código é obrigatório")
            .MaximumLength(10).WithMessage("Código deve ter no máximo 10 caracteres");
    }
}

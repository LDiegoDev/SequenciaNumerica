using FluentValidation;
using SequenciaNumerica.Api.Models;

namespace SequenciaNumerica.Api.Validators;

public class SequenciaInputValidator : AbstractValidator<SequenciaInput>
{
    public SequenciaInputValidator()
    {
        RuleFor(x => x.Valores)
            .NotNull().WithMessage("A lista de valores é obrigatória.")
            .NotEmpty().WithMessage("A lista não pode estar vazia.");

        RuleFor(x => x.Valores.Count)
            .LessThanOrEqualTo(10000)
            .WithMessage("A sequência não pode ter mais de 10.000 números.");

    }
}

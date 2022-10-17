using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.ViewModels.Anuncio;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class AnuncioRequestValidator : AbstractValidator<RequestAnuncio>
    {
        public AnuncioRequestValidator(IImobiliariaRepository imobiliariaRepository)
        {
            RuleFor(x => x.Descricao)
                .MaximumLength(256);

            RuleFor(x => x.Ativo)
                .Must(x => x == false || x == true);

            RuleFor(x => x.ImobiliariaId)
                .NotEqual(0)
                .ValidateForeignKey(imobiliariaRepository);

            RuleFor(x => x.Propriedade)
                .SetValidator(new PropriedadeRequestValidator());
        }
    }
}

using FluentValidation;
using VendaImoveis.Application.ViewModels.Anuncio;

namespace VendaImoveis.Application.Validations
{
    public class AnuncioRequestValidator : AbstractValidator<RequestAnuncio>
    {
        public AnuncioRequestValidator()
        {
            RuleFor(x => x.Descricao)
                .MaximumLength(256);

            RuleFor(x => x.Ativo)
                .Must(x => x == false || x == true);

            RuleFor(x => x.Propriedade)
                .SetValidator(new PropriedadeRequestValidator());
        }
    }
}

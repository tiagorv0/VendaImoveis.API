using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.ViewModels.Venda;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class VendaRequestValidator : AbstractValidator<RequestVenda>
    {
        public VendaRequestValidator(IAnuncioRepository anuncioRepository,
            ICorretorRepository corretorRepository)
        {
            RuleFor(x => x.AnuncioId)
                .NotEqual(0)
                .ValidateForeignKey(anuncioRepository);

            RuleFor(x => x.CorretorId)
                .NotEqual(0)
                .ValidateForeignKey(corretorRepository);
        }
    }
}

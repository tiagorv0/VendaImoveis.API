using FluentValidation;
using VendaImoveis.Application.ViewModels.Propriedade;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities.Enums;

namespace VendaImoveis.Application.Validations
{
    public class PropriedadeRequestValidator : AbstractValidator<RequestPropriedade>
    {
        public PropriedadeRequestValidator()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5)
                .MaximumLength(80)
                .NotEmpty();

            RuleFor(x => x.Endereco)
                .SetValidator(new EnderecoValidator());

            RuleFor(x => x.AreaTotal)
                .NotEmpty();

            RuleFor(x => x.AreaConstruida);

            RuleFor(x => x.QuantidadeGaragem)
                .LessThan(5);

            RuleFor(x => x.Valor)
                .NotEmpty();

            RuleFor(x => x.TipoImovelId)
                .Must(type => Enumeration.GetAll<PropertyType>().Any(x => x.Id == type))
                .WithMessage("Tipo da propriedade inválido");

            RuleFor(x => x.FoiVendida)
                .Must(x => x == false || x == true);
        }
    }
}

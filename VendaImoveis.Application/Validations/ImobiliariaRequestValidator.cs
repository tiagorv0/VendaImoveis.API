using FluentValidation;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Validations
{
    public class ImobiliariaRequestValidator : 
        UsuarioImobiliariaRequestValidator<RequestImobiliaria, Imobiliaria>
    {
        public ImobiliariaRequestValidator(
            IBaseReadOnlyRepository<Imobiliaria> repository,
            IUsuarioRepository usuarioRepository) :
            base(repository, usuarioRepository)
        {
            RuleFor(x => x.CNPJ)
                .MustAsync((cnpj, cancelToken) => repository.ExistAsync(x => x.CNPJ.Equals(cnpj)))
                .WithMessage("{PropertyName} já existente");

            RuleFor(x => x.CNPJ)
                .Length(17)
                .NotEmpty();

            RuleFor(x => x.Endereco)
                .SetValidator(new EnderecoValidator());
        }
    }
}

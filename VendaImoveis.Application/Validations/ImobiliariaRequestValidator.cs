using FluentValidation;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class ImobiliariaRequestValidator : 
        UsuarioImobiliariaRequestValidator<RequestImobiliaria, Imobiliaria>
    {
        public ImobiliariaRequestValidator(
            IImobiliariaRepository repository,
            IUsuarioRepository usuarioRepository, IAuthService service) :
            base(repository, usuarioRepository)
        {
            RuleFor(x => x.CNPJ)
                .ValidateCNPJ(repository, service)
                .WithMessage("{PropertyName} já existente");

            RuleFor(x => x.CNPJ)
                .Length(18)
                .NotEmpty();

            RuleFor(x => x.CNPJ)
                .Must(cnpj => RegexValidate.CNPJEhValido(cnpj))
                .WithMessage("{PropertyName} não é válido!");

            RuleFor(x => x.Endereco)
                .SetValidator(new EnderecoValidator());
        }
    }
}

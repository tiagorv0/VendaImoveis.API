using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Imobiliaria;
using VendaImoveis.Domain.Entities;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class ImobiliariaRequestValidator :
        UsuarioImobiliariaRequestValidator<RequestImobiliaria, Imobiliaria>
    {
        public ImobiliariaRequestValidator(
            IImobiliariaRepository imobiliariaRepository,
            IAuthService authService
        ) : base(imobiliariaRepository, authService)
        {
            RuleFor(x => x.CNPJ)
                .ValidateCNPJ(imobiliariaRepository, authService);

            RuleFor(x => x.CNPJ)
                .Length(18)
                .NotEmpty();

            RuleFor(x => x.CNPJ)
                .Must(cnpj => PropertyValidation.CNPJEhValido(cnpj))
                .WithMessage("{PropertyName} não é válido!");

            RuleFor(x => x.Endereco)
                .SetValidator(new EnderecoValidator());
        }
    }
}

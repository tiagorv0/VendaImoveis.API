using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Common;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Validations
{
    public class UsuarioImobiliariaRequestValidator<TRequest, TEntity> : UsuarioRequestValidator<TRequest, TEntity>
        where TRequest : RequestUsuariosImobiliaria
        where TEntity : UsuariosImobiliaria
    {
        public UsuarioImobiliariaRequestValidator(
            IBaseReadOnlyRepository<TEntity> repository,
            IAuthService authService
        ) : base(repository, authService)
        {
            RuleFor(x => x.Nome)
                .MinimumLength(2)
                .MaximumLength(80)
                .NotEmpty();

            RuleFor(x => x.CRECI)
                .ValidateCRECI(repository, authService);

            RuleFor(x => x.Telefone)
                .MinimumLength(14)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.Telefone)
                .Must(telefone => PropertyValidation.TelefoneEhValido(telefone))
                .WithMessage("{PropertyName} não é válido!");
        }
    }
}

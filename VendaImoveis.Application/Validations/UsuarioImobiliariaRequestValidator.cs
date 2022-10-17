using FluentValidation;
using VendaImoveis.Application.ViewModels;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Validations
{
    public class UsuarioImobiliariaRequestValidator<TRequest, TEntity> :
        AbstractValidator<TRequest> where TRequest : RequestUsuariosImobiliaria
        where TEntity : UsuariosImobiliaria
    {
        public UsuarioImobiliariaRequestValidator(
            IBaseReadOnlyRepository<TEntity> repository, 
            IUsuarioRepository usuarioRepository)
        {
            RuleFor(x => x.Nome)
                .MinimumLength(2)
                .MaximumLength(80)
                .NotEmpty();

            RuleFor(x => x.CRECI)
                .MustAsync((creci, cancelToken) => repository.ExistAsync(x => x.CRECI.Equals(creci)))
                .WithMessage("{PropertyName} já existente");

            RuleFor(x => x.Telefone)
                .MinimumLength(14)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.Usuario)
                .SetValidator(new UsuarioRequestValidator(usuarioRepository));
        }
    }
}

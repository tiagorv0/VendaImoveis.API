using FluentValidation;
using VendaImoveis.Application.Extensions;
using VendaImoveis.Application.Interfaces;
using VendaImoveis.Application.Utils;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Interfaces.Common;

namespace VendaImoveis.Application.Validations
{
    public class UsuarioRequestValidator<TRequest, TEntity> : AbstractValidator<TRequest>
        where TRequest : RequestUsuario
        where TEntity : Usuario
    {
        public UsuarioRequestValidator(IBaseReadOnlyRepository<TEntity> repository,
            IAuthService authService)
        {

            RuleFor(x => x.NomeUsuario)
                .MinimumLength(5)
            .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.NomeUsuario)
                .ValidateNomeUsuario(repository, authService);

            RuleFor(x => x.Email)
            .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .ValidateEmail(repository, authService);

            RuleFor(x => x.Senha)
                .MinimumLength(8)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .Must(senha => PropertyValidation.SenhaEhValido(senha))
                .WithMessage("Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
        }
    }
}

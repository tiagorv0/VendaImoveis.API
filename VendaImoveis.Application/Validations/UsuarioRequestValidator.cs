using FluentValidation;
using VendaImoveis.Application.ViewModels.Usuario;
using VendaImoveis.Domain.Core;
using VendaImoveis.Domain.Entities.Enums;
using VendaImoveis.Domain.Interfaces;

namespace VendaImoveis.Application.Validations
{
    public class UsuarioRequestValidator : AbstractValidator<RequestUsuario>
    {
        public UsuarioRequestValidator(IUsuarioRepository usuarioRepository)
        {
            RuleFor(x => x.NomeUsuario)
                .MinimumLength(5)
                .MaximumLength(15)
                .NotEmpty();

            RuleFor(x => x.NomeUsuario)
                .MustAsync((username, cancelToken) => usuarioRepository.ExistAsync(x => x.NomeUsuario.Equals(username)))
                .WithMessage("{PropertyName} Já existe um usuário com usuário informado.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .MustAsync((email, cancelToken) => usuarioRepository.ExistAsync(x => x.Email.Equals(email)))
                .WithMessage("{PropertyName} Já existe um usuário com e-mail informado.");

            RuleFor(x => x.Senha)
                .MinimumLength(8)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(x => x.Senha)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$_!%*?&-])[A-Za-z\d@$!_%*?&-]{8,}$")
                .WithMessage("Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");

            RuleFor(x => x.TipoUsuarioId)
                .Must(type => Enumeration.GetAll<UserRole>().Any(x => x.Id == type))
                .WithMessage("Tipo do usuário inválido");
        }
    }
}
